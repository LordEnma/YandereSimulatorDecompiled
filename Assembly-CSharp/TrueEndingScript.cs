using UnityEngine;

public class TrueEndingScript : MonoBehaviour
{
	public GameObject TrueEndingPanel;

	public GameObject TimelinePanel;

	public AudioSource Ambience;

	public AudioSource MyAudio;

	public AudioSource BuildUp;

	public UISprite Darkness;

	public Texture DarkLogo;

	public AudioClip[] Clip;

	public UILabel Subtitle;

	public UITexture Logo;

	public string[] Text;

	public float SpeechTimer;

	public float FadeTimer;

	public float WaitTimer;

	public float Timer;

	public float Intensity;

	public bool FadeOut;

	public bool Shake;

	public int Phase;

	private void Start()
	{
		Darkness.alpha = 1f;
		Subtitle.text = "";
	}

	private void Update()
	{
		Timer += Time.deltaTime;
		Ambience.volume = Mathf.MoveTowards(Ambience.volume, 0.25f, Time.deltaTime * 0.25f);
		if (Timer > 1f)
		{
			if (!FadeOut)
			{
				Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime);
			}
			else
			{
				Logo.alpha = Mathf.MoveTowards(Logo.alpha, 0f, Time.deltaTime * 0.33333f);
				if (Logo.alpha == 0f)
				{
					TrueEndingPanel.SetActive(value: false);
					TimelinePanel.SetActive(value: true);
					base.enabled = false;
				}
			}
			WaitTimer += Time.deltaTime;
			if (WaitTimer > 1f)
			{
				if (Input.GetButtonDown("A"))
				{
					SpeechTimer = 1f;
					if (Phase < 16)
					{
						MyAudio.Stop();
					}
				}
				if (!MyAudio.isPlaying && Darkness.alpha == 0f)
				{
					SpeechTimer += Time.deltaTime;
					if (SpeechTimer > 0.5f && Phase < Clip.Length - 1)
					{
						Phase++;
						Subtitle.text = Text[Phase];
						MyAudio.clip = Clip[Phase];
						MyAudio.Play();
						if (Phase == Clip.Length - 1)
						{
							Logo.mainTexture = DarkLogo;
							Ambience.Stop();
							BuildUp.Stop();
							Shake = true;
						}
						else if (Phase == Clip.Length - 2)
						{
							BuildUp.Play();
						}
						SpeechTimer = 0f;
					}
				}
			}
		}
		if (!Shake)
		{
			return;
		}
		Logo.transform.localPosition = new Vector3(Random.Range(-1f, 1f) * Intensity, Random.Range(-1f, 1f) * Intensity, Random.Range(-1f, 1f) * Intensity);
		Intensity = Mathf.MoveTowards(Intensity, 0f, Time.deltaTime * 100f);
		if (Intensity == 0f)
		{
			FadeTimer += Time.deltaTime;
			if (FadeTimer > 5f && !FadeOut)
			{
				Darkness.color = new Color(0f, 0f, 0f, 0f);
				FadeOut = true;
			}
		}
	}
}
