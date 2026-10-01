using System;
using UnityEngine;

public class SchemeManagerScript : MonoBehaviour
{
	public SchemesScript Schemes;

	public ClockScript Clock;

	public int SchemeID;

	public int CurrentCategory;

	public int CurrentScheme;

	public bool ClockCheck;

	public float Timer;

	public bool[] SchemeUnlocked;

	public int[] SchemePreviousStage;

	public int[] SchemeStage;

	public string CurrentSteps;

	public bool Initialized;

	public Transform[] CurrentDestinations;

	public void Start()
	{
		if (!Initialized)
		{
			for (int i = 1; i < SchemeUnlocked.Length; i++)
			{
				SchemeUnlocked[i] = SchemeGlobals.GetSchemeUnlocked(i);
			}
			Initialized = true;
		}
		if (SchemeGlobals.UnlockExpulsionDaily)
		{
			Debug.Log("SchemeGlobals.UnlockExpulsionDaily is true.");
			if (DateGlobals.Weekday == DayOfWeek.Tuesday)
			{
				CurrentScheme = 2;
			}
			else if (DateGlobals.Weekday == DayOfWeek.Wednesday)
			{
				CurrentScheme = 3;
			}
			else if (DateGlobals.Weekday == DayOfWeek.Thursday)
			{
				CurrentScheme = 4;
			}
			else if (DateGlobals.Weekday == DayOfWeek.Friday)
			{
				CurrentScheme = 5;
			}
		}
		if (SchemeGlobals.UnlockRejectionDaily)
		{
			Debug.Log("SchemeGlobals.UnlockRejectionDaily is true.");
			if (DateGlobals.Weekday == DayOfWeek.Tuesday)
			{
				CurrentScheme = 22;
			}
			else if (DateGlobals.Weekday == DayOfWeek.Wednesday)
			{
				CurrentScheme = 23;
			}
			else if (DateGlobals.Weekday == DayOfWeek.Thursday)
			{
				CurrentScheme = 24;
			}
			else if (DateGlobals.Weekday == DayOfWeek.Friday)
			{
				CurrentScheme = 25;
			}
		}
		if (SchemeGlobals.UnlockExpulsionDaily || SchemeGlobals.UnlockRejectionDaily)
		{
			SchemeStage[CurrentScheme] = 1;
			Debug.Log("CurrentScheme is now: " + CurrentScheme + " and SchemeStage[CurrentScheme] is now: " + SchemeStage[CurrentScheme]);
		}
	}

	private void Update()
	{
		if (CurrentCategory > 3 && CurrentScheme > 5 && CurrentScheme < 11)
		{
			if (Clock.HourTime > 15.5f)
			{
				SchemeStage[SchemeID] = 100;
				Clock.Yandere.NotificationManager.CustomText = "Scheme failed! You were too slow.";
				Clock.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Schemes.UpdateInstructions();
				base.enabled = false;
			}
		}
		else if (Schemes.StudentManager.Week == 1 && CurrentCategory > 3 && CurrentScheme == 11 && SchemeStage[SchemeID] == 1)
		{
			if (Clock.HourTime > 8.5f)
			{
				SchemeStage[SchemeID] = 100;
				Clock.Yandere.NotificationManager.CustomText = "Scheme failed! You were too slow.";
				Clock.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Schemes.UpdateInstructions();
				base.enabled = false;
			}
			else if (Clock.StudentManager.Reputation.Reputation + Clock.StudentManager.Reputation.PendingRep >= 10f)
			{
				SchemeStage[SchemeID]++;
				Schemes.UpdateInstructions();
			}
		}
		if (Schemes.NextStepInput.activeInHierarchy && Input.GetButton(InputNames.Xbox_A))
		{
			if (Input.GetButtonDown(InputNames.Xbox_LB))
			{
				SchemeStage[SchemeID]--;
				Schemes.UpdateInstructions();
			}
			else if (Input.GetButtonDown(InputNames.Xbox_RB))
			{
				SchemeStage[SchemeID]++;
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
			if (SchemeStage[410] == 1)
			{
				Debug.Log("It's past 8:15 AM, so we're advancing to Stage 2 of the Scheme to frame Osana for cheating.");
				SchemeStage[410] = 2;
				Schemes.UpdateInstructions();
				ClockCheck = false;
			}
		}
	}

	public void SetSchemeStage(int Scheme, int Stage)
	{
		SchemeStage[Scheme] = Stage;
	}

	public int GetSchemeStage(int Scheme)
	{
		return SchemeStage[Scheme];
	}

	public void SaveSchemeData()
	{
		Debug.Log("Now telling all unlocked schemes to remember that they were unlocked.");
		SchemeGlobals.CurrentScheme = CurrentScheme;
		for (int i = 1; i < 1001; i++)
		{
			SchemeGlobals.SetSchemePreviousStage(i, SchemePreviousStage[i]);
			SchemeGlobals.SetSchemeUnlocked(i, SchemeUnlocked[i]);
			SchemeGlobals.SetSchemeStage(i, SchemeStage[i]);
		}
	}
}
