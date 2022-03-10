using System;
using UnityEngine;

// Token: 0x020002BC RID: 700
[Serializable]
public class TimeOfDayEventTime : IScheduledEventTime
{
	// Token: 0x0600146C RID: 5228 RVA: 0x000C753A File Offset: 0x000C573A
	public TimeOfDayEventTime(int week, DayOfWeek weekday, TimeOfDay timeOfDay)
	{
		this.week = week;
		this.weekday = weekday;
		this.timeOfDay = timeOfDay;
	}

	// Token: 0x1700036C RID: 876
	// (get) Token: 0x0600146D RID: 5229 RVA: 0x000C7557 File Offset: 0x000C5757
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.TimeOfDay;
		}
	}

	// Token: 0x0600146E RID: 5230 RVA: 0x000C755C File Offset: 0x000C575C
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		bool flag3 = currentTime.Clock.TimeOfDay == this.timeOfDay;
		return flag && flag2 && flag3;
	}

	// Token: 0x0600146F RID: 5231 RVA: 0x000C75A0 File Offset: 0x000C57A0
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

	// Token: 0x06001470 RID: 5232 RVA: 0x000C75FC File Offset: 0x000C57FC
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

	// Token: 0x04001F7B RID: 8059
	[SerializeField]
	private int week;

	// Token: 0x04001F7C RID: 8060
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F7D RID: 8061
	[SerializeField]
	private TimeOfDay timeOfDay;
}
