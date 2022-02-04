using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000495 RID: 1173
[Serializable]
public class Clock
{
	// Token: 0x06001F29 RID: 7977 RVA: 0x001B8C30 File Offset: 0x001B6E30
	public Clock(int hours, int minutes, int seconds, float currentSecond)
	{
		this.hours = hours;
		this.minutes = minutes;
		this.seconds = seconds;
		this.currentSecond = currentSecond;
	}

	// Token: 0x06001F2A RID: 7978 RVA: 0x001B8C55 File Offset: 0x001B6E55
	public Clock(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0f)
	{
	}

	// Token: 0x06001F2B RID: 7979 RVA: 0x001B8C65 File Offset: 0x001B6E65
	public Clock() : this(0, 0, 0, 0f)
	{
	}

	// Token: 0x170004AF RID: 1199
	// (get) Token: 0x06001F2C RID: 7980 RVA: 0x001B8C75 File Offset: 0x001B6E75
	public int Hours24
	{
		get
		{
			return this.hours;
		}
	}

	// Token: 0x170004B0 RID: 1200
	// (get) Token: 0x06001F2D RID: 7981 RVA: 0x001B8C80 File Offset: 0x001B6E80
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
	// (get) Token: 0x06001F2E RID: 7982 RVA: 0x001B8C9E File Offset: 0x001B6E9E
	public int Minutes
	{
		get
		{
			return this.minutes;
		}
	}

	// Token: 0x170004B2 RID: 1202
	// (get) Token: 0x06001F2F RID: 7983 RVA: 0x001B8CA6 File Offset: 0x001B6EA6
	public int Seconds
	{
		get
		{
			return this.seconds;
		}
	}

	// Token: 0x170004B3 RID: 1203
	// (get) Token: 0x06001F30 RID: 7984 RVA: 0x001B8CAE File Offset: 0x001B6EAE
	public float CurrentSecond
	{
		get
		{
			return this.currentSecond;
		}
	}

	// Token: 0x170004B4 RID: 1204
	// (get) Token: 0x06001F31 RID: 7985 RVA: 0x001B8CB6 File Offset: 0x001B6EB6
	public int TotalSeconds
	{
		get
		{
			return this.hours * 3600 + this.minutes * 60 + this.seconds;
		}
	}

	// Token: 0x170004B5 RID: 1205
	// (get) Token: 0x06001F32 RID: 7986 RVA: 0x001B8CD5 File Offset: 0x001B6ED5
	public float PreciseTotalSeconds
	{
		get
		{
			return (float)this.TotalSeconds + this.currentSecond;
		}
	}

	// Token: 0x170004B6 RID: 1206
	// (get) Token: 0x06001F33 RID: 7987 RVA: 0x001B8CE5 File Offset: 0x001B6EE5
	public bool IsAM
	{
		get
		{
			return this.hours < 12;
		}
	}

	// Token: 0x170004B7 RID: 1207
	// (get) Token: 0x06001F34 RID: 7988 RVA: 0x001B8CF4 File Offset: 0x001B6EF4
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
	// (get) Token: 0x06001F35 RID: 7989 RVA: 0x001B8D54 File Offset: 0x001B6F54
	public string TimeOfDayString
	{
		get
		{
			return Clock.TimeOfDayStrings[this.TimeOfDay];
		}
	}

	// Token: 0x06001F36 RID: 7990 RVA: 0x001B8D66 File Offset: 0x001B6F66
	public bool IsBefore(Clock clock)
	{
		return this.TotalSeconds < clock.TotalSeconds;
	}

	// Token: 0x06001F37 RID: 7991 RVA: 0x001B8D76 File Offset: 0x001B6F76
	public bool IsAfter(Clock clock)
	{
		return this.TotalSeconds > clock.TotalSeconds;
	}

	// Token: 0x06001F38 RID: 7992 RVA: 0x001B8D86 File Offset: 0x001B6F86
	public void IncrementHour()
	{
		this.hours++;
		if (this.hours == 24)
		{
			this.hours = 0;
		}
	}

	// Token: 0x06001F39 RID: 7993 RVA: 0x001B8DA7 File Offset: 0x001B6FA7
	public void IncrementMinute()
	{
		this.minutes++;
		if (this.minutes == 60)
		{
			this.IncrementHour();
			this.minutes = 0;
		}
	}

	// Token: 0x06001F3A RID: 7994 RVA: 0x001B8DCE File Offset: 0x001B6FCE
	public void IncrementSecond()
	{
		this.seconds++;
		if (this.seconds == 60)
		{
			this.IncrementMinute();
			this.seconds = 0;
		}
	}

	// Token: 0x06001F3B RID: 7995 RVA: 0x001B8DF5 File Offset: 0x001B6FF5
	public void Tick(float dt)
	{
		this.currentSecond += dt;
		while (this.currentSecond >= 1f)
		{
			this.IncrementSecond();
			this.currentSecond -= 1f;
		}
	}

	// Token: 0x04004165 RID: 16741
	[SerializeField]
	private int hours;

	// Token: 0x04004166 RID: 16742
	[SerializeField]
	private int minutes;

	// Token: 0x04004167 RID: 16743
	[SerializeField]
	private int seconds;

	// Token: 0x04004168 RID: 16744
	[SerializeField]
	private float currentSecond;

	// Token: 0x04004169 RID: 16745
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
