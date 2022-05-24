using System;
using UnityEngine;

// Token: 0x020004A1 RID: 1185
[Serializable]
public class DateAndTime
{
	// Token: 0x06001F91 RID: 8081 RVA: 0x001C0EBF File Offset: 0x001BF0BF
	public DateAndTime(int week, DayOfWeek weekday, Clock clock)
	{
		this.week = week;
		this.weekday = weekday;
		this.clock = clock;
	}

	// Token: 0x170004BE RID: 1214
	// (get) Token: 0x06001F92 RID: 8082 RVA: 0x001C0EDC File Offset: 0x001BF0DC
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x170004BF RID: 1215
	// (get) Token: 0x06001F93 RID: 8083 RVA: 0x001C0EE4 File Offset: 0x001BF0E4
	public DayOfWeek Weekday
	{
		get
		{
			return this.weekday;
		}
	}

	// Token: 0x170004C0 RID: 1216
	// (get) Token: 0x06001F94 RID: 8084 RVA: 0x001C0EEC File Offset: 0x001BF0EC
	public Clock Clock
	{
		get
		{
			return this.clock;
		}
	}

	// Token: 0x170004C1 RID: 1217
	// (get) Token: 0x06001F95 RID: 8085 RVA: 0x001C0EF4 File Offset: 0x001BF0F4
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

	// Token: 0x06001F96 RID: 8086 RVA: 0x001C0F2A File Offset: 0x001BF12A
	public void IncrementWeek()
	{
		this.week++;
	}

	// Token: 0x06001F97 RID: 8087 RVA: 0x001C0F3C File Offset: 0x001BF13C
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

	// Token: 0x06001F98 RID: 8088 RVA: 0x001C0F68 File Offset: 0x001BF168
	public void Tick(float dt)
	{
		int hours = this.clock.Hours24;
		this.clock.Tick(dt);
		if (this.clock.Hours24 < hours)
		{
			this.IncrementWeekday();
		}
	}

	// Token: 0x04004265 RID: 16997
	[SerializeField]
	private int week;

	// Token: 0x04004266 RID: 16998
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04004267 RID: 16999
	[SerializeField]
	private Clock clock;
}
