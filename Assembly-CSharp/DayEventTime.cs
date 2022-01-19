using System;
using UnityEngine;

// Token: 0x020002BB RID: 699
[Serializable]
public class DayEventTime : IScheduledEventTime
{
	// Token: 0x06001462 RID: 5218 RVA: 0x000C67EA File Offset: 0x000C49EA
	public DayEventTime(int week, DayOfWeek weekday)
	{
		this.week = week;
		this.weekday = weekday;
	}

	// Token: 0x1700036D RID: 877
	// (get) Token: 0x06001463 RID: 5219 RVA: 0x000C6800 File Offset: 0x000C4A00
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Day;
		}
	}

	// Token: 0x06001464 RID: 5220 RVA: 0x000C6803 File Offset: 0x000C4A03
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week && currentTime.Weekday == this.weekday;
	}

	// Token: 0x06001465 RID: 5221 RVA: 0x000C6823 File Offset: 0x000C4A23
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday < this.weekday;
		}
		return currentTime.Week < this.week;
	}

	// Token: 0x06001466 RID: 5222 RVA: 0x000C6850 File Offset: 0x000C4A50
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday > this.weekday;
		}
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F5A RID: 8026
	[SerializeField]
	private int week;

	// Token: 0x04001F5B RID: 8027
	[SerializeField]
	private DayOfWeek weekday;
}
