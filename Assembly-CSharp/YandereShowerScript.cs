using System;
using UnityEngine;

// Token: 0x020004CA RID: 1226
public class YandereShowerScript : MonoBehaviour
{
	// Token: 0x06002051 RID: 8273 RVA: 0x001D9F01 File Offset: 0x001D8101
	private void Start()
	{
	}

	// Token: 0x06002052 RID: 8274 RVA: 0x001D9F04 File Offset: 0x001D8104
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

	// Token: 0x040046C0 RID: 18112
	public SkinnedMeshRenderer Curtain;

	// Token: 0x040046C1 RID: 18113
	public GameObject CensorSteam;

	// Token: 0x040046C2 RID: 18114
	public YandereScript Yandere;

	// Token: 0x040046C3 RID: 18115
	public PromptScript Prompt;

	// Token: 0x040046C4 RID: 18116
	public Transform BatheSpot;

	// Token: 0x040046C5 RID: 18117
	public float OpenValue;

	// Token: 0x040046C6 RID: 18118
	public float Timer;

	// Token: 0x040046C7 RID: 18119
	public bool UpdateCurtain;

	// Token: 0x040046C8 RID: 18120
	public bool Open;

	// Token: 0x040046C9 RID: 18121
	public AudioSource MyAudio;

	// Token: 0x040046CA RID: 18122
	public AudioClip CurtainClose;

	// Token: 0x040046CB RID: 18123
	public AudioClip CurtainOpen;
}
