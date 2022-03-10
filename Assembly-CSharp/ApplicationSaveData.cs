using System;

// Token: 0x020003F4 RID: 1012
[Serializable]
public class ApplicationSaveData
{
	// Token: 0x06001BF4 RID: 7156 RVA: 0x001467F8 File Offset: 0x001449F8
	public static ApplicationSaveData ReadFromGlobals()
	{
		return new ApplicationSaveData
		{
			versionNumber = ApplicationGlobals.VersionNumber
		};
	}

	// Token: 0x06001BF5 RID: 7157 RVA: 0x0014680A File Offset: 0x00144A0A
	public static void WriteToGlobals(ApplicationSaveData data)
	{
		ApplicationGlobals.VersionNumber = data.versionNumber;
	}

	// Token: 0x04003116 RID: 12566
	public float versionNumber;
}
