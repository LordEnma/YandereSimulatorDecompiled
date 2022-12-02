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
		SaveProfile = GameGlobals.Profile;
		SaveSlot = PlayerPrefs.GetInt("SaveSlot");
		SaveFilePath = Application.streamingAssetsPath + "/SaveData/Profile_" + SaveProfile + "/Slot_" + SaveSlot + "/Student_" + Student.StudentID + "_Data.txt";
	}

	public void SaveData()
	{
		DetermineFilePath();
		SerializedData = JsonUtility.ToJson(Student);
		File.WriteAllText(SaveFilePath, SerializedData);
		PlayerPrefs.SetFloat("Profile_" + SaveProfile + "_Slot_" + SaveSlot + "Student_" + Student.StudentID + "_posX", base.transform.position.x);
		PlayerPrefs.SetFloat("Profile_" + SaveProfile + "_Slot_" + SaveSlot + "Student_" + Student.StudentID + "_posY", base.transform.position.y);
		PlayerPrefs.SetFloat("Profile_" + SaveProfile + "_Slot_" + SaveSlot + "Student_" + Student.StudentID + "_posZ", base.transform.position.z);
		PlayerPrefs.SetFloat("Profile_" + SaveProfile + "_Slot_" + SaveSlot + "Student_" + Student.StudentID + "_rotX", base.transform.eulerAngles.x);
		PlayerPrefs.SetFloat("Profile_" + SaveProfile + "_Slot_" + SaveSlot + "Student_" + Student.StudentID + "_rotY", base.transform.eulerAngles.y);
		PlayerPrefs.SetFloat("Profile_" + SaveProfile + "_Slot_" + SaveSlot + "Student_" + Student.StudentID + "_rotZ", base.transform.eulerAngles.z);
	}

	public void LoadData()
	{
		DetermineFilePath();
		if (File.Exists(SaveFilePath))
		{
			base.transform.position = new Vector3(PlayerPrefs.GetFloat("Profile_" + SaveProfile + "_Slot_" + SaveSlot + "Student_" + Student.StudentID + "_posX"), PlayerPrefs.GetFloat("Profile_" + SaveProfile + "_Slot_" + SaveSlot + "Student_" + Student.StudentID + "_posY"), PlayerPrefs.GetFloat("Profile_" + SaveProfile + "_Slot_" + SaveSlot + "Student_" + Student.StudentID + "_posZ"));
			base.transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat("Profile_" + SaveProfile + "Slot_" + SaveSlot + "Student_" + Student.StudentID + "_rotX"), PlayerPrefs.GetFloat("Profile_" + SaveProfile + "Slot_" + SaveSlot + "Student_" + Student.StudentID + "_rotY"), PlayerPrefs.GetFloat("Profile_" + SaveProfile + "Slot_" + SaveSlot + "Student_" + Student.StudentID + "_rotZ"));
			JsonUtility.FromJsonOverwrite(File.ReadAllText(SaveFilePath), Student);
		}
	}
}
