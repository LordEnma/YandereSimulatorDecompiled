using System;

// Token: 0x020003FD RID: 1021
[Serializable]
public class SaveFileSaveData
{
	// Token: 0x06001C00 RID: 7168 RVA: 0x0014476B File Offset: 0x0014296B
	public static SaveFileSaveData ReadFromGlobals()
	{
		return new SaveFileSaveData
		{
			currentSaveFile = SaveFileGlobals.CurrentSaveFile
		};
	}

	// Token: 0x06001C01 RID: 7169 RVA: 0x0014477D File Offset: 0x0014297D
	public static void WriteToGlobals(SaveFileSaveData data)
	{
		SaveFileGlobals.CurrentSaveFile = data.currentSaveFile;
	}

	// Token: 0x04003134 RID: 12596
	public int currentSaveFile;
}
