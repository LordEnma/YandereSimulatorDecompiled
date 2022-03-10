using System;
using UnityEngine;

// Token: 0x020004D0 RID: 1232
public class YandereShowerScript : MonoBehaviour
{
	// Token: 0x0600207D RID: 8317 RVA: 0x001DDD8D File Offset: 0x001DBF8D
	private void Start()
	{
	}

	// Token: 0x0600207E RID: 8318 RVA: 0x001DDD90 File Offset: 0x001DBF90
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

	// Token: 0x04004725 RID: 18213
	public SkinnedMeshRenderer Curtain;

	// Token: 0x04004726 RID: 18214
	public GameObject CensorSteam;

	// Token: 0x04004727 RID: 18215
	public YandereScript Yandere;

	// Token: 0x04004728 RID: 18216
	public PromptScript Prompt;

	// Token: 0x04004729 RID: 18217
	public Transform BatheSpot;

	// Token: 0x0400472A RID: 18218
	public float OpenValue;

	// Token: 0x0400472B RID: 18219
	public float Timer;

	// Token: 0x0400472C RID: 18220
	public bool UpdateCurtain;

	// Token: 0x0400472D RID: 18221
	public bool Open;

	// Token: 0x0400472E RID: 18222
	public AudioSource MyAudio;

	// Token: 0x0400472F RID: 18223
	public AudioClip CurtainClose;

	// Token: 0x04004730 RID: 18224
	public AudioClip CurtainOpen;
}
