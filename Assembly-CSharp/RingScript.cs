using System;
using UnityEngine;

// Token: 0x020003D5 RID: 981
public class RingScript : MonoBehaviour
{
	// Token: 0x06001B73 RID: 7027 RVA: 0x00136F44 File Offset: 0x00135144
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
			if (!this.Prompt.Yandere.StudentManager.YandereVisible)
			{
				SchemeGlobals.SetSchemeStage(2, 2);
				this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.Ring = true;
				this.Prompt.Yandere.TheftTimer = 0.1f;
				this.RingEvent.RingStolen = true;
				base.gameObject.SetActive(false);
				return;
			}
			this.Prompt.Yandere.NotificationManager.CustomText = "Can't do that! Someone is watching!";
			this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}

	// Token: 0x04002EF5 RID: 12021
	public RingEventScript RingEvent;

	// Token: 0x04002EF6 RID: 12022
	public PromptScript Prompt;
}
