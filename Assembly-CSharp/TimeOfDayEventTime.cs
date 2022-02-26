using System;
using UnityEngine;

// Token: 0x020002BC RID: 700
[Serializable]
public class TimeOfDayEventTime : IScheduledEventTime
{
	// Token: 0x0600146C RID: 5228 RVA: 0x000C73EE File Offset: 0x000C55EE
	public TimeOfDayEventTime(int week, DayOfWeek weekday, TimeOfDay timeOfDay)
	{
		this.week = week;
		this.weekday = weekday;
		this.timeOfDay = timeOfDay;
	}

	// Token: 0x1700036C RID: 876
	// (get) Token: 0x0600146D RID: 5229 RVA: 0x000C740B File Offset: 0x000C560B
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.TimeOfDay;
		}
	}

	// Token: 0x0600146E RID: 5230 RVA: 0x000C7410 File Offset: 0x000C5610
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		bool flag3 = currentTime.Clock.TimeOfDay == this.timeOfDay;
		return flag && flag2 && flag3;
	}

	// Token: 0x0600146F RID: 5231 RVA: 0x000C7454 File Offset: 0x000C5654
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

	// Token: 0x06001470 RID: 5232 RVA: 0x000C74B0 File Offset: 0x000C56B0
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

	// Token: 0x04001F72 RID: 8050
	[SerializeField]
	private int week;

	// Token: 0x04001F73 RID: 8051
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F74 RID: 8052
	[SerializeField]
	private TimeOfDay timeOfDay;
}
