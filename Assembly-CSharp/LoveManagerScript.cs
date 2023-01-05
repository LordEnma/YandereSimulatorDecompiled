using UnityEngine;

public class LoveManagerScript : MonoBehaviour
{
	public ConfessionManagerScript ConfessionManager;

	public AppearanceWindowScript AppearanceWindow;

	public ConfessionSceneScript ConfessionScene;

	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public ClockScript Clock;

	public StudentScript Follower;

	public StudentScript Suitor;

	public StudentScript Rival;

	public Transform FriendWaitSpot;

	public Transform[] Targets;

	public Transform MythHill;

	public int SuitorProgress;

	public int TotalTargets;

	public int Phase = 1;

	public int ID;

	public int SuitorID = 28;

	public int RivalID = 30;

	public float ProximityWarningTimer;

	public float AngleLimit;

	public bool WaitingToConfess;

	public bool ConfessToSuitor;

	public bool HoldingHands;

	public bool RivalWaiting;

	public bool LeftNote;

	public bool Courted;

	public bool CustomSuitorBlack;

	public bool CustomSuitorTan;

	public bool CustomSuitor;

	public int CustomSuitorAccessory;

	public int CustomSuitorEyewear;

	public int CustomSuitorJewelry;

	public int CustomSuitorHair;

	private void Start()
	{
		int week = DateGlobals.Week;
		if (week > 10)
		{
			base.gameObject.SetActive(false);
			return;
		}
		SuitorProgress = DatingGlobals.SuitorProgress;
		CustomSuitorAccessory = StudentGlobals.CustomSuitorAccessory;
		CustomSuitorEyewear = StudentGlobals.CustomSuitorEyewear;
		CustomSuitorJewelry = StudentGlobals.CustomSuitorJewelry;
		CustomSuitorBlack = StudentGlobals.CustomSuitorBlack;
		CustomSuitorHair = StudentGlobals.CustomSuitorHair;
		CustomSuitorTan = StudentGlobals.CustomSuitorTan;
		CustomSuitor = StudentGlobals.CustomSuitor;
		if (GameGlobals.Eighties)
		{
			SuitorID = StudentManager.SuitorIDs[week];
			RivalID = 10 + week;
			if (DatingGlobals.Affection >= (float)(week * 10))
			{
				ConfessToSuitor = true;
			}
		}
		else
		{
			SuitorID = 6;
			RivalID = 11;
			if (DatingGlobals.Affection == 100f)
			{
				ConfessToSuitor = true;
			}
		}
	}

	private void LateUpdate()
	{
		if (Yandere.Follower != null && Yandere.Follower.StudentID == StudentManager.RivalID)
		{
			Follower = Yandere.Follower;
			for (ID = 0; ID < TotalTargets; ID++)
			{
				Transform transform = Targets[ID];
				if (transform != null && Follower.transform.position.y > transform.position.y - 2f && Follower.transform.position.y < transform.position.y + 2f && Vector3.Distance(Follower.transform.position, new Vector3(transform.position.x, Follower.transform.position.y, transform.position.z)) < 2.5f)
				{
					if (Mathf.Abs(Vector3.Angle(Follower.transform.forward, Follower.transform.position - new Vector3(transform.position.x, Follower.transform.position.y, transform.position.z))) > AngleLimit)
					{
						if (!Follower.Gush)
						{
							Follower.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
							Follower.GushTarget = transform;
							ParticleSystem.EmissionModule emission = Follower.Hearts.emission;
							emission.enabled = true;
							emission.rateOverTime = 5f;
							Follower.Hearts.Play();
							Follower.Gush = true;
						}
					}
					else
					{
						Follower.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
						ParticleSystem.EmissionModule emission2 = Follower.Hearts.emission;
						emission2.enabled = false;
						Follower.Gush = false;
					}
				}
			}
		}
		if (LeftNote)
		{
			if (Rival == null)
			{
				Rival = StudentManager.Students[RivalID];
			}
			if (Suitor == null)
			{
				if (ConfessToSuitor)
				{
					Suitor = StudentManager.Students[SuitorID];
				}
				else
				{
					Suitor = StudentManager.Students[1];
				}
			}
			if (Rival != null && Suitor != null && Rival.Alive && Suitor.Alive && !Rival.Dying && !Suitor.Dying && Rival.ConfessPhase == 5 && Suitor.ConfessPhase == 3)
			{
				WaitingToConfess = true;
				float num = Vector3.Distance(Yandere.transform.position, MythHill.position);
				ProximityWarningTimer = Mathf.MoveTowards(ProximityWarningTimer, 0f, Time.deltaTime);
				if (ProximityWarningTimer == 0f)
				{
					if (num < 10f)
					{
						Yandere.NotificationManager.CustomText = "Back away from the tree to watch the confession.";
					}
					else
					{
						Yandere.NotificationManager.CustomText = "Approach the tree to watch the confession.";
					}
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					ProximityWarningTimer = 5f;
				}
				if (WaitingToConfess && !Yandere.Chased && Yandere.Chasers == 0 && !Yandere.Noticed && num > 10f && num < 25f)
				{
					BeginConfession();
				}
			}
		}
		if (HoldingHands)
		{
			if (Rival == null)
			{
				Rival = StudentManager.Students[RivalID];
			}
			if (Suitor == null)
			{
				Suitor = StudentManager.Students[SuitorID];
			}
			Rival.MyController.Move(base.transform.forward * Time.deltaTime);
			Suitor.transform.position = new Vector3(Rival.transform.position.x - 0.5f, Rival.transform.position.y, Rival.transform.position.z);
			if (Rival.transform.position.z > -50f)
			{
				Suitor.MyController.radius = 0.12f;
				Suitor.enabled = true;
				Suitor.Cosmetic.MyRenderer.materials[Suitor.Cosmetic.FaceID].SetFloat("_BlendAmount", 0f);
				ParticleSystem.EmissionModule emission3 = Suitor.Hearts.emission;
				emission3.enabled = false;
				Rival.MyController.radius = 0.12f;
				Rival.enabled = true;
				Rival.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
				ParticleSystem.EmissionModule emission4 = Rival.Hearts.emission;
				emission4.enabled = false;
				Suitor.HoldingHands = false;
				Rival.HoldingHands = false;
				HoldingHands = false;
			}
		}
	}

