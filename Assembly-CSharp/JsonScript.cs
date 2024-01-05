using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JsonScript : MonoBehaviour
{
	[SerializeField]
	private StudentJson[] students;

	[SerializeField]
	private CreditJson[] credits;

	[SerializeField]
	private TopicJson[] topics;

	[SerializeField]
	private MiscJson misc;

	protected static string FolderPath => Path.Combine(Application.streamingAssetsPath, "JSON");

	public StudentJson[] Students
	{
		get
		{
			return students;
		}
		set
		{
			students = value;
		}
	}

	public CreditJson[] Credits => credits;

	public TopicJson[] Topics
	{
		get
		{
			return topics;
		}
		set
		{
			topics = value;
		}
	}

	public MiscJson Misc
	{
		get
		{
			return misc;
		}
		set
		{
			misc = value;
		}
	}

	public void Start()
	{
		students = StudentJson.LoadFromJson(StudentJson.FilePath);
		topics = TopicJson.LoadFromJson(TopicJson.FilePath);
		if (SceneManager.GetActiveScene().name == "SchoolScene")
		{
			StudentManagerScript studentManagerScript = Object.FindObjectOfType<StudentManagerScript>();
			ReplaceDeadTeachers(studentManagerScript.FirstNames, studentManagerScript.LastNames);
		}
		else if (SceneManager.GetActiveScene().name == "CreditsScene")
		{
			credits = CreditJson.LoadFromJson(CreditJson.FilePath);
		}
		if (GameGlobals.CustomMode)
		{
			StudentJson[] array = JsonConvert.DeserializeObject<StudentJson[]>(File.ReadAllText(Path.Combine(FolderPath, "Custom.json")));
			Students = array;
			TopicJson[] array2 = JsonConvert.DeserializeObject<TopicJson[]>(File.ReadAllText(Path.Combine(FolderPath, "CustomTopics.json")));
			Topics = array2;
			MiscJson miscJson = JsonConvert.DeserializeObject<MiscJson>(File.ReadAllText(Path.Combine(FolderPath, "Misc.json")));
			Misc = miscJson;
		}
	}

	private void ReplaceDeadTeachers(string[] firstNames, string[] lastNames)
	{
		for (int i = 90; i < 101; i++)
		{
			if (StudentGlobals.GetStudentDead(i))
			{
				StudentGlobals.SetStudentReplaced(i, value: true);
				StudentGlobals.SetStudentDead(i, value: false);
				string value = firstNames[Random.Range(0, firstNames.Length)] + " " + lastNames[Random.Range(0, lastNames.Length)];
				StudentGlobals.SetStudentName(i, value);
				StudentGlobals.SetStudentBustSize(i, Random.Range(1f, 1.5f));
				StudentGlobals.SetStudentHairstyle(i, Random.Range(1, 8).ToString());
				float r = Random.Range(0f, 1f);
				float g = Random.Range(0f, 1f);
				float b = Random.Range(0f, 1f);
				StudentGlobals.SetStudentColor(i, new Color(r, g, b));
				r = Random.Range(0f, 1f);
				g = Random.Range(0f, 1f);
				b = Random.Range(0f, 1f);
				StudentGlobals.SetStudentEyeColor(i, new Color(r, g, b));
				StudentGlobals.SetStudentAccessory(i, Random.Range(1, 7).ToString());
			}
		}
		for (int j = 90; j < 101; j++)
		{
			if (StudentGlobals.GetStudentReplaced(j))
			{
				StudentJson studentJson = students[j];
				studentJson.Name = StudentGlobals.GetStudentName(j);
				studentJson.BreastSize = StudentGlobals.GetStudentBustSize(j);
				studentJson.Hairstyle = StudentGlobals.GetStudentHairstyle(j);
				studentJson.Accessory = StudentGlobals.GetStudentAccessory(j);
				if (j == 97)
				{
					studentJson.Accessory = "7";
				}
				if (j == 90)
				{
					studentJson.Accessory = "8";
				}
			}
		}
	}

	public static Dictionary<string, string>[] TopicAdapter(TopicJson[] topics)
	{
		List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
		for (int i = 0; i < topics.Length; i++)
		{
			TopicJson topicJson = topics[i];
			if (topicJson != null && topicJson.Topics != null)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["ID"] = i.ToString();
				for (int j = 0; j < topicJson.Topics.Length; j++)
				{
					dictionary[j.ToString()] = topicJson.Topics[j].ToString();
				}
				list.Add(dictionary);
			}
		}
		return list.ToArray();
	}
}
