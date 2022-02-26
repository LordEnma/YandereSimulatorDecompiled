using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000497 RID: 1175
[Serializable]
public class Clock
{
	// Token: 0x06001F3C RID: 7996 RVA: 0x001B9DF0 File Offset: 0x001B7FF0
	public Clock(int hours, int minutes, int seconds, float currentSecond)
	{
		this.hours = hours;
		this.minutes = minutes;
		this.seconds = seconds;
		this.currentSecond = currentSecond;
	}

	// Token: 0x06001F3D RID: 7997 RVA: 0x001B9E15 File Offset: 0x001B8015
	public Clock(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0f)
	{
	}

	// Token: 0x06001F3E RID: 7998 RVA: 0x001B9E25 File Offset: 0x001B8025
	public Clock() : this(0, 0, 0, 0f)
	{
	}

	// Token: 0x170004B1 RID: 1201
	// (get) Token: 0x06001F3F RID: 7999 RVA: 0x001B9E35 File Offset: 0x001B8035
	public int Hours24
	{
		get
		{
			return this.hours;
		}
	}

	// Token: 0x170004B2 RID: 1202
	// (get) Token: 0x06001F40 RID: 8000 RVA: 0x001B9E40 File Offset: 0x001B8040
	public int Hours12
	{
		get
		{
			int num = this.hours % 12;
			if (num != 0)
			{
				return num;
			}
			return 12;
		}
	}

	// Token: 0x170004B3 RID: 1203
	// (get) Token: 0x06001F41 RID: 8001 RVA: 0x001B9E5E File Offset: 0x001B805E
	public int Minutes
	{
		get
		{
			return this.minutes;
		}
	}

	// Token: 0x170004B4 RID: 1204
	// (get) Token: 0x06001F42 RID: 8002 RVA: 0x001B9E66 File Offset: 0x001B8066
	public int Seconds
	{
		get
		{
			return this.seconds;
		}
	}

	// Token: 0x170004B5 RID: 1205
	// (get) Token: 0x06001F43 RID: 8003 RVA: 0x001B9E6E File Offset: 0x001B806E
	public float CurrentSecond
	{
		get
		{
			return this.currentSecond;
		}
	}

	// Token: 0x170004B6 RID: 1206
	// (get) Token: 0x06001F44 RID: 8004 RVA: 0x001B9E76 File Offset: 0x001B8076
	public int TotalSeconds
	{
		get
		{
			return this.hours * 3600 + this.minutes * 60 + this.seconds;
		}
	}

	// Token: 0x170004B7 RID: 1207
	// (get) Token: 0x06001F45 RID: 8005 RVA: 0x001B9E95 File Offset: 0x001B8095
	public float PreciseTotalSeconds
	{
		get
		{
			return (float)this.TotalSeconds + this.currentSecond;
		}
	}

	// Token: 0x170004B8 RID: 1208
	// (get) Token: 0x06001F46 RID: 8006 RVA: 0x001B9EA5 File Offset: 0x001B80A5
	public bool IsAM
	{
		get
		{
			return this.hours < 12;
		}
	}

	// Token: 0x170004B9 RID: 1209
	// (get) Token: 0x06001F47 RID: 8007 RVA: 0x001B9EB4 File Offset: 0x001B80B4
	public TimeOfDay TimeOfDay
	{
		get
		{
			if (this.hours < 3)
			{
				return TimeOfDay.Midnight;
			}
			if (this.hours < 6)
			{
				return TimeOfDay.EarlyMorning;
			}
			if (this.hours < 9)
			{
				return TimeOfDay.Morning;
			}
			if (this.hours < 12)
			{
				return TimeOfDay.LateMorning;
			}
			if (this.hours < 15)
			{
				return TimeOfDay.Noon;
			}
			if (this.hours < 18)
			{
				return TimeOfDay.Afternoon;
			}
			if (this.hours < 21)
			{
				return TimeOfDay.Evening;
			}
			return TimeOfDay.Night;
		}
	}

	// Token: 0x170004BA RID: 1210
	// (get) Token: 0x06001F48 RID: 8008 RVA: 0x001B9F14 File Offset: 0x001B8114
	public string TimeOfDayString
	{
		get
		{
			return Clock.TimeOfDayStrings[this.TimeOfDay];
		}
	}

	// Token: 0x06001F49 RID: 8009 RVA: 0x001B9F26 File Offset: 0x001B8126
	public bool IsBefore(Clock clock)
	{
		return this.TotalSeconds < clock.TotalSeconds;
	}

	// Token: 0x06001F4A RID: 8010 RVA: 0x001B9F36 File Offset: 0x001B8136
	public bool IsAfter(Clock clock)
	{
		return this.TotalSeconds > clock.TotalSeconds;
	}

	// Token: 0x06001F4B RID: 8011 RVA: 0x001B9F46 File Offset: 0x001B8146
	public void IncrementHour()
	{
		this.hours++;
		if (this.hours == 24)
		{
			this.hours = 0;
		}
	}

	// Token: 0x06001F4C RID: 8012 RVA: 0x001B9F67 File Offset: 0x001B8167
	public void IncrementMinute()
	{
		this.minutes++;
		if (this.minutes == 60)
		{
			this.IncrementHour();
			this.minutes = 0;
		}
	}

	// Token: 0x06001F4D RID: 8013 RVA: 0x001B9F8E File Offset: 0x001B818E
	public void IncrementSecond()
	{
		this.seconds++;
		if (this.seconds == 60)
		{
			this.IncrementMinute();
			this.seconds = 0;
		}
	}

	// Token: 0x06001F4E RID: 8014 RVA: 0x001B9FB5 File Offset: 0x001B81B5
	public void Tick(float dt)
	{
		this.currentSecond += dt;
		while (this.currentSecond >= 1f)
		{
			this.IncrementSecond();
			this.currentSecond -= 1f;
		}
	}

	// Token: 0x04004181 RID: 16769
	[SerializeField]
	private int hours;

	// Token: 0x04004182 RID: 16770
	[SerializeField]
	private int minutes;

	// Token: 0x04004183 RID: 16771
	[SerializeField]
	private int seconds;

	// Token: 0x04004184 RID: 16772
	[SerializeField]
	private float currentSecond;

	// Token: 0x04004185 RID: 16773
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
}
