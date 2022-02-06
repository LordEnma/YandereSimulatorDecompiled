using System;
using UnityEngine;

// Token: 0x02000496 RID: 1174
[Serializable]
public class DateAndTime
{
	// Token: 0x06001F40 RID: 8000 RVA: 0x001B90C3 File Offset: 0x001B72C3
	public DateAndTime(int week, DayOfWeek weekday, Clock clock)
	{
		this.week = week;
		this.weekday = weekday;
		this.clock = clock;
	}

	// Token: 0x170004BA RID: 1210
	// (get) Token: 0x06001F41 RID: 8001 RVA: 0x001B90E0 File Offset: 0x001B72E0
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x170004BB RID: 1211
	// (get) Token: 0x06001F42 RID: 8002 RVA: 0x001B90E8 File Offset: 0x001B72E8
	public DayOfWeek Weekday
	{
		get
		{
			return this.weekday;
		}
	}

	// Token: 0x170004BC RID: 1212
	// (get) Token: 0x06001F43 RID: 8003 RVA: 0x001B90F0 File Offset: 0x001B72F0
	public Clock Clock
	{
		get
		{
			return this.clock;
		}
	}

	// Token: 0x170004BD RID: 1213
	// (get) Token: 0x06001F44 RID: 8004 RVA: 0x001B90F8 File Offset: 0x001B72F8
	public int TotalSeconds
	{
		get
		{
			int num = this.week * 604800;
			int num2 = (int)(this.weekday * (DayOfWeek)86400);
			int totalSeconds = this.clock.TotalSeconds;
			return num + num2 + totalSeconds;
		}
	}

	// Token: 0x06001F45 RID: 8005 RVA: 0x001B912E File Offset: 0x001B732E
	public void IncrementWeek()
	{
		this.week++;
	}

	// Token: 0x06001F46 RID: 8006 RVA: 0x001B9140 File Offset: 0x001B7340
	public void IncrementWeekday()
	{
		int num = (int)this.weekday;
		num++;
		if (num == 7)
		{
			this.IncrementWeek();
			num = 0;
		}
		this.weekday = (DayOfWeek)num;
	}

	// Token: 0x06001F47 RID: 8007 RVA: 0x001B916C File Offset: 0x001B736C
	public void Tick(float dt)
	{
		int hours = this.clock.Hours24;
		this.clock.Tick(dt);
		if (this.clock.Hours24 < hours)
		{
			this.IncrementWeekday();
		}
	}

	// Token: 0x0400416D RID: 16749
	[SerializeField]
	private int week;

	// Token: 0x0400416E RID: 16750
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x0400416F RID: 16751
	[SerializeField]
	private Clock clock;
}
