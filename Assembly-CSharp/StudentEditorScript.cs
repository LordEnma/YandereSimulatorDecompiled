// Decompiled with JetBrains decompiler
// Type: StudentEditorScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class StudentEditorScript : MonoBehaviour
{
  [SerializeField]
  private UIPanel mainPanel;
  [SerializeField]
  private UIPanel studentPanel;
  [SerializeField]
  private UILabel bodyLabel;
  [SerializeField]
  private Transform listLabelsOrigin;
  [SerializeField]
  private UILabel studentLabelTemplate;
  [SerializeField]
  private PromptBarScript promptBar;
  private StudentEditorScript.StudentData[] students;
  private int studentIndex;
  private InputManagerScript inputManager;

  private void Awake()
  {
    Dictionary<string, object>[] dictionaryArray = EditorManagerScript.DeserializeJson("Students.json");
    this.students = new StudentEditorScript.StudentData[dictionaryArray.Length];
    for (int index = 0; index < this.students.Length; ++index)
      this.students[index] = StudentEditorScript.StudentData.Deserialize(dictionaryArray[index]);
    Array.Sort<StudentEditorScript.StudentData>(this.students, (Comparison<StudentEditorScript.StudentData>) ((a, b) => a.id - b.id));
    for (int index = 0; index < this.students.Length; ++index)
    {
      StudentEditorScript.StudentData student = this.students[index];
      UILabel uiLabel = UnityEngine.Object.Instantiate<UILabel>(this.studentLabelTemplate, this.listLabelsOrigin);
      uiLabel.text = "(" + student.id.ToString() + ") " + student.name;
      Transform transform = uiLabel.transform;
      transform.localPosition = new Vector3(transform.localPosition.x + (float) (uiLabel.width / 2), transform.localPosition.y - (float) (index * uiLabel.height), transform.localPosition.z);
      uiLabel.gameObject.SetActive(true);
    }
    this.studentIndex = 0;
    this.bodyLabel.text = StudentEditorScript.GetStudentText(this.students[this.studentIndex]);
    this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
  }

  private void OnEnable()
  {
    this.promptBar.Label[0].text = string.Empty;
    this.promptBar.Label[1].text = "Back";
    this.promptBar.UpdateButtons();
  }

  private static ScheduleBlock[] DeserializeScheduleBlocks(
    Dictionary<string, object> dict)
  {
    string[] strArray1 = TFUtils.LoadString(dict, "ScheduleTime").Split('_');
    string[] strArray2 = TFUtils.LoadString(dict, "ScheduleDestination").Split('_');
    string[] strArray3 = TFUtils.LoadString(dict, "ScheduleAction").Split('_');
    ScheduleBlock[] scheduleBlockArray = new ScheduleBlock[strArray1.Length];
    for (int index = 0; index < scheduleBlockArray.Length; ++index)
      scheduleBlockArray[index] = new ScheduleBlock(float.Parse(strArray1[index]), strArray2[index], strArray3[index]);
    return scheduleBlockArray;
  }

  private static string GetStudentText(StudentEditorScript.StudentData data)
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append(data.name + " (" + data.id.ToString() + "):\n");
    stringBuilder.Append("- Gender: " + (data.isMale ? "Male" : "Female") + "\n");
    stringBuilder.Append("- Class: " + data.attendanceInfo.classNumber.ToString() + "\n");
    stringBuilder.Append("- Seat: " + data.attendanceInfo.seatNumber.ToString() + "\n");
    stringBuilder.Append("- Club: " + data.attendanceInfo.club.ToString() + "\n");
    stringBuilder.Append("- Persona: " + data.personality.persona.ToString() + "\n");
    stringBuilder.Append("- Crush: " + data.personality.crush.ToString() + "\n");
    stringBuilder.Append("- Breast size: " + data.cosmetics.breastSize.ToString() + "\n");
    stringBuilder.Append("- Strength: " + data.stats.strength.ToString() + "\n");
    stringBuilder.Append("- Hairstyle: " + data.cosmetics.hairstyle + "\n");
    stringBuilder.Append("- Color: " + data.cosmetics.color + "\n");
    stringBuilder.Append("- Eyes: " + data.cosmetics.eyes + "\n");
    stringBuilder.Append("- Stockings: " + data.cosmetics.stockings + "\n");
    stringBuilder.Append("- Accessory: " + data.cosmetics.accessory + "\n");
    stringBuilder.Append("- Schedule blocks: ");
    foreach (ScheduleBlock scheduleBlock in data.scheduleBlocks)
      stringBuilder.Append("[" + scheduleBlock.time.ToString() + ", " + scheduleBlock.destination + ", " + scheduleBlock.action + "]");
    stringBuilder.Append("\n");
    stringBuilder.Append("- Info: \"" + data.info + "\"\n");
    return stringBuilder.ToString();
  }

  private void HandleInput()
  {
    if (Input.GetButtonDown("B"))
    {
      this.mainPanel.gameObject.SetActive(true);
      this.studentPanel.gameObject.SetActive(false);
    }
    int num1 = 0;
    int num2 = this.students.Length - 1;
    int num3 = this.inputManager.TappedUp ? 1 : 0;
    bool tappedDown = this.inputManager.TappedDown;
    if (num3 != 0)
      this.studentIndex = this.studentIndex > num1 ? this.studentIndex - 1 : num2;
    else if (tappedDown)
      this.studentIndex = this.studentIndex < num2 ? this.studentIndex + 1 : num1;
    if ((num3 | (tappedDown ? 1 : 0)) == 0)
      return;
    this.bodyLabel.text = StudentEditorScript.GetStudentText(this.students[this.studentIndex]);
  }

  private void Update() => this.HandleInput();

  private class StudentAttendanceInfo
  {
    public int classNumber;
    public int seatNumber;
    public int club;

    public static StudentEditorScript.StudentAttendanceInfo Deserialize(
      Dictionary<string, object> dict)
    {
      return new StudentEditorScript.StudentAttendanceInfo()
      {
        classNumber = TFUtils.LoadInt(dict, "Class"),
        seatNumber = TFUtils.LoadInt(dict, "Seat"),
        club = TFUtils.LoadInt(dict, "Club")
      };
    }
  }

  private class StudentPersonality
  {
    public PersonaType persona;
    public int crush;

    public static StudentEditorScript.StudentPersonality Deserialize(
      Dictionary<string, object> dict)
    {
      return new StudentEditorScript.StudentPersonality()
      {
        persona = (PersonaType) TFUtils.LoadInt(dict, "Persona"),
        crush = TFUtils.LoadInt(dict, "Crush")
      };
    }
  }

  private class StudentStats
  {
    public int strength;

    public static StudentEditorScript.StudentStats Deserialize(
      Dictionary<string, object> dict)
    {
      return new StudentEditorScript.StudentStats()
      {
        strength = TFUtils.LoadInt(dict, "Strength")
      };
    }
  }

  private class StudentCosmetics
  {
    public float breastSize;
    public string hairstyle;
    public string color;
    public string eyes;
    public string stockings;
    public string accessory;

    public static StudentEditorScript.StudentCosmetics Deserialize(
      Dictionary<string, object> dict)
    {
      return new StudentEditorScript.StudentCosmetics()
      {
        breastSize = TFUtils.LoadFloat(dict, "BreastSize"),
        hairstyle = TFUtils.LoadString(dict, "Hairstyle"),
        color = TFUtils.LoadString(dict, "Color"),
        eyes = TFUtils.LoadString(dict, "Eyes"),
        stockings = TFUtils.LoadString(dict, "Stockings"),
        accessory = TFUtils.LoadString(dict, "Accessory")
      };
    }
  }

  private class StudentData
  {
    public int id;
    public string name;
    public bool isMale;
    public StudentEditorScript.StudentAttendanceInfo attendanceInfo;
    public StudentEditorScript.StudentPersonality personality;
    public StudentEditorScript.StudentStats stats;
    public StudentEditorScript.StudentCosmetics cosmetics;
    public ScheduleBlock[] scheduleBlocks;
    public string info;

    public static StudentEditorScript.StudentData Deserialize(
      Dictionary<string, object> dict)
    {
      return new StudentEditorScript.StudentData()
      {
        id = TFUtils.LoadInt(dict, "ID"),
        name = TFUtils.LoadString(dict, "Name"),
        isMale = TFUtils.LoadInt(dict, "Gender") == 1,
        attendanceInfo = StudentEditorScript.StudentAttendanceInfo.Deserialize(dict),
        personality = StudentEditorScript.StudentPersonality.Deserialize(dict),
        stats = StudentEditorScript.StudentStats.Deserialize(dict),
        cosmetics = StudentEditorScript.StudentCosmetics.Deserialize(dict),
        scheduleBlocks = StudentEditorScript.DeserializeScheduleBlocks(dict),
        info = TFUtils.LoadString(dict, "Info")
      };
    }
  }
}
