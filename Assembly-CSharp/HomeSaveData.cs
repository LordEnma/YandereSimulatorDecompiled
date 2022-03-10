using System;

// Token: 0x020003FD RID: 1021
[Serializable]
public class HomeSaveData
{
	// Token: 0x06001C0F RID: 7183 RVA: 0x00147319 File Offset: 0x00145519
	public static HomeSaveData ReadFromGlobals()
	{
		return new HomeSaveData
		{
			lateForSchool = HomeGlobals.LateForSchool,
			night = HomeGlobals.Night,
			startInBasement = HomeGlobals.StartInBasement
		};
	}

	// Token: 0x06001C10 RID: 7184 RVA: 0x00147341 File Offset: 0x00145541
	public static void WriteToGlobals(HomeSaveData data)
	{
		HomeGlobals.LateForSchool = data.lateForSchool;
		HomeGlobals.Night = data.night;
		HomeGlobals.StartInBasement = data.startInBasement;
	}

	// Token: 0x04003143 RID: 12611
	public bool lateForSchool;

	// Token: 0x04003144 RID: 12612
	public bool night;

	// Token: 0x04003145 RID: 12613
	public bool startInBasement;
}
