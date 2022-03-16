using System;
using UnityEngine;

// Token: 0x0200026F RID: 623
public class DateChaser : MonoBehaviour
{
	// Token: 0x06001332 RID: 4914 RVA: 0x000AB770 File Offset: 0x000A9970
	private static DateTime fromUnix(long unix)
	{
		return DateChaser.epoch.AddSeconds((double)unix);
	}

	// Token: 0x06001333 RID: 4915 RVA: 0x000AB78C File Offset: 0x000A998C
	private void Start()
	{
		Application.targetFrameRate = 60;
		Time.timeScale = 1f;
	}

	// Token: 0x06001334 RID: 4916 RVA: 0x000AB7A0 File Offset: 0x000A99A0
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

	// Token: 0x06001335 RID: 4917 RVA: 0x000AB8E1 File Offset: 0x000A9AE1
	private void onDayTick(int day)
	{
		this.Label.text = this.CurrentTimeString;
	}

	// Token: 0x04001B86 RID: 7046
	public int CurrentDate;

	// Token: 0x04001B87 RID: 7047
	public string CurrentTimeString;

	// Token: 0x04001B88 RID: 7048
	[Header("Epoch timestamps")]
	[SerializeField]
	private int startDate = 1581724799;

	// Token: 0x04001B89 RID: 7049
	[SerializeField]
	private int endDate = 1421366399;

	// Token: 0x04001B8A RID: 7050
	[Space(5f)]
	[Header("Settings")]
	[SerializeField]
	private float generalDuration = 10f;

	// Token: 0x04001B8B RID: 7051
	[SerializeField]
	private AnimationCurve curve;

	// Token: 0x04001B8C RID: 7052
	public bool Animate;

	// Token: 0x04001B8D RID: 7053
	private float startTime;

	// Token: 0x04001B8E RID: 7054
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

	// Token: 0x04001B8F RID: 7055
	private int lastFrameDay;

	// Token: 0x04001B90 RID: 7056
	private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	// Token: 0x04001B91 RID: 7057
	public UILabel Label;

	// Token: 0x04001B92 RID: 7058
	public float Timer;

	// Token: 0x04001B93 RID: 7059
	public int Stage;
}
