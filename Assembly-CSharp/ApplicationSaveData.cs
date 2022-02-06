using System;

// Token: 0x020003F2 RID: 1010
[Serializable]
public class ApplicationSaveData
{
	// Token: 0x06001BE2 RID: 7138 RVA: 0x00145544 File Offset: 0x00143744
	public static ApplicationSaveData ReadFromGlobals()
	{
		return new ApplicationSaveData
		{
			versionNumber = ApplicationGlobals.VersionNumber
		};
	}

	// Token: 0x06001BE3 RID: 7139 RVA: 0x00145556 File Offset: 0x00143756
	public static void WriteToGlobals(ApplicationSaveData data)
	{
		ApplicationGlobals.VersionNumber = data.versionNumber;
	}

	// Token: 0x040030EA RID: 12522
	public float versionNumber;
}
