using System;
using UnityEngine;

// Token: 0x020002BA RID: 698
[Serializable]
public class DayEventTime : IScheduledEventTime
{
	// Token: 0x0600145E RID: 5214 RVA: 0x000C62AA File Offset: 0x000C44AA
	public DayEventTime(int week, DayOfWeek weekday)
	{
		this.week = week;
		this.weekday = weekday;
	}

	// Token: 0x1700036D RID: 877
	// (get) Token: 0x0600145F RID: 5215 RVA: 0x000C62C0 File Offset: 0x000C44C0
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Day;
		}
	}

	// Token: 0x06001460 RID: 5216 RVA: 0x000C62C3 File Offset: 0x000C44C3
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week && currentTime.Weekday == this.weekday;
	}

	// Token: 0x06001461 RID: 5217 RVA: 0x000C62E3 File Offset: 0x000C44E3
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday < this.weekday;
		}
		return currentTime.Week < this.week;
	}

	// Token: 0x06001462 RID: 5218 RVA: 0x000C6310 File Offset: 0x000C4510
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday > this.weekday;
		}
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F53 RID: 8019
	[SerializeField]
	private int week;

	// Token: 0x04001F54 RID: 8020
	[SerializeField]
	private DayOfWeek weekday;
}
