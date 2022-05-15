using System;

// Token: 0x020002BC RID: 700
public interface IScheduledEventTime
{
	// Token: 0x1700036A RID: 874
	// (get) Token: 0x06001473 RID: 5235
	ScheduledEventTimeType ScheduleType { get; }

	// Token: 0x06001474 RID: 5236
	bool OccurringNow(DateAndTime currentTime);

	// Token: 0x06001475 RID: 5237
	bool OccursInTheFuture(DateAndTime currentTime);

	// Token: 0x06001476 RID: 5238
	bool OccurredInThePast(DateAndTime currentTime);
}
