using System;
using UnityEngine;

// Token: 0x02000473 RID: 1139
public class TitleSaveFilesScript : MonoBehaviour
{
	// Token: 0x06001EA2 RID: 7842 RVA: 0x001AD8FC File Offset: 0x001ABAFC
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
						if (!this.NewTitleScreen.Eighties && GameGlobals.Debug)
						{
							this.PromptBar.Label[3].text = "Quick Start";
						}
						this.PromptBar.Label[4].text = "Change Selection";
						this.UpdateHighlight();
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = true;
					}
					if (Input.GetButtonDown("A") || (GameGlobals.Debug && Input.GetButtonDown("Y")))
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
						if (this.NewTitleScreen.Eighties && GameGlobals.Debug && Input.GetButtonDown("Y"))
						{
							this.NewTitleScreen.QuickStart = true;
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

	// Token: 0x06001EA3 RID: 7843 RVA: 0x001ADD90 File Offset: 0x001ABF90
	private void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(0f, 700f - 350f * (float)this.ID, 0f);
		if (PlayerPrefs.GetInt("ProfileCreated_" + (this.EightiesPrefix + this.ID).ToString()) > 0)
		{
			this.PromptBar.Label[2].text = "Delete";
			this.PromptBar.UpdateButtons();
		}
		else
		{
			this.PromptBar.Label[2].text = "";
		}
		this.PromptBar.UpdateButtons();
	}

	// Token: 0x06001EA4 RID: 7844 RVA: 0x001ADE38 File Offset: 0x001AC038
	public void UpdateOutlines()
	{
		UILabel[] componentsInChildren = base.GetComponentsInChildren<UILabel>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].effectColor = new Color(0f, 0f, 0f);
		}
	}

	// Token: 0x04003F72 RID: 16242
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04003F73 RID: 16243
	public InputManagerScript InputManager;

	// Token: 0x04003F74 RID: 16244
	public TitleSaveDataScript[] SaveDatas;

	// Token: 0x04003F75 RID: 16245
	public UILabel CorruptSaveLabel;

	// Token: 0x04003F76 RID: 16246
	public UILabel NewSaveLabel;

	// Token: 0x04003F77 RID: 16247
	public GameObject ConfirmationWindow;

	// Token: 0x04003F78 RID: 16248
	public GameObject ErrorWindow;

	// Token: 0x04003F79 RID: 16249
	public PromptBarScript PromptBar;

	// Token: 0x04003F7A RID: 16250
	public TitleMenuScript Menu;

	// Token: 0x04003F7B RID: 16251
	public Transform Highlight;

	// Token: 0x04003F7C RID: 16252
	public bool Started;

	// Token: 0x04003F7D RID: 16253
	public bool Show;

	// Token: 0x04003F7E RID: 16254
	public int EightiesPrefix;

	// Token: 0x04003F7F RID: 16255
	public int ID = 1;
}
