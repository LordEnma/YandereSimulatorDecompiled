using System;
using UnityEngine;

// Token: 0x02000472 RID: 1138
public class TaskWindowScript : MonoBehaviour
{
	// Token: 0x06001ECA RID: 7882 RVA: 0x001B2934 File Offset: 0x001B0B34
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

	// Token: 0x06001ECB RID: 7883 RVA: 0x001B2998 File Offset: 0x001B0B98
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

	// Token: 0x06001ECC RID: 7884 RVA: 0x001B2A74 File Offset: 0x001B0C74
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

	// Token: 0x06001ECD RID: 7885 RVA: 0x001B2CCC File Offset: 0x001B0ECC
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

	// Token: 0x06001ECE RID: 7886 RVA: 0x001B2D74 File Offset: 0x001B0F74
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

	// Token: 0x06001ECF RID: 7887 RVA: 0x001B2DEC File Offset: 0x001B0FEC
	private void UpdateTaskObjects(int StudentID)
	{
		if (!this.Yandere.StudentManager.Eighties && this.StudentID == 30)
		{
			this.SewingMachine.Check = true;
		}
	}

	// Token: 0x06001ED0 RID: 7888 RVA: 0x001B2E18 File Offset: 0x001B1018
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

	// Token: 0x06001ED1 RID: 7889 RVA: 0x001B3030 File Offset: 0x001B1230
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

	// Token: 0x04003FD1 RID: 16337
	public CheckOutBookScript HomeworkAssignment;

	// Token: 0x04003FD2 RID: 16338
	public DialogueWheelScript DialogueWheel;

	// Token: 0x04003FD3 RID: 16339
	public SewingMachineScript SewingMachine;

	// Token: 0x04003FD4 RID: 16340
	public CheckOutBookScript CheckOutBook;

	// Token: 0x04003FD5 RID: 16341
	public TaskManagerScript TaskManager;

	// Token: 0x04003FD6 RID: 16342
	public PromptBarScript PromptBar;

	// Token: 0x04003FD7 RID: 16343
	public UILabel TaskDescLabel;

	// Token: 0x04003FD8 RID: 16344
	public YandereScript Yandere;

	// Token: 0x04003FD9 RID: 16345
	public UITexture Portrait;

	// Token: 0x04003FDA RID: 16346
	public UITexture Icon;

	// Token: 0x04003FDB RID: 16347
	public GameObject[] TaskCompleteLetters;

	// Token: 0x04003FDC RID: 16348
	public string[] Descriptions;

	// Token: 0x04003FDD RID: 16349
	public Texture[] Portraits;

	// Token: 0x04003FDE RID: 16350
	public Texture[] Icons;

	// Token: 0x04003FDF RID: 16351
	public bool TaskComplete;

	// Token: 0x04003FE0 RID: 16352
	public bool Generic;

	// Token: 0x04003FE1 RID: 16353
	public GameObject Window;

	// Token: 0x04003FE2 RID: 16354
	public int StudentID;

	// Token: 0x04003FE3 RID: 16355
	public int ID;

	// Token: 0x04003FE4 RID: 16356
	public float TrueTimer;

	// Token: 0x04003FE5 RID: 16357
	public float Timer;

	// Token: 0x04003FE6 RID: 16358
	public string[] EightiesDescriptions;

	// Token: 0x04003FE7 RID: 16359
	public Texture[] EightiesIcons;

	// Token: 0x04003FE8 RID: 16360
	public AudioClip EightiesJingle;
}
