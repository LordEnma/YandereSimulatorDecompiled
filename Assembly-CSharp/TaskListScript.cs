using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000469 RID: 1129
public class TaskListScript : MonoBehaviour
{
	// Token: 0x06001E93 RID: 7827 RVA: 0x001AD9FC File Offset: 0x001ABBFC
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

	// Token: 0x06001E94 RID: 7828 RVA: 0x001ADB70 File Offset: 0x001ABD70
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

	// Token: 0x06001E95 RID: 7829 RVA: 0x001ADC8D File Offset: 0x001ABE8D
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

	// Token: 0x06001E96 RID: 7830 RVA: 0x001ADC9C File Offset: 0x001ABE9C
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

	// Token: 0x04003F12 RID: 16146
	public TutorialWindowScript TutorialWindow;

	// Token: 0x04003F13 RID: 16147
	public InputManagerScript InputManager;

	// Token: 0x04003F14 RID: 16148
	public PauseScreenScript PauseScreen;

	// Token: 0x04003F15 RID: 16149
	public TaskWindowScript TaskWindow;

	// Token: 0x04003F16 RID: 16150
	public JsonScript JSON;

	// Token: 0x04003F17 RID: 16151
	public GameObject MainMenu;

	// Token: 0x04003F18 RID: 16152
	public UITexture StudentIcon;

	// Token: 0x04003F19 RID: 16153
	public UITexture TaskIcon;

	// Token: 0x04003F1A RID: 16154
	public UILabel TaskDesc;

	// Token: 0x04003F1B RID: 16155
	public Texture QuestionMark;

	// Token: 0x04003F1C RID: 16156
	public Transform Highlight;

	// Token: 0x04003F1D RID: 16157
	public Texture Silhouette;

	// Token: 0x04003F1E RID: 16158
	public UILabel[] TaskNameLabels;

	// Token: 0x04003F1F RID: 16159
	public UISprite[] Checkmarks;

	// Token: 0x04003F20 RID: 16160
	public Texture[] TutorialTextures;

	// Token: 0x04003F21 RID: 16161
	public string[] TutorialDescs;

	// Token: 0x04003F22 RID: 16162
	public string[] TutorialNames;

	// Token: 0x04003F23 RID: 16163
	public int ListPosition;

	// Token: 0x04003F24 RID: 16164
	public int Limit = 84;

	// Token: 0x04003F25 RID: 16165
	public int ID = 1;

	// Token: 0x04003F26 RID: 16166
	public bool Tutorials;
}
