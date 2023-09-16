using UnityEngine;
using UnityEngine.SceneManagement;

public class PostCreditsScript : MonoBehaviour
{
	public Animation HeadmasterAnim;

	public GameObject LovesickLogo;

	public UITexture Logo;

	public UIPanel SkipPanel;

	public AudioSource Headmaster;

	public AudioSource Jukebox;

	public AudioSource Buzzing;

	public AudioClip CinematicHit;

	public Transform HeadmasterParent;

	public Transform CameraTarget;

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
		HeadmasterAnim["HeadmasterPhoneCall"].speed = 0f;
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
		else if (Input.GetButton(InputNames.Xbox_X))
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
		Speed += Time.deltaTime * 0.0015f;
		base.transform.position = Vector3.Lerp(base.transform.position, Destination.position, Time.deltaTime * Speed);
		base.transform.LookAt(CameraTarget);
		if (Headmaster.time > 69f)
		{
			Jukebox.volume -= Time.deltaTime * 0.2f;
		}
		if (Phase == 0)
		{
			Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * 0.2f);
			Darkness.color = new Color(0f, 0f, 0f, Alpha);
			if (Alpha == 0f)
			{
				Subtitle.text = Lines[SpeechID];
				HeadmasterAnim["HeadmasterPhoneCall"].speed = 1f;
				HeadmasterAnim["HeadmasterPhoneCall"].time = 0f;
				HeadmasterAnim.Play();
				Headmaster.Play();
				SpeechID++;
				Phase++;
			}
		}
		else if (Phase == 1)
		{
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
