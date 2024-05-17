using System;
using UnityEngine;

public class RivalBagScript : MonoBehaviour
{
	public CounselorScript Counselor;

	public SchemesScript Schemes;

	public ClockScript Clock;

	public PromptScript Prompt;

	private void Start()
	{
		if (Schemes.StudentManager.Students[11] == null || StudentGlobals.StudentSlave == 11)
		{
			base.gameObject.SetActive(value: false);
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
			Prompt.HideButton[2] = true;
			Prompt.HideButton[3] = true;
			Prompt.enabled = false;
		}
		else
		{
			Prompt.HideButton[0] = !Prompt.Yandere.Inventory.Cigs;
			Prompt.HideButton[1] = !Prompt.Yandere.Inventory.Ring;
			Prompt.HideButton[2] = !Prompt.Yandere.Inventory.SafeKey;
			Prompt.HideButton[3] = !Prompt.Yandere.Inventory.IDCard;
			if (!Prompt.HideButton[0] || !Prompt.HideButton[1] || !Prompt.HideButton[2] || !Prompt.HideButton[3])
			{
				Prompt.enabled = true;
			}
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			if (DateGlobals.Weekday == DayOfWeek.Wednesday)
			{
				SchemeGlobals.SetSchemeStage(3, 4);
			}
			Prompt.Yandere.Inventory.Cigs = false;
			Exit();
		}
		if (Prompt.Circle[1].fillAmount == 0f || Prompt.Circle[2].fillAmount == 0f || Prompt.Circle[3].fillAmount == 0f)
		{
			if (DateGlobals.Weekday == DayOfWeek.Tuesday)
			{
				SchemeGlobals.SetSchemeStage(2, 6);
			}
			if (Prompt.Circle[1].fillAmount == 0f)
			{
				Prompt.Yandere.Inventory.Ring = false;
				Counselor.StoleRing = true;
			}
			else if (Prompt.Circle[2].fillAmount == 0f)
			{
				Prompt.Yandere.Inventory.SafeKey = false;
			}
			else if (Prompt.Circle[3].fillAmount == 0f)
			{
				Prompt.Yandere.Inventory.IDCard = false;
			}
			Exit();
		}
	}

	private void Exit()
	{
		Schemes.UpdateInstructions();
		Prompt.enabled = false;
		Prompt.Hide();
		base.enabled = false;
	}
}
