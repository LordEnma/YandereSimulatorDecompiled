using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class StudentEditorScript : MonoBehaviour
{
	private class StudentAttendanceInfo
	{
		public int classNumber;

		public int seatNumber;

		public int club;

		public static StudentAttendanceInfo Deserialize(Dictionary<string, object> dict)
		{
			return new StudentAttendanceInfo
			{
				classNumber = TFUtils.LoadInt(dict, "Class"),
				seatNumber = TFUtils.LoadInt(dict, "Seat"),
				club = TFUtils.LoadInt(dict, "Club")
			};
		}
	}

	private class StudentPersonality
	{
		public PersonaType persona;

		public int crush;

		public static StudentPersonality Deserialize(Dictionary<string, object> dict)
		{
			return new StudentPersonality
			{
				persona = (PersonaType)TFUtils.LoadInt(dict, "Persona"),
				crush = TFUtils.LoadInt(dict, "Crush")
			};
		}
	}

	private class StudentStats
	{
		public int strength;

		public static StudentStats Deserialize(Dictionary<string, object> dict)
		{
			return new StudentStats
			{
				strength = TFUtils.LoadInt(dict, "Strength")
			};
		}
	}

	private class StudentCosmetics
	{
		public float breastSize;

		public string hairstyle;

		public string color;

		public string eyes;

		public string stockings;

		public string accessory;

		public static StudentCosmetics Deserialize(Dictionary<string, object> dict)
		{
			return new StudentCosmetics
			{
				breastSize = TFUtils.LoadFloat(dict, "BreastSize"),
				hairstyle = TFUtils.LoadString(dict, "Hairstyle"),
				color = TFUtils.LoadString(dict, "Color"),
				eyes = TFUtils.LoadString(dict, "Eyes"),
				stockings = TFUtils.LoadString(dict, "Stockings"),
				accessory = TFUtils.LoadString(dict, "Accessory")
			};
		}
	}

	private class StudentData
	{
		public int id;

		public string name;

		public bool isMale;

		public StudentAttendanceInfo attendanceInfo;

		public StudentPersonality personality;

		public StudentStats stats;

		public StudentCosmetics cosmetics;

		public ScheduleBlock[] scheduleBlocks;

		public string info;

		public static StudentData Deserialize(Dictionary<string, object> dict)
		{
			return new StudentData
			{
				id = TFUtils.LoadInt(dict, "ID"),
				name = TFUtils.LoadString(dict, "Name"),
				isMale = (TFUtils.LoadInt(dict, "Gender") == 1),
				attendanceInfo = StudentAttendanceInfo.Deserialize(dict),
				personality = StudentPersonality.Deserialize(dict),
				stats = StudentStats.Deserialize(dict),
				cosmetics = StudentCosmetics.Deserialize(dict),
				scheduleBlocks = DeserializeScheduleBlocks(dict),
				info = TFUtils.LoadString(dict, "Info")
			};
		}
	}

	[SerializeField]
	private UIPanel mainPanel;

	[SerializeField]
	private UIPanel studentPanel;

	[SerializeField]
	private UILabel bodyLabel;

	[SerializeField]
	private Transform listLabelsOrigin;

	[SerializeField]
	private UILabel studentLabelTemplate;

	[SerializeField]
	private PromptBarScript promptBar;

	private StudentData[] students;

	private int studentIndex;

	private InputManagerScript inputManager;

	private void Awake()
	{
		Dictionary<string, object>[] array = EditorManagerScript.DeserializeJson("Students.json");
		students = new StudentData[array.Length];
		for (int i = 0; i < students.Length; i++)
		{
			students[i] = StudentData.Deserialize(array[i]);
		}
		Array.Sort(students, (StudentData a, StudentData b) => a.id - b.id);
		for (int j = 0; j < students.Length; j++)
		{
			StudentData studentData = students[j];
			UILabel uILabel = UnityEngine.Object.Instantiate(studentLabelTemplate, listLabelsOrigin);
			uILabel.text = "(" + studentData.id + ") " + studentData.name;
			Transform transform = uILabel.transform;
			transform.localPosition = new Vector3(transform.localPosition.x + (float)(uILabel.width / 2), transform.localPosition.y - (float)(j * uILabel.height), transform.localPosition.z);
			uILabel.gameObject.SetActive(value: true);
		}
		studentIndex = 0;
		bodyLabel.text = GetStudentText(students[studentIndex]);
		inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	private void OnEnable()
	{
		promptBar.Label[0].text = string.Empty;
		promptBar.Label[1].text = "Back";
		promptBar.UpdateButtons();
	}

	private static ScheduleBlock[] DeserializeScheduleBlocks(Dictionary<string, object> dict)
	{
		string[] array = TFUtils.LoadString(dict, "ScheduleTime").Split('_');
		string[] array2 = TFUtils.LoadString(dict, "ScheduleDestination").Split('_');
		string[] array3 = TFUtils.LoadString(dict, "ScheduleAction").Split('_');
		ScheduleBlock[] array4 = new ScheduleBlock[array.Length];
		for (int i = 0; i < array4.Length; i++)
		{
			array4[i] = new ScheduleBlock(float.Parse(array[i]), array2[i], array3[i]);
		}
		return array4;
	}

	private static string GetStudentText(StudentData data)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(data.name + " (" + data.id + "):\n");
		stringBuilder.Append("- Gender: " + (data.isMale ? "Male" : "Female") + "\n");
		stringBuilder.Append("- Class: " + data.attendanceInfo.classNumber + "\n");
		stringBuilder.Append("- Seat: " + data.attendanceInfo.seatNumber + "\n");
		stringBuilder.Append("- Club: " + data.attendanceInfo.club + "\n");
		stringBuilder.Append("- Persona: " + data.personality.persona.ToString() + "\n");
		stringBuilder.Append("- Crush: " + data.personality.crush + "\n");
		stringBuilder.Append("- Breast size: " + data.cosmetics.breastSize + "\n");
		stringBuilder.Append("- Strength: " + data.stats.strength + "\n");
		stringBuilder.Append("- Hairstyle: " + data.cosmetics.hairstyle + "\n");
		stringBuilder.Append("- Color: " + data.cosmetics.color + "\n");
		stringBuilder.Append("- Eyes: " + data.cosmetics.eyes + "\n");
		stringBuilder.Append("- Stockings: " + data.cosmetics.stockings + "\n");
		stringBuilder.Append("- Accessory: " + data.cosmetics.accessory + "\n");
		stringBuilder.Append("- Schedule blocks: ");
		ScheduleBlock[] scheduleBlocks = data.scheduleBlocks;
		foreach (ScheduleBlock scheduleBlock in scheduleBlocks)
		{
			stringBuilder.Append("[" + scheduleBlock.time + ", " + scheduleBlock.destination + ", " + scheduleBlock.action + "]");
		}
		stringBuilder.Append("\n");
		stringBuilder.Append("- Info: \"" + data.info + "\"\n");
		return stringBuilder.ToString();
	}

	private void HandleInput()
	{
		if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			mainPanel.gameObject.SetActive(value: true);
			studentPanel.gameObject.SetActive(value: false);
		}
		int num = 0;
		int num2 = students.Length - 1;
		bool tappedUp = inputManager.TappedUp;
		bool tappedDown = inputManager.TappedDown;
		if (tappedUp)
		{
			studentIndex = ((studentIndex > num) ? (studentIndex - 1) : num2);
		}
		else if (tappedDown)
		{
			studentIndex = ((studentIndex < num2) ? (studentIndex + 1) : num);
		}
		if (tappedUp || tappedDown)
		{
			bodyLabel.text = GetStudentText(students[studentIndex]);
		}
	}

	private void Update()
	{
		HandleInput();
	}
}
