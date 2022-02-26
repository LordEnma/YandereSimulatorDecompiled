using System;
using UnityEngine;

// Token: 0x020004CF RID: 1231
public class YandereShowerScript : MonoBehaviour
{
	// Token: 0x06002077 RID: 8311 RVA: 0x001DD3C1 File Offset: 0x001DB5C1
	private void Start()
	{
	}

	// Token: 0x06002078 RID: 8312 RVA: 0x001DD3C4 File Offset: 0x001DB5C4
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

	// Token: 0x04004708 RID: 18184
	public SkinnedMeshRenderer Curtain;

	// Token: 0x04004709 RID: 18185
	public GameObject CensorSteam;

	// Token: 0x0400470A RID: 18186
	public YandereScript Yandere;

	// Token: 0x0400470B RID: 18187
	public PromptScript Prompt;

	// Token: 0x0400470C RID: 18188
	public Transform BatheSpot;

	// Token: 0x0400470D RID: 18189
	public float OpenValue;

	// Token: 0x0400470E RID: 18190
	public float Timer;

	// Token: 0x0400470F RID: 18191
	public bool UpdateCurtain;

	// Token: 0x04004710 RID: 18192
	public bool Open;

	// Token: 0x04004711 RID: 18193
	public AudioSource MyAudio;

	// Token: 0x04004712 RID: 18194
	public AudioClip CurtainClose;

	// Token: 0x04004713 RID: 18195
	public AudioClip CurtainOpen;
}
