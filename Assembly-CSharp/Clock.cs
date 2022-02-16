using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000496 RID: 1174
[Serializable]
public class Clock
{
	// Token: 0x06001F33 RID: 7987 RVA: 0x001B92A4 File Offset: 0x001B74A4
	public Clock(int hours, int minutes, int seconds, float currentSecond)
	{
		this.hours = hours;
		this.minutes = minutes;
		this.seconds = seconds;
		this.currentSecond = currentSecond;
	}

	// Token: 0x06001F34 RID: 7988 RVA: 0x001B92C9 File Offset: 0x001B74C9
	public Clock(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0f)
	{
	}

	// Token: 0x06001F35 RID: 7989 RVA: 0x001B92D9 File Offset: 0x001B74D9
	public Clock() : this(0, 0, 0, 0f)
	{
	}

	// Token: 0x170004B1 RID: 1201
	// (get) Token: 0x06001F36 RID: 7990 RVA: 0x001B92E9 File Offset: 0x001B74E9
	public int Hours24
	{
		get
		{
			return this.hours;
		}
	}

	// Token: 0x170004B2 RID: 1202
	// (get) Token: 0x06001F37 RID: 7991 RVA: 0x001B92F4 File Offset: 0x001B74F4
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

	// Token: 0x170004B3 RID: 1203
	// (get) Token: 0x06001F38 RID: 7992 RVA: 0x001B9312 File Offset: 0x001B7512
	public int Minutes
	{
		get
		{
			return this.minutes;
		}
	}

	// Token: 0x170004B4 RID: 1204
	// (get) Token: 0x06001F39 RID: 7993 RVA: 0x001B931A File Offset: 0x001B751A
	public int Seconds
	{
		get
		{
			return this.seconds;
		}
	}

	// Token: 0x170004B5 RID: 1205
	// (get) Token: 0x06001F3A RID: 7994 RVA: 0x001B9322 File Offset: 0x001B7522
	public float CurrentSecond
	{
		get
		{
			return this.currentSecond;
		}
	}

	// Token: 0x170004B6 RID: 1206
	// (get) Token: 0x06001F3B RID: 7995 RVA: 0x001B932A File Offset: 0x001B752A
	public int TotalSeconds
	{
		get
		{
			return this.hours * 3600 + this.minutes * 60 + this.seconds;
		}
	}

	// Token: 0x170004B7 RID: 1207
	// (get) Token: 0x06001F3C RID: 7996 RVA: 0x001B9349 File Offset: 0x001B7549
	public float PreciseTotalSeconds
	{
		get
		{
			return (float)this.TotalSeconds + this.currentSecond;
		}
	}

	// Token: 0x170004B8 RID: 1208
	// (get) Token: 0x06001F3D RID: 7997 RVA: 0x001B9359 File Offset: 0x001B7559
	public bool IsAM
	{
		get
		{
			return this.hours < 12;
		}
	}

	// Token: 0x170004B9 RID: 1209
	// (get) Token: 0x06001F3E RID: 7998 RVA: 0x001B9368 File Offset: 0x001B7568
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

	// Token: 0x170004BA RID: 1210
	// (get) Token: 0x06001F3F RID: 7999 RVA: 0x001B93C8 File Offset: 0x001B75C8
	public string TimeOfDayString
	{
		get
		{
			return Clock.TimeOfDayStrings[this.TimeOfDay];
		}
	}

	// Token: 0x06001F40 RID: 8000 RVA: 0x001B93DA File Offset: 0x001B75DA
	public bool IsBefore(Clock clock)
	{
		return this.TotalSeconds < clock.TotalSeconds;
	}

	// Token: 0x06001F41 RID: 8001 RVA: 0x001B93EA File Offset: 0x001B75EA
	public bool IsAfter(Clock clock)
	{
		return this.TotalSeconds > clock.TotalSeconds;
	}

	// Token: 0x06001F42 RID: 8002 RVA: 0x001B93FA File Offset: 0x001B75FA
	public void IncrementHour()
	{
		this.hours++;
		if (this.hours == 24)
		{
			this.hours = 0;
		}
	}

	// Token: 0x06001F43 RID: 8003 RVA: 0x001B941B File Offset: 0x001B761B
	public void IncrementMinute()
	{
		this.minutes++;
		if (this.minutes == 60)
		{
			this.IncrementHour();
			this.minutes = 0;
		}
	}

	// Token: 0x06001F44 RID: 8004 RVA: 0x001B9442 File Offset: 0x001B7642
	public void IncrementSecond()
	{
		this.seconds++;
		if (this.seconds == 60)
		{
			this.IncrementMinute();
			this.seconds = 0;
		}
	}

	// Token: 0x06001F45 RID: 8005 RVA: 0x001B9469 File Offset: 0x001B7669
	public void Tick(float dt)
	{
		this.currentSecond += dt;
		while (this.currentSecond >= 1f)
		{
			this.IncrementSecond();
			this.currentSecond -= 1f;
		}
	}

	// Token: 0x04004171 RID: 16753
	[SerializeField]
	private int hours;

	// Token: 0x04004172 RID: 16754
	[SerializeField]
	private int minutes;

	// Token: 0x04004173 RID: 16755
	[SerializeField]
	private int seconds;

	// Token: 0x04004174 RID: 16756
	[SerializeField]
	private float currentSecond;

	// Token: 0x04004175 RID: 16757
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
