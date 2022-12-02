using System;
using UnityEngine;

public class HomeExitScript : MonoBehaviour
{
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

	private void Start()
	{
		UILabel uILabel = Labels[1];
		if (HomeGlobals.Night)
		{
			uILabel.color = new Color(uILabel.color.r, uILabel.color.g, uILabel.color.b, 0.5f);
			if (SchemeGlobals.GetSchemeStage(6) == 9 && !StudentGlobals.GetStudentDead(10 + DateGlobals.Week) && !StudentGlobals.GetStudentKidnapped(10 + DateGlobals.Week) && GameGlobals.RivalEliminationID == 0)
			{
				UILabel uILabel2 = Labels[4];
				uILabel2.color = new Color(uILabel2.color.r, uILabel2.color.g, uILabel2.color.b, 1f);
				uILabel2.text = "Stalker's House";
				if (GameGlobals.Eighties)
				{
					Labels[4].text = "Insane Asylum";
				}
			}
			BringItemPrompt.SetActive(false);
		}
		else if (DateGlobals.Weekday == DayOfWeek.Sunday)
		{
			uILabel.color = new Color(uILabel.color.r, uILabel.color.g, uILabel.color.b, 0.5f);
		}
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
			if (ID > 4)
			{
				ID = 1;
			}
			Highlight.localPosition = new Vector3(Highlight.localPosition.x, 50f - (float)ID * 50f, Highlight.localPosition.z);
		}
		if (InputManager.TappedUp)
		{
			ID--;
			if (ID < 1)
			{
				ID = 4;
			}
			Highlight.localPosition = new Vector3(Highlight.localPosition.x, 50f - (float)ID * 50f, Highlight.localPosition.z);
		}
		if (Input.GetButtonDown("A"))
		{
			if (Labels[ID].color.a != 1f)
			{
				return;
			}
			if (ID == 1)
			{
				HomeBringItem.HomeWindow.Show = true;
				HomeWindow.Show = false;
				return;
			}
			if (ID == 2)
			{
				HomeDarkness.Sprite.color = new Color(1f, 1f, 1f, 0f);
			}
			else if (ID == 3)
			{
				HomeDarkness.Sprite.color = new Color(0f, 0f, 0f, 0f);
			}
			else if (ID == 4)
			{
				HomeDarkness.Sprite.color = new Color(0f, 0f, 0f, 0f);
			}
			HomeDarkness.FadeOut = true;
			HomeWindow.Show = false;
			base.enabled = false;
		}
		else if (Input.GetButtonDown("B"))
		{
			HomeCamera.Destination = HomeCamera.Destinations[0];
			HomeCamera.Target = HomeCamera.Targets[0];
			HomeYandere.CanMove = true;
			HomeWindow.Show = false;
			base.enabled = false;
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
		HomeDarkness.FadeOut = true;
		HomeWindow.Show = false;
		base.enabled = false;
	}
}
