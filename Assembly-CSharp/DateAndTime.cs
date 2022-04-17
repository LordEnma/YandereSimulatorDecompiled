using System;
using UnityEngine;

// Token: 0x0200049F RID: 1183
[Serializable]
public class DateAndTime
{
	// Token: 0x06001F7D RID: 8061 RVA: 0x001BE3F3 File Offset: 0x001BC5F3
	public DateAndTime(int week, DayOfWeek weekday, Clock clock)
	{
		this.week = week;
		this.weekday = weekday;
		this.clock = clock;
	}

	// Token: 0x170004BD RID: 1213
	// (get) Token: 0x06001F7E RID: 8062 RVA: 0x001BE410 File Offset: 0x001BC610
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x170004BE RID: 1214
	// (get) Token: 0x06001F7F RID: 8063 RVA: 0x001BE418 File Offset: 0x001BC618
	public DayOfWeek Weekday
	{
		get
		{
			return this.weekday;
		}
	}

	// Token: 0x170004BF RID: 1215
	// (get) Token: 0x06001F80 RID: 8064 RVA: 0x001BE420 File Offset: 0x001BC620
	public Clock Clock
	{
		get
		{
			return this.clock;
		}
	}

	// Token: 0x170004C0 RID: 1216
	// (get) Token: 0x06001F81 RID: 8065 RVA: 0x001BE428 File Offset: 0x001BC628
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

	// Token: 0x06001F82 RID: 8066 RVA: 0x001BE45E File Offset: 0x001BC65E
	public void IncrementWeek()
	{
		this.week++;
	}

	// Token: 0x06001F83 RID: 8067 RVA: 0x001BE470 File Offset: 0x001BC670
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

	// Token: 0x06001F84 RID: 8068 RVA: 0x001BE49C File Offset: 0x001BC69C
	public void Tick(float dt)
	{
		int hours = this.clock.Hours24;
		this.clock.Tick(dt);
		if (this.clock.Hours24 < hours)
		{
			this.IncrementWeekday();
		}
	}

	// Token: 0x04004228 RID: 16936
	[SerializeField]
	private int week;

	// Token: 0x04004229 RID: 16937
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x0400422A RID: 16938
	[SerializeField]
	private Clock clock;
}
