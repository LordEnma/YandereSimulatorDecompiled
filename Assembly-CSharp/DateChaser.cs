using System;
using UnityEngine;

// Token: 0x0200026F RID: 623
public class DateChaser : MonoBehaviour
{
	// Token: 0x0600132F RID: 4911 RVA: 0x000AB224 File Offset: 0x000A9424
	private static DateTime fromUnix(long unix)
	{
		return DateChaser.epoch.AddSeconds((double)unix);
	}

	// Token: 0x06001330 RID: 4912 RVA: 0x000AB240 File Offset: 0x000A9440
	private void Start()
	{
		Application.targetFrameRate = 60;
		Time.timeScale = 1f;
	}

	// Token: 0x06001331 RID: 4913 RVA: 0x000AB254 File Offset: 0x000A9454
	private void Update()
	{
		if (this.Animate)
		{
			float num = Time.time - this.startTime;
			this.CurrentDate = (int)Mathf.Lerp((float)this.startDate, (float)this.endDate, this.curve.Evaluate(num / this.generalDuration));
			DateTime dateTime = DateChaser.fromUnix((long)this.CurrentDate);
			string text = (dateTime.Day == 22 || dateTime.Day == 2) ? "nd" : ((dateTime.Day == 3) ? "rd" : ((dateTime.Day == 1) ? "st" : "th"));
			this.CurrentTimeString = string.Format("{0} {1}{2}, {3}", new object[]
			{
				this.monthNames[dateTime.Month - 1],
				dateTime.Day,
				text,
				dateTime.Year
			});
			if (this.lastFrameDay != dateTime.Day)
			{
				this.onDayTick(dateTime.Day);
			}
			this.lastFrameDay = dateTime.Day;
			this.Timer += Time.deltaTime;
			return;
		}
		this.startTime = Time.time;
		this.CurrentDate = this.startDate;
	}

	// Token: 0x06001332 RID: 4914 RVA: 0x000AB395 File Offset: 0x000A9595
	private void onDayTick(int day)
	{
		this.Label.text = this.CurrentTimeString;
	}

	// Token: 0x04001B78 RID: 7032
	public int CurrentDate;

	// Token: 0x04001B79 RID: 7033
	public string CurrentTimeString;

	// Token: 0x04001B7A RID: 7034
	[Header("Epoch timestamps")]
	[SerializeField]
	private int startDate = 1581724799;

	// Token: 0x04001B7B RID: 7035
	[SerializeField]
	private int endDate = 1421366399;

	// Token: 0x04001B7C RID: 7036
	[Space(5f)]
	[Header("Settings")]
	[SerializeField]
	private float generalDuration = 10f;

	// Token: 0x04001B7D RID: 7037
	[SerializeField]
	private AnimationCurve curve;

	// Token: 0x04001B7E RID: 7038
	public bool Animate;

	// Token: 0x04001B7F RID: 7039
	private float startTime;

	// Token: 0x04001B80 RID: 7040
	private string[] monthNames = new string[]
	{
		"January",
		"February",
		"March",
		"April",
		"May",
		"June",
		"July",
		"August",
		"September",
		"October",
		"November",
		"December"
	};

	// Token: 0x04001B81 RID: 7041
	private int lastFrameDay;

	// Token: 0x04001B82 RID: 7042
	private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	// Token: 0x04001B83 RID: 7043
	public UILabel Label;

	// Token: 0x04001B84 RID: 7044
	public float Timer;

	// Token: 0x04001B85 RID: 7045
	public int Stage;
}
