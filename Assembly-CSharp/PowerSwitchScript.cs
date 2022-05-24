using System;
using UnityEngine;

// Token: 0x020003BF RID: 959
public class PowerSwitchScript : MonoBehaviour
{
	// Token: 0x06001B22 RID: 6946 RVA: 0x0012DC26 File Offset: 0x0012BE26
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

	// Token: 0x06001B23 RID: 6947 RVA: 0x0012DC64 File Offset: 0x0012BE64
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

	// Token: 0x06001B24 RID: 6948 RVA: 0x0012DDAC File Offset: 0x0012BFAC
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

	// Token: 0x04002E0D RID: 11789
	public DrinkingFountainScript DrinkingFountain;

	// Token: 0x04002E0E RID: 11790
	public PowerOutletScript PowerOutlet;

	// Token: 0x04002E0F RID: 11791
	public GameObject Electricity;

	// Token: 0x04002E10 RID: 11792
	public Light BathroomLight;

	// Token: 0x04002E11 RID: 11793
	public PromptScript Prompt;

	// Token: 0x04002E12 RID: 11794
	public AudioSource MyAudio;

	// Token: 0x04002E13 RID: 11795
	public AudioClip[] Flick;

	// Token: 0x04002E14 RID: 11796
	public bool Haunted;

	// Token: 0x04002E15 RID: 11797
	public bool On;
}
