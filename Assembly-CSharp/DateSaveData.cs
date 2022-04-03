using System;

// Token: 0x020003FD RID: 1021
[Serializable]
public class DateSaveData
{
	// Token: 0x06001C1A RID: 7194 RVA: 0x0014887E File Offset: 0x00146A7E
	public static DateSaveData ReadFromGlobals()
	{
		return new DateSaveData
		{
			week = DateGlobals.Week,
			weekday = DateGlobals.Weekday
		};
	}

	// Token: 0x06001C1B RID: 7195 RVA: 0x0014889B File Offset: 0x00146A9B
	public static void WriteToGlobals(DateSaveData data)
	{
		DateGlobals.Week = data.week;
		DateGlobals.Weekday = data.weekday;
	}

	// Token: 0x0400317E RID: 12670
	public int week;

	// Token: 0x0400317F RID: 12671
	public DayOfWeek weekday;
}
