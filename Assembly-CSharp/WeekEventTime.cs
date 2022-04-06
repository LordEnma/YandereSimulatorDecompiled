using System;
using UnityEngine;

// Token: 0x020002BF RID: 703
[Serializable]
public class WeekEventTime : IScheduledEventTime
{
	// Token: 0x06001480 RID: 5248 RVA: 0x000C7D95 File Offset: 0x000C5F95
	public WeekEventTime(int week)
	{
		this.week = week;
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x06001481 RID: 5249 RVA: 0x000C7DA4 File Offset: 0x000C5FA4
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Week;
		}
	}

	// Token: 0x06001482 RID: 5250 RVA: 0x000C7DA7 File Offset: 0x000C5FA7
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week;
	}

	// Token: 0x06001483 RID: 5251 RVA: 0x000C7DB7 File Offset: 0x000C5FB7
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		return currentTime.Week < this.week;
	}

	// Token: 0x06001484 RID: 5252 RVA: 0x000C7DC7 File Offset: 0x000C5FC7
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F95 RID: 8085
	[SerializeField]
	private int week;
}
