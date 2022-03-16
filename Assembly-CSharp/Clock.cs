using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200049A RID: 1178
[Serializable]
public class Clock
{
	// Token: 0x06001F51 RID: 8017 RVA: 0x001BBD10 File Offset: 0x001B9F10
	public Clock(int hours, int minutes, int seconds, float currentSecond)
	{
		this.hours = hours;
		this.minutes = minutes;
		this.seconds = seconds;
		this.currentSecond = currentSecond;
	}

	// Token: 0x06001F52 RID: 8018 RVA: 0x001BBD35 File Offset: 0x001B9F35
	public Clock(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0f)
	{
	}

	// Token: 0x06001F53 RID: 8019 RVA: 0x001BBD45 File Offset: 0x001B9F45
	public Clock() : this(0, 0, 0, 0f)
	{
	}

	// Token: 0x170004B2 RID: 1202
	// (get) Token: 0x06001F54 RID: 8020 RVA: 0x001BBD55 File Offset: 0x001B9F55
	public int Hours24
	{
		get
		{
			return this.hours;
		}
	}

	// Token: 0x170004B3 RID: 1203
	// (get) Token: 0x06001F55 RID: 8021 RVA: 0x001BBD60 File Offset: 0x001B9F60
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

	// Token: 0x170004B4 RID: 1204
	// (get) Token: 0x06001F56 RID: 8022 RVA: 0x001BBD7E File Offset: 0x001B9F7E
	public int Minutes
	{
		get
		{
			return this.minutes;
		}
	}

	// Token: 0x170004B5 RID: 1205
	// (get) Token: 0x06001F57 RID: 8023 RVA: 0x001BBD86 File Offset: 0x001B9F86
	public int Seconds
	{
		get
		{
			return this.seconds;
		}
	}

	// Token: 0x170004B6 RID: 1206
	// (get) Token: 0x06001F58 RID: 8024 RVA: 0x001BBD8E File Offset: 0x001B9F8E
	public float CurrentSecond
	{
		get
		{
			return this.currentSecond;
		}
	}

	// Token: 0x170004B7 RID: 1207
	// (get) Token: 0x06001F59 RID: 8025 RVA: 0x001BBD96 File Offset: 0x001B9F96
	public int TotalSeconds
	{
		get
		{
			return this.hours * 3600 + this.minutes * 60 + this.seconds;
		}
	}

	// Token: 0x170004B8 RID: 1208
	// (get) Token: 0x06001F5A RID: 8026 RVA: 0x001BBDB5 File Offset: 0x001B9FB5
	public float PreciseTotalSeconds
	{
		get
		{
			return (float)this.TotalSeconds + this.currentSecond;
		}
	}

	// Token: 0x170004B9 RID: 1209
	// (get) Token: 0x06001F5B RID: 8027 RVA: 0x001BBDC5 File Offset: 0x001B9FC5
	public bool IsAM
	{
		get
		{
			return this.hours < 12;
		}
	}

	// Token: 0x170004BA RID: 1210
	// (get) Token: 0x06001F5C RID: 8028 RVA: 0x001BBDD4 File Offset: 0x001B9FD4
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

	// Token: 0x170004BB RID: 1211
	// (get) Token: 0x06001F5D RID: 8029 RVA: 0x001BBE34 File Offset: 0x001BA034
	public string TimeOfDayString
	{
		get
		{
			return Clock.TimeOfDayStrings[this.TimeOfDay];
		}
	}

	// Token: 0x06001F5E RID: 8030 RVA: 0x001BBE46 File Offset: 0x001BA046
	public bool IsBefore(Clock clock)
	{
		return this.TotalSeconds < clock.TotalSeconds;
	}

	// Token: 0x06001F5F RID: 8031 RVA: 0x001BBE56 File Offset: 0x001BA056
	public bool IsAfter(Clock clock)
	{
		return this.TotalSeconds > clock.TotalSeconds;
	}

	// Token: 0x06001F60 RID: 8032 RVA: 0x001BBE66 File Offset: 0x001BA066
	public void IncrementHour()
	{
		this.hours++;
		if (this.hours == 24)
		{
			this.hours = 0;
		}
	}

	// Token: 0x06001F61 RID: 8033 RVA: 0x001BBE87 File Offset: 0x001BA087
	public void IncrementMinute()
	{
		this.minutes++;
		if (this.minutes == 60)
		{
			this.IncrementHour();
			this.minutes = 0;
		}
	}

	// Token: 0x06001F62 RID: 8034 RVA: 0x001BBEAE File Offset: 0x001BA0AE
	public void IncrementSecond()
	{
		this.seconds++;
		if (this.seconds == 60)
		{
			this.IncrementMinute();
			this.seconds = 0;
		}
	}

	// Token: 0x06001F63 RID: 8035 RVA: 0x001BBED5 File Offset: 0x001BA0D5
	public void Tick(float dt)
	{
		this.currentSecond += dt;
		while (this.currentSecond >= 1f)
		{
			this.IncrementSecond();
			this.currentSecond -= 1f;
		}
	}

	// Token: 0x040041E3 RID: 16867
	[SerializeField]
	private int hours;

	// Token: 0x040041E4 RID: 16868
	[SerializeField]
	private int minutes;

	// Token: 0x040041E5 RID: 16869
	[SerializeField]
	private int seconds;

	// Token: 0x040041E6 RID: 16870
	[SerializeField]
	private float currentSecond;

	// Token: 0x040041E7 RID: 16871
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
