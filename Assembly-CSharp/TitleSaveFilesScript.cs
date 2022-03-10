using System;
using UnityEngine;

// Token: 0x02000479 RID: 1145
public class TitleSaveFilesScript : MonoBehaviour
{
	// Token: 0x06001ED4 RID: 7892 RVA: 0x001B22AC File Offset: 0x001B04AC
	private void Update()
	{
		if (this.NewTitleScreen.Speed > 3f && !this.NewTitleScreen.FadeOut)
		{
			if (this.Started)
			{
				this.ErrorWindow.SetActive(true);
				if (!this.Started)
				{
					this.CorruptSaveLabel.gameObject.SetActive(true);
					this.NewSaveLabel.gameObject.SetActive(false);
				}
				this.Started = false;
			}
			if (!this.ConfirmationWindow.activeInHierarchy)
			{
				if (this.InputManager.TappedDown)
				{
					this.ID++;
					if (this.ID > 3)
					{
						this.ID = 1;
					}
					this.UpdateHighlight();
				}
				if (this.InputManager.TappedUp)
				{
					this.ID--;
					if (this.ID < 1)
					{
						this.ID = 3;
					}
					this.UpdateHighlight();
				}
			}
			if (!this.ErrorWindow.activeInHierarchy)
			{
				if (!this.ConfirmationWindow.activeInHierarchy)
				{
					if (!this.PromptBar.Show)
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[0].text = "Make Selection";
						this.PromptBar.Label[1].text = "Go Back";
						this.PromptBar.Label[4].text = "Change Selection";
						this.UpdateHighlight();
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = true;
					}
					if (Input.GetButtonDown("A") || (this.PromptBar.Label[3].text != "" && Input.GetButtonDown("Y")))
					{
						if (PlayerPrefs.GetInt("ProfileCreated_" + (this.EightiesPrefix + this.ID).ToString()) == 0)
						{
							this.Started = true;
							bool debug = GameGlobals.Debug;
							GameGlobals.Profile = this.EightiesPrefix + this.ID;
							Globals.DeleteAll();
							if (GameGlobals.Eighties)
							{
								for (int i = 1; i < 101; i++)
								{
									StudentGlobals.SetStudentPhotographed(i, true);
								}
							}
							GameGlobals.Profile = this.EightiesPrefix + this.ID;
							GameGlobals.Debug = debug;
							this.NewTitleScreen.Darkness.color = new Color(1f, 1f, 1f, 0f);
							this.Started = false;
						}
						else
						{
							Debug.Log("The game believed that Profile " + (this.EightiesPrefix + this.ID).ToString() + " already existed, so that profile is now being loaded.");
							GameGlobals.Profile = this.EightiesPrefix + this.ID;
							GameGlobals.Eighties = this.NewTitleScreen.Eighties;
						}
						this.NewTitleScreen.FadeOut = true;
						if (Input.GetButtonDown("Y"))
						{
							if (!this.NewTitleScreen.Eighties)
							{
								this.NewTitleScreen.QuickStart = true;
								return;
							}
							this.NewTitleScreen.WeekSelect = true;
							return;
						}
					}
					else if (Input.GetButtonDown("X"))
					{
						if (PlayerPrefs.GetInt("ProfileCreated_" + (this.EightiesPrefix + this.ID).ToString()) > 0)
						{
							this.ConfirmationWindow.SetActive(true);
							return;
						}
					}
					else if (Input.GetButtonDown("B"))
					{
						this.NewTitleScreen.Speed = 0f;
						this.NewTitleScreen.Phase = 2;
						this.PromptBar.Show = false;
						base.enabled = false;
						return;
					}
				}
				else
				{
					this.PromptBar.Show = false;
					if (Input.GetButtonDown("A"))
					{
						PlayerPrefs.SetInt("ProfileCreated_" + (this.EightiesPrefix + this.ID).ToString(), 0);
						this.ConfirmationWindow.SetActive(false);
						this.SaveDatas[this.ID].Start();
						return;
					}
					if (Input.GetButtonDown("B"))
					{
						this.ConfirmationWindow.SetActive(false);
						return;
					}
				}
			}
			else if (Input.anyKeyDown)
			{
				PlayerPrefs.DeleteAll();
				Debug.Log("All player prefs deleted...");
				Application.Quit();
			}
		}
	}

	// Token: 0x06001ED5 RID: 7893 RVA: 0x001B26BC File Offset: 0x001B08BC
	private void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(0f, 700f - 350f * (float)this.ID, 0f);
		this.PromptBar.Label[2].text = "";
		this.PromptBar.Label[3].text = "";
		if (PlayerPrefs.GetInt("ProfileCreated_" + (this.EightiesPrefix + this.ID).ToString()) > 0)
		{
			this.PromptBar.Label[2].text = "Delete";
			this.PromptBar.UpdateButtons();
		}
		else if (!this.NewTitleScreen.Eighties)
		{
			if (GameGlobals.Debug)
			{
				this.PromptBar.Label[3].text = "Quick Start";
			}
		}
		else
		{
			this.PromptBar.Label[3].text = "Debug";
		}
		this.PromptBar.UpdateButtons();
	}

	// Token: 0x06001ED6 RID: 7894 RVA: 0x001B27C0 File Offset: 0x001B09C0
	public void UpdateOutlines()
	{
		UILabel[] componentsInChildren = base.GetComponentsInChildren<UILabel>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].effectColor = new Color(0f, 0f, 0f);
		}
	}

	// Token: 0x04004005 RID: 16389
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04004006 RID: 16390
	public InputManagerScript InputManager;

	// Token: 0x04004007 RID: 16391
	public TitleSaveDataScript[] SaveDatas;

	// Token: 0x04004008 RID: 16392
	public UILabel CorruptSaveLabel;

	// Token: 0x04004009 RID: 16393
	public UILabel NewSaveLabel;

	// Token: 0x0400400A RID: 16394
	public GameObject ConfirmationWindow;

	// Token: 0x0400400B RID: 16395
	public GameObject ErrorWindow;

	// Token: 0x0400400C RID: 16396
	public PromptBarScript PromptBar;

	// Token: 0x0400400D RID: 16397
	public TitleMenuScript Menu;

	// Token: 0x0400400E RID: 16398
	public Transform Highlight;

	// Token: 0x0400400F RID: 16399
	public bool Started;

	// Token: 0x04004010 RID: 16400
	public bool Show;

	// Token: 0x04004011 RID: 16401
	public int EightiesPrefix;

	// Token: 0x04004012 RID: 16402
	public int ID = 1;
}
