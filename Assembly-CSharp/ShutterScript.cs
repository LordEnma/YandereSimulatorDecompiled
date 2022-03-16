using System;
using UnityEngine;

// Token: 0x02000427 RID: 1063
public class ShutterScript : MonoBehaviour
{
	// Token: 0x170004A4 RID: 1188
	// (get) Token: 0x06001CAC RID: 7340 RVA: 0x00152B2A File Offset: 0x00150D2A
	public int OnlyPhotography
	{
		get
		{
			return 65537;
		}
	}

	// Token: 0x170004A5 RID: 1189
	// (get) Token: 0x06001CAD RID: 7341 RVA: 0x00152B31 File Offset: 0x00150D31
	public int OnlyCharacters
	{
		get
		{
			return 513;
		}
	}

	// Token: 0x170004A6 RID: 1190
	// (get) Token: 0x06001CAE RID: 7342 RVA: 0x00152B38 File Offset: 0x00150D38
	public int OnlyRagdolls
	{
		get
		{
			return 2049;
		}
	}

	// Token: 0x170004A7 RID: 1191
	// (get) Token: 0x06001CAF RID: 7343 RVA: 0x00152B3F File Offset: 0x00150D3F
	public int OnlyBlood
	{
		get
		{
			return 16385;
		}
	}

	// Token: 0x06001CB0 RID: 7344 RVA: 0x00152B48 File Offset: 0x00150D48
	private void Start()
	{
		if (MissionModeGlobals.MissionMode)
		{
			this.MissionMode = true;
		}
		this.ErrorWindow.transform.localScale = Vector3.zero;
		this.CameraButtons.SetActive(false);
		this.PhotoIcons.SetActive(false);
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
		this.OriginalPosition = this.PhotoIcons.transform.localPosition;
	}

