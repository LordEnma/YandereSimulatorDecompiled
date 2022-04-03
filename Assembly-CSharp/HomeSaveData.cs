using System;

// Token: 0x02000401 RID: 1025
[Serializable]
public class HomeSaveData
{
	// Token: 0x06001C26 RID: 7206 RVA: 0x00148C79 File Offset: 0x00146E79
	public static HomeSaveData ReadFromGlobals()
	{
		return new HomeSaveData
		{
			lateForSchool = HomeGlobals.LateForSchool,
			night = HomeGlobals.Night,
			startInBasement = HomeGlobals.StartInBasement
		};
	}

	// Token: 0x06001C27 RID: 7207 RVA: 0x00148CA1 File Offset: 0x00146EA1
	public static void WriteToGlobals(HomeSaveData data)
	{
		HomeGlobals.LateForSchool = data.lateForSchool;
		HomeGlobals.Night = data.night;
		HomeGlobals.StartInBasement = data.startInBasement;
	}

	// Token: 0x04003190 RID: 12688
	public bool lateForSchool;

	// Token: 0x04003191 RID: 12689
	public bool night;

	// Token: 0x04003192 RID: 12690
	public bool startInBasement;
}
