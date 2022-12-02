using UnityEngine;

public class StalkerScript : MonoBehaviour
{
	public StruggleBarScript StruggleBar;

	public StalkerYandereScript Yandere;

	public StalkerPromptScript CatPrompt;

	public GameObject KnockoutStars;

	public GameObject Heartbroken;

	public GameObject[] BonkEffect;

	public Transform StalkerDoor;

	public AudioClip CrunchSound;

	public Animation MyAnimation;

	public AudioSource Jukebox;

	public AudioSource MyAudio;

	public AudioClip StalkerKnockout;

	public AudioClip StalkerWon;

	public AudioClip Crunch;

	public UILabel Subtitle;

	public AudioClip[] AlarmedClip;

	public string[] AlarmedText;

	public float[] AlarmedTime;

	public AudioClip[] SpeechClip;

	public string[] SpeechText;

	public float[] SpeechTime;

	public Collider[] Boundary;

	public float MinimumDistance;

	public float Distance;

	public float Scale;

	public float Timer;

	public bool PlayedAudio;

	public bool Struggling;

	public bool Alarmed;

	public bool Started;

	public bool Chase;

	public int SpeechPhase;

	public int Limit;

	private void Update()
	{
		if (!Chase)
		{
			Distance = Vector3.Distance(Yandere.transform.position, base.transform.position);
			if (!Alarmed)
			{
				for (int i = 0; i < Boundary.Length; i++)
				{
					if (Boundary[i].bounds.Contains(Yandere.transform.position))
					{
						AudioSource.PlayClipAtPoint(CrunchSound, Camera.main.transform.position);
						TriggerAlarm();
					}
				}
				if (Distance < 0.5f)
				{
					TriggerAlarm();
				}
			}
			else
			{
				base.transform.LookAt(Yandere.transform.position);
				if (Limit == 10 && Vector3.Distance(Yandere.transform.position, StalkerDoor.position) < 1f)
				{
					ChaseNow();
				}
			}
			if (Distance < MinimumDistance)
			{
				if (!Started)
				{
					Timer += Time.deltaTime;
					if (Timer > 1f)
					{
						Subtitle.transform.localScale = new Vector3(1f, 1f, 1f);
						Subtitle.text = SpeechText[0];
						MyAudio.clip = SpeechClip[0];
						MyAudio.Play();
						Started = true;
						SpeechPhase++;
					}
				}
				else
				{
					MyAudio.pitch = Time.timeScale;
					if (!Alarmed)
					{
						if (SpeechPhase < SpeechTime.Length && !MyAudio.isPlaying)
						{
							MyAudio.clip = SpeechClip[SpeechPhase];
							MyAudio.Play();
							Subtitle.text = SpeechText[SpeechPhase];
							SpeechPhase++;
						}
					}
					else if (SpeechPhase < Limit && !MyAudio.isPlaying)
					{
						MyAudio.clip = SpeechClip[SpeechPhase];
						MyAudio.Play();
						Subtitle.text = SpeechText[SpeechPhase];
						SpeechPhase++;
						if (Limit == 10 && SpeechPhase == Limit)
						{
							ChaseNow();
						}
					}
					if (MyAudio.isPlaying)
					{
						Jukebox.volume = 0.1f;
					}
					else
					{
						Jukebox.volume = 1f;
					}
				}
			}
			else
			{
				Subtitle.text = "";
			}
		}
		else if (!Struggling)
		{
			base.transform.LookAt(Yandere.transform.position);
			base.transform.Translate(base.transform.forward * Time.deltaTime * 5f, Space.World);
			MyAnimation.CrossFade("newSprint_00");
			if (Vector3.Distance(base.transform.position, Yandere.transform.position) < 1f)
			{
				MyAnimation.CrossFade("struggleB_00");
				Yandere.BeginStruggle();
				Struggling = true;
				StruggleBar.gameObject.SetActive(true);
				StruggleBar.Struggling = true;
				Subtitle.text = "";
			}
		}
		else
		{
			base.transform.position = Vector3.MoveTowards(base.transform.position, Yandere.transform.position + Yandere.transform.forward * 0.5f, Time.deltaTime * 10f);
			base.transform.rotation = Yandere.transform.rotation;
			if (!StruggleBar.Struggling)
			{
				if (StruggleBar.Yandere.Won)
				{
					if (!PlayedAudio)
					{
						AudioSource.PlayClipAtPoint(StalkerKnockout, Yandere.MainCamera.transform.position);
						PlayedAudio = true;
					}
					Yandere.MyAnimation.CrossFade("f02_struggleWinA_00");
					MyAnimation.CrossFade("struggleWinB_00");
					if (MyAnimation["struggleWinB_00"].time >= 0.66666f)
					{
						BonkEffect[1].SetActive(true);
					}
					if (MyAnimation["struggleWinB_00"].time >= 1.33333f)
					{
						KnockoutStars.SetActive(true);
						BonkEffect[2].SetActive(true);
					}
					if (MyAnimation["struggleWinB_00"].time >= MyAnimation["struggleWinB_00"].length)
					{
						CatPrompt.BeginCarryingCat();
						Yandere.CanMove = true;
						Yandere.Chased = false;
						base.enabled = false;
					}
				}
				else
				{
					if (!PlayedAudio)
					{
						AudioSource.PlayClipAtPoint(StalkerWon, Yandere.MainCamera.transform.position);
						PlayedAudio = true;
						Jukebox.Stop();
					}
					Yandere.MyAnimation.CrossFade("f02_struggleLoseA_00");
					MyAnimation.CrossFade("struggleLoseB_00");
					if (MyAnimation["struggleLoseB_00"].time >= MyAnimation["struggleLoseB_00"].length)
					{
						Heartbroken.SetActive(true);
						base.enabled = false;
					}
				}
			}
		}
		if (Yandere.transform.position.x < 1f)
		{
			MyAudio.volume = 1f;
		}
		else
		{
			MyAudio.volume = 0f;
		}
	}

	private void ChaseNow()
	{
		SpeechClip = AlarmedClip;
		SpeechText = AlarmedText;
		SpeechTime = AlarmedTime;
		SpeechPhase = 9;
		MyAudio.clip = SpeechClip[SpeechPhase];
		MyAudio.Play();
		Subtitle.text = SpeechText[SpeechPhase];
		SpeechPhase++;
		Yandere.MyAnimation.CrossFade(Yandere.IdleAnim);
		Yandere.CanMove = false;
		Yandere.Chased = true;
		Chase = true;
	}

	private void TriggerAlarm()
	{
		MyAnimation.CrossFade("readyToFight_00");
		SpeechClip = AlarmedClip;
		SpeechText = AlarmedText;
		SpeechTime = AlarmedTime;
		Subtitle.text = "";
		Started = false;
		Alarmed = true;
		SpeechPhase = 0;
		Timer = 0f;
		MyAudio.Stop();
	}
}
