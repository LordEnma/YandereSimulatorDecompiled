using UnityEngine;

public class DelinquentManagerScript : MonoBehaviour
{
	public GameObject Delinquents;

	public GameObject RapBeat;

	public GameObject Panel;

	public float[] NextTime;

	public DelinquentScript Attacker;

	public MirrorScript Mirror;

	public UILabel TimeLabel;

	public ClockScript Clock;

	public UISprite Circle;

	public float SpeechTimer;

	public float TimerMax;

	public float Timer;

	public bool Aggro;

	public int Phase = 1;

	private void Start()
	{
		Delinquents.SetActive(false);
		TimerMax = 15f;
		Timer = 15f;
		Phase++;
	}

	private void Update()
	{
		SpeechTimer = Mathf.MoveTowards(SpeechTimer, 0f, Time.deltaTime);
		if (Attacker != null && !Attacker.Attacking && Attacker.ExpressedSurprise && Attacker.Run && !Aggro)
		{
			AudioSource component = GetComponent<AudioSource>();
			component.clip = Attacker.AggroClips[Random.Range(0, Attacker.AggroClips.Length)];
			component.Play();
			Aggro = true;
		}
		if (!Panel.activeInHierarchy || !(Clock.HourTime > NextTime[Phase]))
		{
			return;
		}
		if (Phase == 3 && Clock.HourTime > 7.25f)
		{
			TimerMax = 75f;
			Timer = 75f;
			Phase++;
		}
		else if (Phase == 5 && Clock.HourTime > 8.5f)
		{
			TimerMax = 285f;
			Timer = 285f;
			Phase++;
		}
		else if (Phase == 7 && Clock.HourTime > 13.25f)
		{
			TimerMax = 15f;
			Timer = 15f;
			Phase++;
		}
		else if (Phase == 9 && Clock.HourTime > 13.5f)
		{
			TimerMax = 135f;
			Timer = 135f;
			Phase++;
		}
		if (Attacker == null)
		{
			Timer -= Time.deltaTime * (Clock.TimeSpeed / 60f);
		}
		Circle.fillAmount = 1f - Timer / TimerMax;
		if (Timer <= 0f)
		{
			Delinquents.SetActive(!Delinquents.activeInHierarchy);
			if (Phase < 8)
			{
				Phase++;
				return;
			}
			Delinquents.SetActive(false);
			Panel.SetActive(false);
		}
	}

	public void CheckTime()
	{
		if (Clock.HourTime < 13f)
		{
			Delinquents.SetActive(false);
			TimerMax = 15f;
			Timer = 15f;
			Phase = 6;
		}
		else if (Clock.HourTime < 15.5f)
		{
			Delinquents.SetActive(false);
			TimerMax = 15f;
			Timer = 15f;
			Phase = 8;
		}
	}

	public void EasterEgg()
	{
		RapBeat.SetActive(true);
		Mirror.Limit++;
	}
}