	// Token: 0x06001CB1 RID: 7345 RVA: 0x00152BEC File Offset: 0x00150DEC
	private void Update()
	{
		bool selfie = this.Yandere.Selfie;
		if (this.Snapping)
		{
			if (this.Yandere.Noticed)
			{
				this.ResumeGameplay();
				this.Yandere.StopAiming();
			}
			else if (this.Close)
			{
				this.currentPercent += 60f * Time.unscaledDeltaTime;
				while (this.currentPercent >= 1f)
				{
					this.Frame = Mathf.Min(this.Frame + 1, 8);
					this.currentPercent -= 1f;
				}
				this.Sprite.spriteName = "Shutter" + this.Frame.ToString();
				if (this.Frame == 8)
				{
					this.StudentManager.GhostChan.gameObject.SetActive(true);
					this.PhotoDescription.SetActive(false);
					this.PhotoDescLabel.text = "";
					this.StudentManager.GhostChan.Look();
					this.CheckPhoto();
					if (this.PhotoDescLabel.text == "")
					{
						this.PhotoDescLabel.text = "Cannot determine subject of photo. Try again.";
					}
					this.PhotoDescription.SetActive(true);
					this.SmartphoneCamera.targetTexture = null;
					this.Yandere.PhonePromptBar.Show = false;
					this.NotificationManager.SetActive(false);
					this.HeartbeatCamera.SetActive(false);
					this.PhotoIcons.transform.localPosition = this.OriginalPosition;
					this.Yandere.SelfieGuide.SetActive(false);
					this.MainCamera.enabled = false;
					this.PhotoIcons.SetActive(true);
					this.SubPanel.SetActive(false);
					this.Panel.SetActive(false);
					this.Close = false;
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Save";
					this.PromptBar.Label[1].text = "Delete";
					if (!this.Yandere.RivalPhone)
					{
						this.PromptBar.Label[2].text = "Send";
					}
					else if (this.PantiesX.activeInHierarchy)
					{
						this.PromptBar.Label[0].text = "";
					}
					if (this.StudentManager.Eighties)
					{
						this.PromptBar.Label[2].text = "";
					}
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = true;
					Time.timeScale = 0.0001f;
				}
			}
			else
			{
				this.currentPercent += 60f * Time.unscaledDeltaTime;
				while (this.currentPercent >= 1f)
				{
					this.Frame = Mathf.Max(this.Frame - 1, 1);
					this.currentPercent -= 1f;
				}
				this.Sprite.spriteName = "Shutter" + this.Frame.ToString();
				if (this.Frame == 1)
				{
					this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
					this.Snapping = false;
				}
			}
		}
		else if (this.Yandere.Aiming)
		{
			this.TargetStudent = 0;
			this.Timer += Time.deltaTime;
			if (this.Timer > 0.5f)
			{
				Vector3 direction;
				if (!this.Yandere.Selfie)
				{
					direction = this.SmartphoneCamera.transform.TransformDirection(Vector3.forward);
				}
				else
				{
					direction = this.SelfieRayParent.TransformDirection(Vector3.forward);
				}
				if (Physics.Raycast(this.SmartphoneCamera.transform.position, direction, out this.hit, float.PositiveInfinity, this.OnlyPhotography))
				{
					if (this.hit.collider.gameObject.name == "Face")
					{
						GameObject gameObject = this.hit.collider.gameObject.transform.root.gameObject;
						this.FaceStudent = gameObject.GetComponent<StudentScript>();
						if (this.FaceStudent != null)
						{
							this.TargetStudent = this.FaceStudent.StudentID;
							if (this.TargetStudent > 1)
							{
								this.ReactionDistance = 1.66666f;
							}
							else
							{
								this.ReactionDistance = this.FaceStudent.VisionDistance;
							}
							bool enabled = this.FaceStudent.ShoeRemoval.enabled;
							if (!this.FaceStudent.Alarmed && !this.FaceStudent.Dying && !this.FaceStudent.Distracted && !this.FaceStudent.InEvent && !this.FaceStudent.Wet && this.FaceStudent.Schoolwear > 0 && !this.FaceStudent.Fleeing && !this.FaceStudent.Following && !enabled && !this.FaceStudent.HoldingHands && this.FaceStudent.Actions[this.FaceStudent.Phase] != StudentActionType.Mourn && !this.FaceStudent.Guarding && !this.FaceStudent.Confessing && !this.FaceStudent.DiscCheck && !this.FaceStudent.TurnOffRadio && !this.FaceStudent.Investigating && !this.FaceStudent.Distracting && !this.FaceStudent.WitnessedLimb && !this.FaceStudent.WitnessedWeapon && !this.FaceStudent.WitnessedBloodPool && !this.FaceStudent.WitnessedBloodyWeapon && !this.FaceStudent.SentHome && !this.FaceStudent.EatingSnack && !this.FaceStudent.Slave && !this.FaceStudent.FragileSlave && Vector3.Distance(this.Yandere.transform.position, gameObject.transform.position) < this.ReactionDistance && this.FaceStudent.CanSeeObject(this.Yandere.gameObject, this.Yandere.transform.position + Vector3.up))
							{
								if (this.MissionMode)
								{
									this.PenaltyTimer += Time.deltaTime;
									if (this.PenaltyTimer > 1f)
									{
										this.FaceStudent.Reputation.PendingRep -= -10f;
										this.PenaltyTimer = 0f;
									}
								}
								if (!this.FaceStudent.CameraReacting)
								{
									if (this.FaceStudent.enabled && !this.FaceStudent.Stop)
									{
										if ((this.FaceStudent.DistanceToDestination < 5f && this.FaceStudent.Actions[this.FaceStudent.Phase] == StudentActionType.Graffiti) || (this.FaceStudent.DistanceToDestination < 5f && this.FaceStudent.Actions[this.FaceStudent.Phase] == StudentActionType.Bully))
										{
											this.FaceStudent.PhotoPatience = 0f;
											this.FaceStudent.KilledMood = true;
											this.FaceStudent.Ignoring = true;
											this.PenaltyTimer = 1f;
											this.Penalize();
										}
										else if (this.FaceStudent.PhotoPatience > 0f)
										{
											if (this.FaceStudent.StudentID > 1)
											{
												if ((this.Yandere.Bloodiness > 0f && !this.Yandere.Paint) || (double)this.Yandere.Sanity < 33.33333)
												{
													this.FaceStudent.Alarm += 200f;
												}
												else
												{
													this.FaceStudent.CameraReact();
												}
											}
											else
											{
												this.FaceStudent.Alarm += Time.deltaTime * (100f / this.FaceStudent.DistanceToPlayer) * this.FaceStudent.Paranoia * this.FaceStudent.Perception * this.FaceStudent.DistanceToPlayer * 2f;
												this.FaceStudent.YandereVisible = true;
											}
										}
										else
										{
											this.Penalize();
										}
									}
								}
								else
								{
									this.FaceStudent.PhotoPatience = Mathf.MoveTowards(this.FaceStudent.PhotoPatience, 0f, Time.deltaTime);
									if (this.FaceStudent.PhotoPatience > 0f)
									{
										this.FaceStudent.CameraPoseTimer = 1f;
										if (this.MissionMode)
										{
											this.FaceStudent.PhotoPatience = 0f;
										}
									}
								}
							}
						}
					}
					else if (this.hit.collider.gameObject.name == "Panties" || this.hit.collider.gameObject.name == "Skirt")
					{
						GameObject gameObject2 = this.hit.collider.gameObject.transform.root.gameObject;
						if (Physics.Raycast(this.SmartphoneCamera.transform.position, direction, out this.hit, float.PositiveInfinity, this.OnlyCharacters))
						{
							if (Vector3.Distance(this.Yandere.transform.position, gameObject2.transform.position) < 5f)
							{
								if (this.hit.collider.gameObject == gameObject2)
								{
									if (!this.Yandere.Lewd)
									{
										this.Yandere.NotificationManager.DisplayNotification(NotificationType.Lewd);
									}
									this.Yandere.Lewd = true;
								}
								else
								{
									this.Yandere.Lewd = false;
								}
							}
							else
							{
								this.Yandere.Lewd = false;
							}
						}
					}
					else
					{
						this.Yandere.Lewd = false;
					}
				}
				else
				{
					this.Yandere.Lewd = false;
				}
			}
		}
		else
		{
			this.Timer = 0f;
		}
		if (this.TookPhoto)
		{
			this.ResumeGameplay();
		}
		if (!this.DisplayError)
		{
			if (this.PhotoIcons.activeInHierarchy && !this.Snapping && !this.TextMessages.gameObject.activeInHierarchy)
			{
				Time.timeScale = 0.0001f;
				if (Input.GetButtonDown("A"))
				{
					if (!this.Yandere.RivalPhone)
					{
						bool flag = !this.BullyX.activeInHierarchy;
						bool flag2 = !this.SenpaiX.activeInHierarchy;
						this.PromptBar.transform.localPosition = new Vector3(this.PromptBar.transform.localPosition.x, -627f, this.PromptBar.transform.localPosition.z);
						this.PromptBar.ClearButtons();
						this.PromptBar.Show = false;
						this.PhotoIcons.SetActive(false);
						this.ID = 0;
						this.FreeSpace = false;
						while (this.ID < 26)
						{
							this.ID++;
							if (!PlayerGlobals.GetPhoto(this.ID))
							{
								this.FreeSpace = true;
								this.Slot = this.ID;
								this.ID = 26;
							}
						}
						if (this.FreeSpace)
						{
							if (this.StudentManager.Eighties)
							{
								this.Yandere.HandCamera.gameObject.SetActive(true);
							}
							ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/Photographs/Photo_" + this.Slot.ToString() + ".png");
							this.TookPhoto = true;
							Debug.Log("Setting Photo " + this.Slot.ToString() + " to ''true''.");
							PlayerGlobals.SetPhoto(this.Slot, true);
							if (flag)
							{
								Debug.Log("Saving a bully photo!");
								int studentID = this.BullyPhotoCollider.transform.parent.gameObject.GetComponent<StudentScript>().StudentID;
								if (this.StudentManager.Students[studentID].Club != ClubType.Bully)
								{
									PlayerGlobals.SetBullyPhoto(this.Slot, studentID);
								}
								else
								{
									PlayerGlobals.SetBullyPhoto(this.Slot, this.StudentManager.Students[studentID].DistractionTarget.StudentID);
								}
							}
							if (flag2)
							{
								PlayerGlobals.SetSenpaiPhoto(this.Slot, true);
								PlayerGlobals.SenpaiShots++;
								this.Yandere.Inventory.SenpaiShots++;
							}
							if (this.AirGuitarShot)
							{
								TaskGlobals.SetGuitarPhoto(this.Slot, true);
								this.TaskManager.UpdateTaskStatus();
							}
							if (this.KittenShot)
							{
								TaskGlobals.SetKittenPhoto(this.Slot, true);
								this.TaskManager.UpdateTaskStatus();
							}
							if (this.HorudaShot)
							{
								TaskGlobals.SetHorudaPhoto(this.Slot, true);
								this.TaskManager.UpdateTaskStatus();
							}
							if (this.OsanaShot && DateGlobals.Weekday == DayOfWeek.Thursday)
							{
								SchemeGlobals.SetSchemeStage(4, 7);
								this.Yandere.PauseScreen.Schemes.UpdateInstructions();
							}
						}
						else
						{
							this.DisplayError = true;
						}
					}
					else if (!this.PantiesX.activeInHierarchy)
					{
						if (SchemeGlobals.GetSchemeStage(1) == 5)
						{
							SchemeGlobals.SetSchemeStage(1, 6);
							this.Schemes.UpdateInstructions();
						}
						this.StudentManager.CommunalLocker.RivalPhone.LewdPhotos = true;
						this.ResumeGameplay();
					}
				}
				if (!this.Yandere.RivalPhone && Input.GetButtonDown("X"))
				{
					bool flag3 = false;
					if (this.StudentManager.Eighties && this.InfoX.activeInHierarchy)
					{
						flag3 = true;
					}
					if (!flag3)
					{
						this.Panel.SetActive(true);
						this.MainMenu.SetActive(false);
						this.PauseScreen.Show = true;
						this.PauseScreen.Panel.enabled = true;
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[1].text = "Exit";
						if (!this.InfoX.activeInHierarchy)
						{
							this.PromptBar.Label[3].text = "Interests";
						}
						else
						{
							this.PromptBar.Label[3].text = "";
						}
						this.PromptBar.UpdateButtons();
						if (!this.InfoX.activeInHierarchy)
						{
							this.PauseScreen.Sideways = true;
							if (!StudentGlobals.GetStudentPhotographed(this.Student.StudentID))
							{
								this.Yandere.Inventory.PantyShots++;
							}
							StudentGlobals.SetStudentPhotographed(this.Student.StudentID, true);
							this.ID = 0;
							while (this.ID < this.Student.Outlines.Length)
							{
								if (this.Student.Outlines[this.ID] != null)
								{
									this.Student.Outlines[this.ID].enabled = true;
								}
								this.ID++;
							}
							this.StudentInfo.UpdateInfo(this.Student.StudentID);
							this.StudentInfo.gameObject.SetActive(true);
							this.PhotoIcons.transform.localPosition = new Vector3(0f, 1000f, 0f);
						}
						else if (!this.TextMessages.gameObject.activeInHierarchy)
						{
							this.PauseScreen.Sideways = false;
							this.TextMessages.gameObject.SetActive(true);
							this.SpawnMessage();
						}
					}
				}
				if (Input.GetButtonDown("B"))
				{
					this.ResumeGameplay();
					return;
				}
			}
			else if (this.PhotoIcons.activeInHierarchy && Input.GetButtonDown("B"))
			{
				this.ResumeGameplay();
				if (!this.Yandere.Aiming)
				{
					this.Yandere.StopAiming();
					this.Yandere.CanMove = false;
					return;
				}
			}
		}
		else
		{
			float t = Time.unscaledDeltaTime * 10f;
			this.ErrorWindow.transform.localScale = Vector3.Lerp(this.ErrorWindow.transform.localScale, new Vector3(1f, 1f, 1f), t);
			if (Input.GetButtonDown("A"))
			{
				this.ResumeGameplay();
			}
		}
	}

