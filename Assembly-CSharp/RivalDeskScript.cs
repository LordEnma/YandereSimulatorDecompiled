using System;
using UnityEngine;

// Token: 0x020003E0 RID: 992
public class RivalDeskScript : MonoBehaviour
{
	// Token: 0x06001BB3 RID: 7091 RVA: 0x0013AD51 File Offset: 0x00138F51
	private void Start()
	{
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001BB4 RID: 7092 RVA: 0x0013AD64 File Offset: 0x00138F64
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

	// Token: 0x04002F9B RID: 12187
	public SchemesScript Schemes;

	// Token: 0x04002F9C RID: 12188
	public ClockScript Clock;

	// Token: 0x04002F9D RID: 12189
	public PromptScript Prompt;

	// Token: 0x04002F9E RID: 12190
	public bool Cheating;
}
