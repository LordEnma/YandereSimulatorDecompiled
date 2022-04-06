using System;

// Token: 0x020003FE RID: 1022
[Serializable]
public class DateSaveData
{
	// Token: 0x06001C20 RID: 7200 RVA: 0x00148B62 File Offset: 0x00146D62
	public static DateSaveData ReadFromGlobals()
	{
		return new DateSaveData
		{
			week = DateGlobals.Week,
			weekday = DateGlobals.Weekday
		};
	}

	// Token: 0x06001C21 RID: 7201 RVA: 0x00148B7F File Offset: 0x00146D7F
	public static void WriteToGlobals(DateSaveData data)
	{
		DateGlobals.Week = data.week;
		DateGlobals.Weekday = data.weekday;
	}

	// Token: 0x04003181 RID: 12673
	public int week;

	// Token: 0x04003182 RID: 12674
	public DayOfWeek weekday;
}
