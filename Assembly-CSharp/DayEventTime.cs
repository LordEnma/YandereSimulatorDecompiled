using System;
using UnityEngine;

// Token: 0x020002BE RID: 702
[Serializable]
public class DayEventTime : IScheduledEventTime
{
	// Token: 0x0600147F RID: 5247 RVA: 0x000C8376 File Offset: 0x000C6576
	public DayEventTime(int week, DayOfWeek weekday)
	{
		this.week = week;
		this.weekday = weekday;
	}

	// Token: 0x1700036D RID: 877
	// (get) Token: 0x06001480 RID: 5248 RVA: 0x000C838C File Offset: 0x000C658C
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Day;
		}
	}

	// Token: 0x06001481 RID: 5249 RVA: 0x000C838F File Offset: 0x000C658F
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week && currentTime.Weekday == this.weekday;
	}

	// Token: 0x06001482 RID: 5250 RVA: 0x000C83AF File Offset: 0x000C65AF
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday < this.weekday;
		}
		return currentTime.Week < this.week;
	}

	// Token: 0x06001483 RID: 5251 RVA: 0x000C83DC File Offset: 0x000C65DC
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday > this.weekday;
		}
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F9E RID: 8094
	[SerializeField]
	private int week;

	// Token: 0x04001F9F RID: 8095
	[SerializeField]
	private DayOfWeek weekday;
}
