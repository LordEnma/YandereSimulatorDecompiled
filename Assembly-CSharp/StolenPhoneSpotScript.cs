using System;
using UnityEngine;

// Token: 0x0200044D RID: 1101
public class StolenPhoneSpotScript : MonoBehaviour
{
	// Token: 0x06001D41 RID: 7489 RVA: 0x0015E858 File Offset: 0x0015CA58
	private void Update()
	{
		if (this.Prompt.Yandere.Inventory.RivalPhone)
		{
			this.Prompt.enabled = true;
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				if (this.Prompt.Yandere.StudentManager.Students[this.RivalPhone.StudentID] != null && this.Prompt.Yandere.StudentManager.Students[this.RivalPhone.StudentID].Phoneless)
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

	// Token: 0x04003563 RID: 13667
	public RivalPhoneScript RivalPhone;

	// Token: 0x04003564 RID: 13668
	public PromptScript Prompt;

	// Token: 0x04003565 RID: 13669
	public Transform PhoneSpot;
}
