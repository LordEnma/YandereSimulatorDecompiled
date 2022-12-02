using System;
using System.Globalization;
using UnityEngine;

public class HomeClockScript : MonoBehaviour
{
	public UILabel MoneyLabel;

	public UILabel HourLabel;

	public UILabel DayLabel;

	public AudioSource MyAudio;

	public bool ShakeMoney;

	public Vector3 Origin;

	public float Shake;

	public float OriginalG;

	public float OriginalB;

	public float G;

	public float B;

	private void Start()
	{
		DayLabel.text = GetWeekdayText(DateGlobals.Weekday) + ", WEEK " + DateGlobals.Week;
		if (HomeGlobals.Night)
		{
			HourLabel.text = "8:00 PM";
		}
		else
		{
			HourLabel.text = (HomeGlobals.LateForSchool ? "7:30 AM" : "6:30 AM");
		}
		OriginalG = MoneyLabel.color.g;
		OriginalB = MoneyLabel.color.b;
		UpdateMoneyLabel();
	}

	private void Update()
	{
		if (ShakeMoney)
		{
			Shake = Mathf.MoveTowards(Shake, 0f, Time.deltaTime * 10f);
			MoneyLabel.transform.localPosition = new Vector3(Origin.x + UnityEngine.Random.Range(Shake * -1f, Shake * 1f), Origin.y + UnityEngine.Random.Range(Shake * -1f, Shake * 1f), 0f);
			G = Mathf.MoveTowards(G, OriginalG, Time.deltaTime);
			B = Mathf.MoveTowards(B, OriginalB, Time.deltaTime);
			MoneyLabel.color = new Color(1f, G, B, 1f);
			if (Shake == 0f)
			{
				ShakeMoney = false;
			}
		}
	}

	private string GetWeekdayText(DayOfWeek weekday)
	{
		switch (weekday)
		{
		case DayOfWeek.Sunday:
			return "SUNDAY";
		case DayOfWeek.Monday:
			return "MONDAY";
		case DayOfWeek.Tuesday:
			return "TUESDAY";
		case DayOfWeek.Wednesday:
			return "WEDNESDAY";
		case DayOfWeek.Thursday:
			return "THURSDAY";
		case DayOfWeek.Friday:
			return "FRIDAY";
		default:
			return "SATURDAY";
		}
	}

	public void UpdateMoneyLabel()
	{
		MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
	}

	public void MoneyFail()
	{
		if (Origin != Vector3.zero)
		{
			MoneyLabel.transform.localPosition = Origin;
		}
		Origin = MoneyLabel.transform.localPosition;
		ShakeMoney = true;
		Shake = 10f;
		G = 0f;
		B = 0f;
		MyAudio.Play();
	}
}
