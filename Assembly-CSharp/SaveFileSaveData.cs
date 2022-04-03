using System;

// Token: 0x02000406 RID: 1030
[Serializable]
public class SaveFileSaveData
{
	// Token: 0x06001C35 RID: 7221 RVA: 0x001494DB File Offset: 0x001476DB
	public static SaveFileSaveData ReadFromGlobals()
	{
		return new SaveFileSaveData
		{
			currentSaveFile = SaveFileGlobals.CurrentSaveFile
		};
	}

	// Token: 0x06001C36 RID: 7222 RVA: 0x001494ED File Offset: 0x001476ED
	public static void WriteToGlobals(SaveFileSaveData data)
	{
		SaveFileGlobals.CurrentSaveFile = data.currentSaveFile;
	}

	// Token: 0x040031C2 RID: 12738
	public int currentSaveFile;
}
