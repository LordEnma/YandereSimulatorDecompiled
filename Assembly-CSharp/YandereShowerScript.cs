using System;
using UnityEngine;

// Token: 0x020004D4 RID: 1236
public class YandereShowerScript : MonoBehaviour
{
	// Token: 0x06002095 RID: 8341 RVA: 0x001DFCF3 File Offset: 0x001DDEF3
	private void Start()
	{
	}

	// Token: 0x06002096 RID: 8342 RVA: 0x001DFCF8 File Offset: 0x001DDEF8
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

	// Token: 0x04004784 RID: 18308
	public SkinnedMeshRenderer Curtain;

	// Token: 0x04004785 RID: 18309
	public GameObject CensorSteam;

	// Token: 0x04004786 RID: 18310
	public YandereScript Yandere;

	// Token: 0x04004787 RID: 18311
	public PromptScript Prompt;

	// Token: 0x04004788 RID: 18312
	public Transform BatheSpot;

	// Token: 0x04004789 RID: 18313
	public float OpenValue;

	// Token: 0x0400478A RID: 18314
	public float Timer;

	// Token: 0x0400478B RID: 18315
	public bool UpdateCurtain;

	// Token: 0x0400478C RID: 18316
	public bool Open;

	// Token: 0x0400478D RID: 18317
	public AudioSource MyAudio;

	// Token: 0x0400478E RID: 18318
	public AudioClip CurtainClose;

	// Token: 0x0400478F RID: 18319
	public AudioClip CurtainOpen;
}
