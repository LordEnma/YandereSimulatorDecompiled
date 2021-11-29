using System;
using UnityEngine;

// Token: 0x02000354 RID: 852
public class LoveManagerScript : MonoBehaviour
{
	// Token: 0x06001958 RID: 6488 RVA: 0x000FFBE0 File Offset: 0x000FDDE0
	private void Start()
	{
		int week = DateGlobals.Week;
		if (week > 10)
		{
			base.gameObject.SetActive(false);
			return;
		}
		this.SuitorProgress = DatingGlobals.SuitorProgress;
		this.CustomSuitorAccessory = StudentGlobals.CustomSuitorAccessory;
		this.CustomSuitorEyewear = StudentGlobals.CustomSuitorEyewear;
		this.CustomSuitorJewelry = StudentGlobals.CustomSuitorJewelry;
		this.CustomSuitorBlack = StudentGlobals.CustomSuitorBlack;
		this.CustomSuitorHair = StudentGlobals.CustomSuitorHair;
		this.CustomSuitorTan = StudentGlobals.CustomSuitorTan;
		this.CustomSuitor = StudentGlobals.CustomSuitor;
		if (GameGlobals.Eighties)
		{
			this.SuitorID = this.StudentManager.SuitorIDs[week];
			this.RivalID = 10 + week;
			if (DatingGlobals.Affection >= (float)(week * 10))
			{
				this.ConfessToSuitor = true;
				return;
			}
		}
		else
		{
			this.SuitorID = 6;
			this.RivalID = 11;
			if (DatingGlobals.Affection == 100f)
			{
				this.ConfessToSuitor = true;
			}
		}
	}

	// Token: 0x06001959 RID: 6489 RVA: 0x000FFCB8 File Offset: 0x000FDEB8
	private void LateUpdate()
	{
		if (this.Yandere.Follower != null && this.Yandere.Follower.StudentID == this.StudentManager.RivalID)
		{
			this.Follower = this.Yandere.Follower;
			this.ID = 0;
			while (this.ID < this.TotalTargets)
			{
				Transform transform = this.Targets[this.ID];
				if (transform != null && this.Follower.transform.position.y > transform.position.y - 2f && this.Follower.transform.position.y < transform.position.y + 2f && Vector3.Distance(this.Follower.transform.position, new Vector3(transform.position.x, this.Follower.transform.position.y, transform.position.z)) < 2.5f)
				{
					if (Mathf.Abs(Vector3.Angle(this.Follower.transform.forward, this.Follower.transform.position - new Vector3(transform.position.x, this.Follower.transform.position.y, transform.position.z))) > this.AngleLimit)
					{
						if (!this.Follower.Gush)
						{
							this.Follower.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
							this.Follower.GushTarget = transform;
							ParticleSystem.EmissionModule emission = this.Follower.Hearts.emission;
							emission.enabled = true;
							emission.rateOverTime = 5f;
							this.Follower.Hearts.Play();
							this.Follower.Gush = true;
						}
					}
					else
					{
						this.Follower.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
						this.Follower.Hearts.emission.enabled = false;
						this.Follower.Gush = false;
					}
				}
				this.ID++;
			}
		}
		if (this.LeftNote)
		{
			if (this.Rival == null)
			{
				this.Rival = this.StudentManager.Students[this.RivalID];
			}
			if (this.Suitor == null)
			{
				if (this.ConfessToSuitor)
				{
					this.Suitor = this.StudentManager.Students[this.SuitorID];
				}
				else
				{
					this.Suitor = this.StudentManager.Students[1];
				}
			}
			if (this.Rival != null && this.Suitor != null && this.Rival.Alive && this.Suitor.Alive && !this.Rival.Dying && !this.Suitor.Dying && this.Rival.ConfessPhase == 5 && this.Suitor.ConfessPhase == 3)
			{
				this.WaitingToConfess = true;
				float num = Vector3.Distance(this.Yandere.transform.position, this.MythHill.position);
				if (this.WaitingToConfess && !this.Yandere.Chased && this.Yandere.Chasers == 0 && num > 10f && num < 25f)
				{
					this.BeginConfession();
				}
			}
		}
		if (this.HoldingHands)
		{
			if (this.Rival == null)
			{
				this.Rival = this.StudentManager.Students[this.RivalID];
			}
			if (this.Suitor == null)
			{
				this.Suitor = this.StudentManager.Students[this.SuitorID];
			}
			this.Rival.MyController.Move(base.transform.forward * Time.deltaTime);
			this.Suitor.transform.position = new Vector3(this.Rival.transform.position.x - 0.5f, this.Rival.transform.position.y, this.Rival.transform.position.z);
			if (this.Rival.transform.position.z > -50f)
			{
				this.Suitor.MyController.radius = 0.12f;
				this.Suitor.enabled = true;
				this.Suitor.Cosmetic.MyRenderer.materials[this.Suitor.Cosmetic.FaceID].SetFloat("_BlendAmount", 0f);
				this.Suitor.Hearts.emission.enabled = false;
				this.Rival.MyController.radius = 0.12f;
				this.Rival.enabled = true;
				this.Rival.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
				this.Rival.Hearts.emission.enabled = false;
				this.Suitor.HoldingHands = false;
				this.Rival.HoldingHands = false;
				this.HoldingHands = false;
			}
		}
	}

