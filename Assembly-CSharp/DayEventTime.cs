using System;
using UnityEngine;

// Token: 0x020002BE RID: 702
[Serializable]
public class DayEventTime : IScheduledEventTime
{
	// Token: 0x0600147B RID: 5243 RVA: 0x000C7D02 File Offset: 0x000C5F02
	public DayEventTime(int week, DayOfWeek weekday)
	{
		this.week = week;
		this.weekday = weekday;
	}

	// Token: 0x1700036D RID: 877
	// (get) Token: 0x0600147C RID: 5244 RVA: 0x000C7D18 File Offset: 0x000C5F18
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Day;
		}
	}

	// Token: 0x0600147D RID: 5245 RVA: 0x000C7D1B File Offset: 0x000C5F1B
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week && currentTime.Weekday == this.weekday;
	}

	// Token: 0x0600147E RID: 5246 RVA: 0x000C7D3B File Offset: 0x000C5F3B
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday < this.weekday;
		}
		return currentTime.Week < this.week;
	}

	// Token: 0x0600147F RID: 5247 RVA: 0x000C7D68 File Offset: 0x000C5F68
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday > this.weekday;
		}
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F93 RID: 8083
	[SerializeField]
	private int week;

	// Token: 0x04001F94 RID: 8084
	[SerializeField]
	private DayOfWeek weekday;
}
