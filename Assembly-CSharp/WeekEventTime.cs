using System;
using UnityEngine;

// Token: 0x020002BC RID: 700
[Serializable]
public class WeekEventTime : IScheduledEventTime
{
	// Token: 0x06001468 RID: 5224 RVA: 0x000C6BC5 File Offset: 0x000C4DC5
	public WeekEventTime(int week)
	{
		this.week = week;
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x06001469 RID: 5225 RVA: 0x000C6BD4 File Offset: 0x000C4DD4
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Week;
		}
	}

	// Token: 0x0600146A RID: 5226 RVA: 0x000C6BD7 File Offset: 0x000C4DD7
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week;
	}

	// Token: 0x0600146B RID: 5227 RVA: 0x000C6BE7 File Offset: 0x000C4DE7
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		return currentTime.Week < this.week;
	}

	// Token: 0x0600146C RID: 5228 RVA: 0x000C6BF7 File Offset: 0x000C4DF7
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F63 RID: 8035
	[SerializeField]
	private int week;
}
