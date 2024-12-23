using UnityEngine;

public class PrisonerManagerScript : MonoBehaviour
{
	public HomePrisonerChanScript[] Prisoners;

	public JsonScript JSON;

	public Collider[] PrisonerTrigger;

	public Transform[] SpawnPoints;

	public Transform[] Destination;

	public Transform[] Target;

	public UILabel[] PrisonerLabel;

	public GameObject[] Boxes;

	public GameObject[] Tapes;

	public string[] IdleAnims;

	public Vector3 OriginalDestination;

	public Vector3 OriginalTarget;

	public HomeYandereScript Yandere;

	public GameObject Student;

	public GameObject MaleStudent;

	public int PrisonersToSpawn;

	public int PrisonersSpawned;

	public int ChosenPrisoner;

	public int StudentID;

	public bool[] Genders;

	public int TotalShuffles;

	private void Start()
	{
		OriginalDestination = Destination[0].transform.position;
		OriginalTarget = Target[0].transform.position;
		for (int i = 1; i < Boxes.Length; i++)
		{
			Boxes[i].SetActive(value: true);
			if (Tapes[i] != null)
			{
				Tapes[i].SetActive(value: false);
			}
		}
		ShufflePrisoners();
		if (StudentGlobals.Prisoner1 > 0)
		{
			PrisonersToSpawn++;
		}
		if (StudentGlobals.Prisoner2 > 0)
		{
			PrisonersToSpawn++;
		}
		if (StudentGlobals.Prisoner3 > 0)
		{
			PrisonersToSpawn++;
		}
		if (StudentGlobals.Prisoner4 > 0)
		{
			PrisonersToSpawn++;
		}
		if (StudentGlobals.Prisoner5 > 0)
		{
			PrisonersToSpawn++;
		}
		if (StudentGlobals.Prisoner6 > 0)
		{
			PrisonersToSpawn++;
		}
		if (StudentGlobals.Prisoner7 > 0)
		{
			PrisonersToSpawn++;
		}
		if (StudentGlobals.Prisoner8 > 0)
		{
			PrisonersToSpawn++;
		}
		if (StudentGlobals.Prisoner9 > 0)
		{
			PrisonersToSpawn++;
		}
		if (StudentGlobals.Prisoner10 > 0)
		{
			PrisonersToSpawn++;
		}
		PrisonersToSpawn = StudentGlobals.Prisoners;
		if (StudentGlobals.Prisoner1 > 0 && JSON.Students[StudentGlobals.Prisoner1].Gender == 1)
		{
			Genders[1] = true;
		}
		if (StudentGlobals.Prisoner2 > 0 && JSON.Students[StudentGlobals.Prisoner2].Gender == 1)
		{
			Genders[2] = true;
		}
		if (StudentGlobals.Prisoner3 > 0 && JSON.Students[StudentGlobals.Prisoner3].Gender == 1)
		{
			Genders[3] = true;
		}
		if (StudentGlobals.Prisoner4 > 0 && JSON.Students[StudentGlobals.Prisoner4].Gender == 1)
		{
			Genders[4] = true;
		}
		if (StudentGlobals.Prisoner5 > 0 && JSON.Students[StudentGlobals.Prisoner5].Gender == 1)
		{
			Genders[5] = true;
		}
		if (StudentGlobals.Prisoner6 > 0 && JSON.Students[StudentGlobals.Prisoner6].Gender == 1)
		{
			Genders[6] = true;
		}
		if (StudentGlobals.Prisoner7 > 0 && JSON.Students[StudentGlobals.Prisoner7].Gender == 1)
		{
			Genders[7] = true;
		}
		if (StudentGlobals.Prisoner8 > 0 && JSON.Students[StudentGlobals.Prisoner8].Gender == 1)
		{
			Genders[8] = true;
		}
		if (StudentGlobals.Prisoner9 > 0 && JSON.Students[StudentGlobals.Prisoner9].Gender == 1)
		{
			Genders[9] = true;
		}
		if (StudentGlobals.Prisoner10 > 0 && JSON.Students[StudentGlobals.Prisoner10].Gender == 1)
		{
			Genders[10] = true;
		}
		while (PrisonersToSpawn > PrisonersSpawned)
		{
			if (PrisonersSpawned > 0)
			{
				GameObject gameObject = null;
				string text = "";
				if (Genders[PrisonersSpawned + 1])
				{
					gameObject = Object.Instantiate(MaleStudent, SpawnPoints[PrisonersSpawned + 1].position, SpawnPoints[PrisonersSpawned + 1].rotation);
					text = "_male";
				}
				else
				{
					gameObject = Object.Instantiate(Student, SpawnPoints[PrisonersSpawned + 1].position, SpawnPoints[PrisonersSpawned + 1].rotation);
				}
				HomePrisonerChanScript component = gameObject.GetComponent<HomePrisonerChanScript>();
				component.PrisonerID = PrisonersSpawned + 1;
				component.IdleAnim = IdleAnims[component.PrisonerID] + text;
				Prisoners[PrisonersSpawned + 1] = component;
				StudentScript component2 = gameObject.GetComponent<StudentScript>();
				component2.enabled = false;
				if (PrisonersSpawned == 0)
				{
					component2.StudentID = StudentGlobals.Prisoner1;
				}
				else if (PrisonersSpawned == 1)
				{
					component2.StudentID = StudentGlobals.Prisoner2;
				}
				else if (PrisonersSpawned == 2)
				{
					component2.StudentID = StudentGlobals.Prisoner3;
				}
				else if (PrisonersSpawned == 3)
				{
					component2.StudentID = StudentGlobals.Prisoner4;
				}
				else if (PrisonersSpawned == 4)
				{
					component2.StudentID = StudentGlobals.Prisoner5;
				}
				else if (PrisonersSpawned == 5)
				{
					component2.StudentID = StudentGlobals.Prisoner6;
				}
				else if (PrisonersSpawned == 6)
				{
					component2.StudentID = StudentGlobals.Prisoner7;
				}
				else if (PrisonersSpawned == 7)
				{
					component2.StudentID = StudentGlobals.Prisoner8;
				}
				else if (PrisonersSpawned == 8)
				{
					component2.StudentID = StudentGlobals.Prisoner9;
				}
				else if (PrisonersSpawned == 9)
				{
					component2.StudentID = StudentGlobals.Prisoner10;
				}
				component2.Cosmetic.StudentID = component2.StudentID;
				component2.Cosmetic.Start();
			}
			Boxes[PrisonersSpawned + 1].SetActive(value: false);
			if (Tapes[PrisonersSpawned + 1] != null)
			{
				Tapes[PrisonersSpawned + 1].SetActive(value: true);
			}
			PrisonersSpawned++;
		}
		if (StudentGlobals.Prisoner1 > 0 && StudentGlobals.GetStudentHealth(StudentGlobals.Prisoner1) < 0)
		{
			StudentGlobals.SetStudentHealth(StudentGlobals.Prisoner1, 0);
		}
		if (StudentGlobals.Prisoner2 > 0 && StudentGlobals.GetStudentHealth(StudentGlobals.Prisoner2) < 0)
		{
			StudentGlobals.SetStudentHealth(StudentGlobals.Prisoner2, 0);
		}
		if (StudentGlobals.Prisoner3 > 0 && StudentGlobals.GetStudentHealth(StudentGlobals.Prisoner3) < 0)
		{
			StudentGlobals.SetStudentHealth(StudentGlobals.Prisoner3, 0);
		}
		if (StudentGlobals.Prisoner4 > 0 && StudentGlobals.GetStudentHealth(StudentGlobals.Prisoner4) < 0)
		{
			StudentGlobals.SetStudentHealth(StudentGlobals.Prisoner4, 0);
		}
		if (StudentGlobals.Prisoner5 > 0 && StudentGlobals.GetStudentHealth(StudentGlobals.Prisoner5) < 0)
		{
			StudentGlobals.SetStudentHealth(StudentGlobals.Prisoner5, 0);
		}
		if (StudentGlobals.Prisoner6 > 0 && StudentGlobals.GetStudentHealth(StudentGlobals.Prisoner6) < 0)
		{
			StudentGlobals.SetStudentHealth(StudentGlobals.Prisoner6, 0);
		}
		if (StudentGlobals.Prisoner7 > 0 && StudentGlobals.GetStudentHealth(StudentGlobals.Prisoner7) < 0)
		{
			StudentGlobals.SetStudentHealth(StudentGlobals.Prisoner7, 0);
		}
		if (StudentGlobals.Prisoner8 > 0 && StudentGlobals.GetStudentHealth(StudentGlobals.Prisoner8) < 0)
		{
			StudentGlobals.SetStudentHealth(StudentGlobals.Prisoner8, 0);
		}
		if (StudentGlobals.Prisoner9 > 0 && StudentGlobals.GetStudentHealth(StudentGlobals.Prisoner9) < 0)
		{
			StudentGlobals.SetStudentHealth(StudentGlobals.Prisoner9, 0);
		}
		if (StudentGlobals.Prisoner10 > 0 && StudentGlobals.GetStudentHealth(StudentGlobals.Prisoner10) < 0)
		{
			StudentGlobals.SetStudentHealth(StudentGlobals.Prisoner10, 0);
		}
	}

