// Decompiled with JetBrains decompiler
// Type: StudentJson
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

[Serializable]
public class StudentJson : JsonData
{
  [SerializeField]
  private string name;
  [SerializeField]
  private string realname;
  [SerializeField]
  private int gender;
  [SerializeField]
  private int classID;
  [SerializeField]
  private int seat;
  [SerializeField]
  private ClubType club;
  [SerializeField]
  private PersonaType persona;
  [SerializeField]
  private int crush;
  [SerializeField]
  private float breastSize;
  [SerializeField]
  private int strength;
  [SerializeField]
  private string hairstyle;
  [SerializeField]
  private string color;
  [SerializeField]
  private string eyes;
  [SerializeField]
  private string eyeType;
  [SerializeField]
  private string stockings;
  [SerializeField]
  private string accessory;
  [SerializeField]
  private string info;
  [SerializeField]
  private ScheduleBlock[] scheduleBlocks;
  [SerializeField]
  private bool success;

  public static string FilePath => !GameGlobals.Eighties ? Path.Combine(JsonData.FolderPath, "Students.json") : Path.Combine(JsonData.FolderPath, "Eighties.json");

  public static StudentJson[] LoadFromJson(string path)
  {
    StudentJson[] studentJsonArray = new StudentJson[101];
    for (int index = 0; index < studentJsonArray.Length; ++index)
      studentJsonArray[index] = new StudentJson();
    foreach (Dictionary<string, object> dictionary in JsonData.Deserialize(path))
    {
      int index1 = TFUtils.LoadInt(dictionary, "ID");
      if (index1 != 0)
      {
        StudentJson studentJson = studentJsonArray[index1];
        studentJson.name = TFUtils.LoadString(dictionary, "Name");
        studentJson.realname = TFUtils.LoadString(dictionary, "RealName");
        studentJson.gender = TFUtils.LoadInt(dictionary, "Gender");
        studentJson.classID = TFUtils.LoadInt(dictionary, "Class");
        studentJson.seat = TFUtils.LoadInt(dictionary, "Seat");
        studentJson.club = (ClubType) TFUtils.LoadInt(dictionary, "Club");
        studentJson.persona = (PersonaType) TFUtils.LoadInt(dictionary, "Persona");
        studentJson.crush = TFUtils.LoadInt(dictionary, "Crush");
        studentJson.breastSize = TFUtils.LoadFloat(dictionary, "BreastSize");
        studentJson.strength = TFUtils.LoadInt(dictionary, "Strength");
        studentJson.hairstyle = TFUtils.LoadString(dictionary, "Hairstyle");
        studentJson.color = TFUtils.LoadString(dictionary, "Color");
        studentJson.eyes = TFUtils.LoadString(dictionary, "Eyes");
        studentJson.eyeType = TFUtils.LoadString(dictionary, "EyeType");
        studentJson.stockings = TFUtils.LoadString(dictionary, "Stockings");
        studentJson.accessory = TFUtils.LoadString(dictionary, "Accessory");
        studentJson.info = TFUtils.LoadString(dictionary, "Info");
        if (GameGlobals.LoveSick)
        {
          studentJson.name = studentJson.realname;
          studentJson.realname = "";
        }
        if (OptionGlobals.HighPopulation && studentJson.name == "Unknown")
          studentJson.name = "Random";
        float[] numArray = StudentJson.ConstructTempFloatArray(TFUtils.LoadString(dictionary, "ScheduleTime"));
        string[] strArray1 = StudentJson.ConstructTempStringArray(TFUtils.LoadString(dictionary, "ScheduleDestination"));
        string[] strArray2 = StudentJson.ConstructTempStringArray(TFUtils.LoadString(dictionary, "ScheduleAction"));
        studentJson.scheduleBlocks = new ScheduleBlock[numArray.Length];
        for (int index2 = 0; index2 < studentJson.scheduleBlocks.Length; ++index2)
          studentJson.scheduleBlocks[index2] = new ScheduleBlock(numArray[index2], strArray1[index2], strArray2[index2]);
        studentJson.success = true;
      }
      else
        break;
    }
    return studentJsonArray;
  }

  public string Name
  {
    get => this.name;
    set => this.name = value;
  }

  public string RealName
  {
    get => this.realname;
    set => this.realname = value;
  }

  public int Gender => this.gender;

  public int Class
  {
    get => this.classID;
    set => this.classID = value;
  }

  public int Seat
  {
    get => this.seat;
    set => this.seat = value;
  }

  public ClubType Club => this.club;

  public PersonaType Persona
  {
    get => this.persona;
    set => this.persona = value;
  }

  public int Crush => this.crush;

  public float BreastSize
  {
    get => this.breastSize;
    set => this.breastSize = value;
  }

  public int Strength
  {
    get => this.strength;
    set => this.strength = value;
  }

  public string Hairstyle
  {
    get => this.hairstyle;
    set => this.hairstyle = value;
  }

  public string Color => this.color;

  public string Eyes => this.eyes;

  public string EyeType => this.eyeType;

  public string Stockings => this.stockings;

  public string Accessory
  {
    get => this.accessory;
    set => this.accessory = value;
  }

  public string Info => this.info;

  public ScheduleBlock[] ScheduleBlocks => this.scheduleBlocks;

  public bool Success => this.success;

  private static float[] ConstructTempFloatArray(string str)
  {
    string[] strArray = str.Split('_');
    float[] numArray = new float[strArray.Length];
    for (int index = 0; index < strArray.Length; ++index)
    {
      float result;
      if (float.TryParse(strArray[index], NumberStyles.Float, (IFormatProvider) NumberFormatInfo.InvariantInfo, out result))
        numArray[index] = result;
    }
    return numArray;
  }

  private static string[] ConstructTempStringArray(string str) => str.Split('_');
}
