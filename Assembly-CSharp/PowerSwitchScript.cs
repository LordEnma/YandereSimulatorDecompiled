using System;
using UnityEngine;

// Token: 0x020003BF RID: 959
public class PowerSwitchScript : MonoBehaviour
{
	// Token: 0x06001B21 RID: 6945 RVA: 0x0012D9BE File Offset: 0x0012BBBE
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

	// Token: 0x06001B22 RID: 6946 RVA: 0x0012D9FC File Offset: 0x0012BBFC
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

	// Token: 0x06001B23 RID: 6947 RVA: 0x0012DB44 File Offset: 0x0012BD44
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

	// Token: 0x04002E05 RID: 11781
	public DrinkingFountainScript DrinkingFountain;

	// Token: 0x04002E06 RID: 11782
	public PowerOutletScript PowerOutlet;

	// Token: 0x04002E07 RID: 11783
	public GameObject Electricity;

	// Token: 0x04002E08 RID: 11784
	public Light BathroomLight;

	// Token: 0x04002E09 RID: 11785
	public PromptScript Prompt;

	// Token: 0x04002E0A RID: 11786
	public AudioSource MyAudio;

	// Token: 0x04002E0B RID: 11787
	public AudioClip[] Flick;

	// Token: 0x04002E0C RID: 11788
	public bool Haunted;

	// Token: 0x04002E0D RID: 11789
	public bool On;
}
