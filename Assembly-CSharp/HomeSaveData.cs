using System;

// Token: 0x020003FB RID: 1019
[Serializable]
public class HomeSaveData
{
	// Token: 0x06001BFA RID: 7162 RVA: 0x00145985 File Offset: 0x00143B85
	public static HomeSaveData ReadFromGlobals()
	{
		return new HomeSaveData
		{
			lateForSchool = HomeGlobals.LateForSchool,
			night = HomeGlobals.Night,
			startInBasement = HomeGlobals.StartInBasement
		};
	}

	// Token: 0x06001BFB RID: 7163 RVA: 0x001459AD File Offset: 0x00143BAD
	public static void WriteToGlobals(HomeSaveData data)
	{
		HomeGlobals.LateForSchool = data.lateForSchool;
		HomeGlobals.Night = data.night;
		HomeGlobals.StartInBasement = data.startInBasement;
	}

	// Token: 0x0400310D RID: 12557
	public bool lateForSchool;

	// Token: 0x0400310E RID: 12558
	public bool night;

	// Token: 0x0400310F RID: 12559
	public bool startInBasement;
}
