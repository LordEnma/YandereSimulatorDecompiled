using System;
using UnityEngine;

// Token: 0x020003B8 RID: 952
public class PowerOutletScript : MonoBehaviour
{
	// Token: 0x06001AEE RID: 6894 RVA: 0x00129E40 File Offset: 0x00128040
	private void Update()
	{
		if (this.PowerStrip == null)
		{
			if (this.Prompt.Yandere.PickUp != null)
			{
				if (this.Prompt.Yandere.PickUp.Electronic)
				{
					this.Prompt.enabled = true;
				}
				else if (this.Prompt.enabled)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					this.Prompt.Circle[0].fillAmount = 1f;
					this.PowerStrip = this.Prompt.Yandere.PickUp.gameObject;
					this.Prompt.Yandere.EmptyHands();
					this.PowerStrip.transform.parent = base.transform;
					this.PowerStrip.transform.localPosition = new Vector3(0f, 0f, 0f);
					this.PowerStrip.SetActive(false);
					this.PluggedOutlet.SetActive(true);
					this.Prompt.HideButton[0] = true;
					return;
				}
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				return;
			}
		}
		else if (this.Prompt.Yandere.EquippedWeapon != null)
		{
			if (this.Prompt.Yandere.EquippedWeapon.WeaponID == 6)
			{
				this.Prompt.HideButton[1] = false;
				this.Prompt.enabled = true;
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
			if (this.Prompt.Circle[1].fillAmount == 0f)
			{
				this.Prompt.Circle[1].fillAmount = 1f;
				this.SabotagedOutlet.SetActive(true);
				this.PluggedOutlet.SetActive(false);
				this.PowerSwitch.CheckPuddle();
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				base.enabled = false;
				return;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x04002D68 RID: 11624
	public PromptScript Prompt;

	// Token: 0x04002D69 RID: 11625
	public PowerSwitchScript PowerSwitch;

	// Token: 0x04002D6A RID: 11626
	public GameObject PowerStrip;

	// Token: 0x04002D6B RID: 11627
	public GameObject PluggedOutlet;

	// Token: 0x04002D6C RID: 11628
	public GameObject SabotagedOutlet;

	// Token: 0x04002D6D RID: 11629
	public bool Sabotaged;
}
