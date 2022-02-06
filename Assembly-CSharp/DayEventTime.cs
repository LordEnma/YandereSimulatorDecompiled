using System;
using UnityEngine;

// Token: 0x020002BB RID: 699
[Serializable]
public class DayEventTime : IScheduledEventTime
{
	// Token: 0x06001463 RID: 5219 RVA: 0x000C6B32 File Offset: 0x000C4D32
	public DayEventTime(int week, DayOfWeek weekday)
	{
		this.week = week;
		this.weekday = weekday;
	}

	// Token: 0x1700036D RID: 877
	// (get) Token: 0x06001464 RID: 5220 RVA: 0x000C6B48 File Offset: 0x000C4D48
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Day;
		}
	}

	// Token: 0x06001465 RID: 5221 RVA: 0x000C6B4B File Offset: 0x000C4D4B
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week && currentTime.Weekday == this.weekday;
	}

	// Token: 0x06001466 RID: 5222 RVA: 0x000C6B6B File Offset: 0x000C4D6B
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday < this.weekday;
		}
		return currentTime.Week < this.week;
	}

	// Token: 0x06001467 RID: 5223 RVA: 0x000C6B98 File Offset: 0x000C4D98
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday > this.weekday;
		}
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F61 RID: 8033
	[SerializeField]
	private int week;

	// Token: 0x04001F62 RID: 8034
	[SerializeField]
	private DayOfWeek weekday;
}
