using System;
using System.IO;
using UnityEngine;

// Token: 0x0200040A RID: 1034
public class SaveLoadScript : MonoBehaviour
{
	// Token: 0x06001C35 RID: 7221 RVA: 0x00148C94 File Offset: 0x00146E94
	private void DetermineFilePath()
	{
		this.SaveProfile = GameGlobals.Profile;
		this.SaveSlot = PlayerPrefs.GetInt("SaveSlot");
		this.SaveFilePath = string.Concat(new string[]
		{
			Application.streamingAssetsPath,
			"/SaveData/Profile_",
			this.SaveProfile.ToString(),
			"/Slot_",
			this.SaveSlot.ToString(),
			"/Student_",
			this.Student.StudentID.ToString(),
			"_Data.txt"
		});
	}

	// Token: 0x06001C36 RID: 7222 RVA: 0x00148D24 File Offset: 0x00146F24
	public void SaveData()
	{
		this.DetermineFilePath();
		this.SerializedData = JsonUtility.ToJson(this.Student);
		File.WriteAllText(this.SaveFilePath, this.SerializedData);
		PlayerPrefs.SetFloat(string.Concat(new string[]
		{
			"Profile_",
			this.SaveProfile.ToString(),
			"_Slot_",
			this.SaveSlot.ToString(),
			"Student_",
			this.Student.StudentID.ToString(),
			"_posX"
		}), base.transform.position.x);
		PlayerPrefs.SetFloat(string.Concat(new string[]
		{
			"Profile_",
			this.SaveProfile.ToString(),
			"_Slot_",
			this.SaveSlot.ToString(),
			"Student_",
			this.Student.StudentID.ToString(),
			"_posY"
		}), base.transform.position.y);
		PlayerPrefs.SetFloat(string.Concat(new string[]
		{
			"Profile_",
			this.SaveProfile.ToString(),
			"_Slot_",
			this.SaveSlot.ToString(),
			"Student_",
			this.Student.StudentID.ToString(),
			"_posZ"
		}), base.transform.position.z);
		PlayerPrefs.SetFloat(string.Concat(new string[]
		{
			"Profile_",
			this.SaveProfile.ToString(),
			"_Slot_",
			this.SaveSlot.ToString(),
			"Student_",
			this.Student.StudentID.ToString(),
			"_rotX"
		}), base.transform.eulerAngles.x);
		PlayerPrefs.SetFloat(string.Concat(new string[]
		{
			"Profile_",
			this.SaveProfile.ToString(),
			"_Slot_",
			this.SaveSlot.ToString(),
			"Student_",
			this.Student.StudentID.ToString(),
			"_rotY"
		}), base.transform.eulerAngles.y);
		PlayerPrefs.SetFloat(string.Concat(new string[]
		{
			"Profile_",
			this.SaveProfile.ToString(),
			"_Slot_",
			this.SaveSlot.ToString(),
			"Student_",
			this.Student.StudentID.ToString(),
			"_rotZ"
		}), base.transform.eulerAngles.z);
	}

	// Token: 0x06001C37 RID: 7223 RVA: 0x00148FF4 File Offset: 0x001471F4
	public void LoadData()
	{
		this.DetermineFilePath();
		if (File.Exists(this.SaveFilePath))
		{
			base.transform.position = new Vector3(PlayerPrefs.GetFloat(string.Concat(new string[]
			{
				"Profile_",
				this.SaveProfile.ToString(),
				"_Slot_",
				this.SaveSlot.ToString(),
				"Student_",
				this.Student.StudentID.ToString(),
				"_posX"
			})), PlayerPrefs.GetFloat(string.Concat(new string[]
			{
				"Profile_",
				this.SaveProfile.ToString(),
				"_Slot_",
				this.SaveSlot.ToString(),
				"Student_",
				this.Student.StudentID.ToString(),
				"_posY"
			})), PlayerPrefs.GetFloat(string.Concat(new string[]
			{
				"Profile_",
				this.SaveProfile.ToString(),
				"_Slot_",
				this.SaveSlot.ToString(),
				"Student_",
				this.Student.StudentID.ToString(),
				"_posZ"
			})));
			base.transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat(string.Concat(new string[]
			{
				"Profile_",
				this.SaveProfile.ToString(),
				"Slot_",
				this.SaveSlot.ToString(),
				"Student_",
				this.Student.StudentID.ToString(),
				"_rotX"
			})), PlayerPrefs.GetFloat(string.Concat(new string[]
			{
				"Profile_",
				this.SaveProfile.ToString(),
				"Slot_",
				this.SaveSlot.ToString(),
				"Student_",
				this.Student.StudentID.ToString(),
				"_rotY"
			})), PlayerPrefs.GetFloat(string.Concat(new string[]
			{
				"Profile_",
				this.SaveProfile.ToString(),
				"Slot_",
				this.SaveSlot.ToString(),
				"Student_",
				this.Student.StudentID.ToString(),
				"_rotZ"
			})));
			JsonUtility.FromJsonOverwrite(File.ReadAllText(this.SaveFilePath), this.Student);
		}
	}

	// Token: 0x040031B1 RID: 12721
	public StudentScript Student;

	// Token: 0x040031B2 RID: 12722
	public string SerializedData;

	// Token: 0x040031B3 RID: 12723
	public string SaveFilePath;

	// Token: 0x040031B4 RID: 12724
	public int SaveProfile;

	// Token: 0x040031B5 RID: 12725
	public int SaveSlot;
}
