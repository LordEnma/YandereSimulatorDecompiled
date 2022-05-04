using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000470 RID: 1136
public class TaskListScript : MonoBehaviour
{
	// Token: 0x06001EC8 RID: 7880 RVA: 0x001B2E84 File Offset: 0x001B1084
	private void Update()
	{
		if (this.InputManager.TappedUp)
		{
			if (this.ID == 1)
			{
				this.ListPosition--;
				if (this.ListPosition < 0)
				{
					this.ListPosition = this.Limit - 16;
					this.ID = 16;
				}
			}
			else
			{
				this.ID--;
			}
			this.UpdateTaskList();
			base.StartCoroutine(this.UpdateTaskInfo());
		}
		if (this.InputManager.TappedDown)
		{
			if (this.ID == 16)
			{
				this.ListPosition++;
				if (this.ID + this.ListPosition > this.Limit)
				{
					this.ListPosition = 0;
					this.ID = 1;
				}
			}
			else
			{
				this.ID++;
			}
			this.UpdateTaskList();
			base.StartCoroutine(this.UpdateTaskInfo());
		}
		if (this.Tutorials)
		{
			if (!this.TutorialWindow.Hide && !this.TutorialWindow.Show)
			{
				if (Input.GetButtonDown("A"))
				{
					OptionGlobals.TutorialsOff = false;
					this.TutorialWindow.ForceID = this.ListPosition + this.ID;
					this.TutorialWindow.ShowTutorial();
					this.TutorialWindow.enabled = true;
					this.TutorialWindow.SummonWindow();
					return;
				}
				if (Input.GetButtonDown("B"))
				{
					this.Exit();
					return;
				}
			}
		}
		else if (Input.GetButtonDown("B"))
		{
			this.Exit();
		}
	}

	// Token: 0x06001EC9 RID: 7881 RVA: 0x001B2FF8 File Offset: 0x001B11F8
	public void UpdateTaskList()
	{
		if (!this.TaskWindow.TaskManager.Initialized)
		{
			this.TaskWindow.TaskManager.Start();
		}
		if (this.Tutorials)
		{
			for (int i = 1; i < this.TaskNameLabels.Length; i++)
			{
				this.TaskNameLabels[i].text = this.TutorialNames[i + this.ListPosition];
			}
			return;
		}
		for (int j = 1; j < this.TaskNameLabels.Length; j++)
		{
			if (this.TaskWindow.TaskManager.TaskStatus[j + this.ListPosition] == 0)
			{
				this.TaskNameLabels[j].text = "Undiscovered Task #" + (j + this.ListPosition).ToString();
			}
			else
			{
				this.TaskNameLabels[j].text = this.JSON.Students[j + this.ListPosition].Name + "'s Task";
			}
			this.Checkmarks[j].enabled = (this.TaskWindow.TaskManager.TaskStatus[j + this.ListPosition] == 3);
		}
	}

	// Token: 0x06001ECA RID: 7882 RVA: 0x001B3115 File Offset: 0x001B1315
	public IEnumerator UpdateTaskInfo()
	{
		this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 200f - 25f * (float)this.ID, this.Highlight.localPosition.z);
		if (this.Tutorials)
		{
			this.TaskIcon.mainTexture = this.TutorialTextures[this.ID + this.ListPosition];
			this.TaskDesc.text = "This tutorial will teach you about " + this.TutorialNames[this.ID + this.ListPosition];
		}
		else
		{
			string text = "";
			if (GameGlobals.Eighties)
			{
				text = "1989";
			}
			if (this.TaskWindow.TaskManager.TaskStatus[this.ID + this.ListPosition] == 0)
			{
				this.StudentIcon.mainTexture = this.Silhouette;
				this.TaskIcon.mainTexture = this.QuestionMark;
				this.TaskDesc.text = "This task has not been discovered yet.";
			}
			else
			{
				string url = string.Concat(new string[]
				{
					"file:///",
					Application.streamingAssetsPath,
					"/Portraits",
					text,
					"/Student_",
					(this.ID + this.ListPosition).ToString(),
					".png"
				});
				WWW www = new WWW(url);
				yield return www;
				this.StudentIcon.mainTexture = www.texture;
				this.TaskWindow.AltGenericCheck(this.ID + this.ListPosition);
				if (this.TaskWindow.Generic)
				{
					this.TaskIcon.mainTexture = this.TaskWindow.Icons[0];
					this.TaskDesc.text = this.TaskWindow.Descriptions[0];
				}
				else
				{
					this.TaskIcon.mainTexture = this.TaskWindow.Icons[this.ID + this.ListPosition];
					this.TaskDesc.text = this.TaskWindow.Descriptions[this.ID + this.ListPosition];
				}
				www = null;
			}
		}
		yield break;
	}

	// Token: 0x06001ECB RID: 7883 RVA: 0x001B3124 File Offset: 0x001B1324
	public void Exit()
	{
		this.PauseScreen.PromptBar.ClearButtons();
		this.PauseScreen.PromptBar.Label[0].text = "Accept";
		this.PauseScreen.PromptBar.Label[1].text = "Back";
		this.PauseScreen.PromptBar.Label[4].text = "Choose";
		this.PauseScreen.PromptBar.Label[5].text = "Choose";
		this.PauseScreen.PromptBar.UpdateButtons();
		this.PauseScreen.Sideways = false;
		this.PauseScreen.PressedB = true;
		this.MainMenu.SetActive(true);
		base.gameObject.SetActive(false);
	}

	// Token: 0x04003FC7 RID: 16327
	public TutorialWindowScript TutorialWindow;

	// Token: 0x04003FC8 RID: 16328
	public InputManagerScript InputManager;

	// Token: 0x04003FC9 RID: 16329
	public PauseScreenScript PauseScreen;

	// Token: 0x04003FCA RID: 16330
	public TaskWindowScript TaskWindow;

	// Token: 0x04003FCB RID: 16331
	public JsonScript JSON;

	// Token: 0x04003FCC RID: 16332
	public GameObject MainMenu;

	// Token: 0x04003FCD RID: 16333
	public UITexture StudentIcon;

	// Token: 0x04003FCE RID: 16334
	public UITexture TaskIcon;

	// Token: 0x04003FCF RID: 16335
	public UILabel TaskDesc;

	// Token: 0x04003FD0 RID: 16336
	public Texture QuestionMark;

	// Token: 0x04003FD1 RID: 16337
	public Transform Highlight;

	// Token: 0x04003FD2 RID: 16338
	public Texture Silhouette;

	// Token: 0x04003FD3 RID: 16339
	public UILabel[] TaskNameLabels;

	// Token: 0x04003FD4 RID: 16340
	public UISprite[] Checkmarks;

	// Token: 0x04003FD5 RID: 16341
	public Texture[] TutorialTextures;

	// Token: 0x04003FD6 RID: 16342
	public string[] TutorialDescs;

	// Token: 0x04003FD7 RID: 16343
	public string[] TutorialNames;

	// Token: 0x04003FD8 RID: 16344
	public int ListPosition;

	// Token: 0x04003FD9 RID: 16345
	public int Limit = 84;

	// Token: 0x04003FDA RID: 16346
	public int ID = 1;

	// Token: 0x04003FDB RID: 16347
	public bool Tutorials;
}
