using System;
using UnityEngine;

// Token: 0x020003DB RID: 987
public class RivalDeskScript : MonoBehaviour
{
	// Token: 0x06001B98 RID: 7064 RVA: 0x001393E5 File Offset: 0x001375E5
	private void Start()
	{
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001B99 RID: 7065 RVA: 0x001393F8 File Offset: 0x001375F8
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

	// Token: 0x04002F65 RID: 12133
	public SchemesScript Schemes;

	// Token: 0x04002F66 RID: 12134
	public ClockScript Clock;

	// Token: 0x04002F67 RID: 12135
	public PromptScript Prompt;

	// Token: 0x04002F68 RID: 12136
	public bool Cheating;
}
