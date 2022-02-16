using System;
using UnityEngine;

// Token: 0x02000478 RID: 1144
public class TitleSaveFilesScript : MonoBehaviour
{
	// Token: 0x06001EC8 RID: 7880 RVA: 0x001B1048 File Offset: 0x001AF248
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

	// Token: 0x06001EC9 RID: 7881 RVA: 0x001B1448 File Offset: 0x001AF648
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

	// Token: 0x06001ECA RID: 7882 RVA: 0x001B154C File Offset: 0x001AF74C
	public void UpdateOutlines()
	{
		UILabel[] componentsInChildren = base.GetComponentsInChildren<UILabel>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].effectColor = new Color(0f, 0f, 0f);
		}
	}

	// Token: 0x04003FDE RID: 16350
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04003FDF RID: 16351
	public InputManagerScript InputManager;

	// Token: 0x04003FE0 RID: 16352
	public TitleSaveDataScript[] SaveDatas;

	// Token: 0x04003FE1 RID: 16353
	public UILabel CorruptSaveLabel;

	// Token: 0x04003FE2 RID: 16354
	public UILabel NewSaveLabel;

	// Token: 0x04003FE3 RID: 16355
	public GameObject ConfirmationWindow;

	// Token: 0x04003FE4 RID: 16356
	public GameObject ErrorWindow;

	// Token: 0x04003FE5 RID: 16357
	public PromptBarScript PromptBar;

	// Token: 0x04003FE6 RID: 16358
	public TitleMenuScript Menu;

	// Token: 0x04003FE7 RID: 16359
	public Transform Highlight;

	// Token: 0x04003FE8 RID: 16360
	public bool Started;

	// Token: 0x04003FE9 RID: 16361
	public bool Show;

	// Token: 0x04003FEA RID: 16362
	public int EightiesPrefix;

	// Token: 0x04003FEB RID: 16363
	public int ID = 1;
}
