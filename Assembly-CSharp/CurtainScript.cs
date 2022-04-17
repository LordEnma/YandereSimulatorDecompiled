using System;
using UnityEngine;

// Token: 0x0200026B RID: 619
public class CurtainScript : MonoBehaviour
{
	// Token: 0x0600130C RID: 4876 RVA: 0x000A8EB8 File Offset: 0x000A70B8
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount < 1f && this.Prompt.Circle[0].fillAmount > 0f)
		{
			this.Prompt.Circle[0].fillAmount = 0f;
			this.MyAudio.Play();
			this.Animate = true;
			this.Open = !this.Open;
		}
		if (this.Animate)
		{
			if (!this.Open)
			{
				this.Weight = Mathf.Lerp(this.Weight, 0f, Time.deltaTime * 10f);
				if (this.Weight < 0.01f)
				{
					this.Animate = false;
					this.Weight = 0f;
				}
			}
			else
			{
				this.Weight = Mathf.Lerp(this.Weight, 100f, Time.deltaTime * 10f);
				if (this.Weight > 99.99f)
				{
					this.Animate = false;
					this.Weight = 100f;
				}
			}
			this.Curtains[0].SetBlendShapeWeight(0, this.Weight);
			this.Curtains[1].SetBlendShapeWeight(0, this.Weight);
		}
	}

	// Token: 0x0600130D RID: 4877 RVA: 0x000A8FEC File Offset: 0x000A71EC
	private void OnTriggerEnter(Collider other)
	{
		if ((other.gameObject.layer == 13 || other.gameObject.layer == 9) && !this.Open)
		{
			this.MyAudio.Play();
			this.Animate = true;
			this.Open = true;
		}
	}

	// Token: 0x04001B2C RID: 6956
	public SkinnedMeshRenderer[] Curtains;

	// Token: 0x04001B2D RID: 6957
	public PromptScript Prompt;

	// Token: 0x04001B2E RID: 6958
	public AudioSource MyAudio;

	// Token: 0x04001B2F RID: 6959
	public bool Animate;

	// Token: 0x04001B30 RID: 6960
	public bool Open;

	// Token: 0x04001B31 RID: 6961
	public float Weight;
}
