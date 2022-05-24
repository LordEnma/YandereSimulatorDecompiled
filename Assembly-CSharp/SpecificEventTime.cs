using System;
using UnityEngine;

// Token: 0x020002BD RID: 701
[Serializable]
public class SpecificEventTime : IScheduledEventTime
{
	// Token: 0x06001477 RID: 5239 RVA: 0x000C8462 File Offset: 0x000C6662
	public SpecificEventTime(int week, DayOfWeek weekday, Clock startClock, Clock endClock)
	{
		this.week = week;
		this.weekday = weekday;
		this.startClock = startClock;
		this.endClock = endClock;
	}

	// Token: 0x1700036B RID: 875
	// (get) Token: 0x06001478 RID: 5240 RVA: 0x000C8487 File Offset: 0x000C6687
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Specific;
		}
	}

	// Token: 0x06001479 RID: 5241 RVA: 0x000C848C File Offset: 0x000C668C
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		Clock clock = currentTime.Clock;
		bool flag3 = clock.TotalSeconds >= this.startClock.TotalSeconds && clock.TotalSeconds < this.endClock.TotalSeconds;
		return flag && flag2 && flag3;
	}

	// Token: 0x0600147A RID: 5242 RVA: 0x000C84EC File Offset: 0x000C66EC
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

	// Token: 0x0600147B RID: 5243 RVA: 0x000C854C File Offset: 0x000C674C
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

	// Token: 0x04001F9E RID: 8094
	[SerializeField]
	private int week;

	// Token: 0x04001F9F RID: 8095
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001FA0 RID: 8096
	[SerializeField]
	private Clock startClock;

	// Token: 0x04001FA1 RID: 8097
	[SerializeField]
	private Clock endClock;
}
