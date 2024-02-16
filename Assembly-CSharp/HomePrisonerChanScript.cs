using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePrisonerChanScript : MonoBehaviour
{
	public HomeYandereDetectorScript YandereDetector;

	public HomeCameraScript HomeCamera;

	public CosmeticScript Cosmetic;

	public JsonScript JSON;

	public Vector3 RightEyeRotOrigin;

	public Vector3 LeftEyeRotOrigin;

	public Vector3 PermanentAngleR;

	public Vector3 PermanentAngleL;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public Vector3 Twitch;

	public Quaternion LastRotation;

	public Transform HomeYandere;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform TwintailR;

	public Transform TwintailL;

	public Transform RightEye;

	public Transform LeftEye;

	public Transform Skirt;

	public Transform Neck;

	public GameObject RightMindbrokenEye;

	public GameObject LeftMindbrokenEye;

	public GameObject AnkleRopes;

	public GameObject Blindfold;

	public GameObject Character;

	public GameObject Tripod;

	public GameObject Flies;

	public float HairRotation;

	public float TwitchTimer;

	public float NextTwitch;

	public float BreastSize;

	public float EyeShrink;

	public float Sanity;

	public float HairRot1;

	public float HairRot2;

	public float HairRot3;

	public float HairRot4;

	public float HairRot5;

	public bool LookAhead;

	public bool Tortured;

	public bool Eighties;

	public bool Male;

	public int PrisonerID;

	public int StudentID;

	public int Health = 100;

	public string IdleAnim;

	public void Start()
	{
		if (PrisonerID == 1)
		{
			StudentID = StudentGlobals.Prisoner1;
		}
		if (PrisonerID == 2)
		{
			StudentID = StudentGlobals.Prisoner2;
		}
		if (PrisonerID == 3)
		{
			StudentID = StudentGlobals.Prisoner3;
		}
		if (PrisonerID == 4)
		{
			StudentID = StudentGlobals.Prisoner4;
		}
		if (PrisonerID == 5)
		{
			StudentID = StudentGlobals.Prisoner5;
		}
		if (PrisonerID == 6)
		{
			StudentID = StudentGlobals.Prisoner6;
		}
		if (PrisonerID == 7)
		{
			StudentID = StudentGlobals.Prisoner7;
		}
		if (PrisonerID == 8)
		{
			StudentID = StudentGlobals.Prisoner8;
		}
		if (PrisonerID == 9)
		{
			StudentID = StudentGlobals.Prisoner9;
		}
		if (PrisonerID == 10)
		{
			StudentID = StudentGlobals.Prisoner10;
		}
		if (StudentID > 0)
		{
			if (StudentGlobals.GetStudentSanity(StudentID) == 100)
			{
				AnkleRopes.SetActive(value: false);
			}
			PermanentAngleR = TwintailR.eulerAngles;
			PermanentAngleL = TwintailL.eulerAngles;
			StudentGlobals.GetStudentArrested(StudentID);
			StudentGlobals.GetStudentDead(StudentID);
			if (!StudentGlobals.GetStudentArrested(StudentID) && !StudentGlobals.GetStudentDead(StudentID))
			{
				Cosmetic.StudentID = StudentID;
				Cosmetic.enabled = true;
				BreastSize = JSON.Students[StudentID].BreastSize;
				RightEyeRotOrigin = RightEye.localEulerAngles;
				LeftEyeRotOrigin = LeftEye.localEulerAngles;
				RightEyeOrigin = RightEye.localPosition;
				LeftEyeOrigin = LeftEye.localPosition;
				UpdateSanity();
				TwintailR.transform.localEulerAngles = new Vector3(0f, 180f, -90f);
				TwintailL.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
				Blindfold.SetActive(value: false);
				Tripod.SetActive(value: false);
			}
			else
			{
				base.gameObject.SetActive(value: false);
			}
			if (IdleAnim == "")
			{
				IdleAnim = "f02_kidnapIdle_01";
				Debug.Log("I'm Prisoner #" + PrisonerID + " and for some reason, my IdleAnim was blank.");
			}
			Character.GetComponent<Animation>().CrossFade(IdleAnim);
			Health = StudentGlobals.GetStudentHealth(StudentID);
			if (Health == 0)
			{
				if (PrisonerID == 1)
				{
					Character.GetComponent<Animation>().CrossFade("f02_kidnapIdle_02");
					Character.GetComponent<Animation>()["f02_kidnapIdle_02"].speed = 0f;
				}
				else
				{
					Character.GetComponent<Animation>()[IdleAnim].speed = 0f;
				}
				Object.Instantiate(Flies, base.transform.position, Quaternion.identity);
				if (GameGlobals.AlternateTimeline && StudentGlobals.GetStudentHealth(StudentID) <= 0)
				{
					SceneManager.LoadScene("FunGameOverScene");
				}
			}
			else if (PrisonerID == 1 && Sanity == 0f)
			{
				Character.GetComponent<Animation>().CrossFade("f02_kidnapIdle_02");
			}
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
		if (Cosmetic.Student.Ragdoll != null)
		{
			int num = 0;
			for (num = 0; num < Cosmetic.Student.Ragdoll.AllRigidbodies.Length; num++)
			{
				Cosmetic.Student.Ragdoll.AllRigidbodies[num].isKinematic = true;
				Cosmetic.Student.Ragdoll.AllColliders[num].enabled = false;
			}
			Cosmetic.Student.DisableFemaleProps();
			Cosmetic.Student.SetSplashes(Bool: false);
			Cosmetic.Student.DisableProps();
			Blindfold.SetActive(value: true);
		}
		if (GameGlobals.Eighties)
		{
			if (Eighties)
			{
				Blindfold.SetActive(value: true);
			}
			else
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}

	private void LateUpdate()
	{
		Skirt.transform.localPosition = new Vector3(0f, -0.135f, 0.01f);
		Skirt.transform.localScale = new Vector3(Skirt.transform.localScale.x, 1.2f, Skirt.transform.localScale.z);
		if (Health > 0)
		{
			if (!Tortured && PrisonerID == 1)
			{
				if (Sanity > 0f)
				{
					if (LookAhead)
					{
						Neck.localEulerAngles = new Vector3(Neck.localEulerAngles.x - 45f, Neck.localEulerAngles.y, Neck.localEulerAngles.z);
					}
					else if (YandereDetector.YandereDetected && Vector3.Distance(base.transform.position, HomeYandere.position) < 2f)
					{
						Quaternion b;
						if (HomeCamera.Target == HomeCamera.Targets[10])
						{
							b = Quaternion.LookRotation(HomeCamera.transform.position + Vector3.down * (1.5f * ((100f - Sanity) / 100f)) - Neck.position);
							HairRotation = Mathf.Lerp(HairRotation, HairRot1, Time.deltaTime * 2f);
						}
						else
						{
							b = Quaternion.LookRotation(HomeYandere.position + Vector3.up * 1.5f - Neck.position);
							HairRotation = Mathf.Lerp(HairRotation, HairRot2, Time.deltaTime * 2f);
						}
						Neck.rotation = Quaternion.Slerp(LastRotation, b, Time.deltaTime * 2f);
						TwintailR.transform.localEulerAngles = new Vector3(HairRotation, 180f, -90f);
						TwintailL.transform.localEulerAngles = new Vector3(0f - HairRotation, 0f, -90f);
					}
					else
					{
						if (HomeCamera.Target == HomeCamera.Targets[10])
						{
							Quaternion quaternion = Quaternion.LookRotation(HomeCamera.transform.position + Vector3.down * (1.5f * ((100f - Sanity) / 100f)) - Neck.position);
							HairRotation = Mathf.Lerp(HairRotation, HairRot3, Time.deltaTime * 2f);
						}
						else
						{
							Quaternion quaternion = Quaternion.LookRotation(base.transform.position + base.transform.forward - Neck.position);
							Neck.rotation = Quaternion.Slerp(LastRotation, quaternion, Time.deltaTime * 2f);
						}
						HairRotation = Mathf.Lerp(HairRotation, HairRot4, Time.deltaTime * 2f);
						TwintailR.transform.localEulerAngles = new Vector3(HairRotation, 180f, -90f);
						TwintailL.transform.localEulerAngles = new Vector3(0f - HairRotation, 0f, -90f);
					}
				}
				else
				{
					Neck.localEulerAngles = new Vector3(Neck.localEulerAngles.x - 45f, Neck.localEulerAngles.y, Neck.localEulerAngles.z);
				}
			}
			LastRotation = Neck.rotation;
			if (!Tortured && Sanity < 100f && Sanity > 0f)
			{
				TwitchTimer += Time.deltaTime;
				if (TwitchTimer > NextTwitch)
				{
					Twitch = new Vector3((1f - Sanity / 100f) * Random.Range(-10f, 10f), (1f - Sanity / 100f) * Random.Range(-10f, 10f), (1f - Sanity / 100f) * Random.Range(-10f, 10f));
					NextTwitch = Random.Range(0f, 1f);
					TwitchTimer = 0f;
				}
				Twitch = Vector3.Lerp(Twitch, Vector3.zero, Time.deltaTime * 10f);
				Neck.localEulerAngles += Twitch;
			}
		}
		if (Tortured)
		{
			HairRotation = Mathf.Lerp(HairRotation, HairRot5, Time.deltaTime * 2f);
			TwintailR.transform.localEulerAngles = new Vector3(HairRotation, 180f, -90f);
			TwintailL.transform.localEulerAngles = new Vector3(0f - HairRotation, 0f, -90f);
		}
	}

	public void UpdateSanity()
	{
		Sanity = StudentGlobals.GetStudentSanity(StudentID);
		bool active = Sanity == 0f;
		RightMindbrokenEye.SetActive(active);
		LeftMindbrokenEye.SetActive(active);
	}
}
