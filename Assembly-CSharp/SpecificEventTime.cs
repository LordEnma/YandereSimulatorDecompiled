using System;
using UnityEngine;

// Token: 0x020002B9 RID: 697
[Serializable]
public class SpecificEventTime : IScheduledEventTime
{
	// Token: 0x06001459 RID: 5209 RVA: 0x000C68CA File Offset: 0x000C4ACA
	public SpecificEventTime(int week, DayOfWeek weekday, Clock startClock, Clock endClock)
	{
		this.week = week;
		this.weekday = weekday;
		this.startClock = startClock;
		this.endClock = endClock;
	}

	// Token: 0x1700036B RID: 875
	// (get) Token: 0x0600145A RID: 5210 RVA: 0x000C68EF File Offset: 0x000C4AEF
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Specific;
		}
	}

	// Token: 0x0600145B RID: 5211 RVA: 0x000C68F4 File Offset: 0x000C4AF4
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		Clock clock = currentTime.Clock;
		bool flag3 = clock.TotalSeconds >= this.startClock.TotalSeconds && clock.TotalSeconds < this.endClock.TotalSeconds;
		return flag && flag2 && flag3;
	}

	// Token: 0x0600145C RID: 5212 RVA: 0x000C6954 File Offset: 0x000C4B54
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

	// Token: 0x0600145D RID: 5213 RVA: 0x000C69B4 File Offset: 0x000C4BB4
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

	// Token: 0x04001F5A RID: 8026
	[SerializeField]
	private int week;

	// Token: 0x04001F5B RID: 8027
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F5C RID: 8028
	[SerializeField]
	private Clock startClock;

	// Token: 0x04001F5D RID: 8029
	[SerializeField]
	private Clock endClock;
}
