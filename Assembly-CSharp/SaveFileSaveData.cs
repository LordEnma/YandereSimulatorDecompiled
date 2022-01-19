using System;

// Token: 0x02000400 RID: 1024
[Serializable]
public class SaveFileSaveData
{
	// Token: 0x06001C09 RID: 7177 RVA: 0x001461E7 File Offset: 0x001443E7
	public static SaveFileSaveData ReadFromGlobals()
	{
		return new SaveFileSaveData
		{
			currentSaveFile = SaveFileGlobals.CurrentSaveFile
		};
	}

	// Token: 0x06001C0A RID: 7178 RVA: 0x001461F9 File Offset: 0x001443F9
	public static void WriteToGlobals(SaveFileSaveData data)
	{
		SaveFileGlobals.CurrentSaveFile = data.currentSaveFile;
	}

	// Token: 0x0400313F RID: 12607
	public int currentSaveFile;
}
