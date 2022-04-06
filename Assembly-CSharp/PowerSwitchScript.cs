using System;
using UnityEngine;

// Token: 0x020003BE RID: 958
public class PowerSwitchScript : MonoBehaviour
{
	// Token: 0x06001B13 RID: 6931 RVA: 0x0012C426 File Offset: 0x0012A626
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

	// Token: 0x06001B14 RID: 6932 RVA: 0x0012C464 File Offset: 0x0012A664
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

	// Token: 0x06001B15 RID: 6933 RVA: 0x0012C5AC File Offset: 0x0012A7AC
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

	// Token: 0x04002DDC RID: 11740
	public DrinkingFountainScript DrinkingFountain;

	// Token: 0x04002DDD RID: 11741
	public PowerOutletScript PowerOutlet;

	// Token: 0x04002DDE RID: 11742
	public GameObject Electricity;

	// Token: 0x04002DDF RID: 11743
	public Light BathroomLight;

	// Token: 0x04002DE0 RID: 11744
	public PromptScript Prompt;

	// Token: 0x04002DE1 RID: 11745
	public AudioSource MyAudio;

	// Token: 0x04002DE2 RID: 11746
	public AudioClip[] Flick;

	// Token: 0x04002DE3 RID: 11747
	public bool Haunted;

	// Token: 0x04002DE4 RID: 11748
	public bool On;
}
