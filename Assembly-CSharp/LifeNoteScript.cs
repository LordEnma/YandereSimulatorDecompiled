using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200034C RID: 844
public class LifeNoteScript : MonoBehaviour
{
	// Token: 0x0600193D RID: 6461 RVA: 0x000FC23C File Offset: 0x000FA43C
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

	// Token: 0x0600193E RID: 6462 RVA: 0x000FC30C File Offset: 0x000FA50C
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

	// Token: 0x040027AC RID: 10156
	public UITexture Darkness;

	// Token: 0x040027AD RID: 10157
	public UITexture TextWindow;

	// Token: 0x040027AE RID: 10158
	public UITexture FinalDarkness;

	// Token: 0x040027AF RID: 10159
	public Transform BackgroundArt;

	// Token: 0x040027B0 RID: 10160
	public TypewriterEffect Typewriter;

	// Token: 0x040027B1 RID: 10161
	public GameObject Controls;

	// Token: 0x040027B2 RID: 10162
	public AudioSource MyAudio;

	// Token: 0x040027B3 RID: 10163
	public AudioClip[] Voices;

	// Token: 0x040027B4 RID: 10164
	public string[] Lines;

	// Token: 0x040027B5 RID: 10165
	public int[] Alphas;

	// Token: 0x040027B6 RID: 10166
	public bool[] Reds;

	// Token: 0x040027B7 RID: 10167
	public UILabel Label;

	// Token: 0x040027B8 RID: 10168
	public float Timer;

	// Token: 0x040027B9 RID: 10169
	public int Frame;

	// Token: 0x040027BA RID: 10170
	public int ID;

	// Token: 0x040027BB RID: 10171
	public float AutoTimer;

	// Token: 0x040027BC RID: 10172
	public float Alpha;

	// Token: 0x040027BD RID: 10173
	public string Text;

	// Token: 0x040027BE RID: 10174
	public AudioClip[] SFX;

	// Token: 0x040027BF RID: 10175
	public bool Spoke;

	// Token: 0x040027C0 RID: 10176
	public bool Auto;

	// Token: 0x040027C1 RID: 10177
	public AudioSource SFXAudioSource;

	// Token: 0x040027C2 RID: 10178
	public AudioSource Jukebox;
}
