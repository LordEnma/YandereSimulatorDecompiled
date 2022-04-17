using System;

// Token: 0x020003F9 RID: 1017
[Serializable]
public class ApplicationSaveData
{
	// Token: 0x06001C15 RID: 7189 RVA: 0x0014884C File Offset: 0x00146A4C
	public static ApplicationSaveData ReadFromGlobals()
	{
		return new ApplicationSaveData
		{
			versionNumber = ApplicationGlobals.VersionNumber
		};
	}

	// Token: 0x06001C16 RID: 7190 RVA: 0x0014885E File Offset: 0x00146A5E
	public static void WriteToGlobals(ApplicationSaveData data)
	{
		ApplicationGlobals.VersionNumber = data.versionNumber;
	}

	// Token: 0x04003171 RID: 12657
	public float versionNumber;
}
