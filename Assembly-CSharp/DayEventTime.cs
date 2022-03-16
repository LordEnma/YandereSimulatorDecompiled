using System;
using UnityEngine;

// Token: 0x020002BD RID: 701
[Serializable]
public class DayEventTime : IScheduledEventTime
{
	// Token: 0x06001474 RID: 5236 RVA: 0x000C7AC6 File Offset: 0x000C5CC6
	public DayEventTime(int week, DayOfWeek weekday)
	{
		this.week = week;
		this.weekday = weekday;
	}

	// Token: 0x1700036D RID: 877
	// (get) Token: 0x06001475 RID: 5237 RVA: 0x000C7ADC File Offset: 0x000C5CDC
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Day;
		}
	}

	// Token: 0x06001476 RID: 5238 RVA: 0x000C7ADF File Offset: 0x000C5CDF
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week && currentTime.Weekday == this.weekday;
	}

	// Token: 0x06001477 RID: 5239 RVA: 0x000C7AFF File Offset: 0x000C5CFF
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday < this.weekday;
		}
		return currentTime.Week < this.week;
	}

	// Token: 0x06001478 RID: 5240 RVA: 0x000C7B2C File Offset: 0x000C5D2C
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday > this.weekday;
		}
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F8E RID: 8078
	[SerializeField]
	private int week;

	// Token: 0x04001F8F RID: 8079
	[SerializeField]
	private DayOfWeek weekday;
}
