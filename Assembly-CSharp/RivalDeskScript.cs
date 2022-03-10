using System;
using UnityEngine;

// Token: 0x020003DA RID: 986
public class RivalDeskScript : MonoBehaviour
{
	// Token: 0x06001B8B RID: 7051 RVA: 0x00138541 File Offset: 0x00136741
	private void Start()
	{
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001B8C RID: 7052 RVA: 0x00138554 File Offset: 0x00136754
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

	// Token: 0x04002F31 RID: 12081
	public SchemesScript Schemes;

	// Token: 0x04002F32 RID: 12082
	public ClockScript Clock;

	// Token: 0x04002F33 RID: 12083
	public PromptScript Prompt;

	// Token: 0x04002F34 RID: 12084
	public bool Cheating;
}
