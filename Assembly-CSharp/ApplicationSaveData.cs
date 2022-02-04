using System;

// Token: 0x020003F2 RID: 1010
[Serializable]
public class ApplicationSaveData
{
	// Token: 0x06001BE0 RID: 7136 RVA: 0x001453AC File Offset: 0x001435AC
	public static ApplicationSaveData ReadFromGlobals()
	{
		return new ApplicationSaveData
		{
			versionNumber = ApplicationGlobals.VersionNumber
		};
	}

	// Token: 0x06001BE1 RID: 7137 RVA: 0x001453BE File Offset: 0x001435BE
	public static void WriteToGlobals(ApplicationSaveData data)
	{
		ApplicationGlobals.VersionNumber = data.versionNumber;
	}

	// Token: 0x040030E7 RID: 12519
	public float versionNumber;
}
