using System;
using UnityEngine;

// Token: 0x020002CD RID: 717
public class FixDummyScript : MonoBehaviour
{
	// Token: 0x060014B2 RID: 5298 RVA: 0x000CBD51 File Offset: 0x000C9F51
	private void Start()
	{
		this.FixedDummy.SetActive(false);
		if (GameGlobals.Eighties)
		{
			this.Fix();
		}
	}

	// Token: 0x060014B3 RID: 5299 RVA: 0x000CBD6C File Offset: 0x000C9F6C
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

	// Token: 0x060014B4 RID: 5300 RVA: 0x000CBE0C File Offset: 0x000CA00C
	private void Fix()
	{
		base.gameObject.SetActive(false);
		this.FixedDummy.SetActive(true);
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x04002065 RID: 8293
	public GameObject FixedDummy;

	// Token: 0x04002066 RID: 8294
	public PromptScript Prompt;
}
