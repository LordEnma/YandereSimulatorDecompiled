using System;

// Token: 0x020003FC RID: 1020
[Serializable]
public class SaveFileSaveData
{
	// Token: 0x06001BF6 RID: 7158 RVA: 0x00143AAF File Offset: 0x00141CAF
	public static SaveFileSaveData ReadFromGlobals()
	{
		return new SaveFileSaveData
		{
			currentSaveFile = SaveFileGlobals.CurrentSaveFile
		};
	}

	// Token: 0x06001BF7 RID: 7159 RVA: 0x00143AC1 File Offset: 0x00141CC1
	public static void WriteToGlobals(SaveFileSaveData data)
	{
		SaveFileGlobals.CurrentSaveFile = data.currentSaveFile;
	}

	// Token: 0x04003103 RID: 12547
	public int currentSaveFile;
}
