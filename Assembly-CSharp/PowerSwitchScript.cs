using System;
using UnityEngine;

// Token: 0x020003BD RID: 957
public class PowerSwitchScript : MonoBehaviour
{
	// Token: 0x06001B0D RID: 6925 RVA: 0x0012C27A File Offset: 0x0012A47A
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

	// Token: 0x06001B0E RID: 6926 RVA: 0x0012C2B8 File Offset: 0x0012A4B8
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

	// Token: 0x06001B0F RID: 6927 RVA: 0x0012C400 File Offset: 0x0012A600
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

	// Token: 0x04002DD9 RID: 11737
	public DrinkingFountainScript DrinkingFountain;

	// Token: 0x04002DDA RID: 11738
	public PowerOutletScript PowerOutlet;

	// Token: 0x04002DDB RID: 11739
	public GameObject Electricity;

	// Token: 0x04002DDC RID: 11740
	public Light BathroomLight;

	// Token: 0x04002DDD RID: 11741
	public PromptScript Prompt;

	// Token: 0x04002DDE RID: 11742
	public AudioSource MyAudio;

	// Token: 0x04002DDF RID: 11743
	public AudioClip[] Flick;

	// Token: 0x04002DE0 RID: 11744
	public bool Haunted;

	// Token: 0x04002DE1 RID: 11745
	public bool On;
}
