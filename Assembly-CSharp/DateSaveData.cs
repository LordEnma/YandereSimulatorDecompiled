using System;

// Token: 0x020003FE RID: 1022
[Serializable]
public class DateSaveData
{
	// Token: 0x06001C24 RID: 7204 RVA: 0x00148F72 File Offset: 0x00147172
	public static DateSaveData ReadFromGlobals()
	{
		return new DateSaveData
		{
			week = DateGlobals.Week,
			weekday = DateGlobals.Weekday
		};
	}

	// Token: 0x06001C25 RID: 7205 RVA: 0x00148F8F File Offset: 0x0014718F
	public static void WriteToGlobals(DateSaveData data)
	{
		DateGlobals.Week = data.week;
		DateGlobals.Weekday = data.weekday;
	}

	// Token: 0x0400318C RID: 12684
	public int week;

	// Token: 0x0400318D RID: 12685
	public DayOfWeek weekday;
}
