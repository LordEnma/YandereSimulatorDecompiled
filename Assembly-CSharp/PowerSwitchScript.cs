using System;
using UnityEngine;

// Token: 0x020003BE RID: 958
public class PowerSwitchScript : MonoBehaviour
{
	// Token: 0x06001B1B RID: 6939 RVA: 0x0012CE4A File Offset: 0x0012B04A
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

	// Token: 0x06001B1C RID: 6940 RVA: 0x0012CE88 File Offset: 0x0012B088
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

	// Token: 0x06001B1D RID: 6941 RVA: 0x0012CFD0 File Offset: 0x0012B1D0
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

	// Token: 0x04002DF0 RID: 11760
	public DrinkingFountainScript DrinkingFountain;

	// Token: 0x04002DF1 RID: 11761
	public PowerOutletScript PowerOutlet;

	// Token: 0x04002DF2 RID: 11762
	public GameObject Electricity;

	// Token: 0x04002DF3 RID: 11763
	public Light BathroomLight;

	// Token: 0x04002DF4 RID: 11764
	public PromptScript Prompt;

	// Token: 0x04002DF5 RID: 11765
	public AudioSource MyAudio;

	// Token: 0x04002DF6 RID: 11766
	public AudioClip[] Flick;

	// Token: 0x04002DF7 RID: 11767
	public bool Haunted;

	// Token: 0x04002DF8 RID: 11768
	public bool On;
}