	// Token: 0x0600195A RID: 6490 RVA: 0x0010026C File Offset: 0x000FE46C
	public void CoupleCheck()
	{
		if (this.SuitorProgress == 2)
		{
			this.Rival = this.StudentManager.Students[this.RivalID];
			this.Suitor = this.StudentManager.Students[this.SuitorID];
			if (this.Rival != null && this.Suitor != null)
			{
				this.Suitor.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				this.Suitor.CharacterAnimation.enabled = true;
				this.Rival.CharacterAnimation.enabled = true;
				this.Suitor.CharacterAnimation.Play("walkHands_00");
				this.Suitor.transform.eulerAngles = Vector3.zero;
				this.Suitor.transform.position = new Vector3(-0.25f, 0f, -90f);
				this.Suitor.Pathfinding.canSearch = false;
				this.Suitor.Pathfinding.canMove = false;
				this.Suitor.MyController.radius = 0f;
				this.Suitor.enabled = false;
				this.Rival.CharacterAnimation.Play("f02_walkHands_00");
				this.Rival.transform.eulerAngles = Vector3.zero;
				this.Rival.transform.position = new Vector3(0.25f, 0f, -90f);
				this.Rival.Pathfinding.canSearch = false;
				this.Rival.Pathfinding.canMove = false;
				this.Rival.MyController.radius = 0f;
				this.Rival.enabled = false;
				Physics.SyncTransforms();
				this.Suitor.Cosmetic.MyRenderer.materials[this.Suitor.Cosmetic.FaceID].SetFloat("_BlendAmount", 1f);
				ParticleSystem.EmissionModule emission = this.Suitor.Hearts.emission;
				emission.enabled = true;
				emission.rateOverTime = 5f;
				this.Suitor.Hearts.Play();
				this.Rival.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
				ParticleSystem.EmissionModule emission2 = this.Rival.Hearts.emission;
				emission2.enabled = true;
				emission2.rateOverTime = 5f;
				this.Rival.Hearts.Play();
				this.Suitor.HoldingHands = true;
				this.Rival.HoldingHands = true;
				this.Suitor.CoupleID = this.SuitorID;
				this.Rival.CoupleID = this.RivalID;
				this.HoldingHands = true;
				Debug.Log("Students are now holding hands.");
			}
		}
	}

	// Token: 0x0600195B RID: 6491 RVA: 0x00100560 File Offset: 0x000FE760
	public void BeginConfession()
	{
		Debug.Log("Confession is being told to begin.");
		Time.timeScale = 1f;
		this.Suitor.EmptyHands();
		this.Rival.EmptyHands();
		if (this.Yandere.Aiming)
		{
			this.Yandere.StopAiming();
		}
		if (this.Yandere.YandereVision)
		{
			this.Yandere.ResetYandereEffects();
			this.Yandere.YandereVision = false;
		}
		this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
		this.Yandere.RPGCamera.enabled = false;
		this.Yandere.CanMove = false;
		this.StudentManager.DisableEveryone();
		this.Suitor.gameObject.SetActive(true);
		this.Rival.gameObject.SetActive(true);
		this.Suitor.enabled = false;
		this.Rival.enabled = false;
		if (!this.ConfessToSuitor)
		{
			this.ConfessionManager.Senpai = this.StudentManager.Students[1].CharacterAnimation;
			this.ConfessionManager.gameObject.SetActive(true);
		}
		else
		{
			this.ConfessionScene.enabled = true;
		}
		this.Clock.Police.gameObject.SetActive(false);
		this.WaitingToConfess = false;
		this.Clock.StopTime = true;
		this.LeftNote = false;
	}

