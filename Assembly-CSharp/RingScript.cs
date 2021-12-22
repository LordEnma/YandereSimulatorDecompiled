using System;
using UnityEngine;

// Token: 0x020003D2 RID: 978
public class RingScript : MonoBehaviour
{
	// Token: 0x06001B65 RID: 7013 RVA: 0x001349C4 File Offset: 0x00132BC4
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

	// Token: 0x04002ED9 RID: 11993
	public RingEventScript RingEvent;

	// Token: 0x04002EDA RID: 11994
	public PromptScript Prompt;
}
