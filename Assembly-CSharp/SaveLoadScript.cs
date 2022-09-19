// Decompiled with JetBrains decompiler
// Type: SaveLoadScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.IO;
using UnityEngine;

public class SaveLoadScript : MonoBehaviour
{
  public StudentScript Student;
  public string SerializedData;
  public string SaveFilePath;
  public int SaveProfile;
  public int SaveSlot;

  private void DetermineFilePath()
  {
    this.SaveProfile = GameGlobals.Profile;
    this.SaveSlot = PlayerPrefs.GetInt("SaveSlot");
    this.SaveFilePath = Application.streamingAssetsPath + "/SaveData/Profile_" + this.SaveProfile.ToString() + "/Slot_" + this.SaveSlot.ToString() + "/Student_" + this.Student.StudentID.ToString() + "_Data.txt";
  }

  public void SaveData()
  {
    this.DetermineFilePath();
    this.SerializedData = JsonUtility.ToJson((object) this.Student);
    File.WriteAllText(this.SaveFilePath, this.SerializedData);
    PlayerPrefs.SetFloat("Profile_" + this.SaveProfile.ToString() + "_Slot_" + this.SaveSlot.ToString() + "Student_" + this.Student.StudentID.ToString() + "_posX", this.transform.position.x);
    PlayerPrefs.SetFloat("Profile_" + this.SaveProfile.ToString() + "_Slot_" + this.SaveSlot.ToString() + "Student_" + this.Student.StudentID.ToString() + "_posY", this.transform.position.y);
    PlayerPrefs.SetFloat("Profile_" + this.SaveProfile.ToString() + "_Slot_" + this.SaveSlot.ToString() + "Student_" + this.Student.StudentID.ToString() + "_posZ", this.transform.position.z);
    PlayerPrefs.SetFloat("Profile_" + this.SaveProfile.ToString() + "_Slot_" + this.SaveSlot.ToString() + "Student_" + this.Student.StudentID.ToString() + "_rotX", this.transform.eulerAngles.x);
    PlayerPrefs.SetFloat("Profile_" + this.SaveProfile.ToString() + "_Slot_" + this.SaveSlot.ToString() + "Student_" + this.Student.StudentID.ToString() + "_rotY", this.transform.eulerAngles.y);
    PlayerPrefs.SetFloat("Profile_" + this.SaveProfile.ToString() + "_Slot_" + this.SaveSlot.ToString() + "Student_" + this.Student.StudentID.ToString() + "_rotZ", this.transform.eulerAngles.z);
  }

  public void LoadData()
  {
    this.DetermineFilePath();
    if (!File.Exists(this.SaveFilePath))
      return;
    this.transform.position = new Vector3(PlayerPrefs.GetFloat("Profile_" + this.SaveProfile.ToString() + "_Slot_" + this.SaveSlot.ToString() + "Student_" + this.Student.StudentID.ToString() + "_posX"), PlayerPrefs.GetFloat("Profile_" + this.SaveProfile.ToString() + "_Slot_" + this.SaveSlot.ToString() + "Student_" + this.Student.StudentID.ToString() + "_posY"), PlayerPrefs.GetFloat("Profile_" + this.SaveProfile.ToString() + "_Slot_" + this.SaveSlot.ToString() + "Student_" + this.Student.StudentID.ToString() + "_posZ"));
    this.transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat("Profile_" + this.SaveProfile.ToString() + "Slot_" + this.SaveSlot.ToString() + "Student_" + this.Student.StudentID.ToString() + "_rotX"), PlayerPrefs.GetFloat("Profile_" + this.SaveProfile.ToString() + "Slot_" + this.SaveSlot.ToString() + "Student_" + this.Student.StudentID.ToString() + "_rotY"), PlayerPrefs.GetFloat("Profile_" + this.SaveProfile.ToString() + "Slot_" + this.SaveSlot.ToString() + "Student_" + this.Student.StudentID.ToString() + "_rotZ"));
    JsonUtility.FromJsonOverwrite(File.ReadAllText(this.SaveFilePath), (object) this.Student);
  }
}
