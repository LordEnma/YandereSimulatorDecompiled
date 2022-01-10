using System;
using UnityEngine;

// Token: 0x02000495 RID: 1173
[Serializable]
public class DateAndTime
{
	// Token: 0x06001F37 RID: 7991 RVA: 0x001B799F File Offset: 0x001B5B9F
	public DateAndTime(int week, DayOfWeek weekday, Clock clock)
	{
		this.week = week;
		this.weekday = weekday;
		this.clock = clock;
	}

	// Token: 0x170004B9 RID: 1209
	// (get) Token: 0x06001F38 RID: 7992 RVA: 0x001B79BC File Offset: 0x001B5BBC
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x170004BA RID: 1210
	// (get) Token: 0x06001F39 RID: 7993 RVA: 0x001B79C4 File Offset: 0x001B5BC4
	public DayOfWeek Weekday
	{
		get
		{
			return this.weekday;
		}
	}

	// Token: 0x170004BB RID: 1211
	// (get) Token: 0x06001F3A RID: 7994 RVA: 0x001B79CC File Offset: 0x001B5BCC
	public Clock Clock
	{
		get
		{
			return this.clock;
		}
	}

	// Token: 0x170004BC RID: 1212
	// (get) Token: 0x06001F3B RID: 7995 RVA: 0x001B79D4 File Offset: 0x001B5BD4
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

	// Token: 0x06001F3C RID: 7996 RVA: 0x001B7A0A File Offset: 0x001B5C0A
	public void IncrementWeek()
	{
		this.week++;
	}

	// Token: 0x06001F3D RID: 7997 RVA: 0x001B7A1C File Offset: 0x001B5C1C
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

	// Token: 0x06001F3E RID: 7998 RVA: 0x001B7A48 File Offset: 0x001B5C48
	public void Tick(float dt)
	{
		int hours = this.clock.Hours24;
		this.clock.Tick(dt);
		if (this.clock.Hours24 < hours)
		{
			this.IncrementWeekday();
		}
	}

	// Token: 0x04004155 RID: 16725
	[SerializeField]
	private int week;

	// Token: 0x04004156 RID: 16726
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04004157 RID: 16727
	[SerializeField]
	private Clock clock;
}
