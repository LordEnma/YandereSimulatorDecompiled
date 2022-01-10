using System;
using UnityEngine;

// Token: 0x02000476 RID: 1142
public class TitleSaveFilesScript : MonoBehaviour
{
	// Token: 0x06001EB9 RID: 7865 RVA: 0x001AF4BC File Offset: 0x001AD6BC
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
						Debug.Log("Now checking Profile " + (this.EightiesPrefix + this.ID).ToString() + ".");
						if (PlayerPrefs.GetInt("ProfileCreated_" + (this.EightiesPrefix + this.ID).ToString()) == 0)
						{
							Debug.Log("The game believed that Profile " + (this.EightiesPrefix + this.ID).ToString() + " was empty, so that profile is now being created.");
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
						Debug.Log("As of now, the game should be forgetting everything it knows about Profile " + (this.EightiesPrefix + this.ID).ToString() + ".");
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

	// Token: 0x06001EBA RID: 7866 RVA: 0x001AF938 File Offset: 0x001ADB38
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

	// Token: 0x06001EBB RID: 7867 RVA: 0x001AFA3C File Offset: 0x001ADC3C
	public void UpdateOutlines()
	{
		UILabel[] componentsInChildren = base.GetComponentsInChildren<UILabel>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].effectColor = new Color(0f, 0f, 0f);
		}
	}

	// Token: 0x04003FBD RID: 16317
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04003FBE RID: 16318
	public InputManagerScript InputManager;

	// Token: 0x04003FBF RID: 16319
	public TitleSaveDataScript[] SaveDatas;

	// Token: 0x04003FC0 RID: 16320
	public UILabel CorruptSaveLabel;

	// Token: 0x04003FC1 RID: 16321
	public UILabel NewSaveLabel;

	// Token: 0x04003FC2 RID: 16322
	public GameObject ConfirmationWindow;

	// Token: 0x04003FC3 RID: 16323
	public GameObject ErrorWindow;

	// Token: 0x04003FC4 RID: 16324
	public PromptBarScript PromptBar;

	// Token: 0x04003FC5 RID: 16325
	public TitleMenuScript Menu;

	// Token: 0x04003FC6 RID: 16326
	public Transform Highlight;

	// Token: 0x04003FC7 RID: 16327
	public bool Started;

	// Token: 0x04003FC8 RID: 16328
	public bool Show;

	// Token: 0x04003FC9 RID: 16329
	public int EightiesPrefix;

	// Token: 0x04003FCA RID: 16330
	public int ID = 1;
}
