using System;
using UnityEngine;

// Token: 0x0200049F RID: 1183
[Serializable]
public class DateAndTime
{
	// Token: 0x06001F77 RID: 8055 RVA: 0x001BDA17 File Offset: 0x001BBC17
	public DateAndTime(int week, DayOfWeek weekday, Clock clock)
	{
		this.week = week;
		this.weekday = weekday;
		this.clock = clock;
	}

	// Token: 0x170004BC RID: 1212
	// (get) Token: 0x06001F78 RID: 8056 RVA: 0x001BDA34 File Offset: 0x001BBC34
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x170004BD RID: 1213
	// (get) Token: 0x06001F79 RID: 8057 RVA: 0x001BDA3C File Offset: 0x001BBC3C
	public DayOfWeek Weekday
	{
		get
		{
			return this.weekday;
		}
	}

	// Token: 0x170004BE RID: 1214
	// (get) Token: 0x06001F7A RID: 8058 RVA: 0x001BDA44 File Offset: 0x001BBC44
	public Clock Clock
	{
		get
		{
			return this.clock;
		}
	}

	// Token: 0x170004BF RID: 1215
	// (get) Token: 0x06001F7B RID: 8059 RVA: 0x001BDA4C File Offset: 0x001BBC4C
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

	// Token: 0x06001F7C RID: 8060 RVA: 0x001BDA82 File Offset: 0x001BBC82
	public void IncrementWeek()
	{
		this.week++;
	}

	// Token: 0x06001F7D RID: 8061 RVA: 0x001BDA94 File Offset: 0x001BBC94
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

	// Token: 0x06001F7E RID: 8062 RVA: 0x001BDAC0 File Offset: 0x001BBCC0
	public void Tick(float dt)
	{
		int hours = this.clock.Hours24;
		this.clock.Tick(dt);
		if (this.clock.Hours24 < hours)
		{
			this.IncrementWeekday();
		}
	}

	// Token: 0x04004218 RID: 16920
	[SerializeField]
	private int week;

	// Token: 0x04004219 RID: 16921
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x0400421A RID: 16922
	[SerializeField]
	private Clock clock;
}
