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

	public StudentJson[] Students => students;

	public CreditJson[] Credits => credits;

	public TopicJson[] Topics => topics;

	private void Start()
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
}
