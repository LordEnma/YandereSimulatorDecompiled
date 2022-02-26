using System;
using UnityEngine;

// Token: 0x02000498 RID: 1176
[Serializable]
public class DateAndTime
{
	// Token: 0x06001F50 RID: 8016 RVA: 0x001BA063 File Offset: 0x001B8263
	public DateAndTime(int week, DayOfWeek weekday, Clock clock)
	{
		this.week = week;
		this.weekday = weekday;
		this.clock = clock;
	}

	// Token: 0x170004BB RID: 1211
	// (get) Token: 0x06001F51 RID: 8017 RVA: 0x001BA080 File Offset: 0x001B8280
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x170004BC RID: 1212
	// (get) Token: 0x06001F52 RID: 8018 RVA: 0x001BA088 File Offset: 0x001B8288
	public DayOfWeek Weekday
	{
		get
		{
			return this.weekday;
		}
	}

	// Token: 0x170004BD RID: 1213
	// (get) Token: 0x06001F53 RID: 8019 RVA: 0x001BA090 File Offset: 0x001B8290
	public Clock Clock
	{
		get
		{
			return this.clock;
		}
	}

	// Token: 0x170004BE RID: 1214
	// (get) Token: 0x06001F54 RID: 8020 RVA: 0x001BA098 File Offset: 0x001B8298
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

	// Token: 0x06001F55 RID: 8021 RVA: 0x001BA0CE File Offset: 0x001B82CE
	public void IncrementWeek()
	{
		this.week++;
	}

	// Token: 0x06001F56 RID: 8022 RVA: 0x001BA0E0 File Offset: 0x001B82E0
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

	// Token: 0x06001F57 RID: 8023 RVA: 0x001BA10C File Offset: 0x001B830C
	public void Tick(float dt)
	{
		int hours = this.clock.Hours24;
		this.clock.Tick(dt);
		if (this.clock.Hours24 < hours)
		{
			this.IncrementWeekday();
		}
	}

	// Token: 0x04004186 RID: 16774
	[SerializeField]
	private int week;

	// Token: 0x04004187 RID: 16775
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04004188 RID: 16776
	[SerializeField]
	private Clock clock;
}
