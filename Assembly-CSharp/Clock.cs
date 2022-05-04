using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200049F RID: 1183
[Serializable]
public class Clock
{
	// Token: 0x06001F73 RID: 8051 RVA: 0x001BF638 File Offset: 0x001BD838
	public Clock(int hours, int minutes, int seconds, float currentSecond)
	{
		this.hours = hours;
		this.minutes = minutes;
		this.seconds = seconds;
		this.currentSecond = currentSecond;
	}

	// Token: 0x06001F74 RID: 8052 RVA: 0x001BF65D File Offset: 0x001BD85D
	public Clock(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0f)
	{
	}

	// Token: 0x06001F75 RID: 8053 RVA: 0x001BF66D File Offset: 0x001BD86D
	public Clock() : this(0, 0, 0, 0f)
	{
	}

	// Token: 0x170004B3 RID: 1203
	// (get) Token: 0x06001F76 RID: 8054 RVA: 0x001BF67D File Offset: 0x001BD87D
	public int Hours24
	{
		get
		{
			return this.hours;
		}
	}

	// Token: 0x170004B4 RID: 1204
	// (get) Token: 0x06001F77 RID: 8055 RVA: 0x001BF688 File Offset: 0x001BD888
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
	// (get) Token: 0x06001F78 RID: 8056 RVA: 0x001BF6A6 File Offset: 0x001BD8A6
	public int Minutes
	{
		get
		{
			return this.minutes;
		}
	}

	// Token: 0x170004B6 RID: 1206
	// (get) Token: 0x06001F79 RID: 8057 RVA: 0x001BF6AE File Offset: 0x001BD8AE
	public int Seconds
	{
		get
		{
			return this.seconds;
		}
	}

	// Token: 0x170004B7 RID: 1207
	// (get) Token: 0x06001F7A RID: 8058 RVA: 0x001BF6B6 File Offset: 0x001BD8B6
	public float CurrentSecond
	{
		get
		{
			return this.currentSecond;
		}
	}

	// Token: 0x170004B8 RID: 1208
	// (get) Token: 0x06001F7B RID: 8059 RVA: 0x001BF6BE File Offset: 0x001BD8BE
	public int TotalSeconds
	{
		get
		{
			return this.hours * 3600 + this.minutes * 60 + this.seconds;
		}
	}

	// Token: 0x170004B9 RID: 1209
	// (get) Token: 0x06001F7C RID: 8060 RVA: 0x001BF6DD File Offset: 0x001BD8DD
	public float PreciseTotalSeconds
	{
		get
		{
			return (float)this.TotalSeconds + this.currentSecond;
		}
	}

	// Token: 0x170004BA RID: 1210
	// (get) Token: 0x06001F7D RID: 8061 RVA: 0x001BF6ED File Offset: 0x001BD8ED
	public bool IsAM
	{
		get
		{
			return this.hours < 12;
		}
	}

	// Token: 0x170004BB RID: 1211
	// (get) Token: 0x06001F7E RID: 8062 RVA: 0x001BF6FC File Offset: 0x001BD8FC
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
	// (get) Token: 0x06001F7F RID: 8063 RVA: 0x001BF75C File Offset: 0x001BD95C
	public string TimeOfDayString
	{
		get
		{
			return Clock.TimeOfDayStrings[this.TimeOfDay];
		}
	}

	// Token: 0x06001F80 RID: 8064 RVA: 0x001BF76E File Offset: 0x001BD96E
	public bool IsBefore(Clock clock)
	{
		return this.TotalSeconds < clock.TotalSeconds;
	}

	// Token: 0x06001F81 RID: 8065 RVA: 0x001BF77E File Offset: 0x001BD97E
	public bool IsAfter(Clock clock)
	{
		return this.TotalSeconds > clock.TotalSeconds;
	}

	// Token: 0x06001F82 RID: 8066 RVA: 0x001BF78E File Offset: 0x001BD98E
	public void IncrementHour()
	{
		this.hours++;
		if (this.hours == 24)
		{
			this.hours = 0;
		}
	}

	// Token: 0x06001F83 RID: 8067 RVA: 0x001BF7AF File Offset: 0x001BD9AF
	public void IncrementMinute()
	{
		this.minutes++;
		if (this.minutes == 60)
		{
			this.IncrementHour();
			this.minutes = 0;
		}
	}

	// Token: 0x06001F84 RID: 8068 RVA: 0x001BF7D6 File Offset: 0x001BD9D6
	public void IncrementSecond()
	{
		this.seconds++;
		if (this.seconds == 60)
		{
			this.IncrementMinute();
			this.seconds = 0;
		}
	}

	// Token: 0x06001F85 RID: 8069 RVA: 0x001BF7FD File Offset: 0x001BD9FD
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
