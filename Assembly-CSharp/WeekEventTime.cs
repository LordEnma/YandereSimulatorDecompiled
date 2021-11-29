using System;
using UnityEngine;

// Token: 0x020002BA RID: 698
[Serializable]
public class WeekEventTime : IScheduledEventTime
{
	// Token: 0x0600145C RID: 5212 RVA: 0x000C5BA1 File Offset: 0x000C3DA1
	public WeekEventTime(int week)
	{
		this.week = week;
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x0600145D RID: 5213 RVA: 0x000C5BB0 File Offset: 0x000C3DB0
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Week;
		}
	}

	// Token: 0x0600145E RID: 5214 RVA: 0x000C5BB3 File Offset: 0x000C3DB3
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week;
	}

	// Token: 0x0600145F RID: 5215 RVA: 0x000C5BC3 File Offset: 0x000C3DC3
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		return currentTime.Week < this.week;
	}

	// Token: 0x06001460 RID: 5216 RVA: 0x000C5BD3 File Offset: 0x000C3DD3
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F35 RID: 7989
	[SerializeField]
	private int week;
}
