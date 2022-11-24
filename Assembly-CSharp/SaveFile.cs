// Decompiled with JetBrains decompiler
// Type: SaveFile
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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

  public SaveFile(int index)
  {
    this.data = new SaveFileData();
    this.index = index;
  }

  private SaveFile(SaveFileData data, int index)
  {
    this.data = data;
    this.index = index;
  }

  public SaveFileData Data => this.data;

  public static string GetSaveFolderPath(int index) => Path.Combine(SaveFile.SavesPath, "Save" + index.ToString());

  private static string GetFullSaveFileName(int index) => Path.Combine(SaveFile.GetSaveFolderPath(index), SaveFile.SaveName);

  private static bool SavesFolderExists => Directory.Exists(SaveFile.SavesPath);

  public static bool SaveFolderExists(int index) => Directory.Exists(SaveFile.GetSaveFolderPath(index));

  public static bool Exists(int index) => File.Exists(SaveFile.GetFullSaveFileName(index));

  public static SaveFile Load(int index)
  {
    try
    {
      return new SaveFile((SaveFileData) new XmlSerializer(typeof (SaveFileData)).Deserialize((Stream) new MemoryStream(Encoding.UTF8.GetBytes(File.ReadAllText(SaveFile.GetFullSaveFileName(index))))), index);
    }
    catch (Exception ex)
    {
      Debug.LogError((object) ("Loading save file " + index.ToString() + " failed (" + ex.ToString() + ")."));
      return (SaveFile) null;
    }
  }

  public static void Delete(int index)
  {
    try
    {
      File.Delete(SaveFile.GetFullSaveFileName(index));
    }
    catch (Exception ex)
    {
      Debug.LogError((object) ("Deleting save file " + index.ToString() + " failed (" + ex.ToString() + ")."));
    }
  }

  public void Save()
  {
    try
    {
      if (!SaveFile.SavesFolderExists)
        Directory.CreateDirectory(SaveFile.SavesPath);
      if (!SaveFile.SaveFolderExists(this.index))
        Directory.CreateDirectory(SaveFile.GetSaveFolderPath(this.index));
      string fullSaveFileName = SaveFile.GetFullSaveFileName(this.index);
      if (!SaveFile.Exists(this.index))
        File.Create(fullSaveFileName).Dispose();
      using (XmlWriter xmlWriter = XmlWriter.Create(fullSaveFileName, new XmlWriterSettings()
      {
        Indent = true,
        IndentChars = "\t"
      }))
        new XmlSerializer(typeof (SaveFileData)).Serialize(xmlWriter, (object) this.data);
    }
    catch (Exception ex)
    {
      Debug.LogError((object) ("Saving save file " + this.index.ToString() + " failed (" + ex.ToString() + ")."));
    }
  }

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
}
