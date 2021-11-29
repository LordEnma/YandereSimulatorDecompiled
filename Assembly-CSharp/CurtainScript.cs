using System;
using UnityEngine;

// Token: 0x02000269 RID: 617
public class CurtainScript : MonoBehaviour
{
	// Token: 0x060012FC RID: 4860 RVA: 0x000A7C48 File Offset: 0x000A5E48
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

	// Token: 0x060012FD RID: 4861 RVA: 0x000A7D64 File Offset: 0x000A5F64
	private void OnTriggerEnter(Collider other)
	{
		if ((other.gameObject.layer == 13 || other.gameObject.layer == 9) && !this.Open)
		{
			this.MyAudio.Play();
			this.Animate = true;
			this.Open = true;
		}
	}

	// Token: 0x04001AED RID: 6893
	public SkinnedMeshRenderer[] Curtains;

	// Token: 0x04001AEE RID: 6894
	public PromptScript Prompt;

	// Token: 0x04001AEF RID: 6895
	public AudioSource MyAudio;

	// Token: 0x04001AF0 RID: 6896
	public bool Animate;

	// Token: 0x04001AF1 RID: 6897
	public bool Open;

	// Token: 0x04001AF2 RID: 6898
	public float Weight;
}
