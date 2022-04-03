using System;
using UnityEngine;

// Token: 0x0200049E RID: 1182
[Serializable]
public class DateAndTime
{
	// Token: 0x06001F6F RID: 8047 RVA: 0x001BD50F File Offset: 0x001BB70F
	public DateAndTime(int week, DayOfWeek weekday, Clock clock)
	{
		this.week = week;
		this.weekday = weekday;
		this.clock = clock;
	}

	// Token: 0x170004BC RID: 1212
	// (get) Token: 0x06001F70 RID: 8048 RVA: 0x001BD52C File Offset: 0x001BB72C
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x170004BD RID: 1213
	// (get) Token: 0x06001F71 RID: 8049 RVA: 0x001BD534 File Offset: 0x001BB734
	public DayOfWeek Weekday
	{
		get
		{
			return this.weekday;
		}
	}

	// Token: 0x170004BE RID: 1214
	// (get) Token: 0x06001F72 RID: 8050 RVA: 0x001BD53C File Offset: 0x001BB73C
	public Clock Clock
	{
		get
		{
			return this.clock;
		}
	}

	// Token: 0x170004BF RID: 1215
	// (get) Token: 0x06001F73 RID: 8051 RVA: 0x001BD544 File Offset: 0x001BB744
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

	// Token: 0x06001F74 RID: 8052 RVA: 0x001BD57A File Offset: 0x001BB77A
	public void IncrementWeek()
	{
		this.week++;
	}

	// Token: 0x06001F75 RID: 8053 RVA: 0x001BD58C File Offset: 0x001BB78C
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

	// Token: 0x06001F76 RID: 8054 RVA: 0x001BD5B8 File Offset: 0x001BB7B8
	public void Tick(float dt)
	{
		int hours = this.clock.Hours24;
		this.clock.Tick(dt);
		if (this.clock.Hours24 < hours)
		{
			this.IncrementWeekday();
		}
	}

	// Token: 0x04004215 RID: 16917
	[SerializeField]
	private int week;

	// Token: 0x04004216 RID: 16918
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04004217 RID: 16919
	[SerializeField]
	private Clock clock;
}
