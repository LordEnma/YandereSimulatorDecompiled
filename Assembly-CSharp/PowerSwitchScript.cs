using System;
using UnityEngine;

// Token: 0x020003B6 RID: 950
public class PowerSwitchScript : MonoBehaviour
{
	// Token: 0x06001ADD RID: 6877 RVA: 0x00128E12 File Offset: 0x00127012
	private void Start()
	{
		if (this.BathroomLight != null)
		{
			this.Prompt.Label[0].text = "     Turn Off";
		}
	}

	// Token: 0x06001ADE RID: 6878 RVA: 0x00128E3C File Offset: 0x0012703C
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.On = !this.On;
			if (this.BathroomLight == null)
			{
				if (this.On)
				{
					this.Prompt.Label[0].text = "     Turn Off";
					this.MyAudio.clip = this.Flick[1];
				}
				else
				{
					this.Prompt.Label[0].text = "     Turn On";
					this.MyAudio.clip = this.Flick[0];
				}
			}
			else
			{
				if (this.On)
				{
					this.Prompt.Label[0].text = "     Turn On";
					this.MyAudio.clip = this.Flick[1];
				}
				else
				{
					this.Prompt.Label[0].text = "     Turn Off";
					this.MyAudio.clip = this.Flick[0];
				}
				this.BathroomLight.enabled = !this.BathroomLight.enabled;
			}
			this.CheckPuddle();
			this.MyAudio.Play();
		}
	}

	// Token: 0x06001ADF RID: 6879 RVA: 0x00128F84 File Offset: 0x00127184
	public void CheckPuddle()
	{
		if (this.On)
		{
			if (this.DrinkingFountain.Puddle != null && this.DrinkingFountain.Puddle.gameObject.activeInHierarchy && this.PowerOutlet.SabotagedOutlet.activeInHierarchy)
			{
				this.Electricity.SetActive(true);
				return;
			}
		}
		else
		{
			this.Electricity.SetActive(false);
		}
	}

	// Token: 0x04002D50 RID: 11600
	public DrinkingFountainScript DrinkingFountain;

	// Token: 0x04002D51 RID: 11601
	public PowerOutletScript PowerOutlet;

	// Token: 0x04002D52 RID: 11602
	public GameObject Electricity;

	// Token: 0x04002D53 RID: 11603
	public Light BathroomLight;

	// Token: 0x04002D54 RID: 11604
	public PromptScript Prompt;

	// Token: 0x04002D55 RID: 11605
	public AudioSource MyAudio;

	// Token: 0x04002D56 RID: 11606
	public AudioClip[] Flick;

	// Token: 0x04002D57 RID: 11607
	public bool On;
}
