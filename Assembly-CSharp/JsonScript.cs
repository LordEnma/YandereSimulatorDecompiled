using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000345 RID: 837
public class JsonScript : MonoBehaviour
{
	// Token: 0x06001925 RID: 6437 RVA: 0x000FAE40 File Offset: 0x000F9040
	private void Start()
	{
		this.students = StudentJson.LoadFromJson(StudentJson.FilePath);
		this.topics = TopicJson.LoadFromJson(TopicJson.FilePath);
		if (SceneManager.GetActiveScene().name == "SchoolScene")
		{
			StudentManagerScript studentManagerScript = UnityEngine.Object.FindObjectOfType<StudentManagerScript>();
			this.ReplaceDeadTeachers(studentManagerScript.FirstNames, studentManagerScript.LastNames);
			return;
		}
		if (SceneManager.GetActiveScene().name == "CreditsScene")
		{
			this.credits = CreditJson.LoadFromJson(CreditJson.FilePath);
		}
	}

	// Token: 0x17000491 RID: 1169
	// (get) Token: 0x06001926 RID: 6438 RVA: 0x000FAEC8 File Offset: 0x000F90C8
	public StudentJson[] Students
	{
		get
		{
			return this.students;
		}
	}

	// Token: 0x17000492 RID: 1170
	// (get) Token: 0x06001927 RID: 6439 RVA: 0x000FAED0 File Offset: 0x000F90D0
	public CreditJson[] Credits
	{
		get
		{
			return this.credits;
		}
	}

	// Token: 0x17000493 RID: 1171
	// (get) Token: 0x06001928 RID: 6440 RVA: 0x000FAED8 File Offset: 0x000F90D8
	public TopicJson[] Topics
	{
		get
		{
			return this.topics;
		}
	}

	// Token: 0x06001929 RID: 6441 RVA: 0x000FAEE0 File Offset: 0x000F90E0
	private void ReplaceDeadTeachers(string[] firstNames, string[] lastNames)
	{
		for (int i = 90; i < 101; i++)
		{
			if (StudentGlobals.GetStudentDead(i))
			{
				StudentGlobals.SetStudentReplaced(i, true);
				StudentGlobals.SetStudentDead(i, false);
				string value = firstNames[UnityEngine.Random.Range(0, firstNames.Length)] + " " + lastNames[UnityEngine.Random.Range(0, lastNames.Length)];
				StudentGlobals.SetStudentName(i, value);
				StudentGlobals.SetStudentBustSize(i, UnityEngine.Random.Range(1f, 1.5f));
				StudentGlobals.SetStudentHairstyle(i, UnityEngine.Random.Range(1, 8).ToString());
				float r = UnityEngine.Random.Range(0f, 1f);
				float g = UnityEngine.Random.Range(0f, 1f);
				float b = UnityEngine.Random.Range(0f, 1f);
				StudentGlobals.SetStudentColor(i, new Color(r, g, b));
				r = UnityEngine.Random.Range(0f, 1f);
				g = UnityEngine.Random.Range(0f, 1f);
				b = UnityEngine.Random.Range(0f, 1f);
				StudentGlobals.SetStudentEyeColor(i, new Color(r, g, b));
				StudentGlobals.SetStudentAccessory(i, UnityEngine.Random.Range(1, 7).ToString());
			}
		}
		for (int j = 90; j < 101; j++)
		{
			if (StudentGlobals.GetStudentReplaced(j))
			{
				StudentJson studentJson = this.students[j];
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

	// Token: 0x04002740 RID: 10048
	[SerializeField]
	private StudentJson[] students;

	// Token: 0x04002741 RID: 10049
	[SerializeField]
	private CreditJson[] credits;

	// Token: 0x04002742 RID: 10050
	[SerializeField]
	private TopicJson[] topics;
}
