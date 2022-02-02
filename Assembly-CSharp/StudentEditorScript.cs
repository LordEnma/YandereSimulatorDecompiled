using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x0200029A RID: 666
public class StudentEditorScript : MonoBehaviour
{
	// Token: 0x060013F9 RID: 5113 RVA: 0x000BD4B4 File Offset: 0x000BB6B4
	private void Awake()
	{
		Dictionary<string, object>[] array = EditorManagerScript.DeserializeJson("Students.json");
		this.students = new StudentEditorScript.StudentData[array.Length];
		for (int i = 0; i < this.students.Length; i++)
		{
			this.students[i] = StudentEditorScript.StudentData.Deserialize(array[i]);
		}
		Array.Sort<StudentEditorScript.StudentData>(this.students, (StudentEditorScript.StudentData a, StudentEditorScript.StudentData b) => a.id - b.id);
		for (int j = 0; j < this.students.Length; j++)
		{
			StudentEditorScript.StudentData studentData = this.students[j];
			UILabel uilabel = UnityEngine.Object.Instantiate<UILabel>(this.studentLabelTemplate, this.listLabelsOrigin);
			uilabel.text = "(" + studentData.id.ToString() + ") " + studentData.name;
			Transform transform = uilabel.transform;
			transform.localPosition = new Vector3(transform.localPosition.x + (float)(uilabel.width / 2), transform.localPosition.y - (float)(j * uilabel.height), transform.localPosition.z);
			uilabel.gameObject.SetActive(true);
		}
		this.studentIndex = 0;
		this.bodyLabel.text = StudentEditorScript.GetStudentText(this.students[this.studentIndex]);
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013FA RID: 5114 RVA: 0x000BD60E File Offset: 0x000BB80E
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013FB RID: 5115 RVA: 0x000BD64C File Offset: 0x000BB84C
	private static ScheduleBlock[] DeserializeScheduleBlocks(Dictionary<string, object> dict)
	{
		string[] array = TFUtils.LoadString(dict, "ScheduleTime").Split(new char[]
		{
			'_'
		});
		string[] array2 = TFUtils.LoadString(dict, "ScheduleDestination").Split(new char[]
		{
			'_'
		});
		string[] array3 = TFUtils.LoadString(dict, "ScheduleAction").Split(new char[]
		{
			'_'
		});
		ScheduleBlock[] array4 = new ScheduleBlock[array.Length];
		for (int i = 0; i < array4.Length; i++)
		{
			array4[i] = new ScheduleBlock(float.Parse(array[i]), array2[i], array3[i]);
		}
		return array4;
	}

	// Token: 0x060013FC RID: 5116 RVA: 0x000BD6E4 File Offset: 0x000BB8E4
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
		{
			stringBuilder.Append(string.Concat(new string[]
			{
				"[",
				scheduleBlock.time.ToString(),
				", ",
				scheduleBlock.destination,
				", ",
				scheduleBlock.action,
				"]"
			}));
		}
		stringBuilder.Append("\n");
		stringBuilder.Append("- Info: \"" + data.info + "\"\n");
		return stringBuilder.ToString();
	}

