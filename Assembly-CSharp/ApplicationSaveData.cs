using System;

// Token: 0x020003FB RID: 1019
[Serializable]
public class ApplicationSaveData
{
	// Token: 0x06001C23 RID: 7203 RVA: 0x00149FC4 File Offset: 0x001481C4
	public static ApplicationSaveData ReadFromGlobals()
	{
		return new ApplicationSaveData
		{
			versionNumber = ApplicationGlobals.VersionNumber
		};
	}

	// Token: 0x06001C24 RID: 7204 RVA: 0x00149FD6 File Offset: 0x001481D6
	public static void WriteToGlobals(ApplicationSaveData data)
	{
		ApplicationGlobals.VersionNumber = data.versionNumber;
	}

	// Token: 0x0400319D RID: 12701
	public float versionNumber;
}
