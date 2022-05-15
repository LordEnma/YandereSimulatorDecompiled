using System;
using UnityEngine;

// Token: 0x02000270 RID: 624
public class DateChaser : MonoBehaviour
{
	// Token: 0x06001339 RID: 4921 RVA: 0x000AC078 File Offset: 0x000AA278
	private static DateTime fromUnix(long unix)
	{
		return DateChaser.epoch.AddSeconds((double)unix);
	}

	// Token: 0x0600133A RID: 4922 RVA: 0x000AC094 File Offset: 0x000AA294
	private void Start()
	{
		Application.targetFrameRate = 60;
		Time.timeScale = 1f;
	}

	// Token: 0x0600133B RID: 4923 RVA: 0x000AC0A8 File Offset: 0x000AA2A8
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

	// Token: 0x0600133C RID: 4924 RVA: 0x000AC1E9 File Offset: 0x000AA3E9
	private void onDayTick(int day)
	{
		this.Label.text = this.CurrentTimeString;
	}

	// Token: 0x04001B99 RID: 7065
	public int CurrentDate;

	// Token: 0x04001B9A RID: 7066
	public string CurrentTimeString;

	// Token: 0x04001B9B RID: 7067
	[Header("Epoch timestamps")]
	[SerializeField]
	private int startDate = 1581724799;

	// Token: 0x04001B9C RID: 7068
	[SerializeField]
	private int endDate = 1421366399;

	// Token: 0x04001B9D RID: 7069
	[Space(5f)]
	[Header("Settings")]
	[SerializeField]
	private float generalDuration = 10f;

	// Token: 0x04001B9E RID: 7070
	[SerializeField]
	private AnimationCurve curve;

	// Token: 0x04001B9F RID: 7071
	public bool Animate;

	// Token: 0x04001BA0 RID: 7072
	private float startTime;

	// Token: 0x04001BA1 RID: 7073
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

	// Token: 0x04001BA2 RID: 7074
	private int lastFrameDay;

	// Token: 0x04001BA3 RID: 7075
	private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	// Token: 0x04001BA4 RID: 7076
	public UILabel Label;

	// Token: 0x04001BA5 RID: 7077
	public float Timer;

	// Token: 0x04001BA6 RID: 7078
	public int Stage;
}
