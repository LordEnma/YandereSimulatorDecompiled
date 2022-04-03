using System;
using UnityEngine;

// Token: 0x020002BB RID: 699
[Serializable]
public class SpecificEventTime : IScheduledEventTime
{
	// Token: 0x0600146B RID: 5227 RVA: 0x000C7992 File Offset: 0x000C5B92
	public SpecificEventTime(int week, DayOfWeek weekday, Clock startClock, Clock endClock)
	{
		this.week = week;
		this.weekday = weekday;
		this.startClock = startClock;
		this.endClock = endClock;
	}

	// Token: 0x1700036B RID: 875
	// (get) Token: 0x0600146C RID: 5228 RVA: 0x000C79B7 File Offset: 0x000C5BB7
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Specific;
		}
	}

	// Token: 0x0600146D RID: 5229 RVA: 0x000C79BC File Offset: 0x000C5BBC
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		Clock clock = currentTime.Clock;
		bool flag3 = clock.TotalSeconds >= this.startClock.TotalSeconds && clock.TotalSeconds < this.endClock.TotalSeconds;
		return flag && flag2 && flag3;
	}

	// Token: 0x0600146E RID: 5230 RVA: 0x000C7A1C File Offset: 0x000C5C1C
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

	// Token: 0x0600146F RID: 5231 RVA: 0x000C7A7C File Offset: 0x000C5C7C
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

	// Token: 0x04001F8A RID: 8074
	[SerializeField]
	private int week;

	// Token: 0x04001F8B RID: 8075
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F8C RID: 8076
	[SerializeField]
	private Clock startClock;

	// Token: 0x04001F8D RID: 8077
	[SerializeField]
	private Clock endClock;
}
