using System;

// Token: 0x020002BB RID: 699
public interface IScheduledEventTime
{
	// Token: 0x1700036A RID: 874
	// (get) Token: 0x06001471 RID: 5233
	ScheduledEventTimeType ScheduleType { get; }

	// Token: 0x06001472 RID: 5234
	bool OccurringNow(DateAndTime currentTime);

	// Token: 0x06001473 RID: 5235
	bool OccursInTheFuture(DateAndTime currentTime);

	// Token: 0x06001474 RID: 5236
	bool OccurredInThePast(DateAndTime currentTime);
}
