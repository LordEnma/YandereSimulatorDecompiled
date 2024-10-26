using System;
using UnityEngine;

public class ClubManagerScript : MonoBehaviour
{
	public EmergencyShowerScript EmergencyShower;

	public ShoulderCameraScript ShoulderCamera;

	public StudentManagerScript StudentManager;

	public ComputerGamesScript ComputerGames;

	public BloodCleanerScript BloodCleaner;

	public RefrigeratorScript Refrigerator;

	public SchoolMangaScript SchoolManga;

	public ClubWindowScript ClubWindow;

	public TypewriterScript Typewriter;

	public ContainerScript Container;

	public PromptBarScript PromptBar;

	public TranqCaseScript TranqCase;

	public TrashCanScript WeaponBag;

	public FeedListScript FeedList;

	public GloveScript OccultRobe;

	public YandereScript Yandere;

	public RPG_Camera MainCamera;

	public PickUpScript Candle;

	public DoorScript ShedDoor;

	public PoliceScript Police;

	public GloveScript Gloves;

	public UISprite Darkness;

	public WoodChipperScript[] AcidVats;

	public AudioSource MyAudio;

	public GameObject Viewfinder;

	public GameObject Reputation;

	public GameObject Heartrate;

	public GameObject Watermark;

	public GameObject Padlock;

	public GameObject Ritual;

	public GameObject Clock;

	public GameObject Cake;

	public Transform[] EightiesClubPatrolPoints;

	public Transform[] ClubPatrolPoints;

	public Transform[] ClubVantages;

	public AudioClip[] MotivationalQuotes;

	public GameObject[] EightiesClubPosters;

	public GameObject[] ClubPosters;

	public GameObject[] GameScreens;

	public GameObject[] ClubStands;

	public MaskScript[] Masks;

	public GameObject[] Cultists;

	public Transform[] Club1ActivitySpots;

	public Transform[] Club4ActivitySpots;

	public Transform[] Club6ActivitySpots;

	public Transform Club7ActivitySpot;

	public Transform[] Club8ActivitySpots;

	public Transform[] Club10ActivitySpots;

	public int[] Club1Students;

	public int[] Club2Students;

	public int[] Club3Students;

	public int[] Club4Students;

	public int[] Club5Students;

	public int[] Club6Students;

	public int[] Club7Students;

	public int[] Club8Students;

	public int[] Club9Students;

	public int[] Club10Students;

	public int[] Club11Students;

	public int[] Club14Students;

	public int[] Club15Students;

	public bool ClubActivityReminder;

	public bool LeaderAshamed;

	public bool ClubEffect;

	public bool Eighties;

	public AudioClip OccultAmbience;

	public int ActivitiesAttended;

	public int ClubPhase;

	public int Phase = 1;

	public ClubType Club;

	public int ID;

	public float TimeLimit;

	public float Timer;

	public ClubType[] ClubArray;

	public bool[] ClubsKickedFrom;

	public bool[] QuitClub;

	public bool NoBag;

	public Transform ElightiesVantageLMC;

	public bool LeaderMissing;

	public bool LeaderDead;

	public int ClubMembers;

	public int[] Club1IDs;

	public int[] Club2IDs;

	public int[] Club3IDs;

	public int[] Club4IDs;

	public int[] Club5IDs;

	public int[] Club6IDs;

	public int[] Club7IDs;

	public int[] Club8IDs;

	public int[] Club9IDs;

	public int[] Club10IDs;

	public int[] Club11IDs;

	public int[] Club14IDs;

	public int[] Club15IDs;

	public int[] ClubIDs;

	public bool LeaderGrudge;

	public bool ClubGrudge;

	private void Start()
	{
		NoBag = ChallengeGlobals.NoBag;
		Eighties = GameGlobals.Eighties;
		if (!NoBag)
		{
			NoBag = DifficultyGlobals.NoCase;
		}
		LearnKickedClubs();
		ActivitiesAttended = ClubGlobals.ActivitiesAttended;
		MyAudio = GetComponent<AudioSource>();
		ClubWindow.ActivityWindow.localScale = Vector3.zero;
		ClubWindow.ActivityWindow.gameObject.SetActive(value: false);
		int num = 0;
		ID = 1;
		if (GameGlobals.Eighties)
		{
			ClubVantages[5] = ElightiesVantageLMC;
			ClubPatrolPoints = EightiesClubPatrolPoints;
			ClubPosters = EightiesClubPosters;
		}
		while (ID < ClubArray.Length)
		{
			if (ClubGlobals.GetClubClosed(ClubArray[ID]))
			{
				ClubPosters[ID].SetActive(value: false);
				if (ClubArray[ID] == ClubType.Gardening)
				{
					ClubPatrolPoints[ID].transform.position = new Vector3(-36f, ClubPatrolPoints[ID].transform.position.y, ClubPatrolPoints[ID].transform.position.z);
				}
				else if (ClubArray[ID] == ClubType.Gaming)
				{
					ClubPatrolPoints[ID].transform.position = new Vector3(20f, ClubPatrolPoints[ID].transform.position.y, ClubPatrolPoints[ID].transform.position.z);
				}
				else if (ClubArray[ID] != ClubType.Sports)
				{
					ClubPatrolPoints[ID].transform.position = new Vector3(ClubPatrolPoints[ID].transform.position.x, ClubPatrolPoints[ID].transform.position.y, 20f);
				}
				num++;
			}
			if (ClubGlobals.GetQuitClub(ClubArray[ID]))
			{
				QuitClub[ID] = true;
			}
			ID++;
		}
		if (num > 10)
		{
			StudentManager.NoClubMeeting = true;
		}
		if (ClubGlobals.GetClubClosed(ClubArray[2]))
		{
			StudentManager.HidingSpots.List[56] = StudentManager.Hangouts.List[56];
			StudentManager.HidingSpots.List[57] = StudentManager.Hangouts.List[57];
			StudentManager.HidingSpots.List[58] = StudentManager.Hangouts.List[58];
			StudentManager.HidingSpots.List[59] = StudentManager.Hangouts.List[59];
			StudentManager.HidingSpots.List[60] = StudentManager.Hangouts.List[60];
			StudentManager.SleuthPhase = 3;
		}
		ID = 0;
		EmergencyShower.Prompt.enabled = false;
		EmergencyShower.Prompt.Hide();
		if (!StudentManager.MissionMode)
		{
			AcidVats[1].Prompt.enabled = false;
			AcidVats[1].Prompt.Hide();
			AcidVats[2].Prompt.enabled = false;
			AcidVats[2].Prompt.Hide();
		}
		if (ClubGlobals.Club != 0 && DateGlobals.Weekday == DayOfWeek.Friday && ClubGlobals.ActivitiesAttended == 0)
		{
			ClubActivityReminder = true;
		}
		Physics.IgnoreCollision(Container.gameObject.GetComponent<Collider>(), Yandere.MyController);
	}

