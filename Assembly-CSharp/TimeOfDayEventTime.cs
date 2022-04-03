using System;
using UnityEngine;

// Token: 0x020002BC RID: 700
[Serializable]
public class TimeOfDayEventTime : IScheduledEventTime
{
	// Token: 0x06001470 RID: 5232 RVA: 0x000C7ADE File Offset: 0x000C5CDE
	public TimeOfDayEventTime(int week, DayOfWeek weekday, TimeOfDay timeOfDay)
	{
		this.week = week;
		this.weekday = weekday;
		this.timeOfDay = timeOfDay;
	}

	// Token: 0x1700036C RID: 876
	// (get) Token: 0x06001471 RID: 5233 RVA: 0x000C7AFB File Offset: 0x000C5CFB
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.TimeOfDay;
		}
	}

	// Token: 0x06001472 RID: 5234 RVA: 0x000C7B00 File Offset: 0x000C5D00
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		bool flag3 = currentTime.Clock.TimeOfDay == this.timeOfDay;
		return flag && flag2 && flag3;
	}

	// Token: 0x06001473 RID: 5235 RVA: 0x000C7B44 File Offset: 0x000C5D44
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

	// Token: 0x06001474 RID: 5236 RVA: 0x000C7BA0 File Offset: 0x000C5DA0
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

	// Token: 0x04001F8E RID: 8078
	[SerializeField]
	private int week;

	// Token: 0x04001F8F RID: 8079
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F90 RID: 8080
	[SerializeField]
	private TimeOfDay timeOfDay;
}
