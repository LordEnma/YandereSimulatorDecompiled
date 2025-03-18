using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeDarknessScript : MonoBehaviour
{
	public PrisonerManagerScript PrisonerManager;

	public HomeVideoGamesScript HomeVideoGames;

	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public HomeExitScript HomeExit;

	public InputDeviceScript InputDevice;

	public UILabel BasementLabel;

	public UISprite Sprite;

	public bool Cyberstalking;

	public bool GoWatchAnime;

	public bool ReadingManga;

	public bool Disposing;

	public bool FadeSlow;

	public bool FadeOut;

	public int WaitFrame;

	private void Start()
	{
		if (GameGlobals.LoveSick)
		{
			Sprite.color = new Color(0f, 0f, 0f, 1f);
		}
		Sprite.color = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, 1f);
		StudentGlobals.PreviousPrisoner = 0;
		StudentGlobals.PreviousSanity = 0;
	}

	private void Update()
	{
		if (FadeOut)
		{
			Sprite.color = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, Sprite.color.a + Time.deltaTime * (FadeSlow ? 0.2f : 1f));
			if (!(Sprite.color.a >= 0.999f))
			{
				return;
			}
			GameGlobals.LastInputType = (int)InputDevice.Type;
			HomeCamera.Profile.bloom.enabled = HomeCamera.RestoreBloom;
			HomeCamera.Profile.depthOfField.enabled = HomeCamera.RestoreDOF;
			if (HomeCamera.ID == 0 && !HomeCamera.OutOfRoom)
			{
				Debug.Log("Cheeky player stepped out of a trigger...");
				HomeCamera.ID = HomeCamera.LastID;
			}
			if (HomeCamera.ID != 2)
			{
				if (HomeCamera.ID == 3)
				{
					if (Cyberstalking)
					{
						if (DateGlobals.PassDays < 1)
						{
							DateGlobals.PassDays = 1;
						}
						if (DateGlobals.Weekday != DayOfWeek.Friday)
						{
							DateGlobals.ForceSkip = true;
						}
						Debug.Log("Exiting home via cyberstalking.");
						SceneManager.LoadScene("CalendarScene");
					}
					else
					{
						Debug.Log("Exiting home via Yancord.");
						SceneManager.LoadScene("YancordScene");
					}
				}
				else if (HomeCamera.ID == 5)
				{
					Debug.Log("Exiting home via video game.");
					if (HomeVideoGames.ID == 1)
					{
						SceneManager.LoadScene("YanvaniaTitleScene");
					}
					else
					{
						SceneManager.LoadScene("MiyukiTitleScene");
					}
				}
				else if (HomeCamera.ID == 9 || ReadingManga)
				{
					Debug.Log("Exiting home via manga.");
					if (!HomeGlobals.Night)
					{
						HomeGlobals.Night = true;
						SceneManager.LoadScene("HomeScene");
						return;
					}
					if (DateGlobals.PassDays < 1)
					{
						DateGlobals.PassDays = 1;
					}
					if (DateGlobals.Weekday != DayOfWeek.Friday)
					{
						DateGlobals.ForceSkip = true;
					}
					SceneManager.LoadScene("CalendarScene");
				}
				else if (HomeCamera.ID == 10)
				{
					Debug.Log("Exiting home via taking mind-broken slave to school.");
					if (Disposing)
					{
						if (!HomeGlobals.Night)
						{
							HomeGlobals.Night = true;
							SceneManager.LoadScene("HomeScene");
							return;
						}
						if (DateGlobals.PassDays < 1)
						{
							DateGlobals.PassDays = 1;
						}
						if (DateGlobals.Weekday != DayOfWeek.Friday)
						{
							DateGlobals.ForceSkip = true;
						}
						SceneManager.LoadScene("CalendarScene");
					}
					else
					{
						StudentGlobals.SetStudentKidnapped(PrisonerManager.StudentID, value: false);
						StudentGlobals.StudentSlave = PrisonerManager.StudentID;
						StudentGlobals.PrisonerChosen = PrisonerManager.ChosenPrisoner;
						CheckForOsanaThursday();
					}
				}
				else if (HomeCamera.ID == 11)
				{
					Debug.Log("Exiting home via kidnap conversation.");
					EventGlobals.KidnapConversation = true;
					SceneManager.LoadScene("PhoneScene");
				}
				else if (HomeCamera.ID == 12 || GoWatchAnime)
				{
					Debug.Log("Exiting home via watching anime.");
					SceneManager.LoadScene("LifeNoteScene");
				}
				else if (HomeYandere.transform.localScale.x < 0.5f)
				{
					Debug.Log("Going to school because of the Hardware Menu.");
					CheckForOsanaThursday();
				}
				else if (HomeExit.ID == 1)
				{
					CheckForOsanaThursday();
				}
				else if (HomeExit.ID == 2)
				{
					SceneManager.LoadScene("StreetScene");
				}
				else if (HomeExit.ID == 3)
				{
					if (HomeYandere.transform.position.y > -5f)
					{
						HomeYandere.transform.position = new Vector3(-2f, -10f, -2.75f);
						HomeYandere.transform.eulerAngles = new Vector3(0f, 90f, 0f);
						HomeYandere.CanMove = true;
						FadeOut = false;
						HomeCamera.Destinations[0].position = new Vector3(2.425f, -8.5f, 0f);
						HomeCamera.Destination = HomeCamera.Destinations[0];
						HomeCamera.transform.position = HomeCamera.Destination.position;
						HomeCamera.Target = HomeCamera.Targets[0];
						HomeCamera.Focus.position = HomeCamera.Target.position;
						BasementLabel.text = "Upstairs";
						HomeCamera.DayLight.SetActive(value: true);
						HomeCamera.DayLight.GetComponent<Light>().intensity = 0.66666f;
						HomeYandere.MyController.radius = 0.445f;
						Physics.SyncTransforms();
						return;
					}
					if (HomeCamera.OutOfRoom)
					{
						HomeCamera.Destination = HomeCamera.OutOfRoomDestinations[2];
						HomeCamera.LastChangePoint = Vector3.zero;
						HomeCamera.TooClose = false;
						HomeCamera.CameraTimer = 0f;
						HomeYandere.transform.position = new Vector3(-3.306057f, -2.892705f, 0f);
						HomeYandere.transform.eulerAngles = new Vector3(0f, -90f, 0f);
						HomeYandere.MyController.radius = 0.25f;
					}
					else
					{
						HomeCamera.Destinations[0].position = new Vector3(-2.0615f, 1.5f, 2.418f);
						HomeCamera.Destination = HomeCamera.Destinations[0];
						HomeCamera.transform.position = HomeCamera.Destination.position;
						HomeYandere.transform.position = new Vector3(-1.6f, 0f, -1.6f);
						HomeYandere.transform.eulerAngles = new Vector3(0f, 45f, 0f);
					}
					HomeYandere.CanMove = true;
					FadeOut = false;
					HomeCamera.Target = HomeCamera.Targets[0];
					HomeCamera.Focus.position = HomeCamera.Target.position;
					BasementLabel.text = "Basement";
					if (HomeGlobals.Night)
					{
						HomeCamera.DayLight.SetActive(value: false);
					}
					HomeCamera.DayLight.GetComponent<Light>().intensity = 2f;
					Physics.SyncTransforms();
				}
				else if (HomeExit.ID == 4)
				{
					if (!GameGlobals.Eighties)
					{
						if (DateGlobals.Week == 1)
						{
							SceneManager.LoadScene("StalkerHouseScene");
						}
						else
						{
							SceneManager.LoadScene("RivalBakeryScene");
						}
					}
					else
					{
						SceneManager.LoadScene("AsylumScene");
					}
				}
				else
				{
					if (HomeExit.ID != 5)
					{
						return;
					}
					Debug.Log("Exiting HomeScene via Part Time Job menu.");
					if (!HomeGlobals.Night)
					{
						HomeGlobals.Night = true;
						SceneManager.LoadScene("HomeScene");
						return;
					}
					if (DateGlobals.Weekday == DayOfWeek.Sunday)
					{
						Debug.Log("It was Sunday.");
						DateGlobals.ForceSkip = true;
					}
					SceneManager.LoadScene("CalendarScene");
				}
				return;
			}
			if (HomeGlobals.Night)
			{
				if (DateGlobals.Weekday == DayOfWeek.Sunday)
				{
					DateGlobals.ForceSkip = true;
				}
				else if (DateGlobals.PassDays < 1)
				{
					DateGlobals.PassDays = 1;
				}
				if (GameGlobals.Dream == 0)
				{
					SceneManager.LoadScene("CalendarScene");
					return;
				}
				if (GameGlobals.Dream == 1)
				{
					SceneManager.LoadScene("OriginDreamScene");
				}
				else if (GameGlobals.Dream == 2)
				{
					SceneManager.LoadScene("OutlanderDreamScene");
				}
				GameGlobals.Dream = 0;
				return;
			}
			if (DateGlobals.Weekday != 0)
			{
				PlayerGlobals.Reputation -= 20f;
				if (StudentGlobals.MemorialStudents > 0)
				{
					StudentGlobals.MemorialStudents = 0;
					StudentGlobals.MemorialStudent1 = 0;
					StudentGlobals.MemorialStudent2 = 0;
					StudentGlobals.MemorialStudent3 = 0;
					StudentGlobals.MemorialStudent4 = 0;
					StudentGlobals.MemorialStudent5 = 0;
					StudentGlobals.MemorialStudent6 = 0;
					StudentGlobals.MemorialStudent7 = 0;
					StudentGlobals.MemorialStudent8 = 0;
					StudentGlobals.MemorialStudent9 = 0;
				}
				GameGlobals.SenpaiMourning = false;
			}
			HomeGlobals.Night = true;
			SceneManager.LoadScene("HomeScene");
		}
		else
		{
			if (WaitFrame > 0)
			{
				Sprite.alpha = Mathf.MoveTowards(Sprite.alpha, 0f, Time.deltaTime);
			}
			WaitFrame++;
		}
	}

	private void CheckForOsanaThursday()
	{
		if (InputDevice.Type == InputDeviceType.Gamepad)
		{
			PlayerGlobals.UsingGamepad = true;
		}
		else
		{
			PlayerGlobals.UsingGamepad = false;
		}
		GameGlobals.LastInputType = (int)InputDevice.Type;
		int buildIndexByScenePath = SceneUtility.GetBuildIndexByScenePath("WalkToSchoolScene");
		int num = 10 + DateGlobals.Week;
		if (!GameGlobals.Eighties && GameGlobals.RivalEliminationID == 0 && !StudentGlobals.GetStudentKidnapped(num) && StudentGlobals.StudentSlave != num && DateGlobals.Weekday == DayOfWeek.Thursday && !HomeGlobals.LateForSchool && StudentGlobals.GetStudentReputation(num) > -100 && buildIndexByScenePath > -1)
		{
			SceneManager.LoadScene("WalkToSchoolScene");
		}
		else if (DateGlobals.Weekday == DayOfWeek.Saturday)
		{
			DateGlobals.PassDays = 1;
			SceneManager.LoadScene("CalendarScene");
		}
		else if (GameGlobals.ShowAbduction)
		{
			SceneManager.LoadScene("AbductionScene");
			GameGlobals.ShowAbduction = false;
		}
		else
		{
			SceneManager.LoadScene("LoadingScene");
		}
	}
}
