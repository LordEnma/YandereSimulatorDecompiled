using UnityEngine;

public class TaskManagerScript : MonoBehaviour
{
	public GravurePhotoShootScript GravureShoot;

	public StudentManagerScript StudentManager;

	public WeaponManagerScript WeaponManager;

	public YandereScript Yandere;

	public ClockScript Clock;

	public Transform MuddyFootprintParent;

	public GameObject[] TaskObjects;

	public PromptScript[] Prompts;

	public TapePlayerScript TapePlayer;

	public TaskKittenScript Kitten;

	public PickUpScript AmaiPlate;

	public ClothScript Cloth;

	public bool[] GirlsQuestioned;

	public GameObject CarBattery;

	public GameObject FixedDummy;

	public GameObject Flyers;

	public GameObject Books;

	public int[] TaskStatus;

	public bool Initialized;

	public bool Eighties;

	public bool Mentored;

	public bool Custom;

	public bool Impossible;

	public bool Proceed;

	public void Start()
	{
		if (GameGlobals.EightiesTutorial)
		{
			for (int i = 1; i < TaskObjects.Length; i++)
			{
				if (TaskObjects[i] != null)
				{
					TaskObjects[i].SetActive(value: false);
				}
			}
		}
		Custom = GameGlobals.CustomMode;
	}

	public void GetTaskStatus()
	{
		if (!Initialized)
		{
			for (int i = 1; i < 101; i++)
			{
				TaskStatus[i] = TaskGlobals.GetTaskStatus(i);
				if (TaskStatus[i] == 1)
				{
					Debug.Log("Task #" + i + " has been accepted by the player.");
				}
			}
			for (int j = 1; j < TaskObjects.Length; j++)
			{
				if (TaskObjects[j] != null)
				{
					TaskObjects[j].SetActive(value: false);
				}
			}
			if (TaskStatus[46] == 1)
			{
				TaskGlobals.SetTaskStatus(46, 0);
				TaskStatus[46] = 0;
			}
			if (StudentManager != null)
			{
				UpdateTaskStatus();
			}
			if (GameGlobals.Eighties)
			{
				if (MuddyFootprintParent != null)
				{
					MuddyFootprintParent.gameObject.SetActive(value: false);
				}
				Eighties = true;
			}
			if (Eighties)
			{
				for (int k = 1; k < 101; k++)
				{
					if (TaskStatus[k] != 1)
					{
						continue;
					}
					Debug.Log("Task #" + k + " has been accepted by the player.");
					if (StudentManager.Students[k] != null)
					{
						Debug.Log("Student #" + k + " is not null.");
						if (StudentManager.GenericTaskIDs[k] > 0)
						{
							Yandere.Inventory.ItemsRequested[StudentManager.GenericTaskIDs[k]]++;
							Debug.Log("The TaskManager has determined that the player has been asked to obtain Generic Item #" + StudentManager.GenericTaskIDs[k]);
						}
						else
						{
							Debug.Log("Student #" + k + " doesn't have a generic task.");
						}
					}
					else
					{
						Debug.Log("However, Student #" + k + " is null.");
					}
				}
			}
		}
		Initialized = true;
	}

