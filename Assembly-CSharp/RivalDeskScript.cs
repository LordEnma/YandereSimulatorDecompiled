using System;
using UnityEngine;

// Token: 0x020003DE RID: 990
public class RivalDeskScript : MonoBehaviour
{
	// Token: 0x06001BA2 RID: 7074 RVA: 0x00139E59 File Offset: 0x00138059
	private void Start()
	{
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001BA3 RID: 7075 RVA: 0x00139E6C File Offset: 0x0013806C
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

	// Token: 0x04002F7E RID: 12158
	public SchemesScript Schemes;

	// Token: 0x04002F7F RID: 12159
	public ClockScript Clock;

	// Token: 0x04002F80 RID: 12160
	public PromptScript Prompt;

	// Token: 0x04002F81 RID: 12161
	public bool Cheating;
}
