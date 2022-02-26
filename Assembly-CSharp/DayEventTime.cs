using System;
using UnityEngine;

// Token: 0x020002BD RID: 701
[Serializable]
public class DayEventTime : IScheduledEventTime
{
	// Token: 0x06001471 RID: 5233 RVA: 0x000C750A File Offset: 0x000C570A
	public DayEventTime(int week, DayOfWeek weekday)
	{
		this.week = week;
		this.weekday = weekday;
	}

	// Token: 0x1700036D RID: 877
	// (get) Token: 0x06001472 RID: 5234 RVA: 0x000C7520 File Offset: 0x000C5720
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Day;
		}
	}

	// Token: 0x06001473 RID: 5235 RVA: 0x000C7523 File Offset: 0x000C5723
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week && currentTime.Weekday == this.weekday;
	}

	// Token: 0x06001474 RID: 5236 RVA: 0x000C7543 File Offset: 0x000C5743
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday < this.weekday;
		}
		return currentTime.Week < this.week;
	}

	// Token: 0x06001475 RID: 5237 RVA: 0x000C7570 File Offset: 0x000C5770
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday > this.weekday;
		}
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F75 RID: 8053
	[SerializeField]
	private int week;

	// Token: 0x04001F76 RID: 8054
	[SerializeField]
	private DayOfWeek weekday;
}
