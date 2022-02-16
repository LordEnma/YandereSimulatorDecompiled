using System;

// Token: 0x020003FC RID: 1020
[Serializable]
public class HomeSaveData
{
	// Token: 0x06001C04 RID: 7172 RVA: 0x00146365 File Offset: 0x00144565
	public static HomeSaveData ReadFromGlobals()
	{
		return new HomeSaveData
		{
			lateForSchool = HomeGlobals.LateForSchool,
			night = HomeGlobals.Night,
			startInBasement = HomeGlobals.StartInBasement
		};
	}

	// Token: 0x06001C05 RID: 7173 RVA: 0x0014638D File Offset: 0x0014458D
	public static void WriteToGlobals(HomeSaveData data)
	{
		HomeGlobals.LateForSchool = data.lateForSchool;
		HomeGlobals.Night = data.night;
		HomeGlobals.StartInBasement = data.startInBasement;
	}

	// Token: 0x0400311D RID: 12573
	public bool lateForSchool;

	// Token: 0x0400311E RID: 12574
	public bool night;

	// Token: 0x0400311F RID: 12575
	public bool startInBasement;
}
