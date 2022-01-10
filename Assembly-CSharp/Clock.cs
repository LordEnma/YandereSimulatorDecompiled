using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000494 RID: 1172
[Serializable]
public class Clock
{
	// Token: 0x06001F23 RID: 7971 RVA: 0x001B772C File Offset: 0x001B592C
	public Clock(int hours, int minutes, int seconds, float currentSecond)
	{
		this.hours = hours;
		this.minutes = minutes;
		this.seconds = seconds;
		this.currentSecond = currentSecond;
	}

	// Token: 0x06001F24 RID: 7972 RVA: 0x001B7751 File Offset: 0x001B5951
	public Clock(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0f)
	{
	}

	// Token: 0x06001F25 RID: 7973 RVA: 0x001B7761 File Offset: 0x001B5961
	public Clock() : this(0, 0, 0, 0f)
	{
	}

	// Token: 0x170004AF RID: 1199
	// (get) Token: 0x06001F26 RID: 7974 RVA: 0x001B7771 File Offset: 0x001B5971
	public int Hours24
	{
		get
		{
			return this.hours;
		}
	}

	// Token: 0x170004B0 RID: 1200
	// (get) Token: 0x06001F27 RID: 7975 RVA: 0x001B777C File Offset: 0x001B597C
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
	// (get) Token: 0x06001F28 RID: 7976 RVA: 0x001B779A File Offset: 0x001B599A
	public int Minutes
	{
		get
		{
			return this.minutes;
		}
	}

	// Token: 0x170004B2 RID: 1202
	// (get) Token: 0x06001F29 RID: 7977 RVA: 0x001B77A2 File Offset: 0x001B59A2
	public int Seconds
	{
		get
		{
			return this.seconds;
		}
	}

	// Token: 0x170004B3 RID: 1203
	// (get) Token: 0x06001F2A RID: 7978 RVA: 0x001B77AA File Offset: 0x001B59AA
	public float CurrentSecond
	{
		get
		{
			return this.currentSecond;
		}
	}

	// Token: 0x170004B4 RID: 1204
	// (get) Token: 0x06001F2B RID: 7979 RVA: 0x001B77B2 File Offset: 0x001B59B2
	public int TotalSeconds
	{
		get
		{
			return this.hours * 3600 + this.minutes * 60 + this.seconds;
		}
	}

	// Token: 0x170004B5 RID: 1205
	// (get) Token: 0x06001F2C RID: 7980 RVA: 0x001B77D1 File Offset: 0x001B59D1
	public float PreciseTotalSeconds
	{
		get
		{
			return (float)this.TotalSeconds + this.currentSecond;
		}
	}

	// Token: 0x170004B6 RID: 1206
	// (get) Token: 0x06001F2D RID: 7981 RVA: 0x001B77E1 File Offset: 0x001B59E1
	public bool IsAM
	{
		get
		{
			return this.hours < 12;
		}
	}

	// Token: 0x170004B7 RID: 1207
	// (get) Token: 0x06001F2E RID: 7982 RVA: 0x001B77F0 File Offset: 0x001B59F0
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
	// (get) Token: 0x06001F2F RID: 7983 RVA: 0x001B7850 File Offset: 0x001B5A50
	public string TimeOfDayString
	{
		get
		{
			return Clock.TimeOfDayStrings[this.TimeOfDay];
		}
	}

	// Token: 0x06001F30 RID: 7984 RVA: 0x001B7862 File Offset: 0x001B5A62
	public bool IsBefore(Clock clock)
	{
		return this.TotalSeconds < clock.TotalSeconds;
	}

	// Token: 0x06001F31 RID: 7985 RVA: 0x001B7872 File Offset: 0x001B5A72
	public bool IsAfter(Clock clock)
	{
		return this.TotalSeconds > clock.TotalSeconds;
	}

	// Token: 0x06001F32 RID: 7986 RVA: 0x001B7882 File Offset: 0x001B5A82
	public void IncrementHour()
	{
		this.hours++;
		if (this.hours == 24)
		{
			this.hours = 0;
		}
	}

	// Token: 0x06001F33 RID: 7987 RVA: 0x001B78A3 File Offset: 0x001B5AA3
	public void IncrementMinute()
	{
		this.minutes++;
		if (this.minutes == 60)
		{
			this.IncrementHour();
			this.minutes = 0;
		}
	}

	// Token: 0x06001F34 RID: 7988 RVA: 0x001B78CA File Offset: 0x001B5ACA
	public void IncrementSecond()
	{
		this.seconds++;
		if (this.seconds == 60)
		{
			this.IncrementMinute();
			this.seconds = 0;
		}
	}

	// Token: 0x06001F35 RID: 7989 RVA: 0x001B78F1 File Offset: 0x001B5AF1
	public void Tick(float dt)
	{
		this.currentSecond += dt;
		while (this.currentSecond >= 1f)
		{
			this.IncrementSecond();
			this.currentSecond -= 1f;
		}
	}

	// Token: 0x04004150 RID: 16720
	[SerializeField]
	private int hours;

	// Token: 0x04004151 RID: 16721
	[SerializeField]
	private int minutes;

	// Token: 0x04004152 RID: 16722
	[SerializeField]
	private int seconds;

	// Token: 0x04004153 RID: 16723
	[SerializeField]
	private float currentSecond;

	// Token: 0x04004154 RID: 16724
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
