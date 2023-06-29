using System;
using UnityEngine;

public class SchemeManagerScript : MonoBehaviour
{
	public SchemesScript Schemes;

	public ClockScript Clock;

	public bool ClockCheck;

	public float Timer;

	public int CurrentScheme;

	public void Start()
	{
		if (SchemeGlobals.UnlockExpulsionDaily)
		{
			Debug.Log("SchemeGlobals.UnlockExpulsionDaily is true.");
			if (DateGlobals.Weekday == DayOfWeek.Tuesday)
			{
				SchemeGlobals.CurrentScheme = 2;
			}
			else if (DateGlobals.Weekday == DayOfWeek.Wednesday)
			{
				SchemeGlobals.CurrentScheme = 3;
			}
			else if (DateGlobals.Weekday == DayOfWeek.Thursday)
			{
				SchemeGlobals.CurrentScheme = 4;
			}
			else if (DateGlobals.Weekday == DayOfWeek.Friday)
			{
				SchemeGlobals.CurrentScheme = 5;
			}
		}
		if (SchemeGlobals.UnlockRejectionDaily)
		{
			Debug.Log("SchemeGlobals.UnlockRejectionDaily is true.");
			if (DateGlobals.Weekday == DayOfWeek.Tuesday)
			{
				SchemeGlobals.CurrentScheme = 22;
			}
			else if (DateGlobals.Weekday == DayOfWeek.Wednesday)
			{
				SchemeGlobals.CurrentScheme = 23;
			}
			else if (DateGlobals.Weekday == DayOfWeek.Thursday)
			{
				SchemeGlobals.CurrentScheme = 24;
			}
			else if (DateGlobals.Weekday == DayOfWeek.Friday)
			{
				SchemeGlobals.CurrentScheme = 25;
			}
		}
		if (SchemeGlobals.UnlockExpulsionDaily || SchemeGlobals.UnlockRejectionDaily)
		{
			SchemeGlobals.SetSchemeStage(SchemeGlobals.CurrentScheme, 1);
			Debug.Log("SchemeGlobals is now: " + SchemeGlobals.CurrentScheme + " and SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) is: " + SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme));
		}
	}

	private void Update()
	{
		if (CurrentScheme < 6)
		{
			if (Clock.HourTime > 15.5f)
			{
				SchemeGlobals.SetSchemeStage(SchemeGlobals.CurrentScheme, 100);
				Clock.Yandere.NotificationManager.CustomText = "Scheme failed! You were too slow.";
				Clock.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Schemes.UpdateInstructions();
				base.enabled = false;
			}
		}
		else if (CurrentScheme > 6 && Input.GetButton("A"))
		{
			if (Input.GetButtonDown("LB"))
			{
				SchemeGlobals.SetSchemeStage(CurrentScheme, SchemeGlobals.GetSchemeStage(CurrentScheme) - 1);
				Schemes.UpdateInstructions();
			}
			else if (Input.GetButtonDown("RB"))
			{
				SchemeGlobals.SetSchemeStage(CurrentScheme, SchemeGlobals.GetSchemeStage(CurrentScheme) + 1);
				Schemes.UpdateInstructions();
			}
		}
		if (!ClockCheck || !(Clock.HourTime > 8.25f))
		{
			return;
		}
		Timer += Time.deltaTime;
		if (Timer > 1f)
		{
			Timer = 0f;
			if (SchemeGlobals.GetSchemeStage(5) == 1)
			{
				Debug.Log("It's past 8:15 AM, so we're advancing to Stage 2 of Scheme 5.");
				SchemeGlobals.SetSchemeStage(5, 2);
				Schemes.UpdateInstructions();
				ClockCheck = false;
			}
		}
	}
}
