using System;

// Token: 0x020003FA RID: 1018
[Serializable]
public class ApplicationSaveData
{
	// Token: 0x06001C1C RID: 7196 RVA: 0x00149088 File Offset: 0x00147288
	public static ApplicationSaveData ReadFromGlobals()
	{
		return new ApplicationSaveData
		{
			versionNumber = ApplicationGlobals.VersionNumber
		};
	}

	// Token: 0x06001C1D RID: 7197 RVA: 0x0014909A File Offset: 0x0014729A
	public static void WriteToGlobals(ApplicationSaveData data)
	{
		ApplicationGlobals.VersionNumber = data.versionNumber;
	}

	// Token: 0x04003180 RID: 12672
	public float versionNumber;
}
