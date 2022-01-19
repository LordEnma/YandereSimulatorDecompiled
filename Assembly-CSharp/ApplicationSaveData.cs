using System;

// Token: 0x020003F2 RID: 1010
[Serializable]
public class ApplicationSaveData
{
	// Token: 0x06001BDF RID: 7135 RVA: 0x00144E64 File Offset: 0x00143064
	public static ApplicationSaveData ReadFromGlobals()
	{
		return new ApplicationSaveData
		{
			versionNumber = ApplicationGlobals.VersionNumber
		};
	}

	// Token: 0x06001BE0 RID: 7136 RVA: 0x00144E76 File Offset: 0x00143076
	public static void WriteToGlobals(ApplicationSaveData data)
	{
		ApplicationGlobals.VersionNumber = data.versionNumber;
	}

	// Token: 0x040030E0 RID: 12512
	public float versionNumber;
}
