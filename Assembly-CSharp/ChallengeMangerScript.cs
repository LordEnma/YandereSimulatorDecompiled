using UnityEngine;

public class ChallengeMangerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public StudentScript StudentToZoomInOn;

	public HeartbrokenScript Heartbroken;

	public YandereScript Yandere;

	public GameObject KnifeOnlyIcon;

	public GameObject NoAlertsIcon;

	public GameObject NoBagIcon;

	public GameObject NoFriendsIcon;

	public GameObject NoGamingIcon;

	public GameObject NoInfoIcon;

	public GameObject NoLaughIcon;

	public GameObject RivalsOnlyIcon;

	public Texture NewspaperIcon;

	public Texture YakuzaIcon;

	public UITexture GamingIcon;

	public UITexture InfoIcon;

	public bool KnifeOnly;

	public bool NoAlerts;

	public bool NoBag;

	public bool NoFriends;

	public bool NoGaming;

	public bool NoInfo;

	public bool NoLaugh;

	public bool RivalsOnly;

	public float ZoomInTimer;

	public float GameOverTimer;

	private void Start()
	{
		if (!GameGlobals.EightiesTutorial && !GameGlobals.KokonaTutorial)
		{
			KnifeOnly = ChallengeGlobals.KnifeOnly;
			NoAlerts = ChallengeGlobals.NoAlerts;
			NoBag = ChallengeGlobals.NoBag;
			NoFriends = ChallengeGlobals.NoFriends;
			NoGaming = ChallengeGlobals.NoGaming;
			NoInfo = ChallengeGlobals.NoInfo;
			NoLaugh = ChallengeGlobals.NoLaugh;
			RivalsOnly = ChallengeGlobals.RivalsOnly;
		}
		UpdateIcons();
	}

	private void Update()
	{
		if (!(Yandere != null))
		{
			return;
		}
		if (Yandere.CanMove && !Yandere.PauseScreen.Show)
		{
			if (KnifeOnly && StudentManager.Students[StudentManager.RivalID] != null && ((!StudentManager.Students[StudentManager.RivalID].Alive && !StudentManager.Students[StudentManager.RivalID].Stabbed) || StudentManager.StudentReps[StudentManager.RivalID] <= -100f || (StudentManager.RivalEliminated && !StudentManager.Students[StudentManager.RivalID].Stabbed) || StudentManager.Students[StudentManager.RivalID].Tranquil))
			{
				Debug.Log("Current rival is: " + StudentManager.Students[StudentManager.RivalID].Name);
				if (!StudentManager.Students[StudentManager.RivalID].Alive && !StudentManager.Students[StudentManager.RivalID].Stabbed)
				{
					Debug.Log("Rival is not alive and rival was not stabbed.");
				}
				if (StudentManager.StudentReps[StudentManager.RivalID] <= -100f)
				{
					Debug.Log("Rival's reputation is too low.");
				}
				if (StudentManager.RivalEliminated && !StudentManager.Students[StudentManager.RivalID].Stabbed)
				{
					Debug.Log("RivalEliminated is true and the rival is not stabbed.");
				}
				if (StudentManager.Students[StudentManager.RivalID].Tranquil)
				{
					Debug.Log("Rival is Tranquil.");
				}
				GameOver();
			}
			CountDownToGameOver();
		}
		if (((Yandere.CanMove && !Yandere.PauseScreen.Show) || (Yandere.Noticed && !Yandere.PauseScreen.Show)) && NoAlerts && (Yandere.Alerts > 0 || Yandere.Police.StudentFoundCorpse) && StudentToZoomInOn == null)
		{
			GameOverTimer = 5f;
			for (int i = 1; i < 101; i++)
			{
				if (StudentManager.Students[i] != null && StudentManager.Students[i].Alarmed && StudentManager.Students[i].Witnessed != 0)
				{
					Debug.Log("A student was alarmed by something.");
					StudentToZoomInOn = StudentManager.Students[i];
					StudentToZoomInOn.StudentID = 1;
					StudentToZoomInOn.Teacher = false;
					StudentToZoomInOn.Club = ClubType.None;
					StudentToZoomInOn.SenpaiNoticed();
					StudentToZoomInOn.CameraEffects.MurderWitnessed();
					StudentToZoomInOn.Stop = true;
					StudentToZoomInOn.CharacterAnimation.CrossFade(StudentToZoomInOn.ScaredAnim);
					ZoomInTimer = 1f;
				}
			}
		}
		if (StudentToZoomInOn != null)
		{
			Yandere.ShoulderCamera.GoingToCounselor = false;
			ZoomInTimer = Mathf.MoveTowards(ZoomInTimer, 0f, Time.deltaTime);
			if (ZoomInTimer == 0f)
			{
				Yandere.ShoulderCamera.enabled = true;
				Yandere.ShoulderCamera.Noticed = true;
				Yandere.RPGCamera.enabled = false;
				Heartbroken.ChallengeFailed = true;
			}
		}
	}

	public void CountDownToGameOver()
	{
		if (GameOverTimer > 0f)
		{
			GameOverTimer = Mathf.MoveTowards(GameOverTimer, 0f, Time.deltaTime);
			if (GameOverTimer == 0f)
			{
				GameOver();
			}
		}
	}

	public void GameOver()
	{
		Yandere.CharacterAnimation.CrossFade("f02_down_22");
		Yandere.Collapse = true;
		Yandere.CanMove = false;
		Heartbroken.transform.parent.gameObject.SetActive(value: true);
		Heartbroken.ChallengeFailed = true;
		Yandere.RPGCamera.ZeroEverything();
		Yandere.FixCamera();
		Yandere.RPGCamera.enabled = false;
		StudentManager.StopMoving();
	}

	private void UpdateIcons()
	{
		if (GameGlobals.Eighties)
		{
			GamingIcon.mainTexture = NewspaperIcon;
			InfoIcon.mainTexture = YakuzaIcon;
		}
		KnifeOnlyIcon.SetActive(KnifeOnly);
		NoAlertsIcon.SetActive(NoAlerts);
		NoBagIcon.SetActive(NoBag);
		NoFriendsIcon.SetActive(NoFriends);
		NoGamingIcon.SetActive(NoGaming);
		NoInfoIcon.SetActive(NoInfo);
		NoLaughIcon.SetActive(NoLaugh);
		RivalsOnlyIcon.SetActive(RivalsOnly);
	}
}
