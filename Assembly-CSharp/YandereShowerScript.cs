using System;
using UnityEngine;

// Token: 0x020004CA RID: 1226
public class YandereShowerScript : MonoBehaviour
{
	// Token: 0x0600204E RID: 8270 RVA: 0x001D9911 File Offset: 0x001D7B11
	private void Start()
	{
	}

	// Token: 0x0600204F RID: 8271 RVA: 0x001D9914 File Offset: 0x001D7B14
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

	// Token: 0x040046B7 RID: 18103
	public SkinnedMeshRenderer Curtain;

	// Token: 0x040046B8 RID: 18104
	public GameObject CensorSteam;

	// Token: 0x040046B9 RID: 18105
	public YandereScript Yandere;

	// Token: 0x040046BA RID: 18106
	public PromptScript Prompt;

	// Token: 0x040046BB RID: 18107
	public Transform BatheSpot;

	// Token: 0x040046BC RID: 18108
	public float OpenValue;

	// Token: 0x040046BD RID: 18109
	public float Timer;

	// Token: 0x040046BE RID: 18110
	public bool UpdateCurtain;

	// Token: 0x040046BF RID: 18111
	public bool Open;

	// Token: 0x040046C0 RID: 18112
	public AudioSource MyAudio;

	// Token: 0x040046C1 RID: 18113
	public AudioClip CurtainClose;

	// Token: 0x040046C2 RID: 18114
	public AudioClip CurtainOpen;
}
