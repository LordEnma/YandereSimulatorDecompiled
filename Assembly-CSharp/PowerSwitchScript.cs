using System;
using UnityEngine;

// Token: 0x020003BE RID: 958
public class PowerSwitchScript : MonoBehaviour
{
	// Token: 0x06001B17 RID: 6935 RVA: 0x0012C836 File Offset: 0x0012AA36
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

	// Token: 0x06001B18 RID: 6936 RVA: 0x0012C874 File Offset: 0x0012AA74
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

	// Token: 0x06001B19 RID: 6937 RVA: 0x0012C9BC File Offset: 0x0012ABBC
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

	// Token: 0x04002DE7 RID: 11751
	public DrinkingFountainScript DrinkingFountain;

	// Token: 0x04002DE8 RID: 11752
	public PowerOutletScript PowerOutlet;

	// Token: 0x04002DE9 RID: 11753
	public GameObject Electricity;

	// Token: 0x04002DEA RID: 11754
	public Light BathroomLight;

	// Token: 0x04002DEB RID: 11755
	public PromptScript Prompt;

	// Token: 0x04002DEC RID: 11756
	public AudioSource MyAudio;

	// Token: 0x04002DED RID: 11757
	public AudioClip[] Flick;

	// Token: 0x04002DEE RID: 11758
	public bool Haunted;

	// Token: 0x04002DEF RID: 11759
	public bool On;
}
