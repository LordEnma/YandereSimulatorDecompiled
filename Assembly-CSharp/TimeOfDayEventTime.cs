using System;
using UnityEngine;

// Token: 0x020002B9 RID: 697
[Serializable]
public class TimeOfDayEventTime : IScheduledEventTime
{
	// Token: 0x06001459 RID: 5209 RVA: 0x000C618E File Offset: 0x000C438E
	public TimeOfDayEventTime(int week, DayOfWeek weekday, TimeOfDay timeOfDay)
	{
		this.week = week;
		this.weekday = weekday;
		this.timeOfDay = timeOfDay;
	}

	// Token: 0x1700036C RID: 876
	// (get) Token: 0x0600145A RID: 5210 RVA: 0x000C61AB File Offset: 0x000C43AB
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.TimeOfDay;
		}
	}

	// Token: 0x0600145B RID: 5211 RVA: 0x000C61B0 File Offset: 0x000C43B0
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		bool flag3 = currentTime.Clock.TimeOfDay == this.timeOfDay;
		return flag && flag2 && flag3;
	}

	// Token: 0x0600145C RID: 5212 RVA: 0x000C61F4 File Offset: 0x000C43F4
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

	// Token: 0x0600145D RID: 5213 RVA: 0x000C6250 File Offset: 0x000C4450
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

	// Token: 0x04001F50 RID: 8016
	[SerializeField]
	private int week;

	// Token: 0x04001F51 RID: 8017
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F52 RID: 8018
	[SerializeField]
	private TimeOfDay timeOfDay;
}
