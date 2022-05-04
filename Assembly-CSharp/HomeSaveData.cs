using System;

// Token: 0x02000403 RID: 1027
[Serializable]
public class HomeSaveData
{
	// Token: 0x06001C37 RID: 7223 RVA: 0x00149B75 File Offset: 0x00147D75
	public static HomeSaveData ReadFromGlobals()
	{
		return new HomeSaveData
		{
			lateForSchool = HomeGlobals.LateForSchool,
			night = HomeGlobals.Night,
			startInBasement = HomeGlobals.StartInBasement
		};
	}

	// Token: 0x06001C38 RID: 7224 RVA: 0x00149B9D File Offset: 0x00147D9D
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
