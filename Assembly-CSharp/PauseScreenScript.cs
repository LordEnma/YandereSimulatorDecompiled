using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000392 RID: 914
public class PauseScreenScript : MonoBehaviour
{
	// Token: 0x06001A3C RID: 6716 RVA: 0x00115FF8 File Offset: 0x001141F8
	private void Start()
	{
		if (SceneManager.GetActiveScene().name != "SchoolScene")
		{
			MissionModeGlobals.MultiMission = false;
		}
		else
		{
			this.AtSchool = true;
		}
		if (!MissionModeGlobals.MultiMission)
		{
			this.MissionModeLabel.SetActive(false);
		}
		this.MultiMission = MissionModeGlobals.MultiMission;
		StudentGlobals.SetStudentPhotographed(0, true);
		StudentGlobals.SetStudentPhotographed(1, true);
		base.transform.localPosition = new Vector3(1350f, 0f, 0f);
		base.transform.localScale = new Vector3(0.9133334f, 0.9133334f, 0.9133334f);
		base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, 0f);
		this.FavorMenu.BountyMenu.gameObject.SetActive(false);
		this.StudentInfoMenu.gameObject.SetActive(false);
		this.InventoryMenu.gameObject.SetActive(false);
		this.PhotoGallery.gameObject.SetActive(false);
		this.SaveLoadMenu.gameObject.SetActive(false);
		this.ServiceMenu.gameObject.SetActive(false);
		this.NewSettings.gameObject.SetActive(false);
		this.AudioMenu.gameObject.SetActive(false);
		this.FavorMenu.gameObject.SetActive(false);
		this.IdeasMenu.gameObject.SetActive(false);
		this.Tutorials.gameObject.SetActive(false);
		this.PassTime.gameObject.SetActive(false);
		this.Schedule.gameObject.SetActive(false);
		this.TaskList.gameObject.SetActive(false);
		this.Stats.gameObject.SetActive(false);
		this.LoadingScreen.SetActive(false);
		this.ControlMenu.SetActive(false);
		this.SchemesMenu.SetActive(false);
		this.StudentInfo.SetActive(false);
		this.DropsMenu.SetActive(false);
		this.MainMenu.SetActive(true);
		if (!(SceneManager.GetActiveScene().name == "SchoolScene"))
		{
			this.MissionModeIcons.SetActive(false);
			UISprite uisprite = this.PhoneIcons[5];
			uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 0.5f);
			UISprite uisprite2 = this.PhoneIcons[8];
			uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 0.5f);
			UISprite uisprite3 = this.PhoneIcons[9];
			uisprite3.color = new Color(uisprite3.color.r, uisprite3.color.g, uisprite3.color.b, 0.5f);
			UISprite uisprite4 = this.PhoneIcons[11];
			uisprite4.color = new Color(uisprite4.color.r, uisprite4.color.g, uisprite4.color.b, 0.5f);
			UISprite uisprite5 = this.PhoneIcons[13];
			uisprite5.color = new Color(uisprite5.color.r, uisprite5.color.g, uisprite5.color.b, 0.5f);
			UISprite uisprite6 = this.PhoneIcons[15];
			uisprite6.color = new Color(uisprite6.color.r, uisprite6.color.g, uisprite6.color.b, 0.5f);
			UISprite uisprite7 = this.PhoneIcons[17];
			uisprite7.color = new Color(uisprite7.color.r, uisprite7.color.g, uisprite7.color.b, 0.5f);
			if (this.NewMissionModeWindow != null)
			{
				this.NewMissionModeWindow.SetActive(false);
			}
		}
		if (MissionModeGlobals.MissionMode)
		{
			UISprite uisprite8 = this.PhoneIcons[7];
			uisprite8.color = new Color(uisprite8.color.r, uisprite8.color.g, uisprite8.color.b, 0.5f);
			UISprite uisprite9 = this.PhoneIcons[9];
			uisprite9.color = new Color(uisprite9.color.r, uisprite9.color.g, uisprite9.color.b, 0.5f);
			UISprite uisprite10 = this.PhoneIcons[10];
			uisprite10.color = new Color(uisprite10.color.r, uisprite10.color.g, uisprite10.color.b, 1f);
		}
		this.UpdateSelection();
		this.CorrectingTime = false;
		if (GameGlobals.Eighties)
		{
			this.Eighties = true;
			for (int i = 1; i < 19; i++)
			{
				this.EightiesPhoneIcons[i].enabled = true;
				this.PhoneIcons[i].enabled = false;
				this.EightiesPhoneIcons[i].color = this.PhoneIcons[i].color;
			}
			this.SelectionNames[5] = "Ideas";
			UISprite uisprite11 = this.PhoneIcons[17];
			uisprite11.color = new Color(uisprite11.color.r, uisprite11.color.g, uisprite11.color.b, 0.5f);
			this.Notepad.SetActive(true);
			this.Phone.SetActive(false);
			this.Wifi.gameObject.SetActive(false);
		}
		this.QuitLabel.text = "Do you wish to return to the main menu?";
		this.YesLabel.text = "Yes";
		this.HomeButton.SetActive(false);
	}

	// Token: 0x06001A3D RID: 6717 RVA: 0x001165E0 File Offset: 0x001147E0
	private void Update()
	{
		this.Speed = Time.unscaledDeltaTime * 10f;
		if (!this.Police.FadeOut && !this.Map.Show)
		{
			if (!this.Show)
			{
				if (base.transform.localPosition.x > 1349f)
				{
					if (this.Panel.enabled)
					{
						this.Panel.enabled = false;
						base.transform.localPosition = new Vector3(1350f, 50f, 0f);
						base.transform.localScale = new Vector3(0.9133334f, 0.9133334f, 0.9133334f);
						base.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					}
				}
				else
				{
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(1350f, 50f, 0f), this.Speed);
					base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(0.9133334f, 0.9133334f, 0.9133334f), this.Speed);
					base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, Mathf.Lerp(base.transform.localEulerAngles.z, 0f, this.Speed));
				}
				if (this.CorrectingTime && Time.timeScale < 0.9f)
				{
					Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, this.Speed);
					if (Time.timeScale > 0.9f)
					{
						this.CorrectingTime = false;
						Time.timeScale = 1f;
					}
				}
				if (Input.GetButtonDown("Start"))
				{
					if (this.Eighties)
					{
						this.BlackenAllText();
					}
					if (!this.Home)
					{
						if (!this.Yandere.Shutter.Snapping && !this.Yandere.TimeSkipping && !this.Yandere.Talking && !this.Yandere.Noticed && !this.Yandere.InClass && !this.Yandere.Struggling && !this.Yandere.Won && !this.Yandere.Dismembering && !this.Yandere.Attacked && this.Yandere.CanMove && !this.Yandere.Chased && this.Yandere.Chasers == 0 && !this.Yandere.YandereVision && Time.timeScale > 0.0001f && this.Hint.transform.localPosition.x == 0.2043f && !this.Schedule.gameObject.activeInHierarchy)
						{
							this.Yandere.StopAiming();
							this.PromptParent.localScale = Vector3.zero;
							this.Yandere.YandereVision = false;
							this.Yandere.Blur.enabled = true;
							this.Yandere.YandereTimer = 0f;
							this.Yandere.Mopping = false;
							this.Panel.enabled = true;
							this.Sideways = false;
							this.Show = true;
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Accept";
							this.PromptBar.Label[1].text = "Exit";
							this.PromptBar.Label[4].text = "Choose";
							this.PromptBar.Label[5].text = "Choose";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
							UISprite uisprite = this.PhoneIcons[3];
							if (!this.Yandere.CanMove || this.Yandere.Dragging || this.Yandere.Carrying)
							{
								uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 0.5f);
							}
							else
							{
								uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 1f);
							}
							this.CheckIfSavePossible();
							this.UpdateSelection();
							return;
						}
					}
					else if (this.HomeCamera.Destination == this.HomeCamera.Destinations[0])
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[0].text = "Accept";
						this.PromptBar.Label[1].text = "Exit";
						this.PromptBar.Label[4].text = "Choose";
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = true;
						this.HomeYandere.CanMove = false;
						UISprite uisprite2 = this.PhoneIcons[3];
						uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 0.5f);
						this.Panel.enabled = true;
						this.Sideways = false;
						this.Show = true;
						return;
					}
				}
			}
			else
			{
				if (!this.EggsChecked)
				{
					float num = 99999f;
					for (int i = 0; i < this.Eggs.Length; i++)
					{
						if (this.Eggs[i] != null)
						{
							float num2 = Vector3.Distance(this.Yandere.transform.position, this.Eggs[i].position);
							if (num2 < num)
							{
								num = num2;
							}
						}
					}
					if (num < 5f)
					{
						this.Wifi.spriteName = "5Bars";
					}
					else if (num < 10f)
					{
						this.Wifi.spriteName = "4Bars";
					}
					else if (num < 15f)
					{
						this.Wifi.spriteName = "3Bars";
					}
					else if (num < 20f)
					{
						this.Wifi.spriteName = "2Bars";
					}
					else if (num < 25f)
					{
						this.Wifi.spriteName = "1Bars";
					}
					else
					{
						this.Wifi.spriteName = "0Bars";
					}
					this.EggsChecked = true;
				}
				if (!this.Home)
				{
					Time.timeScale = Mathf.Lerp(Time.timeScale, 0f, this.Speed);
					this.RPGCamera.enabled = false;
				}
				if (this.ShowMissionModeDetails)
				{
					base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), this.Speed);
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(0f, 1200f, 0f), this.Speed);
				}
				else if (this.Quitting)
				{
					base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), this.Speed);
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(0f, -1200f, 0f), this.Speed);
				}
				else if (!this.Sideways)
				{
					if (!this.NewSettings.gameObject.activeInHierarchy)
					{
						base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(0f, 50f, 0f), this.Speed);
					}
					else
					{
						base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(1320f, 0f, 0f), this.Speed);
					}
					base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(0.9133334f, 0.9133334f, 0.9133334f), this.Speed);
					base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, Mathf.Lerp(base.transform.localEulerAngles.z, 0f, this.Speed));
				}
				else
				{
					base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1.78f, 1.78f, 1.78f), this.Speed);
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(0f, 35f, 0f), this.Speed);
					base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, Mathf.Lerp(base.transform.localEulerAngles.z, 90f, this.Speed));
				}
				if (this.MainMenu.activeInHierarchy && !this.Quitting)
				{
					if (this.InputManager.TappedUp)
					{
						this.Row--;
						this.UpdateSelection();
					}
					if (this.InputManager.TappedDown)
					{
						this.Row++;
						this.UpdateSelection();
					}
					if (this.InputManager.TappedRight)
					{
						this.Column++;
						this.UpdateSelection();
					}
					if (this.InputManager.TappedLeft)
					{
						this.Column--;
						this.UpdateSelection();
					}
					if (Input.GetKeyDown("space") && this.MultiMission)
					{
						this.ShowMissionModeDetails = !this.ShowMissionModeDetails;
					}
					if (this.ShowMissionModeDetails && Input.GetButtonDown("B"))
					{
						this.ShowMissionModeDetails = false;
					}
					for (int j = 1; j < this.PhoneIcons.Length; j++)
					{
						if (this.PhoneIcons[j] != null)
						{
							Vector3 b = (this.Selected != j) ? new Vector3(1f, 1f, 1f) : new Vector3(1.5f, 1.5f, 1.5f);
							this.PhoneIcons[j].transform.localScale = Vector3.Lerp(this.PhoneIcons[j].transform.localScale, b, this.Speed);
						}
					}
					if (!this.ShowMissionModeDetails)
					{
						if (Input.GetButtonDown("A"))
						{
							this.PressedA = true;
							if (this.Eighties)
							{
								this.BlackenAllText();
							}
							if (this.PhoneIcons[this.Selected].color.a == 1f)
							{
								if (this.Selected == 1)
								{
									this.MainMenu.SetActive(false);
									this.LoadingScreen.SetActive(true);
									this.PromptBar.ClearButtons();
									this.PromptBar.Label[1].text = "Back";
									this.PromptBar.Label[4].text = "Choose";
									this.PromptBar.Label[5].text = "Choose";
									this.PromptBar.UpdateButtons();
									base.StartCoroutine(this.PhotoGallery.GetPhotos());
								}
								else if (this.Selected == 2)
								{
									this.TaskList.gameObject.SetActive(true);
									this.MainMenu.SetActive(false);
									this.Sideways = true;
									this.PromptBar.ClearButtons();
									this.PromptBar.Label[1].text = "Back";
									this.PromptBar.Label[4].text = "Choose";
									this.PromptBar.UpdateButtons();
									this.TaskList.UpdateTaskList();
									base.StartCoroutine(this.TaskList.UpdateTaskInfo());
								}
								else if (this.Selected == 3)
								{
									if (this.PhoneIcons[3].color.a == 1f && this.Yandere.CanMove && !this.Yandere.Dragging)
									{
										for (int k = 0; k < this.Yandere.ArmedAnims.Length; k++)
										{
											this.Yandere.CharacterAnimation[this.Yandere.ArmedAnims[k]].weight = 0f;
										}
										this.MainMenu.SetActive(false);
										this.PromptBar.ClearButtons();
										this.PromptBar.Label[0].text = "Begin";
										this.PromptBar.Label[1].text = "Back";
										this.PromptBar.Label[4].text = "Adjust";
										this.PromptBar.Label[5].text = "Choose";
										this.PromptBar.UpdateButtons();
										this.PassTime.gameObject.SetActive(true);
										this.PassTime.GetCurrentTime();
									}
								}
								else if (this.Selected == 4)
								{
									this.PromptBar.ClearButtons();
									this.PromptBar.Label[1].text = "Exit";
									this.PromptBar.UpdateButtons();
									this.Stats.gameObject.SetActive(true);
									this.Stats.UpdateStats();
									this.MainMenu.SetActive(false);
									this.Sideways = true;
								}
								else if (this.Selected == 5)
								{
									if (this.PhoneIcons[5].color.a == 1f)
									{
										if (!this.Eighties)
										{
											this.PromptBar.ClearButtons();
											this.PromptBar.Label[0].text = "Accept";
											this.PromptBar.Label[1].text = "Exit";
											this.PromptBar.Label[5].text = "Choose";
											this.PromptBar.UpdateButtons();
											this.FavorMenu.gameObject.SetActive(true);
											this.FavorMenu.gameObject.GetComponent<AudioSource>().Play();
											this.MainMenu.SetActive(false);
											this.Sideways = true;
										}
										else
										{
											this.PromptBar.ClearButtons();
											this.PromptBar.Label[0].text = "Confirm";
											this.PromptBar.Label[1].text = "Back";
											this.PromptBar.Label[4].text = "Choose";
											this.PromptBar.UpdateButtons();
											this.PromptBar.Show = true;
											this.IdeasMenu.gameObject.SetActive(true);
											this.MainMenu.SetActive(false);
										}
									}
								}
								else if (this.Selected == 6)
								{
									this.StudentInfoMenu.gameObject.SetActive(true);
									base.StartCoroutine(this.StudentInfoMenu.UpdatePortraits());
									this.MainMenu.SetActive(false);
									this.Sideways = true;
									this.PromptBar.ClearButtons();
									this.PromptBar.Label[0].text = "View Info";
									this.PromptBar.Label[1].text = "Back";
									this.PromptBar.UpdateButtons();
									this.PromptBar.Show = true;
								}
								else if (this.Selected == 7)
								{
									this.SaveLoadMenu.gameObject.SetActive(true);
									this.SaveLoadMenu.Header.text = "Load Data";
									this.SaveLoadMenu.Loading = true;
									this.SaveLoadMenu.Saving = false;
									this.SaveLoadMenu.Column = 1;
									this.SaveLoadMenu.Row = 1;
									this.SaveLoadMenu.UpdateHighlight();
									base.StartCoroutine(this.SaveLoadMenu.GetThumbnails());
									this.MainMenu.SetActive(false);
									this.Sideways = true;
									this.PromptBar.ClearButtons();
									this.PromptBar.Label[0].text = "Choose";
									this.PromptBar.Label[1].text = "Back";
									this.PromptBar.Label[2].text = "Debug";
									this.PromptBar.Label[4].text = "Change";
									this.PromptBar.Label[5].text = "Change";
									this.PromptBar.UpdateButtons();
									this.PromptBar.Show = true;
								}
								else if (this.Selected == 8)
								{
									this.NewSettings.gameObject.SetActive(true);
									if (this.Yandere.Blur != null)
									{
										this.Yandere.Blur.enabled = false;
									}
									this.NewSettings.NewTitleScreen.Speed = 3f;
									this.NewSettings.enabled = true;
									this.NewSettings.Cursor.alpha = 0f;
									this.NewSettings.Selection = 1;
									this.NewSettings.UpdateLabels();
									this.MainMenu.SetActive(false);
								}
								else if (this.Selected == 9)
								{
									this.SaveLoadMenu.gameObject.SetActive(true);
									this.SaveLoadMenu.Header.text = "Save Data";
									this.SaveLoadMenu.Loading = false;
									this.SaveLoadMenu.Saving = true;
									this.SaveLoadMenu.Column = 1;
									this.SaveLoadMenu.Row = 1;
									this.SaveLoadMenu.UpdateHighlight();
									base.StartCoroutine(this.SaveLoadMenu.GetThumbnails());
									this.MainMenu.SetActive(false);
									this.Sideways = true;
									this.PromptBar.ClearButtons();
									this.PromptBar.Label[0].text = "Choose";
									this.PromptBar.Label[1].text = "Back";
									this.PromptBar.Label[2].text = "Delete";
									this.PromptBar.Label[4].text = "Change";
									this.PromptBar.Label[5].text = "Change";
									this.PromptBar.UpdateButtons();
									this.PromptBar.Show = true;
								}
								else if (this.Selected == 10)
								{
									if (!MissionModeGlobals.MissionMode)
									{
										this.AudioMenu.gameObject.SetActive(true);
										this.AudioMenu.UpdateText();
										this.MainMenu.SetActive(false);
										this.PromptBar.ClearButtons();
										this.PromptBar.Label[0].text = "Play";
										this.PromptBar.Label[1].text = "Back";
										this.PromptBar.Label[4].text = "Choose";
										this.PromptBar.UpdateButtons();
										this.PromptBar.Show = true;
									}
									else
									{
										this.PhoneIcons[this.Selected].transform.localScale = new Vector3(1f, 1f, 1f);
										this.MissionMode.ChangeMusic();
									}
								}
								else if (this.Selected == 11)
								{
									this.Tutorials.gameObject.SetActive(true);
									this.MainMenu.SetActive(false);
									this.Sideways = true;
									this.PromptBar.ClearButtons();
									this.PromptBar.Label[1].text = "Back";
									this.PromptBar.Label[4].text = "Choose";
									this.PromptBar.UpdateButtons();
									this.Tutorials.UpdateTaskList();
									base.StartCoroutine(this.Tutorials.UpdateTaskInfo());
								}
								else if (this.Selected == 12)
								{
									if (this.InputDevice.Type == InputDeviceType.Gamepad)
									{
										this.Keyboard.SetActive(false);
										this.Gamepad.SetActive(true);
									}
									else
									{
										this.Keyboard.SetActive(true);
										this.Gamepad.SetActive(false);
									}
									this.ControlMenu.SetActive(false);
									this.ControlMenu.SetActive(true);
									this.MainMenu.SetActive(false);
									this.ViewingControlMenu = true;
									this.Sideways = true;
									this.PromptBar.ClearButtons();
									this.PromptBar.Label[1].text = "Back";
									this.PromptBar.UpdateButtons();
									this.PromptBar.Show = true;
								}
								else if (this.Selected == 13)
								{
									this.InventoryMenu.UpdateLabels();
									this.InventoryMenu.gameObject.SetActive(true);
									this.MainMenu.SetActive(false);
									this.PromptBar.ClearButtons();
									this.PromptBar.Label[1].text = "Back";
									this.PromptBar.UpdateButtons();
									this.PromptBar.Show = true;
								}
								else if (this.Selected == 14)
								{
									this.QuitLabel.text = "Do you wish to return to the main menu?";
									this.YesLabel.text = "Yes";
									this.PromptBar.ClearButtons();
									this.PromptBar.Show = false;
									this.ResettingDay = false;
									this.Quitting = true;
									this.HomeButton.SetActive(false);
								}
								else if (this.Selected == 15)
								{
									this.QuitLabel.text = "Do you wish to restart the day?";
									if (this.Yandere.StudentManager.MissionMode)
									{
										this.YesLabel.text = "Yes";
										this.HomeButton.SetActive(false);
									}
									else
									{
										this.YesLabel.text = "Yes, at school";
										this.HomeButton.SetActive(true);
									}
									this.PromptBar.ClearButtons();
									this.PromptBar.Show = false;
									this.ResettingDay = true;
									this.Quitting = true;
								}
								else if (this.Selected == 17)
								{
									this.ShowScheduleScreen();
								}
							}
						}
						else if (!this.PressedB)
						{
							if (Input.GetButtonDown("Start") || Input.GetButtonDown("B"))
							{
								this.ExitPhone();
							}
						}
						else if (Input.GetButtonUp("B"))
						{
							this.PressedB = false;
						}
					}
				}
				if (!this.PressedA)
				{
					if (this.PassTime.gameObject.activeInHierarchy)
					{
						if (Input.GetButtonDown("A"))
						{
							if (this.Yandere.PickUp != null)
							{
								this.Yandere.PickUp.Drop();
							}
							this.Yandere.Unequip();
							this.Yandere.Blur.enabled = false;
							this.RPGCamera.enabled = true;
							this.PassTime.gameObject.SetActive(false);
							this.MainMenu.SetActive(true);
							this.Show = false;
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[1].text = "Stop";
							this.PromptBar.UpdateButtons();
							this.Clock.TargetTime = (float)this.PassTime.TargetTime;
							this.Clock.StopTime = false;
							this.Clock.TimeSkip = true;
							Time.timeScale = 1f;
							this.Yandere.ResetYandereEffects();
							this.Yandere.Phone.SetActive(true);
						}
						else if (Input.GetButtonDown("B"))
						{
							this.MainMenu.SetActive(true);
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Accept";
							this.PromptBar.Label[1].text = "Exit";
							this.PromptBar.Label[4].text = "Choose";
							this.PromptBar.Label[5].text = "Choose";
							this.PromptBar.UpdateButtons();
							this.PassTime.gameObject.SetActive(false);
						}
					}
					if (this.ViewingControlMenu)
					{
						if (this.InputDevice.Type == InputDeviceType.Gamepad)
						{
							this.Keyboard.SetActive(false);
							this.Gamepad.SetActive(true);
						}
						else
						{
							this.Keyboard.SetActive(true);
							this.Gamepad.SetActive(false);
						}
						if (Input.GetButtonDown("B"))
						{
							this.MainMenu.SetActive(true);
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Accept";
							this.PromptBar.Label[1].text = "Exit";
							this.PromptBar.Label[4].text = "Choose";
							this.PromptBar.Label[5].text = "Choose";
							this.PromptBar.UpdateButtons();
							this.ControlMenu.SetActive(false);
							this.ViewingControlMenu = false;
							this.Sideways = false;
						}
					}
					if (this.Quitting)
					{
						if (Input.GetButtonDown("A"))
						{
							if (this.ResettingDay)
							{
								SceneManager.LoadScene("LoadingScene");
							}
							else
							{
								Debug.Log("We are now returning to the title screen. Currently, GameGlobals.Profile is: " + GameGlobals.Profile.ToString());
								SceneManager.LoadScene("NewTitleScene");
							}
						}
						else if (Input.GetButtonDown("X"))
						{
							if (this.ResettingDay && !this.MissionMode)
							{
								SceneManager.LoadScene("HomeScene");
							}
						}
						else if (Input.GetButtonDown("B"))
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Accept";
							this.PromptBar.Label[1].text = "Exit";
							this.PromptBar.Label[4].text = "Choose";
							this.PromptBar.Label[5].text = "Choose";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
							this.Quitting = false;
							if (this.BypassPhone)
							{
								base.transform.localPosition = new Vector3(1350f, 0f, 0f);
								this.ExitPhone();
							}
						}
					}
				}
				if (this.Eighties)
				{
					for (int l = 1; l < this.PhoneIcons.Length; l++)
					{
						this.EightiesPhoneIcons[l].color = this.PhoneIcons[l].color;
					}
				}
				if (Input.GetButtonUp("A"))
				{
					this.PressedA = false;
				}
			}
		}
	}

	// Token: 0x06001A3E RID: 6718 RVA: 0x00118100 File Offset: 0x00116300
	public void ShowScheduleScreen()
	{
		Debug.Log("The PauseScreenScript has been instructed to display the Schedule Screen...");
		this.Schedule.gameObject.SetActive(true);
		this.Schedule.Start();
		this.MainMenu.SetActive(false);
		this.Panel.enabled = true;
		this.Sideways = true;
		this.Show = true;
		this.PromptBar.ClearButtons();
		this.PromptBar.Label[1].text = "Back";
		this.PromptBar.Label[2].text = "View Schemes";
		this.PromptBar.Label[3].text = (this.Hint.enabled ? "Disable Hints" : "Enable Hints");
		this.PromptBar.Label[6].text = "Change Day";
		this.PromptBar.UpdateButtons();
		this.PromptBar.Show = true;
	}

	// Token: 0x06001A3F RID: 6719 RVA: 0x001181EC File Offset: 0x001163EC
	public void JumpToQuit()
	{
		if (!this.Police.FadeOut && !this.Clock.TimeSkip && !this.Yandere.Noticed)
		{
			base.transform.localPosition = new Vector3(0f, -1200f, 0f);
			this.Yandere.YandereVision = false;
			if (!this.Yandere.Talking && !this.Yandere.Dismembering)
			{
				this.RPGCamera.enabled = false;
				this.Yandere.StopAiming();
			}
			this.QuitLabel.text = "Do you wish to return to the main menu?";
			this.PromptBar.ClearButtons();
			this.PromptBar.Show = false;
			this.Yandere.Blur.enabled = true;
			this.ResettingDay = false;
			this.Panel.enabled = true;
			this.BypassPhone = true;
			this.Quitting = true;
			this.Show = true;
		}
	}

	// Token: 0x06001A40 RID: 6720 RVA: 0x001182E8 File Offset: 0x001164E8
	public void ExitPhone()
	{
		if (!this.Home)
		{
			this.PromptParent.localScale = new Vector3(1f, 1f, 1f);
			this.Yandere.Blur.enabled = false;
			this.CorrectingTime = true;
			if (!this.Yandere.Talking && !this.Yandere.Dismembering)
			{
				this.RPGCamera.enabled = true;
			}
			if (this.Yandere.Laughing)
			{
				this.Yandere.GetComponent<AudioSource>().volume = 1f;
			}
		}
		else
		{
			this.HomeYandere.CanMove = true;
		}
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
		this.BypassPhone = false;
		this.EggsChecked = false;
		this.PressedA = false;
		this.Show = false;
	}

	// Token: 0x06001A41 RID: 6721 RVA: 0x001183C0 File Offset: 0x001165C0
	private void UpdateSelection()
	{
		if (this.Row < 0)
		{
			this.Row = 5;
		}
		else if (this.Row > 5)
		{
			this.Row = 0;
		}
		if (this.Column < 1)
		{
			this.Column = 3;
		}
		else if (this.Column > 3)
		{
			this.Column = 1;
		}
		this.Selected = this.Row * 3 + this.Column;
		this.SelectionLabel.text = this.SelectionNames[this.Selected];
		if (this.AtSchool && this.Selected == 9 && this.PhoneIcons[9].color.a == 0.5f)
		{
			this.SelectionLabel.text = this.Reason;
		}
	}

	// Token: 0x06001A42 RID: 6722 RVA: 0x0011847C File Offset: 0x0011667C
	private void CheckIfSavePossible()
	{
		this.PhoneIcons[9].color = new Color(1f, 1f, 1f, 1f);
		if (this.AtSchool)
		{
			for (int i = 1; i < this.Yandere.StudentManager.Students.Length; i++)
			{
				if (this.Yandere.StudentManager.Students[i] != null && this.Yandere.StudentManager.Students[i].Alive)
				{
					if (this.Yandere.StudentManager.Students[i].Investigating || this.Yandere.StudentManager.Students[i].Alarmed || this.Yandere.StudentManager.Students[i].Fleeing || this.Yandere.StudentManager.Students[i].Wet)
					{
						this.PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
						this.Reason = "You cannot save the game while a student is investigating, alarmed, fleeing, or wet.";
					}
					if (this.Yandere.PickUp != null)
					{
						this.PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
						this.Reason = "You cannot save the game while you are holding that object.";
					}
				}
			}
		}
	}

	// Token: 0x06001A43 RID: 6723 RVA: 0x001185F4 File Offset: 0x001167F4
	public void UpdateSubtitleSize()
	{
		if (!OptionGlobals.SubtitleSize)
		{
			this.SubtitlePanel.localPosition = new Vector3(0f, 0f, 1f);
			this.SubtitlePanel.localScale = new Vector3(0.001f, 0.001f, 0.001f);
			return;
		}
		this.SubtitlePanel.localPosition = new Vector3(0f, 0.1133333f, 1f);
		this.SubtitlePanel.localScale = new Vector3(0.00133333f, 0.00133333f, 0.00133333f);
	}

	// Token: 0x06001A44 RID: 6724 RVA: 0x00118688 File Offset: 0x00116888
	public void BlackenAllText()
	{
		foreach (UILabel uilabel in base.GetComponentsInChildren<UILabel>())
		{
			uilabel.color = new Color(0f, 0f, 0f, 1f);
			uilabel.effectStyle = UILabel.Effect.None;
		}
	}

	// Token: 0x04002AC6 RID: 10950
	public StudentInfoMenuScript StudentInfoMenu;

	// Token: 0x04002AC7 RID: 10951
	public InventoryMenuScript InventoryMenu;

	// Token: 0x04002AC8 RID: 10952
	public InputManagerScript InputManager;

	// Token: 0x04002AC9 RID: 10953
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x04002ACA RID: 10954
	public SaveLoadMenuScript SaveLoadMenu;

	// Token: 0x04002ACB RID: 10955
	public HomeYandereScript HomeYandere;

	// Token: 0x04002ACC RID: 10956
	public InputDeviceScript InputDevice;

	// Token: 0x04002ACD RID: 10957
	public MissionModeScript MissionMode;

	// Token: 0x04002ACE RID: 10958
	public NewSettingsScript NewSettings;

	// Token: 0x04002ACF RID: 10959
	public HomeCameraScript HomeCamera;

	// Token: 0x04002AD0 RID: 10960
	public ServicesScript ServiceMenu;

	// Token: 0x04002AD1 RID: 10961
	public FavorMenuScript FavorMenu;

	// Token: 0x04002AD2 RID: 10962
	public AudioMenuScript AudioMenu;

	// Token: 0x04002AD3 RID: 10963
	public IdeasMenuScript IdeasMenu;

	// Token: 0x04002AD4 RID: 10964
	public PromptBarScript PromptBar;

	// Token: 0x04002AD5 RID: 10965
	public TaskListScript Tutorials;

	// Token: 0x04002AD6 RID: 10966
	public PassTimeScript PassTime;

	// Token: 0x04002AD7 RID: 10967
	public ScheduleScript Schedule;

	// Token: 0x04002AD8 RID: 10968
	public TaskListScript TaskList;

	// Token: 0x04002AD9 RID: 10969
	public SchemesScript Schemes;

	// Token: 0x04002ADA RID: 10970
	public YandereScript Yandere;

	// Token: 0x04002ADB RID: 10971
	public RPG_Camera RPGCamera;

	// Token: 0x04002ADC RID: 10972
	public PoliceScript Police;

	// Token: 0x04002ADD RID: 10973
	public ClockScript Clock;

	// Token: 0x04002ADE RID: 10974
	public StatsScript Stats;

	// Token: 0x04002ADF RID: 10975
	public HintScript Hint;

	// Token: 0x04002AE0 RID: 10976
	public MapScript Map;

	// Token: 0x04002AE1 RID: 10977
	public UILabel SelectionLabel;

	// Token: 0x04002AE2 RID: 10978
	public UILabel QuitLabel;

	// Token: 0x04002AE3 RID: 10979
	public UILabel YesLabel;

	// Token: 0x04002AE4 RID: 10980
	public UIPanel Panel;

	// Token: 0x04002AE5 RID: 10981
	public UISprite Wifi;

	// Token: 0x04002AE6 RID: 10982
	public GameObject NewMissionModeWindow;

	// Token: 0x04002AE7 RID: 10983
	public GameObject MissionModeLabel;

	// Token: 0x04002AE8 RID: 10984
	public GameObject MissionModeIcons;

	// Token: 0x04002AE9 RID: 10985
	public GameObject LoadingScreen;

	// Token: 0x04002AEA RID: 10986
	public GameObject ControlMenu;

	// Token: 0x04002AEB RID: 10987
	public GameObject SchemesMenu;

	// Token: 0x04002AEC RID: 10988
	public GameObject StudentInfo;

	// Token: 0x04002AED RID: 10989
	public GameObject HomeButton;

	// Token: 0x04002AEE RID: 10990
	public GameObject DropsMenu;

	// Token: 0x04002AEF RID: 10991
	public GameObject MainMenu;

	// Token: 0x04002AF0 RID: 10992
	public GameObject Keyboard;

	// Token: 0x04002AF1 RID: 10993
	public GameObject Gamepad;

	// Token: 0x04002AF2 RID: 10994
	public GameObject Notepad;

	// Token: 0x04002AF3 RID: 10995
	public GameObject Phone;

	// Token: 0x04002AF4 RID: 10996
	public Transform SubtitlePanel;

	// Token: 0x04002AF5 RID: 10997
	public Transform PromptParent;

	// Token: 0x04002AF6 RID: 10998
	public UITexture[] EightiesPhoneIcons;

	// Token: 0x04002AF7 RID: 10999
	public UISprite[] PhoneIcons;

	// Token: 0x04002AF8 RID: 11000
	public string[] SelectionNames;

	// Token: 0x04002AF9 RID: 11001
	public Transform[] Eggs;

	// Token: 0x04002AFA RID: 11002
	public float Speed;

	// Token: 0x04002AFB RID: 11003
	public int Prompts;

	// Token: 0x04002AFC RID: 11004
	public int Selected = 1;

	// Token: 0x04002AFD RID: 11005
	public bool ShowMissionModeDetails;

	// Token: 0x04002AFE RID: 11006
	public bool ViewingControlMenu;

	// Token: 0x04002AFF RID: 11007
	public bool CorrectingTime;

	// Token: 0x04002B00 RID: 11008
	public bool MultiMission;

	// Token: 0x04002B01 RID: 11009
	public bool ResettingDay;

	// Token: 0x04002B02 RID: 11010
	public bool BypassPhone;

	// Token: 0x04002B03 RID: 11011
	public bool EggsChecked;

	// Token: 0x04002B04 RID: 11012
	public bool AtSchool;

	// Token: 0x04002B05 RID: 11013
	public bool PressedA;

	// Token: 0x04002B06 RID: 11014
	public bool PressedB;

	// Token: 0x04002B07 RID: 11015
	public bool Quitting;

	// Token: 0x04002B08 RID: 11016
	public bool Sideways;

	// Token: 0x04002B09 RID: 11017
	public bool InEditor;

	// Token: 0x04002B0A RID: 11018
	public bool Eighties;

	// Token: 0x04002B0B RID: 11019
	public bool Home;

	// Token: 0x04002B0C RID: 11020
	public bool Show;

	// Token: 0x04002B0D RID: 11021
	public int Row = 1;

	// Token: 0x04002B0E RID: 11022
	public int Column = 2;

	// Token: 0x04002B0F RID: 11023
	public string Reason;
}
