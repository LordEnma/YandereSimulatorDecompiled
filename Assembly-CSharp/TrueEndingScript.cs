using System;
using UnityEngine;

// Token: 0x02000486 RID: 1158
public class TrueEndingScript : MonoBehaviour
{
	// Token: 0x06001EF4 RID: 7924 RVA: 0x001B3843 File Offset: 0x001B1A43
	private void Start()
	{
		this.Darkness.alpha = 1f;
		this.Subtitle.text = "";
	}

	// Token: 0x06001EF5 RID: 7925 RVA: 0x001B3868 File Offset: 0x001B1A68
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

	// Token: 0x0400406C RID: 16492
	public GameObject TrueEndingPanel;

	// Token: 0x0400406D RID: 16493
	public GameObject TimelinePanel;

	// Token: 0x0400406E RID: 16494
	public AudioSource Ambience;

	// Token: 0x0400406F RID: 16495
	public AudioSource MyAudio;

	// Token: 0x04004070 RID: 16496
	public AudioSource BuildUp;

	// Token: 0x04004071 RID: 16497
	public UISprite Darkness;

	// Token: 0x04004072 RID: 16498
	public Texture DarkLogo;

	// Token: 0x04004073 RID: 16499
	public AudioClip[] Clip;

	// Token: 0x04004074 RID: 16500
	public UILabel Subtitle;

	// Token: 0x04004075 RID: 16501
	public UITexture Logo;

	// Token: 0x04004076 RID: 16502
	public string[] Text;

	// Token: 0x04004077 RID: 16503
	public float SpeechTimer;

	// Token: 0x04004078 RID: 16504
	public float FadeTimer;

	// Token: 0x04004079 RID: 16505
	public float WaitTimer;

	// Token: 0x0400407A RID: 16506
	public float Timer;

	// Token: 0x0400407B RID: 16507
	public float Intensity;

	// Token: 0x0400407C RID: 16508
	public bool FadeOut;

	// Token: 0x0400407D RID: 16509
	public bool Shake;

	// Token: 0x0400407E RID: 16510
	public int Phase;
}
