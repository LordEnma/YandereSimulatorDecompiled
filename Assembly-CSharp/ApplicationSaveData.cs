using System;

// Token: 0x020003F1 RID: 1009
[Serializable]
public class ApplicationSaveData
{
	// Token: 0x06001BDD RID: 7133 RVA: 0x0014375C File Offset: 0x0014195C
	public static ApplicationSaveData ReadFromGlobals()
	{
		return new ApplicationSaveData
		{
			versionNumber = ApplicationGlobals.VersionNumber
		};
	}

	// Token: 0x06001BDE RID: 7134 RVA: 0x0014376E File Offset: 0x0014196E
	public static void WriteToGlobals(ApplicationSaveData data)
	{
		ApplicationGlobals.VersionNumber = data.versionNumber;
	}

	// Token: 0x040030DB RID: 12507
	public float versionNumber;
}
