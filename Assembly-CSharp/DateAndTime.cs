using System;
using UnityEngine;

// Token: 0x02000493 RID: 1171
[Serializable]
public class DateAndTime
{
	// Token: 0x06001F29 RID: 7977 RVA: 0x001B6B47 File Offset: 0x001B4D47
	public DateAndTime(int week, DayOfWeek weekday, Clock clock)
	{
		this.week = week;
		this.weekday = weekday;
		this.clock = clock;
	}

	// Token: 0x170004B8 RID: 1208
	// (get) Token: 0x06001F2A RID: 7978 RVA: 0x001B6B64 File Offset: 0x001B4D64
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x170004B9 RID: 1209
	// (get) Token: 0x06001F2B RID: 7979 RVA: 0x001B6B6C File Offset: 0x001B4D6C
	public DayOfWeek Weekday
	{
		get
		{
			return this.weekday;
		}
	}

	// Token: 0x170004BA RID: 1210
	// (get) Token: 0x06001F2C RID: 7980 RVA: 0x001B6B74 File Offset: 0x001B4D74
	public Clock Clock
	{
		get
		{
			return this.clock;
		}
	}

	// Token: 0x170004BB RID: 1211
	// (get) Token: 0x06001F2D RID: 7981 RVA: 0x001B6B7C File Offset: 0x001B4D7C
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

	// Token: 0x06001F2E RID: 7982 RVA: 0x001B6BB2 File Offset: 0x001B4DB2
	public void IncrementWeek()
	{
		this.week++;
	}

	// Token: 0x06001F2F RID: 7983 RVA: 0x001B6BC4 File Offset: 0x001B4DC4
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

	// Token: 0x06001F30 RID: 7984 RVA: 0x001B6BF0 File Offset: 0x001B4DF0
	public void Tick(float dt)
	{
		int hours = this.clock.Hours24;
		this.clock.Tick(dt);
		if (this.clock.Hours24 < hours)
		{
			this.IncrementWeekday();
		}
	}

	// Token: 0x0400413A RID: 16698
	[SerializeField]
	private int week;

	// Token: 0x0400413B RID: 16699
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x0400413C RID: 16700
	[SerializeField]
	private Clock clock;
}
