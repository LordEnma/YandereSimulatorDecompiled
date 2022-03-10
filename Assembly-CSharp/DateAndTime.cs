using System;
using UnityEngine;

// Token: 0x02000498 RID: 1176
[Serializable]
public class DateAndTime
{
	// Token: 0x06001F53 RID: 8019 RVA: 0x001BA803 File Offset: 0x001B8A03
	public DateAndTime(int week, DayOfWeek weekday, Clock clock)
	{
		this.week = week;
		this.weekday = weekday;
		this.clock = clock;
	}

	// Token: 0x170004BB RID: 1211
	// (get) Token: 0x06001F54 RID: 8020 RVA: 0x001BA820 File Offset: 0x001B8A20
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x170004BC RID: 1212
	// (get) Token: 0x06001F55 RID: 8021 RVA: 0x001BA828 File Offset: 0x001B8A28
	public DayOfWeek Weekday
	{
		get
		{
			return this.weekday;
		}
	}

	// Token: 0x170004BD RID: 1213
	// (get) Token: 0x06001F56 RID: 8022 RVA: 0x001BA830 File Offset: 0x001B8A30
	public Clock Clock
	{
		get
		{
			return this.clock;
		}
	}

	// Token: 0x170004BE RID: 1214
	// (get) Token: 0x06001F57 RID: 8023 RVA: 0x001BA838 File Offset: 0x001B8A38
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

	// Token: 0x06001F58 RID: 8024 RVA: 0x001BA86E File Offset: 0x001B8A6E
	public void IncrementWeek()
	{
		this.week++;
	}

	// Token: 0x06001F59 RID: 8025 RVA: 0x001BA880 File Offset: 0x001B8A80
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

	// Token: 0x06001F5A RID: 8026 RVA: 0x001BA8AC File Offset: 0x001B8AAC
	public void Tick(float dt)
	{
		int hours = this.clock.Hours24;
		this.clock.Tick(dt);
		if (this.clock.Hours24 < hours)
		{
			this.IncrementWeekday();
		}
	}

	// Token: 0x0400419D RID: 16797
	[SerializeField]
	private int week;

	// Token: 0x0400419E RID: 16798
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x0400419F RID: 16799
	[SerializeField]
	private Clock clock;
}
