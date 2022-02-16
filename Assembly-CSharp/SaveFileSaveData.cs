using System;

// Token: 0x02000401 RID: 1025
[Serializable]
public class SaveFileSaveData
{
	// Token: 0x06001C13 RID: 7187 RVA: 0x00146BC7 File Offset: 0x00144DC7
	public static SaveFileSaveData ReadFromGlobals()
	{
		return new SaveFileSaveData
		{
			currentSaveFile = SaveFileGlobals.CurrentSaveFile
		};
	}

	// Token: 0x06001C14 RID: 7188 RVA: 0x00146BD9 File Offset: 0x00144DD9
	public static void WriteToGlobals(SaveFileSaveData data)
	{
		SaveFileGlobals.CurrentSaveFile = data.currentSaveFile;
	}

	// Token: 0x0400314F RID: 12623
	public int currentSaveFile;
}
