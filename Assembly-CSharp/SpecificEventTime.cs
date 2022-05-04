using System;
using UnityEngine;

// Token: 0x020002BC RID: 700
[Serializable]
public class SpecificEventTime : IScheduledEventTime
{
	// Token: 0x06001475 RID: 5237 RVA: 0x000C80DA File Offset: 0x000C62DA
	public SpecificEventTime(int week, DayOfWeek weekday, Clock startClock, Clock endClock)
	{
		this.week = week;
		this.weekday = weekday;
		this.startClock = startClock;
		this.endClock = endClock;
	}

	// Token: 0x1700036B RID: 875
	// (get) Token: 0x06001476 RID: 5238 RVA: 0x000C80FF File Offset: 0x000C62FF
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Specific;
		}
	}

	// Token: 0x06001477 RID: 5239 RVA: 0x000C8104 File Offset: 0x000C6304
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		Clock clock = currentTime.Clock;
		bool flag3 = clock.TotalSeconds >= this.startClock.TotalSeconds && clock.TotalSeconds < this.endClock.TotalSeconds;
		return flag && flag2 && flag3;
	}

	// Token: 0x06001478 RID: 5240 RVA: 0x000C8164 File Offset: 0x000C6364
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

	// Token: 0x06001479 RID: 5241 RVA: 0x000C81C4 File Offset: 0x000C63C4
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

	// Token: 0x04001F97 RID: 8087
	[SerializeField]
	private int week;

	// Token: 0x04001F98 RID: 8088
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F99 RID: 8089
	[SerializeField]
	private Clock startClock;

	// Token: 0x04001F9A RID: 8090
	[SerializeField]
	private Clock endClock;
}
