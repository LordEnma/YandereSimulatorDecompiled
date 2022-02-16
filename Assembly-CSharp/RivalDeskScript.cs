using System;
using UnityEngine;

// Token: 0x020003D9 RID: 985
public class RivalDeskScript : MonoBehaviour
{
	// Token: 0x06001B80 RID: 7040 RVA: 0x001375A5 File Offset: 0x001357A5
	private void Start()
	{
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001B81 RID: 7041 RVA: 0x001375B8 File Offset: 0x001357B8
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

	// Token: 0x04002F0B RID: 12043
	public SchemesScript Schemes;

	// Token: 0x04002F0C RID: 12044
	public ClockScript Clock;

	// Token: 0x04002F0D RID: 12045
	public PromptScript Prompt;

	// Token: 0x04002F0E RID: 12046
	public bool Cheating;
}
