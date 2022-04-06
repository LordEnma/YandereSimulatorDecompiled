using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200049E RID: 1182
[Serializable]
public class Clock
{
	// Token: 0x06001F63 RID: 8035 RVA: 0x001BD7A4 File Offset: 0x001BB9A4
	public Clock(int hours, int minutes, int seconds, float currentSecond)
	{
		this.hours = hours;
		this.minutes = minutes;
		this.seconds = seconds;
		this.currentSecond = currentSecond;
	}

	// Token: 0x06001F64 RID: 8036 RVA: 0x001BD7C9 File Offset: 0x001BB9C9
	public Clock(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0f)
	{
	}

	// Token: 0x06001F65 RID: 8037 RVA: 0x001BD7D9 File Offset: 0x001BB9D9
	public Clock() : this(0, 0, 0, 0f)
	{
	}

	// Token: 0x170004B2 RID: 1202
	// (get) Token: 0x06001F66 RID: 8038 RVA: 0x001BD7E9 File Offset: 0x001BB9E9
	public int Hours24
	{
		get
		{
			return this.hours;
		}
	}

	// Token: 0x170004B3 RID: 1203
	// (get) Token: 0x06001F67 RID: 8039 RVA: 0x001BD7F4 File Offset: 0x001BB9F4
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
	// (get) Token: 0x06001F68 RID: 8040 RVA: 0x001BD812 File Offset: 0x001BBA12
	public int Minutes
	{
		get
		{
			return this.minutes;
		}
	}

	// Token: 0x170004B5 RID: 1205
	// (get) Token: 0x06001F69 RID: 8041 RVA: 0x001BD81A File Offset: 0x001BBA1A
	public int Seconds
	{
		get
		{
			return this.seconds;
		}
	}

	// Token: 0x170004B6 RID: 1206
	// (get) Token: 0x06001F6A RID: 8042 RVA: 0x001BD822 File Offset: 0x001BBA22
	public float CurrentSecond
	{
		get
		{
			return this.currentSecond;
		}
	}

	// Token: 0x170004B7 RID: 1207
	// (get) Token: 0x06001F6B RID: 8043 RVA: 0x001BD82A File Offset: 0x001BBA2A
	public int TotalSeconds
	{
		get
		{
			return this.hours * 3600 + this.minutes * 60 + this.seconds;
		}
	}

	// Token: 0x170004B8 RID: 1208
	// (get) Token: 0x06001F6C RID: 8044 RVA: 0x001BD849 File Offset: 0x001BBA49
	public float PreciseTotalSeconds
	{
		get
		{
			return (float)this.TotalSeconds + this.currentSecond;
		}
	}

	// Token: 0x170004B9 RID: 1209
	// (get) Token: 0x06001F6D RID: 8045 RVA: 0x001BD859 File Offset: 0x001BBA59
	public bool IsAM
	{
		get
		{
			return this.hours < 12;
		}
	}

	// Token: 0x170004BA RID: 1210
	// (get) Token: 0x06001F6E RID: 8046 RVA: 0x001BD868 File Offset: 0x001BBA68
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
	// (get) Token: 0x06001F6F RID: 8047 RVA: 0x001BD8C8 File Offset: 0x001BBAC8
	public string TimeOfDayString
	{
		get
		{
			return Clock.TimeOfDayStrings[this.TimeOfDay];
		}
	}

	// Token: 0x06001F70 RID: 8048 RVA: 0x001BD8DA File Offset: 0x001BBADA
	public bool IsBefore(Clock clock)
	{
		return this.TotalSeconds < clock.TotalSeconds;
	}

	// Token: 0x06001F71 RID: 8049 RVA: 0x001BD8EA File Offset: 0x001BBAEA
	public bool IsAfter(Clock clock)
	{
		return this.TotalSeconds > clock.TotalSeconds;
	}

	// Token: 0x06001F72 RID: 8050 RVA: 0x001BD8FA File Offset: 0x001BBAFA
	public void IncrementHour()
	{
		this.hours++;
		if (this.hours == 24)
		{
			this.hours = 0;
		}
	}

	// Token: 0x06001F73 RID: 8051 RVA: 0x001BD91B File Offset: 0x001BBB1B
	public void IncrementMinute()
	{
		this.minutes++;
		if (this.minutes == 60)
		{
			this.IncrementHour();
			this.minutes = 0;
		}
	}

	// Token: 0x06001F74 RID: 8052 RVA: 0x001BD942 File Offset: 0x001BBB42
	public void IncrementSecond()
	{
		this.seconds++;
		if (this.seconds == 60)
		{
			this.IncrementMinute();
			this.seconds = 0;
		}
	}

	// Token: 0x06001F75 RID: 8053 RVA: 0x001BD969 File Offset: 0x001BBB69
	public void Tick(float dt)
	{
		this.currentSecond += dt;
		while (this.currentSecond >= 1f)
		{
			this.IncrementSecond();
			this.currentSecond -= 1f;
		}
	}

	// Token: 0x04004213 RID: 16915
	[SerializeField]
	private int hours;

	// Token: 0x04004214 RID: 16916
	[SerializeField]
	private int minutes;

	// Token: 0x04004215 RID: 16917
	[SerializeField]
	private int seconds;

	// Token: 0x04004216 RID: 16918
	[SerializeField]
	private float currentSecond;

	// Token: 0x04004217 RID: 16919
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
