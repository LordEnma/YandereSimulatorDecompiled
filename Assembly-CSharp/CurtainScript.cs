using System;
using UnityEngine;

// Token: 0x0200026A RID: 618
public class CurtainScript : MonoBehaviour
{
	// Token: 0x06001304 RID: 4868 RVA: 0x000A8494 File Offset: 0x000A6694
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
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

	// Token: 0x06001305 RID: 4869 RVA: 0x000A85B0 File Offset: 0x000A67B0
	private void OnTriggerEnter(Collider other)
	{
		if ((other.gameObject.layer == 13 || other.gameObject.layer == 9) && !this.Open)
		{
			this.MyAudio.Play();
			this.Animate = true;
			this.Open = true;
		}
	}

	// Token: 0x04001B0E RID: 6926
	public SkinnedMeshRenderer[] Curtains;

	// Token: 0x04001B0F RID: 6927
	public PromptScript Prompt;

	// Token: 0x04001B10 RID: 6928
	public AudioSource MyAudio;

	// Token: 0x04001B11 RID: 6929
	public bool Animate;

	// Token: 0x04001B12 RID: 6930
	public bool Open;

	// Token: 0x04001B13 RID: 6931
	public float Weight;
}
