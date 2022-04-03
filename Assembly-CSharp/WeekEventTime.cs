using System;
using UnityEngine;

// Token: 0x020002BE RID: 702
[Serializable]
public class WeekEventTime : IScheduledEventTime
{
	// Token: 0x0600147A RID: 5242 RVA: 0x000C7C8D File Offset: 0x000C5E8D
	public WeekEventTime(int week)
	{
		this.week = week;
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x0600147B RID: 5243 RVA: 0x000C7C9C File Offset: 0x000C5E9C
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Week;
		}
	}

	// Token: 0x0600147C RID: 5244 RVA: 0x000C7C9F File Offset: 0x000C5E9F
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week;
	}

	// Token: 0x0600147D RID: 5245 RVA: 0x000C7CAF File Offset: 0x000C5EAF
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		return currentTime.Week < this.week;
	}

	// Token: 0x0600147E RID: 5246 RVA: 0x000C7CBF File Offset: 0x000C5EBF
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F93 RID: 8083
	[SerializeField]
	private int week;
}
