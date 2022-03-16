using System;

// Token: 0x02000403 RID: 1027
[Serializable]
public class SaveFileSaveData
{
	// Token: 0x06001C2B RID: 7211 RVA: 0x00148A1F File Offset: 0x00146C1F
	public static SaveFileSaveData ReadFromGlobals()
	{
		return new SaveFileSaveData
		{
			currentSaveFile = SaveFileGlobals.CurrentSaveFile
		};
	}

	// Token: 0x06001C2C RID: 7212 RVA: 0x00148A31 File Offset: 0x00146C31
	public static void WriteToGlobals(SaveFileSaveData data)
	{
		SaveFileGlobals.CurrentSaveFile = data.currentSaveFile;
	}

	// Token: 0x040031A9 RID: 12713
	public int currentSaveFile;
}
