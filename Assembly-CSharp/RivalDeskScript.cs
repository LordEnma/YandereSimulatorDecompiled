using System;
using UnityEngine;

// Token: 0x020003DF RID: 991
public class RivalDeskScript : MonoBehaviour
{
	// Token: 0x06001BAC RID: 7084 RVA: 0x0013A54D File Offset: 0x0013874D
	private void Start()
	{
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001BAD RID: 7085 RVA: 0x0013A560 File Offset: 0x00138760
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

	// Token: 0x04002F8C RID: 12172
	public SchemesScript Schemes;

	// Token: 0x04002F8D RID: 12173
	public ClockScript Clock;

	// Token: 0x04002F8E RID: 12174
	public PromptScript Prompt;

	// Token: 0x04002F8F RID: 12175
	public bool Cheating;
}
