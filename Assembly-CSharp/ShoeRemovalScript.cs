using UnityEngine;

public class ShoeRemovalScript : MonoBehaviour
{
	public StudentScript Student;

	public Vector3 RightShoePosition;

	public Vector3 LeftShoePosition;

	public Transform RightCurrentShoe;

	public Transform LeftCurrentShoe;

	public Transform RightCasualShoe;

	public Transform LeftCasualShoe;

	public Transform RightSchoolShoe;

	public Transform LeftSchoolShoe;

	public Transform RightNewShoe;

	public Transform LeftNewShoe;

	public Transform RightFoot;

	public Transform LeftFoot;

	public Transform RightHand;

	public Transform LeftHand;

	public Transform ShoeParent;

	public Transform Locker;

	public GameObject NewPairOfShoes;

	public GameObject Character;

	public string[] LockerAnims;

	public Texture OutdoorShoes;

	public Texture IndoorShoes;

	public Texture TargetShoes;

	public Texture Socks;

	public Renderer MyRenderer;

	public bool RemovingCasual = true;

	public bool Male;

	public int Height;

	public int Phase = 1;

	public float X;

	public float Y;

	public float Z;

	public string RemoveCasualAnim = string.Empty;

	public string RemoveSchoolAnim = string.Empty;

	public string RemovalAnim = string.Empty;

	public void Start()
	{
		if (Locker == null)
		{
			GetHeight(Student.StudentID);
			if (Student.StudentID < Student.StudentManager.Lockers.List.Length)
			{
				Locker = Student.StudentManager.Lockers.List[Student.StudentID];
			}
			GameObject gameObject = Object.Instantiate(NewPairOfShoes, base.transform.position, Quaternion.identity);
			gameObject.transform.parent = Locker;
			gameObject.transform.localEulerAngles = new Vector3(0f, -180f, 0f);
			gameObject.transform.localPosition = new Vector3(0f, -0.29f + 0.3f * (float)Height, Male ? 0.04f : 0.05f);
			LeftSchoolShoe = gameObject.transform.GetChild(0);
			RightSchoolShoe = gameObject.transform.GetChild(1);
			RemovalAnim = RemoveCasualAnim;
			RightCurrentShoe = RightCasualShoe;
			LeftCurrentShoe = LeftCasualShoe;
			RightNewShoe = RightSchoolShoe;
			LeftNewShoe = LeftSchoolShoe;
			ShoeParent = gameObject.transform;
			TargetShoes = IndoorShoes;
			RightShoePosition = RightCurrentShoe.localPosition;
			LeftShoePosition = LeftCurrentShoe.localPosition;
			RightCurrentShoe.localScale = new Vector3(1.111113f, 1f, 1.111113f);
			LeftCurrentShoe.localScale = new Vector3(1.111113f, 1f, 1.111113f);
			OutdoorShoes = Student.Cosmetic.CasualTexture;
			IndoorShoes = Student.Cosmetic.UniformTexture;
			Socks = Student.Cosmetic.SocksTexture;
			TargetShoes = IndoorShoes;
		}
	}

	public void StartChangingShoes()
	{
		if (!Student.AoT)
		{
			RightCasualShoe.gameObject.SetActive(value: true);
			LeftCasualShoe.gameObject.SetActive(value: true);
			if (!Male)
			{
				MyRenderer.materials[0].mainTexture = Socks;
				MyRenderer.materials[1].mainTexture = Socks;
			}
			else
			{
				MyRenderer.materials[Student.Cosmetic.UniformID].mainTexture = Socks;
			}
			_ = Student.Follower != null;
		}
	}

