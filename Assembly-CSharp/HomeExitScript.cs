using System;
using UnityEngine;

public class HomeExitScript : MonoBehaviour
{
	public HomeWindowScript PartTimeJobWindow;

	public InputManagerScript InputManager;

	public HomeDarknessScript HomeDarkness;

	public HomeYandereScript HomeYandere;

	public BringItemScript HomeBringItem;

	public HomeCameraScript HomeCamera;

	public HomeWindowScript HomeWindow;

	public GameObject BringItemPrompt;

	public Transform Highlight;

	public UILabel[] Labels;

	public int ID = 1;

	public int Zs;

	public AudioSource MyAudio;

	public AudioClip Confirm;

	public HomeTriggerScript BasementTrigger;

	public UILabel BasementLabel;

	public void Start()
	{
		UILabel uILabel = Labels[1];
		Labels[5].alpha = 0.5f;
		if (HomeGlobals.Night)
		{
			uILabel.color = new Color(uILabel.color.r, uILabel.color.g, uILabel.color.b, 0.5f);
			if (SchemeGlobals.GetSchemeStage(6) == 9 && !StudentGlobals.GetStudentDead(10 + DateGlobals.Week) && !StudentGlobals.GetStudentKidnapped(10 + DateGlobals.Week) && GameGlobals.RivalEliminationID == 0 && !ChallengeGlobals.KnifeOnly)
			{
				UILabel uILabel2 = Labels[4];
				uILabel2.color = new Color(uILabel2.color.r, uILabel2.color.g, uILabel2.color.b, 1f);
				if (GameGlobals.Eighties)
				{
					Labels[4].text = "Insane Asylum";
				}
				else if (DateGlobals.Week == 1)
				{
					uILabel2.text = "Stalker's House";
				}
				else if (DateGlobals.Week == 2)
				{
					uILabel2.text = "''Dark Delights'' Bakery";
				}
			}
			BringItemPrompt.SetActive(value: false);
			Labels[5].alpha = 1f;
			Labels[6].alpha = 0.5f;
		}
		else
		{
			if (DateGlobals.Weekday == DayOfWeek.Sunday)
			{
				uILabel.color = new Color(uILabel.color.r, uILabel.color.g, uILabel.color.b, 0.5f);
				Labels[5].alpha = 1f;
			}
			if (HomeCamera.OutOfRoom)
			{
				Labels[6].alpha = 0.5f;
				if (HomeYandere.transform.position.y < -5f)
				{
					Labels[3].alpha = 1f;
					Labels[6].alpha = 0.5f;
				}
				else
				{
					Labels[3].alpha = 0.5f;
				}
			}
			else if (HomeYandere.transform.position.y < -5f)
			{
				Labels[6].alpha = 0.5f;
			}
			else
			{
				Labels[6].alpha = 1f;
			}
			if (GameGlobals.CustomMode)
			{
				Labels[6].alpha = 0.5f;
			}
		}
		Highlight.localPosition = new Vector3(Highlight.localPosition.x, 125f - (float)ID * 50f, Highlight.localPosition.z);
	}

