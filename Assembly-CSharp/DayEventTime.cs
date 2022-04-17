using System;
using UnityEngine;

// Token: 0x020002BE RID: 702
[Serializable]
public class DayEventTime : IScheduledEventTime
{
	// Token: 0x0600147B RID: 5243 RVA: 0x000C7EAE File Offset: 0x000C60AE
	public DayEventTime(int week, DayOfWeek weekday)
	{
		this.week = week;
		this.weekday = weekday;
	}

	// Token: 0x1700036D RID: 877
	// (get) Token: 0x0600147C RID: 5244 RVA: 0x000C7EC4 File Offset: 0x000C60C4
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Day;
		}
	}

	// Token: 0x0600147D RID: 5245 RVA: 0x000C7EC7 File Offset: 0x000C60C7
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week && currentTime.Weekday == this.weekday;
	}

	// Token: 0x0600147E RID: 5246 RVA: 0x000C7EE7 File Offset: 0x000C60E7
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday < this.weekday;
		}
		return currentTime.Week < this.week;
	}

	// Token: 0x0600147F RID: 5247 RVA: 0x000C7F14 File Offset: 0x000C6114
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday > this.weekday;
		}
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F95 RID: 8085
	[SerializeField]
	private int week;

	// Token: 0x04001F96 RID: 8086
	[SerializeField]
	private DayOfWeek weekday;
}
