using System;

// Token: 0x02000404 RID: 1028
[Serializable]
public class HomeSaveData
{
	// Token: 0x06001C3D RID: 7229 RVA: 0x0014A829 File Offset: 0x00148A29
	public static HomeSaveData ReadFromGlobals()
	{
		return new HomeSaveData
		{
			lateForSchool = HomeGlobals.LateForSchool,
			night = HomeGlobals.Night,
			startInBasement = HomeGlobals.StartInBasement
		};
	}

	// Token: 0x06001C3E RID: 7230 RVA: 0x0014A851 File Offset: 0x00148A51
	public static void WriteToGlobals(HomeSaveData data)
	{
		HomeGlobals.LateForSchool = data.lateForSchool;
		HomeGlobals.Night = data.night;
		HomeGlobals.StartInBasement = data.startInBasement;
	}

	// Token: 0x040031C2 RID: 12738
	public bool lateForSchool;

	// Token: 0x040031C3 RID: 12739
	public bool night;

	// Token: 0x040031C4 RID: 12740
	public bool startInBasement;
}
