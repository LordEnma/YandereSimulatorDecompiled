using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020002DE RID: 734
public class GenocideEndingScript : MonoBehaviour
{
	// Token: 0x060014DB RID: 5339 RVA: 0x000D5124 File Offset: 0x000D3324
	private void Start()
	{
		Time.timeScale = 1f;
		if (GameGlobals.EightiesCutsceneID == 12)
		{
			Debug.Log("We're here for the end of 1980s Mode.");
			this.SpeechText = this.EightiesText;
			this.Subtitle.text = this.SpeechText[1];
			this.SpeechClip = this.EightiesSpeechClip;
			this.MyAudio.clip = this.SpeechClip[1];
			this.MyAudio.Play();
			this.SpeechPhase = 1;
			this.YellowifyLabel(this.Subtitle);
			this.Senpai["kidnapTorture_01"].speed = 0.1f;
			this.Senpai.Play();
			this.SenpaiRopes.SetActive(true);
			this.OsanaRopes.SetActive(false);
			this.Senpai.transform.parent.gameObject.SetActive(true);
			this.Osana.SetActive(false);
			this.EightiesEnding = true;
			this.FadeSpeed = 0.1f;
			return;
		}
		if (EventGlobals.OsanaConversation)
		{
			Debug.Log("We're here for a Betray cutscene.");
			this.Osana.GetComponent<StudentScript>().CharacterAnimation["f02_kidnapTorture_01"].speed = 0.8f;
			this.Osana.GetComponent<CosmeticScript>().SetFemaleUniform();
			this.SenpaiRopes.SetActive(false);
			this.OsanaRopes.SetActive(true);
			this.Senpai.transform.parent.gameObject.SetActive(false);
			this.Osana.SetActive(true);
			this.SpeechText[10] = "...huh? ...what is this? ...why am I tied to a...chair?! Why are you doing this?! This isn't funny! Lemme go! Lemme go right now!";
			this.Subtitle.text = this.SpeechText[10];
			this.MyAudio.clip = this.OsanaClip;
			this.MyAudio.Play();
			this.SpeechPhase = 10;
			this.TimeLimit = 9f;
			this.Delay = 10f;
			if (GameGlobals.Eighties)
			{
				this.RivalHair[0].SetActive(false);
				this.RivalHair[DateGlobals.Week].SetActive(true);
				this.YellowifyLabel(this.Subtitle);
				return;
			}
		}
		else
		{
			Debug.Log("We're here for the Genocide Ending.");
			this.Senpai["kidnapTorture_01"].speed = 0.9f;
			this.SenpaiRopes.SetActive(true);
			this.OsanaRopes.SetActive(false);
			this.Senpai.transform.parent.gameObject.SetActive(true);
			this.Osana.SetActive(false);
			GameGlobals.DarkEnding = true;
		}
	}

