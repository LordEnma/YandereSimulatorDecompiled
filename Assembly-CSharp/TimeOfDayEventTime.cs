using System;
using UnityEngine;

// Token: 0x020002BE RID: 702
[Serializable]
public class TimeOfDayEventTime : IScheduledEventTime
{
	// Token: 0x0600147C RID: 5244 RVA: 0x000C8516 File Offset: 0x000C6716
	public TimeOfDayEventTime(int week, DayOfWeek weekday, TimeOfDay timeOfDay)
	{
		this.week = week;
		this.weekday = weekday;
		this.timeOfDay = timeOfDay;
	}

	// Token: 0x1700036C RID: 876
	// (get) Token: 0x0600147D RID: 5245 RVA: 0x000C8533 File Offset: 0x000C6733
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.TimeOfDay;
		}
	}

	// Token: 0x0600147E RID: 5246 RVA: 0x000C8538 File Offset: 0x000C6738
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		bool flag3 = currentTime.Clock.TimeOfDay == this.timeOfDay;
		return flag && flag2 && flag3;
	}

	// Token: 0x0600147F RID: 5247 RVA: 0x000C857C File Offset: 0x000C677C
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

	// Token: 0x06001480 RID: 5248 RVA: 0x000C85D8 File Offset: 0x000C67D8
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

	// Token: 0x04001FA2 RID: 8098
	[SerializeField]
	private int week;

	// Token: 0x04001FA3 RID: 8099
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001FA4 RID: 8100
	[SerializeField]
	private TimeOfDay timeOfDay;
}