	private void Update()
	{
		if (!Student.DiscCheck && !Student.Dying && !Student.InEvent && !Student.Alarmed && !Student.Splashed && !Student.TurnOffRadio)
		{
			if (Student.Destinations[Student.Phase] == null)
			{
				Student.Phase++;
			}
			if (Student.CurrentDestination == null)
			{
				Student.CurrentDestination = Student.Destinations[Student.Phase];
				Student.Pathfinding.target = Student.CurrentDestination;
			}
			Student.MoveTowardsTarget(Student.CurrentDestination.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, Student.CurrentDestination.rotation, 10f * Time.deltaTime);
			Student.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
			Student.CharacterAnimation.CrossFade(RemovalAnim);
			if (Phase == 1)
			{
				if (!(Student.CharacterAnimation[RemovalAnim].time >= 0.833333f))
				{
					return;
				}
				_ = Student.Follower != null;
				if (Student.StudentID == Student.StudentManager.RivalID && !Student.StudentManager.MissionMode && !GameGlobals.AlphabetMode && !GameGlobals.AlphabetMode)
				{
					if (GameGlobals.Eighties)
					{
						Student.StudentManager.UpdateExteriorEightiesStudents();
					}
					else if (DateGlobals.Week == 1)
					{
						Student.StudentManager.UpdateExteriorStudents();
					}
				}
				ShoeParent.parent = LeftHand;
				Phase++;
			}
			else if (Phase == 2)
			{
				if (Student.CharacterAnimation[RemovalAnim].time >= 1.833333f)
				{
					ShoeParent.parent = Locker;
					X = ShoeParent.localEulerAngles.x;
					Y = ShoeParent.localEulerAngles.y;
					Z = ShoeParent.localEulerAngles.z;
					Phase++;
				}
			}
			else if (Phase == 3)
			{
				X = Mathf.MoveTowards(X, 0f, Time.deltaTime * 360f);
				Y = Mathf.MoveTowards(Y, 186.878f, Time.deltaTime * 360f);
				Z = Mathf.MoveTowards(Z, 0f, Time.deltaTime * 360f);
				ShoeParent.localEulerAngles = new Vector3(X, Y, Z);
				ShoeParent.localPosition = Vector3.MoveTowards(ShoeParent.localPosition, new Vector3(0.272f, 0f, 0.552f), Time.deltaTime);
				if (ShoeParent.localPosition.y == 0f)
				{
					ShoeParent.localPosition = new Vector3(0.272f, 0f, 0.552f);
					ShoeParent.localEulerAngles = new Vector3(0f, 186.878f, 0f);
					Phase++;
				}
			}
			else if (Phase == 4)
			{
				if (Student.CharacterAnimation[RemovalAnim].time >= 3.5f)
				{
					RightCurrentShoe.parent = null;
					RightCurrentShoe.position = new Vector3(RightCurrentShoe.position.x, 0.05f, RightCurrentShoe.position.z);
					RightCurrentShoe.localEulerAngles = new Vector3(0f, RightCurrentShoe.localEulerAngles.y, 0f);
					Phase++;
				}
			}
			else if (Phase == 5)
			{
				if (Student.CharacterAnimation[RemovalAnim].time >= 4f)
				{
					LeftCurrentShoe.parent = null;
					LeftCurrentShoe.position = new Vector3(LeftCurrentShoe.position.x, 0.05f, LeftCurrentShoe.position.z);
					LeftCurrentShoe.localEulerAngles = new Vector3(0f, LeftCurrentShoe.localEulerAngles.y, 0f);
					Phase++;
				}
			}
			else if (Phase == 6)
			{
				if (Student.CharacterAnimation[RemovalAnim].time >= 5.5f)
				{
					LeftNewShoe.parent = LeftFoot;
					LeftNewShoe.localPosition = LeftShoePosition;
					LeftNewShoe.localEulerAngles = Vector3.zero;
					Phase++;
				}
			}
			else if (Phase == 7)
			{
				if (!(Student.CharacterAnimation[RemovalAnim].time >= 6.66666f))
				{
					return;
				}
				if (!Student.AoT)
				{
					if (!Male)
					{
						MyRenderer.materials[0].mainTexture = TargetShoes;
						MyRenderer.materials[1].mainTexture = TargetShoes;
					}
					else
					{
						MyRenderer.materials[Student.Cosmetic.UniformID].mainTexture = TargetShoes;
					}
				}
				RightNewShoe.parent = RightFoot;
				RightNewShoe.localPosition = RightShoePosition;
				RightNewShoe.localEulerAngles = Vector3.zero;
				RightNewShoe.gameObject.SetActive(value: false);
				LeftNewShoe.gameObject.SetActive(value: false);
				Phase++;
			}
			else if (Phase == 8)
			{
				if (Student.CharacterAnimation[RemovalAnim].time >= 7.666666f)
				{
					ShoeParent.transform.position = (RightCurrentShoe.position - LeftCurrentShoe.position) * 0.5f;
					RightCurrentShoe.parent = ShoeParent;
					LeftCurrentShoe.parent = ShoeParent;
					ShoeParent.parent = RightHand;
					Phase++;
				}
			}
			else if (Phase == 9)
			{
				if (Student.CharacterAnimation[RemovalAnim].time >= 8.5f)
				{
					ShoeParent.parent = Locker;
					ShoeParent.localPosition = new Vector3(0f, ((TargetShoes == IndoorShoes) ? (-0.14f) : (-0.29f)) + 0.3f * (float)Height, -0.01f);
					ShoeParent.localEulerAngles = new Vector3(0f, 180f, 0f);
					RightCurrentShoe.localPosition = new Vector3(0.041f, 0.04271515f, 0f);
					LeftCurrentShoe.localPosition = new Vector3(-0.041f, 0.04271515f, 0f);
					RightCurrentShoe.localEulerAngles = Vector3.zero;
					LeftCurrentShoe.localEulerAngles = Vector3.zero;
					Phase++;
				}
			}
			else
			{
				if (Phase != 10 || !(Student.CharacterAnimation[RemovalAnim].time >= Student.CharacterAnimation[RemovalAnim].length))
				{
					return;
				}
				Student.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
				Student.ChangingShoes = false;
				Student.Routine = true;
				base.enabled = false;
				_ = Student.Follower != null;
				if (!Student.Indoors)
				{
					if (Student.Persona == PersonaType.PhoneAddict || Student.Sleuthing)
					{
						Student.SmartPhone.SetActive(value: true);
						if (!Student.Sleuthing)
						{
							Student.WalkAnim = Student.PhoneAnims[1];
						}
					}
					Student.Indoors = true;
					Student.CanTalk = true;
					return;
				}
				if (Student.Destinations[Student.Phase + 1] != null)
				{
					Student.CurrentDestination = Student.Destinations[Student.Phase + 1];
					Student.Pathfinding.target = Student.Destinations[Student.Phase + 1];
				}
				else
				{
					Student.CurrentDestination = Student.StudentManager.Hangouts.List[0];
					Student.Pathfinding.target = Student.StudentManager.Hangouts.List[0];
				}
				Student.CanTalk = false;
				Student.Leaving = true;
				Student.Phase++;
				base.enabled = false;
				Phase++;
			}
		}
		else
		{
			PutOnShoes();
			Student.Routine = false;
		}
	}

