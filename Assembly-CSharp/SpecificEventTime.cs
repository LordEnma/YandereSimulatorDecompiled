using System;
using UnityEngine;

// Token: 0x020002BA RID: 698
[Serializable]
public class SpecificEventTime : IScheduledEventTime
{
	// Token: 0x0600145E RID: 5214 RVA: 0x000C69BE File Offset: 0x000C4BBE
	public SpecificEventTime(int week, DayOfWeek weekday, Clock startClock, Clock endClock)
	{
		this.week = week;
		this.weekday = weekday;
		this.startClock = startClock;
		this.endClock = endClock;
	}

	// Token: 0x1700036B RID: 875
	// (get) Token: 0x0600145F RID: 5215 RVA: 0x000C69E3 File Offset: 0x000C4BE3
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Specific;
		}
	}

	// Token: 0x06001460 RID: 5216 RVA: 0x000C69E8 File Offset: 0x000C4BE8
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		Clock clock = currentTime.Clock;
		bool flag3 = clock.TotalSeconds >= this.startClock.TotalSeconds && clock.TotalSeconds < this.endClock.TotalSeconds;
		return flag && flag2 && flag3;
	}

	// Token: 0x06001461 RID: 5217 RVA: 0x000C6A48 File Offset: 0x000C4C48
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

	// Token: 0x06001462 RID: 5218 RVA: 0x000C6AA8 File Offset: 0x000C4CA8
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

	// Token: 0x04001F5F RID: 8031
	[SerializeField]
	private int week;

	// Token: 0x04001F60 RID: 8032
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F61 RID: 8033
	[SerializeField]
	private Clock startClock;

	// Token: 0x04001F62 RID: 8034
	[SerializeField]
	private Clock endClock;
}
