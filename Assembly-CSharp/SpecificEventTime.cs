using System;
using UnityEngine;

// Token: 0x020002BC RID: 700
[Serializable]
public class SpecificEventTime : IScheduledEventTime
{
	// Token: 0x06001471 RID: 5233 RVA: 0x000C7A9A File Offset: 0x000C5C9A
	public SpecificEventTime(int week, DayOfWeek weekday, Clock startClock, Clock endClock)
	{
		this.week = week;
		this.weekday = weekday;
		this.startClock = startClock;
		this.endClock = endClock;
	}

	// Token: 0x1700036B RID: 875
	// (get) Token: 0x06001472 RID: 5234 RVA: 0x000C7ABF File Offset: 0x000C5CBF
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Specific;
		}
	}

	// Token: 0x06001473 RID: 5235 RVA: 0x000C7AC4 File Offset: 0x000C5CC4
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		Clock clock = currentTime.Clock;
		bool flag3 = clock.TotalSeconds >= this.startClock.TotalSeconds && clock.TotalSeconds < this.endClock.TotalSeconds;
		return flag && flag2 && flag3;
	}

	// Token: 0x06001474 RID: 5236 RVA: 0x000C7B24 File Offset: 0x000C5D24
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

	// Token: 0x06001475 RID: 5237 RVA: 0x000C7B84 File Offset: 0x000C5D84
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

	// Token: 0x04001F8C RID: 8076
	[SerializeField]
	private int week;

	// Token: 0x04001F8D RID: 8077
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F8E RID: 8078
	[SerializeField]
	private Clock startClock;

	// Token: 0x04001F8F RID: 8079
	[SerializeField]
	private Clock endClock;
}
