using System;
using UnityEngine;

// Token: 0x02000442 RID: 1090
public class StolenPhoneSpotScript : MonoBehaviour
{
	// Token: 0x06001CF7 RID: 7415 RVA: 0x00158054 File Offset: 0x00156254
	private void Update()
	{
		if (this.Prompt.Yandere.Inventory.RivalPhone)
		{
			this.Prompt.enabled = true;
			if (this.Prompt.Circle[0].fillAmount == 0f)
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
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.enabled = false;
			this.Prompt.Hide();
		}
	}

	// Token: 0x04003486 RID: 13446
	public RivalPhoneScript RivalPhone;

	// Token: 0x04003487 RID: 13447
	public PromptScript Prompt;

	// Token: 0x04003488 RID: 13448
	public Transform PhoneSpot;
}
