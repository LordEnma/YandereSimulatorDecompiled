using System;
using UnityEngine;

// Token: 0x02000480 RID: 1152
public class TitleSaveFilesScript : MonoBehaviour
{
	// Token: 0x06001EFE RID: 7934 RVA: 0x001B5E50 File Offset: 0x001B4050
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

	// Token: 0x06001EFF RID: 7935 RVA: 0x001B6260 File Offset: 0x001B4460
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

	// Token: 0x06001F00 RID: 7936 RVA: 0x001B6364 File Offset: 0x001B4564
	public void UpdateOutlines()
	{
		UILabel[] componentsInChildren = base.GetComponentsInChildren<UILabel>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].effectColor = new Color(0f, 0f, 0f);
		}
	}

	// Token: 0x04004090 RID: 16528
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04004091 RID: 16529
	public InputManagerScript InputManager;

	// Token: 0x04004092 RID: 16530
	public TitleSaveDataScript[] SaveDatas;

	// Token: 0x04004093 RID: 16531
	public UILabel CorruptSaveLabel;

	// Token: 0x04004094 RID: 16532
	public UILabel NewSaveLabel;

	// Token: 0x04004095 RID: 16533
	public GameObject ConfirmationWindow;

	// Token: 0x04004096 RID: 16534
	public GameObject ErrorWindow;

	// Token: 0x04004097 RID: 16535
	public PromptBarScript PromptBar;

	// Token: 0x04004098 RID: 16536
	public TitleMenuScript Menu;

	// Token: 0x04004099 RID: 16537
	public Transform Highlight;

	// Token: 0x0400409A RID: 16538
	public bool Started;

	// Token: 0x0400409B RID: 16539
	public bool Show;

	// Token: 0x0400409C RID: 16540
	public int EightiesPrefix;

	// Token: 0x0400409D RID: 16541
	public int ID = 1;
}
