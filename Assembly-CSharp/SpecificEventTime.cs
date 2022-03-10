using System;
using UnityEngine;

// Token: 0x020002BB RID: 699
[Serializable]
public class SpecificEventTime : IScheduledEventTime
{
	// Token: 0x06001467 RID: 5223 RVA: 0x000C73EE File Offset: 0x000C55EE
	public SpecificEventTime(int week, DayOfWeek weekday, Clock startClock, Clock endClock)
	{
		this.week = week;
		this.weekday = weekday;
		this.startClock = startClock;
		this.endClock = endClock;
	}

	// Token: 0x1700036B RID: 875
	// (get) Token: 0x06001468 RID: 5224 RVA: 0x000C7413 File Offset: 0x000C5613
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Specific;
		}
	}

	// Token: 0x06001469 RID: 5225 RVA: 0x000C7418 File Offset: 0x000C5618
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		Clock clock = currentTime.Clock;
		bool flag3 = clock.TotalSeconds >= this.startClock.TotalSeconds && clock.TotalSeconds < this.endClock.TotalSeconds;
		return flag && flag2 && flag3;
	}

	// Token: 0x0600146A RID: 5226 RVA: 0x000C7478 File Offset: 0x000C5678
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

	// Token: 0x0600146B RID: 5227 RVA: 0x000C74D8 File Offset: 0x000C56D8
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

	// Token: 0x04001F77 RID: 8055
	[SerializeField]
	private int week;

	// Token: 0x04001F78 RID: 8056
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F79 RID: 8057
	[SerializeField]
	private Clock startClock;

	// Token: 0x04001F7A RID: 8058
	[SerializeField]
	private Clock endClock;
}
