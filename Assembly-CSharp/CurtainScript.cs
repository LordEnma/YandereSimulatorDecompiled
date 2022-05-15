using System;
using UnityEngine;

// Token: 0x0200026C RID: 620
public class CurtainScript : MonoBehaviour
{
	// Token: 0x06001312 RID: 4882 RVA: 0x000A9598 File Offset: 0x000A7798
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

	// Token: 0x06001313 RID: 4883 RVA: 0x000A96CC File Offset: 0x000A78CC
	private void OnTriggerEnter(Collider other)
	{
		if ((other.gameObject.layer == 13 || other.gameObject.layer == 9) && !this.Open)
		{
			this.MyAudio.Play();
			this.Animate = true;
			this.Open = true;
		}
	}

	// Token: 0x04001B3B RID: 6971
	public SkinnedMeshRenderer[] Curtains;

	// Token: 0x04001B3C RID: 6972
	public PromptScript Prompt;

	// Token: 0x04001B3D RID: 6973
	public AudioSource MyAudio;

	// Token: 0x04001B3E RID: 6974
	public bool Animate;

	// Token: 0x04001B3F RID: 6975
	public bool Open;

	// Token: 0x04001B40 RID: 6976
	public float Weight;
}
