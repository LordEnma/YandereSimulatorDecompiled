using System;
using UnityEngine;

// Token: 0x020002BE RID: 702
[Serializable]
public class WeekEventTime : IScheduledEventTime
{
	// Token: 0x06001476 RID: 5238 RVA: 0x000C759D File Offset: 0x000C579D
	public WeekEventTime(int week)
	{
		this.week = week;
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x06001477 RID: 5239 RVA: 0x000C75AC File Offset: 0x000C57AC
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Week;
		}
	}

	// Token: 0x06001478 RID: 5240 RVA: 0x000C75AF File Offset: 0x000C57AF
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week;
	}

	// Token: 0x06001479 RID: 5241 RVA: 0x000C75BF File Offset: 0x000C57BF
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		return currentTime.Week < this.week;
	}

	// Token: 0x0600147A RID: 5242 RVA: 0x000C75CF File Offset: 0x000C57CF
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F77 RID: 8055
	[SerializeField]
	private int week;
}
