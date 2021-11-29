using System;
using UnityEngine;

// Token: 0x020002B9 RID: 697
[Serializable]
public class DayEventTime : IScheduledEventTime
{
	// Token: 0x06001457 RID: 5207 RVA: 0x000C5B0E File Offset: 0x000C3D0E
	public DayEventTime(int week, DayOfWeek weekday)
	{
		this.week = week;
		this.weekday = weekday;
	}

	// Token: 0x1700036D RID: 877
	// (get) Token: 0x06001458 RID: 5208 RVA: 0x000C5B24 File Offset: 0x000C3D24
	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Day;
		}
	}

	// Token: 0x06001459 RID: 5209 RVA: 0x000C5B27 File Offset: 0x000C3D27
	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week && currentTime.Weekday == this.weekday;
	}

	// Token: 0x0600145A RID: 5210 RVA: 0x000C5B47 File Offset: 0x000C3D47
	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday < this.weekday;
		}
		return currentTime.Week < this.week;
	}

	// Token: 0x0600145B RID: 5211 RVA: 0x000C5B74 File Offset: 0x000C3D74
	public bool OccurredInThePast(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday > this.weekday;
		}
		return currentTime.Week > this.week;
	}

	// Token: 0x04001F33 RID: 7987
	[SerializeField]
	private int week;

	// Token: 0x04001F34 RID: 7988
	[SerializeField]
	private DayOfWeek weekday;
}
