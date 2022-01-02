using System;
using System.IO;
using UnityEngine;

// Token: 0x02000407 RID: 1031
public class SaveLoadScript : MonoBehaviour
{
	// Token: 0x06001C29 RID: 7209 RVA: 0x00146B38 File Offset: 0x00144D38
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

	// Token: 0x06001C2A RID: 7210 RVA: 0x00146BC8 File Offset: 0x00144DC8
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

	// Token: 0x06001C2B RID: 7211 RVA: 0x00146E98 File Offset: 0x00145098
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

	// Token: 0x0400319C RID: 12700
	public StudentScript Student;

	// Token: 0x0400319D RID: 12701
	public string SerializedData;

	// Token: 0x0400319E RID: 12702
	public string SaveFilePath;

	// Token: 0x0400319F RID: 12703
	public int SaveProfile;

	// Token: 0x040031A0 RID: 12704
	public int SaveSlot;
}
