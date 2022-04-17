using System;
using UnityEngine;

// Token: 0x020002BD RID: 701
[Serializable]
public class TimeOfDayEventTime : IScheduledEventTime
{
	// Token: 0x06001476 RID: 5238 RVA: 0x000C7D92 File Offset: 0x000C5F92
	public TimeOfDayEventTime(int week, DayOfWeek weekday, TimeOfDay timeOfDay)
	{
		this.week = week;
		this.weekday = weekday;
		this.timeOfDay = timeOfDay;
	}

	// Token: 0x1700036C RID: 876
	// (get) Token: 0x06001477 RID: 5239 RVA: 0x000C7DAF File Offset: 0x000C5FAF
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.TimeOfDay;
		}
	}

	// Token: 0x06001478 RID: 5240 RVA: 0x000C7DB4 File Offset: 0x000C5FB4
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		bool flag3 = currentTime.Clock.TimeOfDay == this.timeOfDay;
		return flag && flag2 && flag3;
	}

	// Token: 0x06001479 RID: 5241 RVA: 0x000C7DF8 File Offset: 0x000C5FF8
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

	// Token: 0x0600147A RID: 5242 RVA: 0x000C7E54 File Offset: 0x000C6054
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

	// Token: 0x04001F92 RID: 8082
	[SerializeField]
	private int week;

	// Token: 0x04001F93 RID: 8083
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F94 RID: 8084
	[SerializeField]
	private TimeOfDay timeOfDay;
}
