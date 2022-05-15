using System;
using System.IO;
using UnityEngine;

// Token: 0x02000413 RID: 1043
public class SaveLoadScript : MonoBehaviour
{
	// Token: 0x06001C75 RID: 7285 RVA: 0x0014D458 File Offset: 0x0014B658
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

	// Token: 0x06001C76 RID: 7286 RVA: 0x0014D4E8 File Offset: 0x0014B6E8
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

	// Token: 0x06001C77 RID: 7287 RVA: 0x0014D7B8 File Offset: 0x0014B9B8
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

	// Token: 0x0400325C RID: 12892
	public StudentScript Student;

	// Token: 0x0400325D RID: 12893
	public string SerializedData;

	// Token: 0x0400325E RID: 12894
	public string SaveFilePath;

	// Token: 0x0400325F RID: 12895
	public int SaveProfile;

	// Token: 0x04003260 RID: 12896
	public int SaveSlot;
}
