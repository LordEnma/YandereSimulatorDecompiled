using System;
using UnityEngine;

[Serializable]
public class DayEventTime : IScheduledEventTime
{
	[SerializeField]
	private int week;

	[SerializeField]
	private DayOfWeek weekday;

	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Day;
		}
	}

	public DayEventTime(int week, DayOfWeek weekday)
	{
		this.week = week;
		this.weekday = weekday;
	}

	public bool OccurringNow(DateAndTime currentTime)
	{
		if (currentTime.Week == week)
		{
			return currentTime.Weekday == weekday;
		}
		return false;
	}

	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		if (currentTime.Week == week)
		{
			return currentTime.Weekday < weekday;
		}
		return currentTime.Week < week;
	}

	public bool OccurredInThePast(DateAndTime currentTime)
	{
		if (currentTime.Week == week)
		{
			return currentTime.Weekday > weekday;
		}
		return currentTime.Week > week;
	}
}
