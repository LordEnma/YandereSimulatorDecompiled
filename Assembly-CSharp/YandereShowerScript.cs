using System;
using UnityEngine;

// Token: 0x020004DB RID: 1243
public class YandereShowerScript : MonoBehaviour
{
	// Token: 0x060020C6 RID: 8390 RVA: 0x001E5093 File Offset: 0x001E3293
	private void Start()
	{
	}

	// Token: 0x060020C7 RID: 8391 RVA: 0x001E5098 File Offset: 0x001E3298
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			if ((this.Yandere.Schoolwear > 0 && this.Yandere.Schoolwear != 2) || this.Yandere.Chased || this.Yandere.Chasers > 0 || this.Yandere.Bloodiness == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
			}
			else
			{
				AudioSource.PlayClipAtPoint(this.CurtainOpen, base.transform.position);
				this.CensorSteam.SetActive(true);
				this.MyAudio.Play();
				this.Yandere.EmptyHands();
				this.Yandere.YandereShower = this;
				this.Yandere.CanMove = false;
				this.Yandere.Bathing = true;
				this.UpdateCurtain = true;
				this.Open = true;
				this.Timer = 6f;
			}
		}
		if (this.UpdateCurtain)
		{
			this.Timer = Mathf.MoveTowards(this.Timer, 0f, Time.deltaTime);
			if (this.Timer < 1f)
			{
				if (this.Open)
				{
					AudioSource.PlayClipAtPoint(this.CurtainClose, base.transform.position);
				}
				this.Open = false;
				if (this.Timer == 0f)
				{
					this.CensorSteam.SetActive(false);
					this.UpdateCurtain = false;
				}
			}
			if (this.Open)
			{
				this.OpenValue = Mathf.Lerp(this.OpenValue, 0f, Time.deltaTime * 10f);
				this.Curtain.SetBlendShapeWeight(0, this.OpenValue);
				return;
			}
			this.OpenValue = Mathf.Lerp(this.OpenValue, 100f, Time.deltaTime * 10f);
			this.Curtain.SetBlendShapeWeight(0, this.OpenValue);
		}
	}

	// Token: 0x04004808 RID: 18440
	public SkinnedMeshRenderer Curtain;

	// Token: 0x04004809 RID: 18441
	public GameObject CensorSteam;

	// Token: 0x0400480A RID: 18442
	public YandereScript Yandere;

	// Token: 0x0400480B RID: 18443
	public PromptScript Prompt;

	// Token: 0x0400480C RID: 18444
	public Transform BatheSpot;

	// Token: 0x0400480D RID: 18445
	public float OpenValue;

	// Token: 0x0400480E RID: 18446
	public float Timer;

	// Token: 0x0400480F RID: 18447
	public bool UpdateCurtain;

	// Token: 0x04004810 RID: 18448
	public bool Open;

	// Token: 0x04004811 RID: 18449
	public AudioSource MyAudio;

	// Token: 0x04004812 RID: 18450
	public AudioClip CurtainClose;

	// Token: 0x04004813 RID: 18451
	public AudioClip CurtainOpen;
}
