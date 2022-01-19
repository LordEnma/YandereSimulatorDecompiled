using System;
using UnityEngine;

// Token: 0x020004CD RID: 1229
public class YandereShowerScript : MonoBehaviour
{
	// Token: 0x0600205E RID: 8286 RVA: 0x001DB571 File Offset: 0x001D9771
	private void Start()
	{
	}

	// Token: 0x0600205F RID: 8287 RVA: 0x001DB574 File Offset: 0x001D9774
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			if (this.Yandere.Schoolwear > 0 || this.Yandere.Chased || this.Yandere.Chasers > 0 || this.Yandere.Bloodiness == 0f)
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

	// Token: 0x040046DB RID: 18139
	public SkinnedMeshRenderer Curtain;

	// Token: 0x040046DC RID: 18140
	public GameObject CensorSteam;

	// Token: 0x040046DD RID: 18141
	public YandereScript Yandere;

	// Token: 0x040046DE RID: 18142
	public PromptScript Prompt;

	// Token: 0x040046DF RID: 18143
	public Transform BatheSpot;

	// Token: 0x040046E0 RID: 18144
	public float OpenValue;

	// Token: 0x040046E1 RID: 18145
	public float Timer;

	// Token: 0x040046E2 RID: 18146
	public bool UpdateCurtain;

	// Token: 0x040046E3 RID: 18147
	public bool Open;

	// Token: 0x040046E4 RID: 18148
	public AudioSource MyAudio;

	// Token: 0x040046E5 RID: 18149
	public AudioClip CurtainClose;

	// Token: 0x040046E6 RID: 18150
	public AudioClip CurtainOpen;
}