	public void CheckTaskPickups()
	{
		if (StudentManager.Eighties)
		{
			return;
		}
		if (TaskStatus[4] == 1 && Prompts[4].Circle[3] != null && Prompts[4].Circle[3].fillAmount == 0f)
		{
			if (StudentManager.Students[4] != null)
			{
				StudentManager.Students[4].TaskPhase = 5;
			}
			TaskStatus[4] = 2;
			Object.Destroy(TaskObjects[4]);
		}
		if (TaskStatus[11] == 1 && Prompts[11].Circle[3] != null && Prompts[11].Circle[3].fillAmount == 0f)
		{
			if (StudentManager.Students[11] != null)
			{
				StudentManager.Students[11].TaskPhase = 5;
			}
			Yandere.NotificationManager.TopicName = "Cats";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
			StudentManager.SetTopicLearnedByStudent(15, 11, boolean: true);
			TaskStatus[11] = 2;
			Object.Destroy(TaskObjects[11]);
		}
		if (TaskStatus[25] == 1 && Prompts[25].Circle[3].fillAmount == 0f)
		{
			if (StudentManager.Students[25] != null)
			{
				StudentManager.Students[25].TaskPhase = 5;
			}
			TaskStatus[25] = 2;
			Object.Destroy(TaskObjects[25]);
		}
		if (TaskStatus[37] == 1 && Prompts[37].Circle[3] != null && Prompts[37].Circle[3].fillAmount == 0f)
		{
			if (StudentManager.Students[37] != null)
			{
				StudentManager.Students[37].TaskPhase = 5;
			}
			TaskStatus[37] = 2;
			Object.Destroy(TaskObjects[37]);
		}
		if (TaskStatus[41] == 1 && Prompts[41].Circle[3] != null && Prompts[41].Circle[3].fillAmount == 0f)
		{
			if (StudentManager.Students[41] != null)
			{
				StudentManager.Students[41].TaskPhase = 5;
			}
			TaskStatus[41] = 2;
			Object.Destroy(TaskObjects[41]);
		}
	}

