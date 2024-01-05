using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeNoteScript : MonoBehaviour
{
	public UITexture Darkness;

	public UITexture TextWindow;

	public UITexture FinalDarkness;

	public Transform BackgroundArt;

	public TypewriterEffect Typewriter;

	public GameObject Controls;

	public AudioSource MyAudio;

	public AudioClip[] Voices;

	public string[] Lines;

	public int[] Alphas;

	public bool[] Reds;

	public UILabel Label;

	public float Timer;

	public int Frame;

	public int ID;

	public float AutoTimer;

	public float Alpha;

	public string Text;

	public AudioClip[] SFX;

	public bool Spoke;

	public bool Auto;

	public AudioSource SFXAudioSource;

	public AudioSource Jukebox;

	private void Start()
	{
		Application.targetFrameRate = 60;
		Label.text = Lines[ID];
		Controls.SetActive(value: false);
		Label.gameObject.SetActive(value: false);
		Darkness.color = new Color(0f, 0f, 0f, 1f);
		BackgroundArt.localPosition = new Vector3(0f, -540f, 0f);
		BackgroundArt.localScale = new Vector3(2.5f, 2.5f, 1f);
		TextWindow.color = new Color(1f, 1f, 1f, 0f);
		GameGlobals.WatchedAnime = true;
	}

	private void Update()
	{
		if (Controls.activeInHierarchy)
		{
			if (Typewriter.mCurrentOffset == 1)
			{
				if (Reds[ID])
				{
					Label.color = new Color(1f, 0f, 0f, 1f);
				}
				else
				{
					Label.color = new Color(1f, 1f, 1f, 1f);
				}
			}
			if (Input.GetButtonDown(InputNames.Xbox_A) || AutoTimer > 0.5f)
			{
				if (ID < Lines.Length - 1)
				{
					if (Typewriter.mCurrentOffset < Typewriter.mFullText.Length)
					{
						Typewriter.Finish();
					}
					else
					{
						ID++;
						Alpha = Alphas[ID];
						Darkness.color = new Color(0f, 0f, 0f, Alpha);
						Typewriter.ResetToBeginning();
						Typewriter.mFullText = Lines[ID];
						Label.text = "";
						Spoke = false;
						Frame = 0;
						if (Alphas[ID] == 1)
						{
							Jukebox.Stop();
						}
						else if (!Jukebox.isPlaying)
						{
							Jukebox.Play();
						}
						if (ID == 17)
						{
							SFXAudioSource.clip = SFX[1];
							SFXAudioSource.Play();
						}
						if (ID == 18)
						{
							SFXAudioSource.clip = SFX[2];
							SFXAudioSource.Play();
						}
						if (ID > 25)
						{
							Typewriter.charsPerSecond = 15;
						}
						AutoTimer = 0f;
					}
				}
				else if (!FinalDarkness.enabled)
				{
					FinalDarkness.enabled = true;
					Alpha = 0f;
				}
			}
			if (!Spoke && !SFXAudioSource.isPlaying)
			{
				MyAudio.clip = Voices[ID];
				MyAudio.Play();
				Spoke = true;
			}
			if (Auto && Typewriter.mCurrentOffset == Typewriter.mFullText.Length && !SFXAudioSource.isPlaying && !MyAudio.isPlaying)
			{
				AutoTimer += Time.deltaTime;
			}
			if (FinalDarkness.enabled)
			{
				Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime * 0.2f);
				FinalDarkness.color = new Color(0f, 0f, 0f, Alpha);
				if (Alpha == 1f)
				{
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("LifeNote", 1);
						PlayerPrefs.SetInt("a", 1);
					}
					SceneManager.LoadScene("HomeScene");
				}
			}
		}
		if (!(TextWindow.color.a < 1f))
		{
			return;
		}
		if (Input.GetButtonDown(InputNames.Xbox_A))
		{
			Darkness.color = new Color(0f, 0f, 0f, 0f);
			BackgroundArt.localPosition = new Vector3(0f, 0f, 0f);
			BackgroundArt.localScale = new Vector3(1f, 1f, 1f);
			TextWindow.color = new Color(1f, 1f, 1f, 1f);
			Label.color = new Color(1f, 1f, 1f, 0f);
			Label.gameObject.SetActive(value: true);
			Controls.SetActive(value: true);
			Timer = 0f;
		}
		Timer += Time.deltaTime;
		if (Timer > 6f)
		{
			Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime);
			TextWindow.color = new Color(1f, 1f, 1f, Alpha);
			if (TextWindow.color.a == 1f && !Typewriter.mActive)
			{
				Label.color = new Color(1f, 1f, 1f, 0f);
				Label.gameObject.SetActive(value: true);
				Controls.SetActive(value: true);
				Timer = 0f;
			}
		}
		else if (Timer > 2f)
		{
			BackgroundArt.localScale = Vector3.Lerp(BackgroundArt.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * (Timer - 2f));
			BackgroundArt.localPosition = Vector3.Lerp(BackgroundArt.localPosition, new Vector3(0f, 0f, 0f), Time.deltaTime * (Timer - 2f));
		}
		else if (Timer > 0f)
		{
			Darkness.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime));
		}
	}
}
