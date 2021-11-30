using System;

// Token: 0x020002B6 RID: 694
public interface IScheduledEventTime
{
	// Token: 0x1700036A RID: 874
	// (get) Token: 0x06001449 RID: 5193
	ScheduledEventTimeType ScheduleType { get; }

	// Token: 0x0600144A RID: 5194
	bool OccurringNow(DateAndTime currentTime);

	// Token: 0x0600144B RID: 5195
	bool OccursInTheFuture(DateAndTime currentTime);

	// Token: 0x0600144C RID: 5196
	bool OccurredInThePast(DateAndTime currentTime);
}
