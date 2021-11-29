using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000463 RID: 1123
public class TaskListScript : MonoBehaviour
{
	// Token: 0x06001E64 RID: 7780 RVA: 0x001A97B8 File Offset: 0x001A79B8
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

	// Token: 0x06001E65 RID: 7781 RVA: 0x001A992C File Offset: 0x001A7B2C
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

	// Token: 0x06001E66 RID: 7782 RVA: 0x001A9A49 File Offset: 0x001A7C49
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

	// Token: 0x06001E67 RID: 7783 RVA: 0x001A9A58 File Offset: 0x001A7C58
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

	// Token: 0x04003E97 RID: 16023
	public TutorialWindowScript TutorialWindow;

	// Token: 0x04003E98 RID: 16024
	public InputManagerScript InputManager;

	// Token: 0x04003E99 RID: 16025
	public PauseScreenScript PauseScreen;

	// Token: 0x04003E9A RID: 16026
	public TaskWindowScript TaskWindow;

	// Token: 0x04003E9B RID: 16027
	public JsonScript JSON;

	// Token: 0x04003E9C RID: 16028
	public GameObject MainMenu;

	// Token: 0x04003E9D RID: 16029
	public UITexture StudentIcon;

	// Token: 0x04003E9E RID: 16030
	public UITexture TaskIcon;

	// Token: 0x04003E9F RID: 16031
	public UILabel TaskDesc;

	// Token: 0x04003EA0 RID: 16032
	public Texture QuestionMark;

	// Token: 0x04003EA1 RID: 16033
	public Transform Highlight;

	// Token: 0x04003EA2 RID: 16034
	public Texture Silhouette;

	// Token: 0x04003EA3 RID: 16035
	public UILabel[] TaskNameLabels;

	// Token: 0x04003EA4 RID: 16036
	public UISprite[] Checkmarks;

	// Token: 0x04003EA5 RID: 16037
	public Texture[] TutorialTextures;

	// Token: 0x04003EA6 RID: 16038
	public string[] TutorialDescs;

	// Token: 0x04003EA7 RID: 16039
	public string[] TutorialNames;

	// Token: 0x04003EA8 RID: 16040
	public int ListPosition;

	// Token: 0x04003EA9 RID: 16041
	public int Limit = 84;

	// Token: 0x04003EAA RID: 16042
	public int ID = 1;

	// Token: 0x04003EAB RID: 16043
	public bool Tutorials;
}
