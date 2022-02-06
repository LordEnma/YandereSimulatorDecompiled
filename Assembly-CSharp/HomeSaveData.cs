using System;

// Token: 0x020003FB RID: 1019
[Serializable]
public class HomeSaveData
{
	// Token: 0x06001BFD RID: 7165 RVA: 0x00146065 File Offset: 0x00144265
	public static HomeSaveData ReadFromGlobals()
	{
		return new HomeSaveData
		{
			lateForSchool = HomeGlobals.LateForSchool,
			night = HomeGlobals.Night,
			startInBasement = HomeGlobals.StartInBasement
		};
	}

	// Token: 0x06001BFE RID: 7166 RVA: 0x0014608D File Offset: 0x0014428D
	public static void WriteToGlobals(HomeSaveData data)
	{
		HomeGlobals.LateForSchool = data.lateForSchool;
		HomeGlobals.Night = data.night;
		HomeGlobals.StartInBasement = data.startInBasement;
	}

	// Token: 0x04003117 RID: 12567
	public bool lateForSchool;

	// Token: 0x04003118 RID: 12568
	public bool night;

	// Token: 0x04003119 RID: 12569
	public bool startInBasement;
}
