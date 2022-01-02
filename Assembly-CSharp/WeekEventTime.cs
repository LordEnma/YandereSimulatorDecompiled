using System;
using UnityEngine;

// Token: 0x020002BB RID: 699
[Serializable]
public class WeekEventTime : IScheduledEventTime
{
	// Token: 0x06001463 RID: 5219 RVA: 0x000C6585 File Offset: 0x000C4785
	public WeekEventTime(int week)
	{
		this.week = week;
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x06001464 RID: 5220 RVA: 0x000C6594 File Offset: 0x000C4794
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Week;
		}
	}

	// Token: 0x06001465 RID: 5221 RVA: 0x000C6597 File Offset: 0x000C4797
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week;
	}

	// Token: 0x06001466 RID: 5222 RVA: 0x000C65A7 File Offset: 0x000C47A7
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		return currentTime.Week < this.week;
	}

	// Token: 0x06001467 RID: 5223 RVA: 0x000C65B7 File Offset: 0x000C47B7
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F58 RID: 8024
	[SerializeField]
	private int week;
}