	private void LateUpdate()
	{
		if (Phase < 7)
		{
			RightFoot.localScale = new Vector3(0.9f, 1f, 0.9f);
			LeftFoot.localScale = new Vector3(0.9f, 1f, 0.9f);
		}
	}

	public void PutOnShoes()
	{
		CloseLocker();
		if (ShoeParent == null)
		{
			Start();
		}
		ShoeParent.parent = LeftHand;
		ShoeParent.parent = Locker;
		ShoeParent.localPosition = new Vector3(0.272f, 0f, 0.552f);
		ShoeParent.localEulerAngles = new Vector3(0f, 186.878f, 0f);
		RightCurrentShoe.parent = null;
		RightCurrentShoe.position = new Vector3(RightCurrentShoe.position.x, 0.05f, RightCurrentShoe.position.z);
		RightCurrentShoe.localEulerAngles = new Vector3(0f, RightCurrentShoe.localEulerAngles.y, 0f);
		LeftCurrentShoe.parent = null;
		LeftCurrentShoe.position = new Vector3(LeftCurrentShoe.position.x, 0.05f, LeftCurrentShoe.position.z);
		LeftCurrentShoe.localEulerAngles = new Vector3(0f, LeftCurrentShoe.localEulerAngles.y, 0f);
		LeftNewShoe.parent = LeftFoot;
		LeftNewShoe.localPosition = LeftShoePosition;
		LeftNewShoe.localEulerAngles = Vector3.zero;
		if (!Student.AoT && TargetShoes != null)
		{
			if (!Male)
			{
				MyRenderer.materials[0].mainTexture = TargetShoes;
				MyRenderer.materials[1].mainTexture = TargetShoes;
			}
			else
			{
				MyRenderer.materials[Student.Cosmetic.UniformID].mainTexture = TargetShoes;
			}
		}
		RightNewShoe.parent = RightFoot;
		RightNewShoe.localPosition = RightShoePosition;
		RightNewShoe.localEulerAngles = Vector3.zero;
		RightNewShoe.gameObject.SetActive(value: false);
		LeftNewShoe.gameObject.SetActive(value: false);
		ShoeParent.transform.position = (RightCurrentShoe.position - LeftCurrentShoe.position) * 0.5f;
		RightCurrentShoe.parent = ShoeParent;
		LeftCurrentShoe.parent = ShoeParent;
		ShoeParent.parent = RightHand;
		ShoeParent.parent = Locker;
		ShoeParent.localPosition = new Vector3(0f, ((TargetShoes == IndoorShoes) ? (-0.14f) : (-0.29f)) + 0.3f * (float)Height, -0.01f);
		ShoeParent.localEulerAngles = new Vector3(0f, 180f, 0f);
		RightCurrentShoe.localPosition = new Vector3(0.041f, 0.04271515f, 0f);
		LeftCurrentShoe.localPosition = new Vector3(-0.041f, 0.04271515f, 0f);
		RightCurrentShoe.localEulerAngles = Vector3.zero;
		LeftCurrentShoe.localEulerAngles = Vector3.zero;
		Student.Indoors = true;
		Student.CanTalk = true;
		base.enabled = false;
		Student.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		Student.StopPairing();
		if (Student.StudentID == Student.StudentManager.RivalID && !Student.StudentManager.MissionMode && !GameGlobals.AlphabetMode)
		{
			Debug.Log("A rival character just put her shoes on.");
			if (GameGlobals.Eighties)
			{
				Student.StudentManager.UpdateExteriorEightiesStudents();
			}
			else if (DateGlobals.Week == 1)
			{
				Student.StudentManager.UpdateExteriorStudents();
			}
		}
	}

