using System;
using UnityEngine;

// Token: 0x020002BC RID: 700
[Serializable]
public class WeekEventTime : IScheduledEventTime
{
	// Token: 0x06001468 RID: 5224 RVA: 0x000C6B35 File Offset: 0x000C4D35
	public WeekEventTime(int week)
	{
		this.week = week;
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x06001469 RID: 5225 RVA: 0x000C6B44 File Offset: 0x000C4D44
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Week;
		}
	}

	// Token: 0x0600146A RID: 5226 RVA: 0x000C6B47 File Offset: 0x000C4D47
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week;
	}

	// Token: 0x0600146B RID: 5227 RVA: 0x000C6B57 File Offset: 0x000C4D57
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		return currentTime.Week < this.week;
	}

	// Token: 0x0600146C RID: 5228 RVA: 0x000C6B67 File Offset: 0x000C4D67
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F61 RID: 8033
	[SerializeField]
	private int week;
}