	private void Update()
	{
		if (HomeYandere.CanMove || HomeDarkness.FadeOut || !(HomeWindow.Sprite.color.a > 0.9f))
		{
			return;
		}
		if (InputManager.TappedDown)
		{
			ID++;
			if (ID > 6)
			{
				ID = 1;
			}
			Highlight.localPosition = new Vector3(Highlight.localPosition.x, 125f - (float)ID * 50f, Highlight.localPosition.z);
		}
		if (InputManager.TappedUp)
		{
			ID--;
			if (ID < 1)
			{
				ID = 6;
			}
			Highlight.localPosition = new Vector3(Highlight.localPosition.x, 125f - (float)ID * 50f, Highlight.localPosition.z);
		}
		if (Input.GetButtonDown(InputNames.Xbox_A))
		{
			if (Labels[ID].color.a == 1f)
			{
				if (ID == 1)
				{
					HomeBringItem.HomeWindow.Show = true;
					HomeWindow.Show = false;
				}
				else if (ID == 5)
				{
					PartTimeJobWindow.Show = true;
					HomeWindow.Show = false;
				}
				else if (ID == 6)
				{
					Debug.Log("Leaving bedroom, allegedly.");
					HomeYandere.MyController.radius = 0.25f;
					HomeCamera.Triggers[1].gameObject.transform.position = new Vector3(-4.063334f, -2.5165f, -4.0875f);
					HomeCamera.Triggers[1].gameObject.GetComponent<BoxCollider>().size = new Vector3(2.16f, 1f, 1f);
					HomeCamera.Triggers[1].FadeIn = false;
					HomeCamera.Triggers[1].Label.transform.localPosition = new Vector3(-4067.5f, -1450f, -4541f);
					HomeCamera.Triggers[1].Label.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
					HomeCamera.Destinations[1].transform.localPosition = new Vector3(-4.02f, -2.1f, -2.5f);
					HomeCamera.Targets[1].transform.localPosition = new Vector3(-4.02f, -2.1f, -4.56265f);
					HomeBringItem.HardwareButton.SetActive(value: false);
					HomeCamera.OutOfRoom = true;
					HomeCamera.ID = 0;
					if (!GameGlobals.Eighties)
					{
						HomeCamera.OpenDoor = true;
						Exit();
					}
					else
					{
						BasementTrigger.Label = BasementLabel;
						HomeDarkness.FadeOut = true;
						HomeCamera.enabled = false;
						HomeWindow.Show = false;
						base.enabled = false;
					}
				}
				else
				{
					if (ID == 2)
					{
						HomeDarkness.Sprite.color = new Color(1f, 1f, 1f, 0f);
						MyAudio.clip = Confirm;
						MyAudio.Play();
					}
					else if (ID == 3)
					{
						HomeDarkness.Sprite.color = new Color(0f, 0f, 0f, 0f);
						MyAudio.clip = Confirm;
						MyAudio.Play();
					}
					else if (ID == 4)
					{
						HomeDarkness.Sprite.color = new Color(0f, 0f, 0f, 0f);
						MyAudio.clip = Confirm;
						MyAudio.Play();
					}
					HomeDarkness.FadeOut = true;
					HomeWindow.Show = false;
					base.enabled = false;
				}
			}
		}
		else if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			Exit();
			if (HomeCamera.OutOfRoom && HomeYandere.transform.position.y > -5f)
			{
				HomeCamera.Destination = HomeCamera.OutOfRoomDestinations[2];
				HomeCamera.LastChangePoint = Vector3.zero;
				HomeCamera.TooClose = false;
				HomeCamera.CameraTimer = 0f;
				HomeYandere.transform.position = new Vector3(-4.111486f, -2.994555f, -3.33333f);
				HomeYandere.transform.eulerAngles = new Vector3(0f, 180f, 0f);
			}
		}
		if (Input.GetKeyDown("z"))
		{
			Zs++;
			if (Zs > 9)
			{
				SchemeGlobals.SetSchemeStage(6, 9);
			}
		}
	}

	public void GoToSchool()
	{
		if (SchoolGlobals.SchoolAtmosphere < 0.5f || GameGlobals.LoveSick)
		{
			HomeDarkness.Sprite.color = new Color(0f, 0f, 0f, 0f);
		}
		else
		{
			HomeDarkness.Sprite.color = new Color(1f, 1f, 1f, 0f);
		}
		MyAudio.clip = Confirm;
		MyAudio.Play();
		HomeDarkness.FadeOut = true;
		HomeWindow.Show = false;
		base.enabled = false;
	}

	public void Exit()
	{
		HomeCamera.Destination = HomeCamera.Destinations[0];
		HomeCamera.Target = HomeCamera.Targets[0];
		HomeYandere.CanMove = true;
		HomeWindow.Show = false;
		base.enabled = false;
	}
}
