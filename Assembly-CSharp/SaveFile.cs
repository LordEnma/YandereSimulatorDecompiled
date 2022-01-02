using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x02000405 RID: 1029
[Serializable]
public class SaveFile
{
	// Token: 0x06001C16 RID: 7190 RVA: 0x00145AAE File Offset: 0x00143CAE
	public SaveFile(int index)
	{
		this.data = new SaveFileData();
		this.index = index;
	}

	// Token: 0x06001C17 RID: 7191 RVA: 0x00145AC8 File Offset: 0x00143CC8
	private SaveFile(SaveFileData data, int index)
	{
		this.data = data;
		this.index = index;
	}

	// Token: 0x1700049E RID: 1182
	// (get) Token: 0x06001C18 RID: 7192 RVA: 0x00145ADE File Offset: 0x00143CDE
	public SaveFileData Data
	{
		get
		{
			return this.data;
		}
	}

	// Token: 0x06001C19 RID: 7193 RVA: 0x00145AE6 File Offset: 0x00143CE6
	public static string GetSaveFolderPath(int index)
	{
		return Path.Combine(SaveFile.SavesPath, "Save" + index.ToString());
	}

	// Token: 0x06001C1A RID: 7194 RVA: 0x00145B03 File Offset: 0x00143D03
	private static string GetFullSaveFileName(int index)
	{
		return Path.Combine(SaveFile.GetSaveFolderPath(index), SaveFile.SaveName);
	}

	// Token: 0x1700049F RID: 1183
	// (get) Token: 0x06001C1B RID: 7195 RVA: 0x00145B15 File Offset: 0x00143D15
	private static bool SavesFolderExists
	{
		get
		{
			return Directory.Exists(SaveFile.SavesPath);
		}
	}

	// Token: 0x06001C1C RID: 7196 RVA: 0x00145B21 File Offset: 0x00143D21
	public static bool SaveFolderExists(int index)
	{
		return Directory.Exists(SaveFile.GetSaveFolderPath(index));
	}

	// Token: 0x06001C1D RID: 7197 RVA: 0x00145B2E File Offset: 0x00143D2E
	public static bool Exists(int index)
	{
		return File.Exists(SaveFile.GetFullSaveFileName(index));
	}

	// Token: 0x06001C1E RID: 7198 RVA: 0x00145B3C File Offset: 0x00143D3C
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

	// Token: 0x06001C1F RID: 7199 RVA: 0x00145BDC File Offset: 0x00143DDC
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

	// Token: 0x06001C20 RID: 7200 RVA: 0x00145C44 File Offset: 0x00143E44
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

	// Token: 0x06001C21 RID: 7201 RVA: 0x00145D50 File Offset: 0x00143F50
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

	// Token: 0x06001C22 RID: 7202 RVA: 0x00145EB0 File Offset: 0x001440B0
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

	// Token: 0x04003184 RID: 12676
	[SerializeField]
	private SaveFileData data;

	// Token: 0x04003185 RID: 12677
	[SerializeField]
	private int index;

	// Token: 0x04003186 RID: 12678
	private static readonly string SavesPath = Path.Combine(Application.persistentDataPath, "Saves");

	// Token: 0x04003187 RID: 12679
	private static readonly string SaveName = "Save.txt";
}
