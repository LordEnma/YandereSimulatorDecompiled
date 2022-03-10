using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000469 RID: 1129
public class TaskListScript : MonoBehaviour
{
	// Token: 0x06001E96 RID: 7830 RVA: 0x001AE124 File Offset: 0x001AC324
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

	// Token: 0x06001E97 RID: 7831 RVA: 0x001AE298 File Offset: 0x001AC498
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

	// Token: 0x06001E98 RID: 7832 RVA: 0x001AE3B5 File Offset: 0x001AC5B5
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

	// Token: 0x06001E99 RID: 7833 RVA: 0x001AE3C4 File Offset: 0x001AC5C4
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

	// Token: 0x04003F29 RID: 16169
	public TutorialWindowScript TutorialWindow;

	// Token: 0x04003F2A RID: 16170
	public InputManagerScript InputManager;

	// Token: 0x04003F2B RID: 16171
	public PauseScreenScript PauseScreen;

	// Token: 0x04003F2C RID: 16172
	public TaskWindowScript TaskWindow;

	// Token: 0x04003F2D RID: 16173
	public JsonScript JSON;

	// Token: 0x04003F2E RID: 16174
	public GameObject MainMenu;

	// Token: 0x04003F2F RID: 16175
	public UITexture StudentIcon;

	// Token: 0x04003F30 RID: 16176
	public UITexture TaskIcon;

	// Token: 0x04003F31 RID: 16177
	public UILabel TaskDesc;

	// Token: 0x04003F32 RID: 16178
	public Texture QuestionMark;

	// Token: 0x04003F33 RID: 16179
	public Transform Highlight;

	// Token: 0x04003F34 RID: 16180
	public Texture Silhouette;

	// Token: 0x04003F35 RID: 16181
	public UILabel[] TaskNameLabels;

	// Token: 0x04003F36 RID: 16182
	public UISprite[] Checkmarks;

	// Token: 0x04003F37 RID: 16183
	public Texture[] TutorialTextures;

	// Token: 0x04003F38 RID: 16184
	public string[] TutorialDescs;

	// Token: 0x04003F39 RID: 16185
	public string[] TutorialNames;

	// Token: 0x04003F3A RID: 16186
	public int ListPosition;

	// Token: 0x04003F3B RID: 16187
	public int Limit = 84;

	// Token: 0x04003F3C RID: 16188
	public int ID = 1;

	// Token: 0x04003F3D RID: 16189
	public bool Tutorials;
}
