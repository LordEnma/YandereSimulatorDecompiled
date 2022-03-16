using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200040C RID: 1036
public class SaveLoadMenuScript : MonoBehaviour
{
	// Token: 0x06001C4F RID: 7247 RVA: 0x0014A2E1 File Offset: 0x001484E1
	public void Start()
	{
		if (GameGlobals.Profile == 0)
		{
			GameGlobals.Profile = 1;
		}
		this.Profile = GameGlobals.Profile;
		this.WarningWindow.SetActive(true);
		this.ConfirmWindow.SetActive(false);
		base.StartCoroutine(this.GetThumbnails());
	}

	// Token: 0x06001C50 RID: 7248 RVA: 0x0014A320 File Offset: 0x00148520
	public void Update()
	{
		if (!this.ConfirmWindow.activeInHierarchy)
		{
			if (this.InputManager.TappedUp)
			{
				this.Row--;
				this.UpdateHighlight();
			}
			else if (this.InputManager.TappedDown)
			{
				this.Row++;
				this.UpdateHighlight();
			}
			if (this.InputManager.TappedLeft)
			{
				this.Column--;
				this.UpdateHighlight();
			}
			else if (this.InputManager.TappedRight)
			{
				this.Column++;
				this.UpdateHighlight();
			}
		}
		if (this.GrabScreenshot)
		{
			if (GameGlobals.Profile == 0)
			{
				Debug.Log("Grabbin' a screenshot!");
				GameGlobals.Profile = 1;
				this.Profile = 1;
			}
			this.PauseScreen.Yandere.Blur.enabled = true;
			this.UICamera.enabled = true;
			this.StudentManager.Save();
			base.StartCoroutine(this.GetThumbnails());
			if (DateGlobals.Weekday == DayOfWeek.Monday)
			{
				PlayerPrefs.SetInt(string.Concat(new string[]
				{
					"Profile_",
					this.Profile.ToString(),
					"_Slot_",
					this.Selected.ToString(),
					"_Weekday"
				}), 1);
			}
			else if (DateGlobals.Weekday == DayOfWeek.Tuesday)
			{
				PlayerPrefs.SetInt(string.Concat(new string[]
				{
					"Profile_",
					this.Profile.ToString(),
					"_Slot_",
					this.Selected.ToString(),
					"_Weekday"
				}), 2);
			}
			else if (DateGlobals.Weekday == DayOfWeek.Wednesday)
			{
				PlayerPrefs.SetInt(string.Concat(new string[]
				{
					"Profile_",
					this.Profile.ToString(),
					"_Slot_",
					this.Selected.ToString(),
					"_Weekday"
				}), 3);
			}
			else if (DateGlobals.Weekday == DayOfWeek.Thursday)
			{
				PlayerPrefs.SetInt(string.Concat(new string[]
				{
					"Profile_",
					this.Profile.ToString(),
					"_Slot_",
					this.Selected.ToString(),
					"_Weekday"
				}), 4);
			}
			else if (DateGlobals.Weekday == DayOfWeek.Friday)
			{
				PlayerPrefs.SetInt(string.Concat(new string[]
				{
					"Profile_",
					this.Profile.ToString(),
					"_Slot_",
					this.Selected.ToString(),
					"_Weekday"
				}), 5);
			}
			this.GrabScreenshot = false;
		}
		if (this.WarningWindow.activeInHierarchy)
		{
			if (Input.GetButtonDown("A"))
			{
				this.WarningWindow.SetActive(false);
				return;
			}
			if (Input.GetButtonDown("B"))
			{
				this.PauseScreen.MainMenu.SetActive(true);
				this.PauseScreen.Sideways = false;
				this.PauseScreen.PressedB = true;
				base.gameObject.SetActive(false);
				this.PauseScreen.PromptBar.ClearButtons();
				this.PauseScreen.PromptBar.Label[0].text = "Accept";
				this.PauseScreen.PromptBar.Label[1].text = "Exit";
				this.PauseScreen.PromptBar.Label[4].text = "Choose";
				this.PauseScreen.PromptBar.UpdateButtons();
				this.PauseScreen.PromptBar.Show = true;
				return;
			}
		}
		else
		{
			if (Input.GetButtonDown("A"))
			{
				if (this.Loading)
				{
					if (this.DataLabels[this.Selected].text != "No Data")
					{
						if (!this.ConfirmWindow.activeInHierarchy)
						{
							this.AreYouSureLabel.text = "Are you sure you'd like to load?";
							this.ConfirmWindow.SetActive(true);
						}
						else if (this.DataLabels[this.Selected].text != "No Data")
						{
							PlayerPrefs.SetInt("LoadingSave", 1);
							PlayerPrefs.SetInt("SaveSlot", this.Selected);
							YanSave.LoadPrefs("Profile_" + GameGlobals.Profile.ToString() + "_Slot_" + this.Selected.ToString());
							SceneManager.LoadScene("LoadingScene");
						}
					}
				}
				else if (this.Saving)
				{
					if (!this.ConfirmWindow.activeInHierarchy)
					{
						this.AreYouSureLabel.text = "Are you sure you'd like to save?";
						this.ConfirmWindow.SetActive(true);
					}
					else
					{
						this.ConfirmWindow.SetActive(false);
						PlayerPrefs.SetInt("SaveSlot", this.Selected);
						GameGlobals.MostRecentSlot = this.Selected;
						PlayerPrefs.SetString(string.Concat(new string[]
						{
							"Profile_",
							this.Profile.ToString(),
							"_Slot_",
							this.Selected.ToString(),
							"_DateTime"
						}), DateTime.Now.ToString());
						ScreenCapture.CaptureScreenshot(string.Concat(new string[]
						{
							Application.streamingAssetsPath,
							"/SaveData/Profile_",
							this.Profile.ToString(),
							"/Slot_",
							this.Selected.ToString(),
							"_Thumbnail.png"
						}));
						this.PauseScreen.Yandere.Blur.enabled = false;
						this.UICamera.enabled = false;
						this.GrabScreenshot = true;
					}
				}
			}
			if (Input.GetButtonDown("X"))
			{
				if (this.Loading)
				{
					if (this.DataLabels[this.Selected].text != "No Data")
					{
						PlayerPrefs.SetInt("SaveSlot", this.Selected);
						this.StudentManager.Load();
						Physics.SyncTransforms();
						if (PlayerPrefs.GetInt(string.Concat(new string[]
						{
							"Profile_",
							this.Profile.ToString(),
							"_Slot_",
							this.Selected.ToString(),
							"_Weekday"
						})) == 1)
						{
							DateGlobals.Weekday = DayOfWeek.Monday;
						}
						else if (PlayerPrefs.GetInt(string.Concat(new string[]
						{
							"Profile_",
							this.Profile.ToString(),
							"_Slot_",
							this.Selected.ToString(),
							"_Weekday"
						})) == 2)
						{
							DateGlobals.Weekday = DayOfWeek.Tuesday;
						}
						else if (PlayerPrefs.GetInt(string.Concat(new string[]
						{
							"Profile_",
							this.Profile.ToString(),
							"_Slot_",
							this.Selected.ToString(),
							"_Weekday"
						})) == 3)
						{
							DateGlobals.Weekday = DayOfWeek.Wednesday;
						}
						else if (PlayerPrefs.GetInt(string.Concat(new string[]
						{
							"Profile_",
							this.Profile.ToString(),
							"_Slot_",
							this.Selected.ToString(),
							"_Weekday"
						})) == 4)
						{
							DateGlobals.Weekday = DayOfWeek.Tuesday;
						}
						else if (PlayerPrefs.GetInt(string.Concat(new string[]
						{
							"Profile_",
							this.Profile.ToString(),
							"_Slot_",
							this.Selected.ToString(),
							"_Weekday"
						})) == 5)
						{
							DateGlobals.Weekday = DayOfWeek.Wednesday;
						}
						this.Clock.DayLabel.text = this.Clock.GetWeekdayText(DateGlobals.Weekday);
						this.PauseScreen.MainMenu.SetActive(true);
						this.PauseScreen.Sideways = false;
						this.PauseScreen.PressedB = true;
						base.gameObject.SetActive(false);
						this.PauseScreen.ExitPhone();
					}
				}
				else if (this.Saving && PlayerPrefs.GetString(string.Concat(new string[]
				{
					"Profile_",
					this.Profile.ToString(),
					"_Slot_",
					this.Selected.ToString(),
					"_DateTime"
				})) != "")
				{
					File.Delete(string.Concat(new string[]
					{
						Application.streamingAssetsPath,
						"/SaveData/Profile_",
						this.Profile.ToString(),
						"/Slot_",
						this.Selected.ToString(),
						"_Thumbnail.png"
					}));
					PlayerPrefs.SetString(string.Concat(new string[]
					{
						"Profile_",
						this.Profile.ToString(),
						"_Slot_",
						this.Selected.ToString(),
						"_DateTime"
					}), "");
					this.Thumbnails[this.Selected].mainTexture = this.DefaultThumbnail;
					this.DataLabels[this.Selected].text = "No Data";
				}
			}
			if (Input.GetButtonDown("B"))
			{
				if (this.ConfirmWindow.activeInHierarchy)
				{
					this.ConfirmWindow.SetActive(false);
					return;
				}
				this.PauseScreen.MainMenu.SetActive(true);
				this.PauseScreen.Sideways = false;
				this.PauseScreen.PressedB = true;
				base.gameObject.SetActive(false);
				this.PauseScreen.PromptBar.ClearButtons();
				this.PauseScreen.PromptBar.Label[0].text = "Accept";
				this.PauseScreen.PromptBar.Label[1].text = "Exit";
				this.PauseScreen.PromptBar.Label[4].text = "Choose";
				this.PauseScreen.PromptBar.UpdateButtons();
				this.PauseScreen.PromptBar.Show = true;
			}
		}
	}

