using System;
using UnityEngine;

// Token: 0x020002CE RID: 718
public class FixDummyScript : MonoBehaviour
{
	// Token: 0x060014B8 RID: 5304 RVA: 0x000CC579 File Offset: 0x000CA779
	private void Start()
	{
		this.FixedDummy.SetActive(false);
		if (GameGlobals.Eighties)
		{
			this.Fix();
		}
	}

	// Token: 0x060014B9 RID: 5305 RVA: 0x000CC594 File Offset: 0x000CA794
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

	// Token: 0x060014BA RID: 5306 RVA: 0x000CC634 File Offset: 0x000CA834
	private void Fix()
	{
		base.gameObject.SetActive(false);
		this.FixedDummy.SetActive(true);
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x04002075 RID: 8309
	public GameObject FixedDummy;

	// Token: 0x04002076 RID: 8310
	public PromptScript Prompt;
}
