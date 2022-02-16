using System;
using UnityEngine;

// Token: 0x020002BC RID: 700
[Serializable]
public class DayEventTime : IScheduledEventTime
{
	// Token: 0x06001468 RID: 5224 RVA: 0x000C6C26 File Offset: 0x000C4E26
	public DayEventTime(int week, DayOfWeek weekday)
	{
		this.week = week;
		this.weekday = weekday;
	}

	// Token: 0x1700036D RID: 877
	// (get) Token: 0x06001469 RID: 5225 RVA: 0x000C6C3C File Offset: 0x000C4E3C
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Day;
		}
	}

	// Token: 0x0600146A RID: 5226 RVA: 0x000C6C3F File Offset: 0x000C4E3F
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week && currentTime.Weekday == this.weekday;
	}

	// Token: 0x0600146B RID: 5227 RVA: 0x000C6C5F File Offset: 0x000C4E5F
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday < this.weekday;
		}
		return currentTime.Week < this.week;
	}

	// Token: 0x0600146C RID: 5228 RVA: 0x000C6C8C File Offset: 0x000C4E8C
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday > this.weekday;
		}
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F66 RID: 8038
	[SerializeField]
	private int week;

	// Token: 0x04001F67 RID: 8039
	[SerializeField]
	private DayOfWeek weekday;
}
