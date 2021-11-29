using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003B3 RID: 947
public class PostCreditsScript : MonoBehaviour
{
	// Token: 0x06001AD0 RID: 6864 RVA: 0x00127DBC File Offset: 0x00125FBC
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
		this.Subtitle.text = "";
		Time.timeScale = 1f;
		this.Logo.gameObject.SetActive(false);
		this.LovesickLogo.SetActive(false);
	}

	// Token: 0x06001AD1 RID: 6865 RVA: 0x00127E24 File Offset: 0x00126024
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

	// Token: 0x04002D0B RID: 11531
	public GameObject LovesickLogo;

	// Token: 0x04002D0C RID: 11532
	public UITexture Logo;

	// Token: 0x04002D0D RID: 11533
	public UIPanel SkipPanel;

	// Token: 0x04002D0E RID: 11534
	public AudioSource Headmaster;

	// Token: 0x04002D0F RID: 11535
	public AudioSource Jukebox;

	// Token: 0x04002D10 RID: 11536
	public AudioSource Buzzing;

	// Token: 0x04002D11 RID: 11537
	public AudioClip CinematicHit;

	// Token: 0x04002D12 RID: 11538
	public Transform Destination;

	// Token: 0x04002D13 RID: 11539
	public UISprite SkipCircle;

	// Token: 0x04002D14 RID: 11540
	public UISprite Darkness;

	// Token: 0x04002D15 RID: 11541
	public UILabel Subtitle;

	// Token: 0x04002D16 RID: 11542
	public string[] Lines;

	// Token: 0x04002D17 RID: 11543
	public float[] Times;

	// Token: 0x04002D18 RID: 11544
	public float SkipTimer;

	// Token: 0x04002D19 RID: 11545
	public float Rotation;

	// Token: 0x04002D1A RID: 11546
	public float Alpha;

	// Token: 0x04002D1B RID: 11547
	public float Speed;

	// Token: 0x04002D1C RID: 11548
	public float Timer;

	// Token: 0x04002D1D RID: 11549
	public bool EndEarly;

	// Token: 0x04002D1E RID: 11550
	public int SpeechID;

	// Token: 0x04002D1F RID: 11551
	public int Phase;
}