	public void CloseLocker()
	{
	}

	public void UpdateShoes()
	{
		Student.Indoors = true;
		if (!Student.AoT)
		{
			if (!Male)
			{
				MyRenderer.materials[0].mainTexture = IndoorShoes;
				MyRenderer.materials[1].mainTexture = IndoorShoes;
			}
			else
			{
				MyRenderer.materials[Student.Cosmetic.UniformID].mainTexture = IndoorShoes;
			}
		}
	}

	public void LeavingSchool()
	{
		if (Locker == null)
		{
			Start();
		}
		Student.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
		OutdoorShoes = Student.Cosmetic.CasualTexture;
		IndoorShoes = Student.Cosmetic.UniformTexture;
		Socks = Student.Cosmetic.SocksTexture;
		RemovalAnim = RemoveSchoolAnim;
		if (!Student.AoT)
		{
			if (!Male)
			{
				MyRenderer.materials[0].mainTexture = Socks;
				MyRenderer.materials[1].mainTexture = Socks;
			}
			else
			{
				MyRenderer.materials[Student.Cosmetic.UniformID].mainTexture = Socks;
			}
		}
		Student.CharacterAnimation.CrossFade(RemovalAnim);
		RightNewShoe.gameObject.SetActive(value: true);
		LeftNewShoe.gameObject.SetActive(value: true);
		RightCurrentShoe = RightSchoolShoe;
		LeftCurrentShoe = LeftSchoolShoe;
		RightNewShoe = RightCasualShoe;
		LeftNewShoe = LeftCasualShoe;
		TargetShoes = OutdoorShoes;
		Phase = 1;
		RightFoot.localScale = new Vector3(0.9f, 1f, 0.9f);
		LeftFoot.localScale = new Vector3(0.9f, 1f, 0.9f);
		RightCurrentShoe.localScale = new Vector3(1.111113f, 1f, 1.111113f);
		LeftCurrentShoe.localScale = new Vector3(1.111113f, 1f, 1.111113f);
	}

	private void GetHeight(int StudentID)
	{
		Height = 5;
		RemoveCasualAnim += "5_00";
		RemoveSchoolAnim += "5_01";
	}
}
