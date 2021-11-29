using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x0200000F RID: 15
public class MGPMManagerScript : MonoBehaviour
{
	// Token: 0x06000030 RID: 48 RVA: 0x00004B14 File Offset: 0x00002D14
	private void Start()
	{
		if (GameGlobals.HardMode)
		{
			this.Jukebox.clip = this.HardModeVoice;
			this.WaterRenderer[0].material.color = Color.red;
			this.WaterRenderer[1].material.color = Color.red;
			this.RightArtwork.material.mainTexture = this.RightBloody;
			this.LeftArtwork.material.mainTexture = this.LeftBloody;
		}
		if (GameGlobals.Eighties)
		{
			this.Canvas.localEulerAngles = new Vector3(0f, 0f, -90f);
			this.Canvas.localScale = new Vector3(0.0332f, 0.0332f, 0.0332f);
			this.StageClearGraphic.transform.localEulerAngles = new Vector3(0f, 0f, 90f);
			this.GameOverGraphic.transform.localEulerAngles = new Vector3(0f, 0f, 90f);
			this.StartGraphic.transform.localEulerAngles = new Vector3(0f, 0f, 90f);
			this.GameOverGraphic.transform.GetChild(0).gameObject.SetActive(false);
			this.RightArtwork.material.color = new Color(0f, 0f, 0f, 1f);
			this.LeftArtwork.material.color = new Color(0f, 0f, 0f, 1f);
			this.Miyuki.Hearts[1].transform.localPosition = new Vector3(145f, -260f, -4f);
			this.Miyuki.Hearts[1].transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			this.Miyuki.Hearts[1].transform.localScale = new Vector3(16f, 16f, 1f);
			this.Miyuki.Hearts[2].transform.localPosition = new Vector3(145f, -245f, -4f);
			this.Miyuki.Hearts[2].transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			this.Miyuki.Hearts[2].transform.localScale = new Vector3(16f, 16f, 1f);
			this.Miyuki.Hearts[3].transform.localPosition = new Vector3(145f, -230f, -4f);
			this.Miyuki.Hearts[3].transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			this.Miyuki.Hearts[3].transform.localScale = new Vector3(16f, 16f, 1f);
			this.Miyuki.MagicBar.transform.parent.localPosition = new Vector3(145f, 0f, -1.1f);
			this.Miyuki.MagicBar.transform.parent.localEulerAngles = new Vector3(0f, 0f, 90f);
			this.Miyuki.MagicBar.transform.parent.localScale = new Vector3(132f, 10f, 1f);
			this.Border.material.mainTexture = this.WhiteBorder;
			this.ScoreLabel.color = new Color(1f, 1f, 1f, 1f);
			this.ScoreLabel.font = this.VCR;
			this.GameOverMusic = this.EightiesGameOverMusic;
			this.VictoryMusic = this.EightiesVictoryMusic;
			this.Jukebox.clip = this.EightiesIntroJingle;
			this.FinalBoss = this.EightiesFinalBoss;
			this.BGM = this.EightiesGameplayLoop;
			this.Water[1].Sprite = this.Stars;
			this.Water[2].Sprite = this.Stars;
			this.Eighties = true;
		}
		this.Miyuki.transform.localPosition = new Vector3(0f, -300f, 0f);
		this.Black.material.color = new Color(0f, 0f, 0f, 1f);
		this.StartGraphic.SetActive(false);
		this.Miyuki.Gameplay = false;
		this.ID = 1;
		while (this.ID < this.EnemySpawner.Length)
		{
			this.EnemySpawner[this.ID].enabled = false;
			this.ID++;
		}
		Time.timeScale = 1f;
	}

