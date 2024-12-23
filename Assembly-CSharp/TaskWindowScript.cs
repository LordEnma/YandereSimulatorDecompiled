using UnityEngine;

public class TaskWindowScript : MonoBehaviour
{
	public CheckOutBookScript HomeworkAssignment;

	public DialogueWheelScript DialogueWheel;

	public SewingMachineScript SewingMachine;

	public CheckOutBookScript CheckOutBook;

	public TaskManagerScript TaskManager;

	public PromptBarScript PromptBar;

	public UILabel TaskDescLabel;

	public YandereScript Yandere;

	public UITexture Portrait;

	public UITexture Icon;

	public GameObject[] TaskCompleteLetters;

	public string[] GenericDescriptions;

	public string[] Descriptions;

	public Texture[] GenericIcons;

	public Texture[] Portraits;

	public Texture[] Icons;

	public bool TaskComplete;

	public bool CustomMode;

	public bool Eighties;

	public bool Generic;

	public GameObject Window;

	public int StudentID;

	public int ID;

	public float TrueTimer;

	public float Timer;

	public string[] EightiesDescriptions;

	public Texture[] EightiesIcons;

	public AudioClip EightiesJingle;

	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			GetComponent<AudioSource>().clip = EightiesJingle;
			GetComponent<AudioSource>().volume = 0.1f;
			Descriptions = EightiesDescriptions;
			Icons = EightiesIcons;
		}
		else
		{
			UpdateTaskObjects(30);
		}
		Window.SetActive(value: false);
		CustomMode = GameGlobals.CustomMode;
		Eighties = GameGlobals.Eighties;
	}

	public void UpdateWindow(int ID)
	{
		PromptBar.ClearButtons();
		PromptBar.Label[0].text = "Accept";
		PromptBar.Label[1].text = "Refuse";
		PromptBar.UpdateButtons();
		PromptBar.Show = true;
		GetPortrait(ID);
		StudentID = ID;
		Debug.Log("Updating window with information for Student #" + ID);
		TaskDescLabel.text = Descriptions[ID];
		Icon.mainTexture = Icons[ID];
		GenericCheck();
		if (CustomMode)
		{
			Generic = true;
		}
		if (Generic)
		{
			if (Yandere.StudentManager.Eighties)
			{
				ID = Yandere.StudentManager.GenericTaskIDs[ID];
				TaskDescLabel.text = GenericDescriptions[ID];
				Icon.mainTexture = GenericIcons[ID];
			}
			else
			{
				ID = 0;
				TaskDescLabel.text = Descriptions[ID];
				Icon.mainTexture = Icons[ID];
			}
		}
		Generic = false;
		TaskDescLabel.transform.parent.gameObject.SetActive(value: true);
		Window.SetActive(value: true);
		Time.timeScale = 0.0001f;
	}

	private void Update()
	{
		if (Window.activeInHierarchy)
		{
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				TaskManager.TaskStatus[StudentID] = 1;
				Yandere.TargetStudent.TalkTimer = 100f;
				Yandere.TargetStudent.Interaction = StudentInteractionType.GivingTask;
				Yandere.TargetStudent.TaskRejected = 0;
				Yandere.TargetStudent.TaskPhase = 4;
				PromptBar.ClearButtons();
				PromptBar.Show = false;
				Window.SetActive(value: false);
				if (!Yandere.StudentManager.Eighties)
				{
					UpdateTaskObjects(StudentID);
				}
				else
				{
					Yandere.Inventory.ItemsRequested[Yandere.TargetStudent.GenericTaskID]++;
				}
				Time.timeScale = 1f;
			}
			else if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				Yandere.TargetStudent.Interaction = StudentInteractionType.GivingTask;
				Yandere.TargetStudent.TalkTimer = 100f;
				Yandere.TargetStudent.TaskPhase = 0;
				Yandere.TargetStudent.Pestered += 5;
				PromptBar.ClearButtons();
				PromptBar.Show = false;
				Window.SetActive(value: false);
				Time.timeScale = 1f;
			}
		}
		if (!TaskComplete)
		{
			return;
		}
		if (TrueTimer == 0f)
		{
			GetComponent<AudioSource>().Play();
		}
		TrueTimer += Time.deltaTime;
		Timer += Time.deltaTime;
		if (ID < TaskCompleteLetters.Length && Timer > 0.05f)
		{
			TaskCompleteLetters[ID].SetActive(value: true);
			Timer = 0f;
			ID++;
		}
		if (TaskCompleteLetters[12].transform.localPosition.y < -725f)
		{
			for (ID = 0; ID < TaskCompleteLetters.Length; ID++)
			{
				TaskCompleteLetters[ID].GetComponent<GrowShrinkScript>().Return();
			}
			if (Yandere.StudentManager.Eighties)
			{
				Yandere.Inventory.ItemsRequested[Yandere.TargetStudent.GenericTaskID]--;
				Yandere.Inventory.ItemsCollected[Yandere.TargetStudent.GenericTaskID]--;
			}
			TaskCheck();
			DialogueWheel.End();
			TaskComplete = false;
			TrueTimer = 0f;
			Timer = 0f;
			ID = 0;
		}
	}

	private void TaskCheck()
	{
		GenericCheck();
		if (CustomMode)
		{
			Generic = true;
		}
		if (Generic)
		{
			if (!Yandere.StudentManager.Eighties)
			{
				Yandere.Inventory.Book = false;
				CheckOutBook.UpdatePrompt();
			}
			else if (Yandere.TargetStudent.GenericTaskID == 3)
			{
				Debug.Log("Enabling the task-related scarf.");
				DialogueWheel.Yandere.TargetStudent.Cosmetic.TaskScarf.SetActive(value: true);
				DialogueWheel.Yandere.TargetStudent.Cosmetic.TaskScarf.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
			}
			Generic = false;
		}
		else if (!Eighties)
		{
			if (Yandere.TargetStudent.StudentID == 37)
			{
				DialogueWheel.Yandere.TargetStudent.Cosmetic.MaleAccessories[1].SetActive(value: true);
			}
		}
		else if (Yandere.TargetStudent.StudentID == 11)
		{
			DialogueWheel.Yandere.TargetStudent.Cosmetic.Stockings = "ShortPink";
			DialogueWheel.Yandere.TargetStudent.Cosmetic.PutOnStockings();
		}
		else if (Yandere.TargetStudent.StudentID == 15)
		{
			Yandere.Inventory.Money -= 1000f;
			Yandere.Inventory.UpdateMoney();
		}
	}

	private void GetPortrait(int ID)
	{
		string text = "";
		if (GameGlobals.Eighties)
		{
			text = "1989";
			if (GameGlobals.CustomMode)
			{
				text = "Custom";
			}
		}
		WWW wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits" + text + "/Student_" + ID + ".png");
		Portrait.mainTexture = wWW.texture;
	}

	private void UpdateTaskObjects(int StudentID)
	{
		if (!Yandere.StudentManager.Eighties && this.StudentID == 30)
		{
			SewingMachine.Check = true;
		}
	}

	public void GenericCheck()
	{
		Generic = false;
		if (Yandere.StudentManager.Eighties)
		{
			Generic = true;
			if ((Yandere.TargetStudent.StudentID > 10 && Yandere.TargetStudent.StudentID < 21) || Yandere.TargetStudent.StudentID == 79)
			{
				Generic = false;
			}
			if (Yandere.StudentManager.CustomMode && ((Yandere.TargetStudent.StudentID > 10 && Yandere.TargetStudent.StudentID < 21) || Yandere.TargetStudent.StudentID == 79))
			{
				Generic = true;
			}
		}
		else if (Yandere.TargetStudent.StudentID != 4 && Yandere.TargetStudent.StudentID != 6 && Yandere.TargetStudent.StudentID != 8 && Yandere.TargetStudent.StudentID != 11 && Yandere.TargetStudent.StudentID != 12 && Yandere.TargetStudent.StudentID != 21 && Yandere.TargetStudent.StudentID != 22 && Yandere.TargetStudent.StudentID != 23 && Yandere.TargetStudent.StudentID != 24 && Yandere.TargetStudent.StudentID != 25 && Yandere.TargetStudent.StudentID != 28 && Yandere.TargetStudent.StudentID != 30 && Yandere.TargetStudent.StudentID != 36 && Yandere.TargetStudent.StudentID != 37 && Yandere.TargetStudent.StudentID != 38 && Yandere.TargetStudent.StudentID != 41 && Yandere.TargetStudent.StudentID != 46 && Yandere.TargetStudent.StudentID != 47 && Yandere.TargetStudent.StudentID != 48 && Yandere.TargetStudent.StudentID != 49 && Yandere.TargetStudent.StudentID != 50 && Yandere.TargetStudent.StudentID != 52 && Yandere.TargetStudent.StudentID != 65 && Yandere.TargetStudent.StudentID != 76 && Yandere.TargetStudent.StudentID != 77 && Yandere.TargetStudent.StudentID != 78 && Yandere.TargetStudent.StudentID != 79 && Yandere.TargetStudent.StudentID != 80 && Yandere.TargetStudent.StudentID != 81)
		{
			Generic = true;
		}
	}

	public void AltGenericCheck(int TempID)
	{
		Generic = false;
		if (Yandere.StudentManager.Eighties)
		{
			Generic = true;
			if ((TempID > 10 && TempID < 21) || TempID == 79)
			{
				Generic = false;
			}
			if (CustomMode)
			{
				Generic = true;
			}
		}
		else if (TempID != 4 && TempID != 6 && TempID != 8 && TempID != 11 && TempID != 12 && TempID != 21 && TempID != 22 && TempID != 23 && TempID != 24 && TempID != 25 && TempID != 28 && TempID != 30 && TempID != 36 && TempID != 37 && TempID != 38 && TempID != 41 && TempID != 46 && TempID != 47 && TempID != 48 && TempID != 49 && TempID != 50 && TempID != 52 && TempID != 65 && TempID != 76 && TempID != 77 && TempID != 78 && TempID != 79 && TempID != 80 && TempID != 81)
		{
			Generic = true;
		}
	}
}
