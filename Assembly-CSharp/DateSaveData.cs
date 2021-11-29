using System;

// Token: 0x020003F3 RID: 1011
[Serializable]
public class DateSaveData
{
	// Token: 0x06001BDB RID: 7131 RVA: 0x00142E52 File Offset: 0x00141052
	public static DateSaveData ReadFromGlobals()
	{
		return new DateSaveData
		{
			week = DateGlobals.Week,
			weekday = DateGlobals.Weekday
		};
	}

	// Token: 0x06001BDC RID: 7132 RVA: 0x00142E6F File Offset: 0x0014106F
	public static void WriteToGlobals(DateSaveData data)
	{
		DateGlobals.Week = data.week;
		DateGlobals.Weekday = data.weekday;
	}

	// Token: 0x040030BF RID: 12479
	public int week;

	// Token: 0x040030C0 RID: 12480
	public DayOfWeek weekday;
}
