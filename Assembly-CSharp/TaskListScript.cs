using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000471 RID: 1137
public class TaskListScript : MonoBehaviour
{
	// Token: 0x06001ED1 RID: 7889 RVA: 0x001B448C File Offset: 0x001B268C
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

	// Token: 0x06001ED2 RID: 7890 RVA: 0x001B4600 File Offset: 0x001B2800
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

	// Token: 0x06001ED3 RID: 7891 RVA: 0x001B471D File Offset: 0x001B291D
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

	// Token: 0x06001ED4 RID: 7892 RVA: 0x001B472C File Offset: 0x001B292C
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

	// Token: 0x04003FEE RID: 16366
	public TutorialWindowScript TutorialWindow;

	// Token: 0x04003FEF RID: 16367
	public InputManagerScript InputManager;

	// Token: 0x04003FF0 RID: 16368
	public PauseScreenScript PauseScreen;

	// Token: 0x04003FF1 RID: 16369
	public TaskWindowScript TaskWindow;

	// Token: 0x04003FF2 RID: 16370
	public JsonScript JSON;

	// Token: 0x04003FF3 RID: 16371
	public GameObject MainMenu;

	// Token: 0x04003FF4 RID: 16372
	public UITexture StudentIcon;

	// Token: 0x04003FF5 RID: 16373
	public UITexture TaskIcon;

	// Token: 0x04003FF6 RID: 16374
	public UILabel TaskDesc;

	// Token: 0x04003FF7 RID: 16375
	public Texture QuestionMark;

	// Token: 0x04003FF8 RID: 16376
	public Transform Highlight;

	// Token: 0x04003FF9 RID: 16377
	public Texture Silhouette;

	// Token: 0x04003FFA RID: 16378
	public UILabel[] TaskNameLabels;

	// Token: 0x04003FFB RID: 16379
	public UISprite[] Checkmarks;

	// Token: 0x04003FFC RID: 16380
	public Texture[] TutorialTextures;

	// Token: 0x04003FFD RID: 16381
	public string[] TutorialDescs;

	// Token: 0x04003FFE RID: 16382
	public string[] TutorialNames;

	// Token: 0x04003FFF RID: 16383
	public int ListPosition;

	// Token: 0x04004000 RID: 16384
	public int Limit = 84;

	// Token: 0x04004001 RID: 16385
	public int ID = 1;

	// Token: 0x04004002 RID: 16386
	public bool Tutorials;
}
