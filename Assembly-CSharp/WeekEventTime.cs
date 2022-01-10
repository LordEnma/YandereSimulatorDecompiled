using System;
using UnityEngine;

// Token: 0x020002BC RID: 700
[Serializable]
public class WeekEventTime : IScheduledEventTime
{
	// Token: 0x06001467 RID: 5223 RVA: 0x000C67A9 File Offset: 0x000C49A9
	public WeekEventTime(int week)
	{
		this.week = week;
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x06001468 RID: 5224 RVA: 0x000C67B8 File Offset: 0x000C49B8
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Week;
		}
	}

	// Token: 0x06001469 RID: 5225 RVA: 0x000C67BB File Offset: 0x000C49BB
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week;
	}

	// Token: 0x0600146A RID: 5226 RVA: 0x000C67CB File Offset: 0x000C49CB
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		return currentTime.Week < this.week;
	}

	// Token: 0x0600146B RID: 5227 RVA: 0x000C67DB File Offset: 0x000C49DB
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F59 RID: 8025
	[SerializeField]
	private int week;
}
