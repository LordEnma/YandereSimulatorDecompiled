using System;

// Token: 0x020003F9 RID: 1017
[Serializable]
public class DateSaveData
{
	// Token: 0x06001C01 RID: 7169 RVA: 0x001469E2 File Offset: 0x00144BE2
	public static DateSaveData ReadFromGlobals()
	{
		return new DateSaveData
		{
			week = DateGlobals.Week,
			weekday = DateGlobals.Weekday
		};
	}

	// Token: 0x06001C02 RID: 7170 RVA: 0x001469FF File Offset: 0x00144BFF
	public static void WriteToGlobals(DateSaveData data)
	{
		DateGlobals.Week = data.week;
		DateGlobals.Weekday = data.weekday;
	}

	// Token: 0x0400311B RID: 12571
	public int week;

	// Token: 0x0400311C RID: 12572
	public DayOfWeek weekday;
}
