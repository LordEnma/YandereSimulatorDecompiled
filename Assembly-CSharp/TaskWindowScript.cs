using System;
using UnityEngine;

// Token: 0x02000474 RID: 1140
public class TaskWindowScript : MonoBehaviour
{
	// Token: 0x06001EDD RID: 7901 RVA: 0x001B53A8 File Offset: 0x001B35A8
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

	// Token: 0x06001EDE RID: 7902 RVA: 0x001B540C File Offset: 0x001B360C
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

	// Token: 0x06001EDF RID: 7903 RVA: 0x001B54E8 File Offset: 0x001B36E8
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

	// Token: 0x06001EE0 RID: 7904 RVA: 0x001B5740 File Offset: 0x001B3940
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

	// Token: 0x06001EE1 RID: 7905 RVA: 0x001B57E8 File Offset: 0x001B39E8
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

	// Token: 0x06001EE2 RID: 7906 RVA: 0x001B5860 File Offset: 0x001B3A60
	private void UpdateTaskObjects(int StudentID)
	{
		if (!this.Yandere.StudentManager.Eighties && this.StudentID == 30)
		{
			this.SewingMachine.Check = true;
		}
	}

	// Token: 0x06001EE3 RID: 7907 RVA: 0x001B588C File Offset: 0x001B3A8C
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

	// Token: 0x06001EE4 RID: 7908 RVA: 0x001B5AA4 File Offset: 0x001B3CA4
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

	// Token: 0x0400400E RID: 16398
	public CheckOutBookScript HomeworkAssignment;

	// Token: 0x0400400F RID: 16399
	public DialogueWheelScript DialogueWheel;

	// Token: 0x04004010 RID: 16400
	public SewingMachineScript SewingMachine;

	// Token: 0x04004011 RID: 16401
	public CheckOutBookScript CheckOutBook;

	// Token: 0x04004012 RID: 16402
	public TaskManagerScript TaskManager;

	// Token: 0x04004013 RID: 16403
	public PromptBarScript PromptBar;

	// Token: 0x04004014 RID: 16404
	public UILabel TaskDescLabel;

	// Token: 0x04004015 RID: 16405
	public YandereScript Yandere;

	// Token: 0x04004016 RID: 16406
	public UITexture Portrait;

	// Token: 0x04004017 RID: 16407
	public UITexture Icon;

	// Token: 0x04004018 RID: 16408
	public GameObject[] TaskCompleteLetters;

	// Token: 0x04004019 RID: 16409
	public string[] Descriptions;

	// Token: 0x0400401A RID: 16410
	public Texture[] Portraits;

	// Token: 0x0400401B RID: 16411
	public Texture[] Icons;

	// Token: 0x0400401C RID: 16412
	public bool TaskComplete;

	// Token: 0x0400401D RID: 16413
	public bool Generic;

	// Token: 0x0400401E RID: 16414
	public GameObject Window;

	// Token: 0x0400401F RID: 16415
	public int StudentID;

	// Token: 0x04004020 RID: 16416
	public int ID;

	// Token: 0x04004021 RID: 16417
	public float TrueTimer;

	// Token: 0x04004022 RID: 16418
	public float Timer;

	// Token: 0x04004023 RID: 16419
	public string[] EightiesDescriptions;

	// Token: 0x04004024 RID: 16420
	public Texture[] EightiesIcons;

	// Token: 0x04004025 RID: 16421
	public AudioClip EightiesJingle;
}
