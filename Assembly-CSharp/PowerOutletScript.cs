using System;
using UnityEngine;

// Token: 0x020003BD RID: 957
public class PowerOutletScript : MonoBehaviour
{
	// Token: 0x06001B11 RID: 6929 RVA: 0x0012C1AC File Offset: 0x0012A3AC
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

	// Token: 0x04002DD6 RID: 11734
	public PromptScript Prompt;

	// Token: 0x04002DD7 RID: 11735
	public PowerSwitchScript PowerSwitch;

	// Token: 0x04002DD8 RID: 11736
	public GameObject PowerStrip;

	// Token: 0x04002DD9 RID: 11737
	public GameObject PluggedOutlet;

	// Token: 0x04002DDA RID: 11738
	public GameObject SabotagedOutlet;

	// Token: 0x04002DDB RID: 11739
	public bool Sabotaged;
}
