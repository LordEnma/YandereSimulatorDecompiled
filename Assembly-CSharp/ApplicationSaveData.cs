using System;

// Token: 0x020003F9 RID: 1017
[Serializable]
public class ApplicationSaveData
{
	// Token: 0x06001C11 RID: 7185 RVA: 0x0014843C File Offset: 0x0014663C
	public static ApplicationSaveData ReadFromGlobals()
	{
		return new ApplicationSaveData
		{
			versionNumber = ApplicationGlobals.VersionNumber
		};
	}

	// Token: 0x06001C12 RID: 7186 RVA: 0x0014844E File Offset: 0x0014664E
	public static void WriteToGlobals(ApplicationSaveData data)
	{
		ApplicationGlobals.VersionNumber = data.versionNumber;
	}

	// Token: 0x04003166 RID: 12646
	public float versionNumber;
}
