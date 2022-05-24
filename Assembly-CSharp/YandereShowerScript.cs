using System;
using UnityEngine;

// Token: 0x020004DB RID: 1243
public class YandereShowerScript : MonoBehaviour
{
	// Token: 0x060020C7 RID: 8391 RVA: 0x001E55FB File Offset: 0x001E37FB
	private void Start()
	{
	}

	// Token: 0x060020C8 RID: 8392 RVA: 0x001E5600 File Offset: 0x001E3800
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

	// Token: 0x04004811 RID: 18449
	public SkinnedMeshRenderer Curtain;

	// Token: 0x04004812 RID: 18450
	public GameObject CensorSteam;

	// Token: 0x04004813 RID: 18451
	public YandereScript Yandere;

	// Token: 0x04004814 RID: 18452
	public PromptScript Prompt;

	// Token: 0x04004815 RID: 18453
	public Transform BatheSpot;

	// Token: 0x04004816 RID: 18454
	public float OpenValue;

	// Token: 0x04004817 RID: 18455
	public float Timer;

	// Token: 0x04004818 RID: 18456
	public bool UpdateCurtain;

	// Token: 0x04004819 RID: 18457
	public bool Open;

	// Token: 0x0400481A RID: 18458
	public AudioSource MyAudio;

	// Token: 0x0400481B RID: 18459
	public AudioClip CurtainClose;

	// Token: 0x0400481C RID: 18460
	public AudioClip CurtainOpen;
}
