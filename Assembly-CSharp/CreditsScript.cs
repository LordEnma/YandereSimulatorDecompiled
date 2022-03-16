using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000267 RID: 615
public class CreditsScript : MonoBehaviour
{
	// Token: 0x17000338 RID: 824
	// (get) Token: 0x060012FF RID: 4863 RVA: 0x000A83C1 File Offset: 0x000A65C1
	private bool ShouldStopCredits
	{
		get
		{
			return this.ID == this.JSON.Credits.Length;
		}
	}

	// Token: 0x06001300 RID: 4864 RVA: 0x000A83D8 File Offset: 0x000A65D8
	private GameObject SpawnLabel(int size)
	{
		return UnityEngine.Object.Instantiate<GameObject>((size == 1) ? this.SmallCreditsLabel : this.BigCreditsLabel, this.SpawnPoint.position, Quaternion.identity);
	}

	// Token: 0x06001301 RID: 4865 RVA: 0x000A8404 File Offset: 0x000A6604
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

	// Token: 0x06001302 RID: 4866 RVA: 0x000A84F0 File Offset: 0x000A66F0
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

	// Token: 0x06001303 RID: 4867 RVA: 0x000A86E4 File Offset: 0x000A68E4
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

	// Token: 0x04001B09 RID: 6921
	[SerializeField]
	private JsonScript JSON;

	// Token: 0x04001B0A RID: 6922
	[SerializeField]
	private Transform SpawnPoint;

	// Token: 0x04001B0B RID: 6923
	[SerializeField]
	private Transform Panel;

	// Token: 0x04001B0C RID: 6924
	[SerializeField]
	private GameObject SmallCreditsLabel;

	// Token: 0x04001B0D RID: 6925
	[SerializeField]
	private GameObject BigCreditsLabel;

	// Token: 0x04001B0E RID: 6926
	[SerializeField]
	private UILabel SkipLabel;

	// Token: 0x04001B0F RID: 6927
	[SerializeField]
	private UISprite Darkness;

	// Token: 0x04001B10 RID: 6928
	[SerializeField]
	private int ID;

	// Token: 0x04001B11 RID: 6929
	public float SpeedUpFactor;

	// Token: 0x04001B12 RID: 6930
	public float MusicTimer;

	// Token: 0x04001B13 RID: 6931
	public float TimerLimit;

	// Token: 0x04001B14 RID: 6932
	public float FadeTimer;

	// Token: 0x04001B15 RID: 6933
	public float Speed = 1f;

	// Token: 0x04001B16 RID: 6934
	public float Timer;

	// Token: 0x04001B17 RID: 6935
	public bool Eighties;

	// Token: 0x04001B18 RID: 6936
	public bool FadeOut;

	// Token: 0x04001B19 RID: 6937
	public bool Begin;

	// Token: 0x04001B1A RID: 6938
	public bool Dark;

	// Token: 0x04001B1B RID: 6939
	private const int SmallTextSize = 1;

	// Token: 0x04001B1C RID: 6940
	private const int BigTextSize = 2;

	// Token: 0x04001B1D RID: 6941
	public AudioClip EightiesCreditsMusic;

	// Token: 0x04001B1E RID: 6942
	public AudioClip DarkCreditsMusic;

	// Token: 0x04001B1F RID: 6943
	public AudioSource Jukebox;

	// Token: 0x04001B20 RID: 6944
	public ParticleSystem Blossoms;
}
