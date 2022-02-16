using System;
using UnityEngine;

// Token: 0x020002BD RID: 701
[Serializable]
public class WeekEventTime : IScheduledEventTime
{
	// Token: 0x0600146D RID: 5229 RVA: 0x000C6CB9 File Offset: 0x000C4EB9
	public WeekEventTime(int week)
	{
		this.week = week;
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x0600146E RID: 5230 RVA: 0x000C6CC8 File Offset: 0x000C4EC8
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Week;
		}
	}

	// Token: 0x0600146F RID: 5231 RVA: 0x000C6CCB File Offset: 0x000C4ECB
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week;
	}

	// Token: 0x06001470 RID: 5232 RVA: 0x000C6CDB File Offset: 0x000C4EDB
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		return currentTime.Week < this.week;
	}

	// Token: 0x06001471 RID: 5233 RVA: 0x000C6CEB File Offset: 0x000C4EEB
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F68 RID: 8040
	[SerializeField]
	private int week;
}
