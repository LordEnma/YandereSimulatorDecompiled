using System;
using UnityEngine;

// Token: 0x0200048F RID: 1167
public class TrueEndingScript : MonoBehaviour
{
	// Token: 0x06001F2E RID: 7982 RVA: 0x001B83B7 File Offset: 0x001B65B7
	private void Start()
	{
		this.Darkness.alpha = 1f;
		this.Subtitle.text = "";
	}

	// Token: 0x06001F2F RID: 7983 RVA: 0x001B83DC File Offset: 0x001B65DC
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

	// Token: 0x0400411A RID: 16666
	public GameObject TrueEndingPanel;

	// Token: 0x0400411B RID: 16667
	public GameObject TimelinePanel;

	// Token: 0x0400411C RID: 16668
	public AudioSource Ambience;

	// Token: 0x0400411D RID: 16669
	public AudioSource MyAudio;

	// Token: 0x0400411E RID: 16670
	public AudioSource BuildUp;

	// Token: 0x0400411F RID: 16671
	public UISprite Darkness;

	// Token: 0x04004120 RID: 16672
	public Texture DarkLogo;

	// Token: 0x04004121 RID: 16673
	public AudioClip[] Clip;

	// Token: 0x04004122 RID: 16674
	public UILabel Subtitle;

	// Token: 0x04004123 RID: 16675
	public UITexture Logo;

	// Token: 0x04004124 RID: 16676
	public string[] Text;

	// Token: 0x04004125 RID: 16677
	public float SpeechTimer;

	// Token: 0x04004126 RID: 16678
	public float FadeTimer;

	// Token: 0x04004127 RID: 16679
	public float WaitTimer;

	// Token: 0x04004128 RID: 16680
	public float Timer;

	// Token: 0x04004129 RID: 16681
	public float Intensity;

	// Token: 0x0400412A RID: 16682
	public bool FadeOut;

	// Token: 0x0400412B RID: 16683
	public bool Shake;

	// Token: 0x0400412C RID: 16684
	public int Phase;
}
