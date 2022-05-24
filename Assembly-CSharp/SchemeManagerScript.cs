using System;
using UnityEngine;

// Token: 0x02000417 RID: 1047
public class SchemeManagerScript : MonoBehaviour
{
	// Token: 0x06001C84 RID: 7300 RVA: 0x0014EA50 File Offset: 0x0014CC50
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

	// Token: 0x040032BC RID: 12988
	public SchemesScript Schemes;

	// Token: 0x040032BD RID: 12989
	public ClockScript Clock;

	// Token: 0x040032BE RID: 12990
	public bool ClockCheck;

	// Token: 0x040032BF RID: 12991
	public float Timer;

	// Token: 0x040032C0 RID: 12992
	public int CurrentScheme;
}
