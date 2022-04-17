using System;

// Token: 0x02000407 RID: 1031
[Serializable]
public class SaveFileSaveData
{
	// Token: 0x06001C3F RID: 7231 RVA: 0x00149BCF File Offset: 0x00147DCF
	public static SaveFileSaveData ReadFromGlobals()
	{
		return new SaveFileSaveData
		{
			currentSaveFile = SaveFileGlobals.CurrentSaveFile
		};
	}

	// Token: 0x06001C40 RID: 7232 RVA: 0x00149BE1 File Offset: 0x00147DE1
	public static void WriteToGlobals(SaveFileSaveData data)
	{
		SaveFileGlobals.CurrentSaveFile = data.currentSaveFile;
	}

	// Token: 0x040031D0 RID: 12752
	public int currentSaveFile;
}
