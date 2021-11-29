using System;
using UnityEngine;

// Token: 0x020002B7 RID: 695
[Serializable]
public class SpecificEventTime : IScheduledEventTime
{
	// Token: 0x0600144D RID: 5197 RVA: 0x000C58A8 File Offset: 0x000C3AA8
	public SpecificEventTime(int week, DayOfWeek weekday, Clock startClock, Clock endClock)
	{
		this.week = week;
		this.weekday = weekday;
		this.startClock = startClock;
		this.endClock = endClock;
	}

	// Token: 0x1700036B RID: 875
	// (get) Token: 0x0600144E RID: 5198 RVA: 0x000C58CD File Offset: 0x000C3ACD
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Specific;
		}
	}

	// Token: 0x0600144F RID: 5199 RVA: 0x000C58D0 File Offset: 0x000C3AD0
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		Clock clock = currentTime.Clock;
		bool flag3 = clock.TotalSeconds >= this.startClock.TotalSeconds && clock.TotalSeconds < this.endClock.TotalSeconds;
		return flag && flag2 && flag3;
	}

	// Token: 0x06001450 RID: 5200 RVA: 0x000C5930 File Offset: 0x000C3B30
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		if (currentTime.Week != this.week)
		{
			return currentTime.Week < this.week;
		}
		if (currentTime.Weekday == this.weekday)
		{
			return currentTime.Clock.TotalSeconds < this.startClock.TotalSeconds;
		}
		return currentTime.Weekday < this.weekday;
	}

	// Token: 0x06001451 RID: 5201 RVA: 0x000C5990 File Offset: 0x000C3B90
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		if (currentTime.Week != this.week)
		{
			return currentTime.Week > this.week;
		}
		if (currentTime.Weekday == this.weekday)
		{
			return currentTime.Clock.TotalSeconds >= this.endClock.TotalSeconds;
		}
		return currentTime.Weekday > this.weekday;
	}

	// Token: 0x04001F2C RID: 7980
	[SerializeField]
	private int week;

	// Token: 0x04001F2D RID: 7981
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F2E RID: 7982
	[SerializeField]
	private Clock startClock;

	// Token: 0x04001F2F RID: 7983
	[SerializeField]
	private Clock endClock;
}
