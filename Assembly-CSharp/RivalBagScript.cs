using System;
using UnityEngine;

public class RivalBagScript : MonoBehaviour
{
	public SchemesScript Schemes;

	public ClockScript Clock;

	public PromptScript Prompt;

	private void Start()
	{
		if (Schemes.StudentManager.Students[Schemes.StudentManager.RivalID] == null || StudentGlobals.StudentSlave == Schemes.StudentManager.RivalID)
		{
			base.gameObject.SetActive(false);
			Prompt.enabled = false;
			Prompt.Hide();
		}
	}

	private void Update()
	{
		if (Clock.Period == 2 || Clock.Period > 3)
		{
			Prompt.HideButton[0] = true;
			Prompt.HideButton[1] = true;
		}
		else
		{
			Prompt.HideButton[0] = !Prompt.Yandere.Inventory.Cigs;
			Prompt.HideButton[1] = !Prompt.Yandere.Inventory.Ring;
		}
		if (Prompt.Yandere.Inventory.Cigs)
		{
			Prompt.enabled = true;
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				if (DateGlobals.Weekday == DayOfWeek.Wednesday)
				{
					SchemeGlobals.SetSchemeStage(3, 4);
				}
				Schemes.UpdateInstructions();
				Prompt.Yandere.Inventory.Cigs = false;
				Prompt.enabled = false;
				Prompt.Hide();
				base.enabled = false;
			}
		}
		if (!Prompt.Yandere.Inventory.Ring)
		{
			return;
		}
		Prompt.enabled = true;
		if (Prompt.Circle[1].fillAmount == 0f)
		{
			if (DateGlobals.Weekday == DayOfWeek.Tuesday)
			{
				SchemeGlobals.SetSchemeStage(2, 6);
			}
			Schemes.UpdateInstructions();
			Prompt.Yandere.Inventory.Ring = false;
			Prompt.enabled = false;
			Prompt.Hide();
			base.enabled = false;
		}
	}
}
