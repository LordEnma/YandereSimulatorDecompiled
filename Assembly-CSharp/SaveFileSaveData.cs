using System;

// Token: 0x02000408 RID: 1032
[Serializable]
public class SaveFileSaveData
{
	// Token: 0x06001C46 RID: 7238 RVA: 0x0014A40B File Offset: 0x0014860B
	public static SaveFileSaveData ReadFromGlobals()
	{
		return new SaveFileSaveData
		{
			currentSaveFile = SaveFileGlobals.CurrentSaveFile
		};
	}

	// Token: 0x06001C47 RID: 7239 RVA: 0x0014A41D File Offset: 0x0014861D
	public static void WriteToGlobals(SaveFileSaveData data)
	{
		SaveFileGlobals.CurrentSaveFile = data.currentSaveFile;
	}

	// Token: 0x040031DF RID: 12767
	public int currentSaveFile;
}
