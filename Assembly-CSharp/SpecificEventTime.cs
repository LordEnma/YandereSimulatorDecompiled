using System;
using UnityEngine;

// Token: 0x020002BB RID: 699
[Serializable]
public class SpecificEventTime : IScheduledEventTime
{
	// Token: 0x06001467 RID: 5223 RVA: 0x000C72A2 File Offset: 0x000C54A2
	public SpecificEventTime(int week, DayOfWeek weekday, Clock startClock, Clock endClock)
	{
		this.week = week;
		this.weekday = weekday;
		this.startClock = startClock;
		this.endClock = endClock;
	}

	// Token: 0x1700036B RID: 875
	// (get) Token: 0x06001468 RID: 5224 RVA: 0x000C72C7 File Offset: 0x000C54C7
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Specific;
		}
	}

	// Token: 0x06001469 RID: 5225 RVA: 0x000C72CC File Offset: 0x000C54CC
	public bool OccurringNow(DateAndTime currentTime)
	{
		bool flag = currentTime.Week == this.week;
		bool flag2 = currentTime.Weekday == this.weekday;
		Clock clock = currentTime.Clock;
		bool flag3 = clock.TotalSeconds >= this.startClock.TotalSeconds && clock.TotalSeconds < this.endClock.TotalSeconds;
		return flag && flag2 && flag3;
	}

	// Token: 0x0600146A RID: 5226 RVA: 0x000C732C File Offset: 0x000C552C
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

	// Token: 0x0600146B RID: 5227 RVA: 0x000C738C File Offset: 0x000C558C
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

	// Token: 0x04001F6E RID: 8046
	[SerializeField]
	private int week;

	// Token: 0x04001F6F RID: 8047
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04001F70 RID: 8048
	[SerializeField]
	private Clock startClock;

	// Token: 0x04001F71 RID: 8049
	[SerializeField]
	private Clock endClock;
}