	private void Update()
	{
		int num = 0;
		for (int i = 1; i < PrisonersSpawned + 1; i++)
		{
			if (Vector3.Distance(Yandere.transform.position, Prisoners[i].transform.position) < 1f)
			{
				PrisonerLabel[1].text = "Prisoner # " + i;
				num = i;
			}
		}
		ChosenPrisoner = num;
		if (num > 0)
		{
			PrisonerLabel[1].alpha = Mathf.MoveTowards(PrisonerLabel[1].alpha, 1f, Time.deltaTime * 2f);
			PrisonerLabel[1].transform.position = Prisoners[num].Cosmetic.Student.Head.position + Vector3.up * 0.5f;
			PrisonerLabel[1].transform.LookAt(Camera.main.transform.position);
			PrisonerLabel[1].transform.Translate(PrisonerLabel[1].transform.right * -0.1f);
			PrisonerLabel[1].transform.eulerAngles += new Vector3(0f, 180f, 0f);
			PrisonerTrigger[0].transform.position = Yandere.transform.position;
			PrisonerTrigger[1].transform.position = Yandere.transform.position;
			if (ChosenPrisoner > 1)
			{
				Target[0].transform.position = Prisoners[num].Cosmetic.Student.Head.position;
				Target[1].transform.position = Prisoners[num].Cosmetic.Student.Head.position;
				if (ChosenPrisoner > 7)
				{
					Destination[0].transform.position = Prisoners[ChosenPrisoner].transform.position + Prisoners[ChosenPrisoner].transform.forward * 1.5f + Vector3.up * 1f;
				}
				else if (ChosenPrisoner > 5)
				{
					Destination[0].transform.position = Prisoners[ChosenPrisoner].transform.position + Prisoners[ChosenPrisoner].transform.forward * -0.5f + Vector3.up * 1.5f;
				}
				else if (ChosenPrisoner > 3)
				{
					Destination[0].transform.position = Prisoners[ChosenPrisoner].transform.position + Prisoners[ChosenPrisoner].transform.forward * 1.5f + Vector3.up * 0.5f;
				}
				else
				{
					Destination[0].transform.position = Prisoners[ChosenPrisoner].transform.position + Prisoners[ChosenPrisoner].transform.right * 1.5f + Vector3.up * 1f;
				}
				Destination[1].transform.position = Destination[0].transform.position;
			}
			else
			{
				Target[0].transform.position = OriginalTarget;
				Destination[0].transform.position = OriginalDestination;
				Target[1].transform.position = OriginalTarget;
				Destination[1].transform.position = OriginalDestination;
			}
			if (!Yandere.CanMove)
			{
				PrisonerLabel[1].alpha = 0f;
			}
			if (ChosenPrisoner == 1)
			{
				StudentID = StudentGlobals.Prisoner1;
			}
			else if (ChosenPrisoner == 2)
			{
				StudentID = StudentGlobals.Prisoner2;
			}
			else if (ChosenPrisoner == 3)
			{
				StudentID = StudentGlobals.Prisoner3;
			}
			else if (ChosenPrisoner == 4)
			{
				StudentID = StudentGlobals.Prisoner4;
			}
			else if (ChosenPrisoner == 5)
			{
				StudentID = StudentGlobals.Prisoner5;
			}
			else if (ChosenPrisoner == 6)
			{
				StudentID = StudentGlobals.Prisoner6;
			}
			else if (ChosenPrisoner == 7)
			{
				StudentID = StudentGlobals.Prisoner7;
			}
			else if (ChosenPrisoner == 8)
			{
				StudentID = StudentGlobals.Prisoner8;
			}
			else if (ChosenPrisoner == 9)
			{
				StudentID = StudentGlobals.Prisoner9;
			}
			else if (ChosenPrisoner == 10)
			{
				StudentID = StudentGlobals.Prisoner10;
			}
		}
		else
		{
			PrisonerLabel[1].alpha = Mathf.MoveTowards(PrisonerLabel[1].alpha, 0f, Time.deltaTime * 2f);
			PrisonerTrigger[0].transform.position = new Vector3(100f, 100f, 100f);
			PrisonerTrigger[1].transform.position = new Vector3(100f, 100f, 100f);
		}
		PrisonerLabel[0].text = PrisonerLabel[1].text;
		PrisonerLabel[0].alpha = PrisonerLabel[1].alpha;
		PrisonerLabel[0].transform.position = PrisonerLabel[1].transform.position;
		PrisonerLabel[0].transform.rotation = PrisonerLabel[1].transform.rotation;
	}

