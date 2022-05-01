using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200049F RID: 1183
[Serializable]
public class Clock
{
	// Token: 0x06001F72 RID: 8050 RVA: 0x001BF53C File Offset: 0x001BD73C
	public Clock(int hours, int minutes, int seconds, float currentSecond)
	{
		this.hours = hours;
		this.minutes = minutes;
		this.seconds = seconds;
		this.currentSecond = currentSecond;
	}

	// Token: 0x06001F73 RID: 8051 RVA: 0x001BF561 File Offset: 0x001BD761
	public Clock(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0f)
	{
	}

	// Token: 0x06001F74 RID: 8052 RVA: 0x001BF571 File Offset: 0x001BD771
	public Clock() : this(0, 0, 0, 0f)
	{
	}

	// Token: 0x170004B3 RID: 1203
	// (get) Token: 0x06001F75 RID: 8053 RVA: 0x001BF581 File Offset: 0x001BD781
	public int Hours24
	{
		get
		{
			return this.hours;
		}
	}

	// Token: 0x170004B4 RID: 1204
	// (get) Token: 0x06001F76 RID: 8054 RVA: 0x001BF58C File Offset: 0x001BD78C
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
	// (get) Token: 0x06001F77 RID: 8055 RVA: 0x001BF5AA File Offset: 0x001BD7AA
	public int Minutes
	{
		get
		{
			return this.minutes;
		}
	}

	// Token: 0x170004B6 RID: 1206
	// (get) Token: 0x06001F78 RID: 8056 RVA: 0x001BF5B2 File Offset: 0x001BD7B2
	public int Seconds
	{
		get
		{
			return this.seconds;
		}
	}

	// Token: 0x170004B7 RID: 1207
	// (get) Token: 0x06001F79 RID: 8057 RVA: 0x001BF5BA File Offset: 0x001BD7BA
	public float CurrentSecond
	{
		get
		{
			return this.currentSecond;
		}
	}

	// Token: 0x170004B8 RID: 1208
	// (get) Token: 0x06001F7A RID: 8058 RVA: 0x001BF5C2 File Offset: 0x001BD7C2
	public int TotalSeconds
	{
		get
		{
			return this.hours * 3600 + this.minutes * 60 + this.seconds;
		}
	}

	// Token: 0x170004B9 RID: 1209
	// (get) Token: 0x06001F7B RID: 8059 RVA: 0x001BF5E1 File Offset: 0x001BD7E1
	public float PreciseTotalSeconds
	{
		get
		{
			return (float)this.TotalSeconds + this.currentSecond;
		}
	}

	// Token: 0x170004BA RID: 1210
	// (get) Token: 0x06001F7C RID: 8060 RVA: 0x001BF5F1 File Offset: 0x001BD7F1
	public bool IsAM
	{
		get
		{
			return this.hours < 12;
		}
	}

	// Token: 0x170004BB RID: 1211
	// (get) Token: 0x06001F7D RID: 8061 RVA: 0x001BF600 File Offset: 0x001BD800
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
	// (get) Token: 0x06001F7E RID: 8062 RVA: 0x001BF660 File Offset: 0x001BD860
	public string TimeOfDayString
	{
		get
		{
			return Clock.TimeOfDayStrings[this.TimeOfDay];
		}
	}

	// Token: 0x06001F7F RID: 8063 RVA: 0x001BF672 File Offset: 0x001BD872
	public bool IsBefore(Clock clock)
	{
		return this.TotalSeconds < clock.TotalSeconds;
	}

	// Token: 0x06001F80 RID: 8064 RVA: 0x001BF682 File Offset: 0x001BD882
	public bool IsAfter(Clock clock)
	{
		return this.TotalSeconds > clock.TotalSeconds;
	}

	// Token: 0x06001F81 RID: 8065 RVA: 0x001BF692 File Offset: 0x001BD892
	public void IncrementHour()
	{
		this.hours++;
		if (this.hours == 24)
		{
			this.hours = 0;
		}
	}

	// Token: 0x06001F82 RID: 8066 RVA: 0x001BF6B3 File Offset: 0x001BD8B3
	public void IncrementMinute()
	{
		this.minutes++;
		if (this.minutes == 60)
		{
			this.IncrementHour();
			this.minutes = 0;
		}
	}

	// Token: 0x06001F83 RID: 8067 RVA: 0x001BF6DA File Offset: 0x001BD8DA
	public void IncrementSecond()
	{
		this.seconds++;
		if (this.seconds == 60)
		{
			this.IncrementMinute();
			this.seconds = 0;
		}
	}

	// Token: 0x06001F84 RID: 8068 RVA: 0x001BF701 File Offset: 0x001BD901
	public void Tick(float dt)
	{
		this.currentSecond += dt;
		while (this.currentSecond >= 1f)
		{
			this.IncrementSecond();
			this.currentSecond -= 1f;
		}
	}

	// Token: 0x04004239 RID: 16953
	[SerializeField]
	private int hours;

	// Token: 0x0400423A RID: 16954
	[SerializeField]
	private int minutes;

	// Token: 0x0400423B RID: 16955
	[SerializeField]
	private int seconds;

	// Token: 0x0400423C RID: 16956
	[SerializeField]
	private float currentSecond;

	// Token: 0x0400423D RID: 16957
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
