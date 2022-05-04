using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x0200029D RID: 669
public class StudentEditorScript : MonoBehaviour
{
	// Token: 0x06001414 RID: 5140 RVA: 0x000BEB54 File Offset: 0x000BCD54
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

	// Token: 0x06001415 RID: 5141 RVA: 0x000BECAE File Offset: 0x000BCEAE
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x06001416 RID: 5142 RVA: 0x000BECEC File Offset: 0x000BCEEC
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

	// Token: 0x06001417 RID: 5143 RVA: 0x000BED84 File Offset: 0x000BCF84
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

	// Token: 0x06001418 RID: 5144 RVA: 0x000BF044 File Offset: 0x000BD244
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

	// Token: 0x06001419 RID: 5145 RVA: 0x000BF100 File Offset: 0x000BD300
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DF5 RID: 7669
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DF6 RID: 7670
	[SerializeField]
	private UIPanel studentPanel;

	// Token: 0x04001DF7 RID: 7671
	[SerializeField]
	private UILabel bodyLabel;

	// Token: 0x04001DF8 RID: 7672
	[SerializeField]
	private Transform listLabelsOrigin;

	// Token: 0x04001DF9 RID: 7673
	[SerializeField]
	private UILabel studentLabelTemplate;

	// Token: 0x04001DFA RID: 7674
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DFB RID: 7675
	private StudentEditorScript.StudentData[] students;

	// Token: 0x04001DFC RID: 7676
	private int studentIndex;

	// Token: 0x04001DFD RID: 7677
	private InputManagerScript inputManager;

	// Token: 0x02000665 RID: 1637
	private class StudentAttendanceInfo
	{
		// Token: 0x0600267F RID: 9855 RVA: 0x002054E9 File Offset: 0x002036E9
		public static StudentEditorScript.StudentAttendanceInfo Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentAttendanceInfo
			{
				classNumber = TFUtils.LoadInt(dict, "Class"),
				seatNumber = TFUtils.LoadInt(dict, "Seat"),
				club = TFUtils.LoadInt(dict, "Club")
			};
		}

		// Token: 0x04005014 RID: 20500
		public int classNumber;

		// Token: 0x04005015 RID: 20501
		public int seatNumber;

		// Token: 0x04005016 RID: 20502
		public int club;
	}

	// Token: 0x02000666 RID: 1638
	private class StudentPersonality
	{
		// Token: 0x06002681 RID: 9857 RVA: 0x0020552B File Offset: 0x0020372B
		public static StudentEditorScript.StudentPersonality Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentPersonality
			{
				persona = (PersonaType)TFUtils.LoadInt(dict, "Persona"),
				crush = TFUtils.LoadInt(dict, "Crush")
			};
		}

		// Token: 0x04005017 RID: 20503
		public PersonaType persona;

		// Token: 0x04005018 RID: 20504
		public int crush;
	}

	// Token: 0x02000667 RID: 1639
	private class StudentStats
	{
		// Token: 0x06002683 RID: 9859 RVA: 0x0020555C File Offset: 0x0020375C
		public static StudentEditorScript.StudentStats Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentStats
			{
				strength = TFUtils.LoadInt(dict, "Strength")
			};
		}

		// Token: 0x04005019 RID: 20505
		public int strength;
	}

	// Token: 0x02000668 RID: 1640
	private class StudentCosmetics
	{
		// Token: 0x06002685 RID: 9861 RVA: 0x0020557C File Offset: 0x0020377C
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

		// Token: 0x0400501A RID: 20506
		public float breastSize;

		// Token: 0x0400501B RID: 20507
		public string hairstyle;

		// Token: 0x0400501C RID: 20508
		public string color;

		// Token: 0x0400501D RID: 20509
		public string eyes;

		// Token: 0x0400501E RID: 20510
		public string stockings;

		// Token: 0x0400501F RID: 20511
		public string accessory;
	}

	// Token: 0x02000669 RID: 1641
	private class StudentData
	{
		// Token: 0x06002687 RID: 9863 RVA: 0x002055FC File Offset: 0x002037FC
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

		// Token: 0x04005020 RID: 20512
		public int id;

		// Token: 0x04005021 RID: 20513
		public string name;

		// Token: 0x04005022 RID: 20514
		public bool isMale;

		// Token: 0x04005023 RID: 20515
		public StudentEditorScript.StudentAttendanceInfo attendanceInfo;

		// Token: 0x04005024 RID: 20516
		public StudentEditorScript.StudentPersonality personality;

		// Token: 0x04005025 RID: 20517
		public StudentEditorScript.StudentStats stats;

		// Token: 0x04005026 RID: 20518
		public StudentEditorScript.StudentCosmetics cosmetics;

		// Token: 0x04005027 RID: 20519
		public ScheduleBlock[] scheduleBlocks;

		// Token: 0x04005028 RID: 20520
		public string info;
	}
}
