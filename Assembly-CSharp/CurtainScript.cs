using System;
using UnityEngine;

// Token: 0x0200026B RID: 619
public class CurtainScript : MonoBehaviour
{
	// Token: 0x06001310 RID: 4880 RVA: 0x000A931C File Offset: 0x000A751C
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

	// Token: 0x06001311 RID: 4881 RVA: 0x000A9450 File Offset: 0x000A7650
	private void OnTriggerEnter(Collider other)
	{
		if ((other.gameObject.layer == 13 || other.gameObject.layer == 9) && !this.Open)
		{
			this.MyAudio.Play();
			this.Animate = true;
			this.Open = true;
		}
	}

	// Token: 0x04001B34 RID: 6964
	public SkinnedMeshRenderer[] Curtains;

	// Token: 0x04001B35 RID: 6965
	public PromptScript Prompt;

	// Token: 0x04001B36 RID: 6966
	public AudioSource MyAudio;

	// Token: 0x04001B37 RID: 6967
	public bool Animate;

	// Token: 0x04001B38 RID: 6968
	public bool Open;

	// Token: 0x04001B39 RID: 6969
	public float Weight;
}
