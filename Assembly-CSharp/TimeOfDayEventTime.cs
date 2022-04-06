using System;
using UnityEngine;

// Token: 0x020002BD RID: 701
[Serializable]
public class TimeOfDayEventTime : IScheduledEventTime
{
	// Token: 0x06001476 RID: 5238 RVA: 0x000C7BE6 File Offset: 0x000C5DE6
	public TimeOfDayEventTime(int week, DayOfWeek weekday, TimeOfDay timeOfDay)
	{
		this.week = week;
		this.weekday = weekday;
		this.timeOfDay = timeOfDay;
	}

	// Token: 0x1700036C RID: 876
	// (get) Token: 0x06001477 RID: 5239 RVA: 0x000C7C03 File Offset: 0x000C5E03
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.TimeOfDay;
		}
	}

	// Token: 0x06001478 RID: 5240 RVA: 0x000C7C08 File Offset: 0x000C5E08
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		bool flag3 = currentTime.Clock.TimeOfDay == this.timeOfDay;
		return flag && flag2 && flag3;
	}

	// Token: 0x06001479 RID: 5241 RVA: 0x000C7C4C File Offset: 0x000C5E4C
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		if (currentTime.Week != this.week)
		{
			return currentTime.Week < this.week;
		}
		if (currentTime.Weekday == this.weekday)
		{
			return currentTime.Clock.TimeOfDay < this.timeOfDay;
		}
		return currentTime.Weekday < this.weekday;
	}

	// Token: 0x0600147A RID: 5242 RVA: 0x000C7CA8 File Offset: 0x000C5EA8
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		if (currentTime.Week != this.week)
		{
			return currentTime.Week > this.week;
		}
		if (currentTime.Weekday == this.weekday)
		{
			return currentTime.Clock.TimeOfDay > this.timeOfDay;
		}
		return currentTime.Weekday > this.weekday;
	}

	// Token: 0x04001F90 RID: 8080
	[SerializeField]
	private int week;

	// Token: 0x04001F91 RID: 8081
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F92 RID: 8082
	[SerializeField]
	private TimeOfDay timeOfDay;
}
