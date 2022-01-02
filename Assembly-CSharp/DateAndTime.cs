using System;
using UnityEngine;

// Token: 0x02000493 RID: 1171
[Serializable]
public class DateAndTime
{
	// Token: 0x06001F2C RID: 7980 RVA: 0x001B701F File Offset: 0x001B521F
	public DateAndTime(int week, DayOfWeek weekday, Clock clock)
	{
		this.week = week;
		this.weekday = weekday;
		this.clock = clock;
	}

	// Token: 0x170004B9 RID: 1209
	// (get) Token: 0x06001F2D RID: 7981 RVA: 0x001B703C File Offset: 0x001B523C
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x170004BA RID: 1210
	// (get) Token: 0x06001F2E RID: 7982 RVA: 0x001B7044 File Offset: 0x001B5244
	public DayOfWeek Weekday
	{
		get
		{
			return this.weekday;
		}
	}

	// Token: 0x170004BB RID: 1211
	// (get) Token: 0x06001F2F RID: 7983 RVA: 0x001B704C File Offset: 0x001B524C
	public Clock Clock
	{
		get
		{
			return this.clock;
		}
	}

	// Token: 0x170004BC RID: 1212
	// (get) Token: 0x06001F30 RID: 7984 RVA: 0x001B7054 File Offset: 0x001B5254
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

	// Token: 0x06001F31 RID: 7985 RVA: 0x001B708A File Offset: 0x001B528A
	public void IncrementWeek()
	{
		this.week++;
	}

	// Token: 0x06001F32 RID: 7986 RVA: 0x001B709C File Offset: 0x001B529C
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

	// Token: 0x06001F33 RID: 7987 RVA: 0x001B70C8 File Offset: 0x001B52C8
	public void Tick(float dt)
	{
		int hours = this.clock.Hours24;
		this.clock.Tick(dt);
		if (this.clock.Hours24 < hours)
		{
			this.IncrementWeekday();
		}
	}

	// Token: 0x04004141 RID: 16705
	[SerializeField]
	private int week;

	// Token: 0x04004142 RID: 16706
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04004143 RID: 16707
	[SerializeField]
	private Clock clock;
}
