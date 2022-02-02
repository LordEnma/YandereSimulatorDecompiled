using System;

// Token: 0x020003FB RID: 1019
[Serializable]
public class HomeSaveData
{
	// Token: 0x06001BFB RID: 7163 RVA: 0x00145DC9 File Offset: 0x00143FC9
	public static HomeSaveData ReadFromGlobals()
	{
		return new HomeSaveData
		{
			lateForSchool = HomeGlobals.LateForSchool,
			night = HomeGlobals.Night,
			startInBasement = HomeGlobals.StartInBasement
		};
	}

	// Token: 0x06001BFC RID: 7164 RVA: 0x00145DF1 File Offset: 0x00143FF1
	public static void WriteToGlobals(HomeSaveData data)
	{
		HomeGlobals.LateForSchool = data.lateForSchool;
		HomeGlobals.Night = data.night;
		HomeGlobals.StartInBasement = data.startInBasement;
	}

	// Token: 0x04003113 RID: 12563
	public bool lateForSchool;

	// Token: 0x04003114 RID: 12564
	public bool night;

	// Token: 0x04003115 RID: 12565
	public bool startInBasement;
}
