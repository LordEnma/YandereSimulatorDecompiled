using System;
using UnityEngine;

// Token: 0x02000491 RID: 1169
public class TrueEndingScript : MonoBehaviour
{
	// Token: 0x06001F47 RID: 8007 RVA: 0x001BB7F6 File Offset: 0x001B99F6
	private void Start()
	{
		this.Darkness.alpha = 1f;
		this.Subtitle.text = "";
	}

	// Token: 0x06001F48 RID: 8008 RVA: 0x001BB818 File Offset: 0x001B9A18
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

	// Token: 0x04004167 RID: 16743
	public GameObject TrueEndingPanel;

	// Token: 0x04004168 RID: 16744
	public GameObject TimelinePanel;

	// Token: 0x04004169 RID: 16745
	public AudioSource Ambience;

	// Token: 0x0400416A RID: 16746
	public AudioSource MyAudio;

	// Token: 0x0400416B RID: 16747
	public AudioSource BuildUp;

	// Token: 0x0400416C RID: 16748
	public UISprite Darkness;

	// Token: 0x0400416D RID: 16749
	public Texture DarkLogo;

	// Token: 0x0400416E RID: 16750
	public AudioClip[] Clip;

	// Token: 0x0400416F RID: 16751
	public UILabel Subtitle;

	// Token: 0x04004170 RID: 16752
	public UITexture Logo;

	// Token: 0x04004171 RID: 16753
	public string[] Text;

	// Token: 0x04004172 RID: 16754
	public float SpeechTimer;

	// Token: 0x04004173 RID: 16755
	public float FadeTimer;

	// Token: 0x04004174 RID: 16756
	public float WaitTimer;

	// Token: 0x04004175 RID: 16757
	public float Timer;

	// Token: 0x04004176 RID: 16758
	public float Intensity;

	// Token: 0x04004177 RID: 16759
	public bool FadeOut;

	// Token: 0x04004178 RID: 16760
	public bool Shake;

	// Token: 0x04004179 RID: 16761
	public int Phase;
}
