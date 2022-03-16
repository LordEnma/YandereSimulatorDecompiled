using System;
using UnityEngine;

// Token: 0x02000425 RID: 1061
public class ShoeRemovalScript : MonoBehaviour
{
	// Token: 0x06001C9E RID: 7326 RVA: 0x0014F5A0 File Offset: 0x0014D7A0
	public void Start()
	{
		if (this.Locker == null)
		{
			this.GetHeight(this.Student.StudentID);
			this.Locker = this.Student.StudentManager.Lockers.List[this.Student.StudentID];
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.NewPairOfShoes, base.transform.position, Quaternion.identity);
			gameObject.transform.parent = this.Locker;
			gameObject.transform.localEulerAngles = new Vector3(0f, -180f, 0f);
			gameObject.transform.localPosition = new Vector3(0f, -0.29f + 0.3f * (float)this.Height, this.Male ? 0.04f : 0.05f);
			this.LeftSchoolShoe = gameObject.transform.GetChild(0);
			this.RightSchoolShoe = gameObject.transform.GetChild(1);
			this.RemovalAnim = this.RemoveCasualAnim;
			this.RightCurrentShoe = this.RightCasualShoe;
			this.LeftCurrentShoe = this.LeftCasualShoe;
			this.RightNewShoe = this.RightSchoolShoe;
			this.LeftNewShoe = this.LeftSchoolShoe;
			this.ShoeParent = gameObject.transform;
			this.TargetShoes = this.IndoorShoes;
			this.RightShoePosition = this.RightCurrentShoe.localPosition;
			this.LeftShoePosition = this.LeftCurrentShoe.localPosition;
			this.RightCurrentShoe.localScale = new Vector3(1.111113f, 1f, 1.111113f);
			this.LeftCurrentShoe.localScale = new Vector3(1.111113f, 1f, 1.111113f);
			this.OutdoorShoes = this.Student.Cosmetic.CasualTexture;
			this.IndoorShoes = this.Student.Cosmetic.UniformTexture;
			this.Socks = this.Student.Cosmetic.SocksTexture;
			this.TargetShoes = this.IndoorShoes;
		}
	}

	// Token: 0x06001C9F RID: 7327 RVA: 0x0014F7A4 File Offset: 0x0014D9A4
	public void StartChangingShoes()
	{
		if (!this.Student.AoT)
		{
			this.RightCasualShoe.gameObject.SetActive(true);
			this.LeftCasualShoe.gameObject.SetActive(true);
			if (!this.Male)
			{
				this.MyRenderer.materials[0].mainTexture = this.Socks;
				this.MyRenderer.materials[1].mainTexture = this.Socks;
			}
			else
			{
				this.MyRenderer.materials[this.Student.Cosmetic.UniformID].mainTexture = this.Socks;
			}
			this.Student.Follower != null;
		}
	}

	// Token: 0x06001CA0 RID: 7328 RVA: 0x0014F858 File Offset: 0x0014DA58
	private void Update()
	{
		if (!this.Student.DiscCheck && !this.Student.Dying && !this.Student.InEvent && !this.Student.Alarmed && !this.Student.Splashed && !this.Student.TurnOffRadio)
		{
			if (this.Student.Destinations[this.Student.Phase] == null)
			{
				this.Student.Phase++;
			}
			if (this.Student.CurrentDestination == null)
			{
				this.Student.CurrentDestination = this.Student.Destinations[this.Student.Phase];
				this.Student.Pathfinding.target = this.Student.CurrentDestination;
			}
			this.Student.MoveTowardsTarget(this.Student.CurrentDestination.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Student.CurrentDestination.rotation, 10f * Time.deltaTime);
			this.Student.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
			this.Student.CharacterAnimation.CrossFade(this.RemovalAnim);
			if (this.Phase == 1)
			{
				if (this.Student.CharacterAnimation[this.RemovalAnim].time >= 0.833333f)
				{
					this.Student.Follower != null;
					if (this.Student.StudentID == this.Student.StudentManager.RivalID && !this.Student.StudentManager.MissionMode && !GameGlobals.AlphabetMode && !GameGlobals.Eighties && DateGlobals.Week == 1)
					{
						this.Student.StudentManager.UpdateExteriorStudents();
					}
					this.ShoeParent.parent = this.LeftHand;
					this.Phase++;
					return;
				}
			}
			else if (this.Phase == 2)
			{
				if (this.Student.CharacterAnimation[this.RemovalAnim].time >= 1.833333f)
				{
					this.ShoeParent.parent = this.Locker;
					this.X = this.ShoeParent.localEulerAngles.x;
					this.Y = this.ShoeParent.localEulerAngles.y;
					this.Z = this.ShoeParent.localEulerAngles.z;
					this.Phase++;
					return;
				}
			}
			else if (this.Phase == 3)
			{
				this.X = Mathf.MoveTowards(this.X, 0f, Time.deltaTime * 360f);
				this.Y = Mathf.MoveTowards(this.Y, 186.878f, Time.deltaTime * 360f);
				this.Z = Mathf.MoveTowards(this.Z, 0f, Time.deltaTime * 360f);
				this.ShoeParent.localEulerAngles = new Vector3(this.X, this.Y, this.Z);
				this.ShoeParent.localPosition = Vector3.MoveTowards(this.ShoeParent.localPosition, new Vector3(0.272f, 0f, 0.552f), Time.deltaTime);
				if (this.ShoeParent.localPosition.y == 0f)
				{
					this.ShoeParent.localPosition = new Vector3(0.272f, 0f, 0.552f);
					this.ShoeParent.localEulerAngles = new Vector3(0f, 186.878f, 0f);
					this.Phase++;
					return;
				}
			}
			else if (this.Phase == 4)
			{
				if (this.Student.CharacterAnimation[this.RemovalAnim].time >= 3.5f)
				{
					this.RightCurrentShoe.parent = null;
					this.RightCurrentShoe.position = new Vector3(this.RightCurrentShoe.position.x, 0.05f, this.RightCurrentShoe.position.z);
					this.RightCurrentShoe.localEulerAngles = new Vector3(0f, this.RightCurrentShoe.localEulerAngles.y, 0f);
					this.Phase++;
					return;
				}
			}
			else if (this.Phase == 5)
			{
				if (this.Student.CharacterAnimation[this.RemovalAnim].time >= 4f)
				{
					this.LeftCurrentShoe.parent = null;
					this.LeftCurrentShoe.position = new Vector3(this.LeftCurrentShoe.position.x, 0.05f, this.LeftCurrentShoe.position.z);
					this.LeftCurrentShoe.localEulerAngles = new Vector3(0f, this.LeftCurrentShoe.localEulerAngles.y, 0f);
					this.Phase++;
					return;
				}
			}
			else if (this.Phase == 6)
			{
				if (this.Student.CharacterAnimation[this.RemovalAnim].time >= 5.5f)
				{
					this.LeftNewShoe.parent = this.LeftFoot;
					this.LeftNewShoe.localPosition = this.LeftShoePosition;
					this.LeftNewShoe.localEulerAngles = Vector3.zero;
					this.Phase++;
					return;
				}
			}
			else if (this.Phase == 7)
			{
				if (this.Student.CharacterAnimation[this.RemovalAnim].time >= 6.66666f)
				{
					if (!this.Student.AoT)
					{
						if (!this.Male)
						{
							this.MyRenderer.materials[0].mainTexture = this.TargetShoes;
							this.MyRenderer.materials[1].mainTexture = this.TargetShoes;
						}
						else
						{
							this.MyRenderer.materials[this.Student.Cosmetic.UniformID].mainTexture = this.TargetShoes;
						}
					}
					this.RightNewShoe.parent = this.RightFoot;
					this.RightNewShoe.localPosition = this.RightShoePosition;
					this.RightNewShoe.localEulerAngles = Vector3.zero;
					this.RightNewShoe.gameObject.SetActive(false);
					this.LeftNewShoe.gameObject.SetActive(false);
					this.Phase++;
					return;
				}
			}
			else if (this.Phase == 8)
			{
				if (this.Student.CharacterAnimation[this.RemovalAnim].time >= 7.666666f)
				{
					this.ShoeParent.transform.position = (this.RightCurrentShoe.position - this.LeftCurrentShoe.position) * 0.5f;
					this.RightCurrentShoe.parent = this.ShoeParent;
					this.LeftCurrentShoe.parent = this.ShoeParent;
					this.ShoeParent.parent = this.RightHand;
					this.Phase++;
					return;
				}
			}
			else if (this.Phase == 9)
			{
				if (this.Student.CharacterAnimation[this.RemovalAnim].time >= 8.5f)
				{
					this.ShoeParent.parent = this.Locker;
					this.ShoeParent.localPosition = new Vector3(0f, ((this.TargetShoes == this.IndoorShoes) ? -0.14f : -0.29f) + 0.3f * (float)this.Height, -0.01f);
					this.ShoeParent.localEulerAngles = new Vector3(0f, 180f, 0f);
					this.RightCurrentShoe.localPosition = new Vector3(0.041f, 0.04271515f, 0f);
					this.LeftCurrentShoe.localPosition = new Vector3(-0.041f, 0.04271515f, 0f);
					this.RightCurrentShoe.localEulerAngles = Vector3.zero;
					this.LeftCurrentShoe.localEulerAngles = Vector3.zero;
					this.Phase++;
					return;
				}
			}
			else if (this.Phase == 10 && this.Student.CharacterAnimation[this.RemovalAnim].time >= this.Student.CharacterAnimation[this.RemovalAnim].length)
			{
				this.Student.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
				this.Student.ChangingShoes = false;
				this.Student.Routine = true;
				base.enabled = false;
				this.Student.Follower != null;
				if (!this.Student.Indoors)
				{
					if (this.Student.Persona == PersonaType.PhoneAddict || this.Student.Sleuthing)
					{
						this.Student.SmartPhone.SetActive(true);
						if (!this.Student.Sleuthing)
						{
							this.Student.WalkAnim = this.Student.PhoneAnims[1];
						}
					}
					this.Student.Indoors = true;
					this.Student.CanTalk = true;
					return;
				}
				if (this.Student.Destinations[this.Student.Phase + 1] != null)
				{
					this.Student.CurrentDestination = this.Student.Destinations[this.Student.Phase + 1];
					this.Student.Pathfinding.target = this.Student.Destinations[this.Student.Phase + 1];
				}
				else
				{
					this.Student.CurrentDestination = this.Student.StudentManager.Hangouts.List[0];
					this.Student.Pathfinding.target = this.Student.StudentManager.Hangouts.List[0];
				}
				this.Student.CanTalk = false;
				this.Student.Leaving = true;
				this.Student.Phase++;
				base.enabled = false;
				this.Phase++;
				return;
			}
		}
		else
		{
			this.PutOnShoes();
			this.Student.Routine = false;
		}
	}

	// Token: 0x06001CA1 RID: 7329 RVA: 0x001502CC File Offset: 0x0014E4CC
	private void LateUpdate()
	{
		if (this.Phase < 7)
		{
			this.RightFoot.localScale = new Vector3(0.9f, 1f, 0.9f);
			this.LeftFoot.localScale = new Vector3(0.9f, 1f, 0.9f);
		}
	}

	// Token: 0x06001CA2 RID: 7330 RVA: 0x00150320 File Offset: 0x0014E520
	public void PutOnShoes()
	{
		this.CloseLocker();
		this.ShoeParent.parent = this.LeftHand;
		this.ShoeParent.parent = this.Locker;
		this.ShoeParent.localPosition = new Vector3(0.272f, 0f, 0.552f);
		this.ShoeParent.localEulerAngles = new Vector3(0f, 186.878f, 0f);
		this.RightCurrentShoe.parent = null;
		this.RightCurrentShoe.position = new Vector3(this.RightCurrentShoe.position.x, 0.05f, this.RightCurrentShoe.position.z);
		this.RightCurrentShoe.localEulerAngles = new Vector3(0f, this.RightCurrentShoe.localEulerAngles.y, 0f);
		this.LeftCurrentShoe.parent = null;
		this.LeftCurrentShoe.position = new Vector3(this.LeftCurrentShoe.position.x, 0.05f, this.LeftCurrentShoe.position.z);
		this.LeftCurrentShoe.localEulerAngles = new Vector3(0f, this.LeftCurrentShoe.localEulerAngles.y, 0f);
		this.LeftNewShoe.parent = this.LeftFoot;
		this.LeftNewShoe.localPosition = this.LeftShoePosition;
		this.LeftNewShoe.localEulerAngles = Vector3.zero;
		if (!this.Student.AoT)
		{
			if (!this.Male)
			{
				this.MyRenderer.materials[0].mainTexture = this.TargetShoes;
				this.MyRenderer.materials[1].mainTexture = this.TargetShoes;
			}
			else
			{
				this.MyRenderer.materials[this.Student.Cosmetic.UniformID].mainTexture = this.TargetShoes;
			}
		}
		this.RightNewShoe.parent = this.RightFoot;
		this.RightNewShoe.localPosition = this.RightShoePosition;
		this.RightNewShoe.localEulerAngles = Vector3.zero;
		this.RightNewShoe.gameObject.SetActive(false);
		this.LeftNewShoe.gameObject.SetActive(false);
		this.ShoeParent.transform.position = (this.RightCurrentShoe.position - this.LeftCurrentShoe.position) * 0.5f;
		this.RightCurrentShoe.parent = this.ShoeParent;
		this.LeftCurrentShoe.parent = this.ShoeParent;
		this.ShoeParent.parent = this.RightHand;
		this.ShoeParent.parent = this.Locker;
		this.ShoeParent.localPosition = new Vector3(0f, ((this.TargetShoes == this.IndoorShoes) ? -0.14f : -0.29f) + 0.3f * (float)this.Height, -0.01f);
		this.ShoeParent.localEulerAngles = new Vector3(0f, 180f, 0f);
		this.RightCurrentShoe.localPosition = new Vector3(0.041f, 0.04271515f, 0f);
		this.LeftCurrentShoe.localPosition = new Vector3(-0.041f, 0.04271515f, 0f);
		this.RightCurrentShoe.localEulerAngles = Vector3.zero;
		this.LeftCurrentShoe.localEulerAngles = Vector3.zero;
		this.Student.Indoors = true;
		this.Student.CanTalk = true;
		base.enabled = false;
		this.Student.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		this.Student.StopPairing();
		if (this.Student.StudentID == this.Student.StudentManager.RivalID && !this.Student.StudentManager.MissionMode && !GameGlobals.AlphabetMode && !GameGlobals.Eighties && DateGlobals.Week == 1)
		{
			this.Student.StudentManager.UpdateExteriorStudents();
		}
	}

	// Token: 0x06001CA3 RID: 7331 RVA: 0x0015072A File Offset: 0x0014E92A
	public void CloseLocker()
	{
	}

	// Token: 0x06001CA4 RID: 7332 RVA: 0x0015072C File Offset: 0x0014E92C
	private void UpdateShoes()
	{
		this.Student.Indoors = true;
		if (!this.Student.AoT)
		{
			if (!this.Male)
			{
				this.MyRenderer.materials[0].mainTexture = this.IndoorShoes;
				this.MyRenderer.materials[1].mainTexture = this.IndoorShoes;
				return;
			}
			this.MyRenderer.materials[this.Student.Cosmetic.UniformID].mainTexture = this.IndoorShoes;
		}
	}

	// Token: 0x06001CA5 RID: 7333 RVA: 0x001507B4 File Offset: 0x0014E9B4
	public void LeavingSchool()
	{
		if (this.Locker == null)
		{
			this.Start();
		}
		this.Student.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
		this.OutdoorShoes = this.Student.Cosmetic.CasualTexture;
		this.IndoorShoes = this.Student.Cosmetic.UniformTexture;
		this.Socks = this.Student.Cosmetic.SocksTexture;
		this.RemovalAnim = this.RemoveSchoolAnim;
		if (!this.Student.AoT)
		{
			if (!this.Male)
			{
				this.MyRenderer.materials[0].mainTexture = this.Socks;
				this.MyRenderer.materials[1].mainTexture = this.Socks;
			}
			else
			{
				this.MyRenderer.materials[this.Student.Cosmetic.UniformID].mainTexture = this.Socks;
			}
		}
		this.Student.CharacterAnimation.CrossFade(this.RemovalAnim);
		this.RightNewShoe.gameObject.SetActive(true);
		this.LeftNewShoe.gameObject.SetActive(true);
		this.RightCurrentShoe = this.RightSchoolShoe;
		this.LeftCurrentShoe = this.LeftSchoolShoe;
		this.RightNewShoe = this.RightCasualShoe;
		this.LeftNewShoe = this.LeftCasualShoe;
		this.TargetShoes = this.OutdoorShoes;
		this.Phase = 1;
		this.RightFoot.localScale = new Vector3(0.9f, 1f, 0.9f);
		this.LeftFoot.localScale = new Vector3(0.9f, 1f, 0.9f);
		this.RightCurrentShoe.localScale = new Vector3(1.111113f, 1f, 1.111113f);
		this.LeftCurrentShoe.localScale = new Vector3(1.111113f, 1f, 1.111113f);
	}

	// Token: 0x06001CA6 RID: 7334 RVA: 0x00150999 File Offset: 0x0014EB99
	private void GetHeight(int StudentID)
	{
		this.Height = 5;
		this.RemoveCasualAnim += "5_00";
		this.RemoveSchoolAnim += "5_01";
	}

	// Token: 0x0400330C RID: 13068
	public StudentScript Student;

	// Token: 0x0400330D RID: 13069
	public Vector3 RightShoePosition;

	// Token: 0x0400330E RID: 13070
	public Vector3 LeftShoePosition;

	// Token: 0x0400330F RID: 13071
	public Transform RightCurrentShoe;

	// Token: 0x04003310 RID: 13072
	public Transform LeftCurrentShoe;

	// Token: 0x04003311 RID: 13073
	public Transform RightCasualShoe;

	// Token: 0x04003312 RID: 13074
	public Transform LeftCasualShoe;

	// Token: 0x04003313 RID: 13075
	public Transform RightSchoolShoe;

	// Token: 0x04003314 RID: 13076
	public Transform LeftSchoolShoe;

	// Token: 0x04003315 RID: 13077
	public Transform RightNewShoe;

	// Token: 0x04003316 RID: 13078
	public Transform LeftNewShoe;

	// Token: 0x04003317 RID: 13079
	public Transform RightFoot;

	// Token: 0x04003318 RID: 13080
	public Transform LeftFoot;

	// Token: 0x04003319 RID: 13081
	public Transform RightHand;

	// Token: 0x0400331A RID: 13082
	public Transform LeftHand;

	// Token: 0x0400331B RID: 13083
	public Transform ShoeParent;

	// Token: 0x0400331C RID: 13084
	public Transform Locker;

	// Token: 0x0400331D RID: 13085
	public GameObject NewPairOfShoes;

	// Token: 0x0400331E RID: 13086
	public GameObject Character;

	// Token: 0x0400331F RID: 13087
	public string[] LockerAnims;

	// Token: 0x04003320 RID: 13088
	public Texture OutdoorShoes;

	// Token: 0x04003321 RID: 13089
	public Texture IndoorShoes;

	// Token: 0x04003322 RID: 13090
	public Texture TargetShoes;

	// Token: 0x04003323 RID: 13091
	public Texture Socks;

	// Token: 0x04003324 RID: 13092
	public Renderer MyRenderer;

	// Token: 0x04003325 RID: 13093
	public bool RemovingCasual = true;

	// Token: 0x04003326 RID: 13094
	public bool Male;

	// Token: 0x04003327 RID: 13095
	public int Height;

	// Token: 0x04003328 RID: 13096
	public int Phase = 1;

	// Token: 0x04003329 RID: 13097
	public float X;

	// Token: 0x0400332A RID: 13098
	public float Y;

	// Token: 0x0400332B RID: 13099
	public float Z;

	// Token: 0x0400332C RID: 13100
	public string RemoveCasualAnim = string.Empty;

	// Token: 0x0400332D RID: 13101
	public string RemoveSchoolAnim = string.Empty;

	// Token: 0x0400332E RID: 13102
	public string RemovalAnim = string.Empty;
}
