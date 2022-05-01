using System;
using UnityEngine;

// Token: 0x0200026F RID: 623
public class DateChaser : MonoBehaviour
{
	// Token: 0x06001337 RID: 4919 RVA: 0x000ABE30 File Offset: 0x000AA030
	private static DateTime fromUnix(long unix)
	{
		return DateChaser.epoch.AddSeconds((double)unix);
	}

	// Token: 0x06001338 RID: 4920 RVA: 0x000ABE4C File Offset: 0x000AA04C
	private void Start()
	{
		Application.targetFrameRate = 60;
		Time.timeScale = 1f;
	}

	// Token: 0x06001339 RID: 4921 RVA: 0x000ABE60 File Offset: 0x000AA060
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

	// Token: 0x0600133A RID: 4922 RVA: 0x000ABFA1 File Offset: 0x000AA1A1
	private void onDayTick(int day)
	{
		this.Label.text = this.CurrentTimeString;
	}

	// Token: 0x04001B92 RID: 7058
	public int CurrentDate;

	// Token: 0x04001B93 RID: 7059
	public string CurrentTimeString;

	// Token: 0x04001B94 RID: 7060
	[Header("Epoch timestamps")]
	[SerializeField]
	private int startDate = 1581724799;

	// Token: 0x04001B95 RID: 7061
	[SerializeField]
	private int endDate = 1421366399;

	// Token: 0x04001B96 RID: 7062
	[Space(5f)]
	[Header("Settings")]
	[SerializeField]
	private float generalDuration = 10f;

	// Token: 0x04001B97 RID: 7063
	[SerializeField]
	private AnimationCurve curve;

	// Token: 0x04001B98 RID: 7064
	public bool Animate;

	// Token: 0x04001B99 RID: 7065
	private float startTime;

	// Token: 0x04001B9A RID: 7066
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

	// Token: 0x04001B9B RID: 7067
	private int lastFrameDay;

	// Token: 0x04001B9C RID: 7068
	private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	// Token: 0x04001B9D RID: 7069
	public UILabel Label;

	// Token: 0x04001B9E RID: 7070
	public float Timer;

	// Token: 0x04001B9F RID: 7071
	public int Stage;
}
