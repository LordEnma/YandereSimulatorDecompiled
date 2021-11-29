using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000265 RID: 613
public class CreditsScript : MonoBehaviour
{
	// Token: 0x17000338 RID: 824
	// (get) Token: 0x060012F0 RID: 4848 RVA: 0x000A7379 File Offset: 0x000A5579
	private bool ShouldStopCredits
	{
		get
		{
			return this.ID == this.JSON.Credits.Length;
		}
	}

	// Token: 0x060012F1 RID: 4849 RVA: 0x000A7390 File Offset: 0x000A5590
	private GameObject SpawnLabel(int size)
	{
		return UnityEngine.Object.Instantiate<GameObject>((size == 1) ? this.SmallCreditsLabel : this.BigCreditsLabel, this.SpawnPoint.position, Quaternion.identity);
	}

	// Token: 0x060012F2 RID: 4850 RVA: 0x000A73BC File Offset: 0x000A55BC
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

	// Token: 0x060012F3 RID: 4851 RVA: 0x000A74A8 File Offset: 0x000A56A8
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

	// Token: 0x060012F4 RID: 4852 RVA: 0x000A769C File Offset: 0x000A589C
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

	// Token: 0x04001ACE RID: 6862
	[SerializeField]
	private JsonScript JSON;

	// Token: 0x04001ACF RID: 6863
	[SerializeField]
	private Transform SpawnPoint;

	// Token: 0x04001AD0 RID: 6864
	[SerializeField]
	private Transform Panel;

	// Token: 0x04001AD1 RID: 6865
	[SerializeField]
	private GameObject SmallCreditsLabel;

	// Token: 0x04001AD2 RID: 6866
	[SerializeField]
	private GameObject BigCreditsLabel;

	// Token: 0x04001AD3 RID: 6867
	[SerializeField]
	private UILabel SkipLabel;

	// Token: 0x04001AD4 RID: 6868
	[SerializeField]
	private UISprite Darkness;

	// Token: 0x04001AD5 RID: 6869
	[SerializeField]
	private int ID;

	// Token: 0x04001AD6 RID: 6870
	public float SpeedUpFactor;

	// Token: 0x04001AD7 RID: 6871
	public float MusicTimer;

	// Token: 0x04001AD8 RID: 6872
	public float TimerLimit;

	// Token: 0x04001AD9 RID: 6873
	public float FadeTimer;

	// Token: 0x04001ADA RID: 6874
	public float Speed = 1f;

	// Token: 0x04001ADB RID: 6875
	public float Timer;

	// Token: 0x04001ADC RID: 6876
	public bool Eighties;

	// Token: 0x04001ADD RID: 6877
	public bool FadeOut;

	// Token: 0x04001ADE RID: 6878
	public bool Begin;

	// Token: 0x04001ADF RID: 6879
	public bool Dark;

	// Token: 0x04001AE0 RID: 6880
	private const int SmallTextSize = 1;

	// Token: 0x04001AE1 RID: 6881
	private const int BigTextSize = 2;

	// Token: 0x04001AE2 RID: 6882
	public AudioClip EightiesCreditsMusic;

	// Token: 0x04001AE3 RID: 6883
	public AudioClip DarkCreditsMusic;

	// Token: 0x04001AE4 RID: 6884
	public AudioSource Jukebox;

	// Token: 0x04001AE5 RID: 6885
	public ParticleSystem Blossoms;
}
