using System;
using UnityEngine;

// Token: 0x02000490 RID: 1168
public class TrueEndingScript : MonoBehaviour
{
	// Token: 0x06001F3E RID: 7998 RVA: 0x001BA202 File Offset: 0x001B8402
	private void Start()
	{
		this.Darkness.alpha = 1f;
		this.Subtitle.text = "";
	}

	// Token: 0x06001F3F RID: 7999 RVA: 0x001BA224 File Offset: 0x001B8424
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

	// Token: 0x04004140 RID: 16704
	public GameObject TrueEndingPanel;

	// Token: 0x04004141 RID: 16705
	public GameObject TimelinePanel;

	// Token: 0x04004142 RID: 16706
	public AudioSource Ambience;

	// Token: 0x04004143 RID: 16707
	public AudioSource MyAudio;

	// Token: 0x04004144 RID: 16708
	public AudioSource BuildUp;

	// Token: 0x04004145 RID: 16709
	public UISprite Darkness;

	// Token: 0x04004146 RID: 16710
	public Texture DarkLogo;

	// Token: 0x04004147 RID: 16711
	public AudioClip[] Clip;

	// Token: 0x04004148 RID: 16712
	public UILabel Subtitle;

	// Token: 0x04004149 RID: 16713
	public UITexture Logo;

	// Token: 0x0400414A RID: 16714
	public string[] Text;

	// Token: 0x0400414B RID: 16715
	public float SpeechTimer;

	// Token: 0x0400414C RID: 16716
	public float FadeTimer;

	// Token: 0x0400414D RID: 16717
	public float WaitTimer;

	// Token: 0x0400414E RID: 16718
	public float Timer;

	// Token: 0x0400414F RID: 16719
	public float Intensity;

	// Token: 0x04004150 RID: 16720
	public bool FadeOut;

	// Token: 0x04004151 RID: 16721
	public bool Shake;

	// Token: 0x04004152 RID: 16722
	public int Phase;
}
