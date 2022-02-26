using System;
using UnityEngine;

// Token: 0x02000488 RID: 1160
public class TrueEndingScript : MonoBehaviour
{
	// Token: 0x06001F07 RID: 7943 RVA: 0x001B4A03 File Offset: 0x001B2C03
	private void Start()
	{
		this.Darkness.alpha = 1f;
		this.Subtitle.text = "";
	}

	// Token: 0x06001F08 RID: 7944 RVA: 0x001B4A28 File Offset: 0x001B2C28
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

	// Token: 0x04004088 RID: 16520
	public GameObject TrueEndingPanel;

	// Token: 0x04004089 RID: 16521
	public GameObject TimelinePanel;

	// Token: 0x0400408A RID: 16522
	public AudioSource Ambience;

	// Token: 0x0400408B RID: 16523
	public AudioSource MyAudio;

	// Token: 0x0400408C RID: 16524
	public AudioSource BuildUp;

	// Token: 0x0400408D RID: 16525
	public UISprite Darkness;

	// Token: 0x0400408E RID: 16526
	public Texture DarkLogo;

	// Token: 0x0400408F RID: 16527
	public AudioClip[] Clip;

	// Token: 0x04004090 RID: 16528
	public UILabel Subtitle;

	// Token: 0x04004091 RID: 16529
	public UITexture Logo;

	// Token: 0x04004092 RID: 16530
	public string[] Text;

	// Token: 0x04004093 RID: 16531
	public float SpeechTimer;

	// Token: 0x04004094 RID: 16532
	public float FadeTimer;

	// Token: 0x04004095 RID: 16533
	public float WaitTimer;

	// Token: 0x04004096 RID: 16534
	public float Timer;

	// Token: 0x04004097 RID: 16535
	public float Intensity;

	// Token: 0x04004098 RID: 16536
	public bool FadeOut;

	// Token: 0x04004099 RID: 16537
	public bool Shake;

	// Token: 0x0400409A RID: 16538
	public int Phase;
}
