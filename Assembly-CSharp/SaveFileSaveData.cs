using System;

// Token: 0x02000409 RID: 1033
[Serializable]
public class SaveFileSaveData
{
	// Token: 0x06001C4C RID: 7244 RVA: 0x0014B08B File Offset: 0x0014928B
	public static SaveFileSaveData ReadFromGlobals()
	{
		return new SaveFileSaveData
		{
			currentSaveFile = SaveFileGlobals.CurrentSaveFile
		};
	}

	// Token: 0x06001C4D RID: 7245 RVA: 0x0014B09D File Offset: 0x0014929D
	public static void WriteToGlobals(SaveFileSaveData data)
	{
		SaveFileGlobals.CurrentSaveFile = data.currentSaveFile;
	}

	// Token: 0x040031F4 RID: 12788
	public int currentSaveFile;
}
