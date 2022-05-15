using System;
using UnityEngine;

// Token: 0x02000293 RID: 659
public class DrinkingFountainScript : MonoBehaviour
{
	// Token: 0x060013D1 RID: 5073 RVA: 0x000BBE58 File Offset: 0x000BA058
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

	// Token: 0x04001D86 RID: 7558
	public PowerSwitchScript PowerSwitch;

	// Token: 0x04001D87 RID: 7559
	public ParticleSystem WaterStream;

	// Token: 0x04001D88 RID: 7560
	public ParticleSystem WaterBlast;

	// Token: 0x04001D89 RID: 7561
	public Transform DrinkPosition;

	// Token: 0x04001D8A RID: 7562
	public GameObject WaterCollider;

	// Token: 0x04001D8B RID: 7563
	public GameObject Puddle;

	// Token: 0x04001D8C RID: 7564
	public GameObject Leak;

	// Token: 0x04001D8D RID: 7565
	public PromptScript Prompt;

	// Token: 0x04001D8E RID: 7566
	public AudioSource MyAudio;

	// Token: 0x04001D8F RID: 7567
	public bool Sabotagable;

	// Token: 0x04001D90 RID: 7568
	public bool Sabotaged;

	// Token: 0x04001D91 RID: 7569
	public bool Occupied;
}
