using System;
using UnityEngine;

// Token: 0x0200045F RID: 1119
public class TallLockerScript : MonoBehaviour
{
	// Token: 0x06001E51 RID: 7761 RVA: 0x001A684C File Offset: 0x001A4A4C
	private void Start()
	{
		this.Prompt.HideButton[1] = true;
		this.Prompt.HideButton[2] = true;
		this.Prompt.HideButton[3] = true;
	}

	// Token: 0x06001E52 RID: 7762 RVA: 0x001A6878 File Offset: 0x001A4A78
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f && !this.Yandere.Chased && this.Yandere.Chasers == 0)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Open)
			{
				this.Open = true;
				if (this.YandereLocker)
				{
					if (!this.Yandere.ClubAttire || (this.Yandere.ClubAttire && this.Yandere.Bloodiness > 0f))
					{
						if (this.Yandere.Bloodiness == 0f)
						{
							if (!this.Bloody[1])
							{
								this.Prompt.HideButton[1] = false;
							}
							if (!this.Bloody[2])
							{
								this.Prompt.HideButton[2] = false;
							}
							if (!this.Bloody[3])
							{
								this.Prompt.HideButton[3] = false;
							}
						}
						else if (this.Yandere.Schoolwear > 0)
						{
							if (!this.Yandere.ClubAttire)
							{
								this.Prompt.HideButton[this.Yandere.Schoolwear] = false;
							}
							else
							{
								this.Prompt.HideButton[1] = false;
							}
						}
					}
					else
					{
						this.Prompt.HideButton[1] = true;
						this.Prompt.HideButton[2] = true;
						this.Prompt.HideButton[3] = true;
					}
				}
				this.UpdateSchoolwear();
				this.Prompt.Label[0].text = "     Close";
			}
			else
			{
				this.Open = false;
				this.Prompt.HideButton[1] = true;
				this.Prompt.HideButton[2] = true;
				this.Prompt.HideButton[3] = true;
				this.Prompt.Label[0].text = "     Open";
			}
		}
		if (!this.Open)
		{
			if (this.YandereLocker)
			{
				this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 10f);
			}
			this.Prompt.HideButton[1] = true;
			this.Prompt.HideButton[2] = true;
			this.Prompt.HideButton[3] = true;
		}
		else
		{
			if (this.YandereLocker)
			{
				this.Rotation = Mathf.Lerp(this.Rotation, -180f, Time.deltaTime * 10f);
			}
			if (this.Prompt.Circle[1].fillAmount == 0f)
			{
				this.Yandere.EmptyHands();
				if (this.Yandere.ClubAttire)
				{
					this.RemovingClubAttire = true;
				}
				this.Yandere.PreviousSchoolwear = this.Yandere.Schoolwear;
				if (this.Yandere.Schoolwear == 1)
				{
					this.Yandere.Schoolwear = 0;
					if (!this.Removed[1])
					{
						if (this.Yandere.Bloodiness == 0f)
						{
							this.DropCleanUniform = true;
						}
					}
					else
					{
						this.Removed[1] = false;
					}
				}
				else
				{
					this.Yandere.Schoolwear = 1;
					this.Removed[1] = true;
				}
				this.SpawnSteam();
				this.Yandere.CurrentUniformOrigin = 1;
			}
			else if (this.Prompt.Circle[2].fillAmount == 0f)
			{
				bool flag = false;
				if (this.Yandere.Schoolwear > 0)
				{
					Debug.Log("Checking to see if it's okay for the player to take off clothing.");
					this.CheckAvailableUniforms();
					if (this.AvailableUniforms > 0)
					{
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
				if (flag)
				{
					this.Yandere.EmptyHands();
					if (this.Yandere.ClubAttire)
					{
						this.RemovingClubAttire = true;
					}
					this.Yandere.PreviousSchoolwear = this.Yandere.Schoolwear;
					if (this.Yandere.Schoolwear == 1 && !this.Removed[1])
					{
						this.DropCleanUniform = true;
					}
					if (this.Yandere.Schoolwear == 2)
					{
						this.Yandere.Schoolwear = 0;
						this.Removed[2] = false;
					}
					else
					{
						this.Yandere.Schoolwear = 2;
						this.Removed[2] = true;
					}
					this.SpawnSteam();
					this.Yandere.CurrentUniformOrigin = 1;
				}
				else
				{
					this.Prompt.Circle[2].fillAmount = 1f;
					Debug.Log("Error Message.");
				}
			}
			else if (this.Prompt.Circle[3].fillAmount == 0f)
			{
				this.Yandere.EmptyHands();
				if (this.Yandere.ClubAttire)
				{
					this.RemovingClubAttire = true;
				}
				this.Yandere.PreviousSchoolwear = this.Yandere.Schoolwear;
				if (this.Yandere.Schoolwear == 1 && !this.Removed[1])
				{
					this.DropCleanUniform = true;
				}
				if (this.Yandere.Schoolwear == 3)
				{
					this.Yandere.Schoolwear = 0;
					this.Removed[3] = false;
				}
				else
				{
					this.Yandere.Schoolwear = 3;
					this.Removed[3] = true;
				}
				this.SpawnSteam();
				this.Yandere.CurrentUniformOrigin = 1;
			}
		}
		if (this.YandereLocker)
		{
			this.Hinge.localEulerAngles = new Vector3(0f, this.Rotation, 0f);
		}
		if (this.SteamCountdown)
		{
			this.Timer += Time.deltaTime;
			if (this.Phase == 1)
			{
				if (this.Timer > 1.5f)
				{
					if (this.YandereLocker)
					{
						if (this.Yandere.Gloved)
						{
							this.Yandere.Gloves.GetComponent<PickUpScript>().MyRigidbody.isKinematic = false;
							this.Yandere.Gloves.transform.localPosition = new Vector3(0f, 1f, -1f);
							this.Yandere.Gloves.transform.parent = null;
							this.Yandere.GloveAttacher.newRenderer.enabled = false;
							this.Yandere.Gloves.gameObject.SetActive(true);
							this.Yandere.Gloved = false;
							this.Yandere.Gloves = null;
							this.Yandere.GloveBlood = 0;
						}
						if (this.Yandere.Mask != null)
						{
							this.Yandere.Mask.Drop();
							this.Yandere.WeaponMenu.UpdateSprites();
							this.StudentManager.UpdateStudents(0);
						}
						if (this.Yandere.WearingRaincoat)
						{
							this.Yandere.RaincoatAttacher.newRenderer.enabled = false;
							this.Yandere.PantyAttacher.newRenderer.enabled = true;
							this.Yandere.TheDebugMenuScript.UpdateCensor();
							this.Yandere.CoatBloodiness = this.Yandere.Bloodiness;
							this.Yandere.Bloodiness = this.Yandere.OriginalBloodiness;
							this.Yandere.WearingRaincoat = false;
							if (!this.StudentManager.Eighties)
							{
								this.Yandere.Hairstyle = 1;
							}
							else
							{
								this.Yandere.Hairstyle = 203;
							}
							this.Yandere.UpdateHair();
						}
						this.Yandere.ChangeSchoolwear();
						if (this.Yandere.Bloodiness > 0f)
						{
							PickUpScript component;
							if (this.RemovingClubAttire)
							{
								component = UnityEngine.Object.Instantiate<GameObject>(this.BloodyClubUniform[(int)this.Yandere.Club], this.Yandere.transform.position + Vector3.forward * 0.5f + Vector3.up, Quaternion.identity).GetComponent<PickUpScript>();
								this.StudentManager.ChangingBooths[(int)this.Yandere.Club].CannotChange = true;
								this.StudentManager.ChangingBooths[(int)this.Yandere.Club].CheckYandereClub();
								this.Prompt.HideButton[1] = true;
								this.Prompt.HideButton[2] = true;
								this.Prompt.HideButton[3] = true;
								this.RemovingClubAttire = false;
							}
							else
							{
								component = UnityEngine.Object.Instantiate<GameObject>(this.BloodyUniform[this.Yandere.PreviousSchoolwear], this.Yandere.transform.position + Vector3.forward * 0.5f + Vector3.up, Quaternion.identity).GetComponent<PickUpScript>();
								this.Prompt.HideButton[this.Yandere.PreviousSchoolwear] = true;
								this.Bloody[this.Yandere.PreviousSchoolwear] = true;
							}
							if (this.Yandere.RedPaint)
							{
								component.RedPaint = true;
							}
						}
					}
					else if (this.Student != null)
					{
						if (this.Student.Schoolwear == 0 && !this.Student.Male && !this.StudentManager.Eighties && !this.RivalPhone.gameObject.activeInHierarchy && !this.Yandere.Inventory.RivalPhone)
						{
							StudentScript student = this.Student;
							Debug.Log(((student != null) ? student.ToString() : null) + " just left her smartphone in the locker room!");
							this.RivalPhone.transform.parent = this.StudentManager.StrippingPositions[this.Student.GirlID];
							this.RivalPhone.transform.localPosition = new Vector3(0f, 0.92f, 0.2375f);
							this.RivalPhone.transform.localEulerAngles = new Vector3(-80f, 0f, 0f);
							Physics.SyncTransforms();
							this.RivalPhone.gameObject.SetActive(true);
							this.RivalPhone.StudentID = this.Student.StudentID;
							this.RivalPhone.MyRenderer.material.mainTexture = this.Student.SmartPhone.GetComponent<Renderer>().material.mainTexture;
						}
						this.Student.ChangeSchoolwear();
					}
					this.UpdateSchoolwear();
					this.Phase++;
					return;
				}
			}
			else if (this.Timer > 2.5f)
			{
				if (!this.YandereLocker && this.Student != null)
				{
					this.Student.BathePhase++;
				}
				this.SteamCountdown = false;
				this.Phase = 1;
				this.Timer = 0f;
			}
		}
	}

	// Token: 0x06001E53 RID: 7763 RVA: 0x001A72E8 File Offset: 0x001A54E8
	public void SpawnSteam()
	{
		if (this.Student != null)
		{
			StudentScript student = this.Student;
			Debug.Log(((student != null) ? student.ToString() : null) + " is changing clothes, with all strings attached.");
		}
		this.SteamCountdown = true;
		if (this.YandereLocker)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.SteamCloud, this.Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
			this.Yandere.CharacterAnimation.CrossFade("f02_stripping_00");
			this.Yandere.Stripping = true;
			this.Yandere.CanMove = false;
			this.Timer = 0f;
			return;
		}
		UnityEngine.Object.Instantiate<GameObject>(this.SteamCloud, this.Student.transform.position + Vector3.up * 0.81f, Quaternion.identity).transform.parent = this.Student.transform;
		this.Student.CharacterAnimation.CrossFade(this.Student.StripAnim);
		this.Student.Pathfinding.canSearch = false;
		this.Student.Pathfinding.canMove = false;
	}

	// Token: 0x06001E54 RID: 7764 RVA: 0x001A7428 File Offset: 0x001A5628
	public void SpawnSteamNoSideEffects(StudentScript SteamStudent)
	{
		Debug.Log(((SteamStudent != null) ? SteamStudent.ToString() : null) + " is changing clothes, no strings attached.");
		UnityEngine.Object.Instantiate<GameObject>(this.SteamCloud, SteamStudent.transform.position + Vector3.up * 0.81f, Quaternion.identity).transform.parent = SteamStudent.transform;
		SteamStudent.CharacterAnimation.CrossFade(SteamStudent.StripAnim);
		SteamStudent.Pathfinding.canSearch = false;
		SteamStudent.Pathfinding.canMove = false;
		SteamStudent.MustChangeClothing = false;
		SteamStudent.Stripping = true;
		SteamStudent.Routine = false;
		SteamStudent.WalkAnim = SteamStudent.OriginalOriginalWalkAnim;
	}

	// Token: 0x06001E55 RID: 7765 RVA: 0x001A74DC File Offset: 0x001A56DC
	public void UpdateSchoolwear()
	{
		if (this.DropCleanUniform)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.CleanUniform, this.Yandere.transform.position + Vector3.forward * -0.5f + Vector3.up, Quaternion.identity);
			this.DropCleanUniform = false;
		}
		if (!this.Bloody[1])
		{
			this.Schoolwear[1].SetActive(true);
		}
		if (!this.Bloody[2])
		{
			this.Schoolwear[2].SetActive(true);
		}
		if (!this.Bloody[3])
		{
			this.Schoolwear[3].SetActive(true);
		}
		this.Prompt.Label[1].text = "     School Uniform";
		this.Prompt.Label[2].text = "     School Swimsuit";
		this.Prompt.Label[3].text = "     Gym Uniform";
		if (this.YandereLocker)
		{
			if (this.Yandere.ClubAttire)
			{
				this.Prompt.Label[1].text = "     Towel";
				return;
			}
			if (this.Yandere.Schoolwear > 0)
			{
				this.Prompt.Label[this.Yandere.Schoolwear].text = "     Towel";
				if (this.Removed[this.Yandere.Schoolwear])
				{
					this.Schoolwear[this.Yandere.Schoolwear].SetActive(false);
					return;
				}
			}
		}
		else if (this.Student != null && this.Student.Schoolwear > 0)
		{
			this.Prompt.HideButton[this.Student.Schoolwear] = true;
			this.Schoolwear[this.Student.Schoolwear].SetActive(false);
			this.Student.Indoors = true;
		}
	}

	// Token: 0x06001E56 RID: 7766 RVA: 0x001A76B0 File Offset: 0x001A58B0
	public void UpdateButtons()
	{
		if (!this.Yandere.ClubAttire || (this.Yandere.ClubAttire && this.Yandere.Bloodiness > 0f))
		{
			if (this.Open)
			{
				if (this.Yandere.Bloodiness > 0f)
				{
					this.Prompt.HideButton[1] = true;
					this.Prompt.HideButton[2] = true;
					this.Prompt.HideButton[3] = true;
					if (this.Yandere.Schoolwear > 0 && !this.Yandere.ClubAttire)
					{
						this.Prompt.HideButton[this.Yandere.Schoolwear] = false;
					}
					if (this.Yandere.ClubAttire)
					{
						Debug.Log("Don't hide Prompt 1!");
						this.Prompt.HideButton[1] = false;
						return;
					}
				}
				else
				{
					if (!this.Bloody[1])
					{
						this.Prompt.HideButton[1] = false;
					}
					if (!this.Bloody[2])
					{
						this.Prompt.HideButton[2] = false;
					}
					if (!this.Bloody[3])
					{
						this.Prompt.HideButton[3] = false;
						return;
					}
				}
			}
		}
		else
		{
			this.Prompt.HideButton[1] = true;
			this.Prompt.HideButton[2] = true;
			this.Prompt.HideButton[3] = true;
		}
	}

	// Token: 0x06001E57 RID: 7767 RVA: 0x001A7808 File Offset: 0x001A5A08
	private void CheckAvailableUniforms()
	{
		this.AvailableUniforms = this.StudentManager.OriginalUniforms;
		Debug.Log(this.AvailableUniforms.ToString() + " of the original uniforms are still clean.");
		Debug.Log("There are " + this.StudentManager.NewUniforms.ToString() + " new uniforms in school.");
		if (this.StudentManager.NewUniforms > 0)
		{
			for (int i = 0; i < this.StudentManager.Uniforms.Length; i++)
			{
				Transform transform = this.StudentManager.Uniforms[i];
				if (transform != null && this.StudentManager.LockerRoomArea.bounds.Contains(transform.position))
				{
					Debug.Log("Cool, there's a uniform in the locker room.");
					this.AvailableUniforms++;
				}
			}
		}
	}

	// Token: 0x04003E20 RID: 15904
	public GameObject[] BloodyClubUniform;

	// Token: 0x04003E21 RID: 15905
	public GameObject[] BloodyUniform;

	// Token: 0x04003E22 RID: 15906
	public GameObject[] Schoolwear;

	// Token: 0x04003E23 RID: 15907
	public bool[] Removed;

	// Token: 0x04003E24 RID: 15908
	public bool[] Bloody;

	// Token: 0x04003E25 RID: 15909
	public GameObject CleanUniform;

	// Token: 0x04003E26 RID: 15910
	public GameObject SteamCloud;

	// Token: 0x04003E27 RID: 15911
	public StudentManagerScript StudentManager;

	// Token: 0x04003E28 RID: 15912
	public RivalPhoneScript RivalPhone;

	// Token: 0x04003E29 RID: 15913
	public StudentScript Student;

	// Token: 0x04003E2A RID: 15914
	public YandereScript Yandere;

	// Token: 0x04003E2B RID: 15915
	public PromptScript Prompt;

	// Token: 0x04003E2C RID: 15916
	public Transform Hinge;

	// Token: 0x04003E2D RID: 15917
	public bool RemovingClubAttire;

	// Token: 0x04003E2E RID: 15918
	public bool DropCleanUniform;

	// Token: 0x04003E2F RID: 15919
	public bool SteamCountdown;

	// Token: 0x04003E30 RID: 15920
	public bool YandereLocker;

	// Token: 0x04003E31 RID: 15921
	public bool Swapping;

	// Token: 0x04003E32 RID: 15922
	public bool Open;

	// Token: 0x04003E33 RID: 15923
	public float Rotation;

	// Token: 0x04003E34 RID: 15924
	public float Timer;

	// Token: 0x04003E35 RID: 15925
	public int AvailableUniforms = 2;

	// Token: 0x04003E36 RID: 15926
	public int Phase = 1;
}
