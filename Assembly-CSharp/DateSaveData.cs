using System;

// Token: 0x020003F4 RID: 1012
[Serializable]
public class DateSaveData
{
	// Token: 0x06001BE3 RID: 7139 RVA: 0x00143712 File Offset: 0x00141912
	public static DateSaveData ReadFromGlobals()
	{
		return new DateSaveData
		{
			week = DateGlobals.Week,
			weekday = DateGlobals.Weekday
		};
	}

	// Token: 0x06001BE4 RID: 7140 RVA: 0x0014372F File Offset: 0x0014192F
	public static void WriteToGlobals(DateSaveData data)
	{
		DateGlobals.Week = data.week;
		DateGlobals.Weekday = data.weekday;
	}

	// Token: 0x040030E9 RID: 12521
	public int week;

	// Token: 0x040030EA RID: 12522
	public DayOfWeek weekday;
}
