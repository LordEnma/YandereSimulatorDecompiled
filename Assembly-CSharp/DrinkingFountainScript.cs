using System;
using UnityEngine;

// Token: 0x02000291 RID: 657
public class DrinkingFountainScript : MonoBehaviour
{
	// Token: 0x060013C5 RID: 5061 RVA: 0x000BB4E8 File Offset: 0x000B96E8
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

	// Token: 0x04001D73 RID: 7539
	public PowerSwitchScript PowerSwitch;

	// Token: 0x04001D74 RID: 7540
	public ParticleSystem WaterStream;

	// Token: 0x04001D75 RID: 7541
	public ParticleSystem WaterBlast;

	// Token: 0x04001D76 RID: 7542
	public Transform DrinkPosition;

	// Token: 0x04001D77 RID: 7543
	public GameObject WaterCollider;

	// Token: 0x04001D78 RID: 7544
	public GameObject Puddle;

	// Token: 0x04001D79 RID: 7545
	public GameObject Leak;

	// Token: 0x04001D7A RID: 7546
	public PromptScript Prompt;

	// Token: 0x04001D7B RID: 7547
	public AudioSource MyAudio;

	// Token: 0x04001D7C RID: 7548
	public bool Sabotagable;

	// Token: 0x04001D7D RID: 7549
	public bool Sabotaged;

	// Token: 0x04001D7E RID: 7550
	public bool Occupied;
}
