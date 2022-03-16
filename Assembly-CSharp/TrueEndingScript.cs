using System;
using UnityEngine;

// Token: 0x0200048B RID: 1163
public class TrueEndingScript : MonoBehaviour
{
	// Token: 0x06001F1C RID: 7964 RVA: 0x001B6923 File Offset: 0x001B4B23
	private void Start()
	{
		this.Darkness.alpha = 1f;
		this.Subtitle.text = "";
	}

	// Token: 0x06001F1D RID: 7965 RVA: 0x001B6948 File Offset: 0x001B4B48
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

	// Token: 0x040040EA RID: 16618
	public GameObject TrueEndingPanel;

	// Token: 0x040040EB RID: 16619
	public GameObject TimelinePanel;

	// Token: 0x040040EC RID: 16620
	public AudioSource Ambience;

	// Token: 0x040040ED RID: 16621
	public AudioSource MyAudio;

	// Token: 0x040040EE RID: 16622
	public AudioSource BuildUp;

	// Token: 0x040040EF RID: 16623
	public UISprite Darkness;

	// Token: 0x040040F0 RID: 16624
	public Texture DarkLogo;

	// Token: 0x040040F1 RID: 16625
	public AudioClip[] Clip;

	// Token: 0x040040F2 RID: 16626
	public UILabel Subtitle;

	// Token: 0x040040F3 RID: 16627
	public UITexture Logo;

	// Token: 0x040040F4 RID: 16628
	public string[] Text;

	// Token: 0x040040F5 RID: 16629
	public float SpeechTimer;

	// Token: 0x040040F6 RID: 16630
	public float FadeTimer;

	// Token: 0x040040F7 RID: 16631
	public float WaitTimer;

	// Token: 0x040040F8 RID: 16632
	public float Timer;

	// Token: 0x040040F9 RID: 16633
	public float Intensity;

	// Token: 0x040040FA RID: 16634
	public bool FadeOut;

	// Token: 0x040040FB RID: 16635
	public bool Shake;

	// Token: 0x040040FC RID: 16636
	public int Phase;
}