	// Token: 0x0600195C RID: 6492 RVA: 0x001006C4 File Offset: 0x000FE8C4
	public void SaveSuitorInstructions()
	{
		StudentGlobals.CustomSuitorAccessory = this.CustomSuitorAccessory;
		StudentGlobals.CustomSuitorEyewear = this.CustomSuitorEyewear;
		StudentGlobals.CustomSuitorJewelry = this.CustomSuitorJewelry;
		StudentGlobals.CustomSuitorBlack = this.CustomSuitorBlack;
		StudentGlobals.CustomSuitorHair = this.CustomSuitorHair;
		StudentGlobals.CustomSuitorTan = this.CustomSuitorTan;
		StudentGlobals.CustomSuitor = this.CustomSuitor;
		DatingGlobals.SetSuitorCheck(1, this.AppearanceWindow.Checks[1].enabled);
		DatingGlobals.SetSuitorCheck(2, this.AppearanceWindow.Checks[2].enabled);
		DatingGlobals.SetSuitorCheck(3, this.AppearanceWindow.Checks[3].enabled);
		DatingGlobals.SetSuitorCheck(4, this.AppearanceWindow.Checks[4].enabled);
		DatingGlobals.SetSuitorCheck(5, this.AppearanceWindow.Checks[5].enabled);
		DatingGlobals.SetSuitorCheck(6, this.AppearanceWindow.Checks[6].enabled);
		DatingGlobals.SetSuitorCheck(7, this.AppearanceWindow.Checks[7].enabled);
		DatingGlobals.SetSuitorCheck(8, this.AppearanceWindow.Checks[8].enabled);
		DatingGlobals.SetSuitorCheck(9, this.AppearanceWindow.Checks[9].enabled);
	}

	// Token: 0x0400282D RID: 10285
	public ConfessionManagerScript ConfessionManager;

	// Token: 0x0400282E RID: 10286
	public AppearanceWindowScript AppearanceWindow;

	// Token: 0x0400282F RID: 10287
	public ConfessionSceneScript ConfessionScene;

	// Token: 0x04002830 RID: 10288
	public StudentManagerScript StudentManager;

	// Token: 0x04002831 RID: 10289
	public YandereScript Yandere;

	// Token: 0x04002832 RID: 10290
	public ClockScript Clock;

	// Token: 0x04002833 RID: 10291
	public StudentScript Follower;

	// Token: 0x04002834 RID: 10292
	public StudentScript Suitor;

	// Token: 0x04002835 RID: 10293
	public StudentScript Rival;

	// Token: 0x04002836 RID: 10294
	public Transform FriendWaitSpot;

	// Token: 0x04002837 RID: 10295
	public Transform[] Targets;

	// Token: 0x04002838 RID: 10296
	public Transform MythHill;

	// Token: 0x04002839 RID: 10297
	public int SuitorProgress;

	// Token: 0x0400283A RID: 10298
	public int TotalTargets;

	// Token: 0x0400283B RID: 10299
	public int Phase = 1;

	// Token: 0x0400283C RID: 10300
	public int ID;

	// Token: 0x0400283D RID: 10301
	public int SuitorID = 28;

	// Token: 0x0400283E RID: 10302
	public int RivalID = 30;

	// Token: 0x0400283F RID: 10303
	public float AngleLimit;

	// Token: 0x04002840 RID: 10304
	public bool WaitingToConfess;

	// Token: 0x04002841 RID: 10305
	public bool ConfessToSuitor;

	// Token: 0x04002842 RID: 10306
	public bool HoldingHands;

	// Token: 0x04002843 RID: 10307
	public bool RivalWaiting;

	// Token: 0x04002844 RID: 10308
	public bool LeftNote;

	// Token: 0x04002845 RID: 10309
	public bool Courted;

	// Token: 0x04002846 RID: 10310
	public bool CustomSuitorBlack;

	// Token: 0x04002847 RID: 10311
	public bool CustomSuitorTan;

	// Token: 0x04002848 RID: 10312
	public bool CustomSuitor;

	// Token: 0x04002849 RID: 10313
	public int CustomSuitorAccessory;

	// Token: 0x0400284A RID: 10314
	public int CustomSuitorEyewear;

	// Token: 0x0400284B RID: 10315
	public int CustomSuitorJewelry;

	// Token: 0x0400284C RID: 10316
	public int CustomSuitorHair;
}
