using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x0200029D RID: 669
public class StudentEditorScript : MonoBehaviour
{
	// Token: 0x06001410 RID: 5136 RVA: 0x000BE560 File Offset: 0x000BC760
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

	// Token: 0x06001411 RID: 5137 RVA: 0x000BE6BA File Offset: 0x000BC8BA
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x06001412 RID: 5138 RVA: 0x000BE6F8 File Offset: 0x000BC8F8
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

	// Token: 0x06001413 RID: 5139 RVA: 0x000BE790 File Offset: 0x000BC990
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

	// Token: 0x06001414 RID: 5140 RVA: 0x000BEA50 File Offset: 0x000BCC50
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

	// Token: 0x06001415 RID: 5141 RVA: 0x000BEB0C File Offset: 0x000BCD0C
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DEB RID: 7659
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DEC RID: 7660
	[SerializeField]
	private UIPanel studentPanel;

	// Token: 0x04001DED RID: 7661
	[SerializeField]
	private UILabel bodyLabel;

	// Token: 0x04001DEE RID: 7662
	[SerializeField]
	private Transform listLabelsOrigin;

	// Token: 0x04001DEF RID: 7663
	[SerializeField]
	private UILabel studentLabelTemplate;

	// Token: 0x04001DF0 RID: 7664
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DF1 RID: 7665
	private StudentEditorScript.StudentData[] students;

	// Token: 0x04001DF2 RID: 7666
	private int studentIndex;

	// Token: 0x04001DF3 RID: 7667
	private InputManagerScript inputManager;

	// Token: 0x02000664 RID: 1636
	private class StudentAttendanceInfo
	{
		// Token: 0x0600266E RID: 9838 RVA: 0x002033F1 File Offset: 0x002015F1
		public static StudentEditorScript.StudentAttendanceInfo Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentAttendanceInfo
			{
				classNumber = TFUtils.LoadInt(dict, "Class"),
				seatNumber = TFUtils.LoadInt(dict, "Seat"),
				club = TFUtils.LoadInt(dict, "Club")
			};
		}

		// Token: 0x04004FE4 RID: 20452
		public int classNumber;

		// Token: 0x04004FE5 RID: 20453
		public int seatNumber;

		// Token: 0x04004FE6 RID: 20454
		public int club;
	}

	// Token: 0x02000665 RID: 1637
	private class StudentPersonality
	{
		// Token: 0x06002670 RID: 9840 RVA: 0x00203433 File Offset: 0x00201633
		public static StudentEditorScript.StudentPersonality Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentPersonality
			{
				persona = (PersonaType)TFUtils.LoadInt(dict, "Persona"),
				crush = TFUtils.LoadInt(dict, "Crush")
			};
		}

		// Token: 0x04004FE7 RID: 20455
		public PersonaType persona;

		// Token: 0x04004FE8 RID: 20456
		public int crush;
	}

	// Token: 0x02000666 RID: 1638
	private class StudentStats
	{
		// Token: 0x06002672 RID: 9842 RVA: 0x00203464 File Offset: 0x00201664
		public static StudentEditorScript.StudentStats Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentStats
			{
				strength = TFUtils.LoadInt(dict, "Strength")
			};
		}

		// Token: 0x04004FE9 RID: 20457
		public int strength;
	}

	// Token: 0x02000667 RID: 1639
	private class StudentCosmetics
	{
		// Token: 0x06002674 RID: 9844 RVA: 0x00203484 File Offset: 0x00201684
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

		// Token: 0x04004FEA RID: 20458
		public float breastSize;

		// Token: 0x04004FEB RID: 20459
		public string hairstyle;

		// Token: 0x04004FEC RID: 20460
		public string color;

		// Token: 0x04004FED RID: 20461
		public string eyes;

		// Token: 0x04004FEE RID: 20462
		public string stockings;

		// Token: 0x04004FEF RID: 20463
		public string accessory;
	}

	// Token: 0x02000668 RID: 1640
	private class StudentData
	{
		// Token: 0x06002676 RID: 9846 RVA: 0x00203504 File Offset: 0x00201704
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

		// Token: 0x04004FF0 RID: 20464
		public int id;

		// Token: 0x04004FF1 RID: 20465
		public string name;

		// Token: 0x04004FF2 RID: 20466
		public bool isMale;

		// Token: 0x04004FF3 RID: 20467
		public StudentEditorScript.StudentAttendanceInfo attendanceInfo;

		// Token: 0x04004FF4 RID: 20468
		public StudentEditorScript.StudentPersonality personality;

		// Token: 0x04004FF5 RID: 20469
		public StudentEditorScript.StudentStats stats;

		// Token: 0x04004FF6 RID: 20470
		public StudentEditorScript.StudentCosmetics cosmetics;

		// Token: 0x04004FF7 RID: 20471
		public ScheduleBlock[] scheduleBlocks;

		// Token: 0x04004FF8 RID: 20472
		public string info;
	}
}
