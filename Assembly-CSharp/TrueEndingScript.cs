using System;
using UnityEngine;

// Token: 0x0200048F RID: 1167
public class TrueEndingScript : MonoBehaviour
{
	// Token: 0x06001F34 RID: 7988 RVA: 0x001B8D96 File Offset: 0x001B6F96
	private void Start()
	{
		this.Darkness.alpha = 1f;
		this.Subtitle.text = "";
	}

	// Token: 0x06001F35 RID: 7989 RVA: 0x001B8DB8 File Offset: 0x001B6FB8
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

	// Token: 0x0400412A RID: 16682
	public GameObject TrueEndingPanel;

	// Token: 0x0400412B RID: 16683
	public GameObject TimelinePanel;

	// Token: 0x0400412C RID: 16684
	public AudioSource Ambience;

	// Token: 0x0400412D RID: 16685
	public AudioSource MyAudio;

	// Token: 0x0400412E RID: 16686
	public AudioSource BuildUp;

	// Token: 0x0400412F RID: 16687
	public UISprite Darkness;

	// Token: 0x04004130 RID: 16688
	public Texture DarkLogo;

	// Token: 0x04004131 RID: 16689
	public AudioClip[] Clip;

	// Token: 0x04004132 RID: 16690
	public UILabel Subtitle;

	// Token: 0x04004133 RID: 16691
	public UITexture Logo;

	// Token: 0x04004134 RID: 16692
	public string[] Text;

	// Token: 0x04004135 RID: 16693
	public float SpeechTimer;

	// Token: 0x04004136 RID: 16694
	public float FadeTimer;

	// Token: 0x04004137 RID: 16695
	public float WaitTimer;

	// Token: 0x04004138 RID: 16696
	public float Timer;

	// Token: 0x04004139 RID: 16697
	public float Intensity;

	// Token: 0x0400413A RID: 16698
	public bool FadeOut;

	// Token: 0x0400413B RID: 16699
	public bool Shake;

	// Token: 0x0400413C RID: 16700
	public int Phase;
}
