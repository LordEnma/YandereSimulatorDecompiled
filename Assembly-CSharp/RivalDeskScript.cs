using System;
using UnityEngine;

// Token: 0x020003DA RID: 986
public class RivalDeskScript : MonoBehaviour
{
	// Token: 0x06001B89 RID: 7049 RVA: 0x0013801D File Offset: 0x0013621D
	private void Start()
	{
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001B8A RID: 7050 RVA: 0x00138030 File Offset: 0x00136230
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

	// Token: 0x04002F1B RID: 12059
	public SchemesScript Schemes;

	// Token: 0x04002F1C RID: 12060
	public ClockScript Clock;

	// Token: 0x04002F1D RID: 12061
	public PromptScript Prompt;

	// Token: 0x04002F1E RID: 12062
	public bool Cheating;
}
