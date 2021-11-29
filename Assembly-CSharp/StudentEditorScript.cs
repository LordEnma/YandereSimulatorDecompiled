using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x02000298 RID: 664
public class StudentEditorScript : MonoBehaviour
{
	// Token: 0x060013EE RID: 5102 RVA: 0x000BC9C4 File Offset: 0x000BABC4
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

	// Token: 0x060013EF RID: 5103 RVA: 0x000BCB1E File Offset: 0x000BAD1E
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013F0 RID: 5104 RVA: 0x000BCB5C File Offset: 0x000BAD5C
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

	// Token: 0x060013F1 RID: 5105 RVA: 0x000BCBF4 File Offset: 0x000BADF4
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

	// Token: 0x060013F2 RID: 5106 RVA: 0x000BCEB4 File Offset: 0x000BB0B4
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

	// Token: 0x060013F3 RID: 5107 RVA: 0x000BCF70 File Offset: 0x000BB170
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001D8F RID: 7567
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001D90 RID: 7568
	[SerializeField]
	private UIPanel studentPanel;

	// Token: 0x04001D91 RID: 7569
	[SerializeField]
	private UILabel bodyLabel;

	// Token: 0x04001D92 RID: 7570
	[SerializeField]
	private Transform listLabelsOrigin;

	// Token: 0x04001D93 RID: 7571
	[SerializeField]
	private UILabel studentLabelTemplate;

	// Token: 0x04001D94 RID: 7572
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001D95 RID: 7573
	private StudentEditorScript.StudentData[] students;

	// Token: 0x04001D96 RID: 7574
	private int studentIndex;

	// Token: 0x04001D97 RID: 7575
	private InputManagerScript inputManager;

	// Token: 0x02000656 RID: 1622
	private class StudentAttendanceInfo
	{
		// Token: 0x06002609 RID: 9737 RVA: 0x001FA041 File Offset: 0x001F8241
		public static StudentEditorScript.StudentAttendanceInfo Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentAttendanceInfo
			{
				classNumber = TFUtils.LoadInt(dict, "Class"),
				seatNumber = TFUtils.LoadInt(dict, "Seat"),
				club = TFUtils.LoadInt(dict, "Club")
			};
		}

		// Token: 0x04004ECB RID: 20171
		public int classNumber;

		// Token: 0x04004ECC RID: 20172
		public int seatNumber;

		// Token: 0x04004ECD RID: 20173
		public int club;
	}

	// Token: 0x02000657 RID: 1623
	private class StudentPersonality
	{
		// Token: 0x0600260B RID: 9739 RVA: 0x001FA083 File Offset: 0x001F8283
		public static StudentEditorScript.StudentPersonality Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentPersonality
			{
				persona = (PersonaType)TFUtils.LoadInt(dict, "Persona"),
				crush = TFUtils.LoadInt(dict, "Crush")
			};
		}

		// Token: 0x04004ECE RID: 20174
		public PersonaType persona;

		// Token: 0x04004ECF RID: 20175
		public int crush;
	}

	// Token: 0x02000658 RID: 1624
	private class StudentStats
	{
		// Token: 0x0600260D RID: 9741 RVA: 0x001FA0B4 File Offset: 0x001F82B4
		public static StudentEditorScript.StudentStats Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentStats
			{
				strength = TFUtils.LoadInt(dict, "Strength")
			};
		}

		// Token: 0x04004ED0 RID: 20176
		public int strength;
	}

	// Token: 0x02000659 RID: 1625
	private class StudentCosmetics
	{
		// Token: 0x0600260F RID: 9743 RVA: 0x001FA0D4 File Offset: 0x001F82D4
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

		// Token: 0x04004ED1 RID: 20177
		public float breastSize;

		// Token: 0x04004ED2 RID: 20178
		public string hairstyle;

		// Token: 0x04004ED3 RID: 20179
		public string color;

		// Token: 0x04004ED4 RID: 20180
		public string eyes;

		// Token: 0x04004ED5 RID: 20181
		public string stockings;

		// Token: 0x04004ED6 RID: 20182
		public string accessory;
	}

	// Token: 0x0200065A RID: 1626
	private class StudentData
	{
		// Token: 0x06002611 RID: 9745 RVA: 0x001FA154 File Offset: 0x001F8354
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

		// Token: 0x04004ED7 RID: 20183
		public int id;

		// Token: 0x04004ED8 RID: 20184
		public string name;

		// Token: 0x04004ED9 RID: 20185
		public bool isMale;

		// Token: 0x04004EDA RID: 20186
		public StudentEditorScript.StudentAttendanceInfo attendanceInfo;

		// Token: 0x04004EDB RID: 20187
		public StudentEditorScript.StudentPersonality personality;

		// Token: 0x04004EDC RID: 20188
		public StudentEditorScript.StudentStats stats;

		// Token: 0x04004EDD RID: 20189
		public StudentEditorScript.StudentCosmetics cosmetics;

		// Token: 0x04004EDE RID: 20190
		public ScheduleBlock[] scheduleBlocks;

		// Token: 0x04004EDF RID: 20191
		public string info;
	}
}
