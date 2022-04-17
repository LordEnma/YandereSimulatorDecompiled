using System;

// Token: 0x02000402 RID: 1026
[Serializable]
public class HomeSaveData
{
	// Token: 0x06001C30 RID: 7216 RVA: 0x0014936D File Offset: 0x0014756D
	public static HomeSaveData ReadFromGlobals()
	{
		return new HomeSaveData
		{
			lateForSchool = HomeGlobals.LateForSchool,
			night = HomeGlobals.Night,
			startInBasement = HomeGlobals.StartInBasement
		};
	}

	// Token: 0x06001C31 RID: 7217 RVA: 0x00149395 File Offset: 0x00147595
	public static void WriteToGlobals(HomeSaveData data)
	{
		HomeGlobals.LateForSchool = data.lateForSchool;
		HomeGlobals.Night = data.night;
		HomeGlobals.StartInBasement = data.startInBasement;
	}

	// Token: 0x0400319E RID: 12702
	public bool lateForSchool;

	// Token: 0x0400319F RID: 12703
	public bool night;

	// Token: 0x040031A0 RID: 12704
	public bool startInBasement;
}
