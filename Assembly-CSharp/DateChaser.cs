using System;
using UnityEngine;

// Token: 0x0200026D RID: 621
public class DateChaser : MonoBehaviour
{
	// Token: 0x06001323 RID: 4899 RVA: 0x000AA680 File Offset: 0x000A8880
	private static DateTime fromUnix(long unix)
	{
		return DateChaser.epoch.AddSeconds((double)unix);
	}

	// Token: 0x06001324 RID: 4900 RVA: 0x000AA69C File Offset: 0x000A889C
	private void Start()
	{
		Application.targetFrameRate = 60;
		Time.timeScale = 1f;
	}

	// Token: 0x06001325 RID: 4901 RVA: 0x000AA6B0 File Offset: 0x000A88B0
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

	// Token: 0x06001326 RID: 4902 RVA: 0x000AA7F1 File Offset: 0x000A89F1
	private void onDayTick(int day)
	{
		this.Label.text = this.CurrentTimeString;
	}

	// Token: 0x04001B48 RID: 6984
	public int CurrentDate;

	// Token: 0x04001B49 RID: 6985
	public string CurrentTimeString;

	// Token: 0x04001B4A RID: 6986
	[Header("Epoch timestamps")]
	[SerializeField]
	private int startDate = 1581724799;

	// Token: 0x04001B4B RID: 6987
	[SerializeField]
	private int endDate = 1421366399;

	// Token: 0x04001B4C RID: 6988
	[Space(5f)]
	[Header("Settings")]
	[SerializeField]
	private float generalDuration = 10f;

	// Token: 0x04001B4D RID: 6989
	[SerializeField]
	private AnimationCurve curve;

	// Token: 0x04001B4E RID: 6990
	public bool Animate;

	// Token: 0x04001B4F RID: 6991
	private float startTime;

	// Token: 0x04001B50 RID: 6992
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

	// Token: 0x04001B51 RID: 6993
	private int lastFrameDay;

	// Token: 0x04001B52 RID: 6994
	private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	// Token: 0x04001B53 RID: 6995
	public UILabel Label;

	// Token: 0x04001B54 RID: 6996
	public float Timer;

	// Token: 0x04001B55 RID: 6997
	public int Stage;
}
