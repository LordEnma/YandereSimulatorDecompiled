using System;
using UnityEngine;

// Token: 0x0200026F RID: 623
public class DateChaser : MonoBehaviour
{
	// Token: 0x0600132F RID: 4911 RVA: 0x000AAE88 File Offset: 0x000A9088
	private static DateTime fromUnix(long unix)
	{
		return DateChaser.epoch.AddSeconds((double)unix);
	}

	// Token: 0x06001330 RID: 4912 RVA: 0x000AAEA4 File Offset: 0x000A90A4
	private void Start()
	{
		Application.targetFrameRate = 60;
		Time.timeScale = 1f;
	}

	// Token: 0x06001331 RID: 4913 RVA: 0x000AAEB8 File Offset: 0x000A90B8
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

	// Token: 0x06001332 RID: 4914 RVA: 0x000AAFF9 File Offset: 0x000A91F9
	private void onDayTick(int day)
	{
		this.Label.text = this.CurrentTimeString;
	}

	// Token: 0x04001B6E RID: 7022
	public int CurrentDate;

	// Token: 0x04001B6F RID: 7023
	public string CurrentTimeString;

	// Token: 0x04001B70 RID: 7024
	[Header("Epoch timestamps")]
	[SerializeField]
	private int startDate = 1581724799;

	// Token: 0x04001B71 RID: 7025
	[SerializeField]
	private int endDate = 1421366399;

	// Token: 0x04001B72 RID: 7026
	[Space(5f)]
	[Header("Settings")]
	[SerializeField]
	private float generalDuration = 10f;

	// Token: 0x04001B73 RID: 7027
	[SerializeField]
	private AnimationCurve curve;

	// Token: 0x04001B74 RID: 7028
	public bool Animate;

	// Token: 0x04001B75 RID: 7029
	private float startTime;

	// Token: 0x04001B76 RID: 7030
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

	// Token: 0x04001B77 RID: 7031
	private int lastFrameDay;

	// Token: 0x04001B78 RID: 7032
	private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	// Token: 0x04001B79 RID: 7033
	public UILabel Label;

	// Token: 0x04001B7A RID: 7034
	public float Timer;

	// Token: 0x04001B7B RID: 7035
	public int Stage;
}
