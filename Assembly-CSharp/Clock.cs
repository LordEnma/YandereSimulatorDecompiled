using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020004A0 RID: 1184
[Serializable]
public class Clock
{
	// Token: 0x06001F7C RID: 8060 RVA: 0x001C07D0 File Offset: 0x001BE9D0
	public Clock(int hours, int minutes, int seconds, float currentSecond)
	{
		this.hours = hours;
		this.minutes = minutes;
		this.seconds = seconds;
		this.currentSecond = currentSecond;
	}

	// Token: 0x06001F7D RID: 8061 RVA: 0x001C07F5 File Offset: 0x001BE9F5
	public Clock(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0f)
	{
	}

	// Token: 0x06001F7E RID: 8062 RVA: 0x001C0805 File Offset: 0x001BEA05
	public Clock() : this(0, 0, 0, 0f)
	{
	}

	// Token: 0x170004B4 RID: 1204
	// (get) Token: 0x06001F7F RID: 8063 RVA: 0x001C0815 File Offset: 0x001BEA15
	public int Hours24
	{
		get
		{
			return this.hours;
		}
	}

	// Token: 0x170004B5 RID: 1205
	// (get) Token: 0x06001F80 RID: 8064 RVA: 0x001C0820 File Offset: 0x001BEA20
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

	// Token: 0x170004B6 RID: 1206
	// (get) Token: 0x06001F81 RID: 8065 RVA: 0x001C083E File Offset: 0x001BEA3E
	public int Minutes
	{
		get
		{
			return this.minutes;
		}
	}

	// Token: 0x170004B7 RID: 1207
	// (get) Token: 0x06001F82 RID: 8066 RVA: 0x001C0846 File Offset: 0x001BEA46
	public int Seconds
	{
		get
		{
			return this.seconds;
		}
	}

	// Token: 0x170004B8 RID: 1208
	// (get) Token: 0x06001F83 RID: 8067 RVA: 0x001C084E File Offset: 0x001BEA4E
	public float CurrentSecond
	{
		get
		{
			return this.currentSecond;
		}
	}

	// Token: 0x170004B9 RID: 1209
	// (get) Token: 0x06001F84 RID: 8068 RVA: 0x001C0856 File Offset: 0x001BEA56
	public int TotalSeconds
	{
		get
		{
			return this.hours * 3600 + this.minutes * 60 + this.seconds;
		}
	}

	// Token: 0x170004BA RID: 1210
	// (get) Token: 0x06001F85 RID: 8069 RVA: 0x001C0875 File Offset: 0x001BEA75
	public float PreciseTotalSeconds
	{
		get
		{
			return (float)this.TotalSeconds + this.currentSecond;
		}
	}

	// Token: 0x170004BB RID: 1211
	// (get) Token: 0x06001F86 RID: 8070 RVA: 0x001C0885 File Offset: 0x001BEA85
	public bool IsAM
	{
		get
		{
			return this.hours < 12;
		}
	}

	// Token: 0x170004BC RID: 1212
	// (get) Token: 0x06001F87 RID: 8071 RVA: 0x001C0894 File Offset: 0x001BEA94
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

	// Token: 0x170004BD RID: 1213
	// (get) Token: 0x06001F88 RID: 8072 RVA: 0x001C08F4 File Offset: 0x001BEAF4
	public string TimeOfDayString
	{
		get
		{
			return Clock.TimeOfDayStrings[this.TimeOfDay];
		}
	}

	// Token: 0x06001F89 RID: 8073 RVA: 0x001C0906 File Offset: 0x001BEB06
	public bool IsBefore(Clock clock)
	{
		return this.TotalSeconds < clock.TotalSeconds;
	}

	// Token: 0x06001F8A RID: 8074 RVA: 0x001C0916 File Offset: 0x001BEB16
	public bool IsAfter(Clock clock)
	{
		return this.TotalSeconds > clock.TotalSeconds;
	}

	// Token: 0x06001F8B RID: 8075 RVA: 0x001C0926 File Offset: 0x001BEB26
	public void IncrementHour()
	{
		this.hours++;
		if (this.hours == 24)
		{
			this.hours = 0;
		}
	}

	// Token: 0x06001F8C RID: 8076 RVA: 0x001C0947 File Offset: 0x001BEB47
	public void IncrementMinute()
	{
		this.minutes++;
		if (this.minutes == 60)
		{
			this.IncrementHour();
			this.minutes = 0;
		}
	}

	// Token: 0x06001F8D RID: 8077 RVA: 0x001C096E File Offset: 0x001BEB6E
	public void IncrementSecond()
	{
		this.seconds++;
		if (this.seconds == 60)
		{
			this.IncrementMinute();
			this.seconds = 0;
		}
	}

	// Token: 0x06001F8E RID: 8078 RVA: 0x001C0995 File Offset: 0x001BEB95
	public void Tick(float dt)
	{
		this.currentSecond += dt;
		while (this.currentSecond >= 1f)
		{
			this.IncrementSecond();
			this.currentSecond -= 1f;
		}
	}

	// Token: 0x04004257 RID: 16983
	[SerializeField]
	private int hours;

	// Token: 0x04004258 RID: 16984
	[SerializeField]
	private int minutes;

	// Token: 0x04004259 RID: 16985
	[SerializeField]
	private int seconds;

	// Token: 0x0400425A RID: 16986
	[SerializeField]
	private float currentSecond;

	// Token: 0x0400425B RID: 16987
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
