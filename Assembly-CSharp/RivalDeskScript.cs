using System;
using UnityEngine;

// Token: 0x020003E1 RID: 993
public class RivalDeskScript : MonoBehaviour
{
	// Token: 0x06001BBA RID: 7098 RVA: 0x0013BBC9 File Offset: 0x00139DC9
	private void Start()
	{
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001BBB RID: 7099 RVA: 0x0013BBDC File Offset: 0x00139DDC
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

	// Token: 0x04002FB8 RID: 12216
	public SchemesScript Schemes;

	// Token: 0x04002FB9 RID: 12217
	public ClockScript Clock;

	// Token: 0x04002FBA RID: 12218
	public PromptScript Prompt;

	// Token: 0x04002FBB RID: 12219
	public bool Cheating;
}
