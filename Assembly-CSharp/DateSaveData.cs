using System;

// Token: 0x020003FF RID: 1023
[Serializable]
public class DateSaveData
{
	// Token: 0x06001C2B RID: 7211 RVA: 0x001497AE File Offset: 0x001479AE
	public static DateSaveData ReadFromGlobals()
	{
		return new DateSaveData
		{
			week = DateGlobals.Week,
			weekday = DateGlobals.Weekday
		};
	}

	// Token: 0x06001C2C RID: 7212 RVA: 0x001497CB File Offset: 0x001479CB
	public static void WriteToGlobals(DateSaveData data)
	{
		DateGlobals.Week = data.week;
		DateGlobals.Weekday = data.weekday;
	}

	// Token: 0x0400319B RID: 12699
	public int week;

	// Token: 0x0400319C RID: 12700
	public DayOfWeek weekday;
}
