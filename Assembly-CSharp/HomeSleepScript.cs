using System;
using UnityEngine;

public class HomeSleepScript : MonoBehaviour
{
	public HomeDarknessScript HomeDarkness;

	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public HomeWindowScript HomeWindow;

	public GameObject SkipSchoolWindow;

	public UILabel EightiesLabel;

	public UILabel DescLabel;

	public UILabel Label;

	public bool Anime;

	public void Start()
	{
		if (Anime)
		{
			return;
		}
		SkipSchoolWindow.SetActive(value: false);
		if (GameGlobals.Eighties)
		{
			Label = EightiesLabel;
		}
		if (!HomeGlobals.Night)
		{
			if (DateGlobals.Weekday == DayOfWeek.Sunday)
			{
				DescLabel.text = "Advance to nighttime?";
				Label.text = "Nap";
			}
			else
			{
				DescLabel.text = "Advance to nighttime?";
				Label.text = "Skip School";
				SkipSchoolWindow.SetActive(value: true);
			}
		}
	}

	private void Update()
	{
		if (!HomeYandere.CanMove && !HomeDarkness.FadeOut)
		{
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				HomeDarkness.Sprite.color = new Color(0f, 0f, 0f, 0f);
				HomeDarkness.Cyberstalking = true;
				HomeDarkness.FadeOut = true;
				HomeWindow.Show = false;
				base.enabled = false;
			}
			if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				HomeCamera.Destination = HomeCamera.Destinations[0];
				HomeCamera.Target = HomeCamera.Targets[0];
				HomeYandere.CanMove = true;
				HomeWindow.Show = false;
				base.enabled = false;
			}
		}
	}
}
