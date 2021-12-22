using System;
using UnityEngine;

// Token: 0x0200026A RID: 618
public class CurtainScript : MonoBehaviour
{
	// Token: 0x06001303 RID: 4867 RVA: 0x000A80EC File Offset: 0x000A62EC
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

	// Token: 0x06001304 RID: 4868 RVA: 0x000A8208 File Offset: 0x000A6408
	private void OnTriggerEnter(Collider other)
	{
		if ((other.gameObject.layer == 13 || other.gameObject.layer == 9) && !this.Open)
		{
			this.MyAudio.Play();
			this.Animate = true;
			this.Open = true;
		}
	}

	// Token: 0x04001B06 RID: 6918
	public SkinnedMeshRenderer[] Curtains;

	// Token: 0x04001B07 RID: 6919
	public PromptScript Prompt;

	// Token: 0x04001B08 RID: 6920
	public AudioSource MyAudio;

	// Token: 0x04001B09 RID: 6921
	public bool Animate;

	// Token: 0x04001B0A RID: 6922
	public bool Open;

	// Token: 0x04001B0B RID: 6923
	public float Weight;
}
