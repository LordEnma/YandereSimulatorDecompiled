using System;

// Token: 0x020003F3 RID: 1011
[Serializable]
public class ApplicationSaveData
{
	// Token: 0x06001BE9 RID: 7145 RVA: 0x00145844 File Offset: 0x00143A44
	public static ApplicationSaveData ReadFromGlobals()
	{
		return new ApplicationSaveData
		{
			versionNumber = ApplicationGlobals.VersionNumber
		};
	}

	// Token: 0x06001BEA RID: 7146 RVA: 0x00145856 File Offset: 0x00143A56
	public static void WriteToGlobals(ApplicationSaveData data)
	{
		ApplicationGlobals.VersionNumber = data.versionNumber;
	}

	// Token: 0x040030F0 RID: 12528
	public float versionNumber;
}
