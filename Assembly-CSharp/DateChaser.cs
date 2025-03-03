using System;
using UnityEngine;

public class DateChaser : MonoBehaviour
{
	public int CurrentDate;

	public string CurrentTimeString;

	[Header("Epoch timestamps")]
	[SerializeField]
	private int startDate = 1581724799;

	[SerializeField]
	private int endDate = 1421366399;

	[Space(5f)]
	[Header("Settings")]
	[SerializeField]
	private float generalDuration = 10f;

	[SerializeField]
	private AnimationCurve curve;

	public bool Animate;

	private float startTime;

	private string[] monthNames = new string[12]
	{
		"January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
		"November", "December"
	};

	private int lastFrameDay;

	private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	public UILabel Label;

	public float Timer;

	public int Stage;

	private static DateTime fromUnix(long unix)
	{
		DateTime dateTime = epoch;
		return dateTime.AddSeconds(unix);
	}

	private void Start()
	{
		Application.targetFrameRate = 60;
		Time.timeScale = 1f;
	}

	private void Update()
	{
		if (Animate)
		{
			float num = Time.time - startTime;
			CurrentDate = (int)Mathf.Lerp(startDate, endDate, curve.Evaluate(num / generalDuration));
			DateTime dateTime = fromUnix(CurrentDate);
			string text = ((dateTime.Day == 22 || dateTime.Day == 2) ? "nd" : ((dateTime.Day == 3) ? "rd" : ((dateTime.Day == 1) ? "st" : "th")));
			CurrentTimeString = $"{monthNames[dateTime.Month - 1]} {dateTime.Day}{text}, {dateTime.Year}";
			if (lastFrameDay != dateTime.Day)
			{
				onDayTick(dateTime.Day);
			}
			lastFrameDay = dateTime.Day;
			Timer += Time.deltaTime;
		}
		else
		{
			startTime = Time.time;
			CurrentDate = startDate;
		}
	}

	private void onDayTick(int day)
	{
		Label.text = CurrentTimeString;
	}
}
