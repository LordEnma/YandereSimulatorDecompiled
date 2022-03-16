using System;

// Token: 0x020003FE RID: 1022
[Serializable]
public class HomeSaveData
{
	// Token: 0x06001C1C RID: 7196 RVA: 0x001481BD File Offset: 0x001463BD
	public static HomeSaveData ReadFromGlobals()
	{
		return new HomeSaveData
		{
			lateForSchool = HomeGlobals.LateForSchool,
			night = HomeGlobals.Night,
			startInBasement = HomeGlobals.StartInBasement
		};
	}

	// Token: 0x06001C1D RID: 7197 RVA: 0x001481E5 File Offset: 0x001463E5
	public static void WriteToGlobals(HomeSaveData data)
	{
		HomeGlobals.LateForSchool = data.lateForSchool;
		HomeGlobals.Night = data.night;
		HomeGlobals.StartInBasement = data.startInBasement;
	}

	// Token: 0x04003177 RID: 12663
	public bool lateForSchool;

	// Token: 0x04003178 RID: 12664
	public bool night;

	// Token: 0x04003179 RID: 12665
	public bool startInBasement;
}
