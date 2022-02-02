using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000495 RID: 1173
[Serializable]
public class Clock
{
	// Token: 0x06001F27 RID: 7975 RVA: 0x001B8924 File Offset: 0x001B6B24
	public Clock(int hours, int minutes, int seconds, float currentSecond)
	{
		this.hours = hours;
		this.minutes = minutes;
		this.seconds = seconds;
		this.currentSecond = currentSecond;
	}

	// Token: 0x06001F28 RID: 7976 RVA: 0x001B8949 File Offset: 0x001B6B49
	public Clock(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0f)
	{
	}

	// Token: 0x06001F29 RID: 7977 RVA: 0x001B8959 File Offset: 0x001B6B59
	public Clock() : this(0, 0, 0, 0f)
	{
	}

	// Token: 0x170004AF RID: 1199
	// (get) Token: 0x06001F2A RID: 7978 RVA: 0x001B8969 File Offset: 0x001B6B69
	public int Hours24
	{
		get
		{
			return this.hours;
		}
	}

	// Token: 0x170004B0 RID: 1200
	// (get) Token: 0x06001F2B RID: 7979 RVA: 0x001B8974 File Offset: 0x001B6B74
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
	// (get) Token: 0x06001F2C RID: 7980 RVA: 0x001B8992 File Offset: 0x001B6B92
	public int Minutes
	{
		get
		{
			return this.minutes;
		}
	}

	// Token: 0x170004B2 RID: 1202
	// (get) Token: 0x06001F2D RID: 7981 RVA: 0x001B899A File Offset: 0x001B6B9A
	public int Seconds
	{
		get
		{
			return this.seconds;
		}
	}

	// Token: 0x170004B3 RID: 1203
	// (get) Token: 0x06001F2E RID: 7982 RVA: 0x001B89A2 File Offset: 0x001B6BA2
	public float CurrentSecond
	{
		get
		{
			return this.currentSecond;
		}
	}

	// Token: 0x170004B4 RID: 1204
	// (get) Token: 0x06001F2F RID: 7983 RVA: 0x001B89AA File Offset: 0x001B6BAA
	public int TotalSeconds
	{
		get
		{
			return this.hours * 3600 + this.minutes * 60 + this.seconds;
		}
	}

	// Token: 0x170004B5 RID: 1205
	// (get) Token: 0x06001F30 RID: 7984 RVA: 0x001B89C9 File Offset: 0x001B6BC9
	public float PreciseTotalSeconds
	{
		get
		{
			return (float)this.TotalSeconds + this.currentSecond;
		}
	}

	// Token: 0x170004B6 RID: 1206
	// (get) Token: 0x06001F31 RID: 7985 RVA: 0x001B89D9 File Offset: 0x001B6BD9
	public bool IsAM
	{
		get
		{
			return this.hours < 12;
		}
	}

	// Token: 0x170004B7 RID: 1207
	// (get) Token: 0x06001F32 RID: 7986 RVA: 0x001B89E8 File Offset: 0x001B6BE8
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
	// (get) Token: 0x06001F33 RID: 7987 RVA: 0x001B8A48 File Offset: 0x001B6C48
	public string TimeOfDayString
	{
		get
		{
			return Clock.TimeOfDayStrings[this.TimeOfDay];
		}
	}

	// Token: 0x06001F34 RID: 7988 RVA: 0x001B8A5A File Offset: 0x001B6C5A
	public bool IsBefore(Clock clock)
	{
		return this.TotalSeconds < clock.TotalSeconds;
	}

	// Token: 0x06001F35 RID: 7989 RVA: 0x001B8A6A File Offset: 0x001B6C6A
	public bool IsAfter(Clock clock)
	{
		return this.TotalSeconds > clock.TotalSeconds;
	}

	// Token: 0x06001F36 RID: 7990 RVA: 0x001B8A7A File Offset: 0x001B6C7A
	public void IncrementHour()
	{
		this.hours++;
		if (this.hours == 24)
		{
			this.hours = 0;
		}
	}

	// Token: 0x06001F37 RID: 7991 RVA: 0x001B8A9B File Offset: 0x001B6C9B
	public void IncrementMinute()
	{
		this.minutes++;
		if (this.minutes == 60)
		{
			this.IncrementHour();
			this.minutes = 0;
		}
	}

	// Token: 0x06001F38 RID: 7992 RVA: 0x001B8AC2 File Offset: 0x001B6CC2
	public void IncrementSecond()
	{
		this.seconds++;
		if (this.seconds == 60)
		{
			this.IncrementMinute();
			this.seconds = 0;
		}
	}

	// Token: 0x06001F39 RID: 7993 RVA: 0x001B8AE9 File Offset: 0x001B6CE9
	public void Tick(float dt)
	{
		this.currentSecond += dt;
		while (this.currentSecond >= 1f)
		{
			this.IncrementSecond();
			this.currentSecond -= 1f;
		}
	}

	// Token: 0x0400415F RID: 16735
	[SerializeField]
	private int hours;

	// Token: 0x04004160 RID: 16736
	[SerializeField]
	private int minutes;

	// Token: 0x04004161 RID: 16737
	[SerializeField]
	private int seconds;

	// Token: 0x04004162 RID: 16738
	[SerializeField]
	private float currentSecond;

	// Token: 0x04004163 RID: 16739
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
