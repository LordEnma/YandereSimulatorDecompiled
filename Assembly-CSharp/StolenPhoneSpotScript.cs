using System;
using UnityEngine;

// Token: 0x02000447 RID: 1095
public class StolenPhoneSpotScript : MonoBehaviour
{
	// Token: 0x06001D17 RID: 7447 RVA: 0x0015B7C4 File Offset: 0x001599C4
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

	// Token: 0x040034E2 RID: 13538
	public RivalPhoneScript RivalPhone;

	// Token: 0x040034E3 RID: 13539
	public PromptScript Prompt;

	// Token: 0x040034E4 RID: 13540
	public Transform PhoneSpot;
}
