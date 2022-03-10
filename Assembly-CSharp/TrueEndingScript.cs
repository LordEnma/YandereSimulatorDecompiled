using System;
using UnityEngine;

// Token: 0x02000488 RID: 1160
public class TrueEndingScript : MonoBehaviour
{
	// Token: 0x06001F0A RID: 7946 RVA: 0x001B51A3 File Offset: 0x001B33A3
	private void Start()
	{
		this.Darkness.alpha = 1f;
		this.Subtitle.text = "";
	}

	// Token: 0x06001F0B RID: 7947 RVA: 0x001B51C8 File Offset: 0x001B33C8
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

	// Token: 0x0400409F RID: 16543
	public GameObject TrueEndingPanel;

	// Token: 0x040040A0 RID: 16544
	public GameObject TimelinePanel;

	// Token: 0x040040A1 RID: 16545
	public AudioSource Ambience;

	// Token: 0x040040A2 RID: 16546
	public AudioSource MyAudio;

	// Token: 0x040040A3 RID: 16547
	public AudioSource BuildUp;

	// Token: 0x040040A4 RID: 16548
	public UISprite Darkness;

	// Token: 0x040040A5 RID: 16549
	public Texture DarkLogo;

	// Token: 0x040040A6 RID: 16550
	public AudioClip[] Clip;

	// Token: 0x040040A7 RID: 16551
	public UILabel Subtitle;

	// Token: 0x040040A8 RID: 16552
	public UITexture Logo;

	// Token: 0x040040A9 RID: 16553
	public string[] Text;

	// Token: 0x040040AA RID: 16554
	public float SpeechTimer;

	// Token: 0x040040AB RID: 16555
	public float FadeTimer;

	// Token: 0x040040AC RID: 16556
	public float WaitTimer;

	// Token: 0x040040AD RID: 16557
	public float Timer;

	// Token: 0x040040AE RID: 16558
	public float Intensity;

	// Token: 0x040040AF RID: 16559
	public bool FadeOut;

	// Token: 0x040040B0 RID: 16560
	public bool Shake;

	// Token: 0x040040B1 RID: 16561
	public int Phase;
}
