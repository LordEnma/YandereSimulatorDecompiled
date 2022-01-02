using System;
using UnityEngine;

// Token: 0x020002B9 RID: 697
[Serializable]
public class TimeOfDayEventTime : IScheduledEventTime
{
	// Token: 0x06001459 RID: 5209 RVA: 0x000C63D6 File Offset: 0x000C45D6
	public TimeOfDayEventTime(int week, DayOfWeek weekday, TimeOfDay timeOfDay)
	{
		this.week = week;
		this.weekday = weekday;
		this.timeOfDay = timeOfDay;
	}

	// Token: 0x1700036C RID: 876
	// (get) Token: 0x0600145A RID: 5210 RVA: 0x000C63F3 File Offset: 0x000C45F3
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.TimeOfDay;
		}
	}

	// Token: 0x0600145B RID: 5211 RVA: 0x000C63F8 File Offset: 0x000C45F8
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		bool flag3 = currentTime.Clock.TimeOfDay == this.timeOfDay;
		return flag && flag2 && flag3;
	}

	// Token: 0x0600145C RID: 5212 RVA: 0x000C643C File Offset: 0x000C463C
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

	// Token: 0x0600145D RID: 5213 RVA: 0x000C6498 File Offset: 0x000C4698
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

	// Token: 0x04001F53 RID: 8019
	[SerializeField]
	private int week;

	// Token: 0x04001F54 RID: 8020
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F55 RID: 8021
	[SerializeField]
	private TimeOfDay timeOfDay;
}
