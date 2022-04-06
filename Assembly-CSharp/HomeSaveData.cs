using System;

// Token: 0x02000402 RID: 1026
[Serializable]
public class HomeSaveData
{
	// Token: 0x06001C2C RID: 7212 RVA: 0x00148F5D File Offset: 0x0014715D
	public static HomeSaveData ReadFromGlobals()
	{
		return new HomeSaveData
		{
			lateForSchool = HomeGlobals.LateForSchool,
			night = HomeGlobals.Night,
			startInBasement = HomeGlobals.StartInBasement
		};
	}

	// Token: 0x06001C2D RID: 7213 RVA: 0x00148F85 File Offset: 0x00147185
	public static void WriteToGlobals(HomeSaveData data)
	{
		HomeGlobals.LateForSchool = data.lateForSchool;
		HomeGlobals.Night = data.night;
		HomeGlobals.StartInBasement = data.startInBasement;
	}

	// Token: 0x04003193 RID: 12691
	public bool lateForSchool;

	// Token: 0x04003194 RID: 12692
	public bool night;

	// Token: 0x04003195 RID: 12693
	public bool startInBasement;
}
