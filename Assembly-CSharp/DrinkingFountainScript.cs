using System;
using UnityEngine;

// Token: 0x02000291 RID: 657
public class DrinkingFountainScript : MonoBehaviour
{
	// Token: 0x060013C1 RID: 5057 RVA: 0x000BAFC4 File Offset: 0x000B91C4
	private void Update()
	{
		if (this.Prompt.Yandere.EquippedWeapon != null)
		{
			if (this.Prompt.Yandere.EquippedWeapon.Blood.enabled)
			{
				this.Prompt.HideButton[0] = false;
				this.Prompt.enabled = true;
			}
			else
			{
				this.Prompt.HideButton[0] = true;
			}
			if (!this.Leak.activeInHierarchy)
			{
				if (this.Prompt.Yandere.EquippedWeapon.WeaponID == 24)
				{
					this.Prompt.HideButton[1] = false;
					if (this.Sabotagable && !this.Sabotaged)
					{
						this.Prompt.HideButton[2] = false;
					}
					else
					{
						this.Prompt.HideButton[2] = true;
					}
					this.Prompt.enabled = true;
				}
				else
				{
					this.Prompt.HideButton[1] = true;
					this.Prompt.HideButton[2] = true;
				}
			}
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				this.Prompt.Yandere.CharacterAnimation.CrossFade("f02_cleaningWeapon_00");
				this.Prompt.Yandere.Target = this.DrinkPosition;
				this.Prompt.Yandere.CleaningWeapon = true;
				this.Prompt.Yandere.CanMove = false;
				this.WaterStream.Play();
			}
			if (this.Prompt.Circle[1].fillAmount == 0f)
			{
				this.Prompt.HideButton[1] = true;
				this.Puddle.SetActive(true);
				this.Leak.SetActive(true);
				this.MyAudio.Play();
				this.PowerSwitch.CheckPuddle();
			}
			if (this.Prompt.Circle[2].fillAmount == 0f)
			{
				this.Prompt.HideButton[2] = true;
				this.Sabotaged = true;
				this.MyAudio.Play();
				return;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x04001D61 RID: 7521
	public PowerSwitchScript PowerSwitch;

	// Token: 0x04001D62 RID: 7522
	public ParticleSystem WaterStream;

	// Token: 0x04001D63 RID: 7523
	public ParticleSystem WaterBlast;

	// Token: 0x04001D64 RID: 7524
	public Transform DrinkPosition;

	// Token: 0x04001D65 RID: 7525
	public GameObject WaterCollider;

	// Token: 0x04001D66 RID: 7526
	public GameObject Puddle;

	// Token: 0x04001D67 RID: 7527
	public GameObject Leak;

	// Token: 0x04001D68 RID: 7528
	public PromptScript Prompt;

	// Token: 0x04001D69 RID: 7529
	public AudioSource MyAudio;

	// Token: 0x04001D6A RID: 7530
	public bool Sabotagable;

	// Token: 0x04001D6B RID: 7531
	public bool Sabotaged;

	// Token: 0x04001D6C RID: 7532
	public bool Occupied;
}
