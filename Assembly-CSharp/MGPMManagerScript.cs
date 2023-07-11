using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MGPMManagerScript : MonoBehaviour
{
	public MGPMSpawnerScript[] EnemySpawner;

	public MGPMWaterScript[] Water;

	public MGPMMiyukiScript Miyuki;

	public GameObject StageClearGraphic;

	public GameObject GameOverGraphic;

	public GameObject StartGraphic;

	public Renderer[] WaterRenderer;

	public AudioClip HardModeVoice;

	public AudioClip GameOverMusic;

	public AudioClip VictoryMusic;

	public AudioClip FinalBoss;

	public AudioClip BGM;

	public AudioClip EightiesGameOverMusic;

	public AudioClip EightiesGameplayLoop;

	public AudioClip EightiesVictoryMusic;

	public AudioClip EightiesIntroJingle;

	public AudioClip EightiesFinalBoss;

	public Renderer RightArtwork;

	public Renderer LeftArtwork;

	public Renderer Border;

	public AudioSource Jukebox;

	public Texture WhiteBorder;

	public Texture RightBloody;

	public Texture LeftBloody;

	public Transform Canvas;

	public Texture[] Stars;

	public Text ScoreLabel;

	public Renderer Black;

	public float GameOverTimer;

	public float Timer;

	public bool StageClear;

	public bool Eighties;

	public bool GameOver;

	public bool FadeOut;

	public bool FadeIn;

	public bool Intro;

	public int Score;

	public int ID;

	public Font VCR;

	private void Start()
	{
		if (GameGlobals.HardMode)
		{
			Jukebox.clip = HardModeVoice;
			WaterRenderer[0].material.color = Color.red;
			WaterRenderer[1].material.color = Color.red;
			RightArtwork.material.mainTexture = RightBloody;
			LeftArtwork.material.mainTexture = LeftBloody;
		}
		if (GameGlobals.Eighties)
		{
			Canvas.localEulerAngles = new Vector3(0f, 0f, -90f);
			Canvas.localScale = new Vector3(0.0332f, 0.0332f, 0.0332f);
			StageClearGraphic.transform.localEulerAngles = new Vector3(0f, 0f, 90f);
			GameOverGraphic.transform.localEulerAngles = new Vector3(0f, 0f, 90f);
			StartGraphic.transform.localEulerAngles = new Vector3(0f, 0f, 90f);
			GameOverGraphic.transform.GetChild(0).gameObject.SetActive(value: false);
			RightArtwork.material.color = new Color(0f, 0f, 0f, 1f);
			LeftArtwork.material.color = new Color(0f, 0f, 0f, 1f);
			Miyuki.Hearts[1].transform.localPosition = new Vector3(145f, -260f, -4f);
			Miyuki.Hearts[1].transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			Miyuki.Hearts[1].transform.localScale = new Vector3(16f, 16f, 1f);
			Miyuki.Hearts[2].transform.localPosition = new Vector3(145f, -245f, -4f);
			Miyuki.Hearts[2].transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			Miyuki.Hearts[2].transform.localScale = new Vector3(16f, 16f, 1f);
			Miyuki.Hearts[3].transform.localPosition = new Vector3(145f, -230f, -4f);
			Miyuki.Hearts[3].transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			Miyuki.Hearts[3].transform.localScale = new Vector3(16f, 16f, 1f);
			Miyuki.MagicBar.transform.parent.localPosition = new Vector3(145f, 0f, -1.1f);
			Miyuki.MagicBar.transform.parent.localEulerAngles = new Vector3(0f, 0f, 90f);
			Miyuki.MagicBar.transform.parent.localScale = new Vector3(132f, 10f, 1f);
			Border.material.mainTexture = WhiteBorder;
			ScoreLabel.color = new Color(1f, 1f, 1f, 1f);
			ScoreLabel.font = VCR;
			GameOverMusic = EightiesGameOverMusic;
			VictoryMusic = EightiesVictoryMusic;
			Jukebox.clip = EightiesIntroJingle;
			FinalBoss = EightiesFinalBoss;
			BGM = EightiesGameplayLoop;
			Water[1].Sprite = Stars;
			Water[2].Sprite = Stars;
			Eighties = true;
		}
		Miyuki.transform.localPosition = new Vector3(0f, -300f, 0f);
		Black.material.color = new Color(0f, 0f, 0f, 1f);
		StartGraphic.SetActive(value: false);
		Miyuki.Gameplay = false;
		for (ID = 1; ID < EnemySpawner.Length; ID++)
		{
			EnemySpawner[ID].enabled = false;
		}
		Time.timeScale = 1f;
	}

	private void Update()
	{
		ScoreLabel.text = "Score: " + Score * Miyuki.Health;
		if (StageClear)
		{
			GameOverTimer += Time.deltaTime;
			if (GameOverTimer > 1f)
			{
				Miyuki.transform.localPosition = new Vector3(Miyuki.transform.localPosition.x, Miyuki.transform.localPosition.y + Time.deltaTime * 10f, Miyuki.transform.localPosition.z);
				if (!StageClearGraphic.activeInHierarchy)
				{
					StageClearGraphic.SetActive(value: true);
					Jukebox.clip = VictoryMusic;
					Jukebox.loop = false;
					Jukebox.volume = 1f;
					Jukebox.Play();
				}
				if (GameOverTimer > 9f)
				{
					FadeOut = true;
				}
			}
			if (!FadeOut)
			{
				return;
			}
			Black.material.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(Black.material.color.a, 1f, Time.deltaTime));
			Jukebox.volume = 1f - Black.material.color.a;
			if (Black.material.color.a == 1f)
			{
				if (!Eighties)
				{
					SceneManager.LoadScene("MiyukiThanksScene");
				}
				else
				{
					SceneManager.LoadScene("HomeScene");
				}
			}
			return;
		}
		if (!GameOver)
		{
			if (!Intro)
			{
				return;
			}
			if (FadeIn)
			{
				Black.material.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(Black.material.color.a, 0f, Time.deltaTime));
				if (Black.material.color.a == 0f)
				{
					Jukebox.Play();
					FadeIn = false;
				}
				return;
			}
			Miyuki.transform.localPosition = new Vector3(0f, Mathf.MoveTowards(Miyuki.transform.localPosition.y, -120f, Time.deltaTime * 60f), 0f);
			if (Miyuki.transform.localPosition.y != -120f)
			{
				return;
			}
			if (!Jukebox.isPlaying)
			{
				Jukebox.loop = true;
				Jukebox.clip = BGM;
				Jukebox.Play();
				if (GameGlobals.HardMode)
				{
					Jukebox.pitch = 0.2f;
				}
			}
			StartGraphic.SetActive(value: true);
			Timer += Time.deltaTime;
			if ((double)Timer > 3.5)
			{
				StartGraphic.SetActive(value: false);
				for (ID = 1; ID < EnemySpawner.Length; ID++)
				{
					EnemySpawner[ID].enabled = true;
				}
				Miyuki.Gameplay = true;
				Intro = false;
			}
			return;
		}
		GameOverTimer += Time.deltaTime;
		if (GameOverTimer > 3f)
		{
			if (!GameOverGraphic.activeInHierarchy)
			{
				GameOverGraphic.SetActive(value: true);
				Jukebox.clip = GameOverMusic;
				Jukebox.loop = false;
				Jukebox.Play();
			}
			else if (Input.anyKeyDown)
			{
				FadeOut = true;
			}
		}
		if (FadeOut)
		{
			Black.material.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(Black.material.color.a, 1f, Time.deltaTime));
			Jukebox.volume = 1f - Black.material.color.a;
			if (Black.material.color.a == 1f)
			{
				SceneManager.LoadScene("MiyukiTitleScene");
			}
		}
	}

	public void BeginGameOver()
	{
		Jukebox.Stop();
		GameOver = true;
		Miyuki.enabled = false;
	}
}
