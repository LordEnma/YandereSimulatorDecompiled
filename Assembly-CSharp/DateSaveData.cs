using System;

// Token: 0x02000400 RID: 1024
[Serializable]
public class DateSaveData
{
	// Token: 0x06001C32 RID: 7218 RVA: 0x0014A6EA File Offset: 0x001488EA
	public static DateSaveData ReadFromGlobals()
	{
		return new DateSaveData
		{
			week = DateGlobals.Week,
			weekday = DateGlobals.Weekday
		};
	}

	// Token: 0x06001C33 RID: 7219 RVA: 0x0014A707 File Offset: 0x00148907
	public static void WriteToGlobals(DateSaveData data)
	{
		DateGlobals.Week = data.week;
		DateGlobals.Weekday = data.weekday;
	}

	// Token: 0x040031B8 RID: 12728
	public int week;

	// Token: 0x040031B9 RID: 12729
	public DayOfWeek weekday;
}
