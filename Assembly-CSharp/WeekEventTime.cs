using System;
using UnityEngine;

// Token: 0x020002BF RID: 703
[Serializable]
public class WeekEventTime : IScheduledEventTime
{
	// Token: 0x06001484 RID: 5252 RVA: 0x000C83D5 File Offset: 0x000C65D5
	public WeekEventTime(int week)
	{
		this.week = week;
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x06001485 RID: 5253 RVA: 0x000C83E4 File Offset: 0x000C65E4
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Week;
		}
	}

	// Token: 0x06001486 RID: 5254 RVA: 0x000C83E7 File Offset: 0x000C65E7
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week;
	}

	// Token: 0x06001487 RID: 5255 RVA: 0x000C83F7 File Offset: 0x000C65F7
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		return currentTime.Week < this.week;
	}

	// Token: 0x06001488 RID: 5256 RVA: 0x000C8407 File Offset: 0x000C6607
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		return currentTime.Week > this.week;
	}

	// Token: 0x04001FA0 RID: 8096
	[SerializeField]
	private int week;
}
