using System;
using UnityEngine;

// Token: 0x020002BC RID: 700
[Serializable]
public class WeekEventTime : IScheduledEventTime
{
	// Token: 0x06001468 RID: 5224 RVA: 0x000C6A81 File Offset: 0x000C4C81
	public WeekEventTime(int week)
	{
		this.week = week;
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x06001469 RID: 5225 RVA: 0x000C6A90 File Offset: 0x000C4C90
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Week;
		}
	}

	// Token: 0x0600146A RID: 5226 RVA: 0x000C6A93 File Offset: 0x000C4C93
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week;
	}

	// Token: 0x0600146B RID: 5227 RVA: 0x000C6AA3 File Offset: 0x000C4CA3
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		return currentTime.Week < this.week;
	}

	// Token: 0x0600146C RID: 5228 RVA: 0x000C6AB3 File Offset: 0x000C4CB3
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F60 RID: 8032
	[SerializeField]
	private int week;
}