	private void Update()
	{
		if (Club != 0)
		{
			if (Phase == 1)
			{
				Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime));
			}
			if (Darkness.color.a < 0.0001f)
			{
				if (Phase == 1)
				{
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "Continue";
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
					ClubWindow.PerformingActivity = true;
					ClubWindow.ActivityWindow.gameObject.SetActive(value: true);
					ClubWindow.ActivityLabel.text = ClubWindow.ActivityDescs[(int)Club];
					StudentManager.Portal.GetComponent<PortalScript>().EndFinalEvents();
					ActivitiesAttended++;
					Debug.Log("Incremending ActivitiesAttended. That number is now " + ActivitiesAttended);
					Phase++;
				}
				else if (Phase == 2)
				{
					if (ClubWindow.ActivityWindow.localScale.x > 0.9f)
					{
						if (Club == ClubType.MartialArts)
						{
							if (ClubPhase == 0)
							{
								MyAudio.clip = MotivationalQuotes[UnityEngine.Random.Range(0, MotivationalQuotes.Length)];
								MyAudio.Play();
								ClubEffect = true;
								ClubPhase++;
								TimeLimit = MyAudio.clip.length;
							}
							else if (ClubPhase == 1)
							{
								Timer += Time.deltaTime;
								if (Timer > TimeLimit)
								{
									for (ID = 0; ID < Club6Students.Length; ID++)
									{
										if (StudentManager.Students[ID] != null && !StudentManager.Students[ID].Tranquil)
										{
											StudentManager.Students[Club6Students[ID]].GetComponent<AudioSource>().volume = 1f;
										}
									}
									ClubPhase++;
								}
							}
						}
						if (Input.GetButtonDown(InputNames.Xbox_A))
						{
							ClubWindow.PerformingActivity = false;
							PromptBar.Show = false;
							Phase++;
						}
					}
				}
				else if (ClubWindow.ActivityWindow.localScale.x < 0.1f)
				{
					StudentManager.Reputation.UpdateRep();
					Police.Darkness.enabled = true;
					Police.ClubActivity = false;
					Police.FadeOut = true;
				}
			}
			if (Club == ClubType.Occult)
			{
				MyAudio.volume = 1f - Darkness.color.a;
			}
		}
		if (ClubActivityReminder && StudentManager.Clock.HourTime >= 17f)
		{
			Yandere.NotificationManager.CustomText = "unless you attend a club activity today!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			Yandere.NotificationManager.CustomText = "You will be kicked out of the club you joined";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			Yandere.NotificationManager.CustomText = "You haven't attended club activities this week!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			ClubActivityReminder = false;
		}
	}

	public void ClubActivity()
	{
		Debug.Log("Now firing the ClubActivity() function.");
		Yandere.CameraEffects.UpdateDOF(2f);
		StudentManager.StopMoving();
		ShoulderCamera.enabled = false;
		if (StudentManager.MemorialScene.gameObject.activeInHierarchy)
		{
			ClubVantages[2].transform.position = new Vector3(-5.8f, 2.9f, 22.2f);
		}
		MainCamera.enabled = false;
		MainCamera.transform.position = ClubVantages[(int)Club].position;
		MainCamera.transform.rotation = ClubVantages[(int)Club].rotation;
		if (Club != ClubType.LightMusic)
		{
			StudentManager.PracticeMusic.gameObject.SetActive(value: false);
		}
		if (Club == ClubType.Cooking)
		{
			Cake.SetActive(value: true);
			for (ID = 0; ID < Club1Students.Length; ID++)
			{
				StudentScript studentScript = StudentManager.Students[Club1Students[ID]];
				if (studentScript != null && !studentScript.Tranquil && studentScript.Alive)
				{
					studentScript.transform.position = Club1ActivitySpots[ID].position;
					studentScript.transform.rotation = Club1ActivitySpots[ID].rotation;
					studentScript.CharacterAnimation[studentScript.SocialSitAnim].layer = 99;
					studentScript.CharacterAnimation.Play(studentScript.SocialSitAnim);
					studentScript.CharacterAnimation[studentScript.SocialSitAnim].weight = 1f;
					studentScript.SmartPhone.SetActive(value: false);
					studentScript.SpeechLines.Play();
					studentScript.ClubActivity = true;
					studentScript.Talking = false;
					studentScript.Routine = false;
					studentScript.GetComponent<AudioSource>().volume = 0.1f;
				}
			}
			Yandere.Talking = false;
			Yandere.CanMove = false;
			Yandere.ClubActivity = true;
			Yandere.CharacterAnimation.Play("f02_sit_00");
			Yandere.transform.position = Club1ActivitySpots[6].position;
			Yandere.transform.rotation = Club1ActivitySpots[6].rotation;
			if (Eighties)
			{
				Debug.Log("We're in the 80s.");
				if (StudentManager.Students[12] != null)
				{
					StudentManager.Students[12].transform.position = new Vector3(72f, 0f, 141.5f);
				}
			}
		}
		else if (Club == ClubType.Drama)
		{
			StudentManager.DramaPhase = 1;
			StudentManager.UpdateDrama();
			for (ID = 0; ID < Club2Students.Length; ID++)
			{
				StudentScript studentScript2 = StudentManager.Students[Club2Students[ID]];
				if (studentScript2 != null && !studentScript2.Tranquil && studentScript2.Alive)
				{
					if (!StudentManager.MemorialScene.gameObject.activeInHierarchy)
					{
						studentScript2.transform.position = studentScript2.CurrentDestination.position;
						studentScript2.transform.rotation = studentScript2.CurrentDestination.rotation;
					}
					studentScript2.ClubActivity = true;
					studentScript2.Talking = false;
					studentScript2.Routine = true;
					studentScript2.GetComponent<AudioSource>().volume = 0.1f;
				}
			}
			Yandere.Talking = false;
			Yandere.CanMove = false;
			Yandere.ClubActivity = true;
			if (!StudentManager.MemorialScene.gameObject.activeInHierarchy)
			{
				if (GameGlobals.Eighties && DateGlobals.Week == 4)
				{
					MainCamera.transform.position = new Vector3(20f, 4f, 65f);
					Yandere.transform.position = new Vector3(24.5f, 0f, 72f);
					Yandere.transform.eulerAngles = new Vector3(0f, 90f, 0f);
				}
				else
				{
					Yandere.transform.position = new Vector3(42f, 1.3775f, 72f);
					Yandere.transform.eulerAngles = new Vector3(0f, -90f, 0f);
				}
			}
		}
		else if (Club == ClubType.Occult)
		{
			for (ID = 0; ID < Club3Students.Length; ID++)
			{
				StudentScript studentScript3 = StudentManager.Students[Club3Students[ID]];
				if (studentScript3 != null && !studentScript3.Tranquil)
				{
					studentScript3.gameObject.SetActive(value: false);
				}
			}
			MainCamera.GetComponent<AudioListener>().enabled = true;
			AudioSource component = GetComponent<AudioSource>();
			component.clip = OccultAmbience;
			component.loop = true;
			component.volume = 0f;
			component.Play();
			Yandere.transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
			Ritual.SetActive(value: true);
			CheckClub(ClubType.Occult);
			GameObject[] cultists = Cultists;
			foreach (GameObject gameObject in cultists)
			{
				if (gameObject != null)
				{
					gameObject.SetActive(value: false);
				}
			}
			while (ClubMembers > 0)
			{
				Cultists[ClubMembers].SetActive(value: true);
				ClubMembers--;
			}
			CheckClub(ClubType.Occult);
		}
		else if (Club == ClubType.Art)
		{
			for (ID = 0; ID < Club4Students.Length; ID++)
			{
				StudentScript studentScript4 = StudentManager.Students[Club4Students[ID]];
				if (studentScript4 != null && !studentScript4.Tranquil && studentScript4.Alive)
				{
					studentScript4.transform.position = Club4ActivitySpots[ID].position;
					studentScript4.transform.rotation = Club4ActivitySpots[ID].rotation;
					studentScript4.ClubActivity = true;
					studentScript4.SpeechLines.Stop();
					studentScript4.Talking = false;
					studentScript4.Routine = true;
					if (!studentScript4.ClubAttire)
					{
						studentScript4.ChangeClubwear();
					}
				}
			}
			Yandere.Talking = false;
			Yandere.CanMove = false;
			Yandere.ClubActivity = true;
			Yandere.transform.position = Club4ActivitySpots[5].position;
			Yandere.transform.rotation = Club4ActivitySpots[5].rotation;
			if (!Yandere.ClubAttire)
			{
				Yandere.ChangeClubwear();
			}
		}
		else if (Club == ClubType.LightMusic)
		{
			Debug.Log("Teleporting musicians to the Light Music club.");
			for (ID = 0; ID < Club5Students.Length; ID++)
			{
				StudentScript studentScript5 = StudentManager.Students[Club5Students[ID]];
				if (studentScript5 != null && !studentScript5.Tranquil && studentScript5.Alive)
				{
					if (studentScript5.StudentID == 52)
					{
						studentScript5.ClubAnim = "f02_guitarPlayA_00";
					}
					else if (studentScript5.StudentID == 53)
					{
						studentScript5.ClubAnim = "f02_guitarPlayB_00";
					}
					else if (studentScript5.StudentID == 54)
					{
						studentScript5.ClubAnim = "f02_drumsPlay_00";
					}
					else if (studentScript5.StudentID == 55)
					{
						studentScript5.ClubAnim = "f02_keysPlay_00";
					}
					studentScript5.transform.position = studentScript5.StudentManager.Clubs.List[studentScript5.StudentID].position;
					studentScript5.transform.rotation = studentScript5.StudentManager.Clubs.List[studentScript5.StudentID].rotation;
					studentScript5.PlayMusicalInstrument();
					studentScript5.ClubActivity = false;
					studentScript5.Talking = false;
					studentScript5.Routine = true;
					studentScript5.Stop = false;
				}
			}
		}
		else if (Club == ClubType.MartialArts)
		{
			Debug.Log("Teleporting Martial Artists to the club.");
			for (ID = 0; ID < Club6Students.Length; ID++)
			{
				StudentScript studentScript6 = StudentManager.Students[Club6Students[ID]];
				if (studentScript6 != null && !studentScript6.Tranquil && studentScript6.Alive)
				{
					studentScript6.transform.position = Club6ActivitySpots[ID].position;
					studentScript6.transform.rotation = Club6ActivitySpots[ID].rotation;
					studentScript6.CharacterAnimation.enabled = true;
					studentScript6.CharacterAnimation.Play(studentScript6.ActivityAnim);
					studentScript6.ClubActivity = true;
					studentScript6.Routine = false;
					studentScript6.GetComponent<AudioSource>().volume = 0.1f;
					if (!studentScript6.ClubAttire)
					{
						studentScript6.ChangeClubwear();
					}
				}
			}
			Yandere.CanMove = false;
			Yandere.ClubActivity = true;
			Yandere.transform.position = Club6ActivitySpots[5].position;
			Yandere.transform.rotation = Club6ActivitySpots[5].rotation;
			if (!Yandere.ClubAttire)
			{
				Yandere.ChangeClubwear();
			}
		}
		else if (Club == ClubType.Photography)
		{
			for (ID = 0; ID < Club7Students.Length; ID++)
			{
				StudentScript studentScript7 = StudentManager.Students[Club7Students[ID]];
				if (studentScript7 != null && !studentScript7.Tranquil && studentScript7.Alive)
				{
					studentScript7.transform.position = StudentManager.Clubs.List[studentScript7.StudentID].position;
					studentScript7.transform.rotation = StudentManager.Clubs.List[studentScript7.StudentID].rotation;
					studentScript7.CharacterAnimation[studentScript7.SocialSitAnim].weight = 1f;
					studentScript7.SmartPhone.SetActive(value: false);
					studentScript7.ClubActivity = true;
					studentScript7.SpeechLines.Play();
					studentScript7.Talking = false;
					studentScript7.Routine = true;
					studentScript7.Hearts.Stop();
				}
			}
			Yandere.CanMove = false;
			Yandere.Talking = false;
			Yandere.ClubActivity = true;
			Yandere.transform.position = Club7ActivitySpot.position;
			Yandere.transform.rotation = Club7ActivitySpot.rotation;
			if (!Yandere.ClubAttire)
			{
				Yandere.ChangeClubwear();
			}
			Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
		}
		else if (Club == ClubType.Science)
		{
			for (ID = 0; ID < Club8Students.Length; ID++)
			{
				StudentScript studentScript8 = StudentManager.Students[Club8Students[ID]];
				if (studentScript8 != null && !studentScript8.Tranquil && studentScript8.Alive)
				{
					if (!Eighties)
					{
						studentScript8.transform.position = Club8ActivitySpots[ID].position;
						studentScript8.transform.rotation = Club8ActivitySpots[ID].rotation;
					}
					else
					{
						studentScript8.transform.position = StudentManager.Clubs.List[studentScript8.StudentID].position;
						studentScript8.transform.rotation = StudentManager.Clubs.List[studentScript8.StudentID].rotation;
						studentScript8.CharacterAnimation[studentScript8.ClubAnim].time = UnityEngine.Random.Range(0f, studentScript8.CharacterAnimation[studentScript8.ClubAnim].length);
						studentScript8.CharacterAnimation[studentScript8.ClubAnim].speed = UnityEngine.Random.Range(0.9f, 1.1f);
					}
					studentScript8.ClubActivity = true;
					studentScript8.Talking = false;
					studentScript8.Routine = true;
					if (!studentScript8.ClubAttire && !StudentManager.Eighties)
					{
						studentScript8.ChangeClubwear();
					}
				}
			}
			Yandere.Talking = false;
			Yandere.CanMove = false;
			Yandere.ClubActivity = true;
			if (!Eighties && !Yandere.ClubAttire)
			{
				Yandere.ChangeClubwear();
			}
		}
		else if (Club == ClubType.Sports)
		{
			for (ID = 0; ID < Club9Students.Length; ID++)
			{
				StudentScript studentScript9 = StudentManager.Students[Club9Students[ID]];
				if (studentScript9 != null && !studentScript9.Tranquil && studentScript9.Alive)
				{
					studentScript9.transform.position = studentScript9.CurrentDestination.position;
					studentScript9.transform.rotation = studentScript9.CurrentDestination.rotation;
					studentScript9.ClubActivity = true;
					studentScript9.Talking = false;
					studentScript9.Routine = true;
				}
			}
			Yandere.Talking = false;
			Yandere.CanMove = false;
			Yandere.ClubActivity = true;
			Yandere.Schoolwear = 2;
			Yandere.ChangeSchoolwear();
		}
		else if (Club == ClubType.Gardening)
		{
			for (ID = 0; ID < Club10Students.Length; ID++)
			{
				StudentScript studentScript10 = StudentManager.Students[Club10Students[ID]];
				if (studentScript10 != null && !studentScript10.Tranquil && studentScript10.Alive)
				{
					studentScript10.transform.position = studentScript10.CurrentDestination.position;
					studentScript10.transform.rotation = studentScript10.CurrentDestination.rotation;
					studentScript10.ClubActivity = true;
					studentScript10.Talking = false;
					studentScript10.Routine = true;
					studentScript10.GetComponent<AudioSource>().volume = 0.1f;
				}
			}
			Yandere.Talking = false;
			Yandere.CanMove = false;
			Yandere.ClubActivity = true;
			if (!Yandere.ClubAttire)
			{
				Yandere.ChangeClubwear();
			}
		}
		else if (Club == ClubType.Gaming)
		{
			for (ID = 0; ID < Club11Students.Length; ID++)
			{
				StudentScript studentScript11 = StudentManager.Students[Club11Students[ID]];
				if (studentScript11 != null && !studentScript11.Tranquil && studentScript11.Alive)
				{
					studentScript11.transform.position = studentScript11.CurrentDestination.position;
					studentScript11.transform.rotation = studentScript11.CurrentDestination.rotation;
					studentScript11.ClubManager.GameScreens[ID].SetActive(value: true);
					studentScript11.SmartPhone.SetActive(value: false);
					studentScript11.ClubActivity = true;
					studentScript11.Talking = false;
					studentScript11.Routine = false;
					studentScript11.GetComponent<AudioSource>().volume = 0.1f;
				}
			}
			Yandere.Talking = false;
			Yandere.CanMove = false;
			Yandere.ClubActivity = true;
			GameScreens[6].SetActive(value: true);
			Yandere.transform.position = StudentManager.ComputerGames.Chairs[1].transform.position;
			Yandere.transform.rotation = StudentManager.ComputerGames.Chairs[1].transform.rotation;
		}
		else if (Club == ClubType.Delinquent)
		{
			Debug.Log("Calling the Delinquent 'club activity'.");
			Yandere.transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
			for (ID = 0; ID < Club14Students.Length; ID++)
			{
				StudentScript studentScript12 = StudentManager.Students[Club14Students[ID]];
				if (studentScript12 != null && studentScript12.Alive)
				{
					Debug.Log("Telling a delinquent #" + studentScript12.StudentID + " to leave school.");
					studentScript12.Pathfinding.target = StudentManager.Exit;
					studentScript12.CurrentDestination = StudentManager.Exit;
					studentScript12.Pathfinding.canSearch = true;
					studentScript12.Pathfinding.canMove = true;
					studentScript12.Pathfinding.speed = 1f;
					studentScript12.DistanceToDestination = 100f;
					studentScript12.Talking = false;
					studentScript12.Stop = false;
				}
			}
		}
		else if (Club == ClubType.Newspaper)
		{
			Debug.Log("Displaying the newspaper club performing their club activity.");
			for (ID = 0; ID < Club15Students.Length; ID++)
			{
				StudentScript studentScript13 = StudentManager.Students[Club15Students[ID]];
				if (studentScript13 != null && !studentScript13.Tranquil && studentScript13.Alive)
				{
					studentScript13.transform.position = StudentManager.Clubs.List[studentScript13.StudentID].position;
					studentScript13.transform.rotation = StudentManager.Clubs.List[studentScript13.StudentID].rotation;
					studentScript13.ClubActivity = true;
					studentScript13.Talking = false;
					studentScript13.Routine = true;
				}
			}
			Yandere.Talking = false;
			Yandere.CanMove = false;
			Yandere.ClubActivity = true;
			if (!Yandere.ClubAttire)
			{
				Yandere.ChangeClubwear();
			}
		}
		Clock.SetActive(value: false);
		Reputation.SetActive(value: false);
		Heartrate.SetActive(value: false);
		Watermark.SetActive(value: false);
		Yandere.ClubActivity = true;
		Physics.SyncTransforms();
	}

	public void CheckClub(ClubType Check)
	{
		switch (Check)
		{
		case ClubType.Cooking:
			ClubIDs = Club1IDs;
			if (!GameGlobals.Eighties && StudentManager.Week > 1 && StudentManager.Students[12] != null)
			{
				int[] clubIDs = new int[6] { 21, 22, 23, 24, 25, 12 };
				ClubIDs = clubIDs;
			}
			break;
		case ClubType.Drama:
			ClubIDs = Club2IDs;
			break;
		case ClubType.Occult:
			ClubIDs = Club3IDs;
			break;
		case ClubType.Art:
			ClubIDs = Club4IDs;
			break;
		case ClubType.LightMusic:
			ClubIDs = Club5IDs;
			break;
		case ClubType.MartialArts:
			ClubIDs = Club6IDs;
			break;
		case ClubType.Photography:
			ClubIDs = Club7IDs;
			break;
		case ClubType.Science:
			ClubIDs = Club8IDs;
			break;
		case ClubType.Sports:
			ClubIDs = Club9IDs;
			break;
		case ClubType.Gardening:
			ClubIDs = Club10IDs;
			break;
		case ClubType.Gaming:
			ClubIDs = Club11IDs;
			if (StudentManager.Eighties)
			{
				return;
			}
			break;
		case ClubType.Newspaper:
			ClubIDs = Club15IDs;
			break;
		}
		LeaderMissing = false;
		LeaderDead = false;
		ClubMembers = 0;
		for (ID = 1; ID < ClubIDs.Length; ID++)
		{
			if (!StudentGlobals.GetStudentArrested(ClubIDs[ID]) && !StudentGlobals.GetStudentExpelled(ClubIDs[ID]) && StudentGlobals.GetStudentReputation(ClubIDs[ID]) > -100)
			{
				ClubMembers++;
			}
		}
		if (!Eighties && Check == ClubType.Cooking && StudentManager.Students[12] != null)
		{
			Debug.Log("Amai is at school, so the Cooking Club gains one extra member...");
			ClubMembers++;
		}
		if (TranqCase.VictimClubType == Check)
		{
			ClubMembers--;
			Debug.Log("Subtracting a clubmember because someone's in the tranq case.");
		}
		for (ID = 1; ID < ClubIDs.Length; ID++)
		{
			if (StudentManager.Students[ClubIDs[ID]] == null)
			{
				ClubMembers--;
				Debug.Log("Subtracting a clubmember because someone's not in the Student list.");
			}
			else if (!StudentManager.Students[ClubIDs[ID]].Alive)
			{
				ClubMembers--;
				Debug.Log("Subtracting a clubmember because someone's dead.");
			}
		}
		if (Yandere.Club == Check)
		{
			ClubMembers++;
		}
		if (Check == ClubType.LightMusic && ClubMembers < 5)
		{
			LeaderAshamed = true;
		}
		int num = 0;
		switch (Check)
		{
		case ClubType.Cooking:
			num = 21;
			if (!GameGlobals.Eighties && StudentManager.Week > 1 && StudentManager.Students[12] != null)
			{
				num = 12;
			}
			break;
		case ClubType.Drama:
			num = 26;
			break;
		case ClubType.Occult:
			num = 31;
			break;
		case ClubType.Gaming:
		case ClubType.Newspaper:
			num = 36;
			break;
		case ClubType.Art:
			num = 41;
			break;
		case ClubType.MartialArts:
			num = 46;
			break;
		case ClubType.LightMusic:
			num = 51;
			break;
		case ClubType.Photography:
			num = 56;
			break;
		case ClubType.Science:
			num = 61;
			break;
		case ClubType.Sports:
			num = 66;
			break;
		case ClubType.Gardening:
			num = 71;
			break;
		}
		if (StudentGlobals.GetStudentDead(num) || StudentGlobals.GetStudentDying(num) || StudentGlobals.GetStudentArrested(num) || StudentGlobals.GetStudentReputation(num) <= -100 || (StudentManager.Students[num] != null && !StudentManager.Students[num].Alive && !StudentManager.Students[num].Ragdoll.Disposed))
		{
			Debug.Log("A club leader is dead!");
			LeaderDead = true;
		}
		if (StudentGlobals.GetStudentMissing(num) || StudentGlobals.GetStudentKidnapped(num) || TranqCase.VictimID == num || (StudentManager.Students[num] != null && !StudentManager.Students[num].Alive && StudentManager.Students[num].Ragdoll.Disposed))
		{
			Debug.Log("A club leader is missing!");
			LeaderMissing = true;
		}
		if (!LeaderDead && !LeaderMissing && Check == ClubType.LightMusic && (double)StudentGlobals.GetStudentReputation(51) < -33.33333)
		{
			LeaderAshamed = true;
		}
	}

	public void CheckGrudge(ClubType Check)
	{
		switch (Check)
		{
		case ClubType.Cooking:
			ClubIDs = Club1IDs;
			break;
		case ClubType.Drama:
			ClubIDs = Club2IDs;
			break;
		case ClubType.Occult:
			ClubIDs = Club3IDs;
			break;
		case ClubType.Art:
			ClubIDs = Club4IDs;
			break;
		case ClubType.LightMusic:
			ClubIDs = Club5IDs;
			break;
		case ClubType.MartialArts:
			ClubIDs = Club6IDs;
			break;
		case ClubType.Photography:
			ClubIDs = Club7IDs;
			break;
		case ClubType.Science:
			ClubIDs = Club8IDs;
			break;
		case ClubType.Sports:
			ClubIDs = Club9IDs;
			break;
		case ClubType.Gardening:
			ClubIDs = Club10IDs;
			break;
		case ClubType.Gaming:
			ClubIDs = Club11IDs;
			break;
		case ClubType.Delinquent:
			ClubIDs = Club14IDs;
			break;
		case ClubType.Newspaper:
			ClubIDs = Club15IDs;
			break;
		}
		LeaderGrudge = false;
		ClubGrudge = false;
		for (ID = 1; ID < ClubIDs.Length; ID++)
		{
			if (StudentManager.Students[ClubIDs[ID]] != null && StudentGlobals.GetStudentGrudge(ClubIDs[ID]))
			{
				ClubGrudge = true;
			}
		}
		switch (Check)
		{
		case ClubType.Cooking:
			if (StudentManager.Students[21] != null && StudentManager.Students[21].Grudge)
			{
				LeaderGrudge = true;
			}
			break;
		case ClubType.Drama:
			if (StudentManager.Students[26] != null && StudentManager.Students[26].Grudge)
			{
				LeaderGrudge = true;
			}
			break;
		case ClubType.Occult:
			if (StudentManager.Students[31] != null && StudentManager.Students[31].Grudge)
			{
				LeaderGrudge = true;
			}
			break;
		case ClubType.Art:
			if (StudentManager.Students[41] != null && StudentManager.Students[41].Grudge)
			{
				LeaderGrudge = true;
			}
			break;
		case ClubType.MartialArts:
			if (StudentManager.Students[46] != null && StudentManager.Students[46].Grudge)
			{
				LeaderGrudge = true;
			}
			break;
		case ClubType.LightMusic:
			if (StudentManager.Students[51] != null && StudentManager.Students[51].Grudge)
			{
				LeaderGrudge = true;
			}
			break;
		case ClubType.Photography:
			if (StudentManager.Students[56] != null && StudentManager.Students[56].Grudge)
			{
				LeaderGrudge = true;
			}
			break;
		case ClubType.Science:
			if (StudentManager.Students[61] != null && StudentManager.Students[61].Grudge)
			{
				LeaderGrudge = true;
			}
			break;
		case ClubType.Sports:
			if (StudentManager.Students[66] != null && StudentManager.Students[66].Grudge)
			{
				LeaderGrudge = true;
			}
			break;
		case ClubType.Gardening:
			if (StudentManager.Students[71] != null && StudentManager.Students[71].Grudge)
			{
				LeaderGrudge = true;
			}
			break;
		case ClubType.Delinquent:
			if (StudentManager.Students[76] != null && StudentManager.Students[76].Grudge)
			{
				LeaderGrudge = true;
			}
			break;
		case ClubType.Gaming:
		case ClubType.Newspaper:
			if (StudentManager.Students[36] != null && StudentManager.Students[36].Grudge)
			{
				LeaderGrudge = true;
			}
			break;
		}
	}

	public void ActivateClubBenefit()
	{
		Yandere.WeaponManager.UpdateAllWeapons();
		if (Yandere.Club == ClubType.Cooking)
		{
			FeedList.enabled = true;
			FeedList.Prompt.enabled = true;
			FeedList.Prompt.Hide();
			if (!Refrigerator.CookingEvent.EventActive)
			{
				Refrigerator.enabled = true;
				Refrigerator.Prompt.enabled = true;
			}
		}
		else if (Yandere.Club == ClubType.Drama)
		{
			for (ID = 1; ID < Masks.Length; ID++)
			{
				Masks[ID].enabled = true;
				Masks[ID].Prompt.enabled = true;
			}
			Gloves.enabled = true;
			Gloves.Prompt.enabled = true;
		}
		else if (Yandere.Club == ClubType.Occult)
		{
			StudentManager.UpdatePerception();
			Candle.Suspicious = false;
			Yandere.UpdateNumbness();
			OccultRobe.enabled = true;
			OccultRobe.Prompt.enabled = true;
		}
		else if (Yandere.Club == ClubType.Art)
		{
			StudentManager.UpdateBooths();
		}
		else if (Yandere.Club == ClubType.LightMusic)
		{
			Container.enabled = true;
			Container.Prompt.enabled = true;
			if (NoBag)
			{
				WeaponBag.gameObject.SetActive(value: true);
				WeaponBag.AttachToBack();
			}
		}
		else if (Yandere.Club == ClubType.MartialArts)
		{
			StudentManager.UpdateBooths();
		}
		else if (Yandere.Club == ClubType.Photography)
		{
			if (StudentManager.Eighties)
			{
				Viewfinder.SetActive(value: true);
				return;
			}
			SchoolManga.enabled = true;
			SchoolManga.Prompt.enabled = true;
		}
		else if (Yandere.Club == ClubType.Science)
		{
			EmergencyShower.Prompt.enabled = true;
			BloodCleaner.Prompt.enabled = true;
			AcidVats[1].Prompt.enabled = true;
			AcidVats[2].Prompt.enabled = true;
			StudentManager.UpdateBooths();
		}
		else if (Yandere.Club == ClubType.Sports)
		{
			Yandere.ClubSpeedBonus = 1f;
			if (Yandere.Armed)
			{
				Yandere.EquippedWeapon.SuspicionCheck();
			}
		}
		else if (Yandere.Club == ClubType.Gardening)
		{
			ShedDoor.Prompt.Label[0].text = "     Open";
			Padlock.SetActive(value: false);
			ShedDoor.Locked = false;
			if (Yandere.Armed)
			{
				Yandere.EquippedWeapon.SuspicionCheck();
			}
		}
		else if (Yandere.Club == ClubType.Gaming)
		{
			ComputerGames.EnableGames();
		}
		else if (Yandere.Club == ClubType.Newspaper)
		{
			Typewriter.Prompt.enabled = true;
			Typewriter.enabled = true;
		}
		else if (Yandere.Club == ClubType.Delinquent && NoBag)
		{
			WeaponBag.gameObject.SetActive(value: true);
			WeaponBag.AttachToBack();
		}
	}

	public void DeactivateClubBenefit()
	{
		if (Yandere.Club == ClubType.Cooking)
		{
			FeedList.enabled = false;
			FeedList.Prompt.enabled = false;
			Refrigerator.enabled = false;
			Refrigerator.Prompt.Hide();
			Refrigerator.Prompt.enabled = false;
		}
		else if (Yandere.Club == ClubType.Drama)
		{
			for (ID = 1; ID < Masks.Length; ID++)
			{
				if (Masks[ID] != null)
				{
					Masks[ID].enabled = false;
					Masks[ID].Prompt.Hide();
					Masks[ID].Prompt.enabled = false;
				}
			}
			Gloves.enabled = false;
			Gloves.Prompt.Hide();
			Gloves.Prompt.enabled = false;
		}
		else if (Yandere.Club == ClubType.Occult)
		{
			Yandere.Club = ClubType.None;
			StudentManager.UpdatePerception();
			Yandere.UpdateNumbness();
			Candle.Suspicious = true;
			OccultRobe.enabled = false;
			OccultRobe.Prompt.Hide();
			OccultRobe.Prompt.enabled = false;
		}
		else
		{
			if (Yandere.Club == ClubType.Art)
			{
				return;
			}
			if (Yandere.Club == ClubType.LightMusic)
			{
				Container.enabled = false;
				Container.Prompt.Hide();
				Container.Prompt.enabled = false;
				if (NoBag && Yandere.Container != null)
				{
					Yandere.Container.Drop();
					WeaponBag.gameObject.SetActive(value: false);
				}
			}
			else
			{
				if (Yandere.Club == ClubType.MartialArts)
				{
					return;
				}
				if (Yandere.Club == ClubType.Photography)
				{
					if (StudentManager.Eighties)
					{
						Viewfinder.SetActive(value: false);
					}
					else
					{
						SchoolManga.Disable();
					}
				}
				else if (Yandere.Club == ClubType.Science)
				{
					EmergencyShower.Prompt.enabled = false;
					AcidVats[1].Prompt.enabled = false;
					AcidVats[2].Prompt.enabled = false;
					BloodCleaner.enabled = false;
					BloodCleaner.Prompt.Hide();
					BloodCleaner.Prompt.enabled = false;
				}
				else if (Yandere.Club == ClubType.Sports)
				{
					Yandere.ClubSpeedBonus = 0f;
					if (Yandere.Armed)
					{
						Yandere.Club = ClubType.None;
						Yandere.EquippedWeapon.SuspicionCheck();
					}
				}
				else if (Yandere.Club == ClubType.Gardening)
				{
					if (!Yandere.Inventory.ShedKey)
					{
						ShedDoor.Prompt.Label[0].text = "     Locked";
						Padlock.SetActive(value: true);
						ShedDoor.Locked = true;
						ShedDoor.CloseDoor();
					}
					if (Yandere.Armed)
					{
						Yandere.Club = ClubType.None;
						Yandere.EquippedWeapon.SuspicionCheck();
					}
				}
				else if (Yandere.Club == ClubType.Gaming)
				{
					ComputerGames.DeactivateAllBenefits();
					ComputerGames.DisableGames();
				}
				else if (Yandere.Club == ClubType.Newspaper)
				{
					Typewriter.Prompt.enabled = false;
					Typewriter.enabled = false;
					Typewriter.Prompt.Hide();
				}
				else if (Yandere.Club == ClubType.Delinquent && NoBag && Yandere.Container != null)
				{
					Yandere.Container.Drop();
					WeaponBag.gameObject.SetActive(value: false);
				}
			}
		}
	}

	public void UpdateMasks()
	{
		bool flag = Yandere.Mask != null;
		for (ID = 1; ID < Masks.Length; ID++)
		{
			Masks[ID].Prompt.HideButton[0] = flag;
		}
	}

	public void UpdateQuitClubs()
	{
		for (ID = 1; ID < ClubArray.Length; ID++)
		{
			if (QuitClub[ID] && !ClubGlobals.GetQuitClub(ClubArray[ID]))
			{
				Debug.Log("We quit a club on this day. ActivitiesAttended is now being set to 0.");
				ClubGlobals.SetQuitClub(ClubArray[ID], value: true);
				ActivitiesAttended = 0;
				if (Yandere.ClubActivity)
				{
					Debug.Log("...but we joined a new club after quitting, so we're incrementing ActivitiesAttended anyway!");
					ActivitiesAttended++;
				}
			}
		}
	}

	public void LearnKickedClubs()
	{
		for (ID = 1; ID < ClubArray.Length; ID++)
		{
			if (ClubGlobals.GetClubKicked(ClubArray[ID]))
			{
				Debug.Log("Because we were kicked from a club, ClubManager.ClubsKickedFrom is being updated.");
				ClubsKickedFrom[ID] = true;
			}
		}
	}

	public void UpdateKickedClubs()
	{
		for (ID = 1; ID < ClubArray.Length; ID++)
		{
			if (ClubsKickedFrom[ID])
			{
				Debug.Log("Because we were kicked from a club, ClubGlobals.SetClubKicked is being updated.");
				ClubGlobals.SetClubKicked(ClubArray[ID], value: true);
			}
		}
	}
}
