using System;
using UnityEngine;

// Token: 0x0200028E RID: 654
public class DrinkingFountainScript : MonoBehaviour
{
	// Token: 0x060013B0 RID: 5040 RVA: 0x000BA238 File Offset: 0x000B8438
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

	// Token: 0x04001D3C RID: 7484
	public PowerSwitchScript PowerSwitch;

	// Token: 0x04001D3D RID: 7485
	public ParticleSystem WaterStream;

	// Token: 0x04001D3E RID: 7486
	public ParticleSystem WaterBlast;

	// Token: 0x04001D3F RID: 7487
	public Transform DrinkPosition;

	// Token: 0x04001D40 RID: 7488
	public GameObject WaterCollider;

	// Token: 0x04001D41 RID: 7489
	public GameObject Puddle;

	// Token: 0x04001D42 RID: 7490
	public GameObject Leak;

	// Token: 0x04001D43 RID: 7491
	public PromptScript Prompt;

	// Token: 0x04001D44 RID: 7492
	public AudioSource MyAudio;

	// Token: 0x04001D45 RID: 7493
	public bool Sabotagable;

	// Token: 0x04001D46 RID: 7494
	public bool Sabotaged;

	// Token: 0x04001D47 RID: 7495
	public bool Occupied;
}
