using System;

// Token: 0x02000409 RID: 1033
[Serializable]
public class SaveFileSaveData
{
	// Token: 0x06001C4D RID: 7245 RVA: 0x0014B347 File Offset: 0x00149547
	public static SaveFileSaveData ReadFromGlobals()
	{
		return new SaveFileSaveData
		{
			currentSaveFile = SaveFileGlobals.CurrentSaveFile
		};
	}

	// Token: 0x06001C4E RID: 7246 RVA: 0x0014B359 File Offset: 0x00149559
	public static void WriteToGlobals(SaveFileSaveData data)
	{
		SaveFileGlobals.CurrentSaveFile = data.currentSaveFile;
	}

	// Token: 0x040031FC RID: 12796
	public int currentSaveFile;
}
