using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x0200029E RID: 670
public class StudentEditorScript : MonoBehaviour
{
	// Token: 0x06001416 RID: 5142 RVA: 0x000BEDC8 File Offset: 0x000BCFC8
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

	// Token: 0x06001417 RID: 5143 RVA: 0x000BEF22 File Offset: 0x000BD122
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x06001418 RID: 5144 RVA: 0x000BEF60 File Offset: 0x000BD160
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

	// Token: 0x06001419 RID: 5145 RVA: 0x000BEFF8 File Offset: 0x000BD1F8
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

	// Token: 0x0600141A RID: 5146 RVA: 0x000BF2B8 File Offset: 0x000BD4B8
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

	// Token: 0x0600141B RID: 5147 RVA: 0x000BF374 File Offset: 0x000BD574
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DFC RID: 7676
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DFD RID: 7677
	[SerializeField]
	private UIPanel studentPanel;

	// Token: 0x04001DFE RID: 7678
	[SerializeField]
	private UILabel bodyLabel;

	// Token: 0x04001DFF RID: 7679
	[SerializeField]
	private Transform listLabelsOrigin;

	// Token: 0x04001E00 RID: 7680
	[SerializeField]
	private UILabel studentLabelTemplate;

	// Token: 0x04001E01 RID: 7681
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001E02 RID: 7682
	private StudentEditorScript.StudentData[] students;

	// Token: 0x04001E03 RID: 7683
	private int studentIndex;

	// Token: 0x04001E04 RID: 7684
	private InputManagerScript inputManager;

	// Token: 0x02000666 RID: 1638
	private class StudentAttendanceInfo
	{
		// Token: 0x06002689 RID: 9865 RVA: 0x00206B39 File Offset: 0x00204D39
		public static StudentEditorScript.StudentAttendanceInfo Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentAttendanceInfo
			{
				classNumber = TFUtils.LoadInt(dict, "Class"),
				seatNumber = TFUtils.LoadInt(dict, "Seat"),
				club = TFUtils.LoadInt(dict, "Club")
			};
		}

		// Token: 0x0400503B RID: 20539
		public int classNumber;

		// Token: 0x0400503C RID: 20540
		public int seatNumber;

		// Token: 0x0400503D RID: 20541
		public int club;
	}

	// Token: 0x02000667 RID: 1639
	private class StudentPersonality
	{
		// Token: 0x0600268B RID: 9867 RVA: 0x00206B7B File Offset: 0x00204D7B
		public static StudentEditorScript.StudentPersonality Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentPersonality
			{
				persona = (PersonaType)TFUtils.LoadInt(dict, "Persona"),
				crush = TFUtils.LoadInt(dict, "Crush")
			};
		}

		// Token: 0x0400503E RID: 20542
		public PersonaType persona;

		// Token: 0x0400503F RID: 20543
		public int crush;
	}

	// Token: 0x02000668 RID: 1640
	private class StudentStats
	{
		// Token: 0x0600268D RID: 9869 RVA: 0x00206BAC File Offset: 0x00204DAC
		public static StudentEditorScript.StudentStats Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentStats
			{
				strength = TFUtils.LoadInt(dict, "Strength")
			};
		}

		// Token: 0x04005040 RID: 20544
		public int strength;
	}

	// Token: 0x02000669 RID: 1641
	private class StudentCosmetics
	{
		// Token: 0x0600268F RID: 9871 RVA: 0x00206BCC File Offset: 0x00204DCC
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

		// Token: 0x04005041 RID: 20545
		public float breastSize;

		// Token: 0x04005042 RID: 20546
		public string hairstyle;

		// Token: 0x04005043 RID: 20547
		public string color;

		// Token: 0x04005044 RID: 20548
		public string eyes;

		// Token: 0x04005045 RID: 20549
		public string stockings;

		// Token: 0x04005046 RID: 20550
		public string accessory;
	}

	// Token: 0x0200066A RID: 1642
	private class StudentData
	{
		// Token: 0x06002691 RID: 9873 RVA: 0x00206C4C File Offset: 0x00204E4C
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

		// Token: 0x04005047 RID: 20551
		public int id;

		// Token: 0x04005048 RID: 20552
		public string name;

		// Token: 0x04005049 RID: 20553
		public bool isMale;

		// Token: 0x0400504A RID: 20554
		public StudentEditorScript.StudentAttendanceInfo attendanceInfo;

		// Token: 0x0400504B RID: 20555
		public StudentEditorScript.StudentPersonality personality;

		// Token: 0x0400504C RID: 20556
		public StudentEditorScript.StudentStats stats;

		// Token: 0x0400504D RID: 20557
		public StudentEditorScript.StudentCosmetics cosmetics;

		// Token: 0x0400504E RID: 20558
		public ScheduleBlock[] scheduleBlocks;

		// Token: 0x0400504F RID: 20559
		public string info;
	}
}
