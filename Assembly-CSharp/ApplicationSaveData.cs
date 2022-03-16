using System;

// Token: 0x020003F5 RID: 1013
[Serializable]
public class ApplicationSaveData
{
	// Token: 0x06001C01 RID: 7169 RVA: 0x0014769C File Offset: 0x0014589C
	public static ApplicationSaveData ReadFromGlobals()
	{
		return new ApplicationSaveData
		{
			versionNumber = ApplicationGlobals.VersionNumber
		};
	}

	// Token: 0x06001C02 RID: 7170 RVA: 0x001476AE File Offset: 0x001458AE
	public static void WriteToGlobals(ApplicationSaveData data)
	{
		ApplicationGlobals.VersionNumber = data.versionNumber;
	}

	// Token: 0x0400314A RID: 12618
	public float versionNumber;
}
