using System;
using UnityEngine;

// Token: 0x02000483 RID: 1155
public class TrueEndingScript : MonoBehaviour
{
	// Token: 0x06001EE3 RID: 7907 RVA: 0x001B1A07 File Offset: 0x001AFC07
	private void Start()
	{
		this.Darkness.alpha = 1f;
		this.Subtitle.text = "";
	}

	// Token: 0x06001EE4 RID: 7908 RVA: 0x001B1A2C File Offset: 0x001AFC2C
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

	// Token: 0x04004043 RID: 16451
	public GameObject TrueEndingPanel;

	// Token: 0x04004044 RID: 16452
	public GameObject TimelinePanel;

	// Token: 0x04004045 RID: 16453
	public AudioSource Ambience;

	// Token: 0x04004046 RID: 16454
	public AudioSource MyAudio;

	// Token: 0x04004047 RID: 16455
	public AudioSource BuildUp;

	// Token: 0x04004048 RID: 16456
	public UISprite Darkness;

	// Token: 0x04004049 RID: 16457
	public Texture DarkLogo;

	// Token: 0x0400404A RID: 16458
	public AudioClip[] Clip;

	// Token: 0x0400404B RID: 16459
	public UILabel Subtitle;

	// Token: 0x0400404C RID: 16460
	public UITexture Logo;

	// Token: 0x0400404D RID: 16461
	public string[] Text;

	// Token: 0x0400404E RID: 16462
	public float SpeechTimer;

	// Token: 0x0400404F RID: 16463
	public float FadeTimer;

	// Token: 0x04004050 RID: 16464
	public float WaitTimer;

	// Token: 0x04004051 RID: 16465
	public float Timer;

	// Token: 0x04004052 RID: 16466
	public float Intensity;

	// Token: 0x04004053 RID: 16467
	public bool FadeOut;

	// Token: 0x04004054 RID: 16468
	public bool Shake;

	// Token: 0x04004055 RID: 16469
	public int Phase;
}
