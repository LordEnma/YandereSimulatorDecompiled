using System;
using UnityEngine;

// Token: 0x020003D6 RID: 982
public class RivalBagScript : MonoBehaviour
{
	// Token: 0x06001B75 RID: 7029 RVA: 0x00137050 File Offset: 0x00135250
	private void Start()
	{
		if (this.Schemes.StudentManager.Students[this.Schemes.StudentManager.RivalID] == null || StudentGlobals.StudentSlave == this.Schemes.StudentManager.RivalID)
		{
			base.gameObject.SetActive(false);
			this.Prompt.enabled = false;
			this.Prompt.Hide();
		}
	}

	// Token: 0x06001B76 RID: 7030 RVA: 0x001370C0 File Offset: 0x001352C0
	private void Update()
	{
		if (this.Clock.Period == 2 || this.Clock.Period > 3)
		{
			this.Prompt.HideButton[0] = true;
			this.Prompt.HideButton[1] = true;
		}
		else
		{
			this.Prompt.HideButton[0] = !this.Prompt.Yandere.Inventory.Cigs;
			this.Prompt.HideButton[1] = !this.Prompt.Yandere.Inventory.Ring;
		}
		if (this.Prompt.Yandere.Inventory.Cigs)
		{
			this.Prompt.enabled = true;
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				if (DateGlobals.Weekday == DayOfWeek.Wednesday)
				{
					SchemeGlobals.SetSchemeStage(3, 4);
				}
				this.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.Cigs = false;
				this.Prompt.enabled = false;
				this.Prompt.Hide();
				base.enabled = false;
			}
		}
		if (this.Prompt.Yandere.Inventory.Ring)
		{
			this.Prompt.enabled = true;
			if (this.Prompt.Circle[1].fillAmount == 0f)
			{
				if (DateGlobals.Weekday == DayOfWeek.Tuesday)
				{
					SchemeGlobals.SetSchemeStage(2, 3);
				}
				this.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.Ring = false;
				this.Prompt.enabled = false;
				this.Prompt.Hide();
				base.enabled = false;
			}
		}
	}

	// Token: 0x04002EF7 RID: 12023
	public SchemesScript Schemes;

	// Token: 0x04002EF8 RID: 12024
	public ClockScript Clock;

	// Token: 0x04002EF9 RID: 12025
	public PromptScript Prompt;
}
