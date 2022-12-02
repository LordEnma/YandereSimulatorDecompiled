using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
	[SerializeField]
	private JsonScript JSON;

	[SerializeField]
	private Transform SpawnPoint;

	[SerializeField]
	private Transform Panel;

	[SerializeField]
	private GameObject SmallCreditsLabel;

	[SerializeField]
	private GameObject BigCreditsLabel;

	[SerializeField]
	private UILabel SkipLabel;

	[SerializeField]
	private UISprite Darkness;

	[SerializeField]
	private int ID;

	public float SpeedUpFactor;

	public float MusicTimer;

	public float TimerLimit;

	public float FadeTimer;

	public float Speed = 1f;

	public float Timer;

	public bool Eighties;

	public bool FadeOut;

	public bool Begin;

	public bool Dark;

	private const int SmallTextSize = 1;

	private const int BigTextSize = 2;

	public AudioClip EightiesCreditsMusic;

	public AudioClip DarkCreditsMusic;

	public AudioSource Jukebox;

	public ParticleSystem Blossoms;

	private bool ShouldStopCredits
	{
		get
		{
			return ID == JSON.Credits.Length;
		}
	}

	private GameObject SpawnLabel(int size)
	{
		return Object.Instantiate((size == 1) ? SmallCreditsLabel : BigCreditsLabel, SpawnPoint.position, Quaternion.identity);
	}

	private void Start()
	{
		if (GameGlobals.TransitionToPostCredits || GameGlobals.DarkEnding)
		{
			GameGlobals.DarkEnding = false;
			Jukebox.clip = DarkCreditsMusic;
			Darkness.color = new Color(0f, 0f, 0f, 0f);
			Blossoms.startColor = new Color(0.5f, 0f, 0f, 1f);
			SkipLabel.color = new Color(0.5f, 0f, 0f, 1f);
			Dark = true;
		}
		if (GameGlobals.Eighties)
		{
			Camera.main.backgroundColor = new Color(0.05f, 0.05f, 0.05f, 1f);
			Jukebox.clip = EightiesCreditsMusic;
			Eighties = true;
		}
	}

	private void Update()
	{
		MusicTimer += Time.deltaTime;
		if (!Begin)
		{
			Timer += Time.deltaTime;
			if (Timer > 1f)
			{
				Begin = true;
				Jukebox.Play();
				Timer = 0f;
				SpawnCredit();
			}
		}
		else
		{
			if (!ShouldStopCredits)
			{
				Timer += Time.deltaTime * Speed;
				if (Timer >= TimerLimit)
				{
					SpawnCredit();
					Timer -= TimerLimit;
				}
			}
			if (Input.GetButtonDown("X") || MusicTimer >= Jukebox.clip.length)
			{
				FadeOut = true;
			}
		}
		if (FadeOut)
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
			Jukebox.volume -= Time.deltaTime;
			if (Darkness.color.a == 1f)
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
			Jukebox.pitch = Time.timeScale;
		}
	}

	public void SpawnCredit()
	{
		CreditJson creditJson = JSON.Credits[ID];
		GameObject gameObject = SpawnLabel(creditJson.Size);
		TimerLimit = (float)creditJson.Size * SpeedUpFactor;
		gameObject.transform.parent = Panel;
		gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
		gameObject.GetComponent<UILabel>().text = creditJson.Name;
		if (Eighties)
		{
			gameObject.GetComponent<UILabel>().color = new Color(0.8235294f, 0.6431373f, 1f, 1f);
		}
		else if (Dark)
		{
			gameObject.GetComponent<UILabel>().color = new Color(0.5f, 0f, 0f, 1f);
		}
		ID++;
	}
}
