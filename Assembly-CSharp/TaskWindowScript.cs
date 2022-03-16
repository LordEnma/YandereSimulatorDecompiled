using System;
using UnityEngine;

// Token: 0x0200046E RID: 1134
public class TaskWindowScript : MonoBehaviour
{
	// Token: 0x06001EB2 RID: 7858 RVA: 0x001B0550 File Offset: 0x001AE750
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

	// Token: 0x06001EB3 RID: 7859 RVA: 0x001B05B4 File Offset: 0x001AE7B4
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

	// Token: 0x06001EB4 RID: 7860 RVA: 0x001B0690 File Offset: 0x001AE890
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

	// Token: 0x06001EB5 RID: 7861 RVA: 0x001B08E8 File Offset: 0x001AEAE8
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

	// Token: 0x06001EB6 RID: 7862 RVA: 0x001B0990 File Offset: 0x001AEB90
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

	// Token: 0x06001EB7 RID: 7863 RVA: 0x001B0A08 File Offset: 0x001AEC08
	private void UpdateTaskObjects(int StudentID)
	{
		if (!this.Yandere.StudentManager.Eighties && this.StudentID == 30)
		{
			this.SewingMachine.Check = true;
		}
	}

	// Token: 0x06001EB8 RID: 7864 RVA: 0x001B0A34 File Offset: 0x001AEC34
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

	// Token: 0x06001EB9 RID: 7865 RVA: 0x001B0BF0 File Offset: 0x001AEDF0
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

	// Token: 0x04003F91 RID: 16273
	public CheckOutBookScript HomeworkAssignment;

	// Token: 0x04003F92 RID: 16274
	public DialogueWheelScript DialogueWheel;

	// Token: 0x04003F93 RID: 16275
	public SewingMachineScript SewingMachine;

	// Token: 0x04003F94 RID: 16276
	public CheckOutBookScript CheckOutBook;

	// Token: 0x04003F95 RID: 16277
	public TaskManagerScript TaskManager;

	// Token: 0x04003F96 RID: 16278
	public PromptBarScript PromptBar;

	// Token: 0x04003F97 RID: 16279
	public UILabel TaskDescLabel;

	// Token: 0x04003F98 RID: 16280
	public YandereScript Yandere;

	// Token: 0x04003F99 RID: 16281
	public UITexture Portrait;

	// Token: 0x04003F9A RID: 16282
	public UITexture Icon;

	// Token: 0x04003F9B RID: 16283
	public GameObject[] TaskCompleteLetters;

	// Token: 0x04003F9C RID: 16284
	public string[] Descriptions;

	// Token: 0x04003F9D RID: 16285
	public Texture[] Portraits;

	// Token: 0x04003F9E RID: 16286
	public Texture[] Icons;

	// Token: 0x04003F9F RID: 16287
	public bool TaskComplete;

	// Token: 0x04003FA0 RID: 16288
	public bool Generic;

	// Token: 0x04003FA1 RID: 16289
	public GameObject Window;

	// Token: 0x04003FA2 RID: 16290
	public int StudentID;

	// Token: 0x04003FA3 RID: 16291
	public int ID;

	// Token: 0x04003FA4 RID: 16292
	public float TrueTimer;

	// Token: 0x04003FA5 RID: 16293
	public float Timer;

	// Token: 0x04003FA6 RID: 16294
	public string[] EightiesDescriptions;

	// Token: 0x04003FA7 RID: 16295
	public Texture[] EightiesIcons;

	// Token: 0x04003FA8 RID: 16296
	public AudioClip EightiesJingle;
}
