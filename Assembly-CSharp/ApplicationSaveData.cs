using System;

// Token: 0x020003FB RID: 1019
[Serializable]
public class ApplicationSaveData
{
	// Token: 0x06001C22 RID: 7202 RVA: 0x00149D08 File Offset: 0x00147F08
	public static ApplicationSaveData ReadFromGlobals()
	{
		return new ApplicationSaveData
		{
			versionNumber = ApplicationGlobals.VersionNumber
		};
	}

	// Token: 0x06001C23 RID: 7203 RVA: 0x00149D1A File Offset: 0x00147F1A
	public static void WriteToGlobals(ApplicationSaveData data)
	{
		ApplicationGlobals.VersionNumber = data.versionNumber;
	}

	// Token: 0x04003195 RID: 12693
	public float versionNumber;
}
