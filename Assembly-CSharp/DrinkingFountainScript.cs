using System;
using UnityEngine;

// Token: 0x0200028F RID: 655
public class DrinkingFountainScript : MonoBehaviour
{
	// Token: 0x060013B4 RID: 5044 RVA: 0x000BA544 File Offset: 0x000B8744
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

	// Token: 0x04001D43 RID: 7491
	public PowerSwitchScript PowerSwitch;

	// Token: 0x04001D44 RID: 7492
	public ParticleSystem WaterStream;

	// Token: 0x04001D45 RID: 7493
	public ParticleSystem WaterBlast;

	// Token: 0x04001D46 RID: 7494
	public Transform DrinkPosition;

	// Token: 0x04001D47 RID: 7495
	public GameObject WaterCollider;

	// Token: 0x04001D48 RID: 7496
	public GameObject Puddle;

	// Token: 0x04001D49 RID: 7497
	public GameObject Leak;

	// Token: 0x04001D4A RID: 7498
	public PromptScript Prompt;

	// Token: 0x04001D4B RID: 7499
	public AudioSource MyAudio;

	// Token: 0x04001D4C RID: 7500
	public bool Sabotagable;

	// Token: 0x04001D4D RID: 7501
	public bool Sabotaged;

	// Token: 0x04001D4E RID: 7502
	public bool Occupied;
}
