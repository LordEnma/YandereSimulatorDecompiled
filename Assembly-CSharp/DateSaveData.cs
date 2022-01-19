using System;

// Token: 0x020003F7 RID: 1015
[Serializable]
public class DateSaveData
{
	// Token: 0x06001BEE RID: 7150 RVA: 0x0014558A File Offset: 0x0014378A
	public static DateSaveData ReadFromGlobals()
	{
		return new DateSaveData
		{
			week = DateGlobals.Week,
			weekday = DateGlobals.Weekday
		};
	}

	// Token: 0x06001BEF RID: 7151 RVA: 0x001455A7 File Offset: 0x001437A7
	public static void WriteToGlobals(DateSaveData data)
	{
		DateGlobals.Week = data.week;
		DateGlobals.Weekday = data.weekday;
	}

	// Token: 0x040030FB RID: 12539
	public int week;

	// Token: 0x040030FC RID: 12540
	public DayOfWeek weekday;
}
