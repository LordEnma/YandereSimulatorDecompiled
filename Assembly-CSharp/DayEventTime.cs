using System;
using UnityEngine;

// Token: 0x020002BF RID: 703
[Serializable]
public class DayEventTime : IScheduledEventTime
{
	// Token: 0x06001481 RID: 5249 RVA: 0x000C8632 File Offset: 0x000C6832
	public DayEventTime(int week, DayOfWeek weekday)
	{
		this.week = week;
		this.weekday = weekday;
	}

	// Token: 0x1700036D RID: 877
	// (get) Token: 0x06001482 RID: 5250 RVA: 0x000C8648 File Offset: 0x000C6848
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Day;
		}
	}

	// Token: 0x06001483 RID: 5251 RVA: 0x000C864B File Offset: 0x000C684B
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week && currentTime.Weekday == this.weekday;
	}

	// Token: 0x06001484 RID: 5252 RVA: 0x000C866B File Offset: 0x000C686B
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday < this.weekday;
		}
		return currentTime.Week < this.week;
	}

	// Token: 0x06001485 RID: 5253 RVA: 0x000C8698 File Offset: 0x000C6898
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday > this.weekday;
		}
		return currentTime.Week > this.week;
	}

	// Token: 0x04001FA5 RID: 8101
	[SerializeField]
	private int week;

	// Token: 0x04001FA6 RID: 8102
	[SerializeField]
	private DayOfWeek weekday;
}
