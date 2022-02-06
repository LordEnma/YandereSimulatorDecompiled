using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000495 RID: 1173
[Serializable]
public class Clock
{
	// Token: 0x06001F2C RID: 7980 RVA: 0x001B8E50 File Offset: 0x001B7050
	public Clock(int hours, int minutes, int seconds, float currentSecond)
	{
		this.hours = hours;
		this.minutes = minutes;
		this.seconds = seconds;
		this.currentSecond = currentSecond;
	}

	// Token: 0x06001F2D RID: 7981 RVA: 0x001B8E75 File Offset: 0x001B7075
	public Clock(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0f)
	{
	}

	// Token: 0x06001F2E RID: 7982 RVA: 0x001B8E85 File Offset: 0x001B7085
	public Clock() : this(0, 0, 0, 0f)
	{
	}

	// Token: 0x170004B0 RID: 1200
	// (get) Token: 0x06001F2F RID: 7983 RVA: 0x001B8E95 File Offset: 0x001B7095
	public int Hours24
	{
		get
		{
			return this.hours;
		}
	}

	// Token: 0x170004B1 RID: 1201
	// (get) Token: 0x06001F30 RID: 7984 RVA: 0x001B8EA0 File Offset: 0x001B70A0
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

	// Token: 0x170004B2 RID: 1202
	// (get) Token: 0x06001F31 RID: 7985 RVA: 0x001B8EBE File Offset: 0x001B70BE
	public int Minutes
	{
		get
		{
			return this.minutes;
		}
	}

	// Token: 0x170004B3 RID: 1203
	// (get) Token: 0x06001F32 RID: 7986 RVA: 0x001B8EC6 File Offset: 0x001B70C6
	public int Seconds
	{
		get
		{
			return this.seconds;
		}
	}

	// Token: 0x170004B4 RID: 1204
	// (get) Token: 0x06001F33 RID: 7987 RVA: 0x001B8ECE File Offset: 0x001B70CE
	public float CurrentSecond
	{
		get
		{
			return this.currentSecond;
		}
	}

	// Token: 0x170004B5 RID: 1205
	// (get) Token: 0x06001F34 RID: 7988 RVA: 0x001B8ED6 File Offset: 0x001B70D6
	public int TotalSeconds
	{
		get
		{
			return this.hours * 3600 + this.minutes * 60 + this.seconds;
		}
	}

	// Token: 0x170004B6 RID: 1206
	// (get) Token: 0x06001F35 RID: 7989 RVA: 0x001B8EF5 File Offset: 0x001B70F5
	public float PreciseTotalSeconds
	{
		get
		{
			return (float)this.TotalSeconds + this.currentSecond;
		}
	}

	// Token: 0x170004B7 RID: 1207
	// (get) Token: 0x06001F36 RID: 7990 RVA: 0x001B8F05 File Offset: 0x001B7105
	public bool IsAM
	{
		get
		{
			return this.hours < 12;
		}
	}

	// Token: 0x170004B8 RID: 1208
	// (get) Token: 0x06001F37 RID: 7991 RVA: 0x001B8F14 File Offset: 0x001B7114
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

	// Token: 0x170004B9 RID: 1209
	// (get) Token: 0x06001F38 RID: 7992 RVA: 0x001B8F74 File Offset: 0x001B7174
	public string TimeOfDayString
	{
		get
		{
			return Clock.TimeOfDayStrings[this.TimeOfDay];
		}
	}

	// Token: 0x06001F39 RID: 7993 RVA: 0x001B8F86 File Offset: 0x001B7186
	public bool IsBefore(Clock clock)
	{
		return this.TotalSeconds < clock.TotalSeconds;
	}

	// Token: 0x06001F3A RID: 7994 RVA: 0x001B8F96 File Offset: 0x001B7196
	public bool IsAfter(Clock clock)
	{
		return this.TotalSeconds > clock.TotalSeconds;
	}

	// Token: 0x06001F3B RID: 7995 RVA: 0x001B8FA6 File Offset: 0x001B71A6
	public void IncrementHour()
	{
		this.hours++;
		if (this.hours == 24)
		{
			this.hours = 0;
		}
	}

	// Token: 0x06001F3C RID: 7996 RVA: 0x001B8FC7 File Offset: 0x001B71C7
	public void IncrementMinute()
	{
		this.minutes++;
		if (this.minutes == 60)
		{
			this.IncrementHour();
			this.minutes = 0;
		}
	}

	// Token: 0x06001F3D RID: 7997 RVA: 0x001B8FEE File Offset: 0x001B71EE
	public void IncrementSecond()
	{
		this.seconds++;
		if (this.seconds == 60)
		{
			this.IncrementMinute();
			this.seconds = 0;
		}
	}

	// Token: 0x06001F3E RID: 7998 RVA: 0x001B9015 File Offset: 0x001B7215
	public void Tick(float dt)
	{
		this.currentSecond += dt;
		while (this.currentSecond >= 1f)
		{
			this.IncrementSecond();
			this.currentSecond -= 1f;
		}
	}

	// Token: 0x04004168 RID: 16744
	[SerializeField]
	private int hours;

	// Token: 0x04004169 RID: 16745
	[SerializeField]
	private int minutes;

	// Token: 0x0400416A RID: 16746
	[SerializeField]
	private int seconds;

	// Token: 0x0400416B RID: 16747
	[SerializeField]
	private float currentSecond;

	// Token: 0x0400416C RID: 16748
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
