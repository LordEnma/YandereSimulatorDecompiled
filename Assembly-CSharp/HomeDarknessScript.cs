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

	public bool Disposing;

	public bool FadeSlow;

	public bool FadeOut;

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
			if (!(Sprite.color.a >= 1f))
			{
				return;
			}
			HomeCamera.Profile.bloom.enabled = HomeCamera.RestoreBloom;
			HomeCamera.Profile.depthOfField.enabled = HomeCamera.RestoreDOF;
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
						SceneManager.LoadScene("CalendarScene");
					}
					else
					{
						SceneManager.LoadScene("YancordScene");
					}
				}
				else if (HomeCamera.ID == 5)
				{
					if (HomeVideoGames.ID == 1)
					{
						SceneManager.LoadScene("YanvaniaTitleScene");
					}
					else
					{
						SceneManager.LoadScene("MiyukiTitleScene");
					}
				}
				else if (HomeCamera.ID == 9)
				{
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
						StudentGlobals.SetStudentKidnapped(PrisonerManager.StudentID, false);
						StudentGlobals.StudentSlave = PrisonerManager.StudentID;
						StudentGlobals.PrisonerChosen = PrisonerManager.ChosenPrisoner;
						CheckForOsanaThursday();
					}
				}
				else if (HomeCamera.ID == 11)
				{
					EventGlobals.KidnapConversation = true;
					SceneManager.LoadScene("PhoneScene");
				}
				else if (HomeCamera.ID == 12)
				{
					SceneManager.LoadScene("LifeNoteScene");
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
						HomeCamera.DayLight.SetActive(true);
						HomeCamera.DayLight.GetComponent<Light>().intensity = 0.66666f;
						Physics.SyncTransforms();
						return;
					}
					HomeYandere.transform.position = new Vector3(-1.6f, 0f, -1.6f);
					HomeYandere.transform.eulerAngles = new Vector3(0f, 45f, 0f);
					HomeYandere.CanMove = true;
					FadeOut = false;
					HomeCamera.Destinations[0].position = new Vector3(-2.0615f, 1.5f, 2.418f);
					HomeCamera.Destination = HomeCamera.Destinations[0];
					HomeCamera.transform.position = HomeCamera.Destination.position;
					HomeCamera.Target = HomeCamera.Targets[0];
					HomeCamera.Focus.position = HomeCamera.Target.position;
					BasementLabel.text = "Basement";
					if (HomeGlobals.Night)
					{
						HomeCamera.DayLight.SetActive(false);
					}
					HomeCamera.DayLight.GetComponent<Light>().intensity = 2f;
					Physics.SyncTransforms();
				}
				else if (HomeExit.ID == 4)
				{
					if (!GameGlobals.Eighties)
					{
						SceneManager.LoadScene("StalkerHouseScene");
					}
					else
					{
						SceneManager.LoadScene("AsylumScene");
					}
				}
			}
			else if (HomeGlobals.Night)
			{
				if (DateGlobals.Weekday == DayOfWeek.Sunday)
				{
					DateGlobals.ForceSkip = true;
				}
				else if (DateGlobals.PassDays < 1)
				{
					DateGlobals.PassDays = 1;
				}
				SceneManager.LoadScene("CalendarScene");
				Debug.Log("Went to sleep.");
			}
			else
			{
				if (DateGlobals.Weekday != 0)
				{
					PlayerGlobals.Reputation -= 10f;
				}
				HomeGlobals.Night = true;
				SceneManager.LoadScene("HomeScene");
			}
		}
		else
		{
			Sprite.color = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, Sprite.color.a - Time.deltaTime);
			if (Sprite.color.a < 0f)
			{
				Sprite.color = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, 0f);
			}
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
		int buildIndexByScenePath = SceneUtility.GetBuildIndexByScenePath("WalkToSchoolScene");
		if (!GameGlobals.Eighties && GameGlobals.RivalEliminationID == 0 && !StudentGlobals.GetStudentKidnapped(11) && StudentGlobals.StudentSlave != 11 && DateGlobals.Weekday == DayOfWeek.Thursday && !HomeGlobals.LateForSchool && StudentGlobals.GetStudentReputation(11) > -100 && buildIndexByScenePath > -1)
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
