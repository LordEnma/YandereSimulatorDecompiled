using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugMenuScript : MonoBehaviour
{
	public FakeStudentSpawnerScript FakeStudentSpawner;

	public DelinquentManagerScript DelinquentManager;

	public StudentManagerScript StudentManager;

	public CameraEffectsScript CameraEffects;

	public WeaponManagerScript WeaponManager;

	public ReputationScript Reputation;

	public CounselorScript Counselor;

	public DebugConsole DebugConsole;

	public YandereScript Yandere;

	public BentoScript Bento;

	public ClockScript Clock;

	public PrayScript Turtle;

	public ZoomScript Zoom;

	public AstarPath Astar;

	public OsanaFridayBeforeClassEvent1Script OsanaEvent1;

	public OsanaFridayBeforeClassEvent2Script OsanaEvent2;

	public OsanaFridayLunchEventScript OsanaEvent3;

	public GameObject EasterEggWindow;

	public GameObject SacrificialArm;

	public GameObject DebugPoisons;

	public GameObject CircularSaw;

	public GameObject GreenScreen;

	public GameObject Knife;

	public Transform[] TeleportSpot;

	public Transform RooftopSpot;

	public Transform MidoriSpot;

	public Transform Lockers;

	public GameObject MissionModeWindow;

	public GameObject Window;

	public GameObject[] ElectrocutionKit;

	public bool WaitingForSabotage;

	public bool WaitingForNumber;

	public bool TryNextFrame;

	public bool MissionMode;

	public bool NoDebug;

	public int KidnappedVictim = 11;

	public int RooftopStudent = 7;

	public int DebugInputs;

	public float Timer;

	public int ID;

	public Texture PantyCensorTexture;

	private int DebugInt;

	public GameObject Mop;

	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 0f, base.transform.localPosition.z);
		MissionModeWindow.SetActive(value: false);
		Window.SetActive(value: false);
		MissionMode = true;
		NoDebug = true;
	}

	private void Update()
	{
		if (!MissionMode && !NoDebug)
		{
			if (!Yandere.InClass && !Yandere.Chased && Yandere.Chasers == 0 && Yandere.CanMove)
			{
				if (Input.GetKeyDown(KeyCode.Backslash) && Yandere.transform.position.y < 100f)
				{
					EasterEggWindow.SetActive(value: false);
					Window.SetActive(!Window.activeInHierarchy);
				}
			}
			else if (Window.activeInHierarchy)
			{
				Window.SetActive(value: false);
			}
			if (Window.activeInHierarchy)
			{
				if (Input.GetKeyDown(KeyCode.F1))
				{
					StudentGlobals.FemaleUniform = 1;
					StudentGlobals.MaleUniform = 1;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F2))
				{
					StudentGlobals.FemaleUniform = 2;
					StudentGlobals.MaleUniform = 2;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F3))
				{
					StudentGlobals.FemaleUniform = 3;
					StudentGlobals.MaleUniform = 3;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F4))
				{
					StudentGlobals.FemaleUniform = 4;
					StudentGlobals.MaleUniform = 4;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F5))
				{
					StudentGlobals.FemaleUniform = 5;
					StudentGlobals.MaleUniform = 5;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F6))
				{
					StudentGlobals.FemaleUniform = 6;
					StudentGlobals.MaleUniform = 6;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F7))
				{
					for (ID = 1; ID < 8; ID++)
					{
						StudentManager.DrinkingFountains[ID].PowerSwitch.PowerOutlet.SabotagedOutlet.SetActive(value: true);
						StudentManager.DrinkingFountains[ID].Puddle.SetActive(value: true);
					}
					Window.SetActive(value: false);
				}
				else if (Input.GetKeyDown(KeyCode.F8))
				{
					GameGlobals.CensorBlood = !GameGlobals.CensorBlood;
					WeaponManager.ChangeBloodTexture();
					Yandere.Bloodiness += 0f;
					Window.SetActive(value: false);
				}
				else if (Input.GetKeyDown(KeyCode.F9))
				{
					GameGlobals.CensorKillingAnims = !GameGlobals.CensorKillingAnims;
					Yandere.AttackManager.Censor = !Yandere.AttackManager.Censor;
					Window.SetActive(value: false);
				}
				else if (Input.GetKeyDown(KeyCode.F10))
				{
					StudentManager.Students[21].Attempts = 101;
					StudentManager.Students[22].Attempts = 101;
					StudentManager.Students[23].Attempts = 101;
					StudentManager.Students[24].Attempts = 101;
					StudentManager.Students[25].Attempts = 101;
					Window.SetActive(value: false);
				}
				else if (Input.GetKeyDown(KeyCode.F11))
				{
					DatingGlobals.RivalSabotaged = 5;
					DateGlobals.Weekday = DayOfWeek.Friday;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (!Input.GetKeyDown(KeyCode.F12))
				{
					if (Input.GetKeyDown(KeyCode.Alpha1))
					{
						DateGlobals.Weekday = DayOfWeek.Monday;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Alpha2))
					{
						DateGlobals.Weekday = DayOfWeek.Tuesday;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Alpha3))
					{
						DateGlobals.Weekday = DayOfWeek.Wednesday;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Alpha4))
					{
						DateGlobals.Weekday = DayOfWeek.Thursday;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Alpha5))
					{
						DateGlobals.Weekday = DayOfWeek.Friday;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Alpha6))
					{
						Yandere.DebugTimer = 1f;
						Yandere.transform.position = TeleportSpot[1].position;
						if (Yandere.Followers > 0)
						{
							Yandere.Follower.transform.position = Yandere.transform.position;
						}
						Physics.SyncTransforms();
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.Alpha7))
					{
						Yandere.transform.position = TeleportSpot[2].position + new Vector3(0.75f, 0f, 0f);
						if (Yandere.Followers > 0)
						{
							Yandere.Follower.transform.position = Yandere.transform.position;
						}
						Physics.SyncTransforms();
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.Alpha8))
					{
						Yandere.transform.position = TeleportSpot[3].position;
						if (Yandere.Followers > 0)
						{
							Yandere.Follower.transform.position = Yandere.transform.position;
						}
						Physics.SyncTransforms();
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.Alpha9))
					{
						Yandere.transform.position = TeleportSpot[4].position;
						if (Yandere.Followers > 0)
						{
							Yandere.Follower.transform.position = Yandere.transform.position;
						}
						StudentScript studentScript = StudentManager.Students[39];
						if (studentScript != null)
						{
							studentScript.ShoeRemoval.Start();
							studentScript.ShoeRemoval.PutOnShoes();
							studentScript.Phase = 2;
							studentScript.ScheduleBlocks[2].action = "Stand";
							studentScript.GetDestinations();
							studentScript.CurrentDestination = MidoriSpot;
							studentScript.Pathfinding.target = MidoriSpot;
							studentScript.transform.position = MidoriSpot.position;
						}
						Window.SetActive(value: false);
						Physics.SyncTransforms();
					}
					else if (Input.GetKeyDown(KeyCode.Alpha0))
					{
						Yandere.transform.position = TeleportSpot[11].position;
						if (Yandere.Followers > 0)
						{
							Yandere.Follower.transform.position = Yandere.transform.position;
						}
						Window.SetActive(value: false);
						Physics.SyncTransforms();
					}
					else if (Input.GetKeyDown(KeyCode.A))
					{
						if (SchoolAtmosphere.Type == SchoolAtmosphereType.High)
						{
							SchoolGlobals.SchoolAtmosphere = 0.5f;
						}
						else if (SchoolAtmosphere.Type == SchoolAtmosphereType.Medium)
						{
							SchoolGlobals.SchoolAtmosphere = 0f;
						}
						else
						{
							SchoolGlobals.SchoolAtmosphere = 1f;
						}
						SchoolGlobals.PreviousSchoolAtmosphere = SchoolGlobals.SchoolAtmosphere;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.C))
					{
						for (ID = 1; ID < 11; ID++)
						{
							CollectibleGlobals.SetTapeCollected(ID, value: true);
							StudentManager.TapesCollected[ID] = true;
						}
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.D))
					{
						for (ID = 0; ID < 5; ID++)
						{
							StudentScript studentScript2 = StudentManager.Students[76 + ID];
							if (studentScript2 != null)
							{
								if (studentScript2.Phase < 2)
								{
									studentScript2.ShoeRemoval.Start();
									studentScript2.ShoeRemoval.PutOnShoes();
									studentScript2.Phase = 2;
									studentScript2.CurrentDestination = studentScript2.Destinations[2];
									studentScript2.Pathfinding.target = studentScript2.Destinations[2];
								}
								studentScript2.transform.position = studentScript2.Destinations[2].position;
							}
						}
						Physics.SyncTransforms();
						Window.SetActive(value: false);
						CounselorGlobals.CounselorTape = 1;
						CounselorGlobals.DelinquentPunishments = 5;
					}
					else if (Input.GetKeyDown(KeyCode.F))
					{
						GreenScreen.SetActive(value: true);
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.G))
					{
						StudentScript studentScript3 = StudentManager.Students[RooftopStudent];
						PlayerGlobals.SetStudentFriend(RooftopStudent, value: true);
						StudentManager.Students[RooftopStudent].Friend = true;
						Yandere.transform.position = RooftopSpot.position + new Vector3(1f, 0f, 0f);
						WeaponManager.Weapons[6].transform.position = Yandere.transform.position + new Vector3(0f, 0f, 1.915f);
						if (studentScript3 != null)
						{
							StudentManager.OsanaOfferHelp.UpdateLocation();
							StudentManager.OsanaOfferHelp.enabled = true;
							StudentManager.NoteWindow.MeetID = 9;
							if (!studentScript3.Indoors)
							{
								if (studentScript3.ShoeRemoval.Locker == null)
								{
									studentScript3.ShoeRemoval.Start();
								}
								studentScript3.ShoeRemoval.PutOnShoes();
							}
							studentScript3.CharacterAnimation.Play(studentScript3.IdleAnim);
							studentScript3.transform.position = RooftopSpot.position;
							studentScript3.transform.rotation = RooftopSpot.rotation;
							studentScript3.Prompt.Label[0].text = "     Push";
							studentScript3.CurrentDestination = RooftopSpot;
							studentScript3.Pathfinding.target = RooftopSpot;
							studentScript3.Pathfinding.canSearch = false;
							studentScript3.Pathfinding.canMove = false;
							studentScript3.SpeechLines.Stop();
							studentScript3.Pushable = true;
							studentScript3.Routine = false;
							studentScript3.Meeting = true;
							studentScript3.MeetTime = 0f;
						}
						if (Clock.HourTime < 7.1f)
						{
							Clock.PresentTime = 426f;
						}
						Physics.SyncTransforms();
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.K))
					{
						StudentGlobals.Prisoner1 = KidnappedVictim;
						StudentGlobals.StudentSlave = KidnappedVictim;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.L))
					{
						DatingGlobals.Affection = 100f;
						DateGlobals.Weekday = DayOfWeek.Friday;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.M))
					{
						PlayerGlobals.Money = 100f;
						Yandere.Inventory.Money = 100f;
						Yandere.Inventory.UpdateMoney();
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.O))
					{
						Yandere.Inventory.RivalPhone = true;
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.P))
					{
						for (ID = 2; ID < 93; ID++)
						{
							StudentScript studentScript4 = StudentManager.Students[ID];
							if (studentScript4 != null)
							{
								studentScript4.Patience = 999;
								studentScript4.Pestered = -999;
								studentScript4.Ignoring = false;
							}
						}
						Yandere.Inventory.PantyShots += 20;
						PlayerGlobals.PantyShots += 20;
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.Q))
					{
						Censor();
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.R))
					{
						Debug.Log("Attempting to update reputation.");
						if (PlayerGlobals.Reputation == -100f)
						{
							PlayerGlobals.Reputation = -66.66666f;
						}
						else if (PlayerGlobals.Reputation == -66.66666f)
						{
							PlayerGlobals.Reputation = 0f;
						}
						else if (PlayerGlobals.Reputation == 0f)
						{
							PlayerGlobals.Reputation = 66.66666f;
						}
						else if (PlayerGlobals.Reputation == 66.66666f)
						{
							PlayerGlobals.Reputation = 100f;
						}
						else if (PlayerGlobals.Reputation == 100f)
						{
							PlayerGlobals.Reputation = -100f;
						}
						else
						{
							PlayerGlobals.Reputation = 0f;
						}
						Reputation.PreviousRep = 999f;
						Reputation.PendingRep = PlayerGlobals.Reputation;
						Reputation.UpdateRep();
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.S))
					{
						Yandere.Class.PhysicalGrade = 5;
						Yandere.Class.Seduction = 5;
						ClassGlobals.PsychologyGrade = 5;
						StudentManager.Police.UpdateCorpses();
						for (ID = 1; ID < 101; ID++)
						{
							StudentGlobals.SetStudentPhotographed(ID, value: true);
							StudentManager.StudentPhotographed[ID] = true;
							if (StudentManager.Students[ID] != null)
							{
								StudentManager.Students[ID].Friend = true;
							}
						}
						StudentManager.Students[46].Friend = false;
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.T))
					{
						Zoom.OverShoulder = !Zoom.OverShoulder;
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.U))
					{
						PlayerGlobals.SetStudentFriend(StudentManager.SuitorID, value: true);
						PlayerGlobals.SetStudentFriend(StudentManager.RivalID, value: true);
						StudentManager.Students[StudentManager.SuitorID].Friend = true;
						StudentManager.Students[StudentManager.RivalID].Friend = true;
						for (ID = 1; ID < 26; ID++)
						{
							ConversationGlobals.SetTopicDiscovered(ID, value: true);
							StudentManager.SetTopicLearnedByStudent(ID, StudentManager.RivalID, boolean: true);
						}
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.Z))
					{
						Yandere.Police.Invalid = true;
						if (Input.GetKey(KeyCode.LeftShift))
						{
							for (ID = 2; ID < 93; ID++)
							{
								_ = StudentManager.Students[ID] != null;
							}
						}
						else
						{
							Debug.Log("Killing all students now.");
							for (ID = 2; ID < 101; ID++)
							{
								StudentScript studentScript5 = StudentManager.Students[ID];
								if (studentScript5 != null)
								{
									studentScript5.SpawnAlarmDisc();
									studentScript5.BecomeRagdoll();
									studentScript5.DeathType = DeathType.EasterEgg;
								}
							}
						}
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.X))
					{
						TaskGlobals.SetTaskStatus(36, 3);
						SchoolGlobals.ReactedToGameLeader = false;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Backspace))
					{
						Time.timeScale = 1f;
						Clock.PresentTime = 1079f;
						Clock.HourTime = Clock.PresentTime / 60f;
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.BackQuote))
					{
						bool debug = GameGlobals.Debug;
						bool eighties = GameGlobals.Eighties;
						Globals.DeleteAll();
						GameGlobals.Debug = debug;
						GameGlobals.Eighties = eighties;
						StudentGlobals.FemaleUniform = 6;
						StudentGlobals.MaleUniform = 6;
						for (int i = 1; i < 101; i++)
						{
							StudentGlobals.SetStudentPhotographed(i, value: true);
						}
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Space))
					{
						Yandere.transform.position = TeleportSpot[5].position;
						if (Yandere.Follower != null)
						{
							Yandere.Follower.transform.position = Yandere.transform.position;
						}
						for (int j = 46; j < 51; j++)
						{
							if (!(StudentManager.Students[j] != null))
							{
								continue;
							}
							StudentManager.Students[j].transform.position = TeleportSpot[5].position;
							if (!StudentManager.Students[j].Indoors)
							{
								if (StudentManager.Students[j].ShoeRemoval.Locker == null)
								{
									StudentManager.Students[j].ShoeRemoval.Start();
								}
								StudentManager.Students[j].ShoeRemoval.PutOnShoes();
							}
						}
						Clock.PresentTime = 1015f;
						Clock.HourTime = Clock.PresentTime / 60f;
						Window.SetActive(value: false);
						OsanaEvent1.enabled = false;
						OsanaEvent2.enabled = false;
						OsanaEvent3.enabled = false;
						Physics.SyncTransforms();
					}
					else if (Input.GetKeyDown(KeyCode.LeftAlt))
					{
						Turtle.SpawnWeapons();
						Yandere.transform.position = TeleportSpot[6].position;
						if (Yandere.Follower != null)
						{
							Yandere.Follower.transform.position = Yandere.transform.position;
						}
						Clock.PresentTime = 425f;
						Clock.HourTime = Clock.PresentTime / 60f;
						Physics.SyncTransforms();
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.LeftControl))
					{
						Yandere.transform.position = TeleportSpot[7].position;
						if (Yandere.Follower != null)
						{
							Yandere.Follower.transform.position = Yandere.transform.position;
						}
						Physics.SyncTransforms();
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.RightControl))
					{
						Yandere.transform.position = TeleportSpot[8].position;
						if (Yandere.Follower != null)
						{
							Yandere.Follower.transform.position = Yandere.transform.position;
						}
						Physics.SyncTransforms();
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.Equals))
					{
						Clock.PresentTime += 10f;
						Window.SetActive(value: false);
					}
					else if (!Input.GetKeyDown(KeyCode.Return))
					{
						if (Input.GetKeyDown(KeyCode.B))
						{
							Yandere.Inventory.Headset = true;
							StudentManager.LoveManager.SuitorProgress = 1;
							DatingGlobals.SuitorProgress = 1;
							PlayerGlobals.SetStudentFriend(6, value: true);
							PlayerGlobals.SetStudentFriend(11, value: true);
							StudentManager.Students[6].Friend = true;
							StudentManager.Students[11].Friend = true;
							for (int k = 0; k < 11; k++)
							{
								DatingGlobals.SetComplimentGiven(k, value: false);
							}
							for (ID = 1; ID < 26; ID++)
							{
								ConversationGlobals.SetTopicDiscovered(ID, value: true);
								StudentManager.SetTopicLearnedByStudent(ID, 11, boolean: true);
							}
							StudentScript studentScript6 = StudentManager.Students[11];
							if (studentScript6 != null)
							{
								studentScript6.ShoeRemoval.Start();
								studentScript6.ShoeRemoval.PutOnShoes();
								studentScript6.CanTalk = true;
								studentScript6.Phase = 2;
								studentScript6.Pestered = 0;
								studentScript6.Patience = 999;
								studentScript6.Ignoring = false;
								studentScript6.CurrentDestination = studentScript6.Destinations[2];
								studentScript6.Pathfinding.target = studentScript6.Destinations[2];
								studentScript6.transform.position = studentScript6.Destinations[2].position;
							}
							StudentScript studentScript7 = StudentManager.Students[6];
							if (studentScript7 != null)
							{
								studentScript7.ShoeRemoval.Start();
								studentScript7.ShoeRemoval.PutOnShoes();
								studentScript7.Phase = 2;
								studentScript7.Pestered = 0;
								studentScript7.Patience = 999;
								studentScript7.Ignoring = false;
								studentScript7.CurrentDestination = studentScript7.Destinations[2];
								studentScript7.Pathfinding.target = studentScript7.Destinations[2];
								studentScript7.transform.position = studentScript7.Destinations[2].position;
							}
							_ = StudentManager.Students[10];
							if (studentScript7 != null)
							{
								studentScript7.transform.position = studentScript6.transform.position;
							}
							CollectibleGlobals.SetGiftPurchased(6, value: true);
							CollectibleGlobals.SetGiftPurchased(7, value: true);
							CollectibleGlobals.SetGiftPurchased(8, value: true);
							CollectibleGlobals.SetGiftPurchased(9, value: true);
							Physics.SyncTransforms();
							Window.SetActive(value: false);
						}
						else if (Input.GetKeyDown(KeyCode.Pause))
						{
							Clock.StopTime = !Clock.StopTime;
							Window.SetActive(value: false);
						}
						else if (Input.GetKeyDown(KeyCode.W))
						{
							DateGlobals.Week++;
							SceneManager.LoadScene("LoadingScene");
						}
						else if (Input.GetKeyDown(KeyCode.H))
						{
							StudentGlobals.FragileSlave = 5;
							StudentGlobals.FragileTarget = 10;
							StudentGlobals.Prisoner1 = KidnappedVictim;
							StudentGlobals.StudentSlave = KidnappedVictim;
							SceneManager.LoadScene("LoadingScene");
						}
						else if (Input.GetKeyDown(KeyCode.I))
						{
							StudentManager.Students[3].BecomeRagdoll();
							WeaponManager.Weapons[1].Blood.enabled = true;
							WeaponManager.Weapons[1].FingerprintID = 2;
							WeaponManager.Weapons[1].Victims[3] = true;
							StudentManager.Students[5].BecomeRagdoll();
							WeaponManager.Weapons[2].Blood.enabled = true;
							WeaponManager.Weapons[2].FingerprintID = 4;
							WeaponManager.Weapons[2].Victims[5] = true;
						}
						else if (!Input.GetKeyDown(KeyCode.J))
						{
							if (Input.GetKeyDown(KeyCode.V))
							{
								WaitingForSabotage = true;
								Window.SetActive(value: false);
							}
							else if (Input.GetKeyDown(KeyCode.N))
							{
								ElectrocutionKit[0].transform.position = Yandere.transform.position;
								ElectrocutionKit[1].transform.position = Yandere.transform.position;
								ElectrocutionKit[2].transform.position = Yandere.transform.position;
								ElectrocutionKit[3].transform.position = Yandere.transform.position;
								ElectrocutionKit[3].SetActive(value: true);
							}
						}
					}
				}
				if (Input.GetKeyDown(KeyCode.Tab))
				{
					DatingGlobals.Affection = 100f;
					DatingGlobals.SuitorProgress = 2;
					DateGlobals.Weekday = DayOfWeek.Friday;
					SceneManager.LoadScene("LoadingScene");
				}
				if (Input.GetKeyDown(KeyCode.CapsLock))
				{
					Debug.Log("The rival should be confessing to the suitor at the end of the day.");
					StudentManager.LoveManager.ConfessToSuitor = true;
				}
			}
			else
			{
				if (Input.GetKey(KeyCode.BackQuote))
				{
					Timer += Time.deltaTime;
					if (Timer > 1f)
					{
						for (ID = 0; ID < StudentManager.NPCsTotal; ID++)
						{
							if (StudentGlobals.GetStudentDying(ID))
							{
								StudentGlobals.SetStudentDying(ID, value: false);
							}
						}
						SceneManager.LoadScene("LoadingScene");
					}
				}
				if (Input.GetKeyUp(KeyCode.BackQuote))
				{
					Timer = 0f;
				}
			}
			if (TryNextFrame)
			{
				UpdateCensor();
			}
		}
		else
		{
			Input.GetKeyDown(KeyCode.Backslash);
		}
		if (WaitingForNumber)
		{
			if (Input.GetKey("1"))
			{
				Debug.Log("Going to class should trigger panty shot lecture.");
				if (!StudentManager.Eighties)
				{
					SchemeGlobals.SetSchemeStage(1, 100);
				}
				StudentGlobals.ExpelProgress = 0;
				Counselor.CutsceneManager.Scheme = 1;
				Counselor.LectureID = 1;
				WaitingForNumber = false;
			}
			else if (Input.GetKey("2"))
			{
				Debug.Log("Going to class should trigger theft lecture.");
				if (!StudentManager.Eighties)
				{
					SchemeGlobals.SetSchemeStage(2, 100);
				}
				StudentGlobals.ExpelProgress = 1;
				Counselor.CutsceneManager.Scheme = 2;
				Counselor.LectureID = 2;
				WaitingForNumber = false;
			}
			else if (Input.GetKey("3"))
			{
				Debug.Log("Going to class should trigger contraband lecture.");
				if (!StudentManager.Eighties)
				{
					SchemeGlobals.SetSchemeStage(3, 100);
				}
				StudentGlobals.ExpelProgress = 2;
				Counselor.CutsceneManager.Scheme = 3;
				Counselor.LectureID = 3;
				WaitingForNumber = false;
			}
			else if (Input.GetKey("4"))
			{
				Debug.Log("Going to class should trigger Vandalism lecture.");
				if (!StudentManager.Eighties)
				{
					SchemeGlobals.SetSchemeStage(4, 100);
				}
				StudentGlobals.ExpelProgress = 3;
				Counselor.CutsceneManager.Scheme = 4;
				Counselor.LectureID = 4;
				WaitingForNumber = false;
			}
			else if (Input.GetKey("5"))
			{
				Debug.Log("Going to class at lunchtime should get your rival expelled!");
				if (!StudentManager.Eighties)
				{
					SchemeGlobals.SetSchemeStage(5, 100);
				}
				Counselor.RivalExpelProgress = 4;
				StudentGlobals.ExpelProgress = 4;
				Counselor.CutsceneManager.Scheme = 5;
				Counselor.LectureID = 5;
				WaitingForNumber = false;
			}
		}
		if (WaitingForSabotage)
		{
			if (Input.GetKey("1"))
			{
				Debug.Log("Sabotage Progress = 1/5");
				DatingGlobals.RivalSabotaged = 1;
				WaitingForSabotage = false;
			}
			else if (Input.GetKey("2"))
			{
				Debug.Log("Sabotage Progress = 2/5");
				DatingGlobals.RivalSabotaged = 2;
				WaitingForSabotage = false;
			}
			else if (Input.GetKey("3"))
			{
				Debug.Log("Sabotage Progress = 3/5");
				DatingGlobals.RivalSabotaged = 3;
				WaitingForSabotage = false;
			}
			else if (Input.GetKey("4"))
			{
				Debug.Log("Sabotage Progress = 4/5");
				DatingGlobals.RivalSabotaged = 4;
				WaitingForSabotage = false;
			}
			else if (Input.GetKey("5"))
			{
				Debug.Log("Sabotage Progress = 5/5");
				DatingGlobals.RivalSabotaged = 5;
				WaitingForSabotage = false;
			}
		}
	}

	public void Censor()
	{
		if (GameGlobals.CensorPanties)
		{
			if (Yandere.Schoolwear == 1)
			{
				if (!Yandere.Sans && !Yandere.SithLord && !Yandere.BanchoActive)
				{
					if (!Yandere.FlameDemonic && !Yandere.TornadoHair.activeInHierarchy)
					{
						Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 1f);
						Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 1f);
						Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
						Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
						if (Yandere.PantyAttacher.newRenderer != null)
						{
							Yandere.PantyAttacher.newRenderer.enabled = false;
						}
					}
					else
					{
						Debug.Log("This block of code activated a shadow.");
						Yandere.MyRenderer.materials[2].SetTexture("_OverlayTex", PantyCensorTexture);
						Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
						Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
						Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
					}
				}
				else
				{
					Yandere.PantyAttacher.newRenderer.enabled = false;
				}
			}
			if (Yandere.MiyukiCostume.activeInHierarchy || Yandere.Rain.activeInHierarchy)
			{
				Yandere.PantyAttacher.newRenderer.enabled = false;
				Yandere.MyRenderer.materials[1].SetTexture("_OverlayTex", PantyCensorTexture);
				Yandere.MyRenderer.materials[2].SetTexture("_OverlayTex", PantyCensorTexture);
				Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
				Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 1f);
				Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount1", 1f);
			}
			if (Yandere.NierCostume.activeInHierarchy || Yandere.MyRenderer.sharedMesh == Yandere.NudeMesh || Yandere.MyRenderer.sharedMesh == Yandere.SchoolSwimsuit || Yandere.WearingRaincoat)
			{
				EasterEggCheck();
			}
			StudentManager.CensorStudents();
			return;
		}
		Debug.Log("The panty censor is turning OFF.");
		Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
		Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
		if (Yandere.MyRenderer.sharedMesh != Yandere.NudeMesh && Yandere.MyRenderer.sharedMesh != Yandere.SchoolSwimsuit)
		{
			Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
			Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			if (Yandere.Schoolwear == 1)
			{
				Yandere.PantyAttacher.newRenderer.enabled = true;
			}
			else
			{
				Yandere.PantyAttacher.newRenderer.enabled = false;
			}
			if (Yandere.MyRenderer.sharedMesh == Yandere.Uniforms[2])
			{
				Debug.Log("Long-sleeved school uniform. Changing which variable get set to 0.");
				Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
			}
			EasterEggCheck();
		}
		else
		{
			Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
			Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			Yandere.PantyAttacher.newRenderer.enabled = false;
			EasterEggCheck();
		}
		if (Yandere.MiyukiCostume.activeInHierarchy)
		{
			Yandere.PantyAttacher.newRenderer.enabled = false;
		}
		StudentManager.CensorStudents();
	}

	public void EasterEggCheck()
	{
		Debug.Log("Checking for easter eggs.");
		if (Yandere.BanchoActive || Yandere.Sans || (Yandere.RaincoatAttacher.newRenderer != null && Yandere.RaincoatAttacher.newRenderer.enabled) || Yandere.KLKSword.activeInHierarchy || Yandere.Gazing || Yandere.Ninja || Yandere.ClubAttire || Yandere.LifeNotebook.activeInHierarchy || Yandere.FalconHelmet.activeInHierarchy || Yandere.WearingRaincoat || Yandere.MyRenderer.sharedMesh == Yandere.NudeMesh || Yandere.MyRenderer.sharedMesh == Yandere.SchoolSwimsuit)
		{
			Debug.Log("A pants-wearing easter egg is active, so we're going to disable all shadows and panties.");
			Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
			Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
			Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
			Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
			Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount1", 0f);
			Yandere.PantyAttacher.newRenderer.enabled = false;
		}
		if (Yandere.FlameDemonic || Yandere.TornadoHair.activeInHierarchy)
		{
			Debug.Log("This other block of code activated a shadow.");
			Yandere.MyRenderer.materials[1].SetTexture("_OverlayTex", PantyCensorTexture);
			Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
			Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
			Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
			Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
			Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount1", 0f);
		}
		if (!Yandere.NierCostume.activeInHierarchy)
		{
			return;
		}
		Debug.Log("Nier costume special case.");
		Yandere.PantyAttacher.newRenderer.enabled = false;
		SkinnedMeshRenderer newRenderer = Yandere.NierCostume.GetComponent<RiggedAccessoryAttacher>().newRenderer;
		if (newRenderer == null)
		{
			TryNextFrame = true;
			return;
		}
		TryNextFrame = false;
		if (GameGlobals.CensorPanties)
		{
			newRenderer.materials[0].SetFloat("_BlendAmount", 1f);
			newRenderer.materials[1].SetFloat("_BlendAmount", 1f);
			newRenderer.materials[2].SetFloat("_BlendAmount", 1f);
			newRenderer.materials[3].SetFloat("_BlendAmount", 1f);
		}
		else
		{
			newRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			newRenderer.materials[1].SetFloat("_BlendAmount", 0f);
			newRenderer.materials[2].SetFloat("_BlendAmount", 0f);
			newRenderer.materials[3].SetFloat("_BlendAmount", 0f);
		}
	}

	public void UpdateCensor()
	{
		Censor();
		Censor();
	}

	public void DebugTest()
	{
		if (DebugInt == 0)
		{
			StudentScript obj = StudentManager.Students[39];
			obj.ShoeRemoval.Start();
			obj.ShoeRemoval.PutOnShoes();
			obj.Phase = 2;
			obj.ScheduleBlocks[2].action = "Stand";
			obj.GetDestinations();
			obj.CurrentDestination = MidoriSpot;
			obj.Pathfinding.target = MidoriSpot;
			obj.transform.position = Yandere.transform.position;
			Physics.SyncTransforms();
		}
		else if (DebugInt == 1)
		{
			Knife.transform.position = Yandere.transform.position + new Vector3(-1f, 1f, 0f);
			Knife.GetComponent<Rigidbody>().isKinematic = false;
			Knife.GetComponent<Rigidbody>().useGravity = true;
		}
		else if (DebugInt == 2)
		{
			Mop.transform.position = Yandere.transform.position + new Vector3(1f, 1f, 0f);
			Mop.GetComponent<Rigidbody>().isKinematic = false;
			Mop.GetComponent<Rigidbody>().useGravity = true;
		}
		DebugInt++;
	}
}
