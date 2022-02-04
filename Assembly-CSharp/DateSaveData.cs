using System;

// Token: 0x020003F7 RID: 1015
[Serializable]
public class DateSaveData
{
	// Token: 0x06001BEF RID: 7151 RVA: 0x00145AD2 File Offset: 0x00143CD2
	public static DateSaveData ReadFromGlobals()
	{
		return new DateSaveData
		{
			week = DateGlobals.Week,
			weekday = DateGlobals.Weekday
		};
	}

	// Token: 0x06001BF0 RID: 7152 RVA: 0x00145AEF File Offset: 0x00143CEF
	public static void WriteToGlobals(DateSaveData data)
	{
		DateGlobals.Week = data.week;
		DateGlobals.Weekday = data.weekday;
	}

	// Token: 0x04003102 RID: 12546
	public int week;

	// Token: 0x04003103 RID: 12547
	public DayOfWeek weekday;
}
