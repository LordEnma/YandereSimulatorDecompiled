using System;
using UnityEngine;

// Token: 0x02000496 RID: 1174
[Serializable]
public class DateAndTime
{
	// Token: 0x06001F39 RID: 7993 RVA: 0x001B866F File Offset: 0x001B686F
	public DateAndTime(int week, DayOfWeek weekday, Clock clock)
	{
		this.week = week;
		this.weekday = weekday;
		this.clock = clock;
	}

	// Token: 0x170004B9 RID: 1209
	// (get) Token: 0x06001F3A RID: 7994 RVA: 0x001B868C File Offset: 0x001B688C
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x170004BA RID: 1210
	// (get) Token: 0x06001F3B RID: 7995 RVA: 0x001B8694 File Offset: 0x001B6894
	public DayOfWeek Weekday
	{
		get
		{
			return this.weekday;
		}
	}

	// Token: 0x170004BB RID: 1211
	// (get) Token: 0x06001F3C RID: 7996 RVA: 0x001B869C File Offset: 0x001B689C
	public Clock Clock
	{
		get
		{
			return this.clock;
		}
	}

	// Token: 0x170004BC RID: 1212
	// (get) Token: 0x06001F3D RID: 7997 RVA: 0x001B86A4 File Offset: 0x001B68A4
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

	// Token: 0x06001F3E RID: 7998 RVA: 0x001B86DA File Offset: 0x001B68DA
	public void IncrementWeek()
	{
		this.week++;
	}

	// Token: 0x06001F3F RID: 7999 RVA: 0x001B86EC File Offset: 0x001B68EC
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

	// Token: 0x06001F40 RID: 8000 RVA: 0x001B8718 File Offset: 0x001B6918
	public void Tick(float dt)
	{
		int hours = this.clock.Hours24;
		this.clock.Tick(dt);
		if (this.clock.Hours24 < hours)
		{
			this.IncrementWeekday();
		}
	}

	// Token: 0x0400415C RID: 16732
	[SerializeField]
	private int week;

	// Token: 0x0400415D RID: 16733
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x0400415E RID: 16734
	[SerializeField]
	private Clock clock;
}
