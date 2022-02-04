using System;

// Token: 0x020003FB RID: 1019
[Serializable]
public class HomeSaveData
{
	// Token: 0x06001BFB RID: 7163 RVA: 0x00145ECD File Offset: 0x001440CD
	public static HomeSaveData ReadFromGlobals()
	{
		return new HomeSaveData
		{
			lateForSchool = HomeGlobals.LateForSchool,
			night = HomeGlobals.Night,
			startInBasement = HomeGlobals.StartInBasement
		};
	}

	// Token: 0x06001BFC RID: 7164 RVA: 0x00145EF5 File Offset: 0x001440F5
	public static void WriteToGlobals(HomeSaveData data)
	{
		HomeGlobals.LateForSchool = data.lateForSchool;
		HomeGlobals.Night = data.night;
		HomeGlobals.StartInBasement = data.startInBasement;
	}

	// Token: 0x04003114 RID: 12564
	public bool lateForSchool;

	// Token: 0x04003115 RID: 12565
	public bool night;

	// Token: 0x04003116 RID: 12566
	public bool startInBasement;
}
