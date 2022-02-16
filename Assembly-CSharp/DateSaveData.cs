using System;

// Token: 0x020003F8 RID: 1016
[Serializable]
public class DateSaveData
{
	// Token: 0x06001BF8 RID: 7160 RVA: 0x00145F6A File Offset: 0x0014416A
	public static DateSaveData ReadFromGlobals()
	{
		return new DateSaveData
		{
			week = DateGlobals.Week,
			weekday = DateGlobals.Weekday
		};
	}

	// Token: 0x06001BF9 RID: 7161 RVA: 0x00145F87 File Offset: 0x00144187
	public static void WriteToGlobals(DateSaveData data)
	{
		DateGlobals.Week = data.week;
		DateGlobals.Weekday = data.weekday;
	}

	// Token: 0x0400310B RID: 12555
	public int week;

	// Token: 0x0400310C RID: 12556
	public DayOfWeek weekday;
}
