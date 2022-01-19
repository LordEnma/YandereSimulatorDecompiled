using System;
using UnityEngine;

// Token: 0x020002BA RID: 698
[Serializable]
public class TimeOfDayEventTime : IScheduledEventTime
{
	// Token: 0x0600145D RID: 5213 RVA: 0x000C66CE File Offset: 0x000C48CE
	public TimeOfDayEventTime(int week, DayOfWeek weekday, TimeOfDay timeOfDay)
	{
		this.week = week;
		this.weekday = weekday;
		this.timeOfDay = timeOfDay;
	}

	// Token: 0x1700036C RID: 876
	// (get) Token: 0x0600145E RID: 5214 RVA: 0x000C66EB File Offset: 0x000C48EB
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.TimeOfDay;
		}
	}

	// Token: 0x0600145F RID: 5215 RVA: 0x000C66F0 File Offset: 0x000C48F0
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		bool flag3 = currentTime.Clock.TimeOfDay == this.timeOfDay;
		return flag && flag2 && flag3;
	}

	// Token: 0x06001460 RID: 5216 RVA: 0x000C6734 File Offset: 0x000C4934
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

	// Token: 0x06001461 RID: 5217 RVA: 0x000C6790 File Offset: 0x000C4990
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

	// Token: 0x04001F57 RID: 8023
	[SerializeField]
	private int week;

	// Token: 0x04001F58 RID: 8024
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F59 RID: 8025
	[SerializeField]
	private TimeOfDay timeOfDay;
}
