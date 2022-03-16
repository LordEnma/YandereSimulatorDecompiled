using System;

// Token: 0x020002BA RID: 698
public interface IScheduledEventTime
{
	// Token: 0x1700036A RID: 874
	// (get) Token: 0x06001466 RID: 5222
	ScheduledEventTimeType ScheduleType { get; }

	// Token: 0x06001467 RID: 5223
	bool OccurringNow(DateAndTime currentTime);

	// Token: 0x06001468 RID: 5224
	bool OccursInTheFuture(DateAndTime currentTime);

	// Token: 0x06001469 RID: 5225
	bool OccurredInThePast(DateAndTime currentTime);
}
