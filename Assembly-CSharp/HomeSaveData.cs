using System;

// Token: 0x020003F8 RID: 1016
[Serializable]
public class HomeSaveData
{
	// Token: 0x06001BEF RID: 7151 RVA: 0x00143B0D File Offset: 0x00141D0D
	public static HomeSaveData ReadFromGlobals()
	{
		return new HomeSaveData
		{
			lateForSchool = HomeGlobals.LateForSchool,
			night = HomeGlobals.Night,
			startInBasement = HomeGlobals.StartInBasement
		};
	}

	// Token: 0x06001BF0 RID: 7152 RVA: 0x00143B35 File Offset: 0x00141D35
	public static void WriteToGlobals(HomeSaveData data)
	{
		HomeGlobals.LateForSchool = data.lateForSchool;
		HomeGlobals.Night = data.night;
		HomeGlobals.StartInBasement = data.startInBasement;
	}

	// Token: 0x040030FB RID: 12539
	public bool lateForSchool;

	// Token: 0x040030FC RID: 12540
	public bool night;

	// Token: 0x040030FD RID: 12541
	public bool startInBasement;
}
