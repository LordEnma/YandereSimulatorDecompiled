using System;
using UnityEngine;

// Token: 0x020003D8 RID: 984
public class RivalDeskScript : MonoBehaviour
{
	// Token: 0x06001B76 RID: 7030 RVA: 0x00136B95 File Offset: 0x00134D95
	private void Start()
	{
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001B77 RID: 7031 RVA: 0x00136BA8 File Offset: 0x00134DA8
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

	// Token: 0x04002EFB RID: 12027
	public SchemesScript Schemes;

	// Token: 0x04002EFC RID: 12028
	public ClockScript Clock;

	// Token: 0x04002EFD RID: 12029
	public PromptScript Prompt;

	// Token: 0x04002EFE RID: 12030
	public bool Cheating;
}
