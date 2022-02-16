using System;
using UnityEngine;

// Token: 0x02000497 RID: 1175
[Serializable]
public class DateAndTime
{
	// Token: 0x06001F47 RID: 8007 RVA: 0x001B9517 File Offset: 0x001B7717
	public DateAndTime(int week, DayOfWeek weekday, Clock clock)
	{
		this.week = week;
		this.weekday = weekday;
		this.clock = clock;
	}

	// Token: 0x170004BB RID: 1211
	// (get) Token: 0x06001F48 RID: 8008 RVA: 0x001B9534 File Offset: 0x001B7734
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x170004BC RID: 1212
	// (get) Token: 0x06001F49 RID: 8009 RVA: 0x001B953C File Offset: 0x001B773C
	public DayOfWeek Weekday
	{
		get
		{
			return this.weekday;
		}
	}

	// Token: 0x170004BD RID: 1213
	// (get) Token: 0x06001F4A RID: 8010 RVA: 0x001B9544 File Offset: 0x001B7744
	public Clock Clock
	{
		get
		{
			return this.clock;
		}
	}

	// Token: 0x170004BE RID: 1214
	// (get) Token: 0x06001F4B RID: 8011 RVA: 0x001B954C File Offset: 0x001B774C
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

	// Token: 0x06001F4C RID: 8012 RVA: 0x001B9582 File Offset: 0x001B7782
	public void IncrementWeek()
	{
		this.week++;
	}

	// Token: 0x06001F4D RID: 8013 RVA: 0x001B9594 File Offset: 0x001B7794
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

	// Token: 0x06001F4E RID: 8014 RVA: 0x001B95C0 File Offset: 0x001B77C0
	public void Tick(float dt)
	{
		int hours = this.clock.Hours24;
		this.clock.Tick(dt);
		if (this.clock.Hours24 < hours)
		{
			this.IncrementWeekday();
		}
	}

	// Token: 0x04004176 RID: 16758
	[SerializeField]
	private int week;

	// Token: 0x04004177 RID: 16759
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04004178 RID: 16760
	[SerializeField]
	private Clock clock;
}
