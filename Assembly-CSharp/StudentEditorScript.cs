using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x0200029C RID: 668
public class StudentEditorScript : MonoBehaviour
{
	// Token: 0x06001409 RID: 5129 RVA: 0x000BE34C File Offset: 0x000BC54C
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

	// Token: 0x0600140A RID: 5130 RVA: 0x000BE4A6 File Offset: 0x000BC6A6
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x0600140B RID: 5131 RVA: 0x000BE4E4 File Offset: 0x000BC6E4
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

	// Token: 0x0600140C RID: 5132 RVA: 0x000BE57C File Offset: 0x000BC77C
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

	// Token: 0x0600140D RID: 5133 RVA: 0x000BE83C File Offset: 0x000BCA3C
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

	// Token: 0x0600140E RID: 5134 RVA: 0x000BE8F8 File Offset: 0x000BCAF8
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DE6 RID: 7654
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DE7 RID: 7655
	[SerializeField]
	private UIPanel studentPanel;

	// Token: 0x04001DE8 RID: 7656
	[SerializeField]
	private UILabel bodyLabel;

	// Token: 0x04001DE9 RID: 7657
	[SerializeField]
	private Transform listLabelsOrigin;

	// Token: 0x04001DEA RID: 7658
	[SerializeField]
	private UILabel studentLabelTemplate;

	// Token: 0x04001DEB RID: 7659
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DEC RID: 7660
	private StudentEditorScript.StudentData[] students;

	// Token: 0x04001DED RID: 7661
	private int studentIndex;

	// Token: 0x04001DEE RID: 7662
	private InputManagerScript inputManager;

	// Token: 0x0200065E RID: 1630
	private class StudentAttendanceInfo
	{
		// Token: 0x06002656 RID: 9814 RVA: 0x0020156D File Offset: 0x001FF76D
		public static StudentEditorScript.StudentAttendanceInfo Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentAttendanceInfo
			{
				classNumber = TFUtils.LoadInt(dict, "Class"),
				seatNumber = TFUtils.LoadInt(dict, "Seat"),
				club = TFUtils.LoadInt(dict, "Club")
			};
		}

		// Token: 0x04004FAE RID: 20398
		public int classNumber;

		// Token: 0x04004FAF RID: 20399
		public int seatNumber;

		// Token: 0x04004FB0 RID: 20400
		public int club;
	}

	// Token: 0x0200065F RID: 1631
	private class StudentPersonality
	{
		// Token: 0x06002658 RID: 9816 RVA: 0x002015AF File Offset: 0x001FF7AF
		public static StudentEditorScript.StudentPersonality Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentPersonality
			{
				persona = (PersonaType)TFUtils.LoadInt(dict, "Persona"),
				crush = TFUtils.LoadInt(dict, "Crush")
			};
		}

		// Token: 0x04004FB1 RID: 20401
		public PersonaType persona;

		// Token: 0x04004FB2 RID: 20402
		public int crush;
	}

	// Token: 0x02000660 RID: 1632
	private class StudentStats
	{
		// Token: 0x0600265A RID: 9818 RVA: 0x002015E0 File Offset: 0x001FF7E0
		public static StudentEditorScript.StudentStats Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentStats
			{
				strength = TFUtils.LoadInt(dict, "Strength")
			};
		}

		// Token: 0x04004FB3 RID: 20403
		public int strength;
	}

	// Token: 0x02000661 RID: 1633
	private class StudentCosmetics
	{
		// Token: 0x0600265C RID: 9820 RVA: 0x00201600 File Offset: 0x001FF800
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

		// Token: 0x04004FB4 RID: 20404
		public float breastSize;

		// Token: 0x04004FB5 RID: 20405
		public string hairstyle;

		// Token: 0x04004FB6 RID: 20406
		public string color;

		// Token: 0x04004FB7 RID: 20407
		public string eyes;

		// Token: 0x04004FB8 RID: 20408
		public string stockings;

		// Token: 0x04004FB9 RID: 20409
		public string accessory;
	}

	// Token: 0x02000662 RID: 1634
	private class StudentData
	{
		// Token: 0x0600265E RID: 9822 RVA: 0x00201680 File Offset: 0x001FF880
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

		// Token: 0x04004FBA RID: 20410
		public int id;

		// Token: 0x04004FBB RID: 20411
		public string name;

		// Token: 0x04004FBC RID: 20412
		public bool isMale;

		// Token: 0x04004FBD RID: 20413
		public StudentEditorScript.StudentAttendanceInfo attendanceInfo;

		// Token: 0x04004FBE RID: 20414
		public StudentEditorScript.StudentPersonality personality;

		// Token: 0x04004FBF RID: 20415
		public StudentEditorScript.StudentStats stats;

		// Token: 0x04004FC0 RID: 20416
		public StudentEditorScript.StudentCosmetics cosmetics;

		// Token: 0x04004FC1 RID: 20417
		public ScheduleBlock[] scheduleBlocks;

		// Token: 0x04004FC2 RID: 20418
		public string info;
	}
}
