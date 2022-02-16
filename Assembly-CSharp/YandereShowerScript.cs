using System;
using UnityEngine;

// Token: 0x020004CE RID: 1230
public class YandereShowerScript : MonoBehaviour
{
	// Token: 0x0600206E RID: 8302 RVA: 0x001DC7E1 File Offset: 0x001DA9E1
	private void Start()
	{
	}

	// Token: 0x0600206F RID: 8303 RVA: 0x001DC7E4 File Offset: 0x001DA9E4
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

	// Token: 0x040046F8 RID: 18168
	public SkinnedMeshRenderer Curtain;

	// Token: 0x040046F9 RID: 18169
	public GameObject CensorSteam;

	// Token: 0x040046FA RID: 18170
	public YandereScript Yandere;

	// Token: 0x040046FB RID: 18171
	public PromptScript Prompt;

	// Token: 0x040046FC RID: 18172
	public Transform BatheSpot;

	// Token: 0x040046FD RID: 18173
	public float OpenValue;

	// Token: 0x040046FE RID: 18174
	public float Timer;

	// Token: 0x040046FF RID: 18175
	public bool UpdateCurtain;

	// Token: 0x04004700 RID: 18176
	public bool Open;

	// Token: 0x04004701 RID: 18177
	public AudioSource MyAudio;

	// Token: 0x04004702 RID: 18178
	public AudioClip CurtainClose;

	// Token: 0x04004703 RID: 18179
	public AudioClip CurtainOpen;
}
