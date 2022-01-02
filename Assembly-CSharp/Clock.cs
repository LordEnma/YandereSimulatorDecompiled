using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000492 RID: 1170
[Serializable]
public class Clock
{
	// Token: 0x06001F18 RID: 7960 RVA: 0x001B6DAC File Offset: 0x001B4FAC
	public Clock(int hours, int minutes, int seconds, float currentSecond)
	{
		this.hours = hours;
		this.minutes = minutes;
		this.seconds = seconds;
		this.currentSecond = currentSecond;
	}

	// Token: 0x06001F19 RID: 7961 RVA: 0x001B6DD1 File Offset: 0x001B4FD1
	public Clock(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0f)
	{
	}

	// Token: 0x06001F1A RID: 7962 RVA: 0x001B6DE1 File Offset: 0x001B4FE1
	public Clock() : this(0, 0, 0, 0f)
	{
	}

	// Token: 0x170004AF RID: 1199
	// (get) Token: 0x06001F1B RID: 7963 RVA: 0x001B6DF1 File Offset: 0x001B4FF1
	public int Hours24
	{
		get
		{
			return this.hours;
		}
	}

	// Token: 0x170004B0 RID: 1200
	// (get) Token: 0x06001F1C RID: 7964 RVA: 0x001B6DFC File Offset: 0x001B4FFC
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

	// Token: 0x170004B1 RID: 1201
	// (get) Token: 0x06001F1D RID: 7965 RVA: 0x001B6E1A File Offset: 0x001B501A
	public int Minutes
	{
		get
		{
			return this.minutes;
		}
	}

	// Token: 0x170004B2 RID: 1202
	// (get) Token: 0x06001F1E RID: 7966 RVA: 0x001B6E22 File Offset: 0x001B5022
	public int Seconds
	{
		get
		{
			return this.seconds;
		}
	}

	// Token: 0x170004B3 RID: 1203
	// (get) Token: 0x06001F1F RID: 7967 RVA: 0x001B6E2A File Offset: 0x001B502A
	public float CurrentSecond
	{
		get
		{
			return this.currentSecond;
		}
	}

	// Token: 0x170004B4 RID: 1204
	// (get) Token: 0x06001F20 RID: 7968 RVA: 0x001B6E32 File Offset: 0x001B5032
	public int TotalSeconds
	{
		get
		{
			return this.hours * 3600 + this.minutes * 60 + this.seconds;
		}
	}

	// Token: 0x170004B5 RID: 1205
	// (get) Token: 0x06001F21 RID: 7969 RVA: 0x001B6E51 File Offset: 0x001B5051
	public float PreciseTotalSeconds
	{
		get
		{
			return (float)this.TotalSeconds + this.currentSecond;
		}
	}

	// Token: 0x170004B6 RID: 1206
	// (get) Token: 0x06001F22 RID: 7970 RVA: 0x001B6E61 File Offset: 0x001B5061
	public bool IsAM
	{
		get
		{
			return this.hours < 12;
		}
	}

	// Token: 0x170004B7 RID: 1207
	// (get) Token: 0x06001F23 RID: 7971 RVA: 0x001B6E70 File Offset: 0x001B5070
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

	// Token: 0x170004B8 RID: 1208
	// (get) Token: 0x06001F24 RID: 7972 RVA: 0x001B6ED0 File Offset: 0x001B50D0
	public string TimeOfDayString
	{
		get
		{
			return Clock.TimeOfDayStrings[this.TimeOfDay];
		}
	}

	// Token: 0x06001F25 RID: 7973 RVA: 0x001B6EE2 File Offset: 0x001B50E2
	public bool IsBefore(Clock clock)
	{
		return this.TotalSeconds < clock.TotalSeconds;
	}

	// Token: 0x06001F26 RID: 7974 RVA: 0x001B6EF2 File Offset: 0x001B50F2
	public bool IsAfter(Clock clock)
	{
		return this.TotalSeconds > clock.TotalSeconds;
	}

	// Token: 0x06001F27 RID: 7975 RVA: 0x001B6F02 File Offset: 0x001B5102
	public void IncrementHour()
	{
		this.hours++;
		if (this.hours == 24)
		{
			this.hours = 0;
		}
	}

	// Token: 0x06001F28 RID: 7976 RVA: 0x001B6F23 File Offset: 0x001B5123
	public void IncrementMinute()
	{
		this.minutes++;
		if (this.minutes == 60)
		{
			this.IncrementHour();
			this.minutes = 0;
		}
	}

	// Token: 0x06001F29 RID: 7977 RVA: 0x001B6F4A File Offset: 0x001B514A
	public void IncrementSecond()
	{
		this.seconds++;
		if (this.seconds == 60)
		{
			this.IncrementMinute();
			this.seconds = 0;
		}
	}

	// Token: 0x06001F2A RID: 7978 RVA: 0x001B6F71 File Offset: 0x001B5171
	public void Tick(float dt)
	{
		this.currentSecond += dt;
		while (this.currentSecond >= 1f)
		{
			this.IncrementSecond();
			this.currentSecond -= 1f;
		}
	}

	// Token: 0x0400413C RID: 16700
	[SerializeField]
	private int hours;

	// Token: 0x0400413D RID: 16701
	[SerializeField]
	private int minutes;

	// Token: 0x0400413E RID: 16702
	[SerializeField]
	private int seconds;

	// Token: 0x0400413F RID: 16703
	[SerializeField]
	private float currentSecond;

	// Token: 0x04004140 RID: 16704
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
