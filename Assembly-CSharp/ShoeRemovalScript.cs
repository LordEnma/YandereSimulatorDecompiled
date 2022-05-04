using System;
using UnityEngine;

// Token: 0x0200042A RID: 1066
public class ShoeRemovalScript : MonoBehaviour
{
	// Token: 0x06001CBA RID: 7354 RVA: 0x00150FDC File Offset: 0x0014F1DC
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

	// Token: 0x06001CBB RID: 7355 RVA: 0x001511E0 File Offset: 0x0014F3E0
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

	// Token: 0x06001CBC RID: 7356 RVA: 0x00151294 File Offset: 0x0014F494
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
						Debug.Log("Apparently, GameGlobals.Eighties is: " + GameGlobals.Eighties.ToString());
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

	// Token: 0x06001CBD RID: 7357 RVA: 0x00151D24 File Offset: 0x0014FF24
	private void LateUpdate()
	{
		if (this.Phase < 7)
		{
			this.RightFoot.localScale = new Vector3(0.9f, 1f, 0.9f);
			this.LeftFoot.localScale = new Vector3(0.9f, 1f, 0.9f);
		}
	}

	// Token: 0x06001CBE RID: 7358 RVA: 0x00151D78 File Offset: 0x0014FF78
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
			Debug.Log("Apparently, GameGlobals.Eighties is: " + GameGlobals.Eighties.ToString());
			this.Student.StudentManager.UpdateExteriorStudents();
		}
	}

	// Token: 0x06001CBF RID: 7359 RVA: 0x0015219E File Offset: 0x0015039E
	public void CloseLocker()
	{
	}

	// Token: 0x06001CC0 RID: 7360 RVA: 0x001521A0 File Offset: 0x001503A0
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

	// Token: 0x06001CC1 RID: 7361 RVA: 0x00152228 File Offset: 0x00150428
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

	// Token: 0x06001CC2 RID: 7362 RVA: 0x0015240D File Offset: 0x0015060D
	private void GetHeight(int StudentID)
	{
		this.Height = 5;
		this.RemoveCasualAnim += "5_00";
		this.RemoveSchoolAnim += "5_01";
	}

	// Token: 0x04003345 RID: 13125
	public StudentScript Student;

	// Token: 0x04003346 RID: 13126
	public Vector3 RightShoePosition;

	// Token: 0x04003347 RID: 13127
	public Vector3 LeftShoePosition;

	// Token: 0x04003348 RID: 13128
	public Transform RightCurrentShoe;

	// Token: 0x04003349 RID: 13129
	public Transform LeftCurrentShoe;

	// Token: 0x0400334A RID: 13130
	public Transform RightCasualShoe;

	// Token: 0x0400334B RID: 13131
	public Transform LeftCasualShoe;

	// Token: 0x0400334C RID: 13132
	public Transform RightSchoolShoe;

	// Token: 0x0400334D RID: 13133
	public Transform LeftSchoolShoe;

	// Token: 0x0400334E RID: 13134
	public Transform RightNewShoe;

	// Token: 0x0400334F RID: 13135
	public Transform LeftNewShoe;

	// Token: 0x04003350 RID: 13136
	public Transform RightFoot;

	// Token: 0x04003351 RID: 13137
	public Transform LeftFoot;

	// Token: 0x04003352 RID: 13138
	public Transform RightHand;

	// Token: 0x04003353 RID: 13139
	public Transform LeftHand;

	// Token: 0x04003354 RID: 13140
	public Transform ShoeParent;

	// Token: 0x04003355 RID: 13141
	public Transform Locker;

	// Token: 0x04003356 RID: 13142
	public GameObject NewPairOfShoes;

	// Token: 0x04003357 RID: 13143
	public GameObject Character;

	// Token: 0x04003358 RID: 13144
	public string[] LockerAnims;

	// Token: 0x04003359 RID: 13145
	public Texture OutdoorShoes;

	// Token: 0x0400335A RID: 13146
	public Texture IndoorShoes;

	// Token: 0x0400335B RID: 13147
	public Texture TargetShoes;

	// Token: 0x0400335C RID: 13148
	public Texture Socks;

	// Token: 0x0400335D RID: 13149
	public Renderer MyRenderer;

	// Token: 0x0400335E RID: 13150
	public bool RemovingCasual = true;

	// Token: 0x0400335F RID: 13151
	public bool Male;

	// Token: 0x04003360 RID: 13152
	public int Height;

	// Token: 0x04003361 RID: 13153
	public int Phase = 1;

	// Token: 0x04003362 RID: 13154
	public float X;

	// Token: 0x04003363 RID: 13155
	public float Y;

	// Token: 0x04003364 RID: 13156
	public float Z;

	// Token: 0x04003365 RID: 13157
	public string RemoveCasualAnim = string.Empty;

	// Token: 0x04003366 RID: 13158
	public string RemoveSchoolAnim = string.Empty;

	// Token: 0x04003367 RID: 13159
	public string RemovalAnim = string.Empty;
}
