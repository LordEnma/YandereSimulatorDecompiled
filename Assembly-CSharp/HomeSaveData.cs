using System;

// Token: 0x02000403 RID: 1027
[Serializable]
public class HomeSaveData
{
	// Token: 0x06001C37 RID: 7223 RVA: 0x00149BA9 File Offset: 0x00147DA9
	public static HomeSaveData ReadFromGlobals()
	{
		return new HomeSaveData
		{
			lateForSchool = HomeGlobals.LateForSchool,
			night = HomeGlobals.Night,
			startInBasement = HomeGlobals.StartInBasement
		};
	}

	// Token: 0x06001C38 RID: 7224 RVA: 0x00149BD1 File Offset: 0x00147DD1
	public static void WriteToGlobals(HomeSaveData data)
	{
		HomeGlobals.LateForSchool = data.lateForSchool;
		HomeGlobals.Night = data.night;
		HomeGlobals.StartInBasement = data.startInBasement;
	}

	// Token: 0x040031AD RID: 12717
	public bool lateForSchool;

	// Token: 0x040031AE RID: 12718
	public bool night;

	// Token: 0x040031AF RID: 12719
	public bool startInBasement;
}
