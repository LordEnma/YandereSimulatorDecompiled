using System;
using UnityEngine;

// Token: 0x020003B6 RID: 950
public class PowerSwitchScript : MonoBehaviour
{
	// Token: 0x06001ADF RID: 6879 RVA: 0x0012914E File Offset: 0x0012734E
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

	// Token: 0x06001AE0 RID: 6880 RVA: 0x0012918C File Offset: 0x0012738C
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

	// Token: 0x06001AE1 RID: 6881 RVA: 0x001292D4 File Offset: 0x001274D4
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

	// Token: 0x04002D54 RID: 11604
	public DrinkingFountainScript DrinkingFountain;

	// Token: 0x04002D55 RID: 11605
	public PowerOutletScript PowerOutlet;

	// Token: 0x04002D56 RID: 11606
	public GameObject Electricity;

	// Token: 0x04002D57 RID: 11607
	public Light BathroomLight;

	// Token: 0x04002D58 RID: 11608
	public PromptScript Prompt;

	// Token: 0x04002D59 RID: 11609
	public AudioSource MyAudio;

	// Token: 0x04002D5A RID: 11610
	public AudioClip[] Flick;

	// Token: 0x04002D5B RID: 11611
	public bool Haunted;

	// Token: 0x04002D5C RID: 11612
	public bool On;
}
