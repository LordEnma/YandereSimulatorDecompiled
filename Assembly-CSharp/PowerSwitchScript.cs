using System;
using UnityEngine;

// Token: 0x020003B5 RID: 949
public class PowerSwitchScript : MonoBehaviour
{
	// Token: 0x06001AD5 RID: 6869 RVA: 0x001285BE File Offset: 0x001267BE
	private void Start()
	{
		if (this.BathroomLight != null)
		{
			this.Prompt.Label[0].text = "     Turn Off";
		}
	}

	// Token: 0x06001AD6 RID: 6870 RVA: 0x001285E8 File Offset: 0x001267E8
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

	// Token: 0x06001AD7 RID: 6871 RVA: 0x00128730 File Offset: 0x00126930
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

	// Token: 0x04002D26 RID: 11558
	public DrinkingFountainScript DrinkingFountain;

	// Token: 0x04002D27 RID: 11559
	public PowerOutletScript PowerOutlet;

	// Token: 0x04002D28 RID: 11560
	public GameObject Electricity;

	// Token: 0x04002D29 RID: 11561
	public Light BathroomLight;

	// Token: 0x04002D2A RID: 11562
	public PromptScript Prompt;

	// Token: 0x04002D2B RID: 11563
	public AudioSource MyAudio;

	// Token: 0x04002D2C RID: 11564
	public AudioClip[] Flick;

	// Token: 0x04002D2D RID: 11565
	public bool On;
}
