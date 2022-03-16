using System;
using UnityEngine;

// Token: 0x0200049B RID: 1179
[Serializable]
public class DateAndTime
{
	// Token: 0x06001F65 RID: 8037 RVA: 0x001BBF83 File Offset: 0x001BA183
	public DateAndTime(int week, DayOfWeek weekday, Clock clock)
	{
		this.week = week;
		this.weekday = weekday;
		this.clock = clock;
	}

	// Token: 0x170004BC RID: 1212
	// (get) Token: 0x06001F66 RID: 8038 RVA: 0x001BBFA0 File Offset: 0x001BA1A0
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x170004BD RID: 1213
	// (get) Token: 0x06001F67 RID: 8039 RVA: 0x001BBFA8 File Offset: 0x001BA1A8
	public DayOfWeek Weekday
	{
		get
		{
			return this.weekday;
		}
	}

	// Token: 0x170004BE RID: 1214
	// (get) Token: 0x06001F68 RID: 8040 RVA: 0x001BBFB0 File Offset: 0x001BA1B0
	public Clock Clock
	{
		get
		{
			return this.clock;
		}
	}

	// Token: 0x170004BF RID: 1215
	// (get) Token: 0x06001F69 RID: 8041 RVA: 0x001BBFB8 File Offset: 0x001BA1B8
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

	// Token: 0x06001F6A RID: 8042 RVA: 0x001BBFEE File Offset: 0x001BA1EE
	public void IncrementWeek()
	{
		this.week++;
	}

	// Token: 0x06001F6B RID: 8043 RVA: 0x001BC000 File Offset: 0x001BA200
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

	// Token: 0x06001F6C RID: 8044 RVA: 0x001BC02C File Offset: 0x001BA22C
	public void Tick(float dt)
	{
		int hours = this.clock.Hours24;
		this.clock.Tick(dt);
		if (this.clock.Hours24 < hours)
		{
			this.IncrementWeekday();
		}
	}

	// Token: 0x040041E8 RID: 16872
	[SerializeField]
	private int week;

	// Token: 0x040041E9 RID: 16873
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x040041EA RID: 16874
	[SerializeField]
	private Clock clock;
}
