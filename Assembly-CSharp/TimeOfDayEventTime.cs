using System;
using UnityEngine;

// Token: 0x020002BC RID: 700
[Serializable]
public class TimeOfDayEventTime : IScheduledEventTime
{
	// Token: 0x0600146F RID: 5231 RVA: 0x000C79AA File Offset: 0x000C5BAA
	public TimeOfDayEventTime(int week, DayOfWeek weekday, TimeOfDay timeOfDay)
	{
		this.week = week;
		this.weekday = weekday;
		this.timeOfDay = timeOfDay;
	}

	// Token: 0x1700036C RID: 876
	// (get) Token: 0x06001470 RID: 5232 RVA: 0x000C79C7 File Offset: 0x000C5BC7
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.TimeOfDay;
		}
	}

	// Token: 0x06001471 RID: 5233 RVA: 0x000C79CC File Offset: 0x000C5BCC
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		bool flag3 = currentTime.Clock.TimeOfDay == this.timeOfDay;
		return flag && flag2 && flag3;
	}

	// Token: 0x06001472 RID: 5234 RVA: 0x000C7A10 File Offset: 0x000C5C10
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

	// Token: 0x06001473 RID: 5235 RVA: 0x000C7A6C File Offset: 0x000C5C6C
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

	// Token: 0x04001F8B RID: 8075
	[SerializeField]
	private int week;

	// Token: 0x04001F8C RID: 8076
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F8D RID: 8077
	[SerializeField]
	private TimeOfDay timeOfDay;
}
