using System;
using UnityEngine;

// Token: 0x020002BB RID: 699
[Serializable]
public class TimeOfDayEventTime : IScheduledEventTime
{
	// Token: 0x06001463 RID: 5219 RVA: 0x000C6B0A File Offset: 0x000C4D0A
	public TimeOfDayEventTime(int week, DayOfWeek weekday, TimeOfDay timeOfDay)
	{
		this.week = week;
		this.weekday = weekday;
		this.timeOfDay = timeOfDay;
	}

	// Token: 0x1700036C RID: 876
	// (get) Token: 0x06001464 RID: 5220 RVA: 0x000C6B27 File Offset: 0x000C4D27
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.TimeOfDay;
		}
	}

	// Token: 0x06001465 RID: 5221 RVA: 0x000C6B2C File Offset: 0x000C4D2C
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		bool flag3 = currentTime.Clock.TimeOfDay == this.timeOfDay;
		return flag && flag2 && flag3;
	}

	// Token: 0x06001466 RID: 5222 RVA: 0x000C6B70 File Offset: 0x000C4D70
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

	// Token: 0x06001467 RID: 5223 RVA: 0x000C6BCC File Offset: 0x000C4DCC
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

	// Token: 0x04001F63 RID: 8035
	[SerializeField]
	private int week;

	// Token: 0x04001F64 RID: 8036
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F65 RID: 8037
	[SerializeField]
	private TimeOfDay timeOfDay;
}
