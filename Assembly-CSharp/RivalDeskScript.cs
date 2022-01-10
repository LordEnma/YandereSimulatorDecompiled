using System;
using UnityEngine;

// Token: 0x020003D7 RID: 983
public class RivalDeskScript : MonoBehaviour
{
	// Token: 0x06001B74 RID: 7028 RVA: 0x0013548D File Offset: 0x0013368D
	private void Start()
	{
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001B75 RID: 7029 RVA: 0x001354A0 File Offset: 0x001336A0
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

	// Token: 0x04002EF6 RID: 12022
	public SchemesScript Schemes;

	// Token: 0x04002EF7 RID: 12023
	public ClockScript Clock;

	// Token: 0x04002EF8 RID: 12024
	public PromptScript Prompt;

	// Token: 0x04002EF9 RID: 12025
	public bool Cheating;
}
