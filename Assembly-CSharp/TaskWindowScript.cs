using System;
using UnityEngine;

// Token: 0x0200046C RID: 1132
public class TaskWindowScript : MonoBehaviour
{
	// Token: 0x06001E9F RID: 7839 RVA: 0x001AE71C File Offset: 0x001AC91C
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

	// Token: 0x06001EA0 RID: 7840 RVA: 0x001AE780 File Offset: 0x001AC980
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

	// Token: 0x06001EA1 RID: 7841 RVA: 0x001AE85C File Offset: 0x001ACA5C
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

	// Token: 0x06001EA2 RID: 7842 RVA: 0x001AEAB4 File Offset: 0x001ACCB4
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

	// Token: 0x06001EA3 RID: 7843 RVA: 0x001AEB5C File Offset: 0x001ACD5C
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

	// Token: 0x06001EA4 RID: 7844 RVA: 0x001AEBD4 File Offset: 0x001ACDD4
	private void UpdateTaskObjects(int StudentID)
	{
		if (!this.Yandere.StudentManager.Eighties && this.StudentID == 30)
		{
			this.SewingMachine.Check = true;
		}
	}

	// Token: 0x06001EA5 RID: 7845 RVA: 0x001AEC00 File Offset: 0x001ACE00
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

	// Token: 0x06001EA6 RID: 7846 RVA: 0x001AEDBC File Offset: 0x001ACFBC
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

	// Token: 0x04003F30 RID: 16176
	public CheckOutBookScript HomeworkAssignment;

	// Token: 0x04003F31 RID: 16177
	public DialogueWheelScript DialogueWheel;

	// Token: 0x04003F32 RID: 16178
	public SewingMachineScript SewingMachine;

	// Token: 0x04003F33 RID: 16179
	public CheckOutBookScript CheckOutBook;

	// Token: 0x04003F34 RID: 16180
	public TaskManagerScript TaskManager;

	// Token: 0x04003F35 RID: 16181
	public PromptBarScript PromptBar;

	// Token: 0x04003F36 RID: 16182
	public UILabel TaskDescLabel;

	// Token: 0x04003F37 RID: 16183
	public YandereScript Yandere;

	// Token: 0x04003F38 RID: 16184
	public UITexture Portrait;

	// Token: 0x04003F39 RID: 16185
	public UITexture Icon;

	// Token: 0x04003F3A RID: 16186
	public GameObject[] TaskCompleteLetters;

	// Token: 0x04003F3B RID: 16187
	public string[] Descriptions;

	// Token: 0x04003F3C RID: 16188
	public Texture[] Portraits;

	// Token: 0x04003F3D RID: 16189
	public Texture[] Icons;

	// Token: 0x04003F3E RID: 16190
	public bool TaskComplete;

	// Token: 0x04003F3F RID: 16191
	public bool Generic;

	// Token: 0x04003F40 RID: 16192
	public GameObject Window;

	// Token: 0x04003F41 RID: 16193
	public int StudentID;

	// Token: 0x04003F42 RID: 16194
	public int ID;

	// Token: 0x04003F43 RID: 16195
	public float TrueTimer;

	// Token: 0x04003F44 RID: 16196
	public float Timer;

	// Token: 0x04003F45 RID: 16197
	public string[] EightiesDescriptions;

	// Token: 0x04003F46 RID: 16198
	public Texture[] EightiesIcons;

	// Token: 0x04003F47 RID: 16199
	public AudioClip EightiesJingle;
}
