using System;
using UnityEngine;

// Token: 0x0200028D RID: 653
public class DrinkingFountainScript : MonoBehaviour
{
	// Token: 0x060013A9 RID: 5033 RVA: 0x000B9A54 File Offset: 0x000B7C54
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

	// Token: 0x04001D19 RID: 7449
	public PowerSwitchScript PowerSwitch;

	// Token: 0x04001D1A RID: 7450
	public ParticleSystem WaterStream;

	// Token: 0x04001D1B RID: 7451
	public ParticleSystem WaterBlast;

	// Token: 0x04001D1C RID: 7452
	public Transform DrinkPosition;

	// Token: 0x04001D1D RID: 7453
	public GameObject WaterCollider;

	// Token: 0x04001D1E RID: 7454
	public GameObject Puddle;

	// Token: 0x04001D1F RID: 7455
	public GameObject Leak;

	// Token: 0x04001D20 RID: 7456
	public PromptScript Prompt;

	// Token: 0x04001D21 RID: 7457
	public AudioSource MyAudio;

	// Token: 0x04001D22 RID: 7458
	public bool Sabotagable;

	// Token: 0x04001D23 RID: 7459
	public bool Sabotaged;

	// Token: 0x04001D24 RID: 7460
	public bool Occupied;
}
