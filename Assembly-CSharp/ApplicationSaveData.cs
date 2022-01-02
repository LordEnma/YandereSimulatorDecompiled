using System;

// Token: 0x020003EF RID: 1007
[Serializable]
public class ApplicationSaveData
{
	// Token: 0x06001BD6 RID: 7126 RVA: 0x001433E8 File Offset: 0x001415E8
	public static ApplicationSaveData ReadFromGlobals()
	{
		return new ApplicationSaveData
		{
			versionNumber = ApplicationGlobals.VersionNumber
		};
	}

	// Token: 0x06001BD7 RID: 7127 RVA: 0x001433FA File Offset: 0x001415FA
	public static void WriteToGlobals(ApplicationSaveData data)
	{
		ApplicationGlobals.VersionNumber = data.versionNumber;
	}

	// Token: 0x040030D5 RID: 12501
	public float versionNumber;
}
