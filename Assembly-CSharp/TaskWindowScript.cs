using System;
using UnityEngine;

// Token: 0x02000473 RID: 1139
public class TaskWindowScript : MonoBehaviour
{
	// Token: 0x06001ED4 RID: 7892 RVA: 0x001B3DA0 File Offset: 0x001B1FA0
	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			base.GetComponent<AudioSource>().clip = this.EightiesJingle;
			base.GetComponent<AudioSource>().volume = 0.1f;
			this.Descriptions = this.EightiesDescriptions;
			this.Icons = this.EightiesIcons;
		}
		else
		{
			this.UpdateTaskObjects(30);
		}
		this.Window.SetActive(false);
	}

	// Token: 0x06001ED5 RID: 7893 RVA: 0x001B3E04 File Offset: 0x001B2004
	public void UpdateWindow(int ID)
	{
		this.PromptBar.ClearButtons();
		this.PromptBar.Label[0].text = "Accept";
		this.PromptBar.Label[1].text = "Refuse";
		this.PromptBar.UpdateButtons();
		this.PromptBar.Show = true;
		this.GetPortrait(ID);
		this.StudentID = ID;
		this.GenericCheck();
		if (this.Generic)
		{
			ID = 0;
			this.Generic = false;
		}
		this.TaskDescLabel.transform.parent.gameObject.SetActive(true);
		this.TaskDescLabel.text = this.Descriptions[ID];
		this.Icon.mainTexture = this.Icons[ID];
		this.Window.SetActive(true);
		Time.timeScale = 0.0001f;
	}

	// Token: 0x06001ED6 RID: 7894 RVA: 0x001B3EE0 File Offset: 0x001B20E0
	private void Update()
	{
		if (this.Window.activeInHierarchy)
		{
			if (Input.GetButtonDown("A"))
			{
				this.TaskManager.TaskStatus[this.StudentID] = 1;
				this.Yandere.TargetStudent.TalkTimer = 100f;
				this.Yandere.TargetStudent.Interaction = StudentInteractionType.GivingTask;
				this.Yandere.TargetStudent.TaskPhase = 4;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
				this.Window.SetActive(false);
				if (!this.Yandere.StudentManager.Eighties)
				{
					this.UpdateTaskObjects(this.StudentID);
				}
				Time.timeScale = 1f;
			}
			else if (Input.GetButtonDown("B"))
			{
				this.Yandere.TargetStudent.TalkTimer = 100f;
				this.Yandere.TargetStudent.Interaction = StudentInteractionType.GivingTask;
				this.Yandere.TargetStudent.TaskPhase = 0;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
				this.Window.SetActive(false);
				Time.timeScale = 1f;
			}
		}
		if (this.TaskComplete)
		{
			if (this.TrueTimer == 0f)
			{
				base.GetComponent<AudioSource>().Play();
			}
			this.TrueTimer += Time.deltaTime;
			this.Timer += Time.deltaTime;
			if (this.ID < this.TaskCompleteLetters.Length && this.Timer > 0.05f)
			{
				this.TaskCompleteLetters[this.ID].SetActive(true);
				this.Timer = 0f;
				this.ID++;
			}
			if (this.TaskCompleteLetters[12].transform.localPosition.y < -725f)
			{
				this.ID = 0;
				while (this.ID < this.TaskCompleteLetters.Length)
				{
					this.TaskCompleteLetters[this.ID].GetComponent<GrowShrinkScript>().Return();
					this.ID++;
				}
				this.TaskCheck();
				this.DialogueWheel.End();
				this.TaskComplete = false;
				this.TrueTimer = 0f;
				this.Timer = 0f;
				this.ID = 0;
			}
		}
	}

	// Token: 0x06001ED7 RID: 7895 RVA: 0x001B4138 File Offset: 0x001B2338
	private void TaskCheck()
	{
		this.GenericCheck();
		if (this.Generic)
		{
			if (!this.Yandere.StudentManager.Eighties)
			{
				this.Yandere.Inventory.Book = false;
				this.CheckOutBook.UpdatePrompt();
			}
			else
			{
				this.Yandere.Inventory.FinishedHomework = false;
				this.HomeworkAssignment.UpdatePrompt();
			}
			this.Generic = false;
			return;
		}
		if (this.Yandere.TargetStudent.StudentID == 37)
		{
			this.DialogueWheel.Yandere.TargetStudent.Cosmetic.MaleAccessories[1].SetActive(true);
		}
	}

	// Token: 0x06001ED8 RID: 7896 RVA: 0x001B41E0 File Offset: 0x001B23E0
	private void GetPortrait(int ID)
	{
		string text = "";
		if (GameGlobals.Eighties)
		{
			text = "1989";
		}
		WWW www = new WWW(string.Concat(new string[]
		{
			"file:///",
			Application.streamingAssetsPath,
			"/Portraits",
			text,
			"/Student_",
			ID.ToString(),
			".png"
		}));
		this.Portrait.mainTexture = www.texture;
	}

	// Token: 0x06001ED9 RID: 7897 RVA: 0x001B4258 File Offset: 0x001B2458
	private void UpdateTaskObjects(int StudentID)
	{
		if (!this.Yandere.StudentManager.Eighties && this.StudentID == 30)
		{
			this.SewingMachine.Check = true;
		}
	}

	// Token: 0x06001EDA RID: 7898 RVA: 0x001B4284 File Offset: 0x001B2484
	public void GenericCheck()
	{
		this.Generic = false;
		if (this.Yandere.StudentManager.Eighties)
		{
			if (this.Yandere.TargetStudent.StudentID != 79)
			{
				this.Generic = true;
				return;
			}
		}
		else if (this.Yandere.TargetStudent.StudentID != 6 && this.Yandere.TargetStudent.StudentID != 8 && this.Yandere.TargetStudent.StudentID != 11 && this.Yandere.TargetStudent.StudentID != 25 && this.Yandere.TargetStudent.StudentID != 28 && this.Yandere.TargetStudent.StudentID != 30 && this.Yandere.TargetStudent.StudentID != 36 && this.Yandere.TargetStudent.StudentID != 37 && this.Yandere.TargetStudent.StudentID != 38 && this.Yandere.TargetStudent.StudentID != 46 && this.Yandere.TargetStudent.StudentID != 47 && this.Yandere.TargetStudent.StudentID != 48 && this.Yandere.TargetStudent.StudentID != 49 && this.Yandere.TargetStudent.StudentID != 50 && this.Yandere.TargetStudent.StudentID != 52 && this.Yandere.TargetStudent.StudentID != 76 && this.Yandere.TargetStudent.StudentID != 77 && this.Yandere.TargetStudent.StudentID != 78 && this.Yandere.TargetStudent.StudentID != 79 && this.Yandere.TargetStudent.StudentID != 80 && this.Yandere.TargetStudent.StudentID != 81)
		{
			this.Generic = true;
		}
	}

	// Token: 0x06001EDB RID: 7899 RVA: 0x001B449C File Offset: 0x001B269C
	public void AltGenericCheck(int TempID)
	{
		this.Generic = false;
		if (this.Yandere.StudentManager.Eighties)
		{
			if (TempID != 79)
			{
				this.Generic = true;
				return;
			}
		}
		else if (TempID != 6 && TempID != 8 && TempID != 11 && TempID != 25 && TempID != 28 && TempID != 30 && TempID != 36 && TempID != 37 && TempID != 38 && TempID != 46 && TempID != 47 && TempID != 48 && TempID != 49 && TempID != 50 && TempID != 52 && TempID != 76 && TempID != 77 && TempID != 78 && TempID != 79 && TempID != 80 && TempID != 81)
		{
			this.Generic = true;
		}
	}

	// Token: 0x04003FE7 RID: 16359
	public CheckOutBookScript HomeworkAssignment;

	// Token: 0x04003FE8 RID: 16360
	public DialogueWheelScript DialogueWheel;

	// Token: 0x04003FE9 RID: 16361
	public SewingMachineScript SewingMachine;

	// Token: 0x04003FEA RID: 16362
	public CheckOutBookScript CheckOutBook;

	// Token: 0x04003FEB RID: 16363
	public TaskManagerScript TaskManager;

	// Token: 0x04003FEC RID: 16364
	public PromptBarScript PromptBar;

	// Token: 0x04003FED RID: 16365
	public UILabel TaskDescLabel;

	// Token: 0x04003FEE RID: 16366
	public YandereScript Yandere;

	// Token: 0x04003FEF RID: 16367
	public UITexture Portrait;

	// Token: 0x04003FF0 RID: 16368
	public UITexture Icon;

	// Token: 0x04003FF1 RID: 16369
	public GameObject[] TaskCompleteLetters;

	// Token: 0x04003FF2 RID: 16370
	public string[] Descriptions;

	// Token: 0x04003FF3 RID: 16371
	public Texture[] Portraits;

	// Token: 0x04003FF4 RID: 16372
	public Texture[] Icons;

	// Token: 0x04003FF5 RID: 16373
	public bool TaskComplete;

	// Token: 0x04003FF6 RID: 16374
	public bool Generic;

	// Token: 0x04003FF7 RID: 16375
	public GameObject Window;

	// Token: 0x04003FF8 RID: 16376
	public int StudentID;

	// Token: 0x04003FF9 RID: 16377
	public int ID;

	// Token: 0x04003FFA RID: 16378
	public float TrueTimer;

	// Token: 0x04003FFB RID: 16379
	public float Timer;

	// Token: 0x04003FFC RID: 16380
	public string[] EightiesDescriptions;

	// Token: 0x04003FFD RID: 16381
	public Texture[] EightiesIcons;

	// Token: 0x04003FFE RID: 16382
	public AudioClip EightiesJingle;
}
