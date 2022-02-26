using System;

// Token: 0x020003FD RID: 1021
[Serializable]
public class HomeSaveData
{
	// Token: 0x06001C0D RID: 7181 RVA: 0x00146DDD File Offset: 0x00144FDD
	public static HomeSaveData ReadFromGlobals()
	{
		return new HomeSaveData
		{
			lateForSchool = HomeGlobals.LateForSchool,
			night = HomeGlobals.Night,
			startInBasement = HomeGlobals.StartInBasement
		};
	}

	// Token: 0x06001C0E RID: 7182 RVA: 0x00146E05 File Offset: 0x00145005
	public static void WriteToGlobals(HomeSaveData data)
	{
		HomeGlobals.LateForSchool = data.lateForSchool;
		HomeGlobals.Night = data.night;
		HomeGlobals.StartInBasement = data.startInBasement;
	}

	// Token: 0x0400312D RID: 12589
	public bool lateForSchool;

	// Token: 0x0400312E RID: 12590
	public bool night;

	// Token: 0x0400312F RID: 12591
	public bool startInBasement;
}
