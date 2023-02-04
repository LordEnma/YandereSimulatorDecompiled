using UnityEngine;
using UnityEngine.SceneManagement;

public class PostCreditsScript : MonoBehaviour
{
	public GameObject LovesickLogo;

	public UITexture Logo;

	public UIPanel SkipPanel;

	public AudioSource Headmaster;

	public AudioSource Jukebox;

	public AudioSource Buzzing;

	public AudioClip CinematicHit;

	public Transform Destination;

	public UISprite SkipCircle;

	public UISprite Darkness;

	public UILabel Subtitle;

	public string[] Lines;

	public float[] Times;

	public float SkipTimer;

	public float Rotation;

	public float Alpha;

	public float Speed;

	public float Timer;

	public bool EndEarly;

	public int SpeechID;

	public int Phase;

	private void Start()
	{
		Darkness.color = new Color(0f, 0f, 0f, 1f);
		Subtitle.text = "";
		Time.timeScale = 1f;
		Logo.gameObject.SetActive(value: false);
		LovesickLogo.SetActive(value: false);
	}

	private void Update()
	{
		SkipTimer += Time.deltaTime;
		if (SkipTimer > 5f)
		{
			SkipPanel.alpha -= Time.deltaTime;
		}
		if (EndEarly)
		{
			Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime * 0.5f);
			Darkness.color = new Color(0f, 0f, 0f, Alpha);
			SkipPanel.alpha -= Time.deltaTime;
			Headmaster.volume -= Time.deltaTime;
			Jukebox.volume -= Time.deltaTime;
			Buzzing.volume -= Time.deltaTime;
			Darkness.material.color = new Color(0f, 0f, 0f, Alpha);
			Subtitle.text = "";
			if (Alpha == 1f)
			{
				SceneManager.LoadScene("ThanksForPlayingScene");
			}
		}
		else if (Input.GetButton("X"))
		{
			SkipPanel.alpha = 1f;
			SkipTimer = 0f;
			SkipCircle.fillAmount -= Time.deltaTime;
			if (SkipCircle.fillAmount == 0f)
			{
				EndEarly = true;
			}
		}
		else
		{
			SkipCircle.fillAmount = 1f;
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += 1f;
		}
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale -= 1f;
		}
		Speed += Time.deltaTime * 0.001f;
		base.transform.position = Vector3.Lerp(base.transform.position, Destination.position, Time.deltaTime * Speed);
		Rotation = Mathf.Lerp(Rotation, -45f, Time.deltaTime * Speed);
		base.transform.eulerAngles = new Vector3(0f, Rotation, 0f);
		if (Headmaster.time > 69f)
		{
			Jukebox.volume -= Time.deltaTime * 0.2f;
		}
		if (Phase == 0)
		{
			if (Input.GetKeyDown("space"))
			{
				Alpha = 0f;
			}
			Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * 0.2f);
			Darkness.color = new Color(0f, 0f, 0f, Alpha);
			if (Alpha == 0f)
			{
				Subtitle.text = Lines[SpeechID];
				Headmaster.Play();
				SpeechID++;
				Phase++;
			}
		}
		else if (Phase == 1)
		{
			if (Input.GetKeyDown("space"))
			{
				Headmaster.time = 68f;
			}
			Headmaster.pitch = Time.timeScale;
			if (Headmaster.time >= Times[SpeechID])
			{
				Subtitle.text = Lines[SpeechID];
				SpeechID++;
				if (SpeechID == 16)
				{
					Darkness.color = new Color(0f, 0f, 0f, 1f);
				}
				else if (SpeechID == 17)
				{
					Jukebox.clip = CinematicHit;
					Jukebox.volume = 1f;
					Jukebox.Play();
					Logo.gameObject.SetActive(value: true);
					Phase++;
				}
			}
		}
		else if (Phase == 2)
		{
			Timer += Time.deltaTime;
			if (Timer > 13f)
			{
				SceneManager.LoadScene("ThanksForPlayingScene");
			}
			else if (Timer > 5f)
			{
				Logo.alpha -= Time.deltaTime * 0.2f;
			}
			Logo.transform.localScale += new Vector3(Time.deltaTime * 0.02f, Time.deltaTime * 0.02f, Time.deltaTime * 0.02f);
			LovesickLogo.transform.localScale += new Vector3(Time.deltaTime * 0.02f, Time.deltaTime * 0.02f, Time.deltaTime * 0.02f);
		}
	}
}
