﻿using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x02000410 RID: 1040
[Serializable]
public class SaveFile
{
	// Token: 0x06001C5C RID: 7260 RVA: 0x0014B74E File Offset: 0x0014994E
	public SaveFile(int index)
	{
		this.data = new SaveFileData();
		this.index = index;
	}

	// Token: 0x06001C5D RID: 7261 RVA: 0x0014B768 File Offset: 0x00149968
	private SaveFile(SaveFileData data, int index)
	{
		this.data = data;
		this.index = index;
	}

	// Token: 0x170004A2 RID: 1186
	// (get) Token: 0x06001C5E RID: 7262 RVA: 0x0014B77E File Offset: 0x0014997E
	public SaveFileData Data
	{
		get
		{
			return this.data;
		}
	}

	// Token: 0x06001C5F RID: 7263 RVA: 0x0014B786 File Offset: 0x00149986
	public static string GetSaveFolderPath(int index)
	{
		return Path.Combine(SaveFile.SavesPath, "Save" + index.ToString());
	}

	// Token: 0x06001C60 RID: 7264 RVA: 0x0014B7A3 File Offset: 0x001499A3
	private static string GetFullSaveFileName(int index)
	{
		return Path.Combine(SaveFile.GetSaveFolderPath(index), SaveFile.SaveName);
	}

	// Token: 0x170004A3 RID: 1187
	// (get) Token: 0x06001C61 RID: 7265 RVA: 0x0014B7B5 File Offset: 0x001499B5
	private static bool SavesFolderExists
	{
		get
		{
			return Directory.Exists(SaveFile.SavesPath);
		}
	}

	// Token: 0x06001C62 RID: 7266 RVA: 0x0014B7C1 File Offset: 0x001499C1
	public static bool SaveFolderExists(int index)
	{
		return Directory.Exists(SaveFile.GetSaveFolderPath(index));
	}

	// Token: 0x06001C63 RID: 7267 RVA: 0x0014B7CE File Offset: 0x001499CE
	public static bool Exists(int index)
	{
		return File.Exists(SaveFile.GetFullSaveFileName(index));
	}

	// Token: 0x06001C64 RID: 7268 RVA: 0x0014B7DC File Offset: 0x001499DC
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

	// Token: 0x06001C65 RID: 7269 RVA: 0x0014B87C File Offset: 0x00149A7C
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

	// Token: 0x06001C66 RID: 7270 RVA: 0x0014B8E4 File Offset: 0x00149AE4
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

	// Token: 0x06001C67 RID: 7271 RVA: 0x0014B9F0 File Offset: 0x00149BF0
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

	// Token: 0x06001C68 RID: 7272 RVA: 0x0014BB50 File Offset: 0x00149D50
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

	// Token: 0x0400322F RID: 12847
	[SerializeField]
	private SaveFileData data;

	// Token: 0x04003230 RID: 12848
	[SerializeField]
	private int index;

	// Token: 0x04003231 RID: 12849
	private static readonly string SavesPath = Path.Combine(Application.persistentDataPath, "Saves");

	// Token: 0x04003232 RID: 12850
	private static readonly string SaveName = "Save.txt";
}
