using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000396 RID: 918
public class PauseScreenScript : MonoBehaviour
{
	// Token: 0x06001A68 RID: 6760 RVA: 0x001191E0 File Offset: 0x001173E0
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

	// Token: 0x06001A69 RID: 6761 RVA: 0x001197C8 File Offset: 0x001179C8
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
									if (!this.Yandere.StudentManager.MissionMode)
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
							if (this.ResettingDay && !this.Yandere.StudentManager.MissionMode)
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

	// Token: 0x06001A6A RID: 6762 RVA: 0x0011B2F8 File Offset: 0x001194F8
	public void ShowScheduleScreen()
	{
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

	// Token: 0x06001A6B RID: 6763 RVA: 0x0011B3DC File Offset: 0x001195DC
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

	// Token: 0x06001A6C RID: 6764 RVA: 0x0011B4D8 File Offset: 0x001196D8
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

	// Token: 0x06001A6D RID: 6765 RVA: 0x0011B5B0 File Offset: 0x001197B0
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

	// Token: 0x06001A6E RID: 6766 RVA: 0x0011B66C File Offset: 0x0011986C
	private void CheckIfSavePossible()
	{
		this.PhoneIcons[9].color = new Color(1f, 1f, 1f, 1f);
		if (this.AtSchool)
		{
			for (int i = 1; i < this.Yandere.StudentManager.Students.Length; i++)
			{
				if (this.Yandere.StudentManager.Students[i] != null && this.Yandere.StudentManager.Students[i].Alive)
				{
					if (this.Yandere.StudentManager.Students[i].Investigating || this.Yandere.StudentManager.Students[i].Alarmed || this.Yandere.StudentManager.Students[i].Fleeing || (this.Yandere.StudentManager.Students[i].Ragdoll.Zs.activeInHierarchy && this.Yandere.StudentManager.Police.EndOfDay.TranqCase.VictimID != i) || this.Yandere.StudentManager.Students[i].Wet)
					{
						this.PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
						this.Reason = "You cannot save the game while a student is investigating, alarmed, fleeing, wet, or sleeping on the ground.";
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

	// Token: 0x06001A6F RID: 6767 RVA: 0x0011B82C File Offset: 0x00119A2C
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

	// Token: 0x06001A70 RID: 6768 RVA: 0x0011B8C0 File Offset: 0x00119AC0
	public void BlackenAllText()
	{
		foreach (UILabel uilabel in base.GetComponentsInChildren<UILabel>())
		{
			uilabel.color = new Color(0f, 0f, 0f, 1f);
			uilabel.effectStyle = UILabel.Effect.None;
		}
	}

	// Token: 0x04002B5C RID: 11100
	public StudentInfoMenuScript StudentInfoMenu;

	// Token: 0x04002B5D RID: 11101
	public InventoryMenuScript InventoryMenu;

	// Token: 0x04002B5E RID: 11102
	public InputManagerScript InputManager;

	// Token: 0x04002B5F RID: 11103
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x04002B60 RID: 11104
	public SaveLoadMenuScript SaveLoadMenu;

	// Token: 0x04002B61 RID: 11105
	public HomeYandereScript HomeYandere;

	// Token: 0x04002B62 RID: 11106
	public InputDeviceScript InputDevice;

	// Token: 0x04002B63 RID: 11107
	public MissionModeScript MissionMode;

	// Token: 0x04002B64 RID: 11108
	public NewSettingsScript NewSettings;

	// Token: 0x04002B65 RID: 11109
	public HomeCameraScript HomeCamera;

	// Token: 0x04002B66 RID: 11110
	public ServicesScript ServiceMenu;

	// Token: 0x04002B67 RID: 11111
	public FavorMenuScript FavorMenu;

	// Token: 0x04002B68 RID: 11112
	public AudioMenuScript AudioMenu;

	// Token: 0x04002B69 RID: 11113
	public IdeasMenuScript IdeasMenu;

	// Token: 0x04002B6A RID: 11114
	public PromptBarScript PromptBar;

	// Token: 0x04002B6B RID: 11115
	public TaskListScript Tutorials;

	// Token: 0x04002B6C RID: 11116
	public PassTimeScript PassTime;

	// Token: 0x04002B6D RID: 11117
	public ScheduleScript Schedule;

	// Token: 0x04002B6E RID: 11118
	public TaskListScript TaskList;

	// Token: 0x04002B6F RID: 11119
	public SchemesScript Schemes;

	// Token: 0x04002B70 RID: 11120
	public YandereScript Yandere;

	// Token: 0x04002B71 RID: 11121
	public RPG_Camera RPGCamera;

	// Token: 0x04002B72 RID: 11122
	public PoliceScript Police;

	// Token: 0x04002B73 RID: 11123
	public ClockScript Clock;

	// Token: 0x04002B74 RID: 11124
	public StatsScript Stats;

	// Token: 0x04002B75 RID: 11125
	public HintScript Hint;

	// Token: 0x04002B76 RID: 11126
	public MapScript Map;

	// Token: 0x04002B77 RID: 11127
	public UILabel SelectionLabel;

	// Token: 0x04002B78 RID: 11128
	public UILabel QuitLabel;

	// Token: 0x04002B79 RID: 11129
	public UILabel YesLabel;

	// Token: 0x04002B7A RID: 11130
	public UIPanel Panel;

	// Token: 0x04002B7B RID: 11131
	public UISprite Wifi;

	// Token: 0x04002B7C RID: 11132
	public GameObject NewMissionModeWindow;

	// Token: 0x04002B7D RID: 11133
	public GameObject MissionModeLabel;

	// Token: 0x04002B7E RID: 11134
	public GameObject MissionModeIcons;

	// Token: 0x04002B7F RID: 11135
	public GameObject LoadingScreen;

	// Token: 0x04002B80 RID: 11136
	public GameObject ControlMenu;

	// Token: 0x04002B81 RID: 11137
	public GameObject SchemesMenu;

	// Token: 0x04002B82 RID: 11138
	public GameObject StudentInfo;

	// Token: 0x04002B83 RID: 11139
	public GameObject HomeButton;

	// Token: 0x04002B84 RID: 11140
	public GameObject DropsMenu;

	// Token: 0x04002B85 RID: 11141
	public GameObject MainMenu;

	// Token: 0x04002B86 RID: 11142
	public GameObject Keyboard;

	// Token: 0x04002B87 RID: 11143
	public GameObject Gamepad;

	// Token: 0x04002B88 RID: 11144
	public GameObject Notepad;

	// Token: 0x04002B89 RID: 11145
	public GameObject Phone;

	// Token: 0x04002B8A RID: 11146
	public Transform SubtitlePanel;

	// Token: 0x04002B8B RID: 11147
	public Transform PromptParent;

	// Token: 0x04002B8C RID: 11148
	public UITexture[] EightiesPhoneIcons;

	// Token: 0x04002B8D RID: 11149
	public UISprite[] PhoneIcons;

	// Token: 0x04002B8E RID: 11150
	public string[] SelectionNames;

	// Token: 0x04002B8F RID: 11151
	public Transform[] Eggs;

	// Token: 0x04002B90 RID: 11152
	public float Speed;

	// Token: 0x04002B91 RID: 11153
	public int Prompts;

	// Token: 0x04002B92 RID: 11154
	public int Selected = 1;

	// Token: 0x04002B93 RID: 11155
	public bool ShowMissionModeDetails;

	// Token: 0x04002B94 RID: 11156
	public bool ViewingControlMenu;

	// Token: 0x04002B95 RID: 11157
	public bool CorrectingTime;

	// Token: 0x04002B96 RID: 11158
	public bool MultiMission;

	// Token: 0x04002B97 RID: 11159
	public bool ResettingDay;

	// Token: 0x04002B98 RID: 11160
	public bool BypassPhone;

	// Token: 0x04002B99 RID: 11161
	public bool EggsChecked;

	// Token: 0x04002B9A RID: 11162
	public bool AtSchool;

	// Token: 0x04002B9B RID: 11163
	public bool PressedA;

	// Token: 0x04002B9C RID: 11164
	public bool PressedB;

	// Token: 0x04002B9D RID: 11165
	public bool Quitting;

	// Token: 0x04002B9E RID: 11166
	public bool Sideways;

	// Token: 0x04002B9F RID: 11167
	public bool InEditor;

	// Token: 0x04002BA0 RID: 11168
	public bool Eighties;

	// Token: 0x04002BA1 RID: 11169
	public bool Home;

	// Token: 0x04002BA2 RID: 11170
	public bool Show;

	// Token: 0x04002BA3 RID: 11171
	public int Row = 1;

	// Token: 0x04002BA4 RID: 11172
	public int Column = 2;

	// Token: 0x04002BA5 RID: 11173
	public string Reason;
}
