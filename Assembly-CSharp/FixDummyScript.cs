using System;
using UnityEngine;

// Token: 0x020002CD RID: 717
public class FixDummyScript : MonoBehaviour
{
	// Token: 0x060014B6 RID: 5302 RVA: 0x000CC219 File Offset: 0x000CA419
	private void Start()
	{
		this.FixedDummy.SetActive(false);
		if (GameGlobals.Eighties)
		{
			this.Fix();
		}
	}

	// Token: 0x060014B7 RID: 5303 RVA: 0x000CC234 File Offset: 0x000CA434
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (this.Prompt.Yandere.Armed && this.Prompt.Yandere.EquippedWeapon.WeaponID == 24)
			{
				this.Fix();
				return;
			}
			this.Prompt.Yandere.NotificationManager.CustomText = "Wrench required!";
			this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}

	// Token: 0x060014B8 RID: 5304 RVA: 0x000CC2D4 File Offset: 0x000CA4D4
	private void Fix()
	{
		base.gameObject.SetActive(false);
		this.FixedDummy.SetActive(true);
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x0400206E RID: 8302
	public GameObject FixedDummy;

	// Token: 0x0400206F RID: 8303
	public PromptScript Prompt;
}