	public void UpdateTaskStatus()
	{
		if (!StudentManager.Eighties)
		{
			if (TaskStatus[4] == 1)
			{
				if (StudentManager.Students[4] != null)
				{
					if (StudentManager.Students[4].TaskPhase == 0)
					{
						StudentManager.Students[4].TaskPhase = 4;
					}
					TaskObjects[4].SetActive(value: true);
				}
			}
			else if (TaskObjects[4] != null)
			{
				TaskObjects[4].SetActive(value: false);
			}
			if (TaskStatus[8] == 1 && StudentManager.Students[8] != null)
			{
				if (StudentManager.Students[8].TaskPhase == 0)
				{
					StudentManager.Students[8].TaskPhase = 4;
				}
				if (Yandere.Inventory.Soda)
				{
					StudentManager.Students[8].TaskPhase = 5;
				}
			}
			if (TaskStatus[11] == 1)
			{
				if (StudentManager.Students[11] != null)
				{
					if (StudentManager.Students[11].TaskPhase == 0)
					{
						StudentManager.Students[11].TaskPhase = 4;
					}
					TaskObjects[11].SetActive(value: true);
				}
			}
			else if (TaskObjects[11] != null)
			{
				TaskObjects[11].SetActive(value: false);
			}
			if (TaskStatus[12] == 1)
			{
				if (StudentManager.Students[12] != null)
				{
					if (StudentManager.Students[12].TaskPhase == 0)
					{
						StudentManager.Students[12].TaskPhase = 4;
					}
					if (!AmaiPlate.gameObject.activeInHierarchy)
					{
						TaskObjects[12].SetActive(value: true);
					}
				}
				if (AmaiPlate.Food == 0)
				{
					Debug.Log("Amai's task should be ready to turn in!");
					StudentManager.Students[12].TaskPhase = 5;
				}
			}
			else if (TaskObjects[12] != null)
			{
				TaskObjects[12].SetActive(value: false);
			}
			if (TaskStatus[21] == 1)
			{
				int num = 0;
				for (int i = 1; i < 26; i++)
				{
					if (StudentManager.OpinionsLearned.StudentOpinions[12].Opinions[i])
					{
						num++;
					}
				}
				Debug.Log("Current number of opinions learned is: " + num);
				if (num == 25)
				{
					Debug.Log("Shoko's task should be ready to turn in!");
					StudentManager.Students[21].TaskPhase = 5;
				}
			}
			if (TaskStatus[25] == 1)
			{
				if (StudentManager.Students[25] != null)
				{
					if (StudentManager.Students[25].TaskPhase == 0)
					{
						StudentManager.Students[25].TaskPhase = 4;
					}
					TaskObjects[25].SetActive(value: true);
				}
			}
			else if (TaskObjects[25] != null)
			{
				TaskObjects[25].SetActive(value: false);
			}
			if (TaskStatus[28] == 1 && StudentManager.Students[28] != null)
			{
				if (StudentManager.Students[28].TaskPhase == 0)
				{
					StudentManager.Students[28].TaskPhase = 4;
				}
				for (int j = 1; j < 26; j++)
				{
					if (Yandere.PauseScreen.PhotoGallery.KittenPhoto[j])
					{
						Debug.Log("Riku's Task can be turned in.");
						StudentManager.Students[28].TaskPhase = 5;
					}
				}
			}
			if (TaskStatus[30] == 1 && StudentManager.Students[30] != null && StudentManager.Students[30].TaskPhase == 0)
			{
				StudentManager.Students[30].TaskPhase = 4;
			}
			if (TaskStatus[36] == 1 && StudentManager.Students[36] != null)
			{
				if (StudentManager.Students[36].TaskPhase == 0)
				{
					StudentManager.Students[36].TaskPhase = 4;
				}
				if (GirlsQuestioned[1] && GirlsQuestioned[2] && GirlsQuestioned[3] && GirlsQuestioned[4] && GirlsQuestioned[5])
				{
					Debug.Log("Gema's task should be ready to turn in!");
					StudentManager.Students[36].TaskPhase = 5;
				}
			}
			if (TaskStatus[37] == 1)
			{
				if (StudentManager.Students[37] != null)
				{
					if (StudentManager.Students[37].TaskPhase == 0)
					{
						StudentManager.Students[37].TaskPhase = 4;
					}
					TaskObjects[37].SetActive(value: true);
				}
			}
			else if (TaskObjects[37] != null)
			{
				TaskObjects[37].SetActive(value: false);
			}
			if (TaskStatus[38] == 1)
			{
				if (StudentManager.Students[38] != null && StudentManager.Students[38].TaskPhase == 0)
				{
					StudentManager.Students[38].TaskPhase = 4;
				}
			}
			else if (TaskStatus[38] == 2 && StudentManager.Students[38] != null)
			{
				StudentManager.Students[38].TaskPhase = 5;
			}
			if (TaskStatus[41] == 1)
			{
				if (StudentManager.Students[41] != null)
				{
					if (StudentManager.Students[41].TaskPhase == 0)
					{
						StudentManager.Students[41].TaskPhase = 4;
					}
					TaskObjects[41].SetActive(value: true);
				}
			}
			else if (TaskObjects[41] != null)
			{
				TaskObjects[41].SetActive(value: false);
			}
			if (TaskStatus[46] == 1 && StudentManager.Students[46] != null)
			{
				if (StudentManager.Students[46].TaskPhase == 0)
				{
					StudentManager.Students[46].TaskPhase = 4;
				}
				if (StudentManager.Students[10] != null && Vector3.Distance(StudentManager.Students[46].transform.position, StudentManager.Students[10].transform.position) < 2f)
				{
					Debug.Log("Budo's task should be ready to turn in!");
					StudentManager.Students[46].TaskPhase = 5;
				}
			}
			if (TaskStatus[47] == 1 && StudentManager.Students[47] != null)
			{
				if (StudentManager.Students[47].TaskPhase == 0)
				{
					StudentManager.Students[47].TaskPhase = 4;
				}
				if (StudentManager.CombatMinigame.PracticeWindow.DefeatedSho)
				{
					Debug.Log("Sho's task should be ready to turn in!");
					StudentManager.Students[47].TaskPhase = 5;
				}
			}
			if (TaskStatus[48] == 1 && StudentManager.Students[48] != null)
			{
				if (StudentManager.Students[48].TaskPhase == 0)
				{
					StudentManager.Students[48].TaskPhase = 4;
				}
				Yandere.WeaponManager.DumbbellCheck(48);
				if (Yandere.WeaponManager.DumbbellNear)
				{
					Debug.Log("Juku's task should be ready to turn in!");
					StudentManager.Students[48].TaskPhase = 5;
				}
			}
			if (TaskStatus[49] == 1 && StudentManager.Students[49] != null)
			{
				if (StudentManager.Students[49].TaskPhase == 0)
				{
					StudentManager.Students[49].TaskPhase = 4;
				}
				if (MuddyFootprintParent.childCount == 0)
				{
					Debug.Log("Mina's task should be ready to turn in!");
					StudentManager.Students[49].TaskPhase = 5;
				}
			}
			if (TaskStatus[50] == 1 && StudentManager.Students[50] != null)
			{
				if (StudentManager.Students[50].TaskPhase == 0)
				{
					StudentManager.Students[50].TaskPhase = 4;
				}
				if (FixedDummy.activeInHierarchy)
				{
					Debug.Log("Shima's task should be ready to turn in!");
					StudentManager.Students[50].TaskPhase = 5;
				}
			}
			if (ClubGlobals.GetClubClosed(ClubType.LightMusic) || StudentManager.Students[51] == null)
			{
				if (StudentManager.Students[52] != null)
				{
					StudentManager.Students[52].TaskPhase = 100;
				}
				TaskStatus[52] = 100;
			}
			else if (TaskStatus[52] == 1 && StudentManager.Students[52] != null)
			{
				StudentManager.Students[52].TaskPhase = 4;
				for (int k = 1; k < 26; k++)
				{
					if (Yandere.PauseScreen.PhotoGallery.GuitarPhoto[k])
					{
						StudentManager.Students[52].TaskPhase = 5;
					}
				}
			}
			if (TaskStatus[65] == 1 && StudentManager.Students[65] != null)
			{
				if (StudentManager.Students[65].TaskPhase == 0)
				{
					StudentManager.Students[65].TaskPhase = 4;
				}
				if (Vector3.Distance(StudentManager.Students[65].transform.position, CarBattery.transform.position) < 2f || (Yandere.Bookbag != null && Yandere.Bookbag.ConcealedPickup != null && Yandere.Bookbag.ConcealedPickup.gameObject == CarBattery && Vector3.Distance(StudentManager.Students[65].transform.position, Yandere.Bookbag.transform.position) < 2f))
				{
					Debug.Log("Homu's Task can be turned in.");
					StudentManager.Students[65].TaskPhase = 5;
				}
				else
				{
					StudentManager.Students[65].TaskPhase = 4;
				}
			}
			if (TaskStatus[81] != 1 || !(StudentManager.Students[81] != null))
			{
				return;
			}
			if (StudentManager.Students[81].TaskPhase == 0)
			{
				StudentManager.Students[81].TaskPhase = 4;
			}
			for (int l = 1; l < 26; l++)
			{
				if (Yandere.PauseScreen.PhotoGallery.HorudaPhoto[l])
				{
					Debug.Log("Musume's Task can be turned in.");
					StudentManager.Students[81].TaskPhase = 5;
				}
			}
		}
		else
		{
			if (Custom)
			{
				return;
			}
			if (TaskStatus[11] == 1 && StudentManager.Students[11] != null)
			{
				if (!Yandere.Inventory.PinkCloth)
				{
					Cloth.PinkSockTask = true;
				}
				if (Yandere.Inventory.PinkSocks)
				{
					Debug.Log("Cutesy's task should be ready to turn in!");
					StudentManager.Students[11].TaskPhase = 5;
				}
			}
			if (TaskStatus[12] == 1 && StudentManager.Students[12] != null)
			{
				int num2 = 0;
				for (int m = 6; m < 11; m++)
				{
					for (int n = 1; n < 26; n++)
					{
						if (StudentManager.OpinionsLearned.StudentOpinions[m].Opinions[n])
						{
							num2++;
						}
					}
				}
				Debug.Log("Current number of opinions learned is: " + num2);
				if (num2 > 9)
				{
					Debug.Log("Fiery's task should be ready to turn in!");
					StudentManager.Students[12].TaskPhase = 5;
				}
			}
			if (TaskStatus[13] == 1 && StudentManager.Students[13] != null)
			{
				Flyers.transform.parent.gameObject.SetActive(value: true);
				if (Flyers.activeInHierarchy && Yandere.Inventory.Flyers == 0)
				{
					Debug.Log("Bookworm's task should be ready to turn in!");
					StudentManager.Students[13].TaskPhase = 5;
				}
			}
			if (TaskStatus[14] == 1)
			{
				Debug.Log("Sporty's TaskStatus is 1.");
				if (StudentManager.Students[14] != null)
				{
					Debug.Log("She's at school.");
					Kitten.gameObject.SetActive(value: true);
					if (Kitten.Caught && Vector3.Distance(StudentManager.Students[14].transform.position, Kitten.gameObject.transform.position) < 5f)
					{
						Debug.Log("Sporty's task should be ready to turn in!");
						StudentManager.Students[14].TaskPhase = 5;
					}
				}
			}
			if (TaskStatus[15] == 1 && StudentManager.Students[15] != null)
			{
				if (Yandere.Inventory.Money > 999.99f)
				{
					Debug.Log("Rich's task should be ready to turn in!");
					StudentManager.Students[15].TaskPhase = 5;
				}
				else
				{
					StudentManager.Students[15].TaskPhase = 4;
				}
			}
			if (TaskStatus[16] == 1 && StudentManager.Students[16] != null)
			{
				TapePlayer.Prompt.enabled = true;
				if (TapePlayer.MelodyRecording)
				{
					Debug.Log("Idol's task should be ready to turn in!");
					StudentManager.Students[16].TaskPhase = 5;
				}
			}
			if (TaskStatus[17] == 1 && StudentManager.Students[17] != null)
			{
				Books.transform.parent.gameObject.SetActive(value: true);
				if (Books.activeInHierarchy && Yandere.Inventory.Books == 0)
				{
					Debug.Log("Prodigy's task should be ready to turn in!");
					StudentManager.Students[17].TaskPhase = 5;
				}
			}
			if (TaskStatus[18] == 1 && StudentManager.Students[18] != null && Yandere.Friends > 19)
			{
				Debug.Log("Traditional's task should be ready to turn in!");
				StudentManager.Students[18].TaskPhase = 5;
			}
			if (TaskStatus[19] == 1 && StudentManager.Students[19] != null)
			{
				GravureShoot.gameObject.SetActive(value: true);
				if (GravureShoot.Complete)
				{
					Debug.Log("Gravure's task should be ready to turn in!");
					StudentManager.Students[19].TaskPhase = 5;
				}
			}
			if (TaskStatus[20] == 1 && StudentManager.Students[20] != null && Clock.HourTime < 8f && WeaponManager.Weapons[1] != null && Vector3.Distance(StudentManager.Students[20].transform.position, WeaponManager.Weapons[1].transform.position) < 3f)
			{
				Debug.Log("Investigator's task should be ready to turn in!");
				StudentManager.Students[20].TaskPhase = 5;
			}
			if (TaskStatus[79] == 1 && StudentManager.Students[79] != null)
			{
				Debug.Log("Telling Yakuza's litle brother to change his destination.");
				Debug.Log("StudentManager.Students[79].ScheduleBlocks.Length is: " + StudentManager.Students[79].ScheduleBlocks.Length);
				if (StudentManager.Students[79].ScheduleBlocks.Length >= 8)
				{
					ScheduleBlock obj = StudentManager.Students[79].ScheduleBlocks[6];
					obj.destination = "Wait";
					obj.action = "Wait";
					ScheduleBlock obj2 = StudentManager.Students[79].ScheduleBlocks[7];
					obj2.destination = "Wait";
					obj2.action = "Wait";
				}
				else
				{
					Debug.Log("Uh, there was a problem! Yakuza bro's scheduleblock length is too low?!");
				}
				StudentManager.Students[79].GetDestinations();
			}
		}
	}

