using System;
using UnityEngine;

// Token: 0x020003B8 RID: 952
public class PowerSwitchScript : MonoBehaviour
{
	// Token: 0x06001AE9 RID: 6889 RVA: 0x00129DB2 File Offset: 0x00127FB2
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

	// Token: 0x06001AEA RID: 6890 RVA: 0x00129DF0 File Offset: 0x00127FF0
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

	// Token: 0x06001AEB RID: 6891 RVA: 0x00129F38 File Offset: 0x00128138
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

	// Token: 0x04002D68 RID: 11624
	public DrinkingFountainScript DrinkingFountain;

	// Token: 0x04002D69 RID: 11625
	public PowerOutletScript PowerOutlet;

	// Token: 0x04002D6A RID: 11626
	public GameObject Electricity;

	// Token: 0x04002D6B RID: 11627
	public Light BathroomLight;

	// Token: 0x04002D6C RID: 11628
	public PromptScript Prompt;

	// Token: 0x04002D6D RID: 11629
	public AudioSource MyAudio;

	// Token: 0x04002D6E RID: 11630
	public AudioClip[] Flick;

	// Token: 0x04002D6F RID: 11631
	public bool Haunted;

	// Token: 0x04002D70 RID: 11632
	public bool On;
}
