using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

[Serializable]
public class SaveFile
{
	[SerializeField]
	private SaveFileData data;

	[SerializeField]
	private int index;

	private static readonly string SavesPath = Path.Combine(Application.persistentDataPath, "Saves");

	private static readonly string SaveName = "Save.txt";

	public SaveFileData Data
	{
		get
		{
			return data;
		}
	}

	private static bool SavesFolderExists
	{
		get
		{
			return Directory.Exists(SavesPath);
		}
	}

	public SaveFile(int index)
	{
		data = new SaveFileData();
		this.index = index;
	}

	private SaveFile(SaveFileData data, int index)
	{
		this.data = data;
		this.index = index;
	}

	public static string GetSaveFolderPath(int index)
	{
		return Path.Combine(SavesPath, "Save" + index);
	}

	private static string GetFullSaveFileName(int index)
	{
		return Path.Combine(GetSaveFolderPath(index), SaveName);
	}

	public static bool SaveFolderExists(int index)
	{
		return Directory.Exists(GetSaveFolderPath(index));
	}

	public static bool Exists(int index)
	{
		return File.Exists(GetFullSaveFileName(index));
	}

	public static SaveFile Load(int index)
	{
		try
		{
			string s = File.ReadAllText(GetFullSaveFileName(index));
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveFileData));
			MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(s));
			return new SaveFile((SaveFileData)xmlSerializer.Deserialize(stream), index);
		}
		catch (Exception ex)
		{
			Debug.LogError("Loading save file " + index + " failed (" + ex.ToString() + ").");
			return null;
		}
	}

	public static void Delete(int index)
	{
		try
		{
			File.Delete(GetFullSaveFileName(index));
		}
		catch (Exception ex)
		{
			Debug.LogError("Deleting save file " + index + " failed (" + ex.ToString() + ").");
		}
	}

	public void Save()
	{
		try
		{
			if (!SavesFolderExists)
			{
				Directory.CreateDirectory(SavesPath);
			}
			if (!SaveFolderExists(index))
			{
				Directory.CreateDirectory(GetSaveFolderPath(index));
			}
			string fullSaveFileName = GetFullSaveFileName(index);
			if (!Exists(index))
			{
				File.Create(fullSaveFileName).Dispose();
			}
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveFileData));
			XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
			xmlWriterSettings.Indent = true;
			xmlWriterSettings.IndentChars = "\t";
			using (XmlWriter xmlWriter = XmlWriter.Create(fullSaveFileName, xmlWriterSettings))
			{
				xmlSerializer.Serialize(xmlWriter, data);
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("Saving save file " + index + " failed (" + ex.ToString() + ").");
		}
	}

	public void ReadFromGlobals()
	{
		data.applicationData = ApplicationSaveData.ReadFromGlobals();
		data.classData = ClassSaveData.ReadFromGlobals();
		data.clubData = ClubSaveData.ReadFromGlobals();
		data.collectibleData = CollectibleSaveData.ReadFromGlobals();
		data.conversationData = ConversationSaveData.ReadFromGlobals();
		data.dateData = DateSaveData.ReadFromGlobals();
		data.datingData = DatingSaveData.ReadFromGlobals();
		data.eventData = EventSaveData.ReadFromGlobals();
		data.gameData = GameSaveData.ReadFromGlobals();
		data.homeData = HomeSaveData.ReadFromGlobals();
		data.missionModeData = MissionModeSaveData.ReadFromGlobals();
		data.optionData = OptionSaveData.ReadFromGlobals();
		data.playerData = PlayerSaveData.ReadFromGlobals();
		data.poseModeData = PoseModeSaveData.ReadFromGlobals();
		data.saveFileData = SaveFileSaveData.ReadFromGlobals();
		data.schemeData = SchemeSaveData.ReadFromGlobals();
		data.schoolData = SchoolSaveData.ReadFromGlobals();
		data.senpaiData = SenpaiSaveData.ReadFromGlobals();
		data.studentData = StudentSaveData.ReadFromGlobals();
		data.taskData = TaskSaveData.ReadFromGlobals();
		data.yanvaniaData = YanvaniaSaveData.ReadFromGlobals();
	}

	public void WriteToGlobals()
	{
		ApplicationSaveData.WriteToGlobals(data.applicationData);
		ClassSaveData.WriteToGlobals(data.classData);
		ClubSaveData.WriteToGlobals(data.clubData);
		CollectibleSaveData.WriteToGlobals(data.collectibleData);
		ConversationSaveData.WriteToGlobals(data.conversationData);
		DateSaveData.WriteToGlobals(data.dateData);
		DatingSaveData.WriteToGlobals(data.datingData);
		EventSaveData.WriteToGlobals(data.eventData);
		GameSaveData.WriteToGlobals(data.gameData);
		HomeSaveData.WriteToGlobals(data.homeData);
		MissionModeSaveData.WriteToGlobals(data.missionModeData);
		OptionSaveData.WriteToGlobals(data.optionData);
		PlayerSaveData.WriteToGlobals(data.playerData);
		PoseModeSaveData.WriteToGlobals(data.poseModeData);
		SaveFileSaveData.WriteToGlobals(data.saveFileData);
		SchemeSaveData.WriteToGlobals(data.schemeData);
		SchoolSaveData.WriteToGlobals(data.schoolData);
		SenpaiSaveData.WriteToGlobals(data.senpaiData);
		StudentSaveData.WriteToGlobals(data.studentData);
		TaskSaveData.WriteToGlobals(data.taskData);
		YanvaniaSaveData.WriteToGlobals(data.yanvaniaData);
	}
}
