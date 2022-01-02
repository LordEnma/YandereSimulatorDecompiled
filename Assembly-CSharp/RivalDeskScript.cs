using System;
using UnityEngine;

// Token: 0x020003D5 RID: 981
public class RivalDeskScript : MonoBehaviour
{
	// Token: 0x06001B6D RID: 7021 RVA: 0x001350F1 File Offset: 0x001332F1
	private void Start()
	{
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001B6E RID: 7022 RVA: 0x00135104 File Offset: 0x00133304
	private void Update()
	{
		if (!this.Prompt.Yandere.Inventory.AnswerSheet && this.Prompt.Yandere.Inventory.DuplicateSheet)
		{
			this.Prompt.enabled = true;
			if (this.Clock.HourTime > 13f)
			{
				this.Prompt.HideButton[0] = false;
				if (this.Clock.HourTime > 13.5f)
				{
					SchemeGlobals.SetSchemeStage(5, 100);
					this.Schemes.UpdateInstructions();
					this.Prompt.HideButton[0] = true;
				}
			}
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				if (DateGlobals.Weekday == DayOfWeek.Friday)
				{
					SchemeGlobals.SetSchemeStage(5, 9);
				}
				this.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.DuplicateSheet = false;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.Cheating = true;
				base.enabled = false;
			}
		}
	}

	// Token: 0x04002EF0 RID: 12016
	public SchemesScript Schemes;

	// Token: 0x04002EF1 RID: 12017
	public ClockScript Clock;

	// Token: 0x04002EF2 RID: 12018
	public PromptScript Prompt;

	// Token: 0x04002EF3 RID: 12019
	public bool Cheating;
}
