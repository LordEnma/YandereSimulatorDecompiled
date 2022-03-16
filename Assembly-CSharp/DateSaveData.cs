using System;

// Token: 0x020003FA RID: 1018
[Serializable]
public class DateSaveData
{
	// Token: 0x06001C10 RID: 7184 RVA: 0x00147DC2 File Offset: 0x00145FC2
	public static DateSaveData ReadFromGlobals()
	{
		return new DateSaveData
		{
			week = DateGlobals.Week,
			weekday = DateGlobals.Weekday
		};
	}

	// Token: 0x06001C11 RID: 7185 RVA: 0x00147DDF File Offset: 0x00145FDF
	public static void WriteToGlobals(DateSaveData data)
	{
		DateGlobals.Week = data.week;
		DateGlobals.Weekday = data.weekday;
	}

	// Token: 0x04003165 RID: 12645
	public int week;

	// Token: 0x04003166 RID: 12646
	public DayOfWeek weekday;
}