	public void CoupleCheck()
	{
		if (SuitorProgress == 2)
		{
			Rival = StudentManager.Students[RivalID];
			Suitor = StudentManager.Students[SuitorID];
			if (Rival != null && Suitor != null)
			{
				Suitor.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				Suitor.CharacterAnimation.enabled = true;
				Rival.CharacterAnimation.enabled = true;
				Suitor.CharacterAnimation.Play("walkHands_00");
				Suitor.transform.eulerAngles = Vector3.zero;
				Suitor.transform.position = new Vector3(-0.25f, 0f, -90f);
				Suitor.Pathfinding.canSearch = false;
				Suitor.Pathfinding.canMove = false;
				Suitor.MyController.radius = 0f;
				Suitor.enabled = false;
				Rival.CharacterAnimation.Play("f02_walkHands_00");
				Rival.transform.eulerAngles = Vector3.zero;
				Rival.transform.position = new Vector3(0.25f, 0f, -90f);
				Rival.Pathfinding.canSearch = false;
				Rival.Pathfinding.canMove = false;
				Rival.MyController.radius = 0f;
				Rival.enabled = false;
				Physics.SyncTransforms();
				Suitor.Cosmetic.MyRenderer.materials[Suitor.Cosmetic.FaceID].SetFloat("_BlendAmount", 1f);
				ParticleSystem.EmissionModule emission = Suitor.Hearts.emission;
				emission.enabled = true;
				emission.rateOverTime = 5f;
				Suitor.Hearts.Play();
				Rival.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
				ParticleSystem.EmissionModule emission2 = Rival.Hearts.emission;
				emission2.enabled = true;
				emission2.rateOverTime = 5f;
				Rival.Hearts.Play();
				Suitor.HoldingHands = true;
				Rival.HoldingHands = true;
				Suitor.PartnerID = RivalID;
				Rival.PartnerID = SuitorID;
				HoldingHands = true;
				Debug.Log("Students are now holding hands.");
			}
		}
	}

	public void BeginConfession()
	{
		Debug.Log("Confession is being told to begin.");
		Time.timeScale = 1f;
		Suitor.EmptyHands();
		Rival.EmptyHands();
		if (Yandere.Aiming)
		{
			Yandere.StopAiming();
		}
		if (Yandere.YandereVision)
		{
			Yandere.ResetYandereEffects();
			Yandere.YandereVision = false;
		}
		Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
		Yandere.RPGCamera.enabled = false;
		Yandere.CanMove = false;
		StudentManager.DisableEveryone();
		Suitor.gameObject.SetActive(true);
		Rival.gameObject.SetActive(true);
		Suitor.enabled = false;
		Rival.enabled = false;
		Suitor.Pathfinding.canSearch = false;
		Suitor.Pathfinding.canMove = false;
		Rival.Pathfinding.canSearch = false;
		Rival.Pathfinding.canMove = false;
		if (!ConfessToSuitor)
		{
			ConfessionManager.Senpai = StudentManager.Students[1].CharacterAnimation;
			ConfessionManager.gameObject.SetActive(true);
		}
		else
		{
			ConfessionScene.enabled = true;
		}
		Clock.Police.gameObject.SetActive(false);
		WaitingToConfess = false;
		Clock.StopTime = true;
		LeftNote = false;
	}

	public void SaveSuitorInstructions()
	{
		StudentGlobals.CustomSuitorAccessory = CustomSuitorAccessory;
		StudentGlobals.CustomSuitorEyewear = CustomSuitorEyewear;
		StudentGlobals.CustomSuitorJewelry = CustomSuitorJewelry;
		StudentGlobals.CustomSuitorBlack = CustomSuitorBlack;
		StudentGlobals.CustomSuitorHair = CustomSuitorHair;
		StudentGlobals.CustomSuitorTan = CustomSuitorTan;
		StudentGlobals.CustomSuitor = CustomSuitor;
		DatingGlobals.SetSuitorCheck(1, AppearanceWindow.Checks[1].enabled);
		DatingGlobals.SetSuitorCheck(2, AppearanceWindow.Checks[2].enabled);
		DatingGlobals.SetSuitorCheck(3, AppearanceWindow.Checks[3].enabled);
		DatingGlobals.SetSuitorCheck(4, AppearanceWindow.Checks[4].enabled);
		DatingGlobals.SetSuitorCheck(5, AppearanceWindow.Checks[5].enabled);
		DatingGlobals.SetSuitorCheck(6, AppearanceWindow.Checks[6].enabled);
		DatingGlobals.SetSuitorCheck(7, AppearanceWindow.Checks[7].enabled);
		DatingGlobals.SetSuitorCheck(8, AppearanceWindow.Checks[8].enabled);
		DatingGlobals.SetSuitorCheck(9, AppearanceWindow.Checks[9].enabled);
	}
}
