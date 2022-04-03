using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200049D RID: 1181
[Serializable]
public class Clock
{
	// Token: 0x06001F5B RID: 8027 RVA: 0x001BD29C File Offset: 0x001BB49C
	public Clock(int hours, int minutes, int seconds, float currentSecond)
	{
		this.hours = hours;
		this.minutes = minutes;
		this.seconds = seconds;
		this.currentSecond = currentSecond;
	}

	// Token: 0x06001F5C RID: 8028 RVA: 0x001BD2C1 File Offset: 0x001BB4C1
	public Clock(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0f)
	{
	}

	// Token: 0x06001F5D RID: 8029 RVA: 0x001BD2D1 File Offset: 0x001BB4D1
	public Clock() : this(0, 0, 0, 0f)
	{
	}

	// Token: 0x170004B2 RID: 1202
	// (get) Token: 0x06001F5E RID: 8030 RVA: 0x001BD2E1 File Offset: 0x001BB4E1
	public int Hours24
	{
		get
		{
			return this.hours;
		}
	}

	// Token: 0x170004B3 RID: 1203
	// (get) Token: 0x06001F5F RID: 8031 RVA: 0x001BD2EC File Offset: 0x001BB4EC
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
	// (get) Token: 0x06001F60 RID: 8032 RVA: 0x001BD30A File Offset: 0x001BB50A
	public int Minutes
	{
		get
		{
			return this.minutes;
		}
	}

	// Token: 0x170004B5 RID: 1205
	// (get) Token: 0x06001F61 RID: 8033 RVA: 0x001BD312 File Offset: 0x001BB512
	public int Seconds
	{
		get
		{
			return this.seconds;
		}
	}

	// Token: 0x170004B6 RID: 1206
	// (get) Token: 0x06001F62 RID: 8034 RVA: 0x001BD31A File Offset: 0x001BB51A
	public float CurrentSecond
	{
		get
		{
			return this.currentSecond;
		}
	}

	// Token: 0x170004B7 RID: 1207
	// (get) Token: 0x06001F63 RID: 8035 RVA: 0x001BD322 File Offset: 0x001BB522
	public int TotalSeconds
	{
		get
		{
			return this.hours * 3600 + this.minutes * 60 + this.seconds;
		}
	}

	// Token: 0x170004B8 RID: 1208
	// (get) Token: 0x06001F64 RID: 8036 RVA: 0x001BD341 File Offset: 0x001BB541
	public float PreciseTotalSeconds
	{
		get
		{
			return (float)this.TotalSeconds + this.currentSecond;
		}
	}

	// Token: 0x170004B9 RID: 1209
	// (get) Token: 0x06001F65 RID: 8037 RVA: 0x001BD351 File Offset: 0x001BB551
	public bool IsAM
	{
		get
		{
			return this.hours < 12;
		}
	}

	// Token: 0x170004BA RID: 1210
	// (get) Token: 0x06001F66 RID: 8038 RVA: 0x001BD360 File Offset: 0x001BB560
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
	// (get) Token: 0x06001F67 RID: 8039 RVA: 0x001BD3C0 File Offset: 0x001BB5C0
	public string TimeOfDayString
	{
		get
		{
			return Clock.TimeOfDayStrings[this.TimeOfDay];
		}
	}

	// Token: 0x06001F68 RID: 8040 RVA: 0x001BD3D2 File Offset: 0x001BB5D2
	public bool IsBefore(Clock clock)
	{
		return this.TotalSeconds < clock.TotalSeconds;
	}

	// Token: 0x06001F69 RID: 8041 RVA: 0x001BD3E2 File Offset: 0x001BB5E2
	public bool IsAfter(Clock clock)
	{
		return this.TotalSeconds > clock.TotalSeconds;
	}

	// Token: 0x06001F6A RID: 8042 RVA: 0x001BD3F2 File Offset: 0x001BB5F2
	public void IncrementHour()
	{
		this.hours++;
		if (this.hours == 24)
		{
			this.hours = 0;
		}
	}

	// Token: 0x06001F6B RID: 8043 RVA: 0x001BD413 File Offset: 0x001BB613
	public void IncrementMinute()
	{
		this.minutes++;
		if (this.minutes == 60)
		{
			this.IncrementHour();
			this.minutes = 0;
		}
	}

	// Token: 0x06001F6C RID: 8044 RVA: 0x001BD43A File Offset: 0x001BB63A
	public void IncrementSecond()
	{
		this.seconds++;
		if (this.seconds == 60)
		{
			this.IncrementMinute();
			this.seconds = 0;
		}
	}

	// Token: 0x06001F6D RID: 8045 RVA: 0x001BD461 File Offset: 0x001BB661
	public void Tick(float dt)
	{
		this.currentSecond += dt;
		while (this.currentSecond >= 1f)
		{
			this.IncrementSecond();
			this.currentSecond -= 1f;
		}
	}

	// Token: 0x04004210 RID: 16912
	[SerializeField]
	private int hours;

	// Token: 0x04004211 RID: 16913
	[SerializeField]
	private int minutes;

	// Token: 0x04004212 RID: 16914
	[SerializeField]
	private int seconds;

	// Token: 0x04004213 RID: 16915
	[SerializeField]
	private float currentSecond;

	// Token: 0x04004214 RID: 16916
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
