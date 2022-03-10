using System;

// Token: 0x02000402 RID: 1026
[Serializable]
public class SaveFileSaveData
{
	// Token: 0x06001C1E RID: 7198 RVA: 0x00147B7B File Offset: 0x00145D7B
	public static SaveFileSaveData ReadFromGlobals()
	{
		return new SaveFileSaveData
		{
			currentSaveFile = SaveFileGlobals.CurrentSaveFile
		};
	}

	// Token: 0x06001C1F RID: 7199 RVA: 0x00147B8D File Offset: 0x00145D8D
	public static void WriteToGlobals(SaveFileSaveData data)
	{
		SaveFileGlobals.CurrentSaveFile = data.currentSaveFile;
	}

	// Token: 0x04003175 RID: 12661
	public int currentSaveFile;
}
