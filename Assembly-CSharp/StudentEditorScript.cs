using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x0200029B RID: 667
public class StudentEditorScript : MonoBehaviour
{
	// Token: 0x060013FD RID: 5117 RVA: 0x000BD48C File Offset: 0x000BB68C
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

	// Token: 0x060013FE RID: 5118 RVA: 0x000BD5E6 File Offset: 0x000BB7E6
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013FF RID: 5119 RVA: 0x000BD624 File Offset: 0x000BB824
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

	// Token: 0x06001400 RID: 5120 RVA: 0x000BD6BC File Offset: 0x000BB8BC
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

	// Token: 0x06001401 RID: 5121 RVA: 0x000BD97C File Offset: 0x000BBB7C
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

	// Token: 0x06001402 RID: 5122 RVA: 0x000BDA38 File Offset: 0x000BBC38
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DBF RID: 7615
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DC0 RID: 7616
	[SerializeField]
	private UIPanel studentPanel;

	// Token: 0x04001DC1 RID: 7617
	[SerializeField]
	private UILabel bodyLabel;

	// Token: 0x04001DC2 RID: 7618
	[SerializeField]
	private Transform listLabelsOrigin;

	// Token: 0x04001DC3 RID: 7619
	[SerializeField]
	private UILabel studentLabelTemplate;

	// Token: 0x04001DC4 RID: 7620
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DC5 RID: 7621
	private StudentEditorScript.StudentData[] students;

	// Token: 0x04001DC6 RID: 7622
	private int studentIndex;

	// Token: 0x04001DC7 RID: 7623
	private InputManagerScript inputManager;

	// Token: 0x02000656 RID: 1622
	private class StudentAttendanceInfo
	{
		// Token: 0x06002626 RID: 9766 RVA: 0x001FDF85 File Offset: 0x001FC185
		public static StudentEditorScript.StudentAttendanceInfo Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentAttendanceInfo
			{
				classNumber = TFUtils.LoadInt(dict, "Class"),
				seatNumber = TFUtils.LoadInt(dict, "Seat"),
				club = TFUtils.LoadInt(dict, "Club")
			};
		}

		// Token: 0x04004F1D RID: 20253
		public int classNumber;

		// Token: 0x04004F1E RID: 20254
		public int seatNumber;

		// Token: 0x04004F1F RID: 20255
		public int club;
	}

	// Token: 0x02000657 RID: 1623
	private class StudentPersonality
	{
		// Token: 0x06002628 RID: 9768 RVA: 0x001FDFC7 File Offset: 0x001FC1C7
		public static StudentEditorScript.StudentPersonality Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentPersonality
			{
				persona = (PersonaType)TFUtils.LoadInt(dict, "Persona"),
				crush = TFUtils.LoadInt(dict, "Crush")
			};
		}

		// Token: 0x04004F20 RID: 20256
		public PersonaType persona;

		// Token: 0x04004F21 RID: 20257
		public int crush;
	}

	// Token: 0x02000658 RID: 1624
	private class StudentStats
	{
		// Token: 0x0600262A RID: 9770 RVA: 0x001FDFF8 File Offset: 0x001FC1F8
		public static StudentEditorScript.StudentStats Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentStats
			{
				strength = TFUtils.LoadInt(dict, "Strength")
			};
		}

		// Token: 0x04004F22 RID: 20258
		public int strength;
	}

	// Token: 0x02000659 RID: 1625
	private class StudentCosmetics
	{
		// Token: 0x0600262C RID: 9772 RVA: 0x001FE018 File Offset: 0x001FC218
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

		// Token: 0x04004F23 RID: 20259
		public float breastSize;

		// Token: 0x04004F24 RID: 20260
		public string hairstyle;

		// Token: 0x04004F25 RID: 20261
		public string color;

		// Token: 0x04004F26 RID: 20262
		public string eyes;

		// Token: 0x04004F27 RID: 20263
		public string stockings;

		// Token: 0x04004F28 RID: 20264
		public string accessory;
	}

	// Token: 0x0200065A RID: 1626
	private class StudentData
	{
		// Token: 0x0600262E RID: 9774 RVA: 0x001FE098 File Offset: 0x001FC298
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

		// Token: 0x04004F29 RID: 20265
		public int id;

		// Token: 0x04004F2A RID: 20266
		public string name;

		// Token: 0x04004F2B RID: 20267
		public bool isMale;

		// Token: 0x04004F2C RID: 20268
		public StudentEditorScript.StudentAttendanceInfo attendanceInfo;

		// Token: 0x04004F2D RID: 20269
		public StudentEditorScript.StudentPersonality personality;

		// Token: 0x04004F2E RID: 20270
		public StudentEditorScript.StudentStats stats;

		// Token: 0x04004F2F RID: 20271
		public StudentEditorScript.StudentCosmetics cosmetics;

		// Token: 0x04004F30 RID: 20272
		public ScheduleBlock[] scheduleBlocks;

		// Token: 0x04004F31 RID: 20273
		public string info;
	}
}
