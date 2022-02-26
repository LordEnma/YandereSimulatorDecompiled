using System;

// Token: 0x02000402 RID: 1026
[Serializable]
public class SaveFileSaveData
{
	// Token: 0x06001C1C RID: 7196 RVA: 0x0014763F File Offset: 0x0014583F
	public static SaveFileSaveData ReadFromGlobals()
	{
		return new SaveFileSaveData
		{
			currentSaveFile = SaveFileGlobals.CurrentSaveFile
		};
	}

	// Token: 0x06001C1D RID: 7197 RVA: 0x00147651 File Offset: 0x00145851
	public static void WriteToGlobals(SaveFileSaveData data)
	{
		SaveFileGlobals.CurrentSaveFile = data.currentSaveFile;
	}

	// Token: 0x0400315F RID: 12639
	public int currentSaveFile;
}
