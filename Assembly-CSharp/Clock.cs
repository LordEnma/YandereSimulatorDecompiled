using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Clock
{
	[SerializeField]
	private int hours;

	[SerializeField]
	private int minutes;

	[SerializeField]
	private int seconds;

	[SerializeField]
	private float currentSecond;

	private static readonly Dictionary<TimeOfDay, string> TimeOfDayStrings = new Dictionary<TimeOfDay, string>
	{
		{
			TimeOfDay.Midnight,
			"Midnight"
		},
		{
			TimeOfDay.EarlyMorning,
			"Early Morning"
		},
		{
			TimeOfDay.Morning,
			"Morning"
		},
		{
			TimeOfDay.LateMorning,
			"Late Morning"
		},
		{
			TimeOfDay.Noon,
			"Noon"
		},
		{
			TimeOfDay.Afternoon,
			"Afternoon"
		},
		{
			TimeOfDay.Evening,
			"Evening"
		},
		{
			TimeOfDay.Night,
			"Night"
		}
	};

	public int Hours24
	{
		get
		{
			return hours;
		}
	}

	public int Hours12
	{
		get
		{
			int num = hours % 12;
			if (num != 0)
			{
				return num;
			}
			return 12;
		}
	}

	public int Minutes
	{
		get
		{
			return minutes;
		}
	}

	public int Seconds
	{
		get
		{
			return seconds;
		}
	}

	public float CurrentSecond
	{
		get
		{
			return currentSecond;
		}
	}

	public int TotalSeconds
	{
		get
		{
			return hours * 3600 + minutes * 60 + seconds;
		}
	}

	public float PreciseTotalSeconds
	{
		get
		{
			return (float)TotalSeconds + currentSecond;
		}
	}

	public bool IsAM
	{
		get
		{
			return hours < 12;
		}
	}

	public TimeOfDay TimeOfDay
	{
		get
		{
			if (hours < 3)
			{
				return TimeOfDay.Midnight;
			}
			if (hours < 6)
			{
				return TimeOfDay.EarlyMorning;
			}
			if (hours < 9)
			{
				return TimeOfDay.Morning;
			}
			if (hours < 12)
			{
				return TimeOfDay.LateMorning;
			}
			if (hours < 15)
			{
				return TimeOfDay.Noon;
			}
			if (hours < 18)
			{
				return TimeOfDay.Afternoon;
			}
			if (hours < 21)
			{
				return TimeOfDay.Evening;
			}
			return TimeOfDay.Night;
		}
	}

	public string TimeOfDayString
	{
		get
		{
			return TimeOfDayStrings[TimeOfDay];
		}
	}

	public Clock(int hours, int minutes, int seconds, float currentSecond)
	{
		this.hours = hours;
		this.minutes = minutes;
		this.seconds = seconds;
		this.currentSecond = currentSecond;
	}

	public Clock(int hours, int minutes, int seconds)
		: this(hours, minutes, seconds, 0f)
	{
	}

	public Clock()
		: this(0, 0, 0, 0f)
	{
	}

	public bool IsBefore(Clock clock)
	{
		return TotalSeconds < clock.TotalSeconds;
	}

	public bool IsAfter(Clock clock)
	{
		return TotalSeconds > clock.TotalSeconds;
	}

	public void IncrementHour()
	{
		hours++;
		if (hours == 24)
		{
			hours = 0;
		}
	}

	public void IncrementMinute()
	{
		minutes++;
		if (minutes == 60)
		{
			IncrementHour();
			minutes = 0;
		}
	}

	public void IncrementSecond()
	{
		seconds++;
		if (seconds == 60)
		{
			IncrementMinute();
			seconds = 0;
		}
	}

	public void Tick(float dt)
	{
		currentSecond += dt;
		while (currentSecond >= 1f)
		{
			IncrementSecond();
			currentSecond -= 1f;
		}
	}
}
