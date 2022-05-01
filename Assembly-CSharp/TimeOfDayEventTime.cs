using System;
using UnityEngine;

// Token: 0x020002BD RID: 701
[Serializable]
public class TimeOfDayEventTime : IScheduledEventTime
{
	// Token: 0x0600147A RID: 5242 RVA: 0x000C825A File Offset: 0x000C645A
	public TimeOfDayEventTime(int week, DayOfWeek weekday, TimeOfDay timeOfDay)
	{
		this.week = week;
		this.weekday = weekday;
		this.timeOfDay = timeOfDay;
	}

	// Token: 0x1700036C RID: 876
	// (get) Token: 0x0600147B RID: 5243 RVA: 0x000C8277 File Offset: 0x000C6477
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.TimeOfDay;
		}
	}

	// Token: 0x0600147C RID: 5244 RVA: 0x000C827C File Offset: 0x000C647C
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		bool flag3 = currentTime.Clock.TimeOfDay == this.timeOfDay;
		return flag && flag2 && flag3;
	}

	// Token: 0x0600147D RID: 5245 RVA: 0x000C82C0 File Offset: 0x000C64C0
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

	// Token: 0x0600147E RID: 5246 RVA: 0x000C831C File Offset: 0x000C651C
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

	// Token: 0x04001F9B RID: 8091
	[SerializeField]
	private int week;

	// Token: 0x04001F9C RID: 8092
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F9D RID: 8093
	[SerializeField]
	private TimeOfDay timeOfDay;
}
