using System;

// Token: 0x020002B9 RID: 697
public interface IScheduledEventTime
{
	// Token: 0x1700036A RID: 874
	// (get) Token: 0x0600145A RID: 5210
	ScheduledEventTimeType ScheduleType { get; }

	// Token: 0x0600145B RID: 5211
	bool OccurringNow(DateAndTime currentTime);

	// Token: 0x0600145C RID: 5212
	bool OccursInTheFuture(DateAndTime currentTime);

	// Token: 0x0600145D RID: 5213
	bool OccurredInThePast(DateAndTime currentTime);
}
