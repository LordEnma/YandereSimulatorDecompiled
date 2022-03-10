using System;
using UnityEngine;

// Token: 0x02000410 RID: 1040
public class SchemeManagerScript : MonoBehaviour
{
	// Token: 0x06001C55 RID: 7253 RVA: 0x0014B21C File Offset: 0x0014941C
	private void Update()
	{
		if (this.CurrentScheme < 6)
		{
			if (this.Clock.HourTime > 15.5f)
			{
				SchemeGlobals.SetSchemeStage(SchemeGlobals.CurrentScheme, 100);
				this.Clock.Yandere.NotificationManager.CustomText = "Scheme failed! You were too slow.";
				this.Clock.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				this.Schemes.UpdateInstructions();
				base.enabled = false;
			}
		}
		else if (this.CurrentScheme > 6 && Input.GetButton("A"))
		{
			if (Input.GetButtonDown("LB"))
			{
				SchemeGlobals.SetSchemeStage(this.CurrentScheme, SchemeGlobals.GetSchemeStage(this.CurrentScheme) - 1);
				this.Schemes.UpdateInstructions();
			}
			else if (Input.GetButtonDown("RB"))
			{
				SchemeGlobals.SetSchemeStage(this.CurrentScheme, SchemeGlobals.GetSchemeStage(this.CurrentScheme) + 1);
				this.Schemes.UpdateInstructions();
			}
		}
		if (this.ClockCheck && this.Clock.HourTime > 8.25f)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				this.Timer = 0f;
				if (SchemeGlobals.GetSchemeStage(5) == 1)
				{
					Debug.Log("It's past 8:15 AM, so we're advancing to Stage 2 of Scheme 5.");
					SchemeGlobals.SetSchemeStage(5, 2);
					this.Schemes.UpdateInstructions();
					this.ClockCheck = false;
				}
			}
		}
	}

	// Token: 0x04003232 RID: 12850
	public SchemesScript Schemes;

	// Token: 0x04003233 RID: 12851
	public ClockScript Clock;

	// Token: 0x04003234 RID: 12852
	public bool ClockCheck;

	// Token: 0x04003235 RID: 12853
	public float Timer;

	// Token: 0x04003236 RID: 12854
	public int CurrentScheme;
}
