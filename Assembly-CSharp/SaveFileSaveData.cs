using System;

// Token: 0x020003FD RID: 1021
[Serializable]
public class SaveFileSaveData
{
	// Token: 0x06001BFE RID: 7166 RVA: 0x0014436F File Offset: 0x0014256F
	public static SaveFileSaveData ReadFromGlobals()
	{
		return new SaveFileSaveData
		{
			currentSaveFile = SaveFileGlobals.CurrentSaveFile
		};
	}

	// Token: 0x06001BFF RID: 7167 RVA: 0x00144381 File Offset: 0x00142581
	public static void WriteToGlobals(SaveFileSaveData data)
	{
		SaveFileGlobals.CurrentSaveFile = data.currentSaveFile;
	}

	// Token: 0x0400312D RID: 12589
	public int currentSaveFile;
}
