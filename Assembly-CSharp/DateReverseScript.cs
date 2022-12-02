using UnityEngine;

public class DateReverseScript : MonoBehaviour
{
	public AudioSource MyAudio;

	public string[] MonthName;

	public string Prefix;

	public UILabel Label;

	public AudioClip Finish;

	public float TimeLimit;

	public float LifeTime;

	public float Timer;

	public int RollDirection;

	public int Month;

	public int Year;

	public int Day;

	public int SlowMonth;

	public int SlowYear;

	public int SlowDay;

	public int EndMonth;

	public int EndYear;

	public int EndDay;

	public bool Rollback;

	private void Start()
	{
		Time.timeScale = 1f;
		UpdateDate();
	}

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			Rollback = true;
		}
		if (!Rollback)
		{
			return;
		}
		LifeTime += Time.deltaTime;
		Timer += Time.deltaTime;
		if (!(Timer > TimeLimit))
		{
			return;
		}
		if ((Year == SlowYear && Month == SlowMonth && Day < SlowDay) || (Year == SlowYear && Month < SlowMonth))
		{
			TimeLimit *= 1.09f;
			if (Month == EndMonth && Day == EndDay + 1)
			{
				MyAudio.clip = Finish;
				Label.color = new Color(1f, 0f, 0f, 1f);
				base.enabled = false;
			}
		}
		else if (TimeLimit > 0.01f)
		{
			TimeLimit *= 0.9f;
		}
		else
		{
			Day += RollDirection * 19;
		}
		Timer = 0f;
		Day += RollDirection;
		UpdateDate();
		MyAudio.Play();
		if (!(MyAudio.clip != Finish))
		{
			MyAudio.pitch = 1f;
		}
	}

	private void UpdateDate()
	{
		if (Day < 1)
		{
			Day = 31;
			Month--;
			if (Month < 1)
			{
				Month = 12;
				Year--;
			}
		}
		else if (Day > 31)
		{
			Day = 1;
			Month++;
			if (Month > 11)
			{
				Month = 1;
				Year++;
			}
		}
		if (Day == 1 || Day == 21 || Day == 31)
		{
			Prefix = "st";
		}
		else if (Day == 2 || Day == 22)
		{
			Prefix = "nd";
		}
		else if (Day == 3 || Day == 23)
		{
			Prefix = "rd";
		}
		else
		{
			Prefix = "th";
		}
		Label.text = MonthName[Month] + " " + Day + Prefix + ", " + Year;
	}
}
