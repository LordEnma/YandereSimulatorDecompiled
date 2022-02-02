using System;

// Token: 0x02000400 RID: 1024
[Serializable]
public class SaveFileSaveData
{
	// Token: 0x06001C0A RID: 7178 RVA: 0x0014662B File Offset: 0x0014482B
	public static SaveFileSaveData ReadFromGlobals()
	{
		return new SaveFileSaveData
		{
			currentSaveFile = SaveFileGlobals.CurrentSaveFile
		};
	}

	// Token: 0x06001C0B RID: 7179 RVA: 0x0014663D File Offset: 0x0014483D
	public static void WriteToGlobals(SaveFileSaveData data)
	{
		SaveFileGlobals.CurrentSaveFile = data.currentSaveFile;
	}

	// Token: 0x04003145 RID: 12613
	public int currentSaveFile;
}