	// Token: 0x06000031 RID: 49 RVA: 0x00005024 File Offset: 0x00003224
	private void Update()
	{
		this.ScoreLabel.text = "Score: " + (this.Score * this.Miyuki.Health).ToString();
		if (this.StageClear)
		{
			this.GameOverTimer += Time.deltaTime;
			if (this.GameOverTimer > 1f)
			{
				this.Miyuki.transform.localPosition = new Vector3(this.Miyuki.transform.localPosition.x, this.Miyuki.transform.localPosition.y + Time.deltaTime * 10f, this.Miyuki.transform.localPosition.z);
				if (!this.StageClearGraphic.activeInHierarchy)
				{
					this.StageClearGraphic.SetActive(true);
					this.Jukebox.clip = this.VictoryMusic;
					this.Jukebox.loop = false;
					this.Jukebox.volume = 1f;
					this.Jukebox.Play();
				}
				if (this.GameOverTimer > 9f)
				{
					this.FadeOut = true;
				}
			}
			if (this.FadeOut)
			{
				this.Black.material.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Black.material.color.a, 1f, Time.deltaTime));
				this.Jukebox.volume = 1f - this.Black.material.color.a;
				if (this.Black.material.color.a == 1f)
				{
					if (!this.Eighties)
					{
						SceneManager.LoadScene("MiyukiThanksScene");
						return;
					}
					SceneManager.LoadScene("HomeScene");
					return;
				}
			}
		}
		else if (!this.GameOver)
		{
			if (this.Intro)
			{
				if (this.FadeIn)
				{
					this.Black.material.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Black.material.color.a, 0f, Time.deltaTime));
					if (this.Black.material.color.a == 0f)
					{
						this.Jukebox.Play();
						this.FadeIn = false;
					}
				}
				else
				{
					this.Miyuki.transform.localPosition = new Vector3(0f, Mathf.MoveTowards(this.Miyuki.transform.localPosition.y, -120f, Time.deltaTime * 60f), 0f);
					if (this.Miyuki.transform.localPosition.y == -120f)
					{
						if (!this.Jukebox.isPlaying)
						{
							this.Jukebox.loop = true;
							this.Jukebox.clip = this.BGM;
							this.Jukebox.Play();
							if (GameGlobals.HardMode)
							{
								this.Jukebox.pitch = 0.2f;
							}
						}
						this.StartGraphic.SetActive(true);
						this.Timer += Time.deltaTime;
						if ((double)this.Timer > 3.5)
						{
							this.StartGraphic.SetActive(false);
							this.ID = 1;
							while (this.ID < this.EnemySpawner.Length)
							{
								this.EnemySpawner[this.ID].enabled = true;
								this.ID++;
							}
							this.Miyuki.Gameplay = true;
							this.Intro = false;
						}
					}
				}
				if (Input.GetKeyDown("space"))
				{
					this.StartGraphic.SetActive(false);
					this.ID = 1;
					while (this.ID < this.EnemySpawner.Length)
					{
						this.EnemySpawner[this.ID].enabled = true;
						this.ID++;
					}
					this.Black.material.color = new Color(0f, 0f, 0f, 0f);
					this.Miyuki.Gameplay = true;
					this.Intro = false;
					this.Jukebox.loop = true;
					this.Jukebox.clip = this.BGM;
					this.Jukebox.Play();
					if (GameGlobals.HardMode)
					{
						this.Jukebox.pitch = 0.2f;
						return;
					}
				}
			}
		}
		else
		{
			this.GameOverTimer += Time.deltaTime;
			if (this.GameOverTimer > 3f)
			{
				if (!this.GameOverGraphic.activeInHierarchy)
				{
					this.GameOverGraphic.SetActive(true);
					this.Jukebox.clip = this.GameOverMusic;
					this.Jukebox.loop = false;
					this.Jukebox.Play();
				}
				else if (Input.anyKeyDown)
				{
					this.FadeOut = true;
				}
			}
			if (this.FadeOut)
			{
				this.Black.material.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Black.material.color.a, 1f, Time.deltaTime));
				this.Jukebox.volume = 1f - this.Black.material.color.a;
				if (this.Black.material.color.a == 1f)
				{
					SceneManager.LoadScene("MiyukiTitleScene");
				}
			}
		}
	}

	// Token: 0x06000032 RID: 50 RVA: 0x000055C4 File Offset: 0x000037C4
	public void BeginGameOver()
	{
		this.Jukebox.Stop();
		this.GameOver = true;
		this.Miyuki.enabled = false;
	}

	// Token: 0x0400008F RID: 143
	public MGPMSpawnerScript[] EnemySpawner;

	// Token: 0x04000090 RID: 144
	public MGPMWaterScript[] Water;

	// Token: 0x04000091 RID: 145
	public MGPMMiyukiScript Miyuki;

	// Token: 0x04000092 RID: 146
	public GameObject StageClearGraphic;

	// Token: 0x04000093 RID: 147
	public GameObject GameOverGraphic;

	// Token: 0x04000094 RID: 148
	public GameObject StartGraphic;

	// Token: 0x04000095 RID: 149
	public Renderer[] WaterRenderer;

	// Token: 0x04000096 RID: 150
	public AudioClip HardModeVoice;

	// Token: 0x04000097 RID: 151
	public AudioClip GameOverMusic;

	// Token: 0x04000098 RID: 152
	public AudioClip VictoryMusic;

	// Token: 0x04000099 RID: 153
	public AudioClip FinalBoss;

	// Token: 0x0400009A RID: 154
	public AudioClip BGM;

	// Token: 0x0400009B RID: 155
	public AudioClip EightiesGameOverMusic;

	// Token: 0x0400009C RID: 156
	public AudioClip EightiesGameplayLoop;

	// Token: 0x0400009D RID: 157
	public AudioClip EightiesVictoryMusic;

	// Token: 0x0400009E RID: 158
	public AudioClip EightiesIntroJingle;

	// Token: 0x0400009F RID: 159
	public AudioClip EightiesFinalBoss;

	// Token: 0x040000A0 RID: 160
	public Renderer RightArtwork;

	// Token: 0x040000A1 RID: 161
	public Renderer LeftArtwork;

	// Token: 0x040000A2 RID: 162
	public Renderer Border;

	// Token: 0x040000A3 RID: 163
	public AudioSource Jukebox;

	// Token: 0x040000A4 RID: 164
	public Texture WhiteBorder;

	// Token: 0x040000A5 RID: 165
	public Texture RightBloody;

	// Token: 0x040000A6 RID: 166
	public Texture LeftBloody;

	// Token: 0x040000A7 RID: 167
	public Transform Canvas;

	// Token: 0x040000A8 RID: 168
	public Texture[] Stars;

	// Token: 0x040000A9 RID: 169
	public Text ScoreLabel;

	// Token: 0x040000AA RID: 170
	public Renderer Black;

	// Token: 0x040000AB RID: 171
	public float GameOverTimer;

	// Token: 0x040000AC RID: 172
	public float Timer;

	// Token: 0x040000AD RID: 173
	public bool StageClear;

	// Token: 0x040000AE RID: 174
	public bool Eighties;

	// Token: 0x040000AF RID: 175
	public bool GameOver;

	// Token: 0x040000B0 RID: 176
	public bool FadeOut;

	// Token: 0x040000B1 RID: 177
	public bool FadeIn;

	// Token: 0x040000B2 RID: 178
	public bool Intro;

	// Token: 0x040000B3 RID: 179
	public int Score;

	// Token: 0x040000B4 RID: 180
	public int ID;

	// Token: 0x040000B5 RID: 181
	public Font VCR;
}
