using System;

// Token: 0x020003EE RID: 1006
[Serializable]
public class ApplicationSaveData
{
	// Token: 0x06001BCC RID: 7116 RVA: 0x0014272C File Offset: 0x0014092C
	public static ApplicationSaveData ReadFromGlobals()
	{
		return new ApplicationSaveData
		{
			versionNumber = ApplicationGlobals.VersionNumber
		};
	}

	// Token: 0x06001BCD RID: 7117 RVA: 0x0014273E File Offset: 0x0014093E
	public static void WriteToGlobals(ApplicationSaveData data)
	{
		ApplicationGlobals.VersionNumber = data.versionNumber;
	}

	// Token: 0x040030A4 RID: 12452
	public float versionNumber;
}
