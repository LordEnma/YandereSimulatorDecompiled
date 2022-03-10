using System;
using UnityEngine;

// Token: 0x020003BA RID: 954
public class PowerSwitchScript : MonoBehaviour
{
	// Token: 0x06001AFA RID: 6906 RVA: 0x0012AED2 File Offset: 0x001290D2
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

	// Token: 0x06001AFB RID: 6907 RVA: 0x0012AF10 File Offset: 0x00129110
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

	// Token: 0x06001AFC RID: 6908 RVA: 0x0012B058 File Offset: 0x00129258
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

	// Token: 0x04002D94 RID: 11668
	public DrinkingFountainScript DrinkingFountain;

	// Token: 0x04002D95 RID: 11669
	public PowerOutletScript PowerOutlet;

	// Token: 0x04002D96 RID: 11670
	public GameObject Electricity;

	// Token: 0x04002D97 RID: 11671
	public Light BathroomLight;

	// Token: 0x04002D98 RID: 11672
	public PromptScript Prompt;

	// Token: 0x04002D99 RID: 11673
	public AudioSource MyAudio;

	// Token: 0x04002D9A RID: 11674
	public AudioClip[] Flick;

	// Token: 0x04002D9B RID: 11675
	public bool Haunted;

	// Token: 0x04002D9C RID: 11676
	public bool On;
}
