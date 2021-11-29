using System;
using UnityEngine;

// Token: 0x020004C8 RID: 1224
public class YandereShowerScript : MonoBehaviour
{
	// Token: 0x0600203D RID: 8253 RVA: 0x001D81DD File Offset: 0x001D63DD
	private void Start()
	{
	}

	// Token: 0x0600203E RID: 8254 RVA: 0x001D81E0 File Offset: 0x001D63E0
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

	// Token: 0x04004678 RID: 18040
	public SkinnedMeshRenderer Curtain;

	// Token: 0x04004679 RID: 18041
	public GameObject CensorSteam;

	// Token: 0x0400467A RID: 18042
	public YandereScript Yandere;

	// Token: 0x0400467B RID: 18043
	public PromptScript Prompt;

	// Token: 0x0400467C RID: 18044
	public Transform BatheSpot;

	// Token: 0x0400467D RID: 18045
	public float OpenValue;

	// Token: 0x0400467E RID: 18046
	public float Timer;

	// Token: 0x0400467F RID: 18047
	public bool UpdateCurtain;

	// Token: 0x04004680 RID: 18048
	public bool Open;

	// Token: 0x04004681 RID: 18049
	public AudioSource MyAudio;

	// Token: 0x04004682 RID: 18050
	public AudioClip CurtainClose;

	// Token: 0x04004683 RID: 18051
	public AudioClip CurtainOpen;
}
