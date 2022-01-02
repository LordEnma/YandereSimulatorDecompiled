using System;
using UnityEngine;

// Token: 0x020002BA RID: 698
[Serializable]
public class DayEventTime : IScheduledEventTime
{
	// Token: 0x0600145E RID: 5214 RVA: 0x000C64F2 File Offset: 0x000C46F2
	public DayEventTime(int week, DayOfWeek weekday)
	{
		this.week = week;
		this.weekday = weekday;
	}

	// Token: 0x1700036D RID: 877
	// (get) Token: 0x0600145F RID: 5215 RVA: 0x000C6508 File Offset: 0x000C4708
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Day;
		}
	}

	// Token: 0x06001460 RID: 5216 RVA: 0x000C650B File Offset: 0x000C470B
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week && currentTime.Weekday == this.weekday;
	}

	// Token: 0x06001461 RID: 5217 RVA: 0x000C652B File Offset: 0x000C472B
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday < this.weekday;
		}
		return currentTime.Week < this.week;
	}

	// Token: 0x06001462 RID: 5218 RVA: 0x000C6558 File Offset: 0x000C4758
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday > this.weekday;
		}
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F56 RID: 8022
	[SerializeField]
	private int week;

	// Token: 0x04001F57 RID: 8023
	[SerializeField]
	private DayOfWeek weekday;
}
