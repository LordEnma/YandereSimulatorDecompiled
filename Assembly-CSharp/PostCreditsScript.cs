using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003B4 RID: 948
public class PostCreditsScript : MonoBehaviour
{
	// Token: 0x06001ADA RID: 6874 RVA: 0x0012894C File Offset: 0x00126B4C
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
		this.Subtitle.text = "";
		Time.timeScale = 1f;
		this.Logo.gameObject.SetActive(false);
		this.LovesickLogo.SetActive(false);
	}

	// Token: 0x06001ADB RID: 6875 RVA: 0x001289B4 File Offset: 0x00126BB4
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

	// Token: 0x04002D39 RID: 11577
	public GameObject LovesickLogo;

	// Token: 0x04002D3A RID: 11578
	public UITexture Logo;

	// Token: 0x04002D3B RID: 11579
	public UIPanel SkipPanel;

	// Token: 0x04002D3C RID: 11580
	public AudioSource Headmaster;

	// Token: 0x04002D3D RID: 11581
	public AudioSource Jukebox;

	// Token: 0x04002D3E RID: 11582
	public AudioSource Buzzing;

	// Token: 0x04002D3F RID: 11583
	public AudioClip CinematicHit;

	// Token: 0x04002D40 RID: 11584
	public Transform Destination;

	// Token: 0x04002D41 RID: 11585
	public UISprite SkipCircle;

	// Token: 0x04002D42 RID: 11586
	public UISprite Darkness;

	// Token: 0x04002D43 RID: 11587
	public UILabel Subtitle;

	// Token: 0x04002D44 RID: 11588
	public string[] Lines;

	// Token: 0x04002D45 RID: 11589
	public float[] Times;

	// Token: 0x04002D46 RID: 11590
	public float SkipTimer;

	// Token: 0x04002D47 RID: 11591
	public float Rotation;

	// Token: 0x04002D48 RID: 11592
	public float Alpha;

	// Token: 0x04002D49 RID: 11593
	public float Speed;

	// Token: 0x04002D4A RID: 11594
	public float Timer;

	// Token: 0x04002D4B RID: 11595
	public bool EndEarly;

	// Token: 0x04002D4C RID: 11596
	public int SpeechID;

	// Token: 0x04002D4D RID: 11597
	public int Phase;
}
