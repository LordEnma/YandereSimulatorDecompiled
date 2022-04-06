using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000410 RID: 1040
public class SaveLoadMenuScript : MonoBehaviour
{
	// Token: 0x06001C5F RID: 7263 RVA: 0x0014B081 File Offset: 0x00149281
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

	// Token: 0x06001C60 RID: 7264 RVA: 0x0014B0C0 File Offset: 0x001492C0
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

	// Token: 0x06001C61 RID: 7265 RVA: 0x0014BAB1 File Offset: 0x00149CB1
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

	// Token: 0x06001C62 RID: 7266 RVA: 0x0014BAC0 File Offset: 0x00149CC0
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

	// Token: 0x04003219 RID: 12825
	public StudentManagerScript StudentManager;

	// Token: 0x0400321A RID: 12826
	public InputManagerScript InputManager;

	// Token: 0x0400321B RID: 12827
	public PauseScreenScript PauseScreen;

	// Token: 0x0400321C RID: 12828
	public GameObject ConfirmWindow;

	// Token: 0x0400321D RID: 12829
	public GameObject WarningWindow;

	// Token: 0x0400321E RID: 12830
	public ClockScript Clock;

	// Token: 0x0400321F RID: 12831
	public Texture DefaultThumbnail;

	// Token: 0x04003220 RID: 12832
	public UILabel AreYouSureLabel;

	// Token: 0x04003221 RID: 12833
	public UILabel Header;

	// Token: 0x04003222 RID: 12834
	public UITexture[] Thumbnails;

	// Token: 0x04003223 RID: 12835
	public UILabel[] DataLabels;

	// Token: 0x04003224 RID: 12836
	public Transform Highlight;

	// Token: 0x04003225 RID: 12837
	public Camera UICamera;

	// Token: 0x04003226 RID: 12838
	public bool GrabScreenshot;

	// Token: 0x04003227 RID: 12839
	public bool Loading;

	// Token: 0x04003228 RID: 12840
	public bool Saving;

	// Token: 0x04003229 RID: 12841
	public int Profile;

	// Token: 0x0400322A RID: 12842
	public int Row = 1;

	// Token: 0x0400322B RID: 12843
	public int Column = 1;

	// Token: 0x0400322C RID: 12844
	public int Selected = 1;
}
