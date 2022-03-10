using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003B8 RID: 952
public class PostCreditsScript : MonoBehaviour
{
	// Token: 0x06001AF5 RID: 6901 RVA: 0x0012A6A8 File Offset: 0x001288A8
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
		this.Subtitle.text = "";
		Time.timeScale = 1f;
		this.Logo.gameObject.SetActive(false);
		this.LovesickLogo.SetActive(false);
	}

	// Token: 0x06001AF6 RID: 6902 RVA: 0x0012A710 File Offset: 0x00128910
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

	// Token: 0x04002D79 RID: 11641
	public GameObject LovesickLogo;

	// Token: 0x04002D7A RID: 11642
	public UITexture Logo;

	// Token: 0x04002D7B RID: 11643
	public UIPanel SkipPanel;

	// Token: 0x04002D7C RID: 11644
	public AudioSource Headmaster;

	// Token: 0x04002D7D RID: 11645
	public AudioSource Jukebox;

	// Token: 0x04002D7E RID: 11646
	public AudioSource Buzzing;

	// Token: 0x04002D7F RID: 11647
	public AudioClip CinematicHit;

	// Token: 0x04002D80 RID: 11648
	public Transform Destination;

	// Token: 0x04002D81 RID: 11649
	public UISprite SkipCircle;

	// Token: 0x04002D82 RID: 11650
	public UISprite Darkness;

	// Token: 0x04002D83 RID: 11651
	public UILabel Subtitle;

	// Token: 0x04002D84 RID: 11652
	public string[] Lines;

	// Token: 0x04002D85 RID: 11653
	public float[] Times;

	// Token: 0x04002D86 RID: 11654
	public float SkipTimer;

	// Token: 0x04002D87 RID: 11655
	public float Rotation;

	// Token: 0x04002D88 RID: 11656
	public float Alpha;

	// Token: 0x04002D89 RID: 11657
	public float Speed;

	// Token: 0x04002D8A RID: 11658
	public float Timer;

	// Token: 0x04002D8B RID: 11659
	public bool EndEarly;

	// Token: 0x04002D8C RID: 11660
	public int SpeechID;

	// Token: 0x04002D8D RID: 11661
	public int Phase;
}
