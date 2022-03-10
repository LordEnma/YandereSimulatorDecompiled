using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000350 RID: 848
public class LifeNoteScript : MonoBehaviour
{
	// Token: 0x0600195D RID: 6493 RVA: 0x000FE5E8 File Offset: 0x000FC7E8
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

	// Token: 0x0600195E RID: 6494 RVA: 0x000FE6B8 File Offset: 0x000FC8B8
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

	// Token: 0x04002811 RID: 10257
	public UITexture Darkness;

	// Token: 0x04002812 RID: 10258
	public UITexture TextWindow;

	// Token: 0x04002813 RID: 10259
	public UITexture FinalDarkness;

	// Token: 0x04002814 RID: 10260
	public Transform BackgroundArt;

	// Token: 0x04002815 RID: 10261
	public TypewriterEffect Typewriter;

	// Token: 0x04002816 RID: 10262
	public GameObject Controls;

	// Token: 0x04002817 RID: 10263
	public AudioSource MyAudio;

	// Token: 0x04002818 RID: 10264
	public AudioClip[] Voices;

	// Token: 0x04002819 RID: 10265
	public string[] Lines;

	// Token: 0x0400281A RID: 10266
	public int[] Alphas;

	// Token: 0x0400281B RID: 10267
	public bool[] Reds;

	// Token: 0x0400281C RID: 10268
	public UILabel Label;

	// Token: 0x0400281D RID: 10269
	public float Timer;

	// Token: 0x0400281E RID: 10270
	public int Frame;

	// Token: 0x0400281F RID: 10271
	public int ID;

	// Token: 0x04002820 RID: 10272
	public float AutoTimer;

	// Token: 0x04002821 RID: 10273
	public float Alpha;

	// Token: 0x04002822 RID: 10274
	public string Text;

	// Token: 0x04002823 RID: 10275
	public AudioClip[] SFX;

	// Token: 0x04002824 RID: 10276
	public bool Spoke;

	// Token: 0x04002825 RID: 10277
	public bool Auto;

	// Token: 0x04002826 RID: 10278
	public AudioSource SFXAudioSource;

	// Token: 0x04002827 RID: 10279
	public AudioSource Jukebox;
}
