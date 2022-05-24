using System;

// Token: 0x02000404 RID: 1028
[Serializable]
public class HomeSaveData
{
	// Token: 0x06001C3E RID: 7230 RVA: 0x0014AAE5 File Offset: 0x00148CE5
	public static HomeSaveData ReadFromGlobals()
	{
		return new HomeSaveData
		{
			lateForSchool = HomeGlobals.LateForSchool,
			night = HomeGlobals.Night,
			startInBasement = HomeGlobals.StartInBasement
		};
	}

	// Token: 0x06001C3F RID: 7231 RVA: 0x0014AB0D File Offset: 0x00148D0D
	public static void WriteToGlobals(HomeSaveData data)
	{
		HomeGlobals.LateForSchool = data.lateForSchool;
		HomeGlobals.Night = data.night;
		HomeGlobals.StartInBasement = data.startInBasement;
	}

	// Token: 0x040031CA RID: 12746
	public bool lateForSchool;

	// Token: 0x040031CB RID: 12747
	public bool night;

	// Token: 0x040031CC RID: 12748
	public bool startInBasement;
}
