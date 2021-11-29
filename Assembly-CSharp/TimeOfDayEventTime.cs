using System;
using UnityEngine;

// Token: 0x020002B8 RID: 696
[Serializable]
public class TimeOfDayEventTime : IScheduledEventTime
{
	// Token: 0x06001452 RID: 5202 RVA: 0x000C59F2 File Offset: 0x000C3BF2
	public TimeOfDayEventTime(int week, DayOfWeek weekday, TimeOfDay timeOfDay)
	{
		this.week = week;
		this.weekday = weekday;
		this.timeOfDay = timeOfDay;
	}

	// Token: 0x1700036C RID: 876
	// (get) Token: 0x06001453 RID: 5203 RVA: 0x000C5A0F File Offset: 0x000C3C0F
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.TimeOfDay;
		}
	}

	// Token: 0x06001454 RID: 5204 RVA: 0x000C5A14 File Offset: 0x000C3C14
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		bool flag3 = currentTime.Clock.TimeOfDay == this.timeOfDay;
		return flag && flag2 && flag3;
	}

	// Token: 0x06001455 RID: 5205 RVA: 0x000C5A58 File Offset: 0x000C3C58
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

	// Token: 0x06001456 RID: 5206 RVA: 0x000C5AB4 File Offset: 0x000C3CB4
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

	// Token: 0x04001F30 RID: 7984
	[SerializeField]
	private int week;

	// Token: 0x04001F31 RID: 7985
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F32 RID: 7986
	[SerializeField]
	private TimeOfDay timeOfDay;
}
