using System;

// Token: 0x020003F8 RID: 1016
[Serializable]
public class HomeSaveData
{
	// Token: 0x06001BF1 RID: 7153 RVA: 0x00143F09 File Offset: 0x00142109
	public static HomeSaveData ReadFromGlobals()
	{
		return new HomeSaveData
		{
			lateForSchool = HomeGlobals.LateForSchool,
			night = HomeGlobals.Night,
			startInBasement = HomeGlobals.StartInBasement
		};
	}

	// Token: 0x06001BF2 RID: 7154 RVA: 0x00143F31 File Offset: 0x00142131
	public static void WriteToGlobals(HomeSaveData data)
	{
		HomeGlobals.LateForSchool = data.lateForSchool;
		HomeGlobals.Night = data.night;
		HomeGlobals.StartInBasement = data.startInBasement;
	}

	// Token: 0x04003102 RID: 12546
	public bool lateForSchool;

	// Token: 0x04003103 RID: 12547
	public bool night;

	// Token: 0x04003104 RID: 12548
	public bool startInBasement;
}
