using System;

// Token: 0x020002B8 RID: 696
public interface IScheduledEventTime
{
	// Token: 0x1700036A RID: 874
	// (get) Token: 0x06001454 RID: 5204
	ScheduledEventTimeType ScheduleType { get; }

	// Token: 0x06001455 RID: 5205
	bool OccurringNow(DateAndTime currentTime);

	// Token: 0x06001456 RID: 5206
	bool OccursInTheFuture(DateAndTime currentTime);

	// Token: 0x06001457 RID: 5207
	bool OccurredInThePast(DateAndTime currentTime);
}