	// Token: 0x06001C51 RID: 7249 RVA: 0x0014AD11 File Offset: 0x00148F11
	public IEnumerator GetThumbnails()
	{
		int num;
		for (int ID = 1; ID < 11; ID = num + 1)
		{
			if (PlayerPrefs.GetString(string.Concat(new string[]
			{
				"Profile_",
				this.Profile.ToString(),
				"_Slot_",
				ID.ToString(),
				"_DateTime"
			})) != "")
			{
				this.DataLabels[ID].text = PlayerPrefs.GetString(string.Concat(new string[]
				{
					"Profile_",
					this.Profile.ToString(),
					"_Slot_",
					ID.ToString(),
					"_DateTime"
				}));
				string url = string.Concat(new string[]
				{
					"file:///",
					Application.streamingAssetsPath,
					"/SaveData/Profile_",
					this.Profile.ToString(),
					"/Slot_",
					ID.ToString(),
					"_Thumbnail.png"
				});
				WWW www = new WWW(url);
				yield return www;
				if (www.error == null)
				{
					this.Thumbnails[ID].mainTexture = www.texture;
				}
				else
				{
					Debug.Log("Could not retrieve the thumbnail. Maybe it was deleted from Streaming Assets?");
				}
				www = null;
			}
			else
			{
				this.DataLabels[ID].text = "No Data";
			}
			num = ID;
		}
		yield break;
	}

