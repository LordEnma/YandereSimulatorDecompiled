using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000468 RID: 1128
public class TaskListScript : MonoBehaviour
{
	// Token: 0x06001E8A RID: 7818 RVA: 0x001ACEC0 File Offset: 0x001AB0C0
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

	// Token: 0x06001E8B RID: 7819 RVA: 0x001AD034 File Offset: 0x001AB234
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

	// Token: 0x06001E8C RID: 7820 RVA: 0x001AD151 File Offset: 0x001AB351
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

	// Token: 0x06001E8D RID: 7821 RVA: 0x001AD160 File Offset: 0x001AB360
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

	// Token: 0x04003F02 RID: 16130
	public TutorialWindowScript TutorialWindow;

	// Token: 0x04003F03 RID: 16131
	public InputManagerScript InputManager;

	// Token: 0x04003F04 RID: 16132
	public PauseScreenScript PauseScreen;

	// Token: 0x04003F05 RID: 16133
	public TaskWindowScript TaskWindow;

	// Token: 0x04003F06 RID: 16134
	public JsonScript JSON;

	// Token: 0x04003F07 RID: 16135
	public GameObject MainMenu;

	// Token: 0x04003F08 RID: 16136
	public UITexture StudentIcon;

	// Token: 0x04003F09 RID: 16137
	public UITexture TaskIcon;

	// Token: 0x04003F0A RID: 16138
	public UILabel TaskDesc;

	// Token: 0x04003F0B RID: 16139
	public Texture QuestionMark;

	// Token: 0x04003F0C RID: 16140
	public Transform Highlight;

	// Token: 0x04003F0D RID: 16141
	public Texture Silhouette;

	// Token: 0x04003F0E RID: 16142
	public UILabel[] TaskNameLabels;

	// Token: 0x04003F0F RID: 16143
	public UISprite[] Checkmarks;

	// Token: 0x04003F10 RID: 16144
	public Texture[] TutorialTextures;

	// Token: 0x04003F11 RID: 16145
	public string[] TutorialDescs;

	// Token: 0x04003F12 RID: 16146
	public string[] TutorialNames;

	// Token: 0x04003F13 RID: 16147
	public int ListPosition;

	// Token: 0x04003F14 RID: 16148
	public int Limit = 84;

	// Token: 0x04003F15 RID: 16149
	public int ID = 1;

	// Token: 0x04003F16 RID: 16150
	public bool Tutorials;
}
