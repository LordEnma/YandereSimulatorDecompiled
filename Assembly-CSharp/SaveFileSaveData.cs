using System;

// Token: 0x02000407 RID: 1031
[Serializable]
public class SaveFileSaveData
{
	// Token: 0x06001C3B RID: 7227 RVA: 0x001497BF File Offset: 0x001479BF
	public static SaveFileSaveData ReadFromGlobals()
	{
		return new SaveFileSaveData
		{
			currentSaveFile = SaveFileGlobals.CurrentSaveFile
		};
	}

	// Token: 0x06001C3C RID: 7228 RVA: 0x001497D1 File Offset: 0x001479D1
	public static void WriteToGlobals(SaveFileSaveData data)
	{
		SaveFileGlobals.CurrentSaveFile = data.currentSaveFile;
	}

	// Token: 0x040031C5 RID: 12741
	public int currentSaveFile;
}
