using System;

// Token: 0x020003F6 RID: 1014
[Serializable]
public class DateSaveData
{
	// Token: 0x06001BEC RID: 7148 RVA: 0x00143E82 File Offset: 0x00142082
	public static DateSaveData ReadFromGlobals()
	{
		return new DateSaveData
		{
			week = DateGlobals.Week,
			weekday = DateGlobals.Weekday
		};
	}

	// Token: 0x06001BED RID: 7149 RVA: 0x00143E9F File Offset: 0x0014209F
	public static void WriteToGlobals(DateSaveData data)
	{
		DateGlobals.Week = data.week;
		DateGlobals.Weekday = data.weekday;
	}

	// Token: 0x040030F6 RID: 12534
	public int week;

	// Token: 0x040030F7 RID: 12535
	public DayOfWeek weekday;
}
