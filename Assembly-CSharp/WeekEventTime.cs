using System;
using UnityEngine;

// Token: 0x020002C0 RID: 704
[Serializable]
public class WeekEventTime : IScheduledEventTime
{
	// Token: 0x06001486 RID: 5254 RVA: 0x000C875D File Offset: 0x000C695D
	public WeekEventTime(int week)
	{
		this.week = week;
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x06001487 RID: 5255 RVA: 0x000C876C File Offset: 0x000C696C
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Week;
		}
	}

	// Token: 0x06001488 RID: 5256 RVA: 0x000C876F File Offset: 0x000C696F
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week;
	}

	// Token: 0x06001489 RID: 5257 RVA: 0x000C877F File Offset: 0x000C697F
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		return currentTime.Week < this.week;
	}

	// Token: 0x0600148A RID: 5258 RVA: 0x000C878F File Offset: 0x000C698F
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		return currentTime.Week > this.week;
	}

	// Token: 0x04001FA7 RID: 8103
	[SerializeField]
	private int week;
}
