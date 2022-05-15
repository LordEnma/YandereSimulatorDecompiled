using System;

// Token: 0x02000400 RID: 1024
[Serializable]
public class DateSaveData
{
	// Token: 0x06001C31 RID: 7217 RVA: 0x0014A42E File Offset: 0x0014862E
	public static DateSaveData ReadFromGlobals()
	{
		return new DateSaveData
		{
			week = DateGlobals.Week,
			weekday = DateGlobals.Weekday
		};
	}

	// Token: 0x06001C32 RID: 7218 RVA: 0x0014A44B File Offset: 0x0014864B
	public static void WriteToGlobals(DateSaveData data)
	{
		DateGlobals.Week = data.week;
		DateGlobals.Weekday = data.weekday;
	}

	// Token: 0x040031B0 RID: 12720
	public int week;

	// Token: 0x040031B1 RID: 12721
	public DayOfWeek weekday;
}
