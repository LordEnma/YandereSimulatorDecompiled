// Decompiled with JetBrains decompiler
// Type: JsonScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class JsonScript : MonoBehaviour
{
  [SerializeField]
  private StudentJson[] students;
  [SerializeField]
  private CreditJson[] credits;
  [SerializeField]
  private TopicJson[] topics;

  private void Start()
  {
    this.students = StudentJson.LoadFromJson(StudentJson.FilePath);
    this.topics = TopicJson.LoadFromJson(TopicJson.FilePath);
    if (SceneManager.GetActiveScene().name == "SchoolScene")
    {
      StudentManagerScript objectOfType = Object.FindObjectOfType<StudentManagerScript>();
      this.ReplaceDeadTeachers(objectOfType.FirstNames, objectOfType.LastNames);
    }
    else
    {
      if (!(SceneManager.GetActiveScene().name == "CreditsScene"))
        return;
      this.credits = CreditJson.LoadFromJson(CreditJson.FilePath);
    }
  }

  public StudentJson[] Students => this.students;

  public CreditJson[] Credits => this.credits;

  public TopicJson[] Topics => this.topics;

  private void ReplaceDeadTeachers(string[] firstNames, string[] lastNames)
  {
    for (int studentID1 = 90; studentID1 < 101; ++studentID1)
    {
      if (StudentGlobals.GetStudentDead(studentID1))
      {
        StudentGlobals.SetStudentReplaced(studentID1, true);
        StudentGlobals.SetStudentDead(studentID1, false);
        string str1 = firstNames[Random.Range(0, firstNames.Length)] + " " + lastNames[Random.Range(0, lastNames.Length)];
        StudentGlobals.SetStudentName(studentID1, str1);
        StudentGlobals.SetStudentBustSize(studentID1, Random.Range(1f, 1.5f));
        int studentID2 = studentID1;
        int num = Random.Range(1, 8);
        string str2 = num.ToString();
        StudentGlobals.SetStudentHairstyle(studentID2, str2);
        float r1 = Random.Range(0.0f, 1f);
        float g1 = Random.Range(0.0f, 1f);
        float b1 = Random.Range(0.0f, 1f);
        StudentGlobals.SetStudentColor(studentID1, new Color(r1, g1, b1));
        float r2 = Random.Range(0.0f, 1f);
        float g2 = Random.Range(0.0f, 1f);
        float b2 = Random.Range(0.0f, 1f);
        StudentGlobals.SetStudentEyeColor(studentID1, new Color(r2, g2, b2));
        int studentID3 = studentID1;
        num = Random.Range(1, 7);
        string str3 = num.ToString();
        StudentGlobals.SetStudentAccessory(studentID3, str3);
      }
    }
    for (int studentID = 90; studentID < 101; ++studentID)
    {
      if (StudentGlobals.GetStudentReplaced(studentID))
      {
        StudentJson student = this.students[studentID];
        student.Name = StudentGlobals.GetStudentName(studentID);
        student.BreastSize = StudentGlobals.GetStudentBustSize(studentID);
        student.Hairstyle = StudentGlobals.GetStudentHairstyle(studentID);
        student.Accessory = StudentGlobals.GetStudentAccessory(studentID);
        if (studentID == 97)
          student.Accessory = "7";
        if (studentID == 90)
          student.Accessory = "8";
      }
    }
  }
}
