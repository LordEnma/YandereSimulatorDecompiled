using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200034E RID: 846
public class LifeNoteScript : MonoBehaviour
{
	// Token: 0x0600194A RID: 6474 RVA: 0x000FD1D4 File Offset: 0x000FB3D4
	private void Start()
	{
		Application.targetFrameRate = 60;
		this.Label.text = this.Lines[this.ID];
		this.Controls.SetActive(false);
		this.Label.gameObject.SetActive(false);
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
		this.BackgroundArt.localPosition = new Vector3(0f, -540f, 0f);
		this.BackgroundArt.localScale = new Vector3(2.5f, 2.5f, 1f);
		this.TextWindow.color = new Color(1f, 1f, 1f, 0f);
	}

	// Token: 0x0600194B RID: 6475 RVA: 0x000FD2A4 File Offset: 0x000FB4A4
	private void Update()
	{
		if (this.Controls.activeInHierarchy)
		{
			if (this.Typewriter.mCurrentOffset == 1)
			{
				if (this.Reds[this.ID])
				{
					this.Label.color = new Color(1f, 0f, 0f, 1f);
				}
				else
				{
					this.Label.color = new Color(1f, 1f, 1f, 1f);
				}
			}
			if (Input.GetButtonDown("A") || this.AutoTimer > 0.5f)
			{
				if (this.ID < this.Lines.Length - 1)
				{
					if (this.Typewriter.mCurrentOffset < this.Typewriter.mFullText.Length)
					{
						this.Typewriter.Finish();
					}
					else
					{
						this.ID++;
						this.Alpha = (float)this.Alphas[this.ID];
						this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
						this.Typewriter.ResetToBeginning();
						this.Typewriter.mFullText = this.Lines[this.ID];
						this.Label.text = "";
						this.Spoke = false;
						this.Frame = 0;
						if (this.Alphas[this.ID] == 1)
						{
							this.Jukebox.Stop();
						}
						else if (!this.Jukebox.isPlaying)
						{
							this.Jukebox.Play();
						}
						if (this.ID == 17)
						{
							this.SFXAudioSource.clip = this.SFX[1];
							this.SFXAudioSource.Play();
						}
						if (this.ID == 18)
						{
							this.SFXAudioSource.clip = this.SFX[2];
							this.SFXAudioSource.Play();
						}
						if (this.ID > 25)
						{
							this.Typewriter.charsPerSecond = 15;
						}
						this.AutoTimer = 0f;
					}
				}
				else if (!this.FinalDarkness.enabled)
				{
					this.FinalDarkness.enabled = true;
					this.Alpha = 0f;
				}
			}
			if (!this.Spoke && !this.SFXAudioSource.isPlaying)
			{
				this.MyAudio.clip = this.Voices[this.ID];
				this.MyAudio.Play();
				this.Spoke = true;
			}
			if (this.Auto && this.Typewriter.mCurrentOffset == this.Typewriter.mFullText.Length && !this.SFXAudioSource.isPlaying && !this.MyAudio.isPlaying)
			{
				this.AutoTimer += Time.deltaTime;
			}
			if (this.FinalDarkness.enabled)
			{
				this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.2f);
				this.FinalDarkness.color = new Color(0f, 0f, 0f, this.Alpha);
				if (this.Alpha == 1f)
				{
					SceneManager.LoadScene("HomeScene");
				}
			}
		}
		if (this.TextWindow.color.a < 1f)
		{
			if (Input.GetButtonDown("A"))
			{
				this.Darkness.color = new Color(0f, 0f, 0f, 0f);
				this.BackgroundArt.localPosition = new Vector3(0f, 0f, 0f);
				this.BackgroundArt.localScale = new Vector3(1f, 1f, 1f);
				this.TextWindow.color = new Color(1f, 1f, 1f, 1f);
				this.Label.color = new Color(1f, 1f, 1f, 0f);
				this.Label.gameObject.SetActive(true);
				this.Controls.SetActive(true);
				this.Timer = 0f;
			}
			this.Timer += Time.deltaTime;
			if (this.Timer > 6f)
			{
				this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime);
				this.TextWindow.color = new Color(1f, 1f, 1f, this.Alpha);
				if (this.TextWindow.color.a == 1f && !this.Typewriter.mActive)
				{
					this.Label.color = new Color(1f, 1f, 1f, 0f);
					this.Label.gameObject.SetActive(true);
					this.Controls.SetActive(true);
					this.Timer = 0f;
					return;
				}
			}
			else
			{
				if (this.Timer > 2f)
				{
					this.BackgroundArt.localScale = Vector3.Lerp(this.BackgroundArt.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * (this.Timer - 2f));
					this.BackgroundArt.localPosition = Vector3.Lerp(this.BackgroundArt.localPosition, new Vector3(0f, 0f, 0f), Time.deltaTime * (this.Timer - 2f));
					return;
				}
				if (this.Timer > 0f)
				{
					this.Darkness.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
				}
			}
		}
	}

	// Token: 0x040027DC RID: 10204
	public UITexture Darkness;

	// Token: 0x040027DD RID: 10205
	public UITexture TextWindow;

	// Token: 0x040027DE RID: 10206
	public UITexture FinalDarkness;

	// Token: 0x040027DF RID: 10207
	public Transform BackgroundArt;

	// Token: 0x040027E0 RID: 10208
	public TypewriterEffect Typewriter;

	// Token: 0x040027E1 RID: 10209
	public GameObject Controls;

	// Token: 0x040027E2 RID: 10210
	public AudioSource MyAudio;

	// Token: 0x040027E3 RID: 10211
	public AudioClip[] Voices;

	// Token: 0x040027E4 RID: 10212
	public string[] Lines;

	// Token: 0x040027E5 RID: 10213
	public int[] Alphas;

	// Token: 0x040027E6 RID: 10214
	public bool[] Reds;

	// Token: 0x040027E7 RID: 10215
	public UILabel Label;

	// Token: 0x040027E8 RID: 10216
	public float Timer;

	// Token: 0x040027E9 RID: 10217
	public int Frame;

	// Token: 0x040027EA RID: 10218
	public int ID;

	// Token: 0x040027EB RID: 10219
	public float AutoTimer;

	// Token: 0x040027EC RID: 10220
	public float Alpha;

	// Token: 0x040027ED RID: 10221
	public string Text;

	// Token: 0x040027EE RID: 10222
	public AudioClip[] SFX;

	// Token: 0x040027EF RID: 10223
	public bool Spoke;

	// Token: 0x040027F0 RID: 10224
	public bool Auto;

	// Token: 0x040027F1 RID: 10225
	public AudioSource SFXAudioSource;

	// Token: 0x040027F2 RID: 10226
	public AudioSource Jukebox;
}
