using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000466 RID: 1126
public class TaskListScript : MonoBehaviour
{
	// Token: 0x06001E7B RID: 7803 RVA: 0x001AB378 File Offset: 0x001A9578
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

	// Token: 0x06001E7C RID: 7804 RVA: 0x001AB4EC File Offset: 0x001A96EC
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

	// Token: 0x06001E7D RID: 7805 RVA: 0x001AB609 File Offset: 0x001A9809
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

	// Token: 0x06001E7E RID: 7806 RVA: 0x001AB618 File Offset: 0x001A9818
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

	// Token: 0x04003EE2 RID: 16098
	public TutorialWindowScript TutorialWindow;

	// Token: 0x04003EE3 RID: 16099
	public InputManagerScript InputManager;

	// Token: 0x04003EE4 RID: 16100
	public PauseScreenScript PauseScreen;

	// Token: 0x04003EE5 RID: 16101
	public TaskWindowScript TaskWindow;

	// Token: 0x04003EE6 RID: 16102
	public JsonScript JSON;

	// Token: 0x04003EE7 RID: 16103
	public GameObject MainMenu;

	// Token: 0x04003EE8 RID: 16104
	public UITexture StudentIcon;

	// Token: 0x04003EE9 RID: 16105
	public UITexture TaskIcon;

	// Token: 0x04003EEA RID: 16106
	public UILabel TaskDesc;

	// Token: 0x04003EEB RID: 16107
	public Texture QuestionMark;

	// Token: 0x04003EEC RID: 16108
	public Transform Highlight;

	// Token: 0x04003EED RID: 16109
	public Texture Silhouette;

	// Token: 0x04003EEE RID: 16110
	public UILabel[] TaskNameLabels;

	// Token: 0x04003EEF RID: 16111
	public UISprite[] Checkmarks;

	// Token: 0x04003EF0 RID: 16112
	public Texture[] TutorialTextures;

	// Token: 0x04003EF1 RID: 16113
	public string[] TutorialDescs;

	// Token: 0x04003EF2 RID: 16114
	public string[] TutorialNames;

	// Token: 0x04003EF3 RID: 16115
	public int ListPosition;

	// Token: 0x04003EF4 RID: 16116
	public int Limit = 84;

	// Token: 0x04003EF5 RID: 16117
	public int ID = 1;

	// Token: 0x04003EF6 RID: 16118
	public bool Tutorials;
}
