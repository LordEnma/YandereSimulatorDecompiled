using System;
using UnityEngine;

// Token: 0x02000469 RID: 1129
public class TaskWindowScript : MonoBehaviour
{
	// Token: 0x06001E87 RID: 7815 RVA: 0x001AC098 File Offset: 0x001AA298
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

	// Token: 0x06001E88 RID: 7816 RVA: 0x001AC0FC File Offset: 0x001AA2FC
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

	// Token: 0x06001E89 RID: 7817 RVA: 0x001AC1D8 File Offset: 0x001AA3D8
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

	// Token: 0x06001E8A RID: 7818 RVA: 0x001AC430 File Offset: 0x001AA630
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

	// Token: 0x06001E8B RID: 7819 RVA: 0x001AC4D8 File Offset: 0x001AA6D8
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

	// Token: 0x06001E8C RID: 7820 RVA: 0x001AC550 File Offset: 0x001AA750
	private void UpdateTaskObjects(int StudentID)
	{
		if (!this.Yandere.StudentManager.Eighties && this.StudentID == 30)
		{
			this.SewingMachine.Check = true;
		}
	}

	// Token: 0x06001E8D RID: 7821 RVA: 0x001AC57C File Offset: 0x001AA77C
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

	// Token: 0x06001E8E RID: 7822 RVA: 0x001AC738 File Offset: 0x001AA938
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

	// Token: 0x04003F00 RID: 16128
	public CheckOutBookScript HomeworkAssignment;

	// Token: 0x04003F01 RID: 16129
	public DialogueWheelScript DialogueWheel;

	// Token: 0x04003F02 RID: 16130
	public SewingMachineScript SewingMachine;

	// Token: 0x04003F03 RID: 16131
	public CheckOutBookScript CheckOutBook;

	// Token: 0x04003F04 RID: 16132
	public TaskManagerScript TaskManager;

	// Token: 0x04003F05 RID: 16133
	public PromptBarScript PromptBar;

	// Token: 0x04003F06 RID: 16134
	public UILabel TaskDescLabel;

	// Token: 0x04003F07 RID: 16135
	public YandereScript Yandere;

	// Token: 0x04003F08 RID: 16136
	public UITexture Portrait;

	// Token: 0x04003F09 RID: 16137
	public UITexture Icon;

	// Token: 0x04003F0A RID: 16138
	public GameObject[] TaskCompleteLetters;

	// Token: 0x04003F0B RID: 16139
	public string[] Descriptions;

	// Token: 0x04003F0C RID: 16140
	public Texture[] Portraits;

	// Token: 0x04003F0D RID: 16141
	public Texture[] Icons;

	// Token: 0x04003F0E RID: 16142
	public bool TaskComplete;

	// Token: 0x04003F0F RID: 16143
	public bool Generic;

	// Token: 0x04003F10 RID: 16144
	public GameObject Window;

	// Token: 0x04003F11 RID: 16145
	public int StudentID;

	// Token: 0x04003F12 RID: 16146
	public int ID;

	// Token: 0x04003F13 RID: 16147
	public float TrueTimer;

	// Token: 0x04003F14 RID: 16148
	public float Timer;

	// Token: 0x04003F15 RID: 16149
	public string[] EightiesDescriptions;

	// Token: 0x04003F16 RID: 16150
	public Texture[] EightiesIcons;

	// Token: 0x04003F17 RID: 16151
	public AudioClip EightiesJingle;
}
