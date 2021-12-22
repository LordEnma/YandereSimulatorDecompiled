using System;

// Token: 0x020002B7 RID: 695
public interface IScheduledEventTime
{
	// Token: 0x1700036A RID: 874
	// (get) Token: 0x06001450 RID: 5200
	ScheduledEventTimeType ScheduleType { get; }

	// Token: 0x06001451 RID: 5201
	bool OccurringNow(DateAndTime currentTime);

	// Token: 0x06001452 RID: 5202
	bool OccursInTheFuture(DateAndTime currentTime);

	// Token: 0x06001453 RID: 5203
	bool OccurredInThePast(DateAndTime currentTime);
}
