using System;

// Token: 0x020003FF RID: 1023
[Serializable]
public class DateSaveData
{
	// Token: 0x06001C2B RID: 7211 RVA: 0x0014977A File Offset: 0x0014797A
	public static DateSaveData ReadFromGlobals()
	{
		return new DateSaveData
		{
			week = DateGlobals.Week,
			weekday = DateGlobals.Weekday
		};
	}

	// Token: 0x06001C2C RID: 7212 RVA: 0x00149797 File Offset: 0x00147997
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
