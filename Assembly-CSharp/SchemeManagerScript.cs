using UnityEngine;

public class SchemeManagerScript : MonoBehaviour
{
	public SchemesScript Schemes;

	public ClockScript Clock;

	public bool ClockCheck;

	public float Timer;

	public int CurrentScheme;

	private void Start()
	{
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
