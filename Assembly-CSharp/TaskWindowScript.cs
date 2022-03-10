using System;
using UnityEngine;

// Token: 0x0200046C RID: 1132
public class TaskWindowScript : MonoBehaviour
{
	// Token: 0x06001EA2 RID: 7842 RVA: 0x001AEE44 File Offset: 0x001AD044
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

	// Token: 0x06001EA3 RID: 7843 RVA: 0x001AEEA8 File Offset: 0x001AD0A8
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

	// Token: 0x06001EA4 RID: 7844 RVA: 0x001AEF84 File Offset: 0x001AD184
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

	// Token: 0x06001EA5 RID: 7845 RVA: 0x001AF1DC File Offset: 0x001AD3DC
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

	// Token: 0x06001EA6 RID: 7846 RVA: 0x001AF284 File Offset: 0x001AD484
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

	// Token: 0x06001EA7 RID: 7847 RVA: 0x001AF2FC File Offset: 0x001AD4FC
	private void UpdateTaskObjects(int StudentID)
	{
		if (!this.Yandere.StudentManager.Eighties && this.StudentID == 30)
		{
			this.SewingMachine.Check = true;
		}
	}

	// Token: 0x06001EA8 RID: 7848 RVA: 0x001AF328 File Offset: 0x001AD528
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

	// Token: 0x06001EA9 RID: 7849 RVA: 0x001AF4E4 File Offset: 0x001AD6E4
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

	// Token: 0x04003F47 RID: 16199
	public CheckOutBookScript HomeworkAssignment;

	// Token: 0x04003F48 RID: 16200
	public DialogueWheelScript DialogueWheel;

	// Token: 0x04003F49 RID: 16201
	public SewingMachineScript SewingMachine;

	// Token: 0x04003F4A RID: 16202
	public CheckOutBookScript CheckOutBook;

	// Token: 0x04003F4B RID: 16203
	public TaskManagerScript TaskManager;

	// Token: 0x04003F4C RID: 16204
	public PromptBarScript PromptBar;

	// Token: 0x04003F4D RID: 16205
	public UILabel TaskDescLabel;

	// Token: 0x04003F4E RID: 16206
	public YandereScript Yandere;

	// Token: 0x04003F4F RID: 16207
	public UITexture Portrait;

	// Token: 0x04003F50 RID: 16208
	public UITexture Icon;

	// Token: 0x04003F51 RID: 16209
	public GameObject[] TaskCompleteLetters;

	// Token: 0x04003F52 RID: 16210
	public string[] Descriptions;

	// Token: 0x04003F53 RID: 16211
	public Texture[] Portraits;

	// Token: 0x04003F54 RID: 16212
	public Texture[] Icons;

	// Token: 0x04003F55 RID: 16213
	public bool TaskComplete;

	// Token: 0x04003F56 RID: 16214
	public bool Generic;

	// Token: 0x04003F57 RID: 16215
	public GameObject Window;

	// Token: 0x04003F58 RID: 16216
	public int StudentID;

	// Token: 0x04003F59 RID: 16217
	public int ID;

	// Token: 0x04003F5A RID: 16218
	public float TrueTimer;

	// Token: 0x04003F5B RID: 16219
	public float Timer;

	// Token: 0x04003F5C RID: 16220
	public string[] EightiesDescriptions;

	// Token: 0x04003F5D RID: 16221
	public Texture[] EightiesIcons;

	// Token: 0x04003F5E RID: 16222
	public AudioClip EightiesJingle;
}
