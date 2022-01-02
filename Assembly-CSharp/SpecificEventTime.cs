using System;
using UnityEngine;

// Token: 0x020002B8 RID: 696
[Serializable]
public class SpecificEventTime : IScheduledEventTime
{
	// Token: 0x06001454 RID: 5204 RVA: 0x000C628C File Offset: 0x000C448C
	public SpecificEventTime(int week, DayOfWeek weekday, Clock startClock, Clock endClock)
	{
		this.week = week;
		this.weekday = weekday;
		this.startClock = startClock;
		this.endClock = endClock;
	}

	// Token: 0x1700036B RID: 875
	// (get) Token: 0x06001455 RID: 5205 RVA: 0x000C62B1 File Offset: 0x000C44B1
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Specific;
		}
	}

	// Token: 0x06001456 RID: 5206 RVA: 0x000C62B4 File Offset: 0x000C44B4
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		Clock clock = currentTime.Clock;
		bool flag3 = clock.TotalSeconds >= this.startClock.TotalSeconds && clock.TotalSeconds < this.endClock.TotalSeconds;
		return flag && flag2 && flag3;
	}

	// Token: 0x06001457 RID: 5207 RVA: 0x000C6314 File Offset: 0x000C4514
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

	// Token: 0x06001458 RID: 5208 RVA: 0x000C6374 File Offset: 0x000C4574
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

	// Token: 0x04001F4F RID: 8015
	[SerializeField]
	private int week;

	// Token: 0x04001F50 RID: 8016
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F51 RID: 8017
	[SerializeField]
	private Clock startClock;

	// Token: 0x04001F52 RID: 8018
	[SerializeField]
	private Clock endClock;
}
