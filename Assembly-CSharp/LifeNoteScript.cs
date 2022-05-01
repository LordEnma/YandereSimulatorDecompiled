using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000352 RID: 850
public class LifeNoteScript : MonoBehaviour
{
	// Token: 0x06001978 RID: 6520 RVA: 0x000FFCC8 File Offset: 0x000FDEC8
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

	// Token: 0x06001979 RID: 6521 RVA: 0x000FFD98 File Offset: 0x000FDF98
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

	// Token: 0x04002855 RID: 10325
	public UITexture Darkness;

	// Token: 0x04002856 RID: 10326
	public UITexture TextWindow;

	// Token: 0x04002857 RID: 10327
	public UITexture FinalDarkness;

	// Token: 0x04002858 RID: 10328
	public Transform BackgroundArt;

	// Token: 0x04002859 RID: 10329
	public TypewriterEffect Typewriter;

	// Token: 0x0400285A RID: 10330
	public GameObject Controls;

	// Token: 0x0400285B RID: 10331
	public AudioSource MyAudio;

	// Token: 0x0400285C RID: 10332
	public AudioClip[] Voices;

	// Token: 0x0400285D RID: 10333
	public string[] Lines;

	// Token: 0x0400285E RID: 10334
	public int[] Alphas;

	// Token: 0x0400285F RID: 10335
	public bool[] Reds;

	// Token: 0x04002860 RID: 10336
	public UILabel Label;

	// Token: 0x04002861 RID: 10337
	public float Timer;

	// Token: 0x04002862 RID: 10338
	public int Frame;

	// Token: 0x04002863 RID: 10339
	public int ID;

	// Token: 0x04002864 RID: 10340
	public float AutoTimer;

	// Token: 0x04002865 RID: 10341
	public float Alpha;

	// Token: 0x04002866 RID: 10342
	public string Text;

	// Token: 0x04002867 RID: 10343
	public AudioClip[] SFX;

	// Token: 0x04002868 RID: 10344
	public bool Spoke;

	// Token: 0x04002869 RID: 10345
	public bool Auto;

	// Token: 0x0400286A RID: 10346
	public AudioSource SFXAudioSource;

	// Token: 0x0400286B RID: 10347
	public AudioSource Jukebox;
}
