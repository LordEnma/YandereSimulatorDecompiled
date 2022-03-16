using System;
using UnityEngine;

// Token: 0x020002BB RID: 699
[Serializable]
public class SpecificEventTime : IScheduledEventTime
{
	// Token: 0x0600146A RID: 5226 RVA: 0x000C785E File Offset: 0x000C5A5E
	public SpecificEventTime(int week, DayOfWeek weekday, Clock startClock, Clock endClock)
	{
		this.week = week;
		this.weekday = weekday;
		this.startClock = startClock;
		this.endClock = endClock;
	}

	// Token: 0x1700036B RID: 875
	// (get) Token: 0x0600146B RID: 5227 RVA: 0x000C7883 File Offset: 0x000C5A83
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Specific;
		}
	}

	// Token: 0x0600146C RID: 5228 RVA: 0x000C7888 File Offset: 0x000C5A88
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		Clock clock = currentTime.Clock;
		bool flag3 = clock.TotalSeconds >= this.startClock.TotalSeconds && clock.TotalSeconds < this.endClock.TotalSeconds;
		return flag && flag2 && flag3;
	}

	// Token: 0x0600146D RID: 5229 RVA: 0x000C78E8 File Offset: 0x000C5AE8
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

	// Token: 0x0600146E RID: 5230 RVA: 0x000C7948 File Offset: 0x000C5B48
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

	// Token: 0x04001F87 RID: 8071
	[SerializeField]
	private int week;

	// Token: 0x04001F88 RID: 8072
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F89 RID: 8073
	[SerializeField]
	private Clock startClock;

	// Token: 0x04001F8A RID: 8074
	[SerializeField]
	private Clock endClock;
}
