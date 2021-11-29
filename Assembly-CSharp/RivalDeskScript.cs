using System;
using UnityEngine;

// Token: 0x020003D4 RID: 980
public class RivalDeskScript : MonoBehaviour
{
	// Token: 0x06001B63 RID: 7011 RVA: 0x00134435 File Offset: 0x00132635
	private void Start()
	{
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001B64 RID: 7012 RVA: 0x00134448 File Offset: 0x00132648
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

	// Token: 0x04002EBF RID: 11967
	public SchemesScript Schemes;

	// Token: 0x04002EC0 RID: 11968
	public ClockScript Clock;

	// Token: 0x04002EC1 RID: 11969
	public PromptScript Prompt;

	// Token: 0x04002EC2 RID: 11970
	public bool Cheating;
}
