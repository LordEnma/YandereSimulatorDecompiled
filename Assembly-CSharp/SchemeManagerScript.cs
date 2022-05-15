using System;
using UnityEngine;

// Token: 0x02000417 RID: 1047
public class SchemeManagerScript : MonoBehaviour
{
	// Token: 0x06001C83 RID: 7299 RVA: 0x0014E794 File Offset: 0x0014C994
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

	// Token: 0x040032B4 RID: 12980
	public SchemesScript Schemes;

	// Token: 0x040032B5 RID: 12981
	public ClockScript Clock;

	// Token: 0x040032B6 RID: 12982
	public bool ClockCheck;

	// Token: 0x040032B7 RID: 12983
	public float Timer;

	// Token: 0x040032B8 RID: 12984
	public int CurrentScheme;
}
