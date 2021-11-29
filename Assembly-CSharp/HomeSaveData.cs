using System;

// Token: 0x020003F7 RID: 1015
[Serializable]
public class HomeSaveData
{
	// Token: 0x06001BE7 RID: 7143 RVA: 0x0014324D File Offset: 0x0014144D
	public static HomeSaveData ReadFromGlobals()
	{
		return new HomeSaveData
		{
			lateForSchool = HomeGlobals.LateForSchool,
			night = HomeGlobals.Night,
			startInBasement = HomeGlobals.StartInBasement
		};
	}

	// Token: 0x06001BE8 RID: 7144 RVA: 0x00143275 File Offset: 0x00141475
	public static void WriteToGlobals(HomeSaveData data)
	{
		HomeGlobals.LateForSchool = data.lateForSchool;
		HomeGlobals.Night = data.night;
		HomeGlobals.StartInBasement = data.startInBasement;
	}

	// Token: 0x040030D1 RID: 12497
	public bool lateForSchool;

	// Token: 0x040030D2 RID: 12498
	public bool night;

	// Token: 0x040030D3 RID: 12499
	public bool startInBasement;
}
