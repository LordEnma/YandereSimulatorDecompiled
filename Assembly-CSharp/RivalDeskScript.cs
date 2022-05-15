using System;
using UnityEngine;

// Token: 0x020003E1 RID: 993
public class RivalDeskScript : MonoBehaviour
{
	// Token: 0x06001BB9 RID: 7097 RVA: 0x0013B90D File Offset: 0x00139B0D
	private void Start()
	{
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001BBA RID: 7098 RVA: 0x0013B920 File Offset: 0x00139B20
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

	// Token: 0x04002FB0 RID: 12208
	public SchemesScript Schemes;

	// Token: 0x04002FB1 RID: 12209
	public ClockScript Clock;

	// Token: 0x04002FB2 RID: 12210
	public PromptScript Prompt;

	// Token: 0x04002FB3 RID: 12211
	public bool Cheating;
}