	// Token: 0x06001C52 RID: 7250 RVA: 0x0014AD20 File Offset: 0x00148F20
	public void UpdateHighlight()
	{
		if (this.Row < 1)
		{
			this.Row = 2;
		}
		else if (this.Row > 2)
		{
			this.Row = 1;
		}
		if (this.Column < 1)
		{
			this.Column = 5;
		}
		else if (this.Column > 5)
		{
			this.Column = 1;
		}
		this.Highlight.localPosition = new Vector3((float)(-510 + 170 * this.Column), (float)(313 - 226 * this.Row), this.Highlight.localPosition.z);
		this.Selected = this.Column + (this.Row - 1) * 5;
	}

	// Token: 0x040031FD RID: 12797
	public StudentManagerScript StudentManager;

	// Token: 0x040031FE RID: 12798
	public InputManagerScript InputManager;

	// Token: 0x040031FF RID: 12799
	public PauseScreenScript PauseScreen;

	// Token: 0x04003200 RID: 12800
	public GameObject ConfirmWindow;

	// Token: 0x04003201 RID: 12801
	public GameObject WarningWindow;

	// Token: 0x04003202 RID: 12802
	public ClockScript Clock;

	// Token: 0x04003203 RID: 12803
	public Texture DefaultThumbnail;

	// Token: 0x04003204 RID: 12804
	public UILabel AreYouSureLabel;

	// Token: 0x04003205 RID: 12805
	public UILabel Header;

	// Token: 0x04003206 RID: 12806
	public UITexture[] Thumbnails;

	// Token: 0x04003207 RID: 12807
	public UILabel[] DataLabels;

	// Token: 0x04003208 RID: 12808
	public Transform Highlight;

	// Token: 0x04003209 RID: 12809
	public Camera UICamera;

	// Token: 0x0400320A RID: 12810
	public bool GrabScreenshot;

	// Token: 0x0400320B RID: 12811
	public bool Loading;

	// Token: 0x0400320C RID: 12812
	public bool Saving;

	// Token: 0x0400320D RID: 12813
	public int Profile;

	// Token: 0x0400320E RID: 12814
	public int Row = 1;

	// Token: 0x0400320F RID: 12815
	public int Column = 1;

	// Token: 0x04003210 RID: 12816
	public int Selected = 1;
}
