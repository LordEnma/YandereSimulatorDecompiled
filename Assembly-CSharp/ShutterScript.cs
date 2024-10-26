using System;
using UnityEngine;

public class ShutterScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public TaskManagerScript TaskManager;

	public PauseScreenScript PauseScreen;

	public StudentInfoScript StudentInfo;

	public PromptBarScript PromptBar;

	public SubtitleScript Subtitle;

	public SchemesScript Schemes;

	public StudentScript Student;

	public YandereScript Yandere;

	public StudentScript FaceStudent;

	public RenderTexture SmartphoneScreen;

	public Camera SmartphoneCamera;

	public Camera MainCamera;

	public Transform SelfieRayParent;

	public Transform TextMessages;

	public Transform ErrorWindow;

	public Transform Palm;

	public UILabel PhotoDescLabel;

	public UISprite Sprite;

	public GameObject NotificationManager;

	public GameObject BullyPhotoCollider;

	public GameObject PhotoDescription;

	public GameObject HeartbeatCamera;

	public GameObject EightiesCamera;

	public GameObject CameraButtons;

	public GameObject NewMessage;

	public GameObject PhotoIcons;

	public GameObject MainMenu;

	public GameObject SubPanel;

	public GameObject Message;

	public GameObject Panel;

	public GameObject ViolenceX;

	public GameObject PantiesX;

	public GameObject SenpaiX;

	public GameObject BullyX;

	public GameObject InfoX;

	public bool PhotographedKokona;

	public bool BountyComplete;

	public bool AirGuitarShot;

	public bool DisplayError;

	public bool MissionMode;

	public bool PlushieShot;

	public bool BountyShot;

	public bool HorudaShot;

	public bool KittenShot;

	public bool RestoreFPS;

	public bool OsanaShot;

	public bool FreeSpace;

	public bool TakePhoto;

	public bool TookPhoto;

	public bool Snapping;

	public bool Disguise;

	public bool Eighties;

	public bool Blocked;

	public bool Nemesis;

	public bool NotFace;

	public bool Close;

	public bool Skirt;

	public RaycastHit hit;

	public float ReactionDistance;

	public float PenaltyTimer;

	public float Timer;

	private float currentPercent;

	public int TargetStudent;

	public int NemesisShots;

	public int Frame;

	public int Slot;

	public int ID;

	public string PlushieName = "";

	public AudioSource MyAudio;

	public Vector3 OriginalPosition;

	public int OnlyPhotography => 65537;

	public int OnlyCharacters => 513;

	public int OnlyRagdolls => 2049;

	public int OnlyBlood => 16385;

	private void Start()
	{
		if (MissionModeGlobals.MissionMode)
		{
			MissionMode = true;
		}
		Eighties = GameGlobals.Eighties;
		ErrorWindow.transform.localScale = Vector3.zero;
		CameraButtons.SetActive(value: false);
		PhotoIcons.SetActive(value: false);
		Sprite.color = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, 0f);
		OriginalPosition = PhotoIcons.transform.localPosition;
	}

	private void Update()
	{
		_ = Yandere.Selfie;
		if (Snapping)
		{
			if (StudentManager.FPSDisplay.activeInHierarchy)
			{
				StudentManager.FPSDisplayBG.SetActive(value: false);
				StudentManager.FPSDisplay.SetActive(value: false);
				RestoreFPS = true;
			}
			if (Yandere.Noticed)
			{
				ResumeGameplay();
				Yandere.StopAiming();
			}
			else if (Close)
			{
				currentPercent += 60f * Time.unscaledDeltaTime;
				while (currentPercent >= 1f)
				{
					Frame = Mathf.Min(Frame + 1, 8);
					currentPercent -= 1f;
				}
				Sprite.spriteName = "Shutter" + Frame;
				if (Frame == 8)
				{
					StudentManager.GhostChan.gameObject.SetActive(value: true);
					PhotoDescription.SetActive(value: false);
					PhotoDescLabel.text = "";
					StudentManager.GhostChan.Look();
					CheckPhoto();
					if (PhotoDescLabel.text == "")
					{
						PhotoDescLabel.text = "Cannot determine subject of photo. Try again.";
					}
					PhotoDescription.SetActive(value: true);
					SmartphoneCamera.targetTexture = null;
					Yandere.PhonePromptBar.Show = false;
					NotificationManager.SetActive(value: false);
					HeartbeatCamera.SetActive(value: false);
					PhotoIcons.transform.localPosition = OriginalPosition;
					Yandere.SelfieGuide.SetActive(value: false);
					MainCamera.enabled = false;
					PhotoIcons.SetActive(value: true);
					SubPanel.SetActive(value: false);
					Panel.SetActive(value: false);
					Close = false;
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "Save";
					PromptBar.Label[1].text = "Delete";
					if (!Yandere.RivalPhone)
					{
						if (StudentManager.Eighties)
						{
							PromptBar.Label[2].text = "View Info";
						}
						else
						{
							PromptBar.Label[2].text = "Send";
						}
					}
					else if (PantiesX.activeInHierarchy)
					{
						PromptBar.Label[0].text = "";
					}
					if ((StudentManager.Eighties && InfoX.activeInHierarchy) || StudentManager.KokonaTutorial)
					{
						PromptBar.Label[2].text = "";
					}
					Yandere.DetectionPanel.alpha = 0f;
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
					Time.timeScale = 0.0001f;
				}
			}
			else
			{
				currentPercent += 60f * Time.unscaledDeltaTime;
				while (currentPercent >= 1f)
				{
					Frame = Mathf.Max(Frame - 1, 1);
					currentPercent -= 1f;
				}
				Sprite.spriteName = "Shutter" + Frame;
				if (Frame == 1)
				{
					Sprite.color = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, 0f);
					Snapping = false;
				}
			}
		}
		else
		{
			bool flag = true;
			if (Eighties && Yandere.Club != ClubType.Photography)
			{
				flag = false;
			}
			if (flag)
			{
				if (Yandere.Aiming)
				{
					TargetStudent = 0;
					Timer += Time.deltaTime;
					if (Timer > 0.5f)
					{
						Vector3 vector = (Yandere.Selfie ? SelfieRayParent.TransformDirection(Vector3.forward) : SmartphoneCamera.transform.TransformDirection(Vector3.forward));
						Debug.DrawRay(SmartphoneCamera.transform.position, vector, Color.green);
						if (Physics.Raycast(SmartphoneCamera.transform.position, vector, out hit, float.PositiveInfinity, OnlyPhotography))
						{
							if (hit.collider.gameObject.name == "Face")
							{
								GameObject gameObject = hit.collider.gameObject.transform.root.gameObject;
								FaceStudent = gameObject.GetComponent<StudentScript>();
								if (FaceStudent != null)
								{
									TargetStudent = FaceStudent.StudentID;
									if (TargetStudent > 1)
									{
										ReactionDistance = 1.66666f;
									}
									else
									{
										ReactionDistance = FaceStudent.VisionDistance;
									}
									bool flag2 = FaceStudent.ShoeRemoval.enabled;
									bool flag3 = false;
									if (FaceStudent.MyPlate != null && FaceStudent.MyPlate.parent == FaceStudent.RightHand)
									{
										flag3 = true;
									}
									if (!FaceStudent.Alarmed && !FaceStudent.Dying && !FaceStudent.Distracted && !FaceStudent.InEvent && !FaceStudent.Wet && FaceStudent.Schoolwear > 0 && !FaceStudent.Fleeing && !FaceStudent.Following && !flag2 && !FaceStudent.HoldingHands && FaceStudent.Actions[FaceStudent.Phase] != StudentActionType.Mourn && !FaceStudent.Guarding && !FaceStudent.Confessing && !FaceStudent.DiscCheck && !FaceStudent.TurnOffRadio && !FaceStudent.Investigating && !FaceStudent.Distracting && !FaceStudent.WitnessedLimb && !FaceStudent.WitnessedWeapon && !FaceStudent.WitnessedBloodPool && !FaceStudent.WitnessedBloodyWeapon && !FaceStudent.SentHome && !FaceStudent.EatingSnack && !FaceStudent.Slave && !FaceStudent.FragileSlave && !FaceStudent.TakingOutTrash && !FaceStudent.Pushable && !FaceStudent.SentToLocker && !flag3 && FaceStudent.Club != ClubType.Council && FaceStudent.Club != ClubType.Delinquent && Vector3.Distance(Yandere.transform.position, gameObject.transform.position) < ReactionDistance && FaceStudent.CanSeeObject(Yandere.gameObject, Yandere.transform.position + Vector3.up))
									{
										if (MissionMode && !FaceStudent.Nemesis)
										{
											PenaltyTimer += Time.deltaTime;
											if (PenaltyTimer > 1f)
											{
												Debug.Log("Mission Mode Awareness Penalty!");
												FaceStudent.Reputation.PendingRep -= 10f;
												FaceStudent.PendingRep -= 10f;
												PenaltyTimer = 0f;
											}
										}
										if (!FaceStudent.CameraReacting)
										{
											if (FaceStudent.enabled && !FaceStudent.Stop && !FaceStudent.SpecialRivalDeathReaction && !FaceStudent.IgnoringPettyActions && !FaceStudent.WitnessedCorpse)
											{
												if ((FaceStudent.DistanceToDestination < 5f && FaceStudent.Actions[FaceStudent.Phase] == StudentActionType.Graffiti) || (FaceStudent.DistanceToDestination < 5f && FaceStudent.Actions[FaceStudent.Phase] == StudentActionType.Bully))
												{
													FaceStudent.PhotoPatience = 0f;
													FaceStudent.KilledMood = true;
													FaceStudent.Ignoring = true;
													PenaltyTimer = 1f;
													Penalize();
												}
												else if (FaceStudent.PhotoPatience > 0f)
												{
													if (FaceStudent.StudentID > 1)
													{
														if ((Yandere.Bloodiness > 0f && !Yandere.Paint) || (double)Yandere.Sanity < 33.33333)
														{
															FaceStudent.Alarm += 200f;
														}
														else
														{
															FaceStudent.CameraReact();
														}
													}
													else
													{
														FaceStudent.Alarm += Time.deltaTime * (100f / FaceStudent.DistanceToPlayer) * FaceStudent.Paranoia * FaceStudent.Perception * FaceStudent.DistanceToPlayer * 2f;
														FaceStudent.YandereVisible = true;
													}
												}
												else if (Student != null && !Student.Teacher)
												{
													Penalize();
												}
											}
										}
										else
										{
											FaceStudent.PhotoPatience = Mathf.MoveTowards(FaceStudent.PhotoPatience, 0f, Time.deltaTime);
											if (FaceStudent.PhotoPatience > 0f)
											{
												FaceStudent.CameraPoseTimer = 1f;
												if (MissionMode)
												{
													FaceStudent.PhotoPatience = 0f;
												}
											}
										}
									}
								}
							}
							else if (hit.collider.gameObject.name == "Panties" || hit.collider.gameObject.name == "Skirt")
							{
								GameObject gameObject2 = hit.collider.gameObject.transform.root.gameObject;
								if (Physics.Raycast(SmartphoneCamera.transform.position, vector, out hit, float.PositiveInfinity, OnlyCharacters))
								{
									if (Vector3.Distance(Yandere.transform.position, gameObject2.transform.position) < 5f)
									{
										if (hit.collider.gameObject == gameObject2)
										{
											if (!Yandere.Lewd)
											{
												Yandere.NotificationManager.DisplayNotification(NotificationType.Lewd);
											}
											Yandere.Lewd = true;
										}
										else
										{
											Yandere.Lewd = false;
										}
									}
									else
									{
										Yandere.Lewd = false;
									}
								}
							}
							else
							{
								Yandere.Lewd = false;
							}
						}
						else
						{
							Yandere.Lewd = false;
						}
					}
				}
				else
				{
					Timer = 0f;
				}
			}
		}
		if (TookPhoto)
		{
			ResumeGameplay();
		}
		if (!DisplayError)
		{
			if (PhotoIcons.activeInHierarchy && !Snapping && !TextMessages.gameObject.activeInHierarchy)
			{
				Time.timeScale = 0.0001f;
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					if (StudentManager.KokonaTutorial)
					{
						if (TargetStudent == 30)
						{
							PhotographedKokona = true;
						}
						ResumeGameplay();
					}
					else if (!Yandere.RivalPhone)
					{
						bool flag4 = !BullyX.activeInHierarchy;
						bool flag5 = !SenpaiX.activeInHierarchy;
						PromptBar.transform.localPosition = new Vector3(PromptBar.transform.localPosition.x, -627f, PromptBar.transform.localPosition.z);
						PromptBar.ClearButtons();
						PromptBar.Show = false;
						PhotoIcons.SetActive(value: false);
						ID = 0;
						FreeSpace = false;
						while (ID < 25)
						{
							ID++;
							if (!Yandere.PauseScreen.PhotoGallery.PhotographTaken[ID])
							{
								FreeSpace = true;
								Slot = ID;
								ID = 25;
							}
						}
						if (FreeSpace)
						{
							Debug.Log("We're going to save a photo into Slot #" + Slot);
							if (StudentManager.Eighties)
							{
								Yandere.HandCamera.gameObject.SetActive(value: true);
							}
							ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/Photographs/Profile_" + GameGlobals.Profile + "/Photo_" + Slot + ".png");
							TookPhoto = true;
							Debug.Log("Setting Photo " + Slot + " to ''true''.");
							PauseScreen.PhotoGallery.PhotographTaken[Slot] = true;
							if (flag4)
							{
								Debug.Log("Saving a bully photo!");
								int studentID = BullyPhotoCollider.transform.parent.gameObject.GetComponent<StudentScript>().StudentID;
								if (StudentManager.Students[studentID].Club != ClubType.Bully)
								{
									Yandere.PauseScreen.PhotoGallery.BullyPhoto[Slot] = studentID;
								}
								else
								{
									Yandere.PauseScreen.PhotoGallery.BullyPhoto[Slot] = StudentManager.Students[studentID].DistractionTarget.StudentID;
								}
							}
							if (flag5)
							{
								Yandere.PauseScreen.PhotoGallery.SenpaiPhoto[Slot] = true;
								Yandere.Inventory.SenpaiShots++;
							}
							if (AirGuitarShot)
							{
								Yandere.PauseScreen.PhotoGallery.GuitarPhoto[Slot] = true;
								TaskManager.UpdateTaskStatus();
							}
							if (KittenShot)
							{
								Yandere.PauseScreen.PhotoGallery.KittenPhoto[Slot] = true;
								TaskManager.UpdateTaskStatus();
							}
							if (HorudaShot)
							{
								Yandere.PauseScreen.PhotoGallery.HorudaPhoto[Slot] = true;
								TaskManager.UpdateTaskStatus();
							}
							if (OsanaShot && DateGlobals.Weekday == DayOfWeek.Thursday)
							{
								SchemeGlobals.SetSchemeStage(4, 7);
								Yandere.PauseScreen.Schemes.UpdateInstructions();
							}
						}
						else
						{
							DisplayError = true;
						}
					}
					else if (!PantiesX.activeInHierarchy)
					{
						if (SchemeGlobals.GetSchemeStage(1) == 5)
						{
							SchemeGlobals.SetSchemeStage(1, 6);
							Schemes.UpdateInstructions();
						}
						StudentManager.CommunalLocker.RivalPhone.LewdPhotos = true;
						ResumeGameplay();
					}
				}
				if (!StudentManager.KokonaTutorial && !Yandere.RivalPhone && Input.GetButtonDown(InputNames.Xbox_X))
				{
					bool flag6 = false;
					if (StudentManager.Eighties && InfoX.activeInHierarchy)
					{
						flag6 = true;
					}
					if (!flag6)
					{
						Panel.SetActive(value: true);
						MainMenu.SetActive(value: false);
						PauseScreen.Show = true;
						PauseScreen.Panel.enabled = true;
						PromptBar.ClearButtons();
						PromptBar.Label[1].text = "Exit";
						if (!InfoX.activeInHierarchy)
						{
							PromptBar.Label[3].text = "Interests";
						}
						else
						{
							PromptBar.Label[3].text = "";
						}
						PromptBar.UpdateButtons();
						if (!InfoX.activeInHierarchy)
						{
							StudentInfo.UpdateTagButton();
							PauseScreen.Sideways = true;
							if (!StudentManager.StudentPhotographed[Student.StudentID])
							{
								Yandere.Inventory.PantyShots++;
							}
							StudentManager.StudentPhotographed[Student.StudentID] = true;
							for (ID = 0; ID < Student.Outlines.Length; ID++)
							{
								if (Student.Outlines[ID] != null)
								{
									Student.Outlines[ID].enabled = true;
								}
							}
							StudentInfo.UpdateInfo(Student.StudentID);
							StudentInfo.gameObject.SetActive(value: true);
							PhotoIcons.transform.localPosition = new Vector3(0f, 1000f, 0f);
						}
						else if (!TextMessages.gameObject.activeInHierarchy)
						{
							PauseScreen.Sideways = false;
							TextMessages.gameObject.SetActive(value: true);
							SpawnMessage();
						}
					}
				}
				if (Input.GetButtonDown(InputNames.Xbox_B))
				{
					ResumeGameplay();
				}
			}
			else if (PhotoIcons.activeInHierarchy && Input.GetButtonDown(InputNames.Xbox_B))
			{
				ResumeGameplay();
				if (!Yandere.Aiming)
				{
					Yandere.StopAiming();
					Yandere.CanMove = false;
				}
			}
		}
		else
		{
			float t = Time.unscaledDeltaTime * 10f;
			ErrorWindow.transform.localScale = Vector3.Lerp(ErrorWindow.transform.localScale, new Vector3(1f, 1f, 1f), t);
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				ResumeGameplay();
			}
		}
	}

	public void Snap()
	{
		ErrorWindow.transform.localScale = Vector3.zero;
		if (!StudentManager.Eighties)
		{
			Yandere.HandCamera.gameObject.SetActive(value: false);
		}
		else
		{
			SmartphoneCamera.transform.parent = Yandere.HandCamera.transform;
			SmartphoneCamera.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			SmartphoneCamera.transform.localPosition = new Vector3(0f, 0f, 0f);
			StudentManager.ClubManager.Viewfinder.SetActive(value: false);
		}
		Sprite.color = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, 1f);
		MyAudio.Play();
		Snapping = true;
		Close = true;
		Frame = 0;
	}

	public void CheckPhoto()
	{
		InfoX.SetActive(value: true);
		BullyX.SetActive(value: true);
		SenpaiX.SetActive(value: true);
		PantiesX.SetActive(value: true);
		ViolenceX.SetActive(value: true);
		AirGuitarShot = false;
		PlushieShot = false;
		BountyShot = false;
		HorudaShot = false;
		KittenShot = false;
		OsanaShot = false;
		Nemesis = false;
		NotFace = false;
		Skirt = false;
		Transform transform = (Yandere.Aiming ? SmartphoneCamera.transform : ((!Yandere.WallInFront) ? Palm : Yandere.StudentManager.transform));
		Vector3 direction = (Yandere.Selfie ? SelfieRayParent.TransformDirection(Vector3.forward) : transform.TransformDirection(Vector3.forward));
		StudentManager.UpdatePanties(Status: true);
		StudentManager.UpdateSkirts(Status: true);
		if (Physics.Raycast(transform.position, direction, out hit, float.PositiveInfinity, OnlyPhotography))
		{
			if (hit.collider.gameObject.name == "Panties")
			{
				Student = hit.collider.gameObject.transform.root.gameObject.GetComponent<StudentScript>();
				PhotoDescLabel.text = "Photo of: " + Student.Name + "'s Panties";
				PantiesX.SetActive(value: false);
				if (!Yandere.Aiming)
				{
					Yandere.ResetYandereEffects();
					PhotoIcons.SetActive(value: true);
					InfoX.SetActive(value: true);
					Time.timeScale = 0f;
					Panel.SetActive(value: true);
					MainMenu.SetActive(value: false);
					PauseScreen.Show = true;
					PauseScreen.Panel.enabled = true;
					PromptBar.ClearButtons();
					PromptBar.Label[1].text = "Exit";
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
					PauseScreen.Sideways = false;
					TextMessages.gameObject.SetActive(value: true);
					SpawnMessage();
				}
			}
			else if (hit.collider.gameObject.name == "Face")
			{
				if (hit.collider.gameObject.tag == "Nemesis")
				{
					PhotoDescLabel.text = "Photo of: Nemesis";
					Nemesis = true;
					NemesisShots++;
				}
				else if (hit.collider.gameObject.tag == "Disguise")
				{
					PhotoDescLabel.text = "Photo of: ?????";
					Disguise = true;
				}
				else
				{
					Student = hit.collider.gameObject.transform.root.gameObject.GetComponent<StudentScript>();
					if (Student.StudentID == 1)
					{
						PhotoDescLabel.text = "Photo of: Senpai";
						SenpaiX.SetActive(value: false);
					}
					else
					{
						PhotoDescLabel.text = "Photo of: " + Student.Name;
						InfoX.SetActive(value: false);
					}
				}
			}
			else if (hit.collider.gameObject.name == "NotFace")
			{
				PhotoDescLabel.text = "Photo of: Blocked Face";
				NotFace = true;
			}
			else if (hit.collider.gameObject.name == "Skirt")
			{
				PhotoDescLabel.text = "Photo of: Skirt";
				Skirt = true;
			}
			if (hit.collider.transform.root.gameObject.name == "Student_51 (Miyuji Shan)" && StudentManager.Students[51].AirGuitar.isPlaying)
			{
				AirGuitarShot = true;
				PhotoDescription.SetActive(value: true);
				PhotoDescLabel.text = "Photo of: Miyuji's True Nature?";
			}
			if (hit.collider.gameObject.name == "Kitten")
			{
				KittenShot = true;
				PhotoDescription.SetActive(value: true);
				PhotoDescLabel.text = "Photo of: Kitten";
				if (!ConversationGlobals.GetTopicDiscovered(15))
				{
					ConversationGlobals.SetTopicDiscovered(15, value: true);
					Yandere.NotificationManager.TopicName = "Cats";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				}
			}
			if (hit.collider.gameObject.tag == "Horuda")
			{
				HorudaShot = true;
				PhotoDescription.SetActive(value: true);
				PhotoDescLabel.text = "Photo of: Horuda Covered in Brown Paint";
			}
			if (hit.collider.gameObject.name == "Bounty")
			{
				BountyShot = true;
				PhotoDescription.SetActive(value: true);
				if (StudentManager.Clock.GameplayDay == 1)
				{
					PhotoDescLabel.text = "Photo of: Horuda Drawing Gore";
				}
				else if (StudentManager.Clock.GameplayDay == 2)
				{
					PhotoDescLabel.text = "Photo of: Kyuji Stalking Osana";
				}
				else if (StudentManager.Clock.GameplayDay == 3)
				{
					PhotoDescLabel.text = "Photo of: Otohiko Falling Down";
				}
				else if (StudentManager.Clock.GameplayDay == 4)
				{
					PhotoDescLabel.text = "Photo of: Hazu Sewing Clothes";
				}
				else if (StudentManager.Clock.GameplayDay == 5)
				{
					PhotoDescLabel.text = "Photo of: Toga Framed as Pervert";
				}
				else if (StudentManager.Clock.GameplayDay == 6)
				{
					PhotoDescLabel.text = "Photo of: Ryuto Gaming at School";
				}
				else if (StudentManager.Clock.GameplayDay == 7)
				{
					PhotoDescLabel.text = "Photo of: Fureddo Slacking Off";
				}
				else if (StudentManager.Clock.GameplayDay == 8)
				{
					PhotoDescLabel.text = "Photo of: Horo Hologram Sabotaged";
				}
				else if (StudentManager.Clock.GameplayDay == 9)
				{
					PhotoDescLabel.text = "Photo of: Uekiya Missing Keys";
				}
				else if (StudentManager.Clock.GameplayDay == 10)
				{
					PhotoDescLabel.text = "Photo of: Umeji Sulking in Defeat";
				}
			}
			if (hit.collider.gameObject.tag == "Bully")
			{
				PhotoDescLabel.text = "Photo of: Student Speaking With Bully";
				BullyPhotoCollider = hit.collider.gameObject;
				BullyX.SetActive(value: false);
			}
			if (hit.collider.gameObject.tag == "RivalEvidence")
			{
				OsanaShot = true;
				PhotoDescription.SetActive(value: true);
				PhotoDescLabel.text = "Photo of: Osana Vandalizing School Property";
			}
			if (hit.collider.gameObject.transform.parent != null && hit.collider.gameObject.transform.parent.name == "Plushies")
			{
				PlushieShot = true;
				PlushieName = hit.collider.gameObject.name;
				PhotoDescription.SetActive(value: true);
				PhotoDescLabel.text = "Photo of: A cute plushie doll";
			}
		}
		if (Physics.Raycast(SmartphoneCamera.transform.position, direction, out hit, float.PositiveInfinity, OnlyRagdolls) && hit.collider.gameObject.layer == 11)
		{
			PhotoDescLabel.text = "Photo of: Corpse";
			ViolenceX.SetActive(value: false);
			StudentScript component = hit.collider.gameObject.transform.root.gameObject.GetComponent<StudentScript>();
			if (component != null)
			{
				if (component.Hunting || component.Hunted)
				{
					PhotoDescLabel.text = "Photo of: Murder-suicide taking place";
				}
				else if (component.Ragdoll.Zs.activeInHierarchy)
				{
					PhotoDescLabel.text = "Photo of: Sleeping Student";
				}
			}
		}
		if (Physics.Raycast(SmartphoneCamera.transform.position, SmartphoneCamera.transform.TransformDirection(Vector3.forward), out hit, float.PositiveInfinity, OnlyBlood) && hit.collider.gameObject.layer == 14)
		{
			PhotoDescLabel.text = "Photo of: Blood";
			ViolenceX.SetActive(value: false);
		}
		StudentManager.UpdateSkirts(Status: false);
		if (!Yandere.Aiming)
		{
			if (NewMessage == null)
			{
				Yandere.NotificationManager.CustomText = "You missed.";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			StudentManager.UpdatePanties(Status: false);
		}
	}

	public void SpawnMessage()
	{
		Debug.Log("Spawning a message.");
		if (Yandere.NoInfo)
		{
			ResumeGameplay();
			return;
		}
		if (NewMessage != null)
		{
			UnityEngine.Object.Destroy(NewMessage);
		}
		NewMessage = UnityEngine.Object.Instantiate(Message);
		NewMessage.transform.parent = TextMessages;
		NewMessage.transform.localPosition = new Vector3(-225f, -275f, 0f);
		NewMessage.transform.localEulerAngles = Vector3.zero;
		NewMessage.transform.localScale = new Vector3(1f, 1f, 1f);
		bool flag = false;
		if (Yandere.Aiming && hit.collider != null && hit.collider.gameObject.name == "Kitten")
		{
			flag = true;
		}
		string empty = string.Empty;
		int num = 0;
		if (BountyShot)
		{
			if (!BountyComplete)
			{
				empty = "Bounty complete. You've earned 25 Info Points.";
				num = 2;
				Yandere.Inventory.PantyShots += 25;
				BountyComplete = true;
			}
			else
			{
				empty = "You've already completed this bounty.";
				num = 2;
			}
		}
		else if (flag)
		{
			empty = "Why are you showing me this? I don't care.";
			num = 2;
		}
		else if (!InfoX.activeInHierarchy)
		{
			empty = "I recognize this person. Here's some information about them.";
			num = 3;
		}
		else if (!PantiesX.activeInHierarchy)
		{
			Debug.Log("Detected panties.");
			if (Student != null)
			{
				if (!StudentManager.PantyShotTaken[Student.StudentID])
				{
					StudentManager.PantyShotTaken[Student.StudentID] = true;
					if (Student.Nemesis)
					{
						empty = "Hey, wait a minute...I recognize those panties! This person is extremely dangerous! Avoid her at all costs!";
					}
					else if (Student.Club == ClubType.Bully || Student.Club == ClubType.Council || Student.Club == ClubType.Nurse || Student.StudentID == 20)
					{
						empty = "A high value target! " + Student.Name + "'s panties were in high demand. You've earned 10 Info Points.";
						Yandere.Inventory.PantyShots += 10;
					}
					else
					{
						empty = "Excellent! Now I have a picture of " + Student.Name + "'s panties. You've earned 5 Info Points.";
						Yandere.Inventory.PantyShots += 5;
					}
					num = 5;
				}
				else if (!Student.Nemesis)
				{
					empty = "I already have a picture of " + Student.Name + "'s panties. I don't need this shot.";
					num = 4;
				}
				else
				{
					empty = "You are in danger. Avoid her.";
					num = 2;
				}
			}
			else
			{
				empty = "How peculiar. I don't recognize these panties.";
				num = 2;
			}
		}
		else if (!ViolenceX.activeInHierarchy)
		{
			empty = "Good work, but don't send me this stuff. I have no use for it.";
			num = 3;
		}
		else if (!SenpaiX.activeInHierarchy)
		{
			if (PlayerGlobals.SenpaiShotsTexted == 0)
			{
				empty = "I don't need any pictures of your Senpai.";
				num = 2;
			}
			else if (PlayerGlobals.SenpaiShotsTexted == 1)
			{
				empty = "I know how you feel about this person, but I have no use for these pictures.";
				num = 4;
			}
			else if (PlayerGlobals.SenpaiShotsTexted == 2)
			{
				empty = "Okay, I get it, you love your Senpai, and you love taking pictures of your Senpai. I still don't need these shots.";
				num = 5;
			}
			else if (PlayerGlobals.SenpaiShotsTexted == 3)
			{
				empty = "You're spamming my inbox. Cut it out.";
				num = 2;
			}
			else
			{
				empty = "...";
				num = 1;
			}
			PlayerGlobals.SenpaiShotsTexted++;
		}
		else if (!BullyX.activeInHierarchy)
		{
			empty = "I have no interest in this.";
			num = 2;
		}
		else if (NotFace)
		{
			empty = "Do you want me to identify this person? Please get me a clear shot of their face.";
			num = 4;
		}
		else if (Skirt)
		{
			empty = "Is this supposed to be a panty shot? My clients are picky. The panties need to be in the EXACT center of the shot.";
			num = 5;
		}
		else if (Nemesis)
		{
			if (NemesisShots == 1)
			{
				empty = "Strange. I have no profile for this student.";
				num = 2;
			}
			else if (NemesisShots == 2)
			{
				empty = "...wait. I think I know who she is.";
				num = 2;
			}
			else if (NemesisShots == 3)
			{
				empty = "You are in danger. Avoid her.";
				num = 2;
			}
			else if (NemesisShots == 4)
			{
				empty = "Do not engage.";
				num = 1;
			}
			else
			{
				empty = "I repeat: Do. Not. Engage.";
				num = 2;
			}
		}
		else if (Disguise)
		{
			empty = "Something about that student seems...wrong.";
			num = 2;
		}
		else if (PlushieShot)
		{
			empty = "Hey, that's " + PlushieName + "!";
			num = 4;
		}
		else
		{
			empty = "I don't get it. What are you trying to show me? Make sure the subject is in the EXACT center of the photo.";
			num = 5;
		}
		NewMessage.GetComponent<UISprite>().height = 36 + 36 * num;
		NewMessage.GetComponent<TextMessageScript>().Label.text = empty;
	}

	public void ResumeGameplay()
	{
		if (RestoreFPS)
		{
			StudentManager.FPSDisplayBG.SetActive(value: true);
			StudentManager.FPSDisplay.SetActive(value: true);
			RestoreFPS = true;
		}
		ErrorWindow.transform.localScale = Vector3.zero;
		SmartphoneCamera.targetTexture = SmartphoneScreen;
		StudentManager.GhostChan.gameObject.SetActive(value: false);
		Yandere.HandCamera.gameObject.SetActive(value: true);
		NotificationManager.SetActive(value: true);
		PauseScreen.CorrectingTime = true;
		HeartbeatCamera.SetActive(value: true);
		TextMessages.gameObject.SetActive(value: false);
		StudentInfo.gameObject.SetActive(value: false);
		Yandere.DetectionPanel.alpha = 1f;
		MainCamera.enabled = true;
		PhotoIcons.SetActive(value: false);
		PauseScreen.Show = false;
		SubPanel.SetActive(value: true);
		MainMenu.SetActive(value: true);
		Yandere.CanMove = true;
		DisplayError = false;
		Panel.SetActive(value: true);
		Time.timeScale = 1f;
		TakePhoto = false;
		TookPhoto = false;
		AirGuitarShot = false;
		PlushieShot = false;
		BountyShot = false;
		HorudaShot = false;
		KittenShot = false;
		OsanaShot = false;
		Nemesis = false;
		NotFace = false;
		Skirt = false;
		if (!StudentManager.Eighties && !StudentManager.KokonaTutorial)
		{
			Yandere.PhonePromptBar.Panel.enabled = true;
			Yandere.PhonePromptBar.Show = true;
		}
		else if (Yandere.Club == ClubType.Photography)
		{
			StudentManager.ClubManager.Viewfinder.SetActive(value: true);
		}
		PromptBar.ClearButtons();
		PromptBar.Show = false;
		if (NewMessage != null)
		{
			UnityEngine.Object.Destroy(NewMessage);
		}
		if (!Yandere.CameraEffects.OneCamera)
		{
			if (!OptionGlobals.Fog)
			{
				Yandere.MainCamera.clearFlags = CameraClearFlags.Skybox;
			}
			else
			{
				Yandere.MainCamera.clearFlags = CameraClearFlags.Color;
			}
			Yandere.MainCamera.farClipPlane = OptionGlobals.DrawDistance;
		}
		Yandere.UpdateSelfieStatus();
		Yandere.RPGCamera.enabled = true;
		Yandere.RPGCamera.mouseX = Yandere.RPGCamera.mouseXSmooth;
		Yandere.RPGCamera.mouseY = Yandere.RPGCamera.mouseYSmooth;
		Yandere.RPGCamera.mouseSmoothingFactor = 0.08f;
	}

	public void Penalize()
	{
		PenaltyTimer += Time.deltaTime;
		if (!(PenaltyTimer >= 1f))
		{
			return;
		}
		Subtitle.UpdateLabel(SubtitleType.PhotoAnnoyance, 0, 3f);
		if (!FaceStudent.Teacher && Yandere.Mask == null)
		{
			if (MissionMode)
			{
				if (FaceStudent.TimesAnnoyed < 5)
				{
					FaceStudent.TimesAnnoyed++;
				}
				else
				{
					Debug.Log("Penalizing the player!");
					FaceStudent.RepDeduction = 0f;
					FaceStudent.RepLoss = 10f;
					FaceStudent.CalculateReputationPenalty();
					if (FaceStudent.RepDeduction >= 0f)
					{
						FaceStudent.RepLoss -= FaceStudent.RepDeduction;
					}
					FaceStudent.Reputation.PendingRep -= FaceStudent.RepLoss * FaceStudent.Paranoia;
					FaceStudent.PendingRep -= FaceStudent.RepLoss * FaceStudent.Paranoia;
					FaceStudent.PersonalSpaceTimer = 0f;
				}
			}
			else
			{
				FaceStudent.RepDeduction = 0f;
				FaceStudent.RepLoss = 1f;
				FaceStudent.CalculateReputationPenalty();
				if (FaceStudent.RepDeduction >= 0f)
				{
					FaceStudent.RepLoss -= FaceStudent.RepDeduction;
				}
				FaceStudent.Reputation.PendingRep -= FaceStudent.RepLoss * FaceStudent.Paranoia;
				FaceStudent.PendingRep -= FaceStudent.RepLoss * FaceStudent.Paranoia;
				FaceStudent.PersonalSpaceTimer = 0f;
			}
		}
		PenaltyTimer = 0f;
	}
}