	// Token: 0x06001CB2 RID: 7346 RVA: 0x00153C70 File Offset: 0x00151E70
	public void Snap()
	{
		this.ErrorWindow.transform.localScale = Vector3.zero;
		if (!this.StudentManager.Eighties)
		{
			this.Yandere.HandCamera.gameObject.SetActive(false);
		}
		else
		{
			this.SmartphoneCamera.transform.parent = this.Yandere.HandCamera.transform;
			this.SmartphoneCamera.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			this.SmartphoneCamera.transform.localPosition = new Vector3(0f, 0f, 0f);
			this.StudentManager.ClubManager.Viewfinder.SetActive(false);
		}
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 1f);
		this.MyAudio.Play();
		this.Snapping = true;
		this.Close = true;
		this.Frame = 0;
	}

	// Token: 0x06001CB3 RID: 7347 RVA: 0x00153D9C File Offset: 0x00151F9C
	public void CheckPhoto()
	{
		Debug.Log("We are now checking what Yandere-chan took a picture of.");
		this.InfoX.SetActive(true);
		this.BullyX.SetActive(true);
		this.SenpaiX.SetActive(true);
		this.PantiesX.SetActive(true);
		this.ViolenceX.SetActive(true);
		this.AirGuitarShot = false;
		this.PlushieShot = false;
		this.BountyShot = false;
		this.HorudaShot = false;
		this.KittenShot = false;
		this.OsanaShot = false;
		this.Nemesis = false;
		this.NotFace = false;
		this.Skirt = false;
		Transform transform;
		if (this.Yandere.Aiming)
		{
			transform = this.SmartphoneCamera.transform;
		}
		else
		{
			transform = this.Palm;
		}
		Vector3 direction;
		if (!this.Yandere.Selfie)
		{
			direction = transform.TransformDirection(Vector3.forward);
		}
		else
		{
			direction = this.SelfieRayParent.TransformDirection(Vector3.forward);
		}
		this.StudentManager.UpdatePanties(true);
		this.StudentManager.UpdateSkirts(true);
		if (Physics.Raycast(transform.position, direction, out this.hit, float.PositiveInfinity, this.OnlyPhotography))
		{
			Debug.Log("The camera's raycast collided with something named ''" + this.hit.collider.gameObject.name + "''");
			if (this.hit.collider.gameObject.name == "Panties")
			{
				this.Student = this.hit.collider.gameObject.transform.root.gameObject.GetComponent<StudentScript>();
				this.PhotoDescLabel.text = "Photo of: " + this.Student.Name + "'s Panties";
				this.PantiesX.SetActive(false);
				if (!this.Yandere.Aiming)
				{
					this.Yandere.ResetYandereEffects();
					this.PhotoIcons.SetActive(true);
					this.InfoX.SetActive(true);
					Time.timeScale = 0f;
					this.Panel.SetActive(true);
					this.MainMenu.SetActive(false);
					this.PauseScreen.Show = true;
					this.PauseScreen.Panel.enabled = true;
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[1].text = "Exit";
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = true;
					this.PauseScreen.Sideways = false;
					this.TextMessages.gameObject.SetActive(true);
					this.SpawnMessage();
				}
			}
			else if (this.hit.collider.gameObject.name == "Face")
			{
				if (this.hit.collider.gameObject.tag == "Nemesis")
				{
					this.PhotoDescLabel.text = "Photo of: Nemesis";
					this.Nemesis = true;
					this.NemesisShots++;
				}
				else if (this.hit.collider.gameObject.tag == "Disguise")
				{
					this.PhotoDescLabel.text = "Photo of: ?????";
					this.Disguise = true;
				}
				else
				{
					this.Student = this.hit.collider.gameObject.transform.root.gameObject.GetComponent<StudentScript>();
					if (this.Student.StudentID == 1)
					{
						this.PhotoDescLabel.text = "Photo of: Senpai";
						this.SenpaiX.SetActive(false);
					}
					else
					{
						this.PhotoDescLabel.text = "Photo of: " + this.Student.Name;
						this.InfoX.SetActive(false);
					}
				}
			}
			else if (this.hit.collider.gameObject.name == "NotFace")
			{
				this.PhotoDescLabel.text = "Photo of: Blocked Face";
				this.NotFace = true;
			}
			else if (this.hit.collider.gameObject.name == "Skirt")
			{
				this.PhotoDescLabel.text = "Photo of: Skirt";
				this.Skirt = true;
			}
			if (this.hit.collider.transform.root.gameObject.name == "Student_51 (Miyuji Shan)" && this.StudentManager.Students[51].AirGuitar.isPlaying)
			{
				this.AirGuitarShot = true;
				this.PhotoDescription.SetActive(true);
				this.PhotoDescLabel.text = "Photo of: Miyuji's True Nature?";
			}
			if (this.hit.collider.gameObject.name == "Kitten")
			{
				this.KittenShot = true;
				this.PhotoDescription.SetActive(true);
				this.PhotoDescLabel.text = "Photo of: Kitten";
				if (!ConversationGlobals.GetTopicDiscovered(15))
				{
					ConversationGlobals.SetTopicDiscovered(15, true);
					this.Yandere.NotificationManager.TopicName = "Cats";
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				}
			}
			if (this.hit.collider.gameObject.tag == "Horuda")
			{
				this.HorudaShot = true;
				this.PhotoDescription.SetActive(true);
				this.PhotoDescLabel.text = "Photo of: Horuda's Hiding Spot";
			}
			if (this.hit.collider.gameObject.name == "Bounty")
			{
				this.BountyShot = true;
				this.PhotoDescription.SetActive(true);
				if (this.StudentManager.Clock.Day == 1)
				{
					this.PhotoDescLabel.text = "Photo of: Ryuto Gaming At School";
				}
				else if (this.StudentManager.Clock.Day == 2)
				{
					this.PhotoDescLabel.text = "Photo of: Otohiko Falling Down";
				}
				else if (this.StudentManager.Clock.Day == 3)
				{
					this.PhotoDescLabel.text = "Photo of: Fureddo Goofing Off";
				}
				else if (this.StudentManager.Clock.Day == 4)
				{
					this.PhotoDescLabel.text = "Photo of: Umeji Sulking In Defeat";
				}
				else if (this.StudentManager.Clock.Day == 5)
				{
					this.PhotoDescLabel.text = "Photo of: Kashiko Ignoring Duties";
				}
			}
			if (this.hit.collider.gameObject.tag == "Bully")
			{
				this.PhotoDescLabel.text = "Photo of: Student Speaking With Bully";
				this.BullyPhotoCollider = this.hit.collider.gameObject;
				this.BullyX.SetActive(false);
			}
			if (this.hit.collider.gameObject.tag == "RivalEvidence")
			{
				this.OsanaShot = true;
				this.PhotoDescription.SetActive(true);
				this.PhotoDescLabel.text = "Photo of: Osana Vandalizing School Property";
			}
			if (this.hit.collider.gameObject.transform.parent != null && this.hit.collider.gameObject.transform.parent.name == "PlushieShelf")
			{
				this.PlushieShot = true;
				this.PlushieName = this.hit.collider.gameObject.name;
				this.PhotoDescription.SetActive(true);
				this.PhotoDescLabel.text = "Photo of: A cute plushie doll";
			}
		}
		if (Physics.Raycast(this.SmartphoneCamera.transform.position, direction, out this.hit, float.PositiveInfinity, this.OnlyRagdolls) && this.hit.collider.gameObject.layer == 11)
		{
			this.PhotoDescLabel.text = "Photo of: Corpse";
			this.ViolenceX.SetActive(false);
		}
		if (Physics.Raycast(this.SmartphoneCamera.transform.position, this.SmartphoneCamera.transform.TransformDirection(Vector3.forward), out this.hit, float.PositiveInfinity, this.OnlyBlood) && this.hit.collider.gameObject.layer == 14)
		{
			this.PhotoDescLabel.text = "Photo of: Blood";
			this.ViolenceX.SetActive(false);
		}
		this.StudentManager.UpdateSkirts(false);
		if (!this.Yandere.Aiming)
		{
			if (this.NewMessage == null)
			{
				this.Yandere.NotificationManager.CustomText = "You missed.";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			this.StudentManager.UpdatePanties(false);
		}
	}

	// Token: 0x06001CB4 RID: 7348 RVA: 0x0015463C File Offset: 0x0015283C
	public void SpawnMessage()
	{
		if (this.NewMessage != null)
		{
			UnityEngine.Object.Destroy(this.NewMessage);
		}
		this.NewMessage = UnityEngine.Object.Instantiate<GameObject>(this.Message);
		this.NewMessage.transform.parent = this.TextMessages;
		this.NewMessage.transform.localPosition = new Vector3(-225f, -275f, 0f);
		this.NewMessage.transform.localEulerAngles = Vector3.zero;
		this.NewMessage.transform.localScale = new Vector3(1f, 1f, 1f);
		bool flag = false;
		if (this.hit.collider != null && this.hit.collider.gameObject.name == "Kitten")
		{
			flag = true;
		}
		string text = string.Empty;
		int num;
		if (this.BountyShot)
		{
			if (!this.BountyComplete)
			{
				text = "Bounty complete. You've earned 25 Info Points.";
				num = 2;
				this.Yandere.Inventory.PantyShots += 25;
				this.BountyComplete = true;
			}
			else
			{
				text = "You've already completed this bounty.";
				num = 2;
			}
		}
		else if (flag)
		{
			text = "Why are you showing me this? I don't care.";
			num = 2;
		}
		else if (!this.InfoX.activeInHierarchy)
		{
			text = "I recognize this person. Here's some information about them.";
			num = 3;
		}
		else if (!this.PantiesX.activeInHierarchy)
		{
			if (this.Student != null)
			{
				if (!this.StudentManager.PantyShotTaken[this.Student.StudentID])
				{
					this.StudentManager.PantyShotTaken[this.Student.StudentID] = true;
					if (this.Student.Nemesis)
					{
						text = "Hey, wait a minute...I recognize those panties! This person is extremely dangerous! Avoid her at all costs!";
					}
					else if (this.Student.Club == ClubType.Bully || this.Student.Club == ClubType.Council || this.Student.Club == ClubType.Nurse || this.Student.StudentID == 20)
					{
						text = "A high value target! " + this.Student.Name + "'s panties were in high demand. You've earned 10 Info Points.";
						this.Yandere.Inventory.PantyShots += 10;
					}
					else
					{
						text = "Excellent! Now I have a picture of " + this.Student.Name + "'s panties. You've earned 5 Info Points.";
						this.Yandere.Inventory.PantyShots += 5;
					}
					num = 5;
				}
				else if (!this.Student.Nemesis)
				{
					text = "I already have a picture of " + this.Student.Name + "'s panties. I don't need this shot.";
					num = 4;
				}
				else
				{
					text = "You are in danger. Avoid her.";
					num = 2;
				}
			}
			else
			{
				text = "How peculiar. I don't recognize these panties.";
				num = 2;
			}
		}
		else if (!this.ViolenceX.activeInHierarchy)
		{
			text = "Good work, but don't send me this stuff. I have no use for it.";
			num = 3;
		}
		else if (!this.SenpaiX.activeInHierarchy)
		{
			if (PlayerGlobals.SenpaiShotsTexted == 0)
			{
				text = "I don't need any pictures of your Senpai.";
				num = 2;
			}
			else if (PlayerGlobals.SenpaiShotsTexted == 1)
			{
				text = "I know how you feel about this person, but I have no use for these pictures.";
				num = 4;
			}
			else if (PlayerGlobals.SenpaiShotsTexted == 2)
			{
				text = "Okay, I get it, you love your Senpai, and you love taking pictures of your Senpai. I still don't need these shots.";
				num = 5;
			}
			else if (PlayerGlobals.SenpaiShotsTexted == 3)
			{
				text = "You're spamming my inbox. Cut it out.";
				num = 2;
			}
			else
			{
				text = "...";
				num = 1;
			}
			PlayerGlobals.SenpaiShotsTexted++;
		}
		else if (!this.BullyX.activeInHierarchy)
		{
			text = "I have no interest in this.";
			num = 2;
		}
		else if (this.NotFace)
		{
			text = "Do you want me to identify this person? Please get me a clear shot of their face.";
			num = 4;
		}
		else if (this.Skirt)
		{
			text = "Is this supposed to be a panty shot? My clients are picky. The panties need to be in the EXACT center of the shot.";
			num = 5;
		}
		else if (this.Nemesis)
		{
			if (this.NemesisShots == 1)
			{
				text = "Strange. I have no profile for this student.";
				num = 2;
			}
			else if (this.NemesisShots == 2)
			{
				text = "...wait. I think I know who she is.";
				num = 2;
			}
			else if (this.NemesisShots == 3)
			{
				text = "You are in danger. Avoid her.";
				num = 2;
			}
			else if (this.NemesisShots == 4)
			{
				text = "Do not engage.";
				num = 1;
			}
			else
			{
				text = "I repeat: Do. Not. Engage.";
				num = 2;
			}
		}
		else if (this.Disguise)
		{
			text = "Something about that student seems...wrong.";
			num = 2;
		}
		else if (this.PlushieShot)
		{
			text = "Hey, that's " + this.PlushieName + "!";
			num = 4;
		}
		else
		{
			text = "I don't get it. What are you trying to show me? Make sure the subject is in the EXACT center of the photo.";
			num = 5;
		}
		this.NewMessage.GetComponent<UISprite>().height = 36 + 36 * num;
		this.NewMessage.GetComponent<TextMessageScript>().Label.text = text;
	}

	// Token: 0x06001CB5 RID: 7349 RVA: 0x00154A90 File Offset: 0x00152C90
	public void ResumeGameplay()
	{
		this.ErrorWindow.transform.localScale = Vector3.zero;
		this.SmartphoneCamera.targetTexture = this.SmartphoneScreen;
		this.StudentManager.GhostChan.gameObject.SetActive(false);
		this.Yandere.HandCamera.gameObject.SetActive(true);
		this.NotificationManager.SetActive(true);
		this.PauseScreen.CorrectingTime = true;
		this.HeartbeatCamera.SetActive(true);
		this.TextMessages.gameObject.SetActive(false);
		this.StudentInfo.gameObject.SetActive(false);
		this.MainCamera.enabled = true;
		this.PhotoIcons.SetActive(false);
		this.PauseScreen.Show = false;
		this.SubPanel.SetActive(true);
		this.MainMenu.SetActive(true);
		this.Yandere.CanMove = true;
		this.DisplayError = false;
		this.Panel.SetActive(true);
		Time.timeScale = 1f;
		this.TakePhoto = false;
		this.TookPhoto = false;
		this.AirGuitarShot = false;
		this.PlushieShot = false;
		this.BountyShot = false;
		this.HorudaShot = false;
		this.KittenShot = false;
		this.OsanaShot = false;
		this.Nemesis = false;
		this.NotFace = false;
		this.Skirt = false;
		if (!this.StudentManager.Eighties)
		{
			this.Yandere.PhonePromptBar.Panel.enabled = true;
			this.Yandere.PhonePromptBar.Show = true;
		}
		else if (this.Yandere.Club == ClubType.Photography)
		{
			this.StudentManager.ClubManager.Viewfinder.SetActive(true);
		}
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
		if (this.NewMessage != null)
		{
			UnityEngine.Object.Destroy(this.NewMessage);
		}
		if (!this.Yandere.CameraEffects.OneCamera)
		{
			if (!OptionGlobals.Fog)
			{
				this.Yandere.MainCamera.clearFlags = CameraClearFlags.Skybox;
			}
			else
			{
				this.Yandere.MainCamera.clearFlags = CameraClearFlags.Color;
			}
			this.Yandere.MainCamera.farClipPlane = (float)OptionGlobals.DrawDistance;
		}
		this.Yandere.UpdateSelfieStatus();
		this.Yandere.RPGCamera.enabled = true;
		this.Yandere.RPGCamera.mouseX = this.Yandere.RPGCamera.mouseXSmooth;
		this.Yandere.RPGCamera.mouseY = this.Yandere.RPGCamera.mouseYSmooth;
		this.Yandere.RPGCamera.mouseSmoothingFactor = 0f;
	}

	// Token: 0x06001CB6 RID: 7350 RVA: 0x00154D38 File Offset: 0x00152F38
	public void Penalize()
	{
		this.PenaltyTimer += Time.deltaTime;
		if (this.PenaltyTimer >= 1f)
		{
			this.Subtitle.UpdateLabel(SubtitleType.PhotoAnnoyance, 0, 3f);
			if (this.Yandere.Mask == null)
			{
				if (this.MissionMode)
				{
					if (this.FaceStudent.TimesAnnoyed < 5)
					{
						this.FaceStudent.TimesAnnoyed++;
					}
					else
					{
						this.FaceStudent.RepDeduction = 0f;
						this.FaceStudent.RepLoss = 20f;
						this.FaceStudent.Reputation.PendingRep -= this.FaceStudent.RepLoss * this.FaceStudent.Paranoia;
						this.FaceStudent.PendingRep -= this.FaceStudent.RepLoss * this.FaceStudent.Paranoia;
					}
				}
				else
				{
					this.FaceStudent.RepDeduction = 0f;
					this.FaceStudent.RepLoss = 1f;
					this.FaceStudent.CalculateReputationPenalty();
					if (this.FaceStudent.RepDeduction >= 0f)
					{
						this.FaceStudent.RepLoss -= this.FaceStudent.RepDeduction;
					}
					this.FaceStudent.Reputation.PendingRep -= this.FaceStudent.RepLoss * this.FaceStudent.Paranoia;
					this.FaceStudent.PendingRep -= this.FaceStudent.RepLoss * this.FaceStudent.Paranoia;
					this.FaceStudent.PersonalSpaceTimer = 0f;
				}
			}
			this.PenaltyTimer = 0f;
		}
	}

	// Token: 0x04003362 RID: 13154
	public StudentManagerScript StudentManager;

	// Token: 0x04003363 RID: 13155
	public TaskManagerScript TaskManager;

	// Token: 0x04003364 RID: 13156
	public PauseScreenScript PauseScreen;

	// Token: 0x04003365 RID: 13157
	public StudentInfoScript StudentInfo;

	// Token: 0x04003366 RID: 13158
	public PromptBarScript PromptBar;

	// Token: 0x04003367 RID: 13159
	public SubtitleScript Subtitle;

	// Token: 0x04003368 RID: 13160
	public SchemesScript Schemes;

	// Token: 0x04003369 RID: 13161
	public StudentScript Student;

	// Token: 0x0400336A RID: 13162
	public YandereScript Yandere;

	// Token: 0x0400336B RID: 13163
	public StudentScript FaceStudent;

	// Token: 0x0400336C RID: 13164
	public RenderTexture SmartphoneScreen;

	// Token: 0x0400336D RID: 13165
	public Camera SmartphoneCamera;

	// Token: 0x0400336E RID: 13166
	public Camera MainCamera;

	// Token: 0x0400336F RID: 13167
	public Transform SelfieRayParent;

	// Token: 0x04003370 RID: 13168
	public Transform TextMessages;

	// Token: 0x04003371 RID: 13169
	public Transform ErrorWindow;

	// Token: 0x04003372 RID: 13170
	public Transform Palm;

	// Token: 0x04003373 RID: 13171
	public UILabel PhotoDescLabel;

	// Token: 0x04003374 RID: 13172
	public UISprite Sprite;

	// Token: 0x04003375 RID: 13173
	public GameObject NotificationManager;

	// Token: 0x04003376 RID: 13174
	public GameObject BullyPhotoCollider;

	// Token: 0x04003377 RID: 13175
	public GameObject PhotoDescription;

	// Token: 0x04003378 RID: 13176
	public GameObject HeartbeatCamera;

	// Token: 0x04003379 RID: 13177
	public GameObject EightiesCamera;

	// Token: 0x0400337A RID: 13178
	public GameObject CameraButtons;

	// Token: 0x0400337B RID: 13179
	public GameObject NewMessage;

	// Token: 0x0400337C RID: 13180
	public GameObject PhotoIcons;

	// Token: 0x0400337D RID: 13181
	public GameObject MainMenu;

	// Token: 0x0400337E RID: 13182
	public GameObject SubPanel;

	// Token: 0x0400337F RID: 13183
	public GameObject Message;

	// Token: 0x04003380 RID: 13184
	public GameObject Panel;

	// Token: 0x04003381 RID: 13185
	public GameObject ViolenceX;

	// Token: 0x04003382 RID: 13186
	public GameObject PantiesX;

	// Token: 0x04003383 RID: 13187
	public GameObject SenpaiX;

	// Token: 0x04003384 RID: 13188
	public GameObject BullyX;

	// Token: 0x04003385 RID: 13189
	public GameObject InfoX;

	// Token: 0x04003386 RID: 13190
	public bool BountyComplete;

	// Token: 0x04003387 RID: 13191
	public bool AirGuitarShot;

	// Token: 0x04003388 RID: 13192
	public bool DisplayError;

	// Token: 0x04003389 RID: 13193
	public bool MissionMode;

	// Token: 0x0400338A RID: 13194
	public bool PlushieShot;

	// Token: 0x0400338B RID: 13195
	public bool BountyShot;

	// Token: 0x0400338C RID: 13196
	public bool HorudaShot;

	// Token: 0x0400338D RID: 13197
	public bool KittenShot;

	// Token: 0x0400338E RID: 13198
	public bool OsanaShot;

	// Token: 0x0400338F RID: 13199
	public bool FreeSpace;

	// Token: 0x04003390 RID: 13200
	public bool TakePhoto;

	// Token: 0x04003391 RID: 13201
	public bool TookPhoto;

	// Token: 0x04003392 RID: 13202
	public bool Snapping;

	// Token: 0x04003393 RID: 13203
	public bool Close;

	// Token: 0x04003394 RID: 13204
	public bool Disguise;

	// Token: 0x04003395 RID: 13205
	public bool Nemesis;

	// Token: 0x04003396 RID: 13206
	public bool NotFace;

	// Token: 0x04003397 RID: 13207
	public bool Skirt;

	// Token: 0x04003398 RID: 13208
	public RaycastHit hit;

	// Token: 0x04003399 RID: 13209
	public float ReactionDistance;

	// Token: 0x0400339A RID: 13210
	public float PenaltyTimer;

	// Token: 0x0400339B RID: 13211
	public float Timer;

	// Token: 0x0400339C RID: 13212
	private float currentPercent;

	// Token: 0x0400339D RID: 13213
	public int TargetStudent;

	// Token: 0x0400339E RID: 13214
	public int NemesisShots;

	// Token: 0x0400339F RID: 13215
	public int Frame;

	// Token: 0x040033A0 RID: 13216
	public int Slot;

	// Token: 0x040033A1 RID: 13217
	public int ID;

	// Token: 0x040033A2 RID: 13218
	public string PlushieName = "";

	// Token: 0x040033A3 RID: 13219
	public AudioSource MyAudio;

	// Token: 0x040033A4 RID: 13220
	public Vector3 OriginalPosition;
}
