using System;
using UnityEngine;

// Token: 0x020003DF RID: 991
public class RivalDeskScript : MonoBehaviour
{
	// Token: 0x06001BA8 RID: 7080 RVA: 0x0013A13D File Offset: 0x0013833D
	private void Start()
	{
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001BA9 RID: 7081 RVA: 0x0013A150 File Offset: 0x00138350
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

	// Token: 0x04002F81 RID: 12161
	public SchemesScript Schemes;

	// Token: 0x04002F82 RID: 12162
	public ClockScript Clock;

	// Token: 0x04002F83 RID: 12163
	public PromptScript Prompt;

	// Token: 0x04002F84 RID: 12164
	public bool Cheating;
}
