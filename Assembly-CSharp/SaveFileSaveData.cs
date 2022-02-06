using System;

// Token: 0x02000400 RID: 1024
[Serializable]
public class SaveFileSaveData
{
	// Token: 0x06001C0C RID: 7180 RVA: 0x001468C7 File Offset: 0x00144AC7
	public static SaveFileSaveData ReadFromGlobals()
	{
		return new SaveFileSaveData
		{
			currentSaveFile = SaveFileGlobals.CurrentSaveFile
		};
	}

	// Token: 0x06001C0D RID: 7181 RVA: 0x001468D9 File Offset: 0x00144AD9
	public static void WriteToGlobals(SaveFileSaveData data)
	{
		SaveFileGlobals.CurrentSaveFile = data.currentSaveFile;
	}

	// Token: 0x04003149 RID: 12617
	public int currentSaveFile;
}
