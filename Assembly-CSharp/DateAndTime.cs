using System;
using UnityEngine;

// Token: 0x020004A0 RID: 1184
[Serializable]
public class DateAndTime
{
	// Token: 0x06001F86 RID: 8070 RVA: 0x001BF7AF File Offset: 0x001BD9AF
	public DateAndTime(int week, DayOfWeek weekday, Clock clock)
	{
		this.week = week;
		this.weekday = weekday;
		this.clock = clock;
	}

	// Token: 0x170004BD RID: 1213
	// (get) Token: 0x06001F87 RID: 8071 RVA: 0x001BF7CC File Offset: 0x001BD9CC
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x170004BE RID: 1214
	// (get) Token: 0x06001F88 RID: 8072 RVA: 0x001BF7D4 File Offset: 0x001BD9D4
	public DayOfWeek Weekday
	{
		get
		{
			return this.weekday;
		}
	}

	// Token: 0x170004BF RID: 1215
	// (get) Token: 0x06001F89 RID: 8073 RVA: 0x001BF7DC File Offset: 0x001BD9DC
	public Clock Clock
	{
		get
		{
			return this.clock;
		}
	}

	// Token: 0x170004C0 RID: 1216
	// (get) Token: 0x06001F8A RID: 8074 RVA: 0x001BF7E4 File Offset: 0x001BD9E4
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

	// Token: 0x06001F8B RID: 8075 RVA: 0x001BF81A File Offset: 0x001BDA1A
	public void IncrementWeek()
	{
		this.week++;
	}

	// Token: 0x06001F8C RID: 8076 RVA: 0x001BF82C File Offset: 0x001BDA2C
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

	// Token: 0x06001F8D RID: 8077 RVA: 0x001BF858 File Offset: 0x001BDA58
	public void Tick(float dt)
	{
		int hours = this.clock.Hours24;
		this.clock.Tick(dt);
		if (this.clock.Hours24 < hours)
		{
			this.IncrementWeekday();
		}
	}

	// Token: 0x0400423E RID: 16958
	[SerializeField]
	private int week;

	// Token: 0x0400423F RID: 16959
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04004240 RID: 16960
	[SerializeField]
	private Clock clock;
}
