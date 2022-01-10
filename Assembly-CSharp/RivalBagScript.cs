using System;
using UnityEngine;

// Token: 0x020003D5 RID: 981
public class RivalBagScript : MonoBehaviour
{
	// Token: 0x06001B70 RID: 7024 RVA: 0x00135268 File Offset: 0x00133468
	private void Start()
	{
		if (this.Schemes.StudentManager.Students[this.Schemes.StudentManager.RivalID] == null || StudentGlobals.StudentSlave == this.Schemes.StudentManager.RivalID)
		{
			base.gameObject.SetActive(false);
			this.Prompt.enabled = false;
			this.Prompt.Hide();
		}
	}

	// Token: 0x06001B71 RID: 7025 RVA: 0x001352D8 File Offset: 0x001334D8
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

	// Token: 0x04002EE8 RID: 12008
	public SchemesScript Schemes;

	// Token: 0x04002EE9 RID: 12009
	public ClockScript Clock;

	// Token: 0x04002EEA RID: 12010
	public PromptScript Prompt;
}
