using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003BC RID: 956
public class PostCreditsScript : MonoBehaviour
{
	// Token: 0x06001B0E RID: 6926 RVA: 0x0012BBFC File Offset: 0x00129DFC
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
		this.Subtitle.text = "";
		Time.timeScale = 1f;
		this.Logo.gameObject.SetActive(false);
		this.LovesickLogo.SetActive(false);
	}

	// Token: 0x06001B0F RID: 6927 RVA: 0x0012BC64 File Offset: 0x00129E64
	private void Update()
	{
		this.SkipTimer += Time.deltaTime;
		if (this.SkipTimer > 5f)
		{
			this.SkipPanel.alpha -= Time.deltaTime;
		}
		if (this.EndEarly)
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.5f);
			this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
			this.SkipPanel.alpha -= Time.deltaTime;
			this.Headmaster.volume -= Time.deltaTime;
			this.Jukebox.volume -= Time.deltaTime;
			this.Buzzing.volume -= Time.deltaTime;
			this.Darkness.material.color = new Color(0f, 0f, 0f, this.Alpha);
			this.Subtitle.text = "";
			if (this.Alpha == 1f)
			{
				SceneManager.LoadScene("ThanksForPlayingScene");
			}
		}
		else if (Input.GetButton("X"))
		{
			this.SkipPanel.alpha = 1f;
			this.SkipTimer = 0f;
			this.SkipCircle.fillAmount -= Time.deltaTime;
			if (this.SkipCircle.fillAmount == 0f)
			{
				this.EndEarly = true;
			}
		}
		else
		{
			this.SkipCircle.fillAmount = 1f;
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += 1f;
		}
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale -= 1f;
		}
		this.Speed += Time.deltaTime * 0.001f;
		base.transform.position = Vector3.Lerp(base.transform.position, this.Destination.position, Time.deltaTime * this.Speed);
		this.Rotation = Mathf.Lerp(this.Rotation, -45f, Time.deltaTime * this.Speed);
		base.transform.eulerAngles = new Vector3(0f, this.Rotation, 0f);
		if (this.Headmaster.time > 69f)
		{
			this.Jukebox.volume -= Time.deltaTime * 0.2f;
		}
		if (this.Phase == 0)
		{
			if (Input.GetKeyDown("space"))
			{
				this.Alpha = 0f;
			}
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.2f);
			this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
			if (this.Alpha == 0f)
			{
				this.Subtitle.text = this.Lines[this.SpeechID];
				this.Headmaster.Play();
				this.SpeechID++;
				this.Phase++;
				return;
			}
		}
		else if (this.Phase == 1)
		{
			if (Input.GetKeyDown("space"))
			{
				this.Headmaster.time = 68f;
			}
			this.Headmaster.pitch = Time.timeScale;
			if (this.Headmaster.time >= this.Times[this.SpeechID])
			{
				this.Subtitle.text = this.Lines[this.SpeechID];
				this.SpeechID++;
				if (this.SpeechID == 16)
				{
					this.Darkness.color = new Color(0f, 0f, 0f, 1f);
					return;
				}
				if (this.SpeechID == 17)
				{
					this.Jukebox.clip = this.CinematicHit;
					this.Jukebox.volume = 1f;
					this.Jukebox.Play();
					this.Logo.gameObject.SetActive(true);
					this.Phase++;
					return;
				}
			}
		}
		else if (this.Phase == 2)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 13f)
			{
				SceneManager.LoadScene("ThanksForPlayingScene");
			}
			else if (this.Timer > 5f)
			{
				this.Logo.alpha -= Time.deltaTime * 0.2f;
			}
			this.Logo.transform.localScale += new Vector3(Time.deltaTime * 0.02f, Time.deltaTime * 0.02f, Time.deltaTime * 0.02f);
			this.LovesickLogo.transform.localScale += new Vector3(Time.deltaTime * 0.02f, Time.deltaTime * 0.02f, Time.deltaTime * 0.02f);
		}
	}

	// Token: 0x04002DC1 RID: 11713
	public GameObject LovesickLogo;

	// Token: 0x04002DC2 RID: 11714
	public UITexture Logo;

	// Token: 0x04002DC3 RID: 11715
	public UIPanel SkipPanel;

	// Token: 0x04002DC4 RID: 11716
	public AudioSource Headmaster;

	// Token: 0x04002DC5 RID: 11717
	public AudioSource Jukebox;

	// Token: 0x04002DC6 RID: 11718
	public AudioSource Buzzing;

	// Token: 0x04002DC7 RID: 11719
	public AudioClip CinematicHit;

	// Token: 0x04002DC8 RID: 11720
	public Transform Destination;

	// Token: 0x04002DC9 RID: 11721
	public UISprite SkipCircle;

	// Token: 0x04002DCA RID: 11722
	public UISprite Darkness;

	// Token: 0x04002DCB RID: 11723
	public UILabel Subtitle;

	// Token: 0x04002DCC RID: 11724
	public string[] Lines;

	// Token: 0x04002DCD RID: 11725
	public float[] Times;

	// Token: 0x04002DCE RID: 11726
	public float SkipTimer;

	// Token: 0x04002DCF RID: 11727
	public float Rotation;

	// Token: 0x04002DD0 RID: 11728
	public float Alpha;

	// Token: 0x04002DD1 RID: 11729
	public float Speed;

	// Token: 0x04002DD2 RID: 11730
	public float Timer;

	// Token: 0x04002DD3 RID: 11731
	public bool EndEarly;

	// Token: 0x04002DD4 RID: 11732
	public int SpeechID;

	// Token: 0x04002DD5 RID: 11733
	public int Phase;
}
