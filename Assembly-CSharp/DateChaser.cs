using System;
using UnityEngine;

// Token: 0x0200026E RID: 622
public class DateChaser : MonoBehaviour
{
	// Token: 0x0600132B RID: 4907 RVA: 0x000AAED4 File Offset: 0x000A90D4
	private static DateTime fromUnix(long unix)
	{
		return DateChaser.epoch.AddSeconds((double)unix);
	}

	// Token: 0x0600132C RID: 4908 RVA: 0x000AAEF0 File Offset: 0x000A90F0
	private void Start()
	{
		Application.targetFrameRate = 60;
		Time.timeScale = 1f;
	}

	// Token: 0x0600132D RID: 4909 RVA: 0x000AAF04 File Offset: 0x000A9104
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

	// Token: 0x0600132E RID: 4910 RVA: 0x000AB045 File Offset: 0x000A9245
	private void onDayTick(int day)
	{
		this.Label.text = this.CurrentTimeString;
	}

	// Token: 0x04001B68 RID: 7016
	public int CurrentDate;

	// Token: 0x04001B69 RID: 7017
	public string CurrentTimeString;

	// Token: 0x04001B6A RID: 7018
	[Header("Epoch timestamps")]
	[SerializeField]
	private int startDate = 1581724799;

	// Token: 0x04001B6B RID: 7019
	[SerializeField]
	private int endDate = 1421366399;

	// Token: 0x04001B6C RID: 7020
	[Space(5f)]
	[Header("Settings")]
	[SerializeField]
	private float generalDuration = 10f;

	// Token: 0x04001B6D RID: 7021
	[SerializeField]
	private AnimationCurve curve;

	// Token: 0x04001B6E RID: 7022
	public bool Animate;

	// Token: 0x04001B6F RID: 7023
	private float startTime;

	// Token: 0x04001B70 RID: 7024
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

	// Token: 0x04001B71 RID: 7025
	private int lastFrameDay;

	// Token: 0x04001B72 RID: 7026
	private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	// Token: 0x04001B73 RID: 7027
	public UILabel Label;

	// Token: 0x04001B74 RID: 7028
	public float Timer;

	// Token: 0x04001B75 RID: 7029
	public int Stage;
}
