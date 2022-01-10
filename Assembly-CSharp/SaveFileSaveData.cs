using System;

// Token: 0x020003FF RID: 1023
[Serializable]
public class SaveFileSaveData
{
	// Token: 0x06001C07 RID: 7175 RVA: 0x00144ADF File Offset: 0x00142CDF
	public static SaveFileSaveData ReadFromGlobals()
	{
		return new SaveFileSaveData
		{
			currentSaveFile = SaveFileGlobals.CurrentSaveFile
		};
	}

	// Token: 0x06001C08 RID: 7176 RVA: 0x00144AF1 File Offset: 0x00142CF1
	public static void WriteToGlobals(SaveFileSaveData data)
	{
		SaveFileGlobals.CurrentSaveFile = data.currentSaveFile;
	}

	// Token: 0x0400313A RID: 12602
	public int currentSaveFile;
}
