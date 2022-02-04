using System;

// Token: 0x02000400 RID: 1024
[Serializable]
public class SaveFileSaveData
{
	// Token: 0x06001C0A RID: 7178 RVA: 0x0014672F File Offset: 0x0014492F
	public static SaveFileSaveData ReadFromGlobals()
	{
		return new SaveFileSaveData
		{
			currentSaveFile = SaveFileGlobals.CurrentSaveFile
		};
	}

	// Token: 0x06001C0B RID: 7179 RVA: 0x00146741 File Offset: 0x00144941
	public static void WriteToGlobals(SaveFileSaveData data)
	{
		SaveFileGlobals.CurrentSaveFile = data.currentSaveFile;
	}

	// Token: 0x04003146 RID: 12614
	public int currentSaveFile;
}
