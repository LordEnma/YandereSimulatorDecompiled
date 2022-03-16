using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200046B RID: 1131
public class TaskListScript : MonoBehaviour
{
	// Token: 0x06001EA6 RID: 7846 RVA: 0x001AF830 File Offset: 0x001ADA30
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

	// Token: 0x06001EA7 RID: 7847 RVA: 0x001AF9A4 File Offset: 0x001ADBA4
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

	// Token: 0x06001EA8 RID: 7848 RVA: 0x001AFAC1 File Offset: 0x001ADCC1
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

	// Token: 0x06001EA9 RID: 7849 RVA: 0x001AFAD0 File Offset: 0x001ADCD0
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

	// Token: 0x04003F73 RID: 16243
	public TutorialWindowScript TutorialWindow;

	// Token: 0x04003F74 RID: 16244
	public InputManagerScript InputManager;

	// Token: 0x04003F75 RID: 16245
	public PauseScreenScript PauseScreen;

	// Token: 0x04003F76 RID: 16246
	public TaskWindowScript TaskWindow;

	// Token: 0x04003F77 RID: 16247
	public JsonScript JSON;

	// Token: 0x04003F78 RID: 16248
	public GameObject MainMenu;

	// Token: 0x04003F79 RID: 16249
	public UITexture StudentIcon;

	// Token: 0x04003F7A RID: 16250
	public UITexture TaskIcon;

	// Token: 0x04003F7B RID: 16251
	public UILabel TaskDesc;

	// Token: 0x04003F7C RID: 16252
	public Texture QuestionMark;

	// Token: 0x04003F7D RID: 16253
	public Transform Highlight;

	// Token: 0x04003F7E RID: 16254
	public Texture Silhouette;

	// Token: 0x04003F7F RID: 16255
	public UILabel[] TaskNameLabels;

	// Token: 0x04003F80 RID: 16256
	public UISprite[] Checkmarks;

	// Token: 0x04003F81 RID: 16257
	public Texture[] TutorialTextures;

	// Token: 0x04003F82 RID: 16258
	public string[] TutorialDescs;

	// Token: 0x04003F83 RID: 16259
	public string[] TutorialNames;

	// Token: 0x04003F84 RID: 16260
	public int ListPosition;

	// Token: 0x04003F85 RID: 16261
	public int Limit = 84;

	// Token: 0x04003F86 RID: 16262
	public int ID = 1;

	// Token: 0x04003F87 RID: 16263
	public bool Tutorials;
}
