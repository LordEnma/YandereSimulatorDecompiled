using System;
using UnityEngine;

// Token: 0x020004CD RID: 1229
public class YandereShowerScript : MonoBehaviour
{
	// Token: 0x06002062 RID: 8290 RVA: 0x001DBE11 File Offset: 0x001DA011
	private void Start()
	{
	}

	// Token: 0x06002063 RID: 8291 RVA: 0x001DBE14 File Offset: 0x001DA014
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

	// Token: 0x040046E6 RID: 18150
	public SkinnedMeshRenderer Curtain;

	// Token: 0x040046E7 RID: 18151
	public GameObject CensorSteam;

	// Token: 0x040046E8 RID: 18152
	public YandereScript Yandere;

	// Token: 0x040046E9 RID: 18153
	public PromptScript Prompt;

	// Token: 0x040046EA RID: 18154
	public Transform BatheSpot;

	// Token: 0x040046EB RID: 18155
	public float OpenValue;

	// Token: 0x040046EC RID: 18156
	public float Timer;

	// Token: 0x040046ED RID: 18157
	public bool UpdateCurtain;

	// Token: 0x040046EE RID: 18158
	public bool Open;

	// Token: 0x040046EF RID: 18159
	public AudioSource MyAudio;

	// Token: 0x040046F0 RID: 18160
	public AudioClip CurtainClose;

	// Token: 0x040046F1 RID: 18161
	public AudioClip CurtainOpen;
}
