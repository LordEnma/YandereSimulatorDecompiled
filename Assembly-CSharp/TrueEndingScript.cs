using System;
using UnityEngine;

// Token: 0x02000486 RID: 1158
public class TrueEndingScript : MonoBehaviour
{
	// Token: 0x06001EF0 RID: 7920 RVA: 0x001B3057 File Offset: 0x001B1257
	private void Start()
	{
		this.Darkness.alpha = 1f;
		this.Subtitle.text = "";
	}

	// Token: 0x06001EF1 RID: 7921 RVA: 0x001B307C File Offset: 0x001B127C
	private void Update()
	{
		this.Timer += Time.deltaTime;
		this.Ambience.volume = Mathf.MoveTowards(this.Ambience.volume, 0.25f, Time.deltaTime * 0.25f);
		if (this.Timer > 1f)
		{
			if (!this.FadeOut)
			{
				this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0f, Time.deltaTime);
			}
			else
			{
				this.Logo.alpha = Mathf.MoveTowards(this.Logo.alpha, 0f, Time.deltaTime * 0.33333f);
				if (this.Logo.alpha == 0f)
				{
					this.TrueEndingPanel.SetActive(false);
					this.TimelinePanel.SetActive(true);
					base.enabled = false;
				}
			}
			this.WaitTimer += Time.deltaTime;
			if (this.WaitTimer > 1f)
			{
				if (Input.GetButtonDown("A"))
				{
					this.SpeechTimer = 1f;
					if (this.Phase < 16)
					{
						this.MyAudio.Stop();
					}
				}
				if (!this.MyAudio.isPlaying && this.Darkness.alpha == 0f)
				{
					this.SpeechTimer += Time.deltaTime;
					if (this.SpeechTimer > 0.5f && this.Phase < this.Clip.Length - 1)
					{
						this.Phase++;
						this.Subtitle.text = this.Text[this.Phase];
						this.MyAudio.clip = this.Clip[this.Phase];
						this.MyAudio.Play();
						if (this.Phase == this.Clip.Length - 1)
						{
							this.Logo.mainTexture = this.DarkLogo;
							this.Ambience.Stop();
							this.BuildUp.Stop();
							this.Shake = true;
						}
						else if (this.Phase == this.Clip.Length - 2)
						{
							this.BuildUp.Play();
						}
						this.SpeechTimer = 0f;
					}
				}
			}
		}
		if (this.Shake)
		{
			this.Logo.transform.localPosition = new Vector3(UnityEngine.Random.Range(-1f, 1f) * this.Intensity, UnityEngine.Random.Range(-1f, 1f) * this.Intensity, UnityEngine.Random.Range(-1f, 1f) * this.Intensity);
			this.Intensity = Mathf.MoveTowards(this.Intensity, 0f, Time.deltaTime * 100f);
			if (this.Intensity == 0f)
			{
				this.FadeTimer += Time.deltaTime;
				if (this.FadeTimer > 5f && !this.FadeOut)
				{
					this.Darkness.color = new Color(0f, 0f, 0f, 0f);
					this.FadeOut = true;
				}
			}
		}
	}

	// Token: 0x0400405E RID: 16478
	public GameObject TrueEndingPanel;

	// Token: 0x0400405F RID: 16479
	public GameObject TimelinePanel;

	// Token: 0x04004060 RID: 16480
	public AudioSource Ambience;

	// Token: 0x04004061 RID: 16481
	public AudioSource MyAudio;

	// Token: 0x04004062 RID: 16482
	public AudioSource BuildUp;

	// Token: 0x04004063 RID: 16483
	public UISprite Darkness;

	// Token: 0x04004064 RID: 16484
	public Texture DarkLogo;

	// Token: 0x04004065 RID: 16485
	public AudioClip[] Clip;

	// Token: 0x04004066 RID: 16486
	public UILabel Subtitle;

	// Token: 0x04004067 RID: 16487
	public UITexture Logo;

	// Token: 0x04004068 RID: 16488
	public string[] Text;

	// Token: 0x04004069 RID: 16489
	public float SpeechTimer;

	// Token: 0x0400406A RID: 16490
	public float FadeTimer;

	// Token: 0x0400406B RID: 16491
	public float WaitTimer;

	// Token: 0x0400406C RID: 16492
	public float Timer;

	// Token: 0x0400406D RID: 16493
	public float Intensity;

	// Token: 0x0400406E RID: 16494
	public bool FadeOut;

	// Token: 0x0400406F RID: 16495
	public bool Shake;

	// Token: 0x04004070 RID: 16496
	public int Phase;
}
