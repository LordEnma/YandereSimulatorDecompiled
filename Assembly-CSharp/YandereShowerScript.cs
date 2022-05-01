using System;
using UnityEngine;

// Token: 0x020004DA RID: 1242
public class YandereShowerScript : MonoBehaviour
{
	// Token: 0x060020BB RID: 8379 RVA: 0x001E3947 File Offset: 0x001E1B47
	private void Start()
	{
	}

	// Token: 0x060020BC RID: 8380 RVA: 0x001E394C File Offset: 0x001E1B4C
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

	// Token: 0x040047E1 RID: 18401
	public SkinnedMeshRenderer Curtain;

	// Token: 0x040047E2 RID: 18402
	public GameObject CensorSteam;

	// Token: 0x040047E3 RID: 18403
	public YandereScript Yandere;

	// Token: 0x040047E4 RID: 18404
	public PromptScript Prompt;

	// Token: 0x040047E5 RID: 18405
	public Transform BatheSpot;

	// Token: 0x040047E6 RID: 18406
	public float OpenValue;

	// Token: 0x040047E7 RID: 18407
	public float Timer;

	// Token: 0x040047E8 RID: 18408
	public bool UpdateCurtain;

	// Token: 0x040047E9 RID: 18409
	public bool Open;

	// Token: 0x040047EA RID: 18410
	public AudioSource MyAudio;

	// Token: 0x040047EB RID: 18411
	public AudioClip CurtainClose;

	// Token: 0x040047EC RID: 18412
	public AudioClip CurtainOpen;
}
