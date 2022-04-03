using System;
using UnityEngine;

// Token: 0x0200044C RID: 1100
public class StolenPhoneSpotScript : MonoBehaviour
{
	// Token: 0x06001D3A RID: 7482 RVA: 0x0015E538 File Offset: 0x0015C738
	private void Update()
	{
		if (this.Prompt.Yandere.Inventory.RivalPhone)
		{
			this.Prompt.enabled = true;
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				if (this.Prompt.Yandere.StudentManager.Students[this.Prompt.Yandere.StudentManager.RivalID] != null && this.Prompt.Yandere.StudentManager.Students[this.Prompt.Yandere.StudentManager.RivalID].Phoneless)
				{
					if (this.RivalPhone.StudentID == this.Prompt.Yandere.StudentManager.RivalID && SchemeGlobals.GetSchemeStage(1) == 6)
					{
						SchemeGlobals.SetSchemeStage(1, 7);
						this.Prompt.Yandere.PauseScreen.Schemes.UpdateInstructions();
					}
					this.Prompt.Yandere.SmartphoneRenderer.material.mainTexture = this.Prompt.Yandere.YanderePhoneTexture;
					this.Prompt.Yandere.Inventory.RivalPhone = false;
					this.Prompt.Yandere.RivalPhone = false;
					this.RivalPhone.StolenPhoneDropoff.Prompt.enabled = false;
					this.RivalPhone.StolenPhoneDropoff.Prompt.Hide();
					this.RivalPhone.transform.parent = null;
					if (this.PhoneSpot == null)
					{
						this.RivalPhone.transform.position = base.transform.position;
					}
					else
					{
						this.RivalPhone.transform.position = this.PhoneSpot.position;
					}
					this.RivalPhone.transform.eulerAngles = base.transform.eulerAngles;
					this.RivalPhone.gameObject.SetActive(true);
					base.gameObject.SetActive(false);
					return;
				}
				this.Prompt.Yandere.NotificationManager.CustomText = "Wait a few more moments first...";
				this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				return;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.enabled = false;
			this.Prompt.Hide();
		}
	}

	// Token: 0x04003560 RID: 13664
	public RivalPhoneScript RivalPhone;

	// Token: 0x04003561 RID: 13665
	public PromptScript Prompt;

	// Token: 0x04003562 RID: 13666
	public Transform PhoneSpot;
}
