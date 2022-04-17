using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x0200040F RID: 1039
[Serializable]
public class SaveFile
{
	// Token: 0x06001C55 RID: 7253 RVA: 0x0014AF12 File Offset: 0x00149112
	public SaveFile(int index)
	{
		this.data = new SaveFileData();
		this.index = index;
	}

	// Token: 0x06001C56 RID: 7254 RVA: 0x0014AF2C File Offset: 0x0014912C
	private SaveFile(SaveFileData data, int index)
	{
		this.data = data;
		this.index = index;
	}

	// Token: 0x170004A2 RID: 1186
	// (get) Token: 0x06001C57 RID: 7255 RVA: 0x0014AF42 File Offset: 0x00149142
	public SaveFileData Data
	{
		get
		{
			return this.data;
		}
	}

	// Token: 0x06001C58 RID: 7256 RVA: 0x0014AF4A File Offset: 0x0014914A
	public static string GetSaveFolderPath(int index)
	{
		return Path.Combine(SaveFile.SavesPath, "Save" + index.ToString());
	}

	// Token: 0x06001C59 RID: 7257 RVA: 0x0014AF67 File Offset: 0x00149167
	private static string GetFullSaveFileName(int index)
	{
		return Path.Combine(SaveFile.GetSaveFolderPath(index), SaveFile.SaveName);
	}

	// Token: 0x170004A3 RID: 1187
	// (get) Token: 0x06001C5A RID: 7258 RVA: 0x0014AF79 File Offset: 0x00149179
	private static bool SavesFolderExists
	{
		get
		{
			return Directory.Exists(SaveFile.SavesPath);
		}
	}

	// Token: 0x06001C5B RID: 7259 RVA: 0x0014AF85 File Offset: 0x00149185
	public static bool SaveFolderExists(int index)
	{
		return Directory.Exists(SaveFile.GetSaveFolderPath(index));
	}

	// Token: 0x06001C5C RID: 7260 RVA: 0x0014AF92 File Offset: 0x00149192
	public static bool Exists(int index)
	{
		return File.Exists(SaveFile.GetFullSaveFileName(index));
	}

