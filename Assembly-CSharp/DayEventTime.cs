using System;
using UnityEngine;

// Token: 0x020002BD RID: 701
[Serializable]
public class DayEventTime : IScheduledEventTime
{
	// Token: 0x06001475 RID: 5237 RVA: 0x000C7BFA File Offset: 0x000C5DFA
	public DayEventTime(int week, DayOfWeek weekday)
	{
		this.week = week;
		this.weekday = weekday;
	}

	// Token: 0x1700036D RID: 877
	// (get) Token: 0x06001476 RID: 5238 RVA: 0x000C7C10 File Offset: 0x000C5E10
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Day;
		}
	}

	// Token: 0x06001477 RID: 5239 RVA: 0x000C7C13 File Offset: 0x000C5E13
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week && currentTime.Weekday == this.weekday;
	}

	// Token: 0x06001478 RID: 5240 RVA: 0x000C7C33 File Offset: 0x000C5E33
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday < this.weekday;
		}
		return currentTime.Week < this.week;
	}

	// Token: 0x06001479 RID: 5241 RVA: 0x000C7C60 File Offset: 0x000C5E60
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday > this.weekday;
		}
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F91 RID: 8081
	[SerializeField]
	private int week;

	// Token: 0x04001F92 RID: 8082
	[SerializeField]
	private DayOfWeek weekday;
}
