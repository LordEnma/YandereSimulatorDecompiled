using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000492 RID: 1170
[Serializable]
public class Clock
{
	// Token: 0x06001F15 RID: 7957 RVA: 0x001B68D4 File Offset: 0x001B4AD4
	public Clock(int hours, int minutes, int seconds, float currentSecond)
	{
		this.hours = hours;
		this.minutes = minutes;
		this.seconds = seconds;
		this.currentSecond = currentSecond;
	}

	// Token: 0x06001F16 RID: 7958 RVA: 0x001B68F9 File Offset: 0x001B4AF9
	public Clock(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0f)
	{
	}

	// Token: 0x06001F17 RID: 7959 RVA: 0x001B6909 File Offset: 0x001B4B09
	public Clock() : this(0, 0, 0, 0f)
	{
	}

	// Token: 0x170004AE RID: 1198
	// (get) Token: 0x06001F18 RID: 7960 RVA: 0x001B6919 File Offset: 0x001B4B19
	public int Hours24
	{
		get
		{
			return this.hours;
		}
	}

	// Token: 0x170004AF RID: 1199
	// (get) Token: 0x06001F19 RID: 7961 RVA: 0x001B6924 File Offset: 0x001B4B24
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

	// Token: 0x170004B0 RID: 1200
	// (get) Token: 0x06001F1A RID: 7962 RVA: 0x001B6942 File Offset: 0x001B4B42
	public int Minutes
	{
		get
		{
			return this.minutes;
		}
	}

	// Token: 0x170004B1 RID: 1201
	// (get) Token: 0x06001F1B RID: 7963 RVA: 0x001B694A File Offset: 0x001B4B4A
	public int Seconds
	{
		get
		{
			return this.seconds;
		}
	}

	// Token: 0x170004B2 RID: 1202
	// (get) Token: 0x06001F1C RID: 7964 RVA: 0x001B6952 File Offset: 0x001B4B52
	public float CurrentSecond
	{
		get
		{
			return this.currentSecond;
		}
	}

	// Token: 0x170004B3 RID: 1203
	// (get) Token: 0x06001F1D RID: 7965 RVA: 0x001B695A File Offset: 0x001B4B5A
	public int TotalSeconds
	{
		get
		{
			return this.hours * 3600 + this.minutes * 60 + this.seconds;
		}
	}

	// Token: 0x170004B4 RID: 1204
	// (get) Token: 0x06001F1E RID: 7966 RVA: 0x001B6979 File Offset: 0x001B4B79
	public float PreciseTotalSeconds
	{
		get
		{
			return (float)this.TotalSeconds + this.currentSecond;
		}
	}

	// Token: 0x170004B5 RID: 1205
	// (get) Token: 0x06001F1F RID: 7967 RVA: 0x001B6989 File Offset: 0x001B4B89
	public bool IsAM
	{
		get
		{
			return this.hours < 12;
		}
	}

	// Token: 0x170004B6 RID: 1206
	// (get) Token: 0x06001F20 RID: 7968 RVA: 0x001B6998 File Offset: 0x001B4B98
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

	// Token: 0x170004B7 RID: 1207
	// (get) Token: 0x06001F21 RID: 7969 RVA: 0x001B69F8 File Offset: 0x001B4BF8
	public string TimeOfDayString
	{
		get
		{
			return Clock.TimeOfDayStrings[this.TimeOfDay];
		}
	}

	// Token: 0x06001F22 RID: 7970 RVA: 0x001B6A0A File Offset: 0x001B4C0A
	public bool IsBefore(Clock clock)
	{
		return this.TotalSeconds < clock.TotalSeconds;
	}

	// Token: 0x06001F23 RID: 7971 RVA: 0x001B6A1A File Offset: 0x001B4C1A
	public bool IsAfter(Clock clock)
	{
		return this.TotalSeconds > clock.TotalSeconds;
	}

	// Token: 0x06001F24 RID: 7972 RVA: 0x001B6A2A File Offset: 0x001B4C2A
	public void IncrementHour()
	{
		this.hours++;
		if (this.hours == 24)
		{
			this.hours = 0;
		}
	}

	// Token: 0x06001F25 RID: 7973 RVA: 0x001B6A4B File Offset: 0x001B4C4B
	public void IncrementMinute()
	{
		this.minutes++;
		if (this.minutes == 60)
		{
			this.IncrementHour();
			this.minutes = 0;
		}
	}

	// Token: 0x06001F26 RID: 7974 RVA: 0x001B6A72 File Offset: 0x001B4C72
	public void IncrementSecond()
	{
		this.seconds++;
		if (this.seconds == 60)
		{
			this.IncrementMinute();
			this.seconds = 0;
		}
	}

	// Token: 0x06001F27 RID: 7975 RVA: 0x001B6A99 File Offset: 0x001B4C99
	public void Tick(float dt)
	{
		this.currentSecond += dt;
		while (this.currentSecond >= 1f)
		{
			this.IncrementSecond();
			this.currentSecond -= 1f;
		}
	}

	// Token: 0x04004135 RID: 16693
	[SerializeField]
	private int hours;

	// Token: 0x04004136 RID: 16694
	[SerializeField]
	private int minutes;

	// Token: 0x04004137 RID: 16695
	[SerializeField]
	private int seconds;

	// Token: 0x04004138 RID: 16696
	[SerializeField]
	private float currentSecond;

	// Token: 0x04004139 RID: 16697
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
