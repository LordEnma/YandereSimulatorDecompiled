using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000344 RID: 836
public class JsonScript : MonoBehaviour
{
	// Token: 0x0600191F RID: 6431 RVA: 0x000FA6C4 File Offset: 0x000F88C4
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

	// Token: 0x17000490 RID: 1168
	// (get) Token: 0x06001920 RID: 6432 RVA: 0x000FA74C File Offset: 0x000F894C
	public StudentJson[] Students
	{
		get
		{
			return this.students;
		}
	}

	// Token: 0x17000491 RID: 1169
	// (get) Token: 0x06001921 RID: 6433 RVA: 0x000FA754 File Offset: 0x000F8954
	public CreditJson[] Credits
	{
		get
		{
			return this.credits;
		}
	}

	// Token: 0x17000492 RID: 1170
	// (get) Token: 0x06001922 RID: 6434 RVA: 0x000FA75C File Offset: 0x000F895C
	public TopicJson[] Topics
	{
		get
		{
			return this.topics;
		}
	}

	// Token: 0x06001923 RID: 6435 RVA: 0x000FA764 File Offset: 0x000F8964
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

	// Token: 0x04002735 RID: 10037
	[SerializeField]
	private StudentJson[] students;

	// Token: 0x04002736 RID: 10038
	[SerializeField]
	private CreditJson[] credits;

	// Token: 0x04002737 RID: 10039
	[SerializeField]
	private TopicJson[] topics;
}
