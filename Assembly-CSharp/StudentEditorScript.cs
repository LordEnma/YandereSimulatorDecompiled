using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x0200029D RID: 669
public class StudentEditorScript : MonoBehaviour
{
	// Token: 0x06001410 RID: 5136 RVA: 0x000BE6E4 File Offset: 0x000BC8E4
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

	// Token: 0x06001411 RID: 5137 RVA: 0x000BE83E File Offset: 0x000BCA3E
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x06001412 RID: 5138 RVA: 0x000BE87C File Offset: 0x000BCA7C
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

	// Token: 0x06001413 RID: 5139 RVA: 0x000BE914 File Offset: 0x000BCB14
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

	// Token: 0x06001414 RID: 5140 RVA: 0x000BEBD4 File Offset: 0x000BCDD4
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

	// Token: 0x06001415 RID: 5141 RVA: 0x000BEC90 File Offset: 0x000BCE90
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DEC RID: 7660
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DED RID: 7661
	[SerializeField]
	private UIPanel studentPanel;

	// Token: 0x04001DEE RID: 7662
	[SerializeField]
	private UILabel bodyLabel;

	// Token: 0x04001DEF RID: 7663
	[SerializeField]
	private Transform listLabelsOrigin;

	// Token: 0x04001DF0 RID: 7664
	[SerializeField]
	private UILabel studentLabelTemplate;

	// Token: 0x04001DF1 RID: 7665
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DF2 RID: 7666
	private StudentEditorScript.StudentData[] students;

	// Token: 0x04001DF3 RID: 7667
	private int studentIndex;

	// Token: 0x04001DF4 RID: 7668
	private InputManagerScript inputManager;

	// Token: 0x02000664 RID: 1636
	private class StudentAttendanceInfo
	{
		// Token: 0x06002675 RID: 9845 RVA: 0x00203E4D File Offset: 0x0020204D
		public static StudentEditorScript.StudentAttendanceInfo Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentAttendanceInfo
			{
				classNumber = TFUtils.LoadInt(dict, "Class"),
				seatNumber = TFUtils.LoadInt(dict, "Seat"),
				club = TFUtils.LoadInt(dict, "Club")
			};
		}

		// Token: 0x04004FF6 RID: 20470
		public int classNumber;

		// Token: 0x04004FF7 RID: 20471
		public int seatNumber;

		// Token: 0x04004FF8 RID: 20472
		public int club;
	}

	// Token: 0x02000665 RID: 1637
	private class StudentPersonality
	{
		// Token: 0x06002677 RID: 9847 RVA: 0x00203E8F File Offset: 0x0020208F
		public static StudentEditorScript.StudentPersonality Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentPersonality
			{
				persona = (PersonaType)TFUtils.LoadInt(dict, "Persona"),
				crush = TFUtils.LoadInt(dict, "Crush")
			};
		}

		// Token: 0x04004FF9 RID: 20473
		public PersonaType persona;

		// Token: 0x04004FFA RID: 20474
		public int crush;
	}

	// Token: 0x02000666 RID: 1638
	private class StudentStats
	{
		// Token: 0x06002679 RID: 9849 RVA: 0x00203EC0 File Offset: 0x002020C0
		public static StudentEditorScript.StudentStats Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentStats
			{
				strength = TFUtils.LoadInt(dict, "Strength")
			};
		}

		// Token: 0x04004FFB RID: 20475
		public int strength;
	}

	// Token: 0x02000667 RID: 1639
	private class StudentCosmetics
	{
		// Token: 0x0600267B RID: 9851 RVA: 0x00203EE0 File Offset: 0x002020E0
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

		// Token: 0x04004FFC RID: 20476
		public float breastSize;

		// Token: 0x04004FFD RID: 20477
		public string hairstyle;

		// Token: 0x04004FFE RID: 20478
		public string color;

		// Token: 0x04004FFF RID: 20479
		public string eyes;

		// Token: 0x04005000 RID: 20480
		public string stockings;

		// Token: 0x04005001 RID: 20481
		public string accessory;
	}

	// Token: 0x02000668 RID: 1640
	private class StudentData
	{
		// Token: 0x0600267D RID: 9853 RVA: 0x00203F60 File Offset: 0x00202160
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

		// Token: 0x04005002 RID: 20482
		public int id;

		// Token: 0x04005003 RID: 20483
		public string name;

		// Token: 0x04005004 RID: 20484
		public bool isMale;

		// Token: 0x04005005 RID: 20485
		public StudentEditorScript.StudentAttendanceInfo attendanceInfo;

		// Token: 0x04005006 RID: 20486
		public StudentEditorScript.StudentPersonality personality;

		// Token: 0x04005007 RID: 20487
		public StudentEditorScript.StudentStats stats;

		// Token: 0x04005008 RID: 20488
		public StudentEditorScript.StudentCosmetics cosmetics;

		// Token: 0x04005009 RID: 20489
		public ScheduleBlock[] scheduleBlocks;

		// Token: 0x0400500A RID: 20490
		public string info;
	}
}