	public void CheckTaskRequirement(int StudentID)
	{
		Impossible = false;
		Proceed = false;
		if (!Eighties)
		{
			switch (StudentID)
			{
			case 21:
				if (DateGlobals.Week == 2)
				{
					Proceed = true;
				}
				break;
			case 46:
			{
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool num = StudentManager.Students[47] != null && StudentManager.Students[47].Friend;
				flag = StudentManager.Students[48] != null && StudentManager.Students[48].Friend;
				flag2 = StudentManager.Students[49] != null && StudentManager.Students[49].Friend;
				flag3 = StudentManager.Students[50] != null && StudentManager.Students[50].Friend;
				if (!num || !flag || !flag2 || !flag3)
				{
					Proceed = false;
				}
				else
				{
					Proceed = true;
				}
				break;
			}
			}
		}
		else
		{
			switch (StudentID)
			{
			case 12:
			{
				bool flag4 = false;
				bool flag5 = false;
				bool flag6 = false;
				bool flag7 = false;
				bool num2 = StudentManager.Students[6] != null && StudentManager.Students[6].Friend;
				flag4 = StudentManager.Students[7] != null && StudentManager.Students[7].Friend;
				flag5 = StudentManager.Students[8] != null && StudentManager.Students[8].Friend;
				flag6 = StudentManager.Students[9] != null && StudentManager.Students[9].Friend;
				flag7 = StudentManager.Students[10] != null && StudentManager.Students[10].Friend;
				if (num2 || flag4 || flag5 || flag6 || flag7)
				{
					Proceed = true;
				}
				if (StudentManager.Students[6] == null && StudentManager.Students[7] == null && StudentManager.Students[8] == null && StudentManager.Students[9] == null && StudentManager.Students[10] == null)
				{
					Impossible = true;
				}
				break;
			}
			case 13:
				if (Yandere.Class.LanguageGrade > 0)
				{
					Proceed = true;
				}
				break;
			case 14:
				if (Yandere.Class.PhysicalGrade > 0)
				{
					Proceed = true;
				}
				break;
			case 15:
				if (Yandere.Inventory.Money > 499.99f)
				{
					Proceed = true;
				}
				break;
			case 16:
				if (Yandere.Club == ClubType.LightMusic)
				{
					Proceed = true;
				}
				if (ClubGlobals.GetClubClosed(ClubType.LightMusic))
				{
					Impossible = true;
				}
				break;
			case 17:
				if (Yandere.Class.BiologyGrade == 5 || Yandere.Class.ChemistryGrade == 5 || Yandere.Class.LanguageGrade == 5 || Yandere.Class.PhysicalGrade == 5 || Yandere.Class.PsychologyGrade == 5)
				{
					Proceed = true;
				}
				break;
			case 18:
				if (Yandere.Friends > 9 || PlayerGlobals.Friends + Yandere.Police.EndOfDay.NewFriends > 9)
				{
					Proceed = true;
				}
				break;
			case 19:
				if (Yandere.EightiesBikiniAttacher.newRenderer != null && Yandere.EightiesBikiniAttacher.newRenderer.enabled)
				{
					Proceed = true;
				}
				break;
			case 20:
				if (Yandere.Inventory.IDCard)
				{
					Proceed = true;
				}
				break;
			}
		}
		if (Proceed)
		{
			Debug.Log("Hey, the player meets the criteria to unlock this character's Task!");
		}
	}

	public void SaveTaskStatuses()
	{
		for (int i = 1; i < 101; i++)
		{
			TaskGlobals.SetTaskStatus(i, TaskStatus[i]);
			if (StudentManager.Students[i] != null)
			{
				PlayerGlobals.SetStudentFriend(i, StudentManager.Students[i].Friend);
			}
		}
	}
}