	private void ShufflePrisoners()
	{
		if (StudentGlobals.Prisoners <= 0)
		{
			return;
		}
		int num = 0;
		if (StudentGlobals.Prisoner1 == 0 && StudentGlobals.Prisoners > 0)
		{
			StudentGlobals.Prisoner1 = StudentGlobals.Prisoner2;
			StudentGlobals.Prisoner2 = StudentGlobals.Prisoner3;
			StudentGlobals.Prisoner3 = StudentGlobals.Prisoner4;
			StudentGlobals.Prisoner4 = StudentGlobals.Prisoner5;
			StudentGlobals.Prisoner5 = StudentGlobals.Prisoner6;
			StudentGlobals.Prisoner6 = StudentGlobals.Prisoner7;
			StudentGlobals.Prisoner7 = StudentGlobals.Prisoner8;
			StudentGlobals.Prisoner8 = StudentGlobals.Prisoner9;
			StudentGlobals.Prisoner9 = StudentGlobals.Prisoner10;
			StudentGlobals.Prisoner10 = 0;
			num++;
		}
		if (StudentGlobals.Prisoner2 == 0 && StudentGlobals.Prisoners > 1)
		{
			StudentGlobals.Prisoner2 = StudentGlobals.Prisoner3;
			StudentGlobals.Prisoner3 = StudentGlobals.Prisoner4;
			StudentGlobals.Prisoner4 = StudentGlobals.Prisoner5;
			StudentGlobals.Prisoner5 = StudentGlobals.Prisoner6;
			StudentGlobals.Prisoner6 = StudentGlobals.Prisoner7;
			StudentGlobals.Prisoner7 = StudentGlobals.Prisoner8;
			StudentGlobals.Prisoner8 = StudentGlobals.Prisoner9;
			StudentGlobals.Prisoner9 = StudentGlobals.Prisoner10;
			StudentGlobals.Prisoner10 = 0;
			num++;
		}
		if (StudentGlobals.Prisoner3 == 0 && StudentGlobals.Prisoners > 2)
		{
			StudentGlobals.Prisoner3 = StudentGlobals.Prisoner4;
			StudentGlobals.Prisoner4 = StudentGlobals.Prisoner5;
			StudentGlobals.Prisoner5 = StudentGlobals.Prisoner6;
			StudentGlobals.Prisoner6 = StudentGlobals.Prisoner7;
			StudentGlobals.Prisoner7 = StudentGlobals.Prisoner8;
			StudentGlobals.Prisoner8 = StudentGlobals.Prisoner9;
			StudentGlobals.Prisoner9 = StudentGlobals.Prisoner10;
			StudentGlobals.Prisoner10 = 0;
			num++;
		}
		if (StudentGlobals.Prisoner4 == 0 && StudentGlobals.Prisoners > 3)
		{
			StudentGlobals.Prisoner4 = StudentGlobals.Prisoner5;
			StudentGlobals.Prisoner5 = StudentGlobals.Prisoner6;
			StudentGlobals.Prisoner6 = StudentGlobals.Prisoner7;
			StudentGlobals.Prisoner7 = StudentGlobals.Prisoner8;
			StudentGlobals.Prisoner8 = StudentGlobals.Prisoner9;
			StudentGlobals.Prisoner9 = StudentGlobals.Prisoner10;
			StudentGlobals.Prisoner10 = 0;
			num++;
		}
		if (StudentGlobals.Prisoner5 == 0 && StudentGlobals.Prisoners > 4)
		{
			StudentGlobals.Prisoner5 = StudentGlobals.Prisoner6;
			StudentGlobals.Prisoner6 = StudentGlobals.Prisoner7;
			StudentGlobals.Prisoner7 = StudentGlobals.Prisoner8;
			StudentGlobals.Prisoner8 = StudentGlobals.Prisoner9;
			StudentGlobals.Prisoner9 = StudentGlobals.Prisoner10;
			StudentGlobals.Prisoner10 = 0;
			num++;
		}
		if (StudentGlobals.Prisoner6 == 0 && StudentGlobals.Prisoners > 5)
		{
			StudentGlobals.Prisoner6 = StudentGlobals.Prisoner7;
			StudentGlobals.Prisoner7 = StudentGlobals.Prisoner8;
			StudentGlobals.Prisoner8 = StudentGlobals.Prisoner9;
			StudentGlobals.Prisoner9 = StudentGlobals.Prisoner10;
			StudentGlobals.Prisoner10 = 0;
			num++;
		}
		if (StudentGlobals.Prisoner7 == 0 && StudentGlobals.Prisoners > 6)
		{
			StudentGlobals.Prisoner7 = StudentGlobals.Prisoner8;
			StudentGlobals.Prisoner8 = StudentGlobals.Prisoner9;
			StudentGlobals.Prisoner9 = StudentGlobals.Prisoner10;
			StudentGlobals.Prisoner10 = 0;
			num++;
		}
		if (StudentGlobals.Prisoner8 == 0 && StudentGlobals.Prisoners > 7)
		{
			StudentGlobals.Prisoner8 = StudentGlobals.Prisoner9;
			StudentGlobals.Prisoner9 = StudentGlobals.Prisoner10;
			StudentGlobals.Prisoner10 = 0;
			num++;
		}
		if (StudentGlobals.Prisoner9 == 0 && StudentGlobals.Prisoners > 8)
		{
			StudentGlobals.Prisoner9 = StudentGlobals.Prisoner10;
			StudentGlobals.Prisoner10 = 0;
			num++;
		}
		if (num > 0)
		{
			Debug.Log("Yeah, we needed to shuffle 'em!");
			TotalShuffles++;
			if (TotalShuffles < 100)
			{
				ShufflePrisoners();
			}
			else
			{
				Debug.Log("Holy fuck, we just shuffled over 100 times. Something went wrong.");
			}
		}
	}
}
