using System;
using UnityEngine;

// Token: 0x02000464 RID: 1124
public class TallLockerScript : MonoBehaviour
{
	// Token: 0x06001E77 RID: 7799 RVA: 0x001A9EE4 File Offset: 0x001A80E4
	private void Start()
	{
		this.Prompt.HideButton[1] = true;
		this.Prompt.HideButton[2] = true;
		this.Prompt.HideButton[3] = true;
	}

	// Token: 0x06001E78 RID: 7800 RVA: 0x001A9F10 File Offset: 0x001A8110
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
					this.Yandere.NotificationManager.CustomText = "Bring a clean uniform here first!";
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
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

	// Token: 0x06001E79 RID: 7801 RVA: 0x001AA9A4 File Offset: 0x001A8BA4
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

	// Token: 0x06001E7A RID: 7802 RVA: 0x001AAAE4 File Offset: 0x001A8CE4
	public void SpawnSteamNoSideEffects(StudentScript SteamStudent)
	{
		Debug.Log(string.Concat(new string[]
		{
			"Student #",
			SteamStudent.StudentID.ToString(),
			", ",
			SteamStudent.Name,
			", is changing clothes, no strings attached."
		}));
		UnityEngine.Object.Instantiate<GameObject>(this.SteamCloud, SteamStudent.transform.position + Vector3.up * 0.81f, Quaternion.identity).transform.parent = SteamStudent.transform;
		SteamStudent.CharacterAnimation.CrossFade(SteamStudent.StripAnim);
		SteamStudent.Pathfinding.canSearch = false;
		SteamStudent.Pathfinding.canMove = false;
		SteamStudent.MustChangeClothing = false;
		SteamStudent.Stripping = true;
		SteamStudent.Routine = false;
		SteamStudent.WalkAnim = SteamStudent.OriginalOriginalWalkAnim;
	}

	// Token: 0x06001E7B RID: 7803 RVA: 0x001AABBC File Offset: 0x001A8DBC
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

	// Token: 0x06001E7C RID: 7804 RVA: 0x001AAD90 File Offset: 0x001A8F90
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

	// Token: 0x06001E7D RID: 7805 RVA: 0x001AAEE8 File Offset: 0x001A90E8
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
					if (transform.GetComponent<FoldedUniformScript>().Clean)
					{
						Debug.Log("AND it's clean!");
						this.AvailableUniforms++;
					}
					else
					{
						Debug.Log("BUT, it's not clean!");
					}
				}
			}
		}
	}

	// Token: 0x04003E8B RID: 16011
	public GameObject[] BloodyClubUniform;

	// Token: 0x04003E8C RID: 16012
	public GameObject[] BloodyUniform;

	// Token: 0x04003E8D RID: 16013
	public GameObject[] Schoolwear;

	// Token: 0x04003E8E RID: 16014
	public bool[] Removed;

	// Token: 0x04003E8F RID: 16015
	public bool[] Bloody;

	// Token: 0x04003E90 RID: 16016
	public GameObject CleanUniform;

	// Token: 0x04003E91 RID: 16017
	public GameObject SteamCloud;

	// Token: 0x04003E92 RID: 16018
	public StudentManagerScript StudentManager;

	// Token: 0x04003E93 RID: 16019
	public RivalPhoneScript RivalPhone;

	// Token: 0x04003E94 RID: 16020
	public StudentScript Student;

	// Token: 0x04003E95 RID: 16021
	public YandereScript Yandere;

	// Token: 0x04003E96 RID: 16022
	public PromptScript Prompt;

	// Token: 0x04003E97 RID: 16023
	public Transform Hinge;

	// Token: 0x04003E98 RID: 16024
	public bool RemovingClubAttire;

	// Token: 0x04003E99 RID: 16025
	public bool DropCleanUniform;

	// Token: 0x04003E9A RID: 16026
	public bool SteamCountdown;

	// Token: 0x04003E9B RID: 16027
	public bool YandereLocker;

	// Token: 0x04003E9C RID: 16028
	public bool Swapping;

	// Token: 0x04003E9D RID: 16029
	public bool Open;

	// Token: 0x04003E9E RID: 16030
	public float Rotation;

	// Token: 0x04003E9F RID: 16031
	public float Timer;

	// Token: 0x04003EA0 RID: 16032
	public int AvailableUniforms = 2;

	// Token: 0x04003EA1 RID: 16033
	public int Phase = 1;
}
