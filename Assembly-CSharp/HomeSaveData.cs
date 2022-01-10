using System;

// Token: 0x020003FA RID: 1018
[Serializable]
public class HomeSaveData
{
	// Token: 0x06001BF8 RID: 7160 RVA: 0x0014427D File Offset: 0x0014247D
	public static HomeSaveData ReadFromGlobals()
	{
		return new HomeSaveData
		{
			lateForSchool = HomeGlobals.LateForSchool,
			night = HomeGlobals.Night,
			startInBasement = HomeGlobals.StartInBasement
		};
	}

	// Token: 0x06001BF9 RID: 7161 RVA: 0x001442A5 File Offset: 0x001424A5
	public static void WriteToGlobals(HomeSaveData data)
	{
		HomeGlobals.LateForSchool = data.lateForSchool;
		HomeGlobals.Night = data.night;
		HomeGlobals.StartInBasement = data.startInBasement;
	}

	// Token: 0x04003108 RID: 12552
	public bool lateForSchool;

	// Token: 0x04003109 RID: 12553
	public bool night;

	// Token: 0x0400310A RID: 12554
	public bool startInBasement;
}
