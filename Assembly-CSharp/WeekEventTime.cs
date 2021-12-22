using System;
using UnityEngine;

// Token: 0x020002BB RID: 699
[Serializable]
public class WeekEventTime : IScheduledEventTime
{
	// Token: 0x06001463 RID: 5219 RVA: 0x000C633D File Offset: 0x000C453D
	public WeekEventTime(int week)
	{
		this.week = week;
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x06001464 RID: 5220 RVA: 0x000C634C File Offset: 0x000C454C
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Week;
		}
	}

	// Token: 0x06001465 RID: 5221 RVA: 0x000C634F File Offset: 0x000C454F
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week;
	}

	// Token: 0x06001466 RID: 5222 RVA: 0x000C635F File Offset: 0x000C455F
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		return currentTime.Week < this.week;
	}

	// Token: 0x06001467 RID: 5223 RVA: 0x000C636F File Offset: 0x000C456F
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F55 RID: 8021
	[SerializeField]
	private int week;
}
