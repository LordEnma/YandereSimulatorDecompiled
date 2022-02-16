using System;
using UnityEngine;

// Token: 0x020003B9 RID: 953
public class PowerSwitchScript : MonoBehaviour
{
	// Token: 0x06001AF0 RID: 6896 RVA: 0x0012A0BA File Offset: 0x001282BA
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

	// Token: 0x06001AF1 RID: 6897 RVA: 0x0012A0F8 File Offset: 0x001282F8
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

	// Token: 0x06001AF2 RID: 6898 RVA: 0x0012A240 File Offset: 0x00128440
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

	// Token: 0x04002D6E RID: 11630
	public DrinkingFountainScript DrinkingFountain;

	// Token: 0x04002D6F RID: 11631
	public PowerOutletScript PowerOutlet;

	// Token: 0x04002D70 RID: 11632
	public GameObject Electricity;

	// Token: 0x04002D71 RID: 11633
	public Light BathroomLight;

	// Token: 0x04002D72 RID: 11634
	public PromptScript Prompt;

	// Token: 0x04002D73 RID: 11635
	public AudioSource MyAudio;

	// Token: 0x04002D74 RID: 11636
	public AudioClip[] Flick;

	// Token: 0x04002D75 RID: 11637
	public bool Haunted;

	// Token: 0x04002D76 RID: 11638
	public bool On;
}
