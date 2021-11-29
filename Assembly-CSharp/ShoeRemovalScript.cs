using System;
using UnityEngine;

// Token: 0x0200041E RID: 1054
public class ShoeRemovalScript : MonoBehaviour
{
	// Token: 0x06001C69 RID: 7273 RVA: 0x0014A5EC File Offset: 0x001487EC
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

	// Token: 0x06001C6A RID: 7274 RVA: 0x0014A7F0 File Offset: 0x001489F0
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
			if (this.Student.Follower != null)
			{
				this.Student.FollowTargetDestination.localPosition = new Vector3(1f, 0f, 0f);
			}
		}
	}

	// Token: 0x06001C6B RID: 7275 RVA: 0x0014A8C8 File Offset: 0x00148AC8
	private void Update()
	{
		if (!this.Student.DiscCheck && !this.Student.Dying && !this.Student.Alarmed && !this.Student.Splashed && !this.Student.TurnOffRadio)
		{
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
					if (this.Student.Follower != null)
					{
						this.Student.FollowTargetDestination.localPosition = new Vector3(1f, 0f, 0f);
					}
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
				if (this.Student.Follower != null)
				{
					this.Student.FollowTargetDestination.localPosition = new Vector3(1f, 0f, 1f);
				}
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

	// Token: 0x06001C6C RID: 7276 RVA: 0x0014B344 File Offset: 0x00149544
	private void LateUpdate()
	{
		if (this.Phase < 7)
		{
			this.RightFoot.localScale = new Vector3(0.9f, 1f, 0.9f);
			this.LeftFoot.localScale = new Vector3(0.9f, 1f, 0.9f);
		}
	}

	// Token: 0x06001C6D RID: 7277 RVA: 0x0014B398 File Offset: 0x00149598
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

	// Token: 0x06001C6E RID: 7278 RVA: 0x0014B7A2 File Offset: 0x001499A2
	public void CloseLocker()
	{
	}

	// Token: 0x06001C6F RID: 7279 RVA: 0x0014B7A4 File Offset: 0x001499A4
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

	// Token: 0x06001C70 RID: 7280 RVA: 0x0014B82C File Offset: 0x00149A2C
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

	// Token: 0x06001C71 RID: 7281 RVA: 0x0014BA11 File Offset: 0x00149C11
	private void GetHeight(int StudentID)
	{
		this.Height = 5;
		this.RemoveCasualAnim += "5_00";
		this.RemoveSchoolAnim += "5_01";
	}

	// Token: 0x04003265 RID: 12901
	public StudentScript Student;

	// Token: 0x04003266 RID: 12902
	public Vector3 RightShoePosition;

	// Token: 0x04003267 RID: 12903
	public Vector3 LeftShoePosition;

	// Token: 0x04003268 RID: 12904
	public Transform RightCurrentShoe;

	// Token: 0x04003269 RID: 12905
	public Transform LeftCurrentShoe;

	// Token: 0x0400326A RID: 12906
	public Transform RightCasualShoe;

	// Token: 0x0400326B RID: 12907
	public Transform LeftCasualShoe;

	// Token: 0x0400326C RID: 12908
	public Transform RightSchoolShoe;

	// Token: 0x0400326D RID: 12909
	public Transform LeftSchoolShoe;

	// Token: 0x0400326E RID: 12910
	public Transform RightNewShoe;

	// Token: 0x0400326F RID: 12911
	public Transform LeftNewShoe;

	// Token: 0x04003270 RID: 12912
	public Transform RightFoot;

	// Token: 0x04003271 RID: 12913
	public Transform LeftFoot;

	// Token: 0x04003272 RID: 12914
	public Transform RightHand;

	// Token: 0x04003273 RID: 12915
	public Transform LeftHand;

	// Token: 0x04003274 RID: 12916
	public Transform ShoeParent;

	// Token: 0x04003275 RID: 12917
	public Transform Locker;

	// Token: 0x04003276 RID: 12918
	public GameObject NewPairOfShoes;

	// Token: 0x04003277 RID: 12919
	public GameObject Character;

	// Token: 0x04003278 RID: 12920
	public string[] LockerAnims;

	// Token: 0x04003279 RID: 12921
	public Texture OutdoorShoes;

	// Token: 0x0400327A RID: 12922
	public Texture IndoorShoes;

	// Token: 0x0400327B RID: 12923
	public Texture TargetShoes;

	// Token: 0x0400327C RID: 12924
	public Texture Socks;

	// Token: 0x0400327D RID: 12925
	public Renderer MyRenderer;

	// Token: 0x0400327E RID: 12926
	public bool RemovingCasual = true;

	// Token: 0x0400327F RID: 12927
	public bool Male;

	// Token: 0x04003280 RID: 12928
	public int Height;

	// Token: 0x04003281 RID: 12929
	public int Phase = 1;

	// Token: 0x04003282 RID: 12930
	public float X;

	// Token: 0x04003283 RID: 12931
	public float Y;

	// Token: 0x04003284 RID: 12932
	public float Z;

	// Token: 0x04003285 RID: 12933
	public string RemoveCasualAnim = string.Empty;

	// Token: 0x04003286 RID: 12934
	public string RemoveSchoolAnim = string.Empty;

	// Token: 0x04003287 RID: 12935
	public string RemovalAnim = string.Empty;
}
