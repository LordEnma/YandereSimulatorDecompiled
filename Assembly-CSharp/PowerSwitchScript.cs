using System;
using UnityEngine;

// Token: 0x020003BA RID: 954
public class PowerSwitchScript : MonoBehaviour
{
	// Token: 0x06001AF9 RID: 6905 RVA: 0x0012AAFA File Offset: 0x00128CFA
	private void Start()
	{
		if (this.BathroomLight != null)
		{
			this.Prompt.Label[0].text = "     Turn Off";
		}
		if (!GameGlobals.Eighties && this.Haunted)
		{
			this.BathroomLight = null;
		}
	}

	// Token: 0x06001AFA RID: 6906 RVA: 0x0012AB38 File Offset: 0x00128D38
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

	// Token: 0x06001AFB RID: 6907 RVA: 0x0012AC80 File Offset: 0x00128E80
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

	// Token: 0x04002D7E RID: 11646
	public DrinkingFountainScript DrinkingFountain;

	// Token: 0x04002D7F RID: 11647
	public PowerOutletScript PowerOutlet;

	// Token: 0x04002D80 RID: 11648
	public GameObject Electricity;

	// Token: 0x04002D81 RID: 11649
	public Light BathroomLight;

	// Token: 0x04002D82 RID: 11650
	public PromptScript Prompt;

	// Token: 0x04002D83 RID: 11651
	public AudioSource MyAudio;

	// Token: 0x04002D84 RID: 11652
	public AudioClip[] Flick;

	// Token: 0x04002D85 RID: 11653
	public bool Haunted;

	// Token: 0x04002D86 RID: 11654
	public bool On;
}
