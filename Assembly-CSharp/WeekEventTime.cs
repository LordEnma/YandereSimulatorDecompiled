using System;
using UnityEngine;

// Token: 0x020002C0 RID: 704
[Serializable]
public class WeekEventTime : IScheduledEventTime
{
	// Token: 0x06001486 RID: 5254 RVA: 0x000C86C5 File Offset: 0x000C68C5
	public WeekEventTime(int week)
	{
		this.week = week;
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x06001487 RID: 5255 RVA: 0x000C86D4 File Offset: 0x000C68D4
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Week;
		}
	}

	// Token: 0x06001488 RID: 5256 RVA: 0x000C86D7 File Offset: 0x000C68D7
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week;
	}

	// Token: 0x06001489 RID: 5257 RVA: 0x000C86E7 File Offset: 0x000C68E7
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		return currentTime.Week < this.week;
	}

	// Token: 0x0600148A RID: 5258 RVA: 0x000C86F7 File Offset: 0x000C68F7
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		return currentTime.Week > this.week;
	}

	// Token: 0x04001FA7 RID: 8103
	[SerializeField]
	private int week;
}