	// Token: 0x060013FD RID: 5117 RVA: 0x000BD9A4 File Offset: 0x000BBBA4
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.studentPanel.gameObject.SetActive(false);
		}
		int num = 0;
		int num2 = this.students.Length - 1;
		bool tappedUp = this.inputManager.TappedUp;
		bool tappedDown = this.inputManager.TappedDown;
		if (tappedUp)
		{
			this.studentIndex = ((this.studentIndex > num) ? (this.studentIndex - 1) : num2);
		}
		else if (tappedDown)
		{
			this.studentIndex = ((this.studentIndex < num2) ? (this.studentIndex + 1) : num);
		}
		if (tappedUp || tappedDown)
		{
			this.bodyLabel.text = StudentEditorScript.GetStudentText(this.students[this.studentIndex]);
		}
	}

	// Token: 0x060013FE RID: 5118 RVA: 0x000BDA60 File Offset: 0x000BBC60
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DB9 RID: 7609
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DBA RID: 7610
	[SerializeField]
	private UIPanel studentPanel;

	// Token: 0x04001DBB RID: 7611
	[SerializeField]
	private UILabel bodyLabel;

	// Token: 0x04001DBC RID: 7612
	[SerializeField]
	private Transform listLabelsOrigin;

	// Token: 0x04001DBD RID: 7613
	[SerializeField]
	private UILabel studentLabelTemplate;

	// Token: 0x04001DBE RID: 7614
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DBF RID: 7615
	private StudentEditorScript.StudentData[] students;

	// Token: 0x04001DC0 RID: 7616
	private int studentIndex;

	// Token: 0x04001DC1 RID: 7617
	private InputManagerScript inputManager;

	// Token: 0x02000655 RID: 1621
	private class StudentAttendanceInfo
	{
		// Token: 0x0600261A RID: 9754 RVA: 0x001FD5B5 File Offset: 0x001FB7B5
		public static StudentEditorScript.StudentAttendanceInfo Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentAttendanceInfo
			{
				classNumber = TFUtils.LoadInt(dict, "Class"),
				seatNumber = TFUtils.LoadInt(dict, "Seat"),
				club = TFUtils.LoadInt(dict, "Club")
			};
		}

		// Token: 0x04004F0B RID: 20235
		public int classNumber;

		// Token: 0x04004F0C RID: 20236
		public int seatNumber;

		// Token: 0x04004F0D RID: 20237
		public int club;
	}

	// Token: 0x02000656 RID: 1622
	private class StudentPersonality
	{
		// Token: 0x0600261C RID: 9756 RVA: 0x001FD5F7 File Offset: 0x001FB7F7
		public static StudentEditorScript.StudentPersonality Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentPersonality
			{
				persona = (PersonaType)TFUtils.LoadInt(dict, "Persona"),
				crush = TFUtils.LoadInt(dict, "Crush")
			};
		}

		// Token: 0x04004F0E RID: 20238
		public PersonaType persona;

		// Token: 0x04004F0F RID: 20239
		public int crush;
	}

	// Token: 0x02000657 RID: 1623
	private class StudentStats
	{
		// Token: 0x0600261E RID: 9758 RVA: 0x001FD628 File Offset: 0x001FB828
		public static StudentEditorScript.StudentStats Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentStats
			{
				strength = TFUtils.LoadInt(dict, "Strength")
			};
		}

		// Token: 0x04004F10 RID: 20240
		public int strength;
	}

	// Token: 0x02000658 RID: 1624
	private class StudentCosmetics
	{
		// Token: 0x06002620 RID: 9760 RVA: 0x001FD648 File Offset: 0x001FB848
		public static StudentEditorScript.StudentCosmetics Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentCosmetics
			{
				breastSize = TFUtils.LoadFloat(dict, "BreastSize"),
				hairstyle = TFUtils.LoadString(dict, "Hairstyle"),
				color = TFUtils.LoadString(dict, "Color"),
				eyes = TFUtils.LoadString(dict, "Eyes"),
				stockings = TFUtils.LoadString(dict, "Stockings"),
				accessory = TFUtils.LoadString(dict, "Accessory")
			};
		}

		// Token: 0x04004F11 RID: 20241
		public float breastSize;

		// Token: 0x04004F12 RID: 20242
		public string hairstyle;

		// Token: 0x04004F13 RID: 20243
		public string color;

		// Token: 0x04004F14 RID: 20244
		public string eyes;

		// Token: 0x04004F15 RID: 20245
		public string stockings;

		// Token: 0x04004F16 RID: 20246
		public string accessory;
	}

	// Token: 0x02000659 RID: 1625
	private class StudentData
	{
		// Token: 0x06002622 RID: 9762 RVA: 0x001FD6C8 File Offset: 0x001FB8C8
		public static StudentEditorScript.StudentData Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentData
			{
				id = TFUtils.LoadInt(dict, "ID"),
				name = TFUtils.LoadString(dict, "Name"),
				isMale = (TFUtils.LoadInt(dict, "Gender") == 1),
				attendanceInfo = StudentEditorScript.StudentAttendanceInfo.Deserialize(dict),
				personality = StudentEditorScript.StudentPersonality.Deserialize(dict),
				stats = StudentEditorScript.StudentStats.Deserialize(dict),
				cosmetics = StudentEditorScript.StudentCosmetics.Deserialize(dict),
				scheduleBlocks = StudentEditorScript.DeserializeScheduleBlocks(dict),
				info = TFUtils.LoadString(dict, "Info")
			};
		}

		// Token: 0x04004F17 RID: 20247
		public int id;

		// Token: 0x04004F18 RID: 20248
		public string name;

		// Token: 0x04004F19 RID: 20249
		public bool isMale;

		// Token: 0x04004F1A RID: 20250
		public StudentEditorScript.StudentAttendanceInfo attendanceInfo;

		// Token: 0x04004F1B RID: 20251
		public StudentEditorScript.StudentPersonality personality;

		// Token: 0x04004F1C RID: 20252
		public StudentEditorScript.StudentStats stats;

		// Token: 0x04004F1D RID: 20253
		public StudentEditorScript.StudentCosmetics cosmetics;

		// Token: 0x04004F1E RID: 20254
		public ScheduleBlock[] scheduleBlocks;

		// Token: 0x04004F1F RID: 20255
		public string info;
	}
}
