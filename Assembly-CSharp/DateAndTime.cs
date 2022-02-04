using System;
using UnityEngine;

// Token: 0x02000496 RID: 1174
[Serializable]
public class DateAndTime
{
	// Token: 0x06001F3D RID: 7997 RVA: 0x001B8EA3 File Offset: 0x001B70A3
	public DateAndTime(int week, DayOfWeek weekday, Clock clock)
	{
		this.week = week;
		this.weekday = weekday;
		this.clock = clock;
	}

	// Token: 0x170004B9 RID: 1209
	// (get) Token: 0x06001F3E RID: 7998 RVA: 0x001B8EC0 File Offset: 0x001B70C0
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x170004BA RID: 1210
	// (get) Token: 0x06001F3F RID: 7999 RVA: 0x001B8EC8 File Offset: 0x001B70C8
	public DayOfWeek Weekday
	{
		get
		{
			return this.weekday;
		}
	}

	// Token: 0x170004BB RID: 1211
	// (get) Token: 0x06001F40 RID: 8000 RVA: 0x001B8ED0 File Offset: 0x001B70D0
	public Clock Clock
	{
		get
		{
			return this.clock;
		}
	}

	// Token: 0x170004BC RID: 1212
	// (get) Token: 0x06001F41 RID: 8001 RVA: 0x001B8ED8 File Offset: 0x001B70D8
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

	// Token: 0x06001F42 RID: 8002 RVA: 0x001B8F0E File Offset: 0x001B710E
	public void IncrementWeek()
	{
		this.week++;
	}

	// Token: 0x06001F43 RID: 8003 RVA: 0x001B8F20 File Offset: 0x001B7120
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

	// Token: 0x06001F44 RID: 8004 RVA: 0x001B8F4C File Offset: 0x001B714C
	public void Tick(float dt)
	{
		int hours = this.clock.Hours24;
		this.clock.Tick(dt);
		if (this.clock.Hours24 < hours)
		{
			this.IncrementWeekday();
		}
	}

	// Token: 0x0400416A RID: 16746
	[SerializeField]
	private int week;

	// Token: 0x0400416B RID: 16747
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x0400416C RID: 16748
	[SerializeField]
	private Clock clock;
}
