using System;
using UnityEngine;

// Token: 0x020003D8 RID: 984
public class RivalDeskScript : MonoBehaviour
{
	// Token: 0x06001B79 RID: 7033 RVA: 0x00137275 File Offset: 0x00135475
	private void Start()
	{
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001B7A RID: 7034 RVA: 0x00137288 File Offset: 0x00135488
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

	// Token: 0x04002F05 RID: 12037
	public SchemesScript Schemes;

	// Token: 0x04002F06 RID: 12038
	public ClockScript Clock;

	// Token: 0x04002F07 RID: 12039
	public PromptScript Prompt;

	// Token: 0x04002F08 RID: 12040
	public bool Cheating;
}
