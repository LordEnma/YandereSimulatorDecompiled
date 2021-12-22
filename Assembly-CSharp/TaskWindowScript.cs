using System;
using UnityEngine;

// Token: 0x02000467 RID: 1127
public class TaskWindowScript : MonoBehaviour
{
	// Token: 0x06001E7A RID: 7802 RVA: 0x001AB264 File Offset: 0x001A9464
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

	// Token: 0x06001E7B RID: 7803 RVA: 0x001AB2C8 File Offset: 0x001A94C8
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

	// Token: 0x06001E7C RID: 7804 RVA: 0x001AB3A4 File Offset: 0x001A95A4
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

	// Token: 0x06001E7D RID: 7805 RVA: 0x001AB5FC File Offset: 0x001A97FC
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

	// Token: 0x06001E7E RID: 7806 RVA: 0x001AB6A4 File Offset: 0x001A98A4
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

	// Token: 0x06001E7F RID: 7807 RVA: 0x001AB71C File Offset: 0x001A991C
	private void UpdateTaskObjects(int StudentID)
	{
		if (!this.Yandere.StudentManager.Eighties && this.StudentID == 30)
		{
			this.SewingMachine.Check = true;
		}
	}

	// Token: 0x06001E80 RID: 7808 RVA: 0x001AB748 File Offset: 0x001A9948
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
		else if (this.Yandere.TargetStudent.StudentID != 6 && this.Yandere.TargetStudent.StudentID != 8 && this.Yandere.TargetStudent.StudentID != 11 && this.Yandere.TargetStudent.StudentID != 25 && this.Yandere.TargetStudent.StudentID != 28 && this.Yandere.TargetStudent.StudentID != 30 && this.Yandere.TargetStudent.StudentID != 36 && this.Yandere.TargetStudent.StudentID != 37 && this.Yandere.TargetStudent.StudentID != 38 && this.Yandere.TargetStudent.StudentID != 46 && this.Yandere.TargetStudent.StudentID != 52 && this.Yandere.TargetStudent.StudentID != 76 && this.Yandere.TargetStudent.StudentID != 77 && this.Yandere.TargetStudent.StudentID != 78 && this.Yandere.TargetStudent.StudentID != 79 && this.Yandere.TargetStudent.StudentID != 80 && this.Yandere.TargetStudent.StudentID != 81)
		{
			this.Generic = true;
		}
	}

	// Token: 0x06001E81 RID: 7809 RVA: 0x001AB904 File Offset: 0x001A9B04
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
		else if (TempID != 6 && TempID != 8 && TempID != 11 && TempID != 25 && TempID != 28 && TempID != 30 && TempID != 36 && TempID != 37 && TempID != 38 && TempID != 46 && TempID != 52 && TempID != 76 && TempID != 77 && TempID != 78 && TempID != 79 && TempID != 80 && TempID != 81)
		{
			this.Generic = true;
		}
	}

	// Token: 0x04003EE5 RID: 16101
	public CheckOutBookScript HomeworkAssignment;

	// Token: 0x04003EE6 RID: 16102
	public DialogueWheelScript DialogueWheel;

	// Token: 0x04003EE7 RID: 16103
	public SewingMachineScript SewingMachine;

	// Token: 0x04003EE8 RID: 16104
	public CheckOutBookScript CheckOutBook;

	// Token: 0x04003EE9 RID: 16105
	public TaskManagerScript TaskManager;

	// Token: 0x04003EEA RID: 16106
	public PromptBarScript PromptBar;

	// Token: 0x04003EEB RID: 16107
	public UILabel TaskDescLabel;

	// Token: 0x04003EEC RID: 16108
	public YandereScript Yandere;

	// Token: 0x04003EED RID: 16109
	public UITexture Portrait;

	// Token: 0x04003EEE RID: 16110
	public UITexture Icon;

	// Token: 0x04003EEF RID: 16111
	public GameObject[] TaskCompleteLetters;

	// Token: 0x04003EF0 RID: 16112
	public string[] Descriptions;

	// Token: 0x04003EF1 RID: 16113
	public Texture[] Portraits;

	// Token: 0x04003EF2 RID: 16114
	public Texture[] Icons;

	// Token: 0x04003EF3 RID: 16115
	public bool TaskComplete;

	// Token: 0x04003EF4 RID: 16116
	public bool Generic;

	// Token: 0x04003EF5 RID: 16117
	public GameObject Window;

	// Token: 0x04003EF6 RID: 16118
	public int StudentID;

	// Token: 0x04003EF7 RID: 16119
	public int ID;

	// Token: 0x04003EF8 RID: 16120
	public float TrueTimer;

	// Token: 0x04003EF9 RID: 16121
	public float Timer;

	// Token: 0x04003EFA RID: 16122
	public string[] EightiesDescriptions;

	// Token: 0x04003EFB RID: 16123
	public Texture[] EightiesIcons;

	// Token: 0x04003EFC RID: 16124
	public AudioClip EightiesJingle;
}
