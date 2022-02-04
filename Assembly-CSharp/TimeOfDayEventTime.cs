using System;
using UnityEngine;

// Token: 0x020002BA RID: 698
[Serializable]
public class TimeOfDayEventTime : IScheduledEventTime
{
	// Token: 0x0600145E RID: 5214 RVA: 0x000C6986 File Offset: 0x000C4B86
	public TimeOfDayEventTime(int week, DayOfWeek weekday, TimeOfDay timeOfDay)
	{
		this.week = week;
		this.weekday = weekday;
		this.timeOfDay = timeOfDay;
	}

	// Token: 0x1700036C RID: 876
	// (get) Token: 0x0600145F RID: 5215 RVA: 0x000C69A3 File Offset: 0x000C4BA3
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.TimeOfDay;
		}
	}

	// Token: 0x06001460 RID: 5216 RVA: 0x000C69A8 File Offset: 0x000C4BA8
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		bool flag3 = currentTime.Clock.TimeOfDay == this.timeOfDay;
		return flag && flag2 && flag3;
	}

	// Token: 0x06001461 RID: 5217 RVA: 0x000C69EC File Offset: 0x000C4BEC
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

	// Token: 0x06001462 RID: 5218 RVA: 0x000C6A48 File Offset: 0x000C4C48
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

	// Token: 0x04001F5C RID: 8028
	[SerializeField]
	private int week;

	// Token: 0x04001F5D RID: 8029
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F5E RID: 8030
	[SerializeField]
	private TimeOfDay timeOfDay;
}
