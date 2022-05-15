using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000268 RID: 616
public class CreditsScript : MonoBehaviour
{
	// Token: 0x17000338 RID: 824
	// (get) Token: 0x06001306 RID: 4870 RVA: 0x000A8CC9 File Offset: 0x000A6EC9
	private bool ShouldStopCredits
	{
		get
		{
			return this.ID == this.JSON.Credits.Length;
		}
	}

	// Token: 0x06001307 RID: 4871 RVA: 0x000A8CE0 File Offset: 0x000A6EE0
	private GameObject SpawnLabel(int size)
	{
		return UnityEngine.Object.Instantiate<GameObject>((size == 1) ? this.SmallCreditsLabel : this.BigCreditsLabel, this.SpawnPoint.position, Quaternion.identity);
	}

	// Token: 0x06001308 RID: 4872 RVA: 0x000A8D0C File Offset: 0x000A6F0C
	private void Start()
	{
		if (GameGlobals.TransitionToPostCredits || GameGlobals.DarkEnding)
		{
			GameGlobals.DarkEnding = false;
			this.Jukebox.clip = this.DarkCreditsMusic;
			this.Darkness.color = new Color(0f, 0f, 0f, 0f);
			this.Blossoms.startColor = new Color(0.5f, 0f, 0f, 1f);
			this.SkipLabel.color = new Color(0.5f, 0f, 0f, 1f);
			this.Dark = true;
		}
		if (GameGlobals.Eighties)
		{
			Camera.main.backgroundColor = new Color(0.05f, 0.05f, 0.05f, 1f);
			this.Jukebox.clip = this.EightiesCreditsMusic;
			this.Eighties = true;
		}
	}

	// Token: 0x06001309 RID: 4873 RVA: 0x000A8DF8 File Offset: 0x000A6FF8
	private void Update()
	{
		this.MusicTimer += Time.deltaTime;
		if (!this.Begin)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				this.Begin = true;
				this.Jukebox.Play();
				this.Timer = 0f;
				this.SpawnCredit();
			}
		}
		else
		{
			if (!this.ShouldStopCredits)
			{
				this.Timer += Time.deltaTime * this.Speed;
				if (this.Timer >= this.TimerLimit)
				{
					this.SpawnCredit();
					this.Timer -= this.TimerLimit;
				}
			}
			if (Input.GetButtonDown("X") || this.MusicTimer >= this.Jukebox.clip.length)
			{
				this.FadeOut = true;
			}
		}
		if (this.FadeOut)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
			this.Jukebox.volume -= Time.deltaTime;
			if (this.Darkness.color.a == 1f)
			{
				if (GameGlobals.TransitionToPostCredits)
				{
					SceneManager.LoadScene("PostCreditsScene");
				}
				else if (GameGlobals.TrueEnding)
				{
					SceneManager.LoadScene("TrueEndingScene");
				}
				else
				{
					SceneManager.LoadScene("NewTitleScene");
				}
			}
		}
		bool keyDown = Input.GetKeyDown(KeyCode.Minus);
		bool keyDown2 = Input.GetKeyDown(KeyCode.Equals);
		if (keyDown)
		{
			Time.timeScale -= 1f;
		}
		else if (keyDown2)
		{
			Time.timeScale += 1f;
		}
		if (keyDown || keyDown2)
		{
			this.Jukebox.pitch = Time.timeScale;
		}
	}

	// Token: 0x0600130A RID: 4874 RVA: 0x000A8FEC File Offset: 0x000A71EC
	public void SpawnCredit()
	{
		CreditJson creditJson = this.JSON.Credits[this.ID];
		GameObject gameObject = this.SpawnLabel(creditJson.Size);
		this.TimerLimit = (float)creditJson.Size * this.SpeedUpFactor;
		gameObject.transform.parent = this.Panel;
		gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
		gameObject.GetComponent<UILabel>().text = creditJson.Name;
		if (this.Eighties)
		{
			gameObject.GetComponent<UILabel>().color = new Color(0.8235294f, 0.6431373f, 1f, 1f);
		}
		else if (this.Dark)
		{
			gameObject.GetComponent<UILabel>().color = new Color(0.5f, 0f, 0f, 1f);
		}
		this.ID++;
	}

	// Token: 0x04001B1C RID: 6940
	[SerializeField]
	private JsonScript JSON;

	// Token: 0x04001B1D RID: 6941
	[SerializeField]
	private Transform SpawnPoint;

	// Token: 0x04001B1E RID: 6942
	[SerializeField]
	private Transform Panel;

	// Token: 0x04001B1F RID: 6943
	[SerializeField]
	private GameObject SmallCreditsLabel;

	// Token: 0x04001B20 RID: 6944
	[SerializeField]
	private GameObject BigCreditsLabel;

	// Token: 0x04001B21 RID: 6945
	[SerializeField]
	private UILabel SkipLabel;

	// Token: 0x04001B22 RID: 6946
	[SerializeField]
	private UISprite Darkness;

	// Token: 0x04001B23 RID: 6947
	[SerializeField]
	private int ID;

	// Token: 0x04001B24 RID: 6948
	public float SpeedUpFactor;

	// Token: 0x04001B25 RID: 6949
	public float MusicTimer;

	// Token: 0x04001B26 RID: 6950
	public float TimerLimit;

	// Token: 0x04001B27 RID: 6951
	public float FadeTimer;

	// Token: 0x04001B28 RID: 6952
	public float Speed = 1f;

	// Token: 0x04001B29 RID: 6953
	public float Timer;

	// Token: 0x04001B2A RID: 6954
	public bool Eighties;

	// Token: 0x04001B2B RID: 6955
	public bool FadeOut;

	// Token: 0x04001B2C RID: 6956
	public bool Begin;

	// Token: 0x04001B2D RID: 6957
	public bool Dark;

	// Token: 0x04001B2E RID: 6958
	private const int SmallTextSize = 1;

	// Token: 0x04001B2F RID: 6959
	private const int BigTextSize = 2;

	// Token: 0x04001B30 RID: 6960
	public AudioClip EightiesCreditsMusic;

	// Token: 0x04001B31 RID: 6961
	public AudioClip DarkCreditsMusic;

	// Token: 0x04001B32 RID: 6962
	public AudioSource Jukebox;

	// Token: 0x04001B33 RID: 6963
	public ParticleSystem Blossoms;
}
