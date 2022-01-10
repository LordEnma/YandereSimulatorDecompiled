using System;
using UnityEngine;

// Token: 0x020004CC RID: 1228
public class YandereShowerScript : MonoBehaviour
{
	// Token: 0x0600205C RID: 8284 RVA: 0x001DA8A1 File Offset: 0x001D8AA1
	private void Start()
	{
	}

	// Token: 0x0600205D RID: 8285 RVA: 0x001DA8A4 File Offset: 0x001D8AA4
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

	// Token: 0x040046D4 RID: 18132
	public SkinnedMeshRenderer Curtain;

	// Token: 0x040046D5 RID: 18133
	public GameObject CensorSteam;

	// Token: 0x040046D6 RID: 18134
	public YandereScript Yandere;

	// Token: 0x040046D7 RID: 18135
	public PromptScript Prompt;

	// Token: 0x040046D8 RID: 18136
	public Transform BatheSpot;

	// Token: 0x040046D9 RID: 18137
	public float OpenValue;

	// Token: 0x040046DA RID: 18138
	public float Timer;

	// Token: 0x040046DB RID: 18139
	public bool UpdateCurtain;

	// Token: 0x040046DC RID: 18140
	public bool Open;

	// Token: 0x040046DD RID: 18141
	public AudioSource MyAudio;

	// Token: 0x040046DE RID: 18142
	public AudioClip CurtainClose;

	// Token: 0x040046DF RID: 18143
	public AudioClip CurtainOpen;
}
