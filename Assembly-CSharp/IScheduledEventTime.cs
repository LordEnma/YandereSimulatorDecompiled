using System;

// Token: 0x020002BA RID: 698
public interface IScheduledEventTime
{
	// Token: 0x1700036A RID: 874
	// (get) Token: 0x06001463 RID: 5219
	ScheduledEventTimeType ScheduleType { get; }

	// Token: 0x06001464 RID: 5220
	bool OccurringNow(DateAndTime currentTime);

	// Token: 0x06001465 RID: 5221
	bool OccursInTheFuture(DateAndTime currentTime);

	// Token: 0x06001466 RID: 5222
	bool OccurredInThePast(DateAndTime currentTime);
}
