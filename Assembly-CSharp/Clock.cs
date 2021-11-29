using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000491 RID: 1169
[Serializable]
public class Clock
{
	// Token: 0x06001F0B RID: 7947 RVA: 0x001B5B18 File Offset: 0x001B3D18
	public Clock(int hours, int minutes, int seconds, float currentSecond)
	{
		this.hours = hours;
		this.minutes = minutes;
		this.seconds = seconds;
		this.currentSecond = currentSecond;
	}

	// Token: 0x06001F0C RID: 7948 RVA: 0x001B5B3D File Offset: 0x001B3D3D
	public Clock(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0f)
	{
	}

	// Token: 0x06001F0D RID: 7949 RVA: 0x001B5B4D File Offset: 0x001B3D4D
	public Clock() : this(0, 0, 0, 0f)
	{
	}

	// Token: 0x170004AE RID: 1198
	// (get) Token: 0x06001F0E RID: 7950 RVA: 0x001B5B5D File Offset: 0x001B3D5D
	public int Hours24
	{
		get
		{
			return this.hours;
		}
	}

	// Token: 0x170004AF RID: 1199
	// (get) Token: 0x06001F0F RID: 7951 RVA: 0x001B5B68 File Offset: 0x001B3D68
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
	// (get) Token: 0x06001F10 RID: 7952 RVA: 0x001B5B86 File Offset: 0x001B3D86
	public int Minutes
	{
		get
		{
			return this.minutes;
		}
	}

	// Token: 0x170004B1 RID: 1201
	// (get) Token: 0x06001F11 RID: 7953 RVA: 0x001B5B8E File Offset: 0x001B3D8E
	public int Seconds
	{
		get
		{
			return this.seconds;
		}
	}

	// Token: 0x170004B2 RID: 1202
	// (get) Token: 0x06001F12 RID: 7954 RVA: 0x001B5B96 File Offset: 0x001B3D96
	public float CurrentSecond
	{
		get
		{
			return this.currentSecond;
		}
	}

	// Token: 0x170004B3 RID: 1203
	// (get) Token: 0x06001F13 RID: 7955 RVA: 0x001B5B9E File Offset: 0x001B3D9E
	public int TotalSeconds
	{
		get
		{
			return this.hours * 3600 + this.minutes * 60 + this.seconds;
		}
	}

	// Token: 0x170004B4 RID: 1204
	// (get) Token: 0x06001F14 RID: 7956 RVA: 0x001B5BBD File Offset: 0x001B3DBD
	public float PreciseTotalSeconds
	{
		get
		{
			return (float)this.TotalSeconds + this.currentSecond;
		}
	}

	// Token: 0x170004B5 RID: 1205
	// (get) Token: 0x06001F15 RID: 7957 RVA: 0x001B5BCD File Offset: 0x001B3DCD
	public bool IsAM
	{
		get
		{
			return this.hours < 12;
		}
	}

	// Token: 0x170004B6 RID: 1206
	// (get) Token: 0x06001F16 RID: 7958 RVA: 0x001B5BDC File Offset: 0x001B3DDC
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
	// (get) Token: 0x06001F17 RID: 7959 RVA: 0x001B5C3C File Offset: 0x001B3E3C
	public string TimeOfDayString
	{
		get
		{
			return Clock.TimeOfDayStrings[this.TimeOfDay];
		}
	}

	// Token: 0x06001F18 RID: 7960 RVA: 0x001B5C4E File Offset: 0x001B3E4E
	public bool IsBefore(Clock clock)
	{
		return this.TotalSeconds < clock.TotalSeconds;
	}

	// Token: 0x06001F19 RID: 7961 RVA: 0x001B5C5E File Offset: 0x001B3E5E
	public bool IsAfter(Clock clock)
	{
		return this.TotalSeconds > clock.TotalSeconds;
	}

	// Token: 0x06001F1A RID: 7962 RVA: 0x001B5C6E File Offset: 0x001B3E6E
	public void IncrementHour()
	{
		this.hours++;
		if (this.hours == 24)
		{
			this.hours = 0;
		}
	}

	// Token: 0x06001F1B RID: 7963 RVA: 0x001B5C8F File Offset: 0x001B3E8F
	public void IncrementMinute()
	{
		this.minutes++;
		if (this.minutes == 60)
		{
			this.IncrementHour();
			this.minutes = 0;
		}
	}

	// Token: 0x06001F1C RID: 7964 RVA: 0x001B5CB6 File Offset: 0x001B3EB6
	public void IncrementSecond()
	{
		this.seconds++;
		if (this.seconds == 60)
		{
			this.IncrementMinute();
			this.seconds = 0;
		}
	}

	// Token: 0x06001F1D RID: 7965 RVA: 0x001B5CDD File Offset: 0x001B3EDD
	public void Tick(float dt)
	{
		this.currentSecond += dt;
		while (this.currentSecond >= 1f)
		{
			this.IncrementSecond();
			this.currentSecond -= 1f;
		}
	}

	// Token: 0x04004105 RID: 16645
	[SerializeField]
	private int hours;

	// Token: 0x04004106 RID: 16646
	[SerializeField]
	private int minutes;

	// Token: 0x04004107 RID: 16647
	[SerializeField]
	private int seconds;

	// Token: 0x04004108 RID: 16648
	[SerializeField]
	private float currentSecond;

	// Token: 0x04004109 RID: 16649
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
