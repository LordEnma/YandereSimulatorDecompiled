using System;
using UnityEngine;

// Token: 0x02000466 RID: 1126
public class TaskWindowScript : MonoBehaviour
{
	// Token: 0x06001E70 RID: 7792 RVA: 0x001AA4D8 File Offset: 0x001A86D8
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

	// Token: 0x06001E71 RID: 7793 RVA: 0x001AA53C File Offset: 0x001A873C
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

	// Token: 0x06001E72 RID: 7794 RVA: 0x001AA618 File Offset: 0x001A8818
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

	// Token: 0x06001E73 RID: 7795 RVA: 0x001AA870 File Offset: 0x001A8A70
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

	// Token: 0x06001E74 RID: 7796 RVA: 0x001AA918 File Offset: 0x001A8B18
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

	// Token: 0x06001E75 RID: 7797 RVA: 0x001AA990 File Offset: 0x001A8B90
	private void UpdateTaskObjects(int StudentID)
	{
		if (!this.Yandere.StudentManager.Eighties && this.StudentID == 30)
		{
			this.SewingMachine.Check = true;
		}
	}

	// Token: 0x06001E76 RID: 7798 RVA: 0x001AA9BC File Offset: 0x001A8BBC
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

	// Token: 0x06001E77 RID: 7799 RVA: 0x001AAB78 File Offset: 0x001A8D78
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

	// Token: 0x04003EB5 RID: 16053
	public CheckOutBookScript HomeworkAssignment;

	// Token: 0x04003EB6 RID: 16054
	public DialogueWheelScript DialogueWheel;

	// Token: 0x04003EB7 RID: 16055
	public SewingMachineScript SewingMachine;

	// Token: 0x04003EB8 RID: 16056
	public CheckOutBookScript CheckOutBook;

	// Token: 0x04003EB9 RID: 16057
	public TaskManagerScript TaskManager;

	// Token: 0x04003EBA RID: 16058
	public PromptBarScript PromptBar;

	// Token: 0x04003EBB RID: 16059
	public UILabel TaskDescLabel;

	// Token: 0x04003EBC RID: 16060
	public YandereScript Yandere;

	// Token: 0x04003EBD RID: 16061
	public UITexture Portrait;

	// Token: 0x04003EBE RID: 16062
	public UITexture Icon;

	// Token: 0x04003EBF RID: 16063
	public GameObject[] TaskCompleteLetters;

	// Token: 0x04003EC0 RID: 16064
	public string[] Descriptions;

	// Token: 0x04003EC1 RID: 16065
	public Texture[] Portraits;

	// Token: 0x04003EC2 RID: 16066
	public Texture[] Icons;

	// Token: 0x04003EC3 RID: 16067
	public bool TaskComplete;

	// Token: 0x04003EC4 RID: 16068
	public bool Generic;

	// Token: 0x04003EC5 RID: 16069
	public GameObject Window;

	// Token: 0x04003EC6 RID: 16070
	public int StudentID;

	// Token: 0x04003EC7 RID: 16071
	public int ID;

	// Token: 0x04003EC8 RID: 16072
	public float TrueTimer;

	// Token: 0x04003EC9 RID: 16073
	public float Timer;

	// Token: 0x04003ECA RID: 16074
	public string[] EightiesDescriptions;

	// Token: 0x04003ECB RID: 16075
	public Texture[] EightiesIcons;

	// Token: 0x04003ECC RID: 16076
	public AudioClip EightiesJingle;
}
