using System;
using UnityEngine;

// Token: 0x02000492 RID: 1170
[Serializable]
public class DateAndTime
{
	// Token: 0x06001F1F RID: 7967 RVA: 0x001B5D8B File Offset: 0x001B3F8B
	public DateAndTime(int week, DayOfWeek weekday, Clock clock)
	{
		this.week = week;
		this.weekday = weekday;
		this.clock = clock;
	}

	// Token: 0x170004B8 RID: 1208
	// (get) Token: 0x06001F20 RID: 7968 RVA: 0x001B5DA8 File Offset: 0x001B3FA8
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x170004B9 RID: 1209
	// (get) Token: 0x06001F21 RID: 7969 RVA: 0x001B5DB0 File Offset: 0x001B3FB0
	public DayOfWeek Weekday
	{
		get
		{
			return this.weekday;
		}
	}

	// Token: 0x170004BA RID: 1210
	// (get) Token: 0x06001F22 RID: 7970 RVA: 0x001B5DB8 File Offset: 0x001B3FB8
	public Clock Clock
	{
		get
		{
			return this.clock;
		}
	}

	// Token: 0x170004BB RID: 1211
	// (get) Token: 0x06001F23 RID: 7971 RVA: 0x001B5DC0 File Offset: 0x001B3FC0
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

	// Token: 0x06001F24 RID: 7972 RVA: 0x001B5DF6 File Offset: 0x001B3FF6
	public void IncrementWeek()
	{
		this.week++;
	}

	// Token: 0x06001F25 RID: 7973 RVA: 0x001B5E08 File Offset: 0x001B4008
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

	// Token: 0x06001F26 RID: 7974 RVA: 0x001B5E34 File Offset: 0x001B4034
	public void Tick(float dt)
	{
		int hours = this.clock.Hours24;
		this.clock.Tick(dt);
		if (this.clock.Hours24 < hours)
		{
			this.IncrementWeekday();
		}
	}

	// Token: 0x0400410A RID: 16650
	[SerializeField]
	private int week;

	// Token: 0x0400410B RID: 16651
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x0400410C RID: 16652
	[SerializeField]
	private Clock clock;
}
