using System;

// Token: 0x020003F7 RID: 1015
[Serializable]
public class DateSaveData
{
	// Token: 0x06001BF1 RID: 7153 RVA: 0x00145C6A File Offset: 0x00143E6A
	public static DateSaveData ReadFromGlobals()
	{
		return new DateSaveData
		{
			week = DateGlobals.Week,
			weekday = DateGlobals.Weekday
		};
	}

	// Token: 0x06001BF2 RID: 7154 RVA: 0x00145C87 File Offset: 0x00143E87
	public static void WriteToGlobals(DateSaveData data)
	{
		DateGlobals.Week = data.week;
		DateGlobals.Weekday = data.weekday;
	}

	// Token: 0x04003105 RID: 12549
	public int week;

	// Token: 0x04003106 RID: 12550
	public DayOfWeek weekday;
}
