using System;

// Token: 0x020003EF RID: 1007
[Serializable]
public class ApplicationSaveData
{
	// Token: 0x06001BD4 RID: 7124 RVA: 0x00142FEC File Offset: 0x001411EC
	public static ApplicationSaveData ReadFromGlobals()
	{
		return new ApplicationSaveData
		{
			versionNumber = ApplicationGlobals.VersionNumber
		};
	}

	// Token: 0x06001BD5 RID: 7125 RVA: 0x00142FFE File Offset: 0x001411FE
	public static void WriteToGlobals(ApplicationSaveData data)
	{
		ApplicationGlobals.VersionNumber = data.versionNumber;
	}

	// Token: 0x040030CE RID: 12494
	public float versionNumber;
}
