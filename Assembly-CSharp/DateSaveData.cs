using System;

// Token: 0x020003F9 RID: 1017
[Serializable]
public class DateSaveData
{
	// Token: 0x06001C03 RID: 7171 RVA: 0x00146F1E File Offset: 0x0014511E
	public static DateSaveData ReadFromGlobals()
	{
		return new DateSaveData
		{
			week = DateGlobals.Week,
			weekday = DateGlobals.Weekday
		};
	}

	// Token: 0x06001C04 RID: 7172 RVA: 0x00146F3B File Offset: 0x0014513B
	public static void WriteToGlobals(DateSaveData data)
	{
		DateGlobals.Week = data.week;
		DateGlobals.Weekday = data.weekday;
	}

	// Token: 0x04003131 RID: 12593
	public int week;

	// Token: 0x04003132 RID: 12594
	public DayOfWeek weekday;
}
