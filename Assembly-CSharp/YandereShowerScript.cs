using System;
using UnityEngine;

// Token: 0x020004D9 RID: 1241
public class YandereShowerScript : MonoBehaviour
{
	// Token: 0x060020B2 RID: 8370 RVA: 0x001E24BB File Offset: 0x001E06BB
	private void Start()
	{
	}

	// Token: 0x060020B3 RID: 8371 RVA: 0x001E24C0 File Offset: 0x001E06C0
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

	// Token: 0x040047CB RID: 18379
	public SkinnedMeshRenderer Curtain;

	// Token: 0x040047CC RID: 18380
	public GameObject CensorSteam;

	// Token: 0x040047CD RID: 18381
	public YandereScript Yandere;

	// Token: 0x040047CE RID: 18382
	public PromptScript Prompt;

	// Token: 0x040047CF RID: 18383
	public Transform BatheSpot;

	// Token: 0x040047D0 RID: 18384
	public float OpenValue;

	// Token: 0x040047D1 RID: 18385
	public float Timer;

	// Token: 0x040047D2 RID: 18386
	public bool UpdateCurtain;

	// Token: 0x040047D3 RID: 18387
	public bool Open;

	// Token: 0x040047D4 RID: 18388
	public AudioSource MyAudio;

	// Token: 0x040047D5 RID: 18389
	public AudioClip CurtainClose;

	// Token: 0x040047D6 RID: 18390
	public AudioClip CurtainOpen;
}
