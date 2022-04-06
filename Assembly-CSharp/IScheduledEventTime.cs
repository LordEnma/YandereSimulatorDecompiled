using System;

// Token: 0x020002BB RID: 699
public interface IScheduledEventTime
{
	// Token: 0x1700036A RID: 874
	// (get) Token: 0x0600146D RID: 5229
	ScheduledEventTimeType ScheduleType { get; }

	// Token: 0x0600146E RID: 5230
	bool OccurringNow(DateAndTime currentTime);

	// Token: 0x0600146F RID: 5231
	bool OccursInTheFuture(DateAndTime currentTime);

	// Token: 0x06001470 RID: 5232
	bool OccurredInThePast(DateAndTime currentTime);
}
