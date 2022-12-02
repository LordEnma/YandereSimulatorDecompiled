using System;
using UnityEngine;

public class RivalDeskScript : MonoBehaviour
{
	public SchemesScript Schemes;

	public ClockScript Clock;

	public PromptScript Prompt;

	public bool Cheating;

	private void Start()
	{
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (Prompt.Yandere.Inventory.AnswerSheet || !Prompt.Yandere.Inventory.DuplicateSheet)
		{
			return;
		}
		Prompt.enabled = true;
		if (Clock.HourTime > 13f)
		{
			Prompt.HideButton[0] = false;
			if (Clock.HourTime > 13.5f)
			{
				SchemeGlobals.SetSchemeStage(5, 100);
				Schemes.UpdateInstructions();
				Prompt.HideButton[0] = true;
			}
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			if (DateGlobals.Weekday == DayOfWeek.Friday)
			{
				SchemeGlobals.SetSchemeStage(5, 9);
			}
			Schemes.UpdateInstructions();
			Prompt.Yandere.Inventory.DuplicateSheet = false;
			Prompt.Hide();
			Prompt.enabled = false;
			Cheating = true;
			base.enabled = false;
		}
	}
}
