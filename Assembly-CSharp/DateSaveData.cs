using System;

// Token: 0x020003F4 RID: 1012
[Serializable]
public class DateSaveData
{
	// Token: 0x06001BE5 RID: 7141 RVA: 0x00143B0E File Offset: 0x00141D0E
	public static DateSaveData ReadFromGlobals()
	{
		return new DateSaveData
		{
			week = DateGlobals.Week,
			weekday = DateGlobals.Weekday
		};
	}

	// Token: 0x06001BE6 RID: 7142 RVA: 0x00143B2B File Offset: 0x00141D2B
	public static void WriteToGlobals(DateSaveData data)
	{
		DateGlobals.Week = data.week;
		DateGlobals.Weekday = data.weekday;
	}

	// Token: 0x040030F0 RID: 12528
	public int week;

	// Token: 0x040030F1 RID: 12529
	public DayOfWeek weekday;
}
