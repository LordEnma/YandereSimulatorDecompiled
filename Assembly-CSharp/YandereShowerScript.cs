using System;
using UnityEngine;

// Token: 0x020004D9 RID: 1241
public class YandereShowerScript : MonoBehaviour
{
	// Token: 0x060020AB RID: 8363 RVA: 0x001E1A5F File Offset: 0x001DFC5F
	private void Start()
	{
	}

	// Token: 0x060020AC RID: 8364 RVA: 0x001E1A64 File Offset: 0x001DFC64
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

	// Token: 0x040047B9 RID: 18361
	public SkinnedMeshRenderer Curtain;

	// Token: 0x040047BA RID: 18362
	public GameObject CensorSteam;

	// Token: 0x040047BB RID: 18363
	public YandereScript Yandere;

	// Token: 0x040047BC RID: 18364
	public PromptScript Prompt;

	// Token: 0x040047BD RID: 18365
	public Transform BatheSpot;

	// Token: 0x040047BE RID: 18366
	public float OpenValue;

	// Token: 0x040047BF RID: 18367
	public float Timer;

	// Token: 0x040047C0 RID: 18368
	public bool UpdateCurtain;

	// Token: 0x040047C1 RID: 18369
	public bool Open;

	// Token: 0x040047C2 RID: 18370
	public AudioSource MyAudio;

	// Token: 0x040047C3 RID: 18371
	public AudioClip CurtainClose;

	// Token: 0x040047C4 RID: 18372
	public AudioClip CurtainOpen;
}
