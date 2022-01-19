using System;
using UnityEngine;

// Token: 0x020002BC RID: 700
[Serializable]
public class WeekEventTime : IScheduledEventTime
{
	// Token: 0x06001467 RID: 5223 RVA: 0x000C687D File Offset: 0x000C4A7D
	public WeekEventTime(int week)
	{
		this.week = week;
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x06001468 RID: 5224 RVA: 0x000C688C File Offset: 0x000C4A8C
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Week;
		}
	}

	// Token: 0x06001469 RID: 5225 RVA: 0x000C688F File Offset: 0x000C4A8F
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week;
	}

	// Token: 0x0600146A RID: 5226 RVA: 0x000C689F File Offset: 0x000C4A9F
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		return currentTime.Week < this.week;
	}

	// Token: 0x0600146B RID: 5227 RVA: 0x000C68AF File Offset: 0x000C4AAF
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F5C RID: 8028
	[SerializeField]
	private int week;
}
