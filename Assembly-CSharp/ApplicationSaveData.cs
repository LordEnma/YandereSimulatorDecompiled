using System;

// Token: 0x020003F8 RID: 1016
[Serializable]
public class ApplicationSaveData
{
	// Token: 0x06001C0B RID: 7179 RVA: 0x00148158 File Offset: 0x00146358
	public static ApplicationSaveData ReadFromGlobals()
	{
		return new ApplicationSaveData
		{
			versionNumber = ApplicationGlobals.VersionNumber
		};
	}

	// Token: 0x06001C0C RID: 7180 RVA: 0x0014816A File Offset: 0x0014636A
	public static void WriteToGlobals(ApplicationSaveData data)
	{
		ApplicationGlobals.VersionNumber = data.versionNumber;
	}

	// Token: 0x04003163 RID: 12643
	public float versionNumber;
}
