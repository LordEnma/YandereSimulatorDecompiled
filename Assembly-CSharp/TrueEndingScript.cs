using System;
using UnityEngine;

// Token: 0x02000482 RID: 1154
public class TrueEndingScript : MonoBehaviour
{
	// Token: 0x06001ED6 RID: 7894 RVA: 0x001B0773 File Offset: 0x001AE973
	private void Start()
	{
		this.Darkness.alpha = 1f;
		this.Subtitle.text = "";
	}

	// Token: 0x06001ED7 RID: 7895 RVA: 0x001B0798 File Offset: 0x001AE998
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

	// Token: 0x0400400C RID: 16396
	public GameObject TrueEndingPanel;

	// Token: 0x0400400D RID: 16397
	public GameObject TimelinePanel;

	// Token: 0x0400400E RID: 16398
	public AudioSource Ambience;

	// Token: 0x0400400F RID: 16399
	public AudioSource MyAudio;

	// Token: 0x04004010 RID: 16400
	public AudioSource BuildUp;

	// Token: 0x04004011 RID: 16401
	public UISprite Darkness;

	// Token: 0x04004012 RID: 16402
	public Texture DarkLogo;

	// Token: 0x04004013 RID: 16403
	public AudioClip[] Clip;

	// Token: 0x04004014 RID: 16404
	public UILabel Subtitle;

	// Token: 0x04004015 RID: 16405
	public UITexture Logo;

	// Token: 0x04004016 RID: 16406
	public string[] Text;

	// Token: 0x04004017 RID: 16407
	public float SpeechTimer;

	// Token: 0x04004018 RID: 16408
	public float FadeTimer;

	// Token: 0x04004019 RID: 16409
	public float WaitTimer;

	// Token: 0x0400401A RID: 16410
	public float Timer;

	// Token: 0x0400401B RID: 16411
	public float Intensity;

	// Token: 0x0400401C RID: 16412
	public bool FadeOut;

	// Token: 0x0400401D RID: 16413
	public bool Shake;

	// Token: 0x0400401E RID: 16414
	public int Phase;
}
