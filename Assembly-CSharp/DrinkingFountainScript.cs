using System;
using UnityEngine;

// Token: 0x02000292 RID: 658
public class DrinkingFountainScript : MonoBehaviour
{
	// Token: 0x060013CF RID: 5071 RVA: 0x000BBC18 File Offset: 0x000B9E18
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

	// Token: 0x04001D7F RID: 7551
	public PowerSwitchScript PowerSwitch;

	// Token: 0x04001D80 RID: 7552
	public ParticleSystem WaterStream;

	// Token: 0x04001D81 RID: 7553
	public ParticleSystem WaterBlast;

	// Token: 0x04001D82 RID: 7554
	public Transform DrinkPosition;

	// Token: 0x04001D83 RID: 7555
	public GameObject WaterCollider;

	// Token: 0x04001D84 RID: 7556
	public GameObject Puddle;

	// Token: 0x04001D85 RID: 7557
	public GameObject Leak;

	// Token: 0x04001D86 RID: 7558
	public PromptScript Prompt;

	// Token: 0x04001D87 RID: 7559
	public AudioSource MyAudio;

	// Token: 0x04001D88 RID: 7560
	public bool Sabotagable;

	// Token: 0x04001D89 RID: 7561
	public bool Sabotaged;

	// Token: 0x04001D8A RID: 7562
	public bool Occupied;
}
