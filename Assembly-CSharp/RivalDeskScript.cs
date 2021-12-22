using System;
using UnityEngine;

// Token: 0x020003D5 RID: 981
public class RivalDeskScript : MonoBehaviour
{
	// Token: 0x06001B6B RID: 7019 RVA: 0x00134CF5 File Offset: 0x00132EF5
	private void Start()
	{
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001B6C RID: 7020 RVA: 0x00134D08 File Offset: 0x00132F08
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

	// Token: 0x04002EE9 RID: 12009
	public SchemesScript Schemes;

	// Token: 0x04002EEA RID: 12010
	public ClockScript Clock;

	// Token: 0x04002EEB RID: 12011
	public PromptScript Prompt;

	// Token: 0x04002EEC RID: 12012
	public bool Cheating;
}
