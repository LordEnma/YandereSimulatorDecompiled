using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200049E RID: 1182
[Serializable]
public class Clock
{
	// Token: 0x06001F69 RID: 8041 RVA: 0x001BE180 File Offset: 0x001BC380
	public Clock(int hours, int minutes, int seconds, float currentSecond)
	{
		this.hours = hours;
		this.minutes = minutes;
		this.seconds = seconds;
		this.currentSecond = currentSecond;
	}

	// Token: 0x06001F6A RID: 8042 RVA: 0x001BE1A5 File Offset: 0x001BC3A5
	public Clock(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0f)
	{
	}

	// Token: 0x06001F6B RID: 8043 RVA: 0x001BE1B5 File Offset: 0x001BC3B5
	public Clock() : this(0, 0, 0, 0f)
	{
	}

	// Token: 0x170004B3 RID: 1203
	// (get) Token: 0x06001F6C RID: 8044 RVA: 0x001BE1C5 File Offset: 0x001BC3C5
	public int Hours24
	{
		get
		{
			return this.hours;
		}
	}

	// Token: 0x170004B4 RID: 1204
	// (get) Token: 0x06001F6D RID: 8045 RVA: 0x001BE1D0 File Offset: 0x001BC3D0
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

	// Token: 0x170004B5 RID: 1205
	// (get) Token: 0x06001F6E RID: 8046 RVA: 0x001BE1EE File Offset: 0x001BC3EE
	public int Minutes
	{
		get
		{
			return this.minutes;
		}
	}

	// Token: 0x170004B6 RID: 1206
	// (get) Token: 0x06001F6F RID: 8047 RVA: 0x001BE1F6 File Offset: 0x001BC3F6
	public int Seconds
	{
		get
		{
			return this.seconds;
		}
	}

	// Token: 0x170004B7 RID: 1207
	// (get) Token: 0x06001F70 RID: 8048 RVA: 0x001BE1FE File Offset: 0x001BC3FE
	public float CurrentSecond
	{
		get
		{
			return this.currentSecond;
		}
	}

	// Token: 0x170004B8 RID: 1208
	// (get) Token: 0x06001F71 RID: 8049 RVA: 0x001BE206 File Offset: 0x001BC406
	public int TotalSeconds
	{
		get
		{
			return this.hours * 3600 + this.minutes * 60 + this.seconds;
		}
	}

	// Token: 0x170004B9 RID: 1209
	// (get) Token: 0x06001F72 RID: 8050 RVA: 0x001BE225 File Offset: 0x001BC425
	public float PreciseTotalSeconds
	{
		get
		{
			return (float)this.TotalSeconds + this.currentSecond;
		}
	}

	// Token: 0x170004BA RID: 1210
	// (get) Token: 0x06001F73 RID: 8051 RVA: 0x001BE235 File Offset: 0x001BC435
	public bool IsAM
	{
		get
		{
			return this.hours < 12;
		}
	}

	// Token: 0x170004BB RID: 1211
	// (get) Token: 0x06001F74 RID: 8052 RVA: 0x001BE244 File Offset: 0x001BC444
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

	// Token: 0x170004BC RID: 1212
	// (get) Token: 0x06001F75 RID: 8053 RVA: 0x001BE2A4 File Offset: 0x001BC4A4
	public string TimeOfDayString
	{
		get
		{
			return Clock.TimeOfDayStrings[this.TimeOfDay];
		}
	}

	// Token: 0x06001F76 RID: 8054 RVA: 0x001BE2B6 File Offset: 0x001BC4B6
	public bool IsBefore(Clock clock)
	{
		return this.TotalSeconds < clock.TotalSeconds;
	}

	// Token: 0x06001F77 RID: 8055 RVA: 0x001BE2C6 File Offset: 0x001BC4C6
	public bool IsAfter(Clock clock)
	{
		return this.TotalSeconds > clock.TotalSeconds;
	}

	// Token: 0x06001F78 RID: 8056 RVA: 0x001BE2D6 File Offset: 0x001BC4D6
	public void IncrementHour()
	{
		this.hours++;
		if (this.hours == 24)
		{
			this.hours = 0;
		}
	}

	// Token: 0x06001F79 RID: 8057 RVA: 0x001BE2F7 File Offset: 0x001BC4F7
	public void IncrementMinute()
	{
		this.minutes++;
		if (this.minutes == 60)
		{
			this.IncrementHour();
			this.minutes = 0;
		}
	}

	// Token: 0x06001F7A RID: 8058 RVA: 0x001BE31E File Offset: 0x001BC51E
	public void IncrementSecond()
	{
		this.seconds++;
		if (this.seconds == 60)
		{
			this.IncrementMinute();
			this.seconds = 0;
		}
	}

	// Token: 0x06001F7B RID: 8059 RVA: 0x001BE345 File Offset: 0x001BC545
	public void Tick(float dt)
	{
		this.currentSecond += dt;
		while (this.currentSecond >= 1f)
		{
			this.IncrementSecond();
			this.currentSecond -= 1f;
		}
	}

	// Token: 0x04004223 RID: 16931
	[SerializeField]
	private int hours;

	// Token: 0x04004224 RID: 16932
	[SerializeField]
	private int minutes;

	// Token: 0x04004225 RID: 16933
	[SerializeField]
	private int seconds;

	// Token: 0x04004226 RID: 16934
	[SerializeField]
	private float currentSecond;

	// Token: 0x04004227 RID: 16935
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
