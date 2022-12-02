using System;
using UnityEngine;

[Serializable]
public class WeekEventTime : IScheduledEventTime
{
	[SerializeField]
	private int week;

	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Week;
		}
	}

	public WeekEventTime(int week)
	{
		this.week = week;
	}

	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == week;
	}

	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		return currentTime.Week < week;
	}

	public bool OccurredInThePast(DateAndTime currentTime)
	{
		return currentTime.Week > week;
	}
}
