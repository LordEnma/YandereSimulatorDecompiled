using System;
using UnityEngine;

// Token: 0x020002BA RID: 698
[Serializable]
public class TimeOfDayEventTime : IScheduledEventTime
{
	// Token: 0x0600145D RID: 5213 RVA: 0x000C65FA File Offset: 0x000C47FA
	public TimeOfDayEventTime(int week, DayOfWeek weekday, TimeOfDay timeOfDay)
	{
		this.week = week;
		this.weekday = weekday;
		this.timeOfDay = timeOfDay;
	}

	// Token: 0x1700036C RID: 876
	// (get) Token: 0x0600145E RID: 5214 RVA: 0x000C6617 File Offset: 0x000C4817
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.TimeOfDay;
		}
	}

	// Token: 0x0600145F RID: 5215 RVA: 0x000C661C File Offset: 0x000C481C
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		bool flag3 = currentTime.Clock.TimeOfDay == this.timeOfDay;
		return flag && flag2 && flag3;
	}

	// Token: 0x06001460 RID: 5216 RVA: 0x000C6660 File Offset: 0x000C4860
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

	// Token: 0x06001461 RID: 5217 RVA: 0x000C66BC File Offset: 0x000C48BC
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

	// Token: 0x04001F54 RID: 8020
	[SerializeField]
	private int week;

	// Token: 0x04001F55 RID: 8021
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F56 RID: 8022
	[SerializeField]
	private TimeOfDay timeOfDay;
}