	// Token: 0x06001C5D RID: 7261 RVA: 0x0014AFA0 File Offset: 0x001491A0
	public static SaveFile Load(int index)
	{
		SaveFile result;
		try
		{
			string s = File.ReadAllText(SaveFile.GetFullSaveFileName(index));
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveFileData));
			MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(s));
			result = new SaveFile((SaveFileData)xmlSerializer.Deserialize(stream), index);
		}
		catch (Exception ex)
		{
			Debug.LogError(string.Concat(new string[]
			{
				"Loading save file ",
				index.ToString(),
				" failed (",
				ex.ToString(),
				")."
			}));
			result = null;
		}
		return result;
	}

	// Token: 0x06001C5E RID: 7262 RVA: 0x0014B040 File Offset: 0x00149240
	public static void Delete(int index)
	{
		try
		{
			File.Delete(SaveFile.GetFullSaveFileName(index));
		}
		catch (Exception ex)
		{
			Debug.LogError(string.Concat(new string[]
			{
				"Deleting save file ",
				index.ToString(),
				" failed (",
				ex.ToString(),
				")."
			}));
		}
	}

	// Token: 0x06001C5F RID: 7263 RVA: 0x0014B0A8 File Offset: 0x001492A8
	public void Save()
	{
		try
		{
			if (!SaveFile.SavesFolderExists)
			{
				Directory.CreateDirectory(SaveFile.SavesPath);
			}
			if (!SaveFile.SaveFolderExists(this.index))
			{
				Directory.CreateDirectory(SaveFile.GetSaveFolderPath(this.index));
			}
			string fullSaveFileName = SaveFile.GetFullSaveFileName(this.index);
			if (!SaveFile.Exists(this.index))
			{
				File.Create(fullSaveFileName).Dispose();
			}
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveFileData));
			using (XmlWriter xmlWriter = XmlWriter.Create(fullSaveFileName, new XmlWriterSettings
			{
				Indent = true,
				IndentChars = "\t"
			}))
			{
				xmlSerializer.Serialize(xmlWriter, this.data);
			}
		}
		catch (Exception ex)
		{
			Debug.LogError(string.Concat(new string[]
			{
				"Saving save file ",
				this.index.ToString(),
				" failed (",
				ex.ToString(),
				")."
			}));
		}
	}

	// Token: 0x06001C60 RID: 7264 RVA: 0x0014B1B4 File Offset: 0x001493B4
	public void ReadFromGlobals()
	{
		this.data.applicationData = ApplicationSaveData.ReadFromGlobals();
		this.data.classData = ClassSaveData.ReadFromGlobals();
		this.data.clubData = ClubSaveData.ReadFromGlobals();
		this.data.collectibleData = CollectibleSaveData.ReadFromGlobals();
		this.data.conversationData = ConversationSaveData.ReadFromGlobals();
		this.data.dateData = DateSaveData.ReadFromGlobals();
		this.data.datingData = DatingSaveData.ReadFromGlobals();
		this.data.eventData = EventSaveData.ReadFromGlobals();
		this.data.gameData = GameSaveData.ReadFromGlobals();
		this.data.homeData = HomeSaveData.ReadFromGlobals();
		this.data.missionModeData = MissionModeSaveData.ReadFromGlobals();
		this.data.optionData = OptionSaveData.ReadFromGlobals();
		this.data.playerData = PlayerSaveData.ReadFromGlobals();
		this.data.poseModeData = PoseModeSaveData.ReadFromGlobals();
		this.data.saveFileData = SaveFileSaveData.ReadFromGlobals();
		this.data.schemeData = SchemeSaveData.ReadFromGlobals();
		this.data.schoolData = SchoolSaveData.ReadFromGlobals();
		this.data.senpaiData = SenpaiSaveData.ReadFromGlobals();
		this.data.studentData = StudentSaveData.ReadFromGlobals();
		this.data.taskData = TaskSaveData.ReadFromGlobals();
		this.data.yanvaniaData = YanvaniaSaveData.ReadFromGlobals();
	}

	// Token: 0x06001C61 RID: 7265 RVA: 0x0014B314 File Offset: 0x00149514
	public void WriteToGlobals()
	{
		ApplicationSaveData.WriteToGlobals(this.data.applicationData);
		ClassSaveData.WriteToGlobals(this.data.classData);
		ClubSaveData.WriteToGlobals(this.data.clubData);
		CollectibleSaveData.WriteToGlobals(this.data.collectibleData);
		ConversationSaveData.WriteToGlobals(this.data.conversationData);
		DateSaveData.WriteToGlobals(this.data.dateData);
		DatingSaveData.WriteToGlobals(this.data.datingData);
		EventSaveData.WriteToGlobals(this.data.eventData);
		GameSaveData.WriteToGlobals(this.data.gameData);
		HomeSaveData.WriteToGlobals(this.data.homeData);
		MissionModeSaveData.WriteToGlobals(this.data.missionModeData);
		OptionSaveData.WriteToGlobals(this.data.optionData);
		PlayerSaveData.WriteToGlobals(this.data.playerData);
		PoseModeSaveData.WriteToGlobals(this.data.poseModeData);
		SaveFileSaveData.WriteToGlobals(this.data.saveFileData);
		SchemeSaveData.WriteToGlobals(this.data.schemeData);
		SchoolSaveData.WriteToGlobals(this.data.schoolData);
		SenpaiSaveData.WriteToGlobals(this.data.senpaiData);
		StudentSaveData.WriteToGlobals(this.data.studentData);
		TaskSaveData.WriteToGlobals(this.data.taskData);
		YanvaniaSaveData.WriteToGlobals(this.data.yanvaniaData);
	}

	// Token: 0x04003220 RID: 12832
	[SerializeField]
	private SaveFileData data;

	// Token: 0x04003221 RID: 12833
	[SerializeField]
	private int index;

	// Token: 0x04003222 RID: 12834
	private static readonly string SavesPath = Path.Combine(Application.persistentDataPath, "Saves");

	// Token: 0x04003223 RID: 12835
	private static readonly string SaveName = "Save.txt";
}
