using System;
using UnityEngine;

// Token: 0x0200026B RID: 619
public class CurtainScript : MonoBehaviour
{
	// Token: 0x06001308 RID: 4872 RVA: 0x000A8450 File Offset: 0x000A6650
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

	// Token: 0x06001309 RID: 4873 RVA: 0x000A856C File Offset: 0x000A676C
	private void OnTriggerEnter(Collider other)
	{
		if ((other.gameObject.layer == 13 || other.gameObject.layer == 9) && !this.Open)
		{
			this.MyAudio.Play();
			this.Animate = true;
			this.Open = true;
		}
	}

	// Token: 0x04001B13 RID: 6931
	public SkinnedMeshRenderer[] Curtains;

	// Token: 0x04001B14 RID: 6932
	public PromptScript Prompt;

	// Token: 0x04001B15 RID: 6933
	public AudioSource MyAudio;

	// Token: 0x04001B16 RID: 6934
	public bool Animate;

	// Token: 0x04001B17 RID: 6935
	public bool Open;

	// Token: 0x04001B18 RID: 6936
	public float Weight;
}
