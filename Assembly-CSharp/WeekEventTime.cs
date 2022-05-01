using System;
using UnityEngine;

// Token: 0x020002BF RID: 703
[Serializable]
public class WeekEventTime : IScheduledEventTime
{
	// Token: 0x06001484 RID: 5252 RVA: 0x000C8409 File Offset: 0x000C6609
	public WeekEventTime(int week)
	{
		this.week = week;
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x06001485 RID: 5253 RVA: 0x000C8418 File Offset: 0x000C6618
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Week;
		}
	}

	// Token: 0x06001486 RID: 5254 RVA: 0x000C841B File Offset: 0x000C661B
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week;
	}

	// Token: 0x06001487 RID: 5255 RVA: 0x000C842B File Offset: 0x000C662B
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		return currentTime.Week < this.week;
	}

	// Token: 0x06001488 RID: 5256 RVA: 0x000C843B File Offset: 0x000C663B
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		return currentTime.Week > this.week;
	}

	// Token: 0x04001FA0 RID: 8096
	[SerializeField]
	private int week;
}
