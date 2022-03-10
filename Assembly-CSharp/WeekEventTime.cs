using System;
using UnityEngine;

// Token: 0x020002BE RID: 702
[Serializable]
public class WeekEventTime : IScheduledEventTime
{
	// Token: 0x06001476 RID: 5238 RVA: 0x000C76E9 File Offset: 0x000C58E9
	public WeekEventTime(int week)
	{
		this.week = week;
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x06001477 RID: 5239 RVA: 0x000C76F8 File Offset: 0x000C58F8
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Week;
		}
	}

	// Token: 0x06001478 RID: 5240 RVA: 0x000C76FB File Offset: 0x000C58FB
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week;
	}

	// Token: 0x06001479 RID: 5241 RVA: 0x000C770B File Offset: 0x000C590B
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		return currentTime.Week < this.week;
	}

	// Token: 0x0600147A RID: 5242 RVA: 0x000C771B File Offset: 0x000C591B
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F80 RID: 8064
	[SerializeField]
	private int week;
}
