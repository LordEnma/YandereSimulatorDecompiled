using UnityEngine;
using UnityEngine.SceneManagement;

public class EightiesEndCutsceneScript : MonoBehaviour
{
	public UISprite SkipCircle;

	public UIPanel SkipPanel;

	public AudioSource Jukebox;

	public AudioSource MyAudio;

	public ClockScript Clock;

	public UISprite Darkness;

	public Camera MainCamera;

	public UILabel Subtitle;

	public GameObject Cops;

	public AudioClip[] Clip;

	public string[] Text;

	public float SkipTimer;

	public float Rotation;

	public float Speed;

	public float Timer;

	public int Phase;

	public int Disappearances;

	public int Deaths;

	public bool Debugging;

	public bool SkipLine6;

	public bool FadeOut;

	public bool WarmUp;

	public AudioClip DeadClip;

	public AudioClip AllDeadClip;

	public AudioClip MissingClip;

	public AudioClip AllMissingClip;

	public AudioClip SomeMissingClip;

	public AudioClip DeadOrMissingClip;

	public AudioClip AllDeadOrMissingClip;

	public AudioClip SomeDeadOrMissingClip;

	public AudioClip PacifistClip;

	private void Start()
	{
		MainCamera.transform.localPosition = new Vector3(0f, 1.482f, -10f);
		MainCamera.clearFlags = CameraClearFlags.Color;
		MainCamera.backgroundColor = new Color(1f, 1f, 1f, 1f);
		MainCamera.farClipPlane = 150f;
		Clock.BloomFadeSpeed = 5f;
		Clock.StopTime = true;
		Clock.BloomWait = 1f;
		SkipPanel.alpha = 0f;
		Subtitle.text = "";
		for (int i = 1; i < 11; i++)
		{
			if (GameGlobals.GetRivalEliminations(i) == 1 || GameGlobals.GetRivalEliminations(i) == 2)
			{
				Debug.Log("Rival #" + i + " was killed.");
				Deaths++;
			}
			else
			{
				Debug.Log("Apparently, Rival #" + i + " does not appear to have been killed.");
			}
			if (GameGlobals.GetRivalEliminations(i) == 11)
			{
				Disappearances++;
			}
		}
		if (Deaths == 10)
		{
			Text[6] = "...and your connection to at least one other person's death.";
			Text[12] = "...and every single one of those girls is dead now!";
			Clip[6] = DeadClip;
			Clip[12] = AllDeadClip;
		}
		else if (Disappearances == 10)
		{
			Text[6] = "...and your connection to at least one other person's disappearance.";
			Text[12] = "...and every single one of those girls has gone missing!";
			Clip[6] = MissingClip;
			Clip[12] = AllMissingClip;
		}
		else if (Deaths + Disappearances == 10)
		{
			Text[6] = "...and your connection to several other deaths and disappearances over the past 10 weeks.";
			Text[12] = "...and every single one of those girls is dead or missing!";
			Clip[6] = DeadOrMissingClip;
			Clip[12] = AllDeadOrMissingClip;
		}
		else if (Deaths > 0)
		{
			Text[6] = "...and your connection to at least one other person's death.";
			Text[12] = "Some of those girls are dead now! And the others? They're conveniently...out of the picture.";
			Clip[6] = DeadClip;
			Clip[12] = SomeDeadOrMissingClip;
		}
		else if (Disappearances > 0)
		{
			Text[6] = "...and your connection to at least one other person's disappearance.";
			Text[12] = "And some of those girls have gone missing. Tch...how convenient for you.";
			Clip[6] = MissingClip;
			Clip[12] = SomeMissingClip;
		}
		else if (Deaths + Disappearances == 0)
		{
			SkipLine6 = true;
			Text[12] = "...and from what I've heard, you've been doing everything in your power to keep girls away from him.";
			Clip[6] = Clip[0];
			Clip[12] = PacifistClip;
		}
		if (SchoolGlobals.SchoolAtmosphere < 0.5f)
		{
			Darkness.color = new Color(1f, 1f, 1f, 1f);
		}
	}

	private void Update()
	{
		if (WarmUp)
		{
			Timer += Time.deltaTime;
			if (Timer > 1f)
			{
				MyAudio.Play();
				Jukebox.Play();
				WarmUp = false;
				Timer = 0f;
			}
			return;
		}
		Jukebox.volume = Mathf.MoveTowards(Jukebox.volume, 0.1f, Time.deltaTime);
		if (!MyAudio.isPlaying || (Debugging && Input.GetButtonDown(InputNames.Xbox_A) && Phase < 16))
		{
			Timer = 1.1f;
			if (Timer > 1f)
			{
				Timer = 0f;
				Phase++;
				if (Phase == 6 && SkipLine6)
				{
					Phase++;
				}
				if (Phase < Text.Length)
				{
					Subtitle.text = Text[Phase];
					MyAudio.clip = Clip[Phase];
					MyAudio.Play();
					if (Phase == 2 || Phase == 3)
					{
						if (Phase == 3)
						{
							MainCamera.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
						}
						MainCamera.transform.localPosition = new Vector3(0f, 1.482f, 0f);
						Cops.SetActive(value: true);
						Speed = 0f;
					}
					else if (Phase == 16)
					{
						FadeOut = true;
						Darkness.color = new Color(0f, 0f, 0f, 0f);
					}
				}
				else if (Darkness.alpha == 1f)
				{
					SceneManager.LoadScene("CourtroomScene");
				}
			}
		}
		if (Phase < 2)
		{
			Speed += Time.deltaTime * 0.05f;
			MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, new Vector3(0f, 1.482f, 0f), Time.deltaTime * Speed);
			Rotation = Mathf.Lerp(Rotation, -15f, Time.deltaTime * Speed);
			MainCamera.transform.localEulerAngles = new Vector3(Rotation, 0f, 0f);
		}
		else if (Phase == 2)
		{
			Speed += Time.deltaTime * 3f;
			Rotation = Mathf.Lerp(Rotation, 0f, Time.deltaTime * Speed);
			MainCamera.transform.localEulerAngles = new Vector3(Rotation, 0f, 0f);
		}
		else if (Phase > 2 && Phase < Text.Length)
		{
			Speed += Time.deltaTime;
			Rotation = Mathf.Lerp(Rotation, -180f, Time.deltaTime * Speed);
			MainCamera.transform.localEulerAngles = new Vector3(0f, Rotation, 0f);
		}
		_ = Phase;
		_ = 1;
		if (FadeOut)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime * 0.33333f);
			SkipPanel.alpha = Mathf.MoveTowards(SkipPanel.alpha, 0f, Time.deltaTime * 0.33333f);
			Jukebox.volume = Mathf.MoveTowards(Jukebox.volume, 0f, Time.deltaTime * 2f);
			return;
		}
		Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime * 0.33333f);
		if (!WarmUp)
		{
			SkipTimer += Time.deltaTime;
			if (SkipTimer > 2f)
			{
				SkipPanel.alpha = Mathf.MoveTowards(SkipPanel.alpha, 1f, Time.deltaTime * 0.33333f);
			}
		}
		if (SkipPanel.alpha != 1f)
		{
			return;
		}
		if (Input.GetButton(InputNames.Xbox_X))
		{
			SkipCircle.fillAmount -= Time.deltaTime;
			if (SkipCircle.fillAmount == 0f)
			{
				MyAudio.Stop();
				FadeOut = true;
				Phase = Text.Length;
				Darkness.color = new Color(0f, 0f, 0f, 0f);
			}
		}
		else
		{
			SkipCircle.fillAmount = 1f;
		}
	}
}
