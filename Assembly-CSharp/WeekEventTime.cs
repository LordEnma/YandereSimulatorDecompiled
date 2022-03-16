using System;
using UnityEngine;

// Token: 0x020002BE RID: 702
[Serializable]
public class WeekEventTime : IScheduledEventTime
{
	// Token: 0x06001479 RID: 5241 RVA: 0x000C7B59 File Offset: 0x000C5D59
	public WeekEventTime(int week)
	{
		this.week = week;
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x0600147A RID: 5242 RVA: 0x000C7B68 File Offset: 0x000C5D68
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Week;
		}
	}

	// Token: 0x0600147B RID: 5243 RVA: 0x000C7B6B File Offset: 0x000C5D6B
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week;
	}

	// Token: 0x0600147C RID: 5244 RVA: 0x000C7B7B File Offset: 0x000C5D7B
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		return currentTime.Week < this.week;
	}

	// Token: 0x0600147D RID: 5245 RVA: 0x000C7B8B File Offset: 0x000C5D8B
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F90 RID: 8080
	[SerializeField]
	private int week;
}
