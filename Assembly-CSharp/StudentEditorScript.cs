using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x0200029C RID: 668
public class StudentEditorScript : MonoBehaviour
{
	// Token: 0x06001406 RID: 5126 RVA: 0x000BDF34 File Offset: 0x000BC134
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

	// Token: 0x06001407 RID: 5127 RVA: 0x000BE08E File Offset: 0x000BC28E
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x06001408 RID: 5128 RVA: 0x000BE0CC File Offset: 0x000BC2CC
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

	// Token: 0x06001409 RID: 5129 RVA: 0x000BE164 File Offset: 0x000BC364
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

	// Token: 0x0600140A RID: 5130 RVA: 0x000BE424 File Offset: 0x000BC624
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

	// Token: 0x0600140B RID: 5131 RVA: 0x000BE4E0 File Offset: 0x000BC6E0
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DD7 RID: 7639
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DD8 RID: 7640
	[SerializeField]
	private UIPanel studentPanel;

	// Token: 0x04001DD9 RID: 7641
	[SerializeField]
	private UILabel bodyLabel;

	// Token: 0x04001DDA RID: 7642
	[SerializeField]
	private Transform listLabelsOrigin;

	// Token: 0x04001DDB RID: 7643
	[SerializeField]
	private UILabel studentLabelTemplate;

	// Token: 0x04001DDC RID: 7644
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DDD RID: 7645
	private StudentEditorScript.StudentData[] students;

	// Token: 0x04001DDE RID: 7646
	private int studentIndex;

	// Token: 0x04001DDF RID: 7647
	private InputManagerScript inputManager;

	// Token: 0x0200065A RID: 1626
	private class StudentAttendanceInfo
	{
		// Token: 0x0600263E RID: 9790 RVA: 0x001FF605 File Offset: 0x001FD805
		public static StudentEditorScript.StudentAttendanceInfo Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentAttendanceInfo
			{
				classNumber = TFUtils.LoadInt(dict, "Class"),
				seatNumber = TFUtils.LoadInt(dict, "Seat"),
				club = TFUtils.LoadInt(dict, "Club")
			};
		}

		// Token: 0x04004F4F RID: 20303
		public int classNumber;

		// Token: 0x04004F50 RID: 20304
		public int seatNumber;

		// Token: 0x04004F51 RID: 20305
		public int club;
	}

	// Token: 0x0200065B RID: 1627
	private class StudentPersonality
	{
		// Token: 0x06002640 RID: 9792 RVA: 0x001FF647 File Offset: 0x001FD847
		public static StudentEditorScript.StudentPersonality Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentPersonality
			{
				persona = (PersonaType)TFUtils.LoadInt(dict, "Persona"),
				crush = TFUtils.LoadInt(dict, "Crush")
			};
		}

		// Token: 0x04004F52 RID: 20306
		public PersonaType persona;

		// Token: 0x04004F53 RID: 20307
		public int crush;
	}

	// Token: 0x0200065C RID: 1628
	private class StudentStats
	{
		// Token: 0x06002642 RID: 9794 RVA: 0x001FF678 File Offset: 0x001FD878
		public static StudentEditorScript.StudentStats Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentStats
			{
				strength = TFUtils.LoadInt(dict, "Strength")
			};
		}

		// Token: 0x04004F54 RID: 20308
		public int strength;
	}

	// Token: 0x0200065D RID: 1629
	private class StudentCosmetics
	{
		// Token: 0x06002644 RID: 9796 RVA: 0x001FF698 File Offset: 0x001FD898
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

		// Token: 0x04004F55 RID: 20309
		public float breastSize;

		// Token: 0x04004F56 RID: 20310
		public string hairstyle;

		// Token: 0x04004F57 RID: 20311
		public string color;

		// Token: 0x04004F58 RID: 20312
		public string eyes;

		// Token: 0x04004F59 RID: 20313
		public string stockings;

		// Token: 0x04004F5A RID: 20314
		public string accessory;
	}

	// Token: 0x0200065E RID: 1630
	private class StudentData
	{
		// Token: 0x06002646 RID: 9798 RVA: 0x001FF718 File Offset: 0x001FD918
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

		// Token: 0x04004F5B RID: 20315
		public int id;

		// Token: 0x04004F5C RID: 20316
		public string name;

		// Token: 0x04004F5D RID: 20317
		public bool isMale;

		// Token: 0x04004F5E RID: 20318
		public StudentEditorScript.StudentAttendanceInfo attendanceInfo;

		// Token: 0x04004F5F RID: 20319
		public StudentEditorScript.StudentPersonality personality;

		// Token: 0x04004F60 RID: 20320
		public StudentEditorScript.StudentStats stats;

		// Token: 0x04004F61 RID: 20321
		public StudentEditorScript.StudentCosmetics cosmetics;

		// Token: 0x04004F62 RID: 20322
		public ScheduleBlock[] scheduleBlocks;

		// Token: 0x04004F63 RID: 20323
		public string info;
	}
}
