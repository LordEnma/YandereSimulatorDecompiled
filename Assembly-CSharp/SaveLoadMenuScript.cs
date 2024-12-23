using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadMenuScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public GameObject ConfirmWindow;

	public GameObject WarningWindow;

	public ClockScript Clock;

	public Texture DefaultThumbnail;

	public UILabel AreYouSureLabel;

	public UILabel Header;

	public UITexture[] Thumbnails;

	public UILabel[] DataLabels;

	public Transform Highlight;

	public Camera UICamera;

	public bool GrabScreenshot;

	public bool Loading;

	public bool Saving;

	public int Profile;

	public int Row = 1;

	public int Column = 1;

	public int Selected = 1;

	public void Start()
	{
		if (GameGlobals.Profile == 0)
		{
			GameGlobals.Profile = 1;
		}
		Profile = GameGlobals.Profile;
		WarningWindow.SetActive(value: true);
		ConfirmWindow.SetActive(value: false);
		StartCoroutine(GetThumbnails());
	}

	public void Update()
	{
		if (!ConfirmWindow.activeInHierarchy)
		{
			if (InputManager.TappedUp)
			{
				Row--;
				UpdateHighlight();
			}
			else if (InputManager.TappedDown)
			{
				Row++;
				UpdateHighlight();
			}
			if (InputManager.TappedLeft)
			{
				Column--;
				UpdateHighlight();
			}
			else if (InputManager.TappedRight)
			{
				Column++;
				UpdateHighlight();
			}
		}
		if (GrabScreenshot)
		{
			if (GameGlobals.Profile == 0)
			{
				Debug.Log("Grabbin' a screenshot!");
				GameGlobals.Profile = 1;
				Profile = 1;
			}
			PauseScreen.Yandere.Blur.enabled = true;
			UICamera.enabled = true;
			StudentManager.Save();
			StartCoroutine(GetThumbnails());
			if (DateGlobals.Weekday == DayOfWeek.Monday)
			{
				PlayerPrefs.SetInt("Profile_" + Profile + "_Slot_" + Selected + "_Weekday", 1);
			}
			else if (DateGlobals.Weekday == DayOfWeek.Tuesday)
			{
				PlayerPrefs.SetInt("Profile_" + Profile + "_Slot_" + Selected + "_Weekday", 2);
			}
			else if (DateGlobals.Weekday == DayOfWeek.Wednesday)
			{
				PlayerPrefs.SetInt("Profile_" + Profile + "_Slot_" + Selected + "_Weekday", 3);
			}
			else if (DateGlobals.Weekday == DayOfWeek.Thursday)
			{
				PlayerPrefs.SetInt("Profile_" + Profile + "_Slot_" + Selected + "_Weekday", 4);
			}
			else if (DateGlobals.Weekday == DayOfWeek.Friday)
			{
				PlayerPrefs.SetInt("Profile_" + Profile + "_Slot_" + Selected + "_Weekday", 5);
			}
			GrabScreenshot = false;
		}
		if (WarningWindow.activeInHierarchy)
		{
			if (Input.GetButtonDown("A"))
			{
				WarningWindow.SetActive(value: false);
			}
			else if (Input.GetButtonDown("B"))
			{
				PauseScreen.MainMenu.SetActive(value: true);
				PauseScreen.Sideways = false;
				PauseScreen.PressedB = true;
				base.gameObject.SetActive(value: false);
				PauseScreen.PromptBar.ClearButtons();
				PauseScreen.PromptBar.Label[0].text = "Accept";
				PauseScreen.PromptBar.Label[1].text = "Exit";
				PauseScreen.PromptBar.Label[4].text = "Choose";
				PauseScreen.PromptBar.UpdateButtons();
				PauseScreen.PromptBar.Show = true;
			}
			return;
		}
		if (Input.GetButtonDown("A"))
		{
			if (Loading)
			{
				if (DataLabels[Selected].text != "No Data")
				{
					if (!ConfirmWindow.activeInHierarchy)
					{
						AreYouSureLabel.text = "Are you sure you'd like to load?";
						ConfirmWindow.SetActive(value: true);
					}
					else if (DataLabels[Selected].text != "No Data")
					{
						PlayerPrefs.SetInt("LoadingSave", 1);
						PlayerPrefs.SetInt("SaveSlot", Selected);
						YanSave.LoadPrefs("Profile_" + GameGlobals.Profile + "_Slot_" + Selected);
						SceneManager.LoadScene("LoadingScene");
					}
				}
			}
			else if (Saving)
			{
				if (!ConfirmWindow.activeInHierarchy)
				{
					AreYouSureLabel.text = "Are you sure you'd like to save?";
					ConfirmWindow.SetActive(value: true);
				}
				else
				{
					ConfirmWindow.SetActive(value: false);
					PlayerPrefs.SetInt("SaveSlot", Selected);
					GameGlobals.MostRecentSlot = Selected;
					PlayerPrefs.SetString("Profile_" + Profile + "_Slot_" + Selected + "_DateTime", DateGlobals.Weekday.ToString() + ", Week " + DateGlobals.Week + " " + DateTime.Now.ToString());
					ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/SaveData/Profile_" + Profile + "/Slot_" + Selected + "_Thumbnail.png");
					PauseScreen.Yandere.Blur.enabled = false;
					UICamera.enabled = false;
					GrabScreenshot = true;
				}
			}
		}
		if (Input.GetButtonDown("X") && PlayerPrefs.GetString("Profile_" + Profile + "_Slot_" + Selected + "_DateTime") != "")
		{
			File.Delete(Application.streamingAssetsPath + "/SaveData/Profile_" + Profile + "/Slot_" + Selected + "_Thumbnail.png");
			PlayerPrefs.SetString("Profile_" + Profile + "_Slot_" + Selected + "_DateTime", "");
			Thumbnails[Selected].mainTexture = DefaultThumbnail;
			DataLabels[Selected].text = "No Data";
			if (Selected == GameGlobals.MostRecentSlot)
			{
				GameGlobals.MostRecentSlot = 0;
			}
		}
		if (Input.GetButtonDown("B"))
		{
			if (ConfirmWindow.activeInHierarchy)
			{
				ConfirmWindow.SetActive(value: false);
				return;
			}
			PauseScreen.MainMenu.SetActive(value: true);
			PauseScreen.Sideways = false;
			PauseScreen.PressedB = true;
			base.gameObject.SetActive(value: false);
			PauseScreen.PromptBar.ClearButtons();
			PauseScreen.PromptBar.Label[0].text = "Accept";
			PauseScreen.PromptBar.Label[1].text = "Exit";
			PauseScreen.PromptBar.Label[4].text = "Choose";
			PauseScreen.PromptBar.UpdateButtons();
			PauseScreen.PromptBar.Show = true;
		}
	}

	public IEnumerator GetThumbnails()
	{
		for (int ID = 1; ID < 11; ID++)
		{
			if (PlayerPrefs.GetString("Profile_" + Profile + "_Slot_" + ID + "_DateTime") != "")
			{
				DataLabels[ID].text = PlayerPrefs.GetString("Profile_" + Profile + "_Slot_" + ID + "_DateTime");
				string url = "file:///" + Application.streamingAssetsPath + "/SaveData/Profile_" + Profile + "/Slot_" + ID + "_Thumbnail.png";
				WWW www = new WWW(url);
				yield return www;
				if (www.error == null)
				{
					Thumbnails[ID].mainTexture = www.texture;
				}
				else
				{
					Debug.Log("Could not retrieve the thumbnail. Maybe it was deleted from Streaming Assets?");
				}
			}
			else
			{
				DataLabels[ID].text = "No Data";
			}
		}
	}

	public void UpdateHighlight()
	{
		if (Row < 1)
		{
			Row = 2;
		}
		else if (Row > 2)
		{
			Row = 1;
		}
		if (Column < 1)
		{
			Column = 5;
		}
		else if (Column > 5)
		{
			Column = 1;
		}
		Highlight.localPosition = new Vector3(-510 + 170 * Column, 313 - 226 * Row, Highlight.localPosition.z);
		Selected = Column + (Row - 1) * 5;
	}
}
