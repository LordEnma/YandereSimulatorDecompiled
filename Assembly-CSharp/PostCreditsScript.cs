using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003B8 RID: 952
public class PostCreditsScript : MonoBehaviour
{
	// Token: 0x06001AFF RID: 6911 RVA: 0x0012B358 File Offset: 0x00129558
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
		this.Subtitle.text = "";
		Time.timeScale = 1f;
		this.Logo.gameObject.SetActive(false);
		this.LovesickLogo.SetActive(false);
	}

	// Token: 0x06001B00 RID: 6912 RVA: 0x0012B3C0 File Offset: 0x001295C0
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

	// Token: 0x04002DA6 RID: 11686
	public GameObject LovesickLogo;

	// Token: 0x04002DA7 RID: 11687
	public UITexture Logo;

	// Token: 0x04002DA8 RID: 11688
	public UIPanel SkipPanel;

	// Token: 0x04002DA9 RID: 11689
	public AudioSource Headmaster;

	// Token: 0x04002DAA RID: 11690
	public AudioSource Jukebox;

	// Token: 0x04002DAB RID: 11691
	public AudioSource Buzzing;

	// Token: 0x04002DAC RID: 11692
	public AudioClip CinematicHit;

	// Token: 0x04002DAD RID: 11693
	public Transform Destination;

	// Token: 0x04002DAE RID: 11694
	public UISprite SkipCircle;

	// Token: 0x04002DAF RID: 11695
	public UISprite Darkness;

	// Token: 0x04002DB0 RID: 11696
	public UILabel Subtitle;

	// Token: 0x04002DB1 RID: 11697
	public string[] Lines;

	// Token: 0x04002DB2 RID: 11698
	public float[] Times;

	// Token: 0x04002DB3 RID: 11699
	public float SkipTimer;

	// Token: 0x04002DB4 RID: 11700
	public float Rotation;

	// Token: 0x04002DB5 RID: 11701
	public float Alpha;

	// Token: 0x04002DB6 RID: 11702
	public float Speed;

	// Token: 0x04002DB7 RID: 11703
	public float Timer;

	// Token: 0x04002DB8 RID: 11704
	public bool EndEarly;

	// Token: 0x04002DB9 RID: 11705
	public int SpeechID;

	// Token: 0x04002DBA RID: 11706
	public int Phase;
}
