using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003B8 RID: 952
public class PostCreditsScript : MonoBehaviour
{
	// Token: 0x06001AF4 RID: 6900 RVA: 0x0012A2D0 File Offset: 0x001284D0
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
		this.Subtitle.text = "";
		Time.timeScale = 1f;
		this.Logo.gameObject.SetActive(false);
		this.LovesickLogo.SetActive(false);
	}

	// Token: 0x06001AF5 RID: 6901 RVA: 0x0012A338 File Offset: 0x00128538
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

	// Token: 0x04002D63 RID: 11619
	public GameObject LovesickLogo;

	// Token: 0x04002D64 RID: 11620
	public UITexture Logo;

	// Token: 0x04002D65 RID: 11621
	public UIPanel SkipPanel;

	// Token: 0x04002D66 RID: 11622
	public AudioSource Headmaster;

	// Token: 0x04002D67 RID: 11623
	public AudioSource Jukebox;

	// Token: 0x04002D68 RID: 11624
	public AudioSource Buzzing;

	// Token: 0x04002D69 RID: 11625
	public AudioClip CinematicHit;

	// Token: 0x04002D6A RID: 11626
	public Transform Destination;

	// Token: 0x04002D6B RID: 11627
	public UISprite SkipCircle;

	// Token: 0x04002D6C RID: 11628
	public UISprite Darkness;

	// Token: 0x04002D6D RID: 11629
	public UILabel Subtitle;

	// Token: 0x04002D6E RID: 11630
	public string[] Lines;

	// Token: 0x04002D6F RID: 11631
	public float[] Times;

	// Token: 0x04002D70 RID: 11632
	public float SkipTimer;

	// Token: 0x04002D71 RID: 11633
	public float Rotation;

	// Token: 0x04002D72 RID: 11634
	public float Alpha;

	// Token: 0x04002D73 RID: 11635
	public float Speed;

	// Token: 0x04002D74 RID: 11636
	public float Timer;

	// Token: 0x04002D75 RID: 11637
	public bool EndEarly;

	// Token: 0x04002D76 RID: 11638
	public int SpeechID;

	// Token: 0x04002D77 RID: 11639
	public int Phase;
}
