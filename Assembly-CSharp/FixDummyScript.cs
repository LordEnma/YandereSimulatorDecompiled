using System;
using UnityEngine;

// Token: 0x020002CC RID: 716
public class FixDummyScript : MonoBehaviour
{
	// Token: 0x060014AC RID: 5292 RVA: 0x000CBAA0 File Offset: 0x000C9CA0
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

	// Token: 0x04002061 RID: 8289
	public GameObject FixedDummy;

	// Token: 0x04002062 RID: 8290
	public PromptScript Prompt;
}
