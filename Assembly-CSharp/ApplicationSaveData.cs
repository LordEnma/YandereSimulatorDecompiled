using System;

// Token: 0x020003F4 RID: 1012
[Serializable]
public class ApplicationSaveData
{
	// Token: 0x06001BF2 RID: 7154 RVA: 0x001462BC File Offset: 0x001444BC
	public static ApplicationSaveData ReadFromGlobals()
	{
		return new ApplicationSaveData
		{
			versionNumber = ApplicationGlobals.VersionNumber
		};
	}

	// Token: 0x06001BF3 RID: 7155 RVA: 0x001462CE File Offset: 0x001444CE
	public static void WriteToGlobals(ApplicationSaveData data)
	{
		ApplicationGlobals.VersionNumber = data.versionNumber;
	}

	// Token: 0x04003100 RID: 12544
	public float versionNumber;
}
