using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x02000408 RID: 1032
[Serializable]
public class SaveFile
{
	// Token: 0x06001C22 RID: 7202 RVA: 0x00147C0A File Offset: 0x00145E0A
	public SaveFile(int index)
	{
		this.data = new SaveFileData();
		this.index = index;
	}

	// Token: 0x06001C23 RID: 7203 RVA: 0x00147C24 File Offset: 0x00145E24
	private SaveFile(SaveFileData data, int index)
	{
		this.data = data;
		this.index = index;
	}

	// Token: 0x1700049F RID: 1183
	// (get) Token: 0x06001C24 RID: 7204 RVA: 0x00147C3A File Offset: 0x00145E3A
	public SaveFileData Data
	{
		get
		{
			return this.data;
		}
	}

	// Token: 0x06001C25 RID: 7205 RVA: 0x00147C42 File Offset: 0x00145E42
	public static string GetSaveFolderPath(int index)
	{
		return Path.Combine(SaveFile.SavesPath, "Save" + index.ToString());
	}

	// Token: 0x06001C26 RID: 7206 RVA: 0x00147C5F File Offset: 0x00145E5F
	private static string GetFullSaveFileName(int index)
	{
		return Path.Combine(SaveFile.GetSaveFolderPath(index), SaveFile.SaveName);
	}

	// Token: 0x170004A0 RID: 1184
	// (get) Token: 0x06001C27 RID: 7207 RVA: 0x00147C71 File Offset: 0x00145E71
	private static bool SavesFolderExists
	{
		get
		{
			return Directory.Exists(SaveFile.SavesPath);
		}
	}

	// Token: 0x06001C28 RID: 7208 RVA: 0x00147C7D File Offset: 0x00145E7D
	public static bool SaveFolderExists(int index)
	{
		return Directory.Exists(SaveFile.GetSaveFolderPath(index));
	}

	// Token: 0x06001C29 RID: 7209 RVA: 0x00147C8A File Offset: 0x00145E8A
	public static bool Exists(int index)
	{
		return File.Exists(SaveFile.GetFullSaveFileName(index));
	}

	// Token: 0x06001C2A RID: 7210 RVA: 0x00147C98 File Offset: 0x00145E98
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

	// Token: 0x06001C2B RID: 7211 RVA: 0x00147D38 File Offset: 0x00145F38
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

	// Token: 0x06001C2C RID: 7212 RVA: 0x00147DA0 File Offset: 0x00145FA0
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

	// Token: 0x06001C2D RID: 7213 RVA: 0x00147EAC File Offset: 0x001460AC
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

	// Token: 0x06001C2E RID: 7214 RVA: 0x0014800C File Offset: 0x0014620C
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

	// Token: 0x04003199 RID: 12697
	[SerializeField]
	private SaveFileData data;

	// Token: 0x0400319A RID: 12698
	[SerializeField]
	private int index;

	// Token: 0x0400319B RID: 12699
	private static readonly string SavesPath = Path.Combine(Application.persistentDataPath, "Saves");

	// Token: 0x0400319C RID: 12700
	private static readonly string SaveName = "Save.txt";
}
