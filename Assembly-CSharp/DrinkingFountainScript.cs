using System;
using UnityEngine;

// Token: 0x02000291 RID: 657
public class DrinkingFountainScript : MonoBehaviour
{
	// Token: 0x060013C1 RID: 5057 RVA: 0x000BAE5C File Offset: 0x000B905C
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

	// Token: 0x04001D58 RID: 7512
	public PowerSwitchScript PowerSwitch;

	// Token: 0x04001D59 RID: 7513
	public ParticleSystem WaterStream;

	// Token: 0x04001D5A RID: 7514
	public ParticleSystem WaterBlast;

	// Token: 0x04001D5B RID: 7515
	public Transform DrinkPosition;

	// Token: 0x04001D5C RID: 7516
	public GameObject WaterCollider;

	// Token: 0x04001D5D RID: 7517
	public GameObject Puddle;

	// Token: 0x04001D5E RID: 7518
	public GameObject Leak;

	// Token: 0x04001D5F RID: 7519
	public PromptScript Prompt;

	// Token: 0x04001D60 RID: 7520
	public AudioSource MyAudio;

	// Token: 0x04001D61 RID: 7521
	public bool Sabotagable;

	// Token: 0x04001D62 RID: 7522
	public bool Sabotaged;

	// Token: 0x04001D63 RID: 7523
	public bool Occupied;
}
