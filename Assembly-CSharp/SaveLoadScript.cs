using System;
using System.IO;
using UnityEngine;

// Token: 0x02000413 RID: 1043
public class SaveLoadScript : MonoBehaviour
{
	// Token: 0x06001C76 RID: 7286 RVA: 0x0014D714 File Offset: 0x0014B914
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

	// Token: 0x06001C77 RID: 7287 RVA: 0x0014D7A4 File Offset: 0x0014B9A4
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

	// Token: 0x06001C78 RID: 7288 RVA: 0x0014DA74 File Offset: 0x0014BC74
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

	// Token: 0x04003264 RID: 12900
	public StudentScript Student;

	// Token: 0x04003265 RID: 12901
	public string SerializedData;

	// Token: 0x04003266 RID: 12902
	public string SaveFilePath;

	// Token: 0x04003267 RID: 12903
	public int SaveProfile;

	// Token: 0x04003268 RID: 12904
	public int SaveSlot;
}
