using System;
using UnityEngine;

public class SabotageVendingMachineScript : MonoBehaviour
{
	public VendingMachineScript VendingMachine;

	public GameObject SabotageSparks;

	public YandereScript Yandere;

	public PromptScript Prompt;

	private void Start()
	{
		Prompt.enabled = false;
		Prompt.Hide();
	}

	private void Update()
	{
		if (Yandere.Armed)
		{
			if (Yandere.EquippedWeapon.WeaponID != 6)
			{
				return;
			}
			Prompt.enabled = true;
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				if (SchemeGlobals.GetSchemeStage(4) == 2)
				{
					SchemeGlobals.SetSchemeStage(4, 3);
					Yandere.PauseScreen.Schemes.UpdateInstructions();
				}
				if (Yandere.StudentManager.Students[11] != null && DateGlobals.Weekday == DayOfWeek.Thursday)
				{
					Yandere.StudentManager.Students[11].Hungry = true;
					Yandere.StudentManager.Students[11].Fed = false;
				}
				UnityEngine.Object.Instantiate(SabotageSparks, new Vector3(-2.5f, 5.3605f, -32.982f), Quaternion.identity);
				VendingMachine.Sabotaged = true;
				Prompt.enabled = false;
				Prompt.Hide();
				base.enabled = false;
			}
		}
		else if (Prompt.enabled)
		{
			Prompt.enabled = false;
			Prompt.Hide();
		}
	}
}