	// Token: 0x060014DC RID: 5340 RVA: 0x000D53A8 File Offset: 0x000D35A8
	private void Update()
	{
		if (!this.EightiesEnding)
		{
			if (this.SpeechPhase > 9)
			{
				base.transform.Translate(Vector3.forward * -0.1f * Time.deltaTime);
				if (this.MyAudio.isPlaying)
				{
					this.Senpai.Play();
					if (this.MyAudio.time < this.TimeLimit)
					{
						this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.25f);
					}
					else
					{
						this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.25f);
					}
				}
				this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
				if (this.Darkness.color.a == 1f)
				{
					this.Subtitle.text = "";
				}
			}
			if (!this.MyAudio.isPlaying)
			{
				this.Timer += Time.deltaTime;
				if (this.Delay == 10f && this.Timer > 1f)
				{
					if (this.Timer < 3f)
					{
						this.RIVAL.SetActive(true);
						this.ELIMINATED.SetActive(true);
					}
					else if (this.Timer < 5f)
					{
						if (this.ELIMINATED.activeInHierarchy)
						{
							this.ELIMINATED.SetActive(false);
							AudioSource.PlayClipAtPoint(this.Slam, base.transform.position);
						}
					}
					else
					{
						this.SecondAlpha = Mathf.MoveTowards(this.SecondAlpha, 1f, Time.deltaTime * 0.25f);
						this.SecondDarkness.color = new Color(0f, 0f, 0f, this.SecondAlpha);
					}
				}
				if (this.Timer > this.Delay)
				{
					this.SpeechPhase++;
					this.Timer = 0f;
					if (this.SpeechPhase < this.SpeechClip.Length)
					{
						this.Subtitle.text = this.SpeechText[this.SpeechPhase];
						this.MyAudio.clip = this.SpeechClip[this.SpeechPhase];
						this.Delay = this.SpeechDelay[this.SpeechPhase];
						this.MyAudio.Play();
						return;
					}
					if (!EventGlobals.OsanaConversation)
					{
						SceneManager.LoadScene("CreditsScene");
						return;
					}
					DateGlobals.PassDays = 1;
					SceneManager.LoadScene("CalendarScene");
					EventGlobals.OsanaConversation = false;
					return;
				}
			}
		}
		else
		{
			base.transform.Translate(Vector3.forward * -0.01f * Time.deltaTime);
			if (!this.FadeOut)
			{
				this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0f, Time.deltaTime * this.FadeSpeed);
			}
			else
			{
				this.SecondDarkness.alpha = Mathf.MoveTowards(this.SecondDarkness.alpha, 1f, Time.deltaTime * this.FadeSpeed);
				if (this.SecondDarkness.alpha == 1f)
				{
					GameGlobals.DarkEnding = false;
					SceneManager.LoadScene("CreditsScene");
				}
			}
			if (Input.GetButtonDown("A"))
			{
				this.MyAudio.Stop();
			}
			if (!this.MyAudio.isPlaying && this.SpeechPhase < this.SpeechClip.Length - 1)
			{
				this.SpeechPhase++;
				this.Subtitle.text = this.SpeechText[this.SpeechPhase];
				this.MyAudio.clip = this.SpeechClip[this.SpeechPhase];
				this.MyAudio.Play();
				if (this.SpeechPhase == this.SpeechClip.Length - 1)
				{
					this.FadeOut = true;
				}
			}
		}
	}

	// Token: 0x060014DD RID: 5341 RVA: 0x000D5790 File Offset: 0x000D3990
	private void LateUpdate()
	{
		this.Neck.transform.localEulerAngles = new Vector3(0f, this.Neck.transform.localEulerAngles.y, this.Neck.transform.localEulerAngles.z);
	}

	// Token: 0x060014DE RID: 5342 RVA: 0x000D57E4 File Offset: 0x000D39E4
	public void YellowifyLabel(UILabel Label)
	{
		Label.trueTypeFont = this.Arial;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 0f, 1f);
		Label.fontStyle = FontStyle.Bold;
		Label.effectDistance = new Vector2(4f, 4f);
	}

	// Token: 0x0400212C RID: 8492
	public AudioSource MyAudio;

	// Token: 0x0400212D RID: 8493
	public UISprite SecondDarkness;

	// Token: 0x0400212E RID: 8494
	public UISprite Darkness;

	// Token: 0x0400212F RID: 8495
	public UILabel Subtitle;

	// Token: 0x04002130 RID: 8496
	public Animation Senpai;

	// Token: 0x04002131 RID: 8497
	public Transform Neck;

	// Token: 0x04002132 RID: 8498
	public AudioClip[] EightiesSpeechClip;

	// Token: 0x04002133 RID: 8499
	public AudioClip[] SpeechClip;

	// Token: 0x04002134 RID: 8500
	public AudioClip OsanaClip;

	// Token: 0x04002135 RID: 8501
	public AudioClip Slam;

	// Token: 0x04002136 RID: 8502
	public string[] EightiesText;

	// Token: 0x04002137 RID: 8503
	public string[] SpeechText;

	// Token: 0x04002138 RID: 8504
	public float[] SpeechDelay;

	// Token: 0x04002139 RID: 8505
	public float[] SpeechTime;

	// Token: 0x0400213A RID: 8506
	public GameObject RIVAL;

	// Token: 0x0400213B RID: 8507
	public GameObject ELIMINATED;

	// Token: 0x0400213C RID: 8508
	public GameObject SenpaiRopes;

	// Token: 0x0400213D RID: 8509
	public GameObject OsanaRopes;

	// Token: 0x0400213E RID: 8510
	public GameObject Osana;

	// Token: 0x0400213F RID: 8511
	public int SpeechPhase;

	// Token: 0x04002140 RID: 8512
	public float SecondAlpha;

	// Token: 0x04002141 RID: 8513
	public float FadeSpeed = 0.2f;

	// Token: 0x04002142 RID: 8514
	public float TimeLimit;

	// Token: 0x04002143 RID: 8515
	public float Alpha;

	// Token: 0x04002144 RID: 8516
	public float Delay;

	// Token: 0x04002145 RID: 8517
	public float Timer;

	// Token: 0x04002146 RID: 8518
	public bool EightiesEnding;

	// Token: 0x04002147 RID: 8519
	public bool FadeOut;

	// Token: 0x04002148 RID: 8520
	public GameObject[] RivalHair;

	// Token: 0x04002149 RID: 8521
	public Font Arial;
}
