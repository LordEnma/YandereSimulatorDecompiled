public interface IScheduledEventTime
{
	ScheduledEventTimeType ScheduleType { get; }

	bool OccurringNow(DateAndTime currentTime);

	bool OccursInTheFuture(DateAndTime currentTime);

	bool OccurredInThePast(DateAndTime currentTime);
}
