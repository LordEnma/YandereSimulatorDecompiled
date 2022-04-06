using System;
using UnityEngine;

// Token: 0x020002CD RID: 717
public class FixDummyScript : MonoBehaviour
{
	// Token: 0x060014B2 RID: 5298 RVA: 0x000CBBA8 File Offset: 0x000C9DA8
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (this.Prompt.Yandere.Armed && this.Prompt.Yandere.EquippedWeapon.WeaponID == 24)
			{
				base.gameObject.SetActive(false);
				this.FixedDummy.SetActive(true);
				this.Prompt.enabled = false;
				this.Prompt.Hide();
				return;
			}
			this.Prompt.Yandere.NotificationManager.CustomText = "Wrench required!";
			this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}

	// Token: 0x04002063 RID: 8291
	public GameObject FixedDummy;

	// Token: 0x04002064 RID: 8292
	public PromptScript Prompt;
}
