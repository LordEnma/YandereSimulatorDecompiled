using System;
using UnityEngine;

// Token: 0x020003BA RID: 954
public class PowerSwitchScript : MonoBehaviour
{
	// Token: 0x06001B04 RID: 6916 RVA: 0x0012BB82 File Offset: 0x00129D82
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

	// Token: 0x06001B05 RID: 6917 RVA: 0x0012BBC0 File Offset: 0x00129DC0
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

	// Token: 0x06001B06 RID: 6918 RVA: 0x0012BD08 File Offset: 0x00129F08
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

	// Token: 0x04002DC1 RID: 11713
	public DrinkingFountainScript DrinkingFountain;

	// Token: 0x04002DC2 RID: 11714
	public PowerOutletScript PowerOutlet;

	// Token: 0x04002DC3 RID: 11715
	public GameObject Electricity;

	// Token: 0x04002DC4 RID: 11716
	public Light BathroomLight;

	// Token: 0x04002DC5 RID: 11717
	public PromptScript Prompt;

	// Token: 0x04002DC6 RID: 11718
	public AudioSource MyAudio;

	// Token: 0x04002DC7 RID: 11719
	public AudioClip[] Flick;

	// Token: 0x04002DC8 RID: 11720
	public bool Haunted;

	// Token: 0x04002DC9 RID: 11721
	public bool On;
}
