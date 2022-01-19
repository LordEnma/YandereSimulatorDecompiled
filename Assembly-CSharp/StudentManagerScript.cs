using System;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x02000453 RID: 1107
public class StudentManagerScript : MonoBehaviour
{
	// Token: 0x06001D43 RID: 7491 RVA: 0x00161084 File Offset: 0x0015F284
	private void Awake()
	{
		if (!this.TakingPortraits && !GameGlobals.Eighties && DateGlobals.Week > this.WeekLimit)
		{
			Debug.Log("We're not in 1980s Mode and Week is " + DateGlobals.Week.ToString() + " so we're resetting the week to ''0'' and booting the player out.");
			DateGlobals.Week = 0;
			SceneManager.LoadScene("VeryFunScene");
		}
	}

	// Token: 0x06001D44 RID: 7492 RVA: 0x001610E0 File Offset: 0x0015F2E0
	private void Start()
	{
		this.EightiesTutorial = GameGlobals.EightiesTutorial;
		this.MissionMode = MissionModeGlobals.MissionMode;
		this.EmptyDemon = GameGlobals.EmptyDemon;
		this.Week = DateGlobals.Week;
		if (GameGlobals.Eighties)
		{
			this.Become1989();
		}
		else
		{
			this.PortraitChan = this.StudentChan;
			this.PortraitKun = this.StudentKun;
			if (this.IdolStage != null)
			{
				this.IdolStage.SetActive(false);
			}
			foreach (GameObject gameObject in this.ModernDayProps)
			{
				if (gameObject != null)
				{
					gameObject.SetActive(true);
				}
			}
			foreach (GameObject gameObject2 in this.EightiesProps)
			{
				if (gameObject2 != null)
				{
					gameObject2.SetActive(false);
				}
			}
			if (!this.TakingPortraits)
			{
				this.InfoClubRoom.SetActive(true);
				this.InfoClubProps.SetActive(true);
				this.ModernDayScienceClub.SetActive(true);
				this.ModernDayScienceProps.SetActive(true);
				this.ModernDayPropsLMC.SetActive(true);
				this.ModernDayRoomLMC.SetActive(true);
				this.NewspaperClubProps.SetActive(false);
				this.NewspaperClubRoom.SetActive(false);
				this.EightiesPropsLMC.SetActive(false);
				this.EightiesRoomLMC.SetActive(false);
				this.EightiesScienceClub.SetActive(false);
				this.EightiesScienceProps.SetActive(false);
			}
			this.SuitorID = 6;
		}
		if (this.EightiesTutorial || this.Week > 10)
		{
			this.SpawnNobody = true;
			if (this.Week > 10)
			{
				this.RivalBookBag.gameObject.SetActive(false);
				this.Tutorial.gameObject.SetActive(false);
				this.Yandere.enabled = false;
				this.EndingCutscene.SetActive(true);
				this.Yandere.MainCamera.gameObject.SetActive(false);
				this.Clock.transform.parent = this.FreeFloatingPanel.transform;
				this.Yandere.HUD.transform.parent.gameObject.SetActive(false);
			}
		}
		else if (this.Tutorial != null)
		{
			this.Tutorial.gameObject.SetActive(false);
		}
		this.InitialSabotageProgress = DatingGlobals.RivalSabotaged;
		this.SabotageProgress = this.InitialSabotageProgress;
		this.LoadCollectibles();
		this.LoadReps();
		this.EmbarassingSecret = SchemeGlobals.EmbarassingSecret;
		if (!ConversationGlobals.GetTopicDiscovered(1))
		{
			this.ID = 1;
			while (this.ID < 26)
			{
				ConversationGlobals.SetTopicDiscovered(this.ID, true);
				this.ID++;
			}
		}
		if (PlayerPrefs.GetInt("LoadingSave") == 1)
		{
			this.ReturnedFromSave = true;
		}
		if (GameGlobals.RivalEliminationID > 0)
		{
			this.ModernRivalBookBag.SetActive(false);
			this.RivalEliminated = true;
		}
		this.RivalID = this.Week + 10;
		StudentGlobals.SetStudentPhotographed(this.RivalID, true);
		if (this.Police != null)
		{
			this.Police.EndOfDay.LearnedOsanaInfo1 = EventGlobals.OsanaEvent1;
			this.Police.EndOfDay.LearnedOsanaInfo2 = EventGlobals.OsanaEvent2;
			this.Police.EndOfDay.LearnedAboutPhotographer = EventGlobals.LearnedAboutPhotographer;
		}
		this.LoveSick = GameGlobals.LoveSick;
		this.MetalDetectors = SchoolGlobals.HighSecurity;
		this.RoofFenceUp = SchoolGlobals.RoofFence;
		if (this.Schemes != null)
		{
			this.Schemes.HUDIcon.gameObject.SetActive(false);
			this.Schemes.HUDInstructions.text = string.Empty;
			this.Schemes.SchemeManager.CurrentScheme = 0;
			this.Schemes.NextStepInput.SetActive(false);
			SchemeGlobals.CurrentScheme = 0;
		}
		if (ClubGlobals.GetClubClosed(ClubType.LightMusic))
		{
			this.SpawnPositions[51].position = new Vector3(3f, 0f, -95f);
		}
		if (HomeGlobals.LateForSchool)
		{
			this.YandereLate = true;
			Debug.Log("Yandere-chan is late for school!");
		}
		if (GameGlobals.Profile == 0)
		{
			GameGlobals.Profile = 1;
			PlayerGlobals.Money = 10f;
		}
		if (PlayerPrefs.GetInt("LoadingSave") == 1)
		{
			int profile = GameGlobals.Profile;
			int @int = PlayerPrefs.GetInt("SaveSlot");
			StudentGlobals.MemorialStudents = PlayerPrefs.GetInt(string.Concat(new string[]
			{
				"Profile_",
				profile.ToString(),
				"_Slot_",
				@int.ToString(),
				"_MemorialStudents"
			}));
		}
		if (!GameGlobals.ReputationsInitialized)
		{
			GameGlobals.ReputationsInitialized = true;
			this.InitializeReputations();
		}
		this.ID = 76;
		while (this.ID < 81)
		{
			if (this.StudentReps[this.ID] > -67f)
			{
				this.StudentReps[this.ID] = -67f;
			}
			this.ID++;
		}
		if (ClubGlobals.GetClubClosed(ClubType.Gardening))
		{
			this.GardenBlockade.SetActive(true);
			this.Flowers.SetActive(false);
		}
		this.ID = 0;
		this.ID = 1;
		while (this.ID < this.JSON.Students.Length)
		{
			if (!this.JSON.Students[this.ID].Success)
			{
				this.ProblemID = this.ID;
				break;
			}
			this.ID++;
		}
		if (!this.TakingPortraits)
		{
			if (this.FridayPaintings.Length != 0)
			{
				this.ID = 1;
				while (this.ID < this.FridayPaintings.Length)
				{
					this.FridayPaintings[this.ID].material.color = new Color(1f, 1f, 1f, 0f);
					this.ID++;
				}
			}
			this.DatingMinigame.Start();
		}
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			if (this.Canvases != null)
			{
				this.Canvases.SetActive(false);
			}
		}
		else if (this.Week == 1 && ClubGlobals.GetClubClosed(ClubType.Art))
		{
			this.Canvases.SetActive(false);
		}
		if (this.ProblemID != -1)
		{
			if (this.ErrorLabel != null)
			{
				this.ErrorLabel.text = string.Empty;
				this.ErrorLabel.enabled = false;
			}
			if (this.MissionMode)
			{
				StudentGlobals.FemaleUniform = 5;
				StudentGlobals.MaleUniform = 5;
				this.RedString.gameObject.SetActive(false);
			}
			this.SetAtmosphere();
			GameGlobals.Paranormal = false;
			if (StudentGlobals.StudentSlave > 0 && !StudentGlobals.GetStudentDead(StudentGlobals.StudentSlave))
			{
				int studentSlave = StudentGlobals.StudentSlave;
				this.ForceSpawn = true;
				this.SpawnPositions[studentSlave] = this.SlaveSpot;
				this.SpawnID = studentSlave;
				StudentGlobals.SetStudentDead(studentSlave, false);
				this.SpawnStudent(this.SpawnID);
				this.Students[studentSlave].Slave = true;
				this.SpawnID = 0;
			}
			if (StudentGlobals.FragileSlave > 0 && !StudentGlobals.GetStudentDead(StudentGlobals.FragileSlave))
			{
				int fragileSlave = StudentGlobals.FragileSlave;
				this.ForceSpawn = true;
				this.SpawnPositions[fragileSlave] = this.FragileSlaveSpot;
				this.SpawnID = fragileSlave;
				StudentGlobals.SetStudentDead(fragileSlave, false);
				this.SpawnStudent(this.SpawnID);
				this.Students[fragileSlave].FragileSlave = true;
				this.Students[fragileSlave].Slave = true;
				this.SpawnID = 0;
			}
			this.NPCsTotal = this.StudentsTotal + this.TeachersTotal;
			this.SpawnID = 1;
			if (StudentGlobals.MaleUniform == 0)
			{
				StudentGlobals.MaleUniform = 1;
			}
			this.ID = 1;
			while (this.ID < this.NPCsTotal + 1)
			{
				if (!StudentGlobals.GetStudentDead(this.ID))
				{
					StudentGlobals.SetStudentDying(this.ID, false);
				}
				this.ID++;
			}
			if (!this.TakingPortraits)
			{
				this.ID = 1;
				while (this.ID < 101)
				{
					this.TargetSize[this.ID] = 2f + (float)this.ID * 0.1f;
					this.ID++;
				}
				this.TargetSize[11] = 20f;
				this.ID = 1;
				while (this.ID < this.Lockers.List.Length)
				{
					this.LockerPositions[this.ID].transform.position = this.Lockers.List[this.ID].position + this.Lockers.List[this.ID].forward * 0.5f;
					this.LockerPositions[this.ID].LookAt(this.Lockers.List[this.ID].position);
					this.ID++;
				}
				this.ID = 1;
				while (this.ID < this.ShowerLockers.List.Length)
				{
					Transform transform = UnityEngine.Object.Instantiate<GameObject>(this.EmptyObject, this.ShowerLockers.List[this.ID].position + this.ShowerLockers.List[this.ID].forward * 0.5f, this.ShowerLockers.List[this.ID].rotation).transform;
					transform.parent = this.ShowerLockers.transform;
					transform.transform.eulerAngles = new Vector3(transform.transform.eulerAngles.x, transform.transform.eulerAngles.y + 180f, transform.transform.eulerAngles.z);
					this.StrippingPositions[this.ID] = transform;
					this.ID++;
				}
				this.ID = 1;
				while (this.ID < this.HidingSpots.List.Length)
				{
					if (this.HidingSpots.List[this.ID] == null)
					{
						GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.EmptyObject, new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f)), Quaternion.identity);
						while (gameObject3.transform.position.x < 2.5f && gameObject3.transform.position.x > -2.5f && gameObject3.transform.position.z > -2.5f && gameObject3.transform.position.z < 2.5f)
						{
							gameObject3.transform.position = new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f));
						}
						gameObject3.transform.parent = this.HidingSpots.transform;
						this.HidingSpots.List[this.ID] = gameObject3.transform;
					}
					this.ID++;
				}
			}
			if (this.YandereLate)
			{
				this.Clock.PresentTime = 480f;
				this.Clock.HourTime = 8f;
				this.Clock.Hour = Mathf.Floor(this.Clock.PresentTime / 60f);
				this.Clock.Minute = Mathf.Floor((this.Clock.PresentTime / 60f - this.Clock.Hour) * 60f);
				this.Clock.UpdateClock();
				this.Clock.Update();
				this.SkipTo8();
			}
			if (GameGlobals.AlphabetMode)
			{
				Debug.Log("Entering Alphabet Killer Mode. Repositioning Yandere-chan and others.");
				this.Yandere.transform.position = this.Portal.transform.position + new Vector3(1f, 0f, 0f);
				this.Clock.StopTime = true;
				this.SkipTo730();
			}
			if (!this.TakingPortraits && !this.RecordingVideo && !this.SpawnNobody)
			{
				while (this.SpawnID < this.NPCsTotal + 1)
				{
					this.SpawnStudent(this.SpawnID);
					this.SpawnID++;
				}
				this.Graffiti[1].SetActive(false);
				this.Graffiti[2].SetActive(false);
				this.Graffiti[3].SetActive(false);
				this.Graffiti[4].SetActive(false);
				this.Graffiti[5].SetActive(false);
				this.RivalChan.SetActive(false);
			}
		}
		else
		{
			string str = string.Empty;
			if (this.ProblemID > 1)
			{
				str = "The problem may be caused by Student " + this.ProblemID.ToString() + ".";
			}
			if (this.ErrorLabel != null)
			{
				this.ErrorLabel.text = "The game cannot compile Students.JSON! There is a typo somewhere in the JSON file. The problem might be a missing quotation mark, a missing colon, a missing comma, or something else like that. Please find your typo and fix it, or revert to a backup of the JSON file. " + str;
				this.ErrorLabel.enabled = true;
			}
		}
		if (!this.TakingPortraits)
		{
			this.NEStairs = GameObject.Find("NEStairs").GetComponent<Collider>();
			this.NWStairs = GameObject.Find("NWStairs").GetComponent<Collider>();
			this.SEStairs = GameObject.Find("SEStairs").GetComponent<Collider>();
			this.SWStairs = GameObject.Find("SWStairs").GetComponent<Collider>();
			if (!this.ReturnedFromSave)
			{
				this.Yandere.Class.GetStats();
			}
			this.Yandere.CameraEffects.UpdateDOF(2f);
		}
		if (PlayerGlobals.PersonaID > 0)
		{
			this.Yandere.PersonaID = PlayerGlobals.PersonaID;
			this.Mirror.UpdatePersona();
		}
		this.LoadPantyshots();
		if (this.RecordingVideo)
		{
			base.gameObject.SetActive(false);
			this.FPSDisplay.SetActive(false);
			this.FPSDisplayBG.SetActive(false);
			this.Clock.CameraEffects.UpdateBloom(1f);
			this.Clock.CameraEffects.UpdateBloomRadius(4f);
			this.Clock.CameraEffects.UpdateBloomKnee(0.75f);
			this.Yandere.enabled = false;
			this.Yandere.UICamera.gameObject.SetActive(false);
			this.Yandere.MainCamera.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001D45 RID: 7493 RVA: 0x00161F3C File Offset: 0x0016013C
	public void SetAtmosphere()
	{
		if (GameGlobals.LoveSick)
		{
			SchoolGlobals.SchoolAtmosphereSet = true;
			SchoolGlobals.SchoolAtmosphere = 0f;
		}
		if (!this.MissionMode)
		{
			if (!SchoolGlobals.SchoolAtmosphereSet)
			{
				SchoolGlobals.SchoolAtmosphereSet = true;
				SchoolGlobals.PreviousSchoolAtmosphere = 1f;
				SchoolGlobals.SchoolAtmosphere = 1f;
			}
			this.Atmosphere = SchoolGlobals.SchoolAtmosphere;
		}
		float num = 1f - this.Atmosphere;
		if (!this.TakingPortraits)
		{
			this.SelectiveGreyscale.desaturation = num;
			if (this.HandSelectiveGreyscale != null)
			{
				this.HandSelectiveGreyscale.desaturation = num;
				this.SmartphoneSelectiveGreyscale.desaturation = num;
			}
			SelectiveGrayscale[] spyGrayscales = this.SpyGrayscales;
			for (int i = 0; i < spyGrayscales.Length; i++)
			{
				spyGrayscales[i].desaturation = num;
			}
			float num2 = 1f - num;
			RenderSettings.fogColor = new Color(num2, num2, num2, 1f);
			Camera.main.backgroundColor = new Color(num2, num2, num2, 1f);
			if (!this.EightiesTutorial)
			{
				RenderSettings.fogDensity = num * 0.1f;
			}
		}
		if (this.Yandere != null)
		{
			this.Yandere.GreyTarget = num;
		}
	}

	// Token: 0x06001D46 RID: 7494 RVA: 0x0016205C File Offset: 0x0016025C
	private void Update()
	{
		if (!this.TakingPortraits)
		{
			if (!this.Yandere.ShoulderCamera.Counselor.Interrogating)
			{
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			}
			this.Frame++;
			if (!this.FirstUpdate)
			{
				this.QualityManager.UpdateOutlines();
				this.FirstUpdate = true;
				this.AssignTeachers();
			}
			if (this.Frame == 3)
			{
				this.Police.EndOfDay.VoidGoddess.UpdatePortraits();
				this.LoveManager.CoupleCheck();
				if (this.Eighties || this.Bullies > 0)
				{
					this.DetermineVictim();
				}
				this.UpdateStudents(0);
				this.QualityManager.UpdateOutlinesAndRimlight();
				if (this.QualityManager.DisableOutlinesLater)
				{
					OptionGlobals.DisableOutlines = true;
				}
				if (this.QualityManager.DisableRimLightLater)
				{
					OptionGlobals.RimLight = false;
				}
				this.QualityManager.UpdateOutlinesAndRimlight();
				for (int i = 26; i < 31; i++)
				{
					if (this.Students[i] != null)
					{
						this.OriginalClubPositions[i - 25] = this.Clubs.List[i].position;
						this.OriginalClubRotations[i - 25] = this.Clubs.List[i].rotation;
					}
				}
				if (!this.TakingPortraits)
				{
					this.TaskManager.UpdateTaskStatus();
				}
				this.Yandere.GloveAttacher.newRenderer.enabled = false;
				this.UpdateAprons();
				if (PlayerPrefs.GetInt("LoadingSave") == 1)
				{
					PlayerPrefs.SetInt("LoadingSave", 0);
					this.Load();
				}
				this.ClubManager.gameObject.SetActive(true);
				if (!this.YandereLate && StudentGlobals.MemorialStudents > 0 && !this.ReturnedFromSave && DateGlobals.Week < 11)
				{
					this.Yandere.HUD.alpha = 0f;
					this.Yandere.RPGCamera.transform.position = new Vector3(38f, 4.125f, 68.825f);
					this.Yandere.RPGCamera.transform.eulerAngles = new Vector3(22.5f, 67.5f, 0f);
					this.Yandere.RPGCamera.transform.Translate(Vector3.forward, Space.Self);
					this.Yandere.RPGCamera.enabled = false;
					this.Yandere.HeartCamera.enabled = false;
					this.Yandere.CanMove = false;
					this.Clock.StopTime = true;
					this.StopMoving();
					this.MemorialScene.gameObject.SetActive(true);
					this.MemorialScene.enabled = true;
				}
				for (int i = 1; i < 90; i++)
				{
					if (this.Students[i] != null)
					{
						this.Students[i].ShoeRemoval.Start();
					}
				}
				this.ClubManager.ActivateClubBenefit();
				if (GameGlobals.CensorPanties)
				{
					this.CensorStudents();
					this.Yandere.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().Censor();
				}
				if (!this.Eighties)
				{
					if (!this.MissionMode && !GameGlobals.AlphabetMode)
					{
						if (this.Week == 1)
						{
							this.Week1RoutineAdjustments();
						}
						if (this.Week == 2)
						{
							this.Week2RoutineAdjustments();
							this.BakeSale.SetActive(true);
						}
					}
				}
				else
				{
					this.IdolStage.SetActive(false);
					if (this.Students[this.RivalID] != null)
					{
						if (this.Week == 3)
						{
							this.EightiesWeek3RoutineAdjustments();
						}
						else if (this.Week == 4)
						{
							this.EightiesWeek4RoutineAdjustments();
						}
						else if (this.Week == 5)
						{
							this.EightiesWeek5RoutineAdjustments();
						}
						else if (this.Week == 6)
						{
							this.EightiesWeek6RoutineAdjustments();
							this.IdolStage.SetActive(true);
						}
						else if (this.Week == 7)
						{
							this.EightiesWeek3RoutineAdjustments();
						}
						else if (this.Week == 8)
						{
							this.EightiesWeek8RoutineAdjustments();
						}
						else if (this.Week == 9)
						{
							this.EightiesWeek9RoutineAdjustments();
							this.PoolPhotoShootCameras.SetActive(true);
						}
						else if (this.Week == 10)
						{
							this.EightiesWeek10RoutineAdjustments();
						}
					}
					if (this.Students[this.RivalID] != null && this.Students[this.SuitorID] != null)
					{
						this.ChangeSuitorRoutine(this.SuitorID);
					}
				}
				if (this.SpawnNobody)
				{
					if (this.Week < 11)
					{
						this.TutorialActive = true;
						this.Tutorial.gameObject.SetActive(true);
						this.Tutorial.InstructionLabel.transform.parent.gameObject.SetActive(true);
					}
					if (SchoolGlobals.SchoolAtmosphere < 0.5f)
					{
						this.Clock.CameraEffects.UpdateBloom(1f);
						this.Clock.CameraEffects.UpdateBloomKnee(0.5f);
						this.Clock.CameraEffects.UpdateBloomRadius(4f);
					}
					else
					{
						this.Clock.CameraEffects.UpdateBloom(11f);
						this.Clock.CameraEffects.UpdateBloomKnee(1f);
						this.Clock.CameraEffects.UpdateBloomRadius(7f);
					}
					this.FPSDisplay.SetActive(false);
					this.FPSDisplayBG.SetActive(false);
				}
				if (!this.TutorialActive)
				{
					this.Tutorial.InstructionLabel.transform.parent.gameObject.SetActive(false);
				}
				this.UpdateAllBentos();
				this.FanCover.enabled = true;
				for (int j = 36; j < 41; j++)
				{
					if (this.Students[j] != null)
					{
						this.Students[j].transform.position = this.SpawnPositions[j].position;
					}
				}
				for (int j = 76; j < 90; j++)
				{
					if (this.Students[j] != null)
					{
						this.Students[j].transform.position = this.SpawnPositions[j].position;
					}
				}
				Physics.SyncTransforms();
				if (this.MissionMode)
				{
					this.Yandere.ChangeSchoolwear();
				}
				this.UpdateAllSleuthClothing();
			}
			if ((double)this.Clock.HourTime > 16.9)
			{
				this.CheckMusic();
			}
		}
		else if (this.NPCsSpawned < this.StudentsTotal + this.TeachersTotal)
		{
			this.Frame++;
			if (this.Frame == 1)
			{
				if (this.NewStudent != null)
				{
					UnityEngine.Object.Destroy(this.NewStudent);
				}
				if (this.Randomize)
				{
					int num = UnityEngine.Random.Range(0, 2);
					this.NewStudent = UnityEngine.Object.Instantiate<GameObject>((num == 0) ? this.PortraitChan : this.PortraitKun, Vector3.zero, Quaternion.identity);
				}
				else
				{
					this.NewStudent = UnityEngine.Object.Instantiate<GameObject>((this.JSON.Students[this.NPCsSpawned + 1].Gender == 0) ? this.PortraitChan : this.PortraitKun, Vector3.zero, Quaternion.identity);
				}
				CosmeticScript component = this.NewStudent.GetComponent<CosmeticScript>();
				component.StudentID = this.NPCsSpawned + 1;
				component.StudentManager = this;
				component.TakingPortrait = true;
				component.Randomize = this.Randomize;
				component.JSON = this.JSON;
				component.Student.enabled = false;
				component.Student.Prompt.enabled = false;
				component.Student.MyCollider.enabled = false;
				component.Student.Pathfinding.enabled = false;
				component.Student.MyRigidbody.useGravity = false;
				component.Student.DisableProps();
				if (component.Student.Male)
				{
					component.Student.DisableMaleProps();
				}
				else
				{
					component.Student.DisableFemaleProps();
				}
				StudentScript component2 = this.NewStudent.GetComponent<StudentScript>();
				component2.Yandere = this.Yandere;
				component2.SetSplashes(false);
				PromptScript[] componentsInChildren = component.gameObject.GetComponentsInChildren<PromptScript>();
				for (int k = 0; k < componentsInChildren.Length; k++)
				{
					componentsInChildren[k].enabled = false;
				}
				if (!this.Randomize)
				{
					this.NPCsSpawned++;
				}
			}
			if (this.Frame == 2)
			{
				ScreenCapture.CaptureScreenshot(string.Concat(new string[]
				{
					Application.streamingAssetsPath,
					"/Portraits",
					this.EightiesPrefix,
					"/Student_",
					this.NPCsSpawned.ToString(),
					".png"
				}));
				this.Frame = 0;
			}
		}
		else
		{
			ScreenCapture.CaptureScreenshot(string.Concat(new string[]
			{
				Application.streamingAssetsPath,
				"/Portraits",
				this.EightiesPrefix,
				"/Student_",
				this.NPCsSpawned.ToString(),
				".png"
			}));
			base.gameObject.SetActive(false);
		}
		if (this.Witnesses > 0)
		{
			this.ID = 1;
			while (this.ID < this.WitnessList.Length)
			{
				StudentScript studentScript = this.WitnessList[this.ID];
				if (studentScript != null && (!studentScript.Alive || studentScript.Attacked || studentScript.Dying || studentScript.Routine || (studentScript.Fleeing && !studentScript.PinningDown)))
				{
					studentScript.PinDownWitness = false;
					if (this.ID != this.WitnessList.Length - 1)
					{
						this.Shuffle(this.ID);
					}
					this.Witnesses--;
				}
				this.ID++;
			}
			if (this.PinningDown && this.Witnesses < 4)
			{
				Debug.Log("Students were going to pin Yandere-chan down, but now there are less than 4 witnesses, so it's not going to happen.");
				if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
				{
					this.Yandere.CanMove = true;
				}
				this.PinningDown = false;
				this.PinDownTimer = 0f;
				this.PinPhase = 0;
			}
		}
		if (this.PinningDown)
		{
			if (!this.Yandere.Attacking && this.Yandere.CanMove)
			{
				this.Yandere.CharacterAnimation.CrossFade("f02_pinDownPanic_00");
				this.Yandere.EmptyHands();
				this.Yandere.CanMove = false;
			}
			if (this.PinPhase == 1)
			{
				if (!this.Yandere.Attacking && !this.Yandere.Struggling)
				{
					this.PinTimer += Time.deltaTime;
				}
				if (this.PinTimer > 1f)
				{
					this.ID = 1;
					while (this.ID < 5)
					{
						StudentScript studentScript2 = this.WitnessList[this.ID];
						if (studentScript2 != null)
						{
							studentScript2.transform.position = new Vector3(studentScript2.transform.position.x, studentScript2.transform.position.y + 0.1f, studentScript2.transform.position.z);
							studentScript2.CurrentDestination = this.PinDownSpots[this.ID];
							studentScript2.Pathfinding.target = this.PinDownSpots[this.ID];
							studentScript2.SprintAnim = studentScript2.OriginalSprintAnim;
							studentScript2.DistanceToDestination = 100f;
							studentScript2.Pathfinding.speed = 5f;
							studentScript2.MyController.radius = 0f;
							studentScript2.PinningDown = true;
							studentScript2.Alarmed = false;
							studentScript2.Routine = false;
							studentScript2.Fleeing = true;
							studentScript2.AlarmTimer = 0f;
							studentScript2.SmartPhone.SetActive(false);
							studentScript2.Safe = true;
							studentScript2.Prompt.Hide();
							studentScript2.Prompt.enabled = false;
							StudentScript studentScript3 = studentScript2;
							string str = (studentScript3 != null) ? studentScript3.ToString() : null;
							string str2 = "'s current destination is ";
							Transform currentDestination = studentScript2.CurrentDestination;
							Debug.Log(str + str2 + ((currentDestination != null) ? currentDestination.ToString() : null));
						}
						this.ID++;
					}
					this.PinPhase++;
				}
			}
			else if (this.WitnessList[1].PinPhase == 0)
			{
				if (!this.Yandere.ShoulderCamera.Noticed && !this.Yandere.ShoulderCamera.HeartbrokenCamera.activeInHierarchy)
				{
					this.PinDownTimer += Time.deltaTime;
					if (this.PinDownTimer > 10f || (this.WitnessList[1].DistanceToDestination < 1f && this.WitnessList[2].DistanceToDestination < 1f && this.WitnessList[3].DistanceToDestination < 1f && this.WitnessList[4].DistanceToDestination < 1f))
					{
						this.Clock.StopTime = true;
						this.Yandere.HUD.enabled = false;
						if (this.Yandere.Aiming)
						{
							this.Yandere.StopAiming();
							this.Yandere.enabled = false;
						}
						this.Yandere.Mopping = false;
						this.Yandere.EmptyHands();
						AudioSource component3 = base.GetComponent<AudioSource>();
						component3.PlayOneShot(this.PinDownSFX);
						component3.PlayOneShot(this.YanderePinDown);
						this.Yandere.CharacterAnimation.CrossFade("f02_pinDown_00");
						this.Yandere.CanMove = false;
						this.Yandere.ShoulderCamera.LookDown = true;
						this.Yandere.RPGCamera.enabled = false;
						this.StopMoving();
						this.Yandere.ShoulderCamera.HeartbrokenCamera.GetComponent<Camera>().cullingMask |= 512;
						this.ID = 1;
						while (this.ID < 5)
						{
							StudentScript studentScript4 = this.WitnessList[this.ID];
							if (studentScript4.MyWeapon != null)
							{
								GameObjectUtils.SetLayerRecursively(studentScript4.MyWeapon.gameObject, 13);
							}
							studentScript4.CharacterAnimation.CrossFade(((studentScript4.Male ? "pinDown_0" : "f02_pinDown_0") + this.ID.ToString()).ToString());
							studentScript4.PinPhase++;
							this.ID++;
						}
					}
				}
			}
			else
			{
				bool flag = false;
				if (!this.WitnessList[1].Male)
				{
					if (this.WitnessList[1].CharacterAnimation["f02_pinDown_01"].time >= this.WitnessList[1].CharacterAnimation["f02_pinDown_01"].length)
					{
						flag = true;
					}
				}
				else if (this.WitnessList[1].CharacterAnimation["pinDown_01"].time >= this.WitnessList[1].CharacterAnimation["pinDown_01"].length)
				{
					flag = true;
				}
				if (flag)
				{
					this.Yandere.CharacterAnimation.CrossFade("f02_pinDownLoop_00");
					this.ID = 1;
					while (this.ID < 5)
					{
						StudentScript studentScript5 = this.WitnessList[this.ID];
						studentScript5.CharacterAnimation.CrossFade(((studentScript5.Male ? "pinDownLoop_0" : "f02_pinDownLoop_0") + this.ID.ToString()).ToString());
						this.ID++;
					}
					this.PinningDown = false;
				}
			}
		}
		if (this.Meeting)
		{
			this.UpdateMeeting();
		}
		if (this.Police != null && (this.Police.BloodParent.childCount > 0 || this.Police.LimbParent.childCount > 0 || this.Yandere.WeaponManager.MisplacedWeapons > 0))
		{
			this.CurrentID++;
			if (this.CurrentID > 97)
			{
				this.UpdateBlood();
				this.CurrentID = 1;
			}
			if (this.Students[this.CurrentID] == null)
			{
				this.CurrentID++;
			}
			else if (!this.Students[this.CurrentID].gameObject.activeInHierarchy)
			{
				this.CurrentID++;
			}
		}
		if (this.OpenCurtain)
		{
			this.OpenValue = Mathf.Lerp(this.OpenValue, 100f, Time.deltaTime * 10f);
			if (this.OpenValue > 99f)
			{
				this.OpenCurtain = false;
			}
			this.FemaleShowerCurtain.SetBlendShapeWeight(0, this.OpenValue);
		}
		if (this.AoT)
		{
			this.GrowTimer += Time.deltaTime;
			if (this.GrowTimer < 10f)
			{
				this.ID = 2;
				while (this.ID < this.Students.Length)
				{
					StudentScript studentScript6 = this.Students[this.ID];
					if (studentScript6 != null && studentScript6.transform.localScale.x < this.TargetSize[this.ID])
					{
						studentScript6.transform.localScale = Vector3.Lerp(studentScript6.transform.localScale, new Vector3(this.TargetSize[this.ID], this.TargetSize[this.ID], this.TargetSize[this.ID]), Time.deltaTime);
					}
					this.ID++;
				}
			}
		}
		if (this.Pose)
		{
			this.ID = 1;
			while (this.ID < this.Students.Length)
			{
				StudentScript studentScript7 = this.Students[this.ID];
				if (studentScript7 != null && studentScript7.Prompt.Label[0] != null)
				{
					studentScript7.Prompt.Label[0].text = "     Pose";
				}
				this.ID++;
			}
		}
		if (this.Yandere.Egg)
		{
			if (this.Sans)
			{
				this.ID = 1;
				while (this.ID < this.Students.Length)
				{
					StudentScript studentScript8 = this.Students[this.ID];
					if (studentScript8 != null && studentScript8.Prompt.Label[0] != null)
					{
						studentScript8.Prompt.Label[0].text = "     Psychokinesis";
					}
					this.ID++;
				}
			}
			if (this.Ebola)
			{
				this.ID = 2;
				while (this.ID < this.Students.Length)
				{
					StudentScript studentScript9 = this.Students[this.ID];
					if (studentScript9 != null && studentScript9.isActiveAndEnabled && studentScript9.DistanceToPlayer < 1f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.Yandere.EbolaEffect, studentScript9.transform.position + Vector3.up, Quaternion.identity);
						studentScript9.SpawnAlarmDisc();
						studentScript9.BecomeRagdoll();
						studentScript9.DeathType = DeathType.EasterEgg;
					}
					this.ID++;
				}
			}
			if (this.Yandere.Hunger >= 5)
			{
				this.ID = 2;
				while (this.ID < this.Students.Length)
				{
					StudentScript studentScript10 = this.Students[this.ID];
					if (studentScript10 != null && studentScript10.isActiveAndEnabled && studentScript10.DistanceToPlayer < 5f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.Yandere.DarkHelix, studentScript10.transform.position + Vector3.up, Quaternion.identity);
						studentScript10.SpawnAlarmDisc();
						studentScript10.BecomeRagdoll();
						studentScript10.DeathType = DeathType.EasterEgg;
					}
					this.ID++;
				}
			}
		}
		if (this.PlazaOccluder != null)
		{
			if (this.Yandere.transform.position.z < -50f)
			{
				this.PlazaOccluder.open = false;
			}
			else
			{
				this.PlazaOccluder.open = true;
			}
		}
		this.YandereVisible = false;
	}

	// Token: 0x06001D47 RID: 7495 RVA: 0x00163474 File Offset: 0x00161674
	public void SpawnStudent(int spawnID)
	{
		bool flag = false;
		if (this.Eighties)
		{
			if (spawnID > this.Week + this.WeekLimit && spawnID < 21)
			{
				flag = true;
			}
		}
		else
		{
			if (spawnID > 11 && spawnID < 21)
			{
				flag = true;
			}
			if (this.Week == 2 && spawnID == 12)
			{
				flag = false;
			}
		}
		if (this.JSON.Students[spawnID].Club != ClubType.Delinquent && StudentGlobals.GetStudentReputation(spawnID) < -100)
		{
			flag = true;
		}
		if (!flag && this.Students[spawnID] == null && !StudentGlobals.GetStudentDead(spawnID) && !StudentGlobals.GetStudentKidnapped(spawnID) && !StudentGlobals.GetStudentArrested(spawnID) && !StudentGlobals.GetStudentExpelled(spawnID))
		{
			int num;
			if (this.JSON.Students[spawnID].Name == "Random")
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.EmptyObject, new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f)), Quaternion.identity);
				while (gameObject.transform.position.x < 2.5f && gameObject.transform.position.x > -2.5f && gameObject.transform.position.z > -2.5f && gameObject.transform.position.z < 2.5f)
				{
					gameObject.transform.position = new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f));
				}
				gameObject.transform.parent = this.HidingSpots.transform;
				this.HidingSpots.List[spawnID] = gameObject.transform;
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.RandomPatrol, Vector3.zero, Quaternion.identity);
				gameObject2.transform.parent = this.Patrols.transform;
				this.Patrols.List[spawnID] = gameObject2.transform;
				GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.RandomPatrol, Vector3.zero, Quaternion.identity);
				gameObject3.transform.parent = this.CleaningSpots.transform;
				this.CleaningSpots.List[spawnID] = gameObject3.transform;
				num = ((this.MissionMode && MissionModeGlobals.MissionTarget == spawnID) ? 0 : UnityEngine.Random.Range(0, 2));
				this.FindUnoccupiedSeat();
			}
			else
			{
				num = this.JSON.Students[spawnID].Gender;
			}
			this.NewStudent = UnityEngine.Object.Instantiate<GameObject>((num == 0) ? this.StudentChan : this.StudentKun, this.SpawnPositions[spawnID].position, Quaternion.identity);
			CosmeticScript component = this.NewStudent.GetComponent<CosmeticScript>();
			component.LoveManager = this.LoveManager;
			component.StudentManager = this;
			component.Randomize = this.Randomize;
			component.StudentID = spawnID;
			component.JSON = this.JSON;
			if (this.JSON.Students[spawnID].Name == "Random")
			{
				this.NewStudent.GetComponent<StudentScript>().CleaningSpot = this.CleaningSpots.List[spawnID];
				this.NewStudent.GetComponent<StudentScript>().CleaningRole = 3;
			}
			if (this.JSON.Students[spawnID].Club == ClubType.Bully)
			{
				this.Bullies++;
			}
			this.Students[spawnID] = this.NewStudent.GetComponent<StudentScript>();
			StudentScript studentScript = this.Students[spawnID];
			studentScript.ChaseSelectiveGrayscale.desaturation = 1f - SchoolGlobals.SchoolAtmosphere;
			studentScript.Cosmetic.TextureManager = this.TextureManager;
			studentScript.WitnessCamera = this.WitnessCamera;
			studentScript.StudentManager = this;
			studentScript.StudentID = spawnID;
			studentScript.JSON = this.JSON;
			studentScript.BloodSpawnerIdentifier.ObjectID = "Student_" + spawnID.ToString() + "_BloodSpawner";
			studentScript.HipsIdentifier.ObjectID = "Student_" + spawnID.ToString() + "_Hips";
			studentScript.YanSave.ObjectID = "Student_" + spawnID.ToString();
			if (studentScript.Miyuki != null)
			{
				studentScript.Miyuki.Enemy = this.MiyukiCat;
			}
			if (this.AoT)
			{
				studentScript.AoT = true;
			}
			if (this.DK)
			{
				studentScript.DK = true;
			}
			if (this.Spooky)
			{
				studentScript.Spooky = true;
			}
			if (this.Sans)
			{
				studentScript.BadTime = true;
			}
			if (!this.MissionMode)
			{
				if (spawnID == this.RivalID)
				{
					studentScript.Rival = true;
					this.RedString.transform.parent = studentScript.LeftPinky;
					this.RedString.transform.localPosition = new Vector3(0f, 0f, 0f);
				}
				if (spawnID == 1)
				{
					this.RedString.Target = studentScript.LeftPinky;
				}
			}
			else if (spawnID == MissionModeGlobals.MissionTarget)
			{
				studentScript.Rival = true;
			}
			if (num == 0)
			{
				this.GirlsSpawned++;
				studentScript.GirlID = this.GirlsSpawned;
			}
			this.OccupySeat();
		}
		this.NPCsSpawned++;
		this.ForceSpawn = false;
	}

	// Token: 0x06001D48 RID: 7496 RVA: 0x001639A8 File Offset: 0x00161BA8
	public void UpdateStudents(int SpecificStudent = 0)
	{
		this.ID = 2;
		while (this.ID < this.Students.Length)
		{
			bool flag = false;
			if (SpecificStudent != 0)
			{
				this.ID = SpecificStudent;
				flag = true;
			}
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.CanTakeSnack = false;
				studentScript.CanGiveHelp = false;
				studentScript.CanBeFed = false;
				if (studentScript.gameObject.activeInHierarchy || studentScript.Hurry)
				{
					if (!studentScript.Safe)
					{
						if (!studentScript.Slave)
						{
							if (studentScript.Pushable)
							{
								studentScript.Prompt.Label[0].text = "     Push";
							}
							else if (this.Yandere.SpiderGrow)
							{
								if (!studentScript.Cosmetic.Empty)
								{
									studentScript.Prompt.Label[0].text = "     Send Husk";
								}
								else
								{
									studentScript.Prompt.Label[0].text = "     Talk";
								}
							}
							else if (!studentScript.Following)
							{
								studentScript.Prompt.Label[0].text = "     Talk";
							}
							else
							{
								studentScript.Prompt.Label[0].text = "     Stop";
							}
							studentScript.Prompt.HideButton[0] = false;
							studentScript.Prompt.HideButton[2] = false;
							studentScript.Prompt.Attack = false;
							if (this.Yandere.Mask != null || studentScript.Ragdoll.Zs.activeInHierarchy)
							{
								studentScript.Prompt.HideButton[0] = true;
							}
							if (this.Yandere.Dragging || this.Yandere.PickUp != null || this.Yandere.Chased)
							{
								studentScript.Prompt.HideButton[0] = true;
								studentScript.Prompt.HideButton[2] = true;
								if (this.Yandere.PickUp != null && !studentScript.Following)
								{
									if (this.Yandere.PickUp.Food > 0)
									{
										studentScript.Prompt.Label[0].text = "     Feed";
										studentScript.Prompt.HideButton[0] = false;
										studentScript.Prompt.HideButton[2] = true;
										studentScript.CanBeFed = true;
									}
									else if (this.Yandere.PickUp.Salty)
									{
										studentScript.Prompt.Label[0].text = "     Give Snack";
										studentScript.Prompt.HideButton[0] = false;
										studentScript.Prompt.HideButton[2] = true;
										studentScript.CanTakeSnack = true;
									}
									else if (this.Yandere.PickUp.StuckBoxCutter != null)
									{
										studentScript.Prompt.Label[0].text = "     Ask For Help";
										studentScript.Prompt.HideButton[0] = false;
										studentScript.Prompt.HideButton[2] = true;
										studentScript.CanGiveHelp = true;
									}
									else if (this.Yandere.PickUp.PuzzleCube)
									{
										studentScript.Prompt.Label[0].text = "     Give Puzzle";
										studentScript.Prompt.HideButton[0] = false;
										studentScript.Prompt.HideButton[2] = true;
									}
								}
							}
							if (this.Yandere.Armed)
							{
								studentScript.Prompt.HideButton[0] = true;
								studentScript.Prompt.Attack = true;
								studentScript.Prompt.MinimumDistanceSqr = 1f;
								studentScript.Prompt.MinimumDistance = 1f;
							}
							else
							{
								studentScript.Prompt.HideButton[2] = true;
								studentScript.Prompt.MinimumDistanceSqr = 2f;
								studentScript.Prompt.MinimumDistance = 2f;
								if (studentScript.WitnessedMurder || studentScript.WitnessedCorpse || studentScript.Private)
								{
									studentScript.Prompt.HideButton[0] = true;
								}
							}
							if (this.Yandere.NearBodies > 0 || this.Yandere.Sanity < 33.33333f)
							{
								studentScript.Prompt.HideButton[0] = true;
							}
							if (studentScript.Teacher)
							{
								if (this.Yandere.Bloodiness == 0f && (double)this.Yandere.Sanity > 66.66666 && !this.Yandere.Armed && !this.Yandere.StudentManager.WitnessCamera.Show && this.Yandere.StudentManager.ChaseCamera == null)
								{
									if (this.Police.Corpses > 0 || this.Police.LimbParent.childCount > 0 || this.Police.BloodParent.childCount > 0 || this.Police.BloodyClothing > 0 || this.Police.BloodyWeapons > 0)
									{
										this.CanSelfReport = true;
									}
									else
									{
										this.CanSelfReport = false;
									}
								}
								else
								{
									this.CanSelfReport = false;
								}
								if (this.CanSelfReport)
								{
									studentScript.Prompt.HideButton[0] = false;
									studentScript.Prompt.Label[0].text = "     Report Blood/Corpse";
								}
								else
								{
									studentScript.Prompt.HideButton[0] = true;
								}
							}
						}
						else if (!studentScript.FragileSlave)
						{
							if (this.Yandere.Armed)
							{
								if (this.Yandere.EquippedWeapon.Concealable)
								{
									studentScript.Prompt.HideButton[0] = false;
									studentScript.Prompt.Label[0].text = "     Give Weapon";
								}
								else
								{
									studentScript.Prompt.HideButton[0] = true;
									studentScript.Prompt.Label[0].text = string.Empty;
								}
							}
							else
							{
								studentScript.Prompt.HideButton[0] = true;
								studentScript.Prompt.Label[0].text = string.Empty;
							}
						}
					}
					if (studentScript.FightingSlave && this.Yandere.Armed)
					{
						Debug.Log("Fighting with a slave!");
						studentScript.Prompt.Label[0].text = "     Stab";
						studentScript.Prompt.HideButton[0] = false;
						studentScript.Prompt.HideButton[2] = true;
						studentScript.Prompt.enabled = true;
					}
					if (this.NoSpeech && !studentScript.Armband.activeInHierarchy)
					{
						studentScript.Prompt.HideButton[0] = true;
					}
				}
				if (studentScript.Prompt.Label[0] != null)
				{
					if (this.Sans)
					{
						studentScript.Prompt.HideButton[0] = false;
						studentScript.Prompt.Label[0].text = "     Psychokinesis";
					}
					if (this.Pose)
					{
						studentScript.Prompt.HideButton[0] = false;
						studentScript.Prompt.Label[0].text = "     Pose";
						studentScript.Prompt.BloodMask = 1;
						studentScript.Prompt.BloodMask |= 2;
						studentScript.Prompt.BloodMask |= 512;
						studentScript.Prompt.BloodMask |= 8192;
						studentScript.Prompt.BloodMask |= 16384;
						studentScript.Prompt.BloodMask |= 65536;
						studentScript.Prompt.BloodMask |= 2097152;
						studentScript.Prompt.BloodMask = ~studentScript.Prompt.BloodMask;
					}
					if (!studentScript.Teacher && this.Six)
					{
						studentScript.Prompt.MinimumDistance = 0.75f;
						studentScript.Prompt.HideButton[0] = false;
						studentScript.Prompt.Label[0].text = "     Eat";
					}
					if (this.Gaze)
					{
						studentScript.Prompt.MinimumDistance = 5f;
						studentScript.Prompt.HideButton[0] = false;
						studentScript.Prompt.Label[0].text = "     Gaze";
					}
				}
				if (this.EmptyDemon)
				{
					studentScript.Prompt.HideButton[0] = false;
				}
			}
			this.ID++;
			if (flag)
			{
				this.ID = this.Students.Length;
			}
		}
		this.Container.UpdatePrompts();
		for (int i = 1; i < this.TrashCans.Length; i++)
		{
			this.TrashCans[i].UpdatePrompt();
		}
	}

	// Token: 0x06001D49 RID: 7497 RVA: 0x001641FC File Offset: 0x001623FC
	public void UpdateMe(int ID)
	{
		if (ID > 1)
		{
			StudentScript studentScript = this.Students[ID];
			if (studentScript != null)
			{
				if (!studentScript.Safe)
				{
					studentScript.Prompt.Label[0].text = "     Talk";
					studentScript.Prompt.HideButton[0] = false;
					studentScript.Prompt.HideButton[2] = false;
					studentScript.Prompt.Attack = false;
					if (studentScript.FightingSlave)
					{
						if (this.Yandere.Armed && this.Yandere.EquippedWeapon.Type == WeaponType.Knife)
						{
							Debug.Log("Fighting with a slave!");
							studentScript.Prompt.Label[0].text = "     Stab";
							studentScript.Prompt.HideButton[0] = false;
							studentScript.Prompt.HideButton[2] = true;
							studentScript.Prompt.enabled = true;
						}
					}
					else
					{
						if (this.Yandere.Armed && this.OriginalUniforms + this.NewUniforms > 0)
						{
							studentScript.Prompt.HideButton[0] = true;
							studentScript.Prompt.MinimumDistance = 1f;
							studentScript.Prompt.Attack = true;
						}
						else
						{
							studentScript.Prompt.HideButton[2] = true;
							studentScript.Prompt.MinimumDistance = 2f;
							if (studentScript.WitnessedMurder || studentScript.WitnessedCorpse || studentScript.Private)
							{
								studentScript.Prompt.HideButton[0] = true;
							}
						}
						studentScript.Prompt.Label[2].text = "     Attack";
						if (studentScript.Drownable && !this.Yandere.Armed && this.Yandere.PickUp == null)
						{
							studentScript.Prompt.Label[2].text = "     Drown";
							studentScript.Prompt.HideButton[0] = true;
							studentScript.Prompt.HideButton[2] = false;
							studentScript.Prompt.MinimumDistance = 1f;
							studentScript.Prompt.Attack = true;
						}
						if (this.Yandere.Dragging || this.Yandere.PickUp != null || this.Yandere.Chased || this.Yandere.Chasers > 0)
						{
							studentScript.Prompt.HideButton[0] = true;
							studentScript.Prompt.HideButton[2] = true;
						}
						if (this.Yandere.NearBodies > 0 || this.Yandere.Sanity < 33.33333f)
						{
							studentScript.Prompt.HideButton[0] = true;
						}
						if (studentScript.Teacher)
						{
							if (this.Yandere.Bloodiness == 0f && (double)this.Yandere.Sanity > 66.66666 && !this.Yandere.StudentManager.WitnessCamera.Show && this.Yandere.StudentManager.ChaseCamera == null)
							{
								if (this.Police.Corpses > 0 || this.Police.LimbParent.childCount > 0 || this.Police.BloodParent.childCount > 0 || this.Police.BloodyClothing > 0 || this.Police.BloodyWeapons > 0)
								{
									this.CanSelfReport = true;
								}
								else
								{
									this.CanSelfReport = false;
								}
							}
							else
							{
								this.CanSelfReport = false;
							}
							if (this.CanSelfReport)
							{
								studentScript.Prompt.HideButton[0] = false;
								studentScript.Prompt.Label[0].text = "     Report Blood/Corpse";
							}
							else
							{
								studentScript.Prompt.HideButton[0] = true;
							}
						}
					}
				}
				if (this.Sans)
				{
					studentScript.Prompt.HideButton[0] = false;
					studentScript.Prompt.Label[0].text = "     Psychokinesis";
				}
				if (this.Pose)
				{
					studentScript.Prompt.HideButton[0] = false;
					studentScript.Prompt.Label[0].text = "     Pose";
				}
				if (this.NoSpeech || studentScript.Ragdoll.Zs.activeInHierarchy)
				{
					studentScript.Prompt.HideButton[0] = true;
				}
			}
		}
	}

	// Token: 0x06001D4A RID: 7498 RVA: 0x0016461C File Offset: 0x0016281C
	public void AttendClass()
	{
		this.ConvoManager.Confirmed = false;
		this.SleuthPhase = 3;
		if (this.RingEvent.EventActive)
		{
			this.RingEvent.ReturnRing();
		}
		while (this.NPCsSpawned < this.NPCsTotal)
		{
			this.SpawnStudent(this.SpawnID);
			this.SpawnID++;
		}
		if (this.Clock.LateStudent)
		{
			this.Clock.ActivateLateStudent();
		}
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				if (studentScript.Meeting)
				{
					studentScript.StopMeeting();
				}
				if (studentScript.WitnessedBloodPool && !studentScript.WitnessedMurder && !studentScript.WitnessedCorpse)
				{
					studentScript.Fleeing = false;
					studentScript.Alarmed = false;
					studentScript.AlarmTimer = 0f;
					studentScript.ReportPhase = 0;
					studentScript.WitnessedBloodPool = false;
				}
				if (studentScript.HoldingHands)
				{
					studentScript.HoldingHands = false;
					studentScript.Paired = false;
					studentScript.enabled = true;
				}
				if (studentScript.Alive && !studentScript.Slave && !studentScript.Tranquil && !studentScript.Fleeing && studentScript.enabled && studentScript.gameObject.activeInHierarchy)
				{
					if (!studentScript.Started)
					{
						studentScript.Start();
					}
					if (!studentScript.Teacher)
					{
						if (!studentScript.Indoors)
						{
							if (studentScript.ShoeRemoval.Locker == null)
							{
								studentScript.ShoeRemoval.Start();
							}
							studentScript.ShoeRemoval.PutOnShoes();
						}
						studentScript.transform.position = studentScript.Seat.position + Vector3.up * 0.01f;
						studentScript.transform.rotation = studentScript.Seat.rotation;
						studentScript.CharacterAnimation.Play(studentScript.SitAnim);
						studentScript.Pathfinding.canSearch = false;
						studentScript.Pathfinding.canMove = false;
						studentScript.Pathfinding.speed = 0f;
						studentScript.ClubActivityPhase = 0;
						studentScript.ClubTimer = 0f;
						studentScript.Patience = 5;
						studentScript.Pestered = 0;
						studentScript.Distracting = false;
						studentScript.Distracted = false;
						studentScript.Tripping = false;
						studentScript.Ignoring = false;
						studentScript.Pushable = false;
						studentScript.Private = false;
						studentScript.Sedated = false;
						studentScript.Emetic = false;
						studentScript.Hurry = false;
						studentScript.Safe = false;
						studentScript.CanTalk = true;
						studentScript.Routine = true;
						if (studentScript.Wet)
						{
							studentScript.CharacterAnimation[studentScript.WetAnim].weight = 0f;
							this.CommunalLocker.Student = null;
							studentScript.Schoolwear = 3;
							studentScript.ChangeSchoolwear();
							studentScript.LiquidProjector.enabled = false;
							studentScript.Splashed = false;
							studentScript.Bloody = false;
							studentScript.BathePhase = 1;
							studentScript.Wet = false;
							studentScript.UnWet();
							if (studentScript.Rival && this.CommunalLocker.RivalPhone.Stolen)
							{
								studentScript.RealizePhoneIsMissing();
							}
						}
						if (studentScript.ClubAttire)
						{
							studentScript.ChangeSchoolwear();
							studentScript.ClubAttire = false;
						}
						if (!studentScript.Male && studentScript.BikiniAttacher.enabled)
						{
							studentScript.ChangeSchoolwear();
						}
						if (studentScript.Schoolwear != 1)
						{
							if (!studentScript.BeenSplashed)
							{
								studentScript.Schoolwear = 1;
								studentScript.ChangeSchoolwear();
								studentScript.MustChangeClothing = false;
							}
							studentScript.SunbathePhase = 0;
						}
						if (studentScript.Meeting && this.Clock.HourTime > studentScript.MeetTime)
						{
							studentScript.Meeting = false;
						}
						if (studentScript.Club == ClubType.Sports)
						{
							studentScript.SetSplashes(false);
							studentScript.WalkAnim = studentScript.OriginalWalkAnim;
							studentScript.Character.transform.localPosition = new Vector3(0f, 0f, 0f);
							if (studentScript.Cosmetic.Goggles.Length != 0 && studentScript.Cosmetic.Goggles[studentScript.StudentID].GetComponent<SkinnedMeshRenderer>() != null)
							{
								studentScript.Cosmetic.Goggles[studentScript.StudentID].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 0f);
							}
							if (!studentScript.Cosmetic.Empty && studentScript.Male && studentScript.Cosmetic.MaleHair[studentScript.Cosmetic.Hairstyle].GetComponent<SkinnedMeshRenderer>() != null)
							{
								studentScript.Cosmetic.MaleHair[studentScript.Cosmetic.Hairstyle].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 0f);
							}
						}
						if (studentScript.MyPlate != null && studentScript.MyPlate.transform.parent == studentScript.RightHand)
						{
							studentScript.MyPlate.transform.parent = null;
							studentScript.MyPlate.transform.position = studentScript.OriginalPlatePosition;
							studentScript.MyPlate.transform.rotation = studentScript.OriginalPlateRotation;
							studentScript.IdleAnim = studentScript.OriginalIdleAnim;
							studentScript.WalkAnim = studentScript.OriginalWalkAnim;
						}
						if (studentScript.ReturningMisplacedWeapon)
						{
							studentScript.ReturnMisplacedWeapon();
						}
					}
					else if (this.ID != this.GymTeacherID && this.ID != this.NurseID)
					{
						studentScript.transform.position = this.Podiums.List[studentScript.Class].position + Vector3.up * 0.01f;
						studentScript.transform.rotation = this.Podiums.List[studentScript.Class].rotation;
					}
					else
					{
						studentScript.transform.position = studentScript.Seat.position + Vector3.up * 0.01f;
						studentScript.transform.rotation = studentScript.Seat.rotation;
					}
				}
			}
			this.ID++;
		}
		this.UpdateStudents(0);
		if (GameGlobals.SenpaiMourning)
		{
			this.Students[1].gameObject.SetActive(false);
			this.Students[1].transform.position = new Vector3(0f, 100f, 0f);
		}
		Physics.SyncTransforms();
		for (int i = 1; i < 10; i++)
		{
			if (this.ShrineCollectibles[i] != null)
			{
				this.ShrineCollectibles[i].SetActive(true);
			}
		}
		this.Gift.SetActive(false);
	}

	// Token: 0x06001D4B RID: 7499 RVA: 0x00164C94 File Offset: 0x00162E94
	public void SkipTo8()
	{
		while (this.NPCsSpawned < this.NPCsTotal)
		{
			this.SpawnStudent(this.SpawnID);
			this.SpawnID++;
		}
		int num = 0;
		int num2 = 0;
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && studentScript.Alive && !studentScript.Slave && !studentScript.Tranquil)
			{
				if (!studentScript.Started)
				{
					studentScript.Start();
				}
				bool flag = false;
				if (this.MemorialScene.enabled && studentScript.Teacher)
				{
					flag = true;
					studentScript.Teacher = false;
				}
				if (!studentScript.Teacher)
				{
					if (!studentScript.Indoors)
					{
						if (studentScript.ShoeRemoval.Locker == null)
						{
							studentScript.ShoeRemoval.Start();
						}
						studentScript.ShoeRemoval.PutOnShoes();
					}
					studentScript.transform.position = studentScript.Seat.position + Vector3.up * 0.01f;
					studentScript.transform.rotation = studentScript.Seat.rotation;
					if (studentScript.StudentID == 10 && this.Students[11] != null)
					{
						studentScript.transform.position = this.Students[11].transform.position;
					}
					Physics.SyncTransforms();
					studentScript.Pathfinding.canSearch = true;
					studentScript.Pathfinding.canMove = true;
					studentScript.Pathfinding.speed = 1f;
					studentScript.ClubActivityPhase = 0;
					studentScript.Distracted = false;
					studentScript.Spawned = true;
					studentScript.Routine = true;
					studentScript.Safe = false;
					studentScript.SprintAnim = studentScript.OriginalSprintAnim;
					if (studentScript.ClubAttire)
					{
						studentScript.ChangeSchoolwear();
						studentScript.ClubAttire = true;
					}
					studentScript.TeleportToDestination();
					studentScript.TeleportToDestination();
				}
				else
				{
					studentScript.TeleportToDestination();
					studentScript.TeleportToDestination();
				}
				if (this.MemorialScene.enabled)
				{
					if (flag)
					{
						studentScript.Teacher = true;
					}
					if (studentScript.Persona == PersonaType.PhoneAddict)
					{
						studentScript.SmartPhone.SetActive(true);
					}
					if (studentScript.Actions[studentScript.Phase] == StudentActionType.Graffiti && !this.Bully)
					{
						ScheduleBlock scheduleBlock = studentScript.ScheduleBlocks[2];
						scheduleBlock.destination = "Patrol";
						scheduleBlock.action = "Patrol";
						studentScript.GetDestinations();
					}
					studentScript.SpeechLines.Stop();
					studentScript.transform.position = new Vector3(20f + (float)num * 1.1f, 0f, (float)(82 - num2 * 5));
					num2++;
					if (num2 > 4)
					{
						num++;
						num2 = 0;
					}
				}
			}
			this.ID++;
		}
	}

	// Token: 0x06001D4C RID: 7500 RVA: 0x00164F54 File Offset: 0x00163154
	public void SkipTo730()
	{
		while (this.NPCsSpawned < this.NPCsTotal)
		{
			this.SpawnStudent(this.SpawnID);
			this.SpawnID++;
		}
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && studentScript.Alive && !studentScript.Slave && !studentScript.Tranquil)
			{
				if (!studentScript.Started)
				{
					studentScript.Start();
				}
				if (!studentScript.Teacher)
				{
					if (!studentScript.Indoors)
					{
						if (studentScript.ShoeRemoval.Locker == null)
						{
							studentScript.ShoeRemoval.Start();
						}
						studentScript.ShoeRemoval.PutOnShoes();
					}
					studentScript.transform.position = studentScript.Seat.position + Vector3.up * 0.01f;
					studentScript.transform.rotation = studentScript.Seat.rotation;
					studentScript.Pathfinding.canSearch = true;
					studentScript.Pathfinding.canMove = true;
					studentScript.Pathfinding.speed = 1f;
					studentScript.ClubActivityPhase = 0;
					studentScript.Distracted = false;
					studentScript.Spawned = true;
					studentScript.Routine = true;
					studentScript.Safe = false;
					studentScript.SprintAnim = studentScript.OriginalSprintAnim;
					if (studentScript.ClubAttire)
					{
						studentScript.ChangeSchoolwear();
						studentScript.ClubAttire = true;
					}
					studentScript.AltTeleportToDestination();
					studentScript.AltTeleportToDestination();
				}
				else
				{
					studentScript.AltTeleportToDestination();
					studentScript.AltTeleportToDestination();
				}
			}
			this.ID++;
		}
		Physics.SyncTransforms();
	}

	// Token: 0x06001D4D RID: 7501 RVA: 0x00165108 File Offset: 0x00163308
	public void ResumeMovement()
	{
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && !studentScript.Fleeing)
			{
				studentScript.Pathfinding.canSearch = true;
				studentScript.Pathfinding.canMove = true;
				studentScript.Pathfinding.speed = 1f;
				if (!studentScript.TurnOffRadio)
				{
					studentScript.Routine = true;
				}
			}
			this.ID++;
		}
	}

	// Token: 0x06001D4E RID: 7502 RVA: 0x00165194 File Offset: 0x00163394
	public void UpdateAllSleuthClothing()
	{
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && studentScript.Persona == PersonaType.Sleuth)
			{
				if (!studentScript.Male)
				{
					studentScript.Cosmetic.SetFemaleUniform();
				}
				else
				{
					studentScript.Cosmetic.SetMaleUniform();
				}
			}
			this.ID++;
		}
	}

	// Token: 0x06001D4F RID: 7503 RVA: 0x0016520C File Offset: 0x0016340C
	public void StopMoving()
	{
		this.CombatMinigame.enabled = false;
		this.Stop = true;
		if (this.GameOverIminent)
		{
			this.Portal.GetComponent<PortalScript>().EndEvents();
			this.Portal.GetComponent<PortalScript>().EndLaterEvents();
		}
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				if (!studentScript.Dying && !studentScript.PinningDown && !studentScript.Spraying && !studentScript.Struggling && !studentScript.Drowned)
				{
					if (this.YandereDying && studentScript.Club != ClubType.Council)
					{
						studentScript.IdleAnim = studentScript.ScaredAnim;
					}
					if (this.Yandere.Attacking)
					{
						if (studentScript.MurderReaction == 0 && !studentScript.Blind)
						{
							studentScript.Character.GetComponent<Animation>().CrossFade(studentScript.ScaredAnim);
						}
					}
					else if (this.ID > 1 && studentScript.CharacterAnimation != null)
					{
						studentScript.CharacterAnimation.CrossFade(studentScript.IdleAnim);
					}
					studentScript.Pathfinding.canSearch = false;
					studentScript.Pathfinding.canMove = false;
					studentScript.Pathfinding.speed = 0f;
					studentScript.Stop = true;
					if (studentScript.EventManager != null)
					{
						studentScript.EventManager.EndEvent();
					}
				}
				if (studentScript.Alive)
				{
					if (studentScript.SawMask)
					{
						this.Police.MaskReported = true;
					}
					if (studentScript.Slave && this.Police.DayOver)
					{
						Debug.Log("A mind-broken slave committed suicide.");
						studentScript.Broken.Subtitle.text = string.Empty;
						studentScript.Broken.Done = true;
						UnityEngine.Object.Destroy(studentScript.Broken);
						studentScript.BecomeRagdoll();
						studentScript.Slave = false;
						studentScript.Suicide = true;
						studentScript.DeathType = DeathType.Mystery;
						StudentGlobals.StudentSlave = studentScript.StudentID;
					}
				}
			}
			this.ID++;
		}
	}

	// Token: 0x06001D50 RID: 7504 RVA: 0x00165428 File Offset: 0x00163628
	public void TimeFreeze()
	{
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && studentScript.Alive)
			{
				studentScript.enabled = false;
				studentScript.CharacterAnimation.Stop();
				studentScript.Pathfinding.canSearch = false;
				studentScript.Pathfinding.canMove = false;
				studentScript.Prompt.Hide();
				studentScript.Prompt.enabled = false;
			}
			this.ID++;
		}
	}

	// Token: 0x06001D51 RID: 7505 RVA: 0x001654BC File Offset: 0x001636BC
	public void TimeUnfreeze()
	{
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && studentScript.Alive)
			{
				studentScript.enabled = true;
				studentScript.Prompt.enabled = true;
				studentScript.Pathfinding.canSearch = true;
				studentScript.Pathfinding.canMove = true;
			}
			this.ID++;
		}
	}

	// Token: 0x06001D52 RID: 7506 RVA: 0x0016553C File Offset: 0x0016373C
	public void ComeBack()
	{
		this.Stop = false;
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && (!this.Police.EndOfDay.Counselor.ExpelledDelinquents || this.ID <= 75 || this.ID >= 81))
			{
				if (!studentScript.Dying && !studentScript.Replaced && studentScript.Spawned && !StudentGlobals.GetStudentExpelled(this.ID) && !StudentGlobals.GetStudentArrested(this.ID) && !studentScript.Ragdoll.Disposed)
				{
					studentScript.gameObject.SetActive(true);
					studentScript.Pathfinding.canSearch = true;
					studentScript.Pathfinding.canMove = true;
					studentScript.Pathfinding.speed = 1f;
					studentScript.Stop = false;
				}
				if (studentScript.Teacher)
				{
					studentScript.CurrentDestination = studentScript.Destinations[studentScript.Phase];
					studentScript.Pathfinding.target = studentScript.Destinations[studentScript.Phase];
					studentScript.Alarmed = false;
					studentScript.Reacted = false;
					studentScript.Witness = false;
					studentScript.Routine = true;
					studentScript.AlarmTimer = 0f;
					studentScript.Concern = 0;
				}
				if (studentScript.Club == ClubType.Council)
				{
					studentScript.Teacher = false;
				}
				if (studentScript.Slave)
				{
					studentScript.Stop = false;
				}
			}
			this.ID++;
		}
		this.UpdateAllAnimLayers();
		if (this.Police.EndOfDay.RivalEliminationMethod == RivalEliminationType.Expelled || this.Police.EndOfDay.RivalEliminationMethod == RivalEliminationType.Arrested)
		{
			this.Students[this.RivalID].gameObject.SetActive(false);
		}
		if (GameGlobals.SenpaiMourning)
		{
			this.Students[1].gameObject.SetActive(false);
		}
		this.Yandere.SetAnimationLayers();
	}

	// Token: 0x06001D53 RID: 7507 RVA: 0x0016572C File Offset: 0x0016392C
	public void StopFleeing()
	{
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && !studentScript.Teacher)
			{
				studentScript.Pathfinding.target = studentScript.Destinations[studentScript.Phase];
				studentScript.Pathfinding.speed = 1f;
				studentScript.WitnessedCorpse = false;
				studentScript.WitnessedMurder = false;
				studentScript.Alarmed = false;
				studentScript.Fleeing = false;
				studentScript.Reacted = false;
				studentScript.Witness = false;
				studentScript.Routine = true;
			}
			this.ID++;
		}
	}

	// Token: 0x06001D54 RID: 7508 RVA: 0x001657E0 File Offset: 0x001639E0
	public void EnablePrompts()
	{
		this.ID = 2;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.Prompt.enabled = true;
			}
			this.ID++;
		}
	}

	// Token: 0x06001D55 RID: 7509 RVA: 0x00165838 File Offset: 0x00163A38
	public void DisablePrompts()
	{
		this.ID = 2;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.Prompt.Hide();
				studentScript.Prompt.enabled = false;
			}
			this.ID++;
		}
	}

	// Token: 0x06001D56 RID: 7510 RVA: 0x0016589C File Offset: 0x00163A9C
	public void WipePendingRep()
	{
		this.ID = 2;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.PendingRep = 0f;
			}
			this.ID++;
		}
	}

	// Token: 0x06001D57 RID: 7511 RVA: 0x001658F4 File Offset: 0x00163AF4
	public void AttackOnTitan()
	{
		this.RandomizeRoutines();
		this.Students[1].Blind = true;
		this.AoT = true;
		this.ID = 2;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.AttackOnTitan();
			}
			this.ID++;
		}
	}

	// Token: 0x06001D58 RID: 7512 RVA: 0x00165960 File Offset: 0x00163B60
	public void Kong()
	{
		this.DK = true;
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.DK = true;
			}
			this.ID++;
		}
	}

	// Token: 0x06001D59 RID: 7513 RVA: 0x001659BC File Offset: 0x00163BBC
	public void Spook()
	{
		this.Spooky = true;
		this.ID = 2;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && !studentScript.Male)
			{
				studentScript.Spook();
			}
			this.ID++;
		}
	}

	// Token: 0x06001D5A RID: 7514 RVA: 0x00165A1C File Offset: 0x00163C1C
	public void BadTime()
	{
		this.Sans = true;
		this.ID = 2;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.Prompt.HideButton[0] = false;
				studentScript.BadTime = true;
			}
			this.ID++;
		}
	}

	// Token: 0x06001D5B RID: 7515 RVA: 0x00165A84 File Offset: 0x00163C84
	public void UpdateBooths()
	{
		this.ID = 0;
		while (this.ID < this.ChangingBooths.Length)
		{
			ChangingBoothScript changingBoothScript = this.ChangingBooths[this.ID];
			if (changingBoothScript != null)
			{
				changingBoothScript.CheckYandereClub();
			}
			this.ID++;
		}
	}

	// Token: 0x06001D5C RID: 7516 RVA: 0x00165AD8 File Offset: 0x00163CD8
	public void UpdatePerception()
	{
		this.ID = 0;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.UpdatePerception();
			}
			this.ID++;
		}
	}

	// Token: 0x06001D5D RID: 7517 RVA: 0x00165B2C File Offset: 0x00163D2C
	public void StopHesitating()
	{
		this.ID = 0;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				if (studentScript.AlarmTimer > 0f)
				{
					studentScript.AlarmTimer = 1f;
				}
				studentScript.Hesitation = 0f;
			}
			this.ID++;
		}
	}

	// Token: 0x06001D5E RID: 7518 RVA: 0x00165B9C File Offset: 0x00163D9C
	public void Unstop()
	{
		this.ID = 0;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.Stop = false;
			}
			this.ID++;
		}
	}

	// Token: 0x06001D5F RID: 7519 RVA: 0x00165BF0 File Offset: 0x00163DF0
	public void LowerCorpsePosition()
	{
		int num;
		if (this.CorpseLocation.position.y < 2f)
		{
			num = 0;
		}
		else if (this.CorpseLocation.position.y < 4f)
		{
			num = 2;
		}
		else if (this.CorpseLocation.position.y < 6f)
		{
			num = 4;
		}
		else if (this.CorpseLocation.position.y < 8f)
		{
			num = 6;
		}
		else if (this.CorpseLocation.position.y < 10f)
		{
			num = 8;
		}
		else if (this.CorpseLocation.position.y < 12f)
		{
			num = 10;
		}
		else
		{
			num = 12;
		}
		this.CorpseLocation.position = new Vector3(this.CorpseLocation.position.x, (float)num, this.CorpseLocation.position.z);
	}

	// Token: 0x06001D60 RID: 7520 RVA: 0x00165CDC File Offset: 0x00163EDC
	public void LowerBloodPosition()
	{
		int num;
		if (this.BloodLocation.position.y < 2f)
		{
			num = 0;
		}
		else if (this.BloodLocation.position.y < 4f)
		{
			num = 2;
		}
		else if (this.BloodLocation.position.y < 6f)
		{
			num = 4;
		}
		else if (this.BloodLocation.position.y < 8f)
		{
			num = 6;
		}
		else if (this.BloodLocation.position.y < 10f)
		{
			num = 8;
		}
		else if (this.BloodLocation.position.y < 12f)
		{
			num = 10;
		}
		else
		{
			num = 12;
		}
		this.BloodLocation.position = new Vector3(this.BloodLocation.position.x, (float)num, this.BloodLocation.position.z);
	}

	// Token: 0x06001D61 RID: 7521 RVA: 0x00165DC8 File Offset: 0x00163FC8
	public void CensorStudents()
	{
		this.ID = 0;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && !studentScript.Male && studentScript.Club != ClubType.Teacher && studentScript.Club != ClubType.GymTeacher && studentScript.Club != ClubType.Nurse)
			{
				if (GameGlobals.CensorPanties)
				{
					studentScript.Cosmetic.CensorPanties();
				}
				else
				{
					studentScript.Cosmetic.RemoveCensor();
				}
			}
			this.ID++;
		}
	}

	// Token: 0x06001D62 RID: 7522 RVA: 0x00165E58 File Offset: 0x00164058
	private void OccupySeat()
	{
		int @class = this.JSON.Students[this.SpawnID].Class;
		int seat = this.JSON.Students[this.SpawnID].Seat;
		if (@class == 11)
		{
			this.SeatsTaken11[seat] = true;
			return;
		}
		if (@class == 12)
		{
			this.SeatsTaken12[seat] = true;
			return;
		}
		if (@class == 21)
		{
			this.SeatsTaken21[seat] = true;
			return;
		}
		if (@class == 22)
		{
			this.SeatsTaken22[seat] = true;
			return;
		}
		if (@class == 31)
		{
			this.SeatsTaken31[seat] = true;
			return;
		}
		if (@class == 32)
		{
			this.SeatsTaken32[seat] = true;
		}
	}

	// Token: 0x06001D63 RID: 7523 RVA: 0x00165EF0 File Offset: 0x001640F0
	private void FindUnoccupiedSeat()
	{
		this.SeatOccupied = false;
		if (this.Class == 1)
		{
			this.JSON.Students[this.SpawnID].Class = 11;
			this.ID = 1;
			while (this.ID < this.SeatsTaken11.Length)
			{
				if (this.SeatOccupied)
				{
					break;
				}
				if (!this.SeatsTaken11[this.ID])
				{
					this.JSON.Students[this.SpawnID].Seat = this.ID;
					this.SeatsTaken11[this.ID] = true;
					this.SeatOccupied = true;
				}
				this.ID++;
				if (this.ID > 15)
				{
					this.Class++;
				}
			}
		}
		else if (this.Class == 2)
		{
			this.JSON.Students[this.SpawnID].Class = 12;
			this.ID = 1;
			while (this.ID < this.SeatsTaken12.Length)
			{
				if (this.SeatOccupied)
				{
					break;
				}
				if (!this.SeatsTaken12[this.ID])
				{
					this.JSON.Students[this.SpawnID].Seat = this.ID;
					this.SeatsTaken12[this.ID] = true;
					this.SeatOccupied = true;
				}
				this.ID++;
				if (this.ID > 15)
				{
					this.Class++;
				}
			}
		}
		else if (this.Class == 3)
		{
			this.JSON.Students[this.SpawnID].Class = 21;
			this.ID = 1;
			while (this.ID < this.SeatsTaken21.Length)
			{
				if (this.SeatOccupied)
				{
					break;
				}
				if (!this.SeatsTaken21[this.ID])
				{
					this.JSON.Students[this.SpawnID].Seat = this.ID;
					this.SeatsTaken21[this.ID] = true;
					this.SeatOccupied = true;
				}
				this.ID++;
				if (this.ID > 15)
				{
					this.Class++;
				}
			}
		}
		else if (this.Class == 4)
		{
			this.JSON.Students[this.SpawnID].Class = 22;
			this.ID = 1;
			while (this.ID < this.SeatsTaken22.Length)
			{
				if (this.SeatOccupied)
				{
					break;
				}
				if (!this.SeatsTaken22[this.ID])
				{
					this.JSON.Students[this.SpawnID].Seat = this.ID;
					this.SeatsTaken22[this.ID] = true;
					this.SeatOccupied = true;
				}
				this.ID++;
				if (this.ID > 15)
				{
					this.Class++;
				}
			}
		}
		else if (this.Class == 5)
		{
			this.JSON.Students[this.SpawnID].Class = 31;
			this.ID = 1;
			while (this.ID < this.SeatsTaken31.Length)
			{
				if (this.SeatOccupied)
				{
					break;
				}
				if (!this.SeatsTaken31[this.ID])
				{
					this.JSON.Students[this.SpawnID].Seat = this.ID;
					this.SeatsTaken31[this.ID] = true;
					this.SeatOccupied = true;
				}
				this.ID++;
				if (this.ID > 15)
				{
					this.Class++;
				}
			}
		}
		else if (this.Class == 6)
		{
			this.JSON.Students[this.SpawnID].Class = 32;
			this.ID = 1;
			while (this.ID < this.SeatsTaken32.Length && !this.SeatOccupied)
			{
				if (!this.SeatsTaken32[this.ID])
				{
					this.JSON.Students[this.SpawnID].Seat = this.ID;
					this.SeatsTaken32[this.ID] = true;
					this.SeatOccupied = true;
				}
				this.ID++;
				if (this.ID > 15)
				{
					this.Class++;
				}
			}
		}
		if (!this.SeatOccupied)
		{
			this.FindUnoccupiedSeat();
		}
	}

	// Token: 0x06001D64 RID: 7524 RVA: 0x00166358 File Offset: 0x00164558
	public void PinDownCheck()
	{
		if (!this.PinningDown && this.Witnesses > 3)
		{
			this.ID = 1;
			while (this.ID < this.WitnessList.Length)
			{
				StudentScript studentScript = this.WitnessList[this.ID];
				if (studentScript != null && (!studentScript.Alive || studentScript.Attacked || studentScript.Fleeing || studentScript.Dying || studentScript.Routine))
				{
					if (this.ID != this.WitnessList.Length - 1)
					{
						this.Shuffle(this.ID);
					}
					this.Witnesses--;
				}
				this.ID++;
			}
			if (this.Witnesses > 3)
			{
				this.PinningDown = true;
				this.PinPhase = 1;
			}
		}
	}

	// Token: 0x06001D65 RID: 7525 RVA: 0x0016642C File Offset: 0x0016462C
	private void Shuffle(int Start)
	{
		for (int i = Start; i < this.WitnessList.Length - 1; i++)
		{
			this.WitnessList[i] = this.WitnessList[i + 1];
		}
	}

	// Token: 0x06001D66 RID: 7526 RVA: 0x00166460 File Offset: 0x00164660
	public void RemovePapersFromDesks()
	{
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && studentScript.MyPaper != null)
			{
				studentScript.MyPaper.SetActive(false);
			}
			this.ID++;
		}
	}

	// Token: 0x06001D67 RID: 7527 RVA: 0x001664C8 File Offset: 0x001646C8
	public void SetStudentsActive(bool active)
	{
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.gameObject.SetActive(active);
			}
			this.ID++;
		}
	}

	// Token: 0x06001D68 RID: 7528 RVA: 0x00166520 File Offset: 0x00164720
	public void AssignTeachers()
	{
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.MyTeacher = this.Teachers[this.JSON.Students[studentScript.StudentID].Class];
			}
			this.ID++;
		}
	}

	// Token: 0x06001D69 RID: 7529 RVA: 0x00166590 File Offset: 0x00164790
	public void ToggleBookBags()
	{
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.BookBag.SetActive(!studentScript.BookBag.activeInHierarchy);
			}
			this.ID++;
		}
	}

	// Token: 0x06001D6A RID: 7530 RVA: 0x001665F4 File Offset: 0x001647F4
	public void DetermineVictim()
	{
		this.Bully = false;
		this.ID = 2;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && this.StudentReps[this.ID] < -33.33333f && (this.ID != 36 || this.TaskManager.TaskStatus[36] != 3) && !studentScript.Teacher && !studentScript.Slave && studentScript.Club != ClubType.Bully && studentScript.Club != ClubType.Council && studentScript.Club != ClubType.Photography && studentScript.Club != ClubType.Delinquent && this.StudentReps[this.ID] < this.LowestRep)
			{
				bool flag = false;
				if (!this.Eighties && this.ID == 11)
				{
					flag = true;
					if (this.Students[10] == null)
					{
						flag = false;
					}
					else if (this.Students[10].FollowTarget == null)
					{
						flag = false;
					}
				}
				if (!flag)
				{
					this.LowestRep = this.StudentReps[this.ID];
					this.VictimID = this.ID;
					this.Bully = true;
				}
			}
			this.ID++;
		}
		if (this.Bully)
		{
			if (this.Students[this.VictimID].Seat.position.x > 0f)
			{
				this.BullyGroup.position = this.Students[this.VictimID].Seat.position + new Vector3(0.33333f, 0f, 0f);
			}
			else
			{
				this.BullyGroup.position = this.Students[this.VictimID].Seat.position - new Vector3(0.33333f, 0f, 0f);
				this.BullyGroup.eulerAngles = new Vector3(0f, 90f, 0f);
			}
			StudentScript studentScript2 = this.Students[this.VictimID];
			if (!this.Students[this.VictimID].Rival)
			{
				ScheduleBlock scheduleBlock = studentScript2.ScheduleBlocks[2];
				scheduleBlock.destination = "ShameSpot";
				scheduleBlock.action = "Shamed";
				scheduleBlock.time = 8f;
			}
			ScheduleBlock scheduleBlock2 = studentScript2.ScheduleBlocks[4];
			scheduleBlock2.destination = "Seat";
			scheduleBlock2.action = "Sit";
			ScheduleBlock scheduleBlock3 = studentScript2.ScheduleBlocks[7];
			scheduleBlock3.destination = "ShameSpot";
			scheduleBlock3.action = "Shamed";
			if (studentScript2.Male)
			{
				studentScript2.ChemistScanner.MyRenderer.materials[1].mainTexture = studentScript2.ChemistScanner.SadEyes;
				studentScript2.ChemistScanner.enabled = false;
			}
			studentScript2.IdleAnim = studentScript2.BulliedIdleAnim;
			studentScript2.WalkAnim = studentScript2.BulliedWalkAnim;
			studentScript2.Bullied = true;
			studentScript2.GetDestinations();
			studentScript2.CameraAnims = studentScript2.CowardAnims;
			studentScript2.BusyAtLunch = true;
			studentScript2.Shy = false;
		}
	}

	// Token: 0x06001D6B RID: 7531 RVA: 0x0016690C File Offset: 0x00164B0C
	public void SecurityCameras()
	{
		this.Egg = true;
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && studentScript.SecurityCamera != null && studentScript.Alive)
			{
				Debug.Log("Enabling security camera on this character's head.");
				studentScript.SecurityCamera.SetActive(true);
			}
			this.ID++;
		}
	}

	// Token: 0x06001D6C RID: 7532 RVA: 0x0016698C File Offset: 0x00164B8C
	public void DisableEveryone()
	{
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && !studentScript.Ragdoll.enabled)
			{
				studentScript.gameObject.SetActive(false);
			}
			this.ID++;
		}
	}

	// Token: 0x06001D6D RID: 7533 RVA: 0x001669F0 File Offset: 0x00164BF0
	public void DisableStudent(int DisableID)
	{
		StudentScript studentScript = this.Students[DisableID];
		if (studentScript != null)
		{
			if (studentScript.gameObject.activeInHierarchy)
			{
				studentScript.gameObject.SetActive(false);
				return;
			}
			studentScript.gameObject.SetActive(true);
			this.UpdateOneAnimLayer(DisableID);
			this.Students[DisableID].ReadPhase = 0;
		}
	}

	// Token: 0x06001D6E RID: 7534 RVA: 0x00166A4A File Offset: 0x00164C4A
	public void UpdateOneAnimLayer(int DisableID)
	{
		this.Students[DisableID].UpdateAnimLayers();
		this.Students[DisableID].ReadPhase = 0;
	}

	// Token: 0x06001D6F RID: 7535 RVA: 0x00166A68 File Offset: 0x00164C68
	public void UpdateAllAnimLayers()
	{
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.UpdateAnimLayers();
				studentScript.ReadPhase = 0;
			}
			this.ID++;
		}
	}

	// Token: 0x06001D70 RID: 7536 RVA: 0x00166AC0 File Offset: 0x00164CC0
	public void UpdateGraffiti()
	{
		this.ID = 1;
		while (this.ID < 6)
		{
			if (!this.NoBully[this.ID])
			{
				this.Graffiti[this.ID].SetActive(true);
			}
			this.ID++;
		}
	}

	// Token: 0x06001D71 RID: 7537 RVA: 0x00166B10 File Offset: 0x00164D10
	public void UpdateAllBentos()
	{
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && !studentScript.MyBento.Tampered)
			{
				studentScript.MyBento.Prompt.Yandere = this.Yandere;
				studentScript.MyBento.UpdatePrompts();
			}
			this.ID++;
		}
	}

	// Token: 0x06001D72 RID: 7538 RVA: 0x00166B8C File Offset: 0x00164D8C
	public void UpdateSleuths()
	{
		this.SleuthPhase++;
		this.ID = 56;
		while (this.ID < 61)
		{
			if (this.Students[this.ID] != null && !this.Students[this.ID].Slave && !this.Students[this.ID].Following && !this.Students[this.ID].Meeting && !this.Students[this.ID].SentToLocker)
			{
				if (this.SleuthPhase < 3)
				{
					this.Students[this.ID].SleuthTarget = this.SleuthDestinations[this.ID - 55];
					this.Students[this.ID].Pathfinding.target = this.Students[this.ID].SleuthTarget;
					this.Students[this.ID].CurrentDestination = this.Students[this.ID].SleuthTarget;
				}
				else if (this.SleuthPhase == 3)
				{
					this.Students[this.ID].GetSleuthTarget();
				}
				else if (this.SleuthPhase == 4)
				{
					this.Students[this.ID].SleuthTarget = this.Clubs.List[this.ID];
					this.Students[this.ID].Pathfinding.target = this.Students[this.ID].SleuthTarget;
					this.Students[this.ID].CurrentDestination = this.Students[this.ID].SleuthTarget;
				}
				this.Students[this.ID].SmartPhone.SetActive(true);
				this.Students[this.ID].SpeechLines.Stop();
			}
			this.ID++;
		}
	}

	// Token: 0x06001D73 RID: 7539 RVA: 0x00166D88 File Offset: 0x00164F88
	public void UpdateDrama()
	{
		if (!this.MemorialScene.gameObject.activeInHierarchy)
		{
			this.DramaPhase++;
			this.ID = 26;
			while (this.ID < 31)
			{
				if (this.Students[this.ID] != null)
				{
					if (this.DramaPhase == 1)
					{
						this.Clubs.List[this.ID].position = this.OriginalClubPositions[this.ID - 25];
						this.Clubs.List[this.ID].rotation = this.OriginalClubRotations[this.ID - 25];
						this.Students[this.ID].ClubAnim = this.Students[this.ID].OriginalClubAnim;
					}
					else if (this.DramaPhase == 2)
					{
						this.Clubs.List[this.ID].position = this.DramaSpots[this.ID - 25].position;
						this.Clubs.List[this.ID].rotation = this.DramaSpots[this.ID - 25].rotation;
						if (this.ID == 26)
						{
							this.Students[this.ID].ClubAnim = this.Students[this.ID].ActAnim;
						}
						else if (this.ID == 27)
						{
							this.Students[this.ID].ClubAnim = this.Students[this.ID].ThinkAnim;
						}
						else if (this.ID == 28)
						{
							this.Students[this.ID].ClubAnim = this.Students[this.ID].ThinkAnim;
						}
						else if (this.ID == 29)
						{
							this.Students[this.ID].ClubAnim = this.Students[this.ID].ActAnim;
						}
						else if (this.ID == 30)
						{
							this.Students[this.ID].ClubAnim = this.Students[this.ID].ThinkAnim;
						}
					}
					else if (this.DramaPhase == 3)
					{
						this.Clubs.List[this.ID].position = this.BackstageSpots[this.ID - 25].position;
						this.Clubs.List[this.ID].rotation = this.BackstageSpots[this.ID - 25].rotation;
					}
					else if (this.DramaPhase == 4)
					{
						this.DramaPhase = 1;
						this.UpdateDrama();
					}
					this.Students[this.ID].DistanceToDestination = 100f;
					this.Students[this.ID].SmartPhone.SetActive(false);
					this.Students[this.ID].SpeechLines.Stop();
				}
				this.ID++;
			}
		}
	}

	// Token: 0x06001D74 RID: 7540 RVA: 0x001670A4 File Offset: 0x001652A4
	public void UpdateMartialArts()
	{
		this.ConvoManager.Confirmed = false;
		this.MartialArtsPhase++;
		this.ID = 46;
		while (this.ID < 51)
		{
			if (this.Students[this.ID] != null)
			{
				if (this.MartialArtsPhase == 1)
				{
					this.Clubs.List[this.ID].position = this.MartialArtsSpots[this.ID - 45].position;
					this.Clubs.List[this.ID].rotation = this.MartialArtsSpots[this.ID - 45].rotation;
				}
				else if (this.MartialArtsPhase == 2)
				{
					this.Clubs.List[this.ID].position = this.MartialArtsSpots[this.ID - 40].position;
					this.Clubs.List[this.ID].rotation = this.MartialArtsSpots[this.ID - 40].rotation;
				}
				else if (this.MartialArtsPhase == 3)
				{
					this.Clubs.List[this.ID].position = this.MartialArtsSpots[this.ID - 35].position;
					this.Clubs.List[this.ID].rotation = this.MartialArtsSpots[this.ID - 35].rotation;
				}
				else if (this.MartialArtsPhase == 4)
				{
					this.MartialArtsPhase = 0;
					this.UpdateMartialArts();
				}
				this.Students[this.ID].DistanceToDestination = 100f;
				this.Students[this.ID].SmartPhone.SetActive(false);
				this.Students[this.ID].SpeechLines.Stop();
			}
			this.ID++;
		}
		this.RaibaruMentorSpot.position = this.Clubs.List[46].position + this.Clubs.List[46].forward * 0.5f + this.Clubs.List[46].right * 0.5f;
		this.RaibaruMentorSpot.rotation = this.Clubs.List[46].rotation;
		if (this.Students[10] != null && this.Students[10].CurrentAction != StudentActionType.Follow && this.Students[10].DistanceToDestination < 1f)
		{
			this.Students[10].Pathfinding.speed = 1f;
			this.Students[10].SpeechLines.Stop();
			this.Students[10].Hurry = false;
		}
	}

	// Token: 0x06001D75 RID: 7541 RVA: 0x00167388 File Offset: 0x00165588
	public void UpdateMeeting()
	{
		this.MeetingTimer += Time.deltaTime;
		if (this.MeetingTimer > 5f)
		{
			this.Speaker += 5;
			if (this.Speaker == 91)
			{
				this.Speaker = 21;
			}
			else if (this.Speaker == 76)
			{
				this.Speaker = 86;
			}
			else if (this.Speaker == 36)
			{
				this.Speaker = 41;
			}
			this.MeetingTimer = 0f;
		}
	}

	// Token: 0x06001D76 RID: 7542 RVA: 0x00167408 File Offset: 0x00165608
	public void CheckMusic()
	{
		int num = 0;
		this.ID = 51;
		while (this.ID < 56)
		{
			if (this.Students[this.ID] != null && this.Students[this.ID].Routine && this.Students[this.ID].DistanceToDestination < 0.1f)
			{
				num++;
			}
			this.ID++;
		}
		if (num == 5)
		{
			this.PracticeVocals.pitch = Time.timeScale;
			this.PracticeMusic.pitch = Time.timeScale;
			if (!this.PracticeMusic.isPlaying)
			{
				this.PracticeVocals.Play();
				this.PracticeMusic.Play();
				return;
			}
		}
		else
		{
			this.PracticeVocals.Stop();
			this.PracticeMusic.Stop();
		}
	}

	// Token: 0x06001D77 RID: 7543 RVA: 0x001674E0 File Offset: 0x001656E0
	public void UpdateAprons()
	{
		this.ID = 21;
		while (this.ID < 26)
		{
			if (this.Students[this.ID] != null && this.Students[this.ID].ClubMemberID > 0 && this.Students[this.ID].ApronAttacher != null && this.Students[this.ID].ApronAttacher.newRenderer != null)
			{
				if (!this.Eighties)
				{
					this.Students[this.ID].ApronAttacher.newRenderer.material.mainTexture = this.Students[this.ID].Cosmetic.ApronTextures[this.Students[this.ID].ClubMemberID];
				}
				else
				{
					this.Students[this.ID].ApronAttacher.newRenderer.material.mainTexture = this.Students[this.ID].Cosmetic.ApronTextures[0];
				}
			}
			this.ID++;
		}
		if (this.Students[12] != null && this.Students[12].ApronAttacher != null && this.Students[12].ApronAttacher.newRenderer != null)
		{
			this.Students[12].ApronAttacher.newRenderer.material.mainTexture = this.Students[12].Cosmetic.AmaiApron;
		}
	}

	// Token: 0x06001D78 RID: 7544 RVA: 0x00167688 File Offset: 0x00165888
	public void PreventAlarm()
	{
		this.ID = 1;
		while (this.ID < 101)
		{
			if (this.Students[this.ID] != null)
			{
				this.Students[this.ID].Alarm = 0f;
			}
			this.ID++;
		}
	}

	// Token: 0x06001D79 RID: 7545 RVA: 0x001676E4 File Offset: 0x001658E4
	public void VolumeDown()
	{
		this.ID = 51;
		while (this.ID < 56)
		{
			if (this.Students[this.ID] != null && this.Students[this.ID].Instruments[this.Students[this.ID].ClubMemberID] != null)
			{
				this.Students[this.ID].Instruments[this.Students[this.ID].ClubMemberID].GetComponent<AudioSource>().volume = 0.2f;
			}
			this.ID++;
		}
	}

	// Token: 0x06001D7A RID: 7546 RVA: 0x00167790 File Offset: 0x00165990
	public void VolumeUp()
	{
		this.ID = 51;
		while (this.ID < 56)
		{
			if (this.Students[this.ID] != null && this.Students[this.ID].Instruments[this.Students[this.ID].ClubMemberID] != null)
			{
				this.Students[this.ID].Instruments[this.Students[this.ID].ClubMemberID].GetComponent<AudioSource>().volume = 1f;
			}
			this.ID++;
		}
	}

	// Token: 0x06001D7B RID: 7547 RVA: 0x0016783C File Offset: 0x00165A3C
	public void GetMaleVomitSpot(StudentScript VomitStudent)
	{
		this.MaleVomitSpot = this.MaleVomitSpots[1];
		VomitStudent.VomitDoor = this.MaleToiletDoors[1];
		this.ID = 2;
		while (this.ID < 7)
		{
			if (Vector3.Distance(VomitStudent.transform.position, this.MaleVomitSpots[this.ID].position) < Vector3.Distance(VomitStudent.transform.position, this.MaleVomitSpot.position))
			{
				this.MaleVomitSpot = this.MaleVomitSpots[this.ID];
				VomitStudent.VomitDoor = this.MaleToiletDoors[this.ID];
			}
			this.ID++;
		}
	}

	// Token: 0x06001D7C RID: 7548 RVA: 0x001678EC File Offset: 0x00165AEC
	public void GetFemaleVomitSpot(StudentScript VomitStudent)
	{
		this.FemaleVomitSpot = this.FemaleVomitSpots[1];
		VomitStudent.VomitDoor = this.FemaleToiletDoors[1];
		this.ID = 2;
		while (this.ID < 7)
		{
			if (Vector3.Distance(VomitStudent.transform.position, this.FemaleVomitSpots[this.ID].position) < Vector3.Distance(VomitStudent.transform.position, this.FemaleVomitSpot.position))
			{
				this.FemaleVomitSpot = this.FemaleVomitSpots[this.ID];
				VomitStudent.VomitDoor = this.FemaleToiletDoors[this.ID];
			}
			this.ID++;
		}
	}

	// Token: 0x06001D7D RID: 7549 RVA: 0x0016799C File Offset: 0x00165B9C
	public void GetMaleWashSpot(StudentScript VomitStudent)
	{
		Transform transform = this.MaleWashSpots[1];
		this.ID = 2;
		while (this.ID < 7)
		{
			if (Vector3.Distance(VomitStudent.transform.position, this.MaleWashSpots[this.ID].position) < Vector3.Distance(VomitStudent.transform.position, transform.position))
			{
				transform = this.MaleWashSpots[this.ID];
			}
			this.ID++;
		}
		this.MaleWashSpot = transform;
	}

	// Token: 0x06001D7E RID: 7550 RVA: 0x00167A24 File Offset: 0x00165C24
	public void GetFemaleWashSpot(StudentScript VomitStudent)
	{
		Transform transform = this.FemaleWashSpots[1];
		this.ID = 2;
		while (this.ID < 7)
		{
			if (Vector3.Distance(VomitStudent.transform.position, this.FemaleWashSpots[this.ID].position) < Vector3.Distance(VomitStudent.transform.position, transform.position))
			{
				transform = this.FemaleWashSpots[this.ID];
			}
			this.ID++;
		}
		this.FemaleWashSpot = transform;
	}

	// Token: 0x06001D7F RID: 7551 RVA: 0x00167AAC File Offset: 0x00165CAC
	public void GetNearestFountain(StudentScript Student)
	{
		DrinkingFountainScript drinkingFountainScript = this.DrinkingFountains[1];
		bool flag = false;
		this.ID = 1;
		while (drinkingFountainScript.Occupied)
		{
			drinkingFountainScript = this.DrinkingFountains[1 + this.ID];
			this.ID++;
			if (1 + this.ID == this.DrinkingFountains.Length)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			Student.EquipCleaningItems();
			Student.EatingSnack = false;
			Student.Private = false;
			Student.Routine = true;
			Student.StudentManager.UpdateMe(Student.StudentID);
			Student.CurrentDestination = Student.Destinations[Student.Phase];
			Student.Pathfinding.target = Student.Destinations[Student.Phase];
			return;
		}
		this.ID = 1;
		while (this.ID < this.DrinkingFountains.Length)
		{
			if (Vector3.Distance(Student.transform.position, this.DrinkingFountains[this.ID].transform.position) < Vector3.Distance(Student.transform.position, drinkingFountainScript.transform.position) && !this.DrinkingFountains[this.ID].Occupied)
			{
				drinkingFountainScript = this.DrinkingFountains[this.ID];
			}
			this.ID++;
		}
		Student.DrinkingFountain = drinkingFountainScript;
		Student.DrinkingFountain.Occupied = true;
	}

	// Token: 0x06001D80 RID: 7552 RVA: 0x00167C08 File Offset: 0x00165E08
	public void Save()
	{
		int profile = GameGlobals.Profile;
		int @int = PlayerPrefs.GetInt("SaveSlot");
		this.BloodParent.RecordAllBlood();
		YanSave.SaveData("Profile_" + profile.ToString() + "_Slot_" + @int.ToString());
		PlayerPrefs.SetInt(string.Concat(new string[]
		{
			"Profile_",
			profile.ToString(),
			"_Slot_",
			@int.ToString(),
			"_MemorialStudents"
		}), StudentGlobals.MemorialStudents);
	}

	// Token: 0x06001D81 RID: 7553 RVA: 0x00167C94 File Offset: 0x00165E94
	public void Load()
	{
		Debug.Log("Now loading save data.");
		int profile = GameGlobals.Profile;
		int @int = PlayerPrefs.GetInt("SaveSlot");
		this.Yandere.Class.gameObject.SetActive(true);
		YanSave.LoadData("Profile_" + profile.ToString() + "_Slot_" + @int.ToString(), false);
		this.Yandere.Class.gameObject.SetActive(false);
		Physics.SyncTransforms();
		this.ID = 1;
		while (this.ID < 101)
		{
			if (this.Students[this.ID] != null)
			{
				if (!this.Students[this.ID].Alive)
				{
					Debug.Log(this.Students[this.ID].Name + " is confirmed to be dead. Transforming them into a ragdoll now.");
					Vector3 localPosition = this.Students[this.ID].Hips.localPosition;
					Quaternion localRotation = this.Students[this.ID].Hips.localRotation;
					this.Students[this.ID].Ragdoll.Yandere = this.Yandere;
					this.Students[this.ID].BecomeRagdoll();
					this.Students[this.ID].Ragdoll.UpdateNextFrame = true;
					this.Students[this.ID].Ragdoll.NextPosition = localPosition;
					this.Students[this.ID].Ragdoll.NextRotation = localRotation;
					this.Students[this.ID].Ragdoll.CharacterAnimation = this.Students[this.ID].CharacterAnimation;
					this.Students[this.ID].MyRenderer.updateWhenOffscreen = true;
					this.Students[this.ID].CharacterAnimation.enabled = false;
					this.Students[this.ID].MyController.enabled = false;
					this.Students[this.ID].Pathfinding.enabled = false;
					this.Students[this.ID].HipCollider.enabled = true;
					GameObjectUtils.SetLayerRecursively(this.Students[this.ID].gameObject, 11);
					this.Police.CorpseList[this.Police.Corpses] = this.Students[this.ID].Ragdoll;
					this.Police.Corpses++;
					if (this.Students[this.ID].Removed)
					{
						this.Students[this.ID].Ragdoll.Remove();
						this.Police.Corpses--;
					}
				}
				else
				{
					this.Students[this.ID].ReturningFromSave = true;
					this.Students[this.ID].PhaseFromSave = this.Students[this.ID].Phase;
					if (this.Students[this.ID].ChangingShoes)
					{
						this.Students[this.ID].ShoeRemoval.enabled = true;
					}
					if (this.Students[this.ID].Schoolwear != 1)
					{
						this.Students[this.ID].ChangeSchoolwear();
					}
					if (this.Students[this.ID].ClubAttire)
					{
						int clubActivityPhase = this.Students[this.ID].ClubActivityPhase;
						this.Students[this.ID].ClubAttire = false;
						if (this.Students[this.ID].ClubActivityPhase > 14)
						{
							if (this.Students[this.ID].ClubActivityPhase == 18 || this.Students[this.ID].ClubActivityPhase == 19)
							{
								this.Students[this.ID].Destinations[this.Students[this.ID].Phase] = this.Clubs.List[this.ID].GetChild(this.Students[this.ID].ClubActivityPhase - 2);
								this.Students[this.ID].Destinations[this.Students[this.ID].Phase + 1] = this.Clubs.List[this.ID].GetChild(this.Students[this.ID].ClubActivityPhase - 2);
								this.Students[this.ID].CurrentDestination = this.Clubs.List[this.ID].GetChild(this.Students[this.ID].ClubActivityPhase - 2);
								this.Students[this.ID].Pathfinding.target = this.Clubs.List[this.ID].GetChild(this.Students[this.ID].ClubActivityPhase - 2);
								this.Students[this.ID].Character.transform.localPosition = new Vector3(0f, -0.25f, 0f);
								this.Students[this.ID].CurrentAction = StudentActionType.ClubAction;
								this.Students[this.ID].WalkAnim = "poolSwim_00";
								this.Students[this.ID].ClubAnim = "poolSwim_00";
								this.Students[this.ID].SetSplashes(true);
								this.Students[this.ID].Phase++;
							}
							this.Clock.Period = 3;
						}
						this.Students[this.ID].ChangeClubwear();
						if (this.Students[this.ID].ClubActivityPhase > 14)
						{
							this.Students[this.ID].ClubActivityPhase = clubActivityPhase;
						}
					}
					if (this.Students[this.ID].Defeats > 0)
					{
						this.Students[this.ID].IdleAnim = "idleInjured_00";
						this.Students[this.ID].WalkAnim = "walkInjured_00";
						this.Students[this.ID].OriginalIdleAnim = this.Students[this.ID].IdleAnim;
						this.Students[this.ID].OriginalWalkAnim = this.Students[this.ID].WalkAnim;
						this.Students[this.ID].LeanAnim = this.Students[this.ID].IdleAnim;
						this.Students[this.ID].CharacterAnimation.CrossFade(this.Students[this.ID].IdleAnim);
						this.Students[this.ID].Injured = true;
						this.Students[this.ID].Strength = 0;
						ScheduleBlock scheduleBlock = this.Students[this.ID].ScheduleBlocks[2];
						scheduleBlock.destination = "Sulk";
						scheduleBlock.action = "Sulk";
						ScheduleBlock scheduleBlock2 = this.Students[this.ID].ScheduleBlocks[4];
						scheduleBlock2.destination = "Sulk";
						scheduleBlock2.action = "Sulk";
						ScheduleBlock scheduleBlock3 = this.Students[this.ID].ScheduleBlocks[6];
						scheduleBlock3.destination = "Sulk";
						scheduleBlock3.action = "Sulk";
						ScheduleBlock scheduleBlock4 = this.Students[this.ID].ScheduleBlocks[7];
						scheduleBlock4.destination = "Sulk";
						scheduleBlock4.action = "Sulk";
						this.Students[this.ID].GetDestinations();
					}
					if (this.Students[this.ID].Actions[this.Students[this.ID].Phase] == StudentActionType.ClubAction && this.Students[this.ID].Club == ClubType.Cooking && this.Students[this.ID].ClubActivityPhase > 0)
					{
						this.Students[this.ID].MyPlate.parent = this.Students[this.ID].RightHand;
						this.Students[this.ID].MyPlate.localPosition = new Vector3(0.02f, -0.02f, -0.15f);
						this.Students[this.ID].MyPlate.localEulerAngles = new Vector3(-5f, -90f, 172.5f);
						this.Students[this.ID].IdleAnim = this.Students[this.ID].PlateIdleAnim;
						this.Students[this.ID].WalkAnim = this.Students[this.ID].PlateWalkAnim;
						this.Students[this.ID].LeanAnim = this.Students[this.ID].PlateIdleAnim;
						this.Students[this.ID].GetFoodTarget();
						this.Students[this.ID].ClubTimer = 0f;
					}
					else if (this.Students[this.ID].Phase > 0)
					{
						this.Students[this.ID].Phase--;
					}
					if (this.OsanaPoolEvent.Phase > 2)
					{
						this.OsanaPoolEvent.ReturnFromSave();
					}
				}
			}
			this.ID++;
		}
		this.Clock.UpdateClock();
		this.Clock.UpdateBloom = true;
		this.Alphabet.UpdateText();
		this.ClubManager.ActivateClubBenefit();
		this.Yandere.CanMove = true;
		this.Yandere.ClubAccessory();
		this.Yandere.Inventory.UpdateMoney();
		this.Yandere.WeaponManager.EquipWeaponsFromSave();
		this.Yandere.WeaponManager.RestoreWeaponToStudent();
		this.Yandere.WeaponManager.UpdateDelinquentWeapons();
		this.Mirror.UpdatePersona();
		if (this.Yandere.ClubAttire)
		{
			this.Yandere.ClubAttire = false;
			this.Yandere.ChangeClubwear();
		}
		foreach (DoorScript doorScript in this.Doors)
		{
			if (doorScript != null && doorScript.Open)
			{
				doorScript.OpenDoor();
			}
		}
		foreach (BugScript bugScript in this.Bugs)
		{
			if (bugScript != null)
			{
				bugScript.CheckStatus();
			}
		}
		foreach (BodyHidingLockerScript bodyHidingLockerScript in this.BodyHidingLockers)
		{
			if (bodyHidingLockerScript != null && bodyHidingLockerScript.StudentID > 0)
			{
				bodyHidingLockerScript.UpdateCorpse();
			}
		}
		this.BloodParent.RestoreAllBlood();
		if (this.OsanaThursdayAfterClassEvent.Phase > 0)
		{
			this.OsanaThursdayAfterClassEvent.ReturningFromSave = true;
		}
		if (this.Students[10] != null && this.Students[10].Cheer != null)
		{
			this.Students[10].Cheer.enabled = false;
		}
		if (this.Yandere.Gloved)
		{
			this.Yandere.Gloves = this.GloveList[this.GloveID];
			this.Yandere.WearingRaincoat = this.Yandere.Gloves.Raincoat;
			this.Yandere.WearGloves();
		}
		if (this.DramaPhase > 1)
		{
			Debug.Log("When loading, DramaPhase was " + this.DramaPhase.ToString() + ". So, we are attempting to restore that DramaPhase now.");
			this.DramaPhase--;
			this.UpdateDrama();
		}
	}

	// Token: 0x06001D82 RID: 7554 RVA: 0x00168838 File Offset: 0x00166A38
	public void UpdateBlood()
	{
		if (this.Police.BloodParent.childCount > 0)
		{
			this.ID = 0;
			foreach (object obj in this.Police.BloodParent)
			{
				Transform transform = (Transform)obj;
				if (this.ID < 100)
				{
					this.Blood[this.ID] = transform.gameObject.GetComponent<Collider>();
					this.ID++;
				}
			}
		}
		if (this.Police.BloodParent.childCount > 0 || this.Police.LimbParent.childCount > 0)
		{
			this.ID = 0;
			foreach (object obj2 in this.Police.LimbParent)
			{
				Transform transform2 = (Transform)obj2;
				if (this.ID < 100)
				{
					this.Limbs[this.ID] = transform2.gameObject.GetComponent<Collider>();
					this.ID++;
				}
			}
		}
	}

	// Token: 0x06001D83 RID: 7555 RVA: 0x0016897C File Offset: 0x00166B7C
	public void CanAnyoneSeeYandere()
	{
		this.YandereVisible = false;
		foreach (StudentScript studentScript in this.Students)
		{
			if (studentScript != null && studentScript.gameObject.activeInHierarchy && studentScript.CanSeeObject(studentScript.Yandere.gameObject, studentScript.Yandere.HeadPosition))
			{
				this.YandereVisible = true;
				return;
			}
		}
	}

	// Token: 0x06001D84 RID: 7556 RVA: 0x001689E8 File Offset: 0x00166BE8
	public void CheckBentos()
	{
		foreach (StudentScript studentScript in this.Students)
		{
			if (studentScript != null && studentScript.MyBento.Tranquil)
			{
				Debug.Log("Yandere-chan put sedative into " + studentScript.Name + "'s bento, so that student is being marked as ''Sleepy''.");
				studentScript.Sleepy = true;
			}
		}
	}

	// Token: 0x06001D85 RID: 7557 RVA: 0x00168A48 File Offset: 0x00166C48
	public void SetFaces(float alpha)
	{
		foreach (StudentScript studentScript in this.Students)
		{
			if (studentScript != null && studentScript.StudentID > 1)
			{
				if (studentScript.MyRenderer != null)
				{
					studentScript.MyRenderer.materials[0].color = new Color(1f - alpha, 1f - alpha, 1f - alpha, 1f);
					studentScript.MyRenderer.materials[1].color = new Color(1f - alpha, 1f - alpha, 1f - alpha, 1f);
					if (studentScript.MyRenderer.materials.Length > 2)
					{
						studentScript.MyRenderer.materials[2].color = new Color(1f - alpha, 1f - alpha, 1f - alpha, 1f);
					}
				}
				studentScript.Cosmetic.LeftEyeRenderer.material.color = new Color(1f - alpha, 1f - alpha, 1f - alpha, 1f);
				studentScript.Cosmetic.RightEyeRenderer.material.color = new Color(1f - alpha, 1f - alpha, 1f - alpha, 1f);
				if (studentScript.Cosmetic.HairRenderer != null)
				{
					studentScript.Cosmetic.HairRenderer.material.color = new Color(1f - alpha, 1f - alpha, 1f - alpha, 1f);
				}
			}
		}
	}

	// Token: 0x06001D86 RID: 7558 RVA: 0x00168BF0 File Offset: 0x00166DF0
	public void DisableChaseCameras()
	{
		foreach (StudentScript studentScript in this.Students)
		{
			if (studentScript != null)
			{
				studentScript.ChaseCamera.SetActive(false);
			}
		}
	}

	// Token: 0x06001D87 RID: 7559 RVA: 0x00168C2C File Offset: 0x00166E2C
	public void UpdateDynamicBones(bool Status)
	{
		foreach (DynamicBone dynamicBone in this.AllDynamicBones)
		{
			if (dynamicBone != null)
			{
				dynamicBone.enabled = Status;
			}
		}
	}

	// Token: 0x06001D88 RID: 7560 RVA: 0x00168C64 File Offset: 0x00166E64
	public void UpdateFPSDisplay(bool Status)
	{
		if (!this.RecordingVideo)
		{
			foreach (DynamicBone dynamicBone in this.AllDynamicBones)
			{
				if (this.FPSDisplay != null)
				{
					this.FPSDisplayBG.SetActive(Status);
					this.FPSDisplay.SetActive(Status);
				}
			}
		}
	}

	// Token: 0x06001D89 RID: 7561 RVA: 0x00168CB8 File Offset: 0x00166EB8
	public void InitializeReputations()
	{
		this.ReputationSetter.InitializeReputations();
		while (this.ID < 101)
		{
			Vector3 reputationTriangle = StudentGlobals.GetReputationTriangle(this.ID);
			reputationTriangle.x *= 0.33333f;
			reputationTriangle.y *= 0.33333f;
			reputationTriangle.z *= 0.33333f;
			StudentGlobals.SetStudentReputation(this.ID, Mathf.RoundToInt(reputationTriangle.x + reputationTriangle.y + reputationTriangle.z));
			this.StudentReps[this.ID] = (float)StudentGlobals.GetStudentReputation(this.ID);
			this.ID++;
		}
	}

	// Token: 0x06001D8A RID: 7562 RVA: 0x00168D74 File Offset: 0x00166F74
	public void GracePeriod(float Length)
	{
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.IgnoreTimer = Length;
			}
			this.ID++;
		}
	}

	// Token: 0x06001D8B RID: 7563 RVA: 0x00168DC8 File Offset: 0x00166FC8
	public void OpenSomeDoors()
	{
		int openedDoors = this.OpenedDoors;
		while (this.OpenedDoors < openedDoors + 11)
		{
			if (this.OpenedDoors < this.Doors.Length && this.Doors[this.OpenedDoors] != null && this.Doors[this.OpenedDoors].enabled)
			{
				this.Doors[this.OpenedDoors].Open = true;
				this.Doors[this.OpenedDoors].OpenDoor();
			}
			this.OpenedDoors++;
		}
	}

	// Token: 0x06001D8C RID: 7564 RVA: 0x00168E58 File Offset: 0x00167058
	public void SnapSomeStudents()
	{
		int snappedStudents = this.SnappedStudents;
		while (this.SnappedStudents < snappedStudents + 10)
		{
			if (this.SnappedStudents < this.Students.Length)
			{
				StudentScript studentScript = this.Students[this.SnappedStudents];
				if (studentScript != null && studentScript.gameObject.activeInHierarchy && studentScript.Alive)
				{
					studentScript.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					studentScript.CharacterAnimation[studentScript.SocialSitAnim].weight = 0f;
					studentScript.SnapStudent.Yandere = this.SnappedYandere;
					studentScript.SnapStudent.enabled = true;
					studentScript.SpeechLines.Stop();
					studentScript.enabled = false;
					studentScript.EmptyHands();
					if (studentScript.Shy)
					{
						studentScript.CharacterAnimation[studentScript.ShyAnim].weight = 0f;
					}
					if (studentScript.Club == ClubType.LightMusic)
					{
						studentScript.StopMusic();
					}
				}
			}
			this.SnappedStudents++;
		}
	}

	// Token: 0x06001D8D RID: 7565 RVA: 0x00168F64 File Offset: 0x00167164
	public void DarkenAllStudents()
	{
		foreach (StudentScript studentScript in this.Students)
		{
			if (studentScript != null && studentScript.StudentID > 1)
			{
				studentScript.MyRenderer.materials[0].mainTexture = this.PureWhite;
				studentScript.MyRenderer.materials[1].mainTexture = this.PureWhite;
				studentScript.MyRenderer.materials[2].mainTexture = this.PureWhite;
				studentScript.MyRenderer.materials[0].color = new Color(1f, 1f, 1f, 1f);
				studentScript.MyRenderer.materials[1].color = new Color(1f, 1f, 1f, 1f);
				studentScript.MyRenderer.materials[2].color = new Color(1f, 1f, 1f, 1f);
				studentScript.Cosmetic.LeftEyeRenderer.material.mainTexture = this.PureWhite;
				studentScript.Cosmetic.RightEyeRenderer.material.mainTexture = this.PureWhite;
				studentScript.Cosmetic.HairRenderer.material.mainTexture = this.PureWhite;
				studentScript.Cosmetic.LeftEyeRenderer.material.color = new Color(1f, 1f, 1f, 1f);
				studentScript.Cosmetic.RightEyeRenderer.material.color = new Color(1f, 1f, 1f, 1f);
				studentScript.Cosmetic.HairRenderer.material.color = new Color(1f, 1f, 1f, 1f);
			}
		}
	}

	// Token: 0x06001D8E RID: 7566 RVA: 0x0016914C File Offset: 0x0016734C
	public void LockDownOccultClub()
	{
		for (int i = 31; i < 36; i++)
		{
			this.Patrols.List[i].GetChild(1).position = this.Patrols.List[i].GetChild(0).position;
			this.Patrols.List[i].GetChild(2).position = this.Patrols.List[i].GetChild(0).position;
			this.Patrols.List[i].GetChild(3).position = this.Patrols.List[i].GetChild(0).position;
			this.Patrols.List[i].GetChild(4).position = this.Patrols.List[i].GetChild(0).position;
			this.Patrols.List[i].GetChild(5).position = this.Patrols.List[i].GetChild(0).position;
		}
		for (int j = 81; j < 86; j++)
		{
			this.Patrols.List[j].GetChild(0).position = this.BullySnapPosition[j].position;
			this.Patrols.List[j].GetChild(1).position = this.BullySnapPosition[j].position;
			this.Patrols.List[j].GetChild(2).position = this.BullySnapPosition[j].position;
			this.Patrols.List[j].GetChild(3).position = this.BullySnapPosition[j].position;
		}
	}

	// Token: 0x06001D8F RID: 7567 RVA: 0x00169308 File Offset: 0x00167508
	public void SetWindowsTransparent()
	{
		this.Window.sharedMaterial.color = new Color(0.85f, 0.85f, 0.85f, 0.5f);
		this.Window.sharedMaterial.shader = Shader.Find("Transparent/Diffuse");
		this.TransWindows = true;
	}

	// Token: 0x06001D90 RID: 7568 RVA: 0x00169360 File Offset: 0x00167560
	public void SetWindowsOpaque()
	{
		this.Window.sharedMaterial.color = new Color(0.85f, 0.85f, 0.85f, 1f);
		this.Window.sharedMaterial.shader = Shader.Find("Diffuse");
		this.TransWindows = false;
	}

	// Token: 0x06001D91 RID: 7569 RVA: 0x001693B8 File Offset: 0x001675B8
	public void LateUpdate()
	{
		if (this.WindowOccluder != null && !this.TransparentWindows)
		{
			if (this.Yandere.transform.position.y > 0.1f && this.Yandere.transform.position.y < 11f)
			{
				this.WindowOccluder.open = false;
				return;
			}
			this.WindowOccluder.open = true;
		}
	}

	// Token: 0x06001D92 RID: 7570 RVA: 0x0016942C File Offset: 0x0016762C
	public void UpdateSkirts(bool Status)
	{
		foreach (StudentScript studentScript in this.Students)
		{
			if (studentScript != null)
			{
				if (!studentScript.Male && !studentScript.Teacher && studentScript.Schoolwear == 1)
				{
					studentScript.SkirtCollider.gameObject.SetActive(Status);
				}
				studentScript.RightHandCollider.enabled = Status;
				studentScript.LeftHandCollider.enabled = Status;
			}
		}
	}

	// Token: 0x06001D93 RID: 7571 RVA: 0x001694A0 File Offset: 0x001676A0
	public void UpdatePanties(bool Status)
	{
		foreach (StudentScript studentScript in this.Students)
		{
			if (studentScript != null)
			{
				if (!studentScript.Male && !studentScript.Teacher && studentScript.Schoolwear == 1)
				{
					studentScript.PantyCollider.gameObject.SetActive(Status);
				}
				studentScript.NotFaceCollider.enabled = Status;
				studentScript.FaceCollider.enabled = Status;
			}
		}
	}

	// Token: 0x06001D94 RID: 7572 RVA: 0x00169514 File Offset: 0x00167714
	public void LoadPantyshots()
	{
		this.ID = 1;
		foreach (bool flag in this.PantyShotTaken)
		{
			if (this.ID < this.PantyShotTaken.Length)
			{
				this.PantyShotTaken[this.ID] = PlayerGlobals.GetStudentPantyShot(this.ID);
			}
			this.ID++;
		}
	}

	// Token: 0x06001D95 RID: 7573 RVA: 0x00169578 File Offset: 0x00167778
	public void SavePantyshots()
	{
		this.ID = 0;
		foreach (bool value in this.PantyShotTaken)
		{
			PlayerGlobals.SetStudentPantyShot(this.ID, value);
			this.ID++;
		}
	}

	// Token: 0x06001D96 RID: 7574 RVA: 0x001695C0 File Offset: 0x001677C0
	public void LoadReps()
	{
		this.ID = 1;
		foreach (float num in this.StudentReps)
		{
			if (this.ID < this.StudentReps.Length)
			{
				this.StudentReps[this.ID] = (float)StudentGlobals.GetStudentReputation(this.ID);
			}
			this.ID++;
		}
	}

	// Token: 0x06001D97 RID: 7575 RVA: 0x00169624 File Offset: 0x00167824
	public void SaveReps()
	{
		this.ID = 1;
		foreach (float num in this.StudentReps)
		{
			if (this.ID < this.StudentReps.Length)
			{
				StudentGlobals.SetStudentReputation(this.ID, (int)this.StudentReps[this.ID]);
			}
			this.ID++;
		}
	}

	// Token: 0x06001D98 RID: 7576 RVA: 0x00169688 File Offset: 0x00167888
	public void Week1RoutineAdjustments()
	{
		Debug.Log("Making week 1 routine adjustments.");
		this.UpdateWeek1Hangout(25);
		this.UpdateWeek1Hangout(30);
		this.UpdateWeek1Hangout(24);
		this.UpdateWeek1Hangout(27);
		this.UpdateWeek1Hangout(34);
		this.UpdateWeek1Hangout(35);
		this.UpdateWeek1Hangout(39);
		this.UpdateWeek1Hangout(40);
		this.UpdateWeek1Hangout(44);
		this.UpdateWeek1Hangout(45);
		this.UpdateWeek1Hangout(54);
		this.UpdateWeek1Hangout(55);
		this.UpdateWeek1Hangout(59);
		this.UpdateWeek1Hangout(60);
		this.UpdateWeek1Hangout(64);
		this.UpdateWeek1Hangout(65);
		this.UpdateWeek1Hangout(69);
		this.UpdateWeek1Hangout(70);
		this.UpdateWeek1Hangout(72);
		this.UpdateWeek1Hangout(73);
		this.UpdateWeek1Hangout(74);
		this.UpdateWeek1Hangout(75);
		if (!this.Bully)
		{
			this.UpdateWeek1Hangout(82);
			this.UpdateWeek1Hangout(83);
		}
	}

	// Token: 0x06001D99 RID: 7577 RVA: 0x00169768 File Offset: 0x00167968
	public void UpdateWeek1Hangout(int StudentID)
	{
		if (this.Students[StudentID] != null && !this.Students[StudentID].Sleuthing)
		{
			this.scheduleBlock = this.Students[StudentID].ScheduleBlocks[2];
			this.scheduleBlock.destination = "Week1Hangout";
			this.scheduleBlock.action = "Socialize";
			if (StudentID == 25 || StudentID == 30 || StudentID == 24 || StudentID == 27)
			{
				this.Students[StudentID].Hurry = true;
				this.Students[StudentID].Pathfinding.speed = 4f;
			}
			if (this.Students[StudentID].Club != ClubType.Bully)
			{
				this.scheduleBlock = this.Students[StudentID].ScheduleBlocks[6];
				this.scheduleBlock.destination = "Week1Hangout";
				this.scheduleBlock.action = "Socialize";
			}
			this.scheduleBlock = this.Students[StudentID].ScheduleBlocks[7];
			this.scheduleBlock.destination = "Week1Hangout";
			this.scheduleBlock.action = "Socialize";
			this.Students[StudentID].GetDestinations();
		}
	}

	// Token: 0x06001D9A RID: 7578 RVA: 0x00169890 File Offset: 0x00167A90
	public void UpdateExteriorStudents()
	{
		Debug.Log("Osana finished changing her shoes, so exterior students are moving back inside.");
		this.UpdateExteriorHangout(25);
		this.UpdateExteriorHangout(30);
		this.UpdateExteriorHangout(24);
		this.UpdateExteriorHangout(27);
		this.UpdateExteriorHangout(34);
		this.UpdateExteriorHangout(35);
	}

	// Token: 0x06001D9B RID: 7579 RVA: 0x001698CC File Offset: 0x00167ACC
	public void UpdateLunchtimeStudents()
	{
		Debug.Log("Osana is about to eat lunch, so certain students are having their routines adjusted.");
		this.UpdateLunchtimeHangout(25);
		this.UpdateLunchtimeHangout(30);
		this.UpdateLunchtimeHangout(24);
		this.UpdateLunchtimeHangout(27);
		this.UpdateLunchtimeHangout(34);
		this.UpdateLunchtimeHangout(35);
		this.UpdateLunchtimeHangout(39);
		this.UpdateLunchtimeHangout(40);
		this.UpdateLunchtimeHangout(44);
		this.UpdateLunchtimeHangout(45);
		this.UpdateLunchtimeHangout(54);
		this.UpdateLunchtimeHangout(55);
		this.UpdateLunchtimeHangout(59);
		this.UpdateLunchtimeHangout(60);
		if (!this.Bully)
		{
			this.UpdateLunchtimeHangout(82);
			this.UpdateLunchtimeHangout(83);
		}
	}

	// Token: 0x06001D9C RID: 7580 RVA: 0x0016996C File Offset: 0x00167B6C
	public void UpdateExteriorHangout(int StudentID)
	{
		if (this.Students[StudentID] != null)
		{
			this.scheduleBlock = this.Students[StudentID].ScheduleBlocks[2];
			this.scheduleBlock.destination = "Stairway";
			this.scheduleBlock.action = "Socialize";
			this.scheduleBlock = this.Students[StudentID].ScheduleBlocks[6];
			this.scheduleBlock.destination = "Stairway";
			this.scheduleBlock.action = "Socialize";
			this.scheduleBlock = this.Students[StudentID].ScheduleBlocks[7];
			this.scheduleBlock.destination = "Stairway";
			this.scheduleBlock.action = "Socialize";
			this.Students[StudentID].GetDestinations();
			this.Students[StudentID].CurrentDestination = this.Students[StudentID].Destinations[this.Students[StudentID].Phase];
			this.Students[StudentID].Pathfinding.target = this.Students[StudentID].Destinations[this.Students[StudentID].Phase];
		}
	}

	// Token: 0x06001D9D RID: 7581 RVA: 0x00169A90 File Offset: 0x00167C90
	public void UpdateLunchtimeHangout(int StudentID)
	{
		if (this.Students[StudentID] != null)
		{
			this.scheduleBlock = this.Students[StudentID].ScheduleBlocks[4];
			this.scheduleBlock.destination = "LunchWitnessPosition";
			this.scheduleBlock.action = "Socialize";
			this.Students[StudentID].GetDestinations();
			this.Students[StudentID].CurrentDestination = this.Students[StudentID].Destinations[this.Students[StudentID].Phase];
			this.Students[StudentID].Pathfinding.target = this.Students[StudentID].Destinations[this.Students[StudentID].Phase];
		}
	}

	// Token: 0x06001D9E RID: 7582 RVA: 0x00169B48 File Offset: 0x00167D48
	public void Week2RoutineAdjustments()
	{
		if (this.Students[11] != null)
		{
			this.Hangouts.List[11] = this.Week2Hangouts.List[11];
			this.Students[11].GetDestinations();
			if (this.Students[10] != null)
			{
				this.Hangouts.List[10] = this.Week2Hangouts.List[10];
				this.Students[10].GetDestinations();
			}
		}
		this.MournSpots[10].position = this.Week2Hangouts.List[11].position;
		this.MournSpots[10].eulerAngles = this.Week2Hangouts.List[11].eulerAngles;
		if (this.Students[21] != null)
		{
			this.scheduleBlock = this.Students[21].ScheduleBlocks[2];
			this.scheduleBlock.destination = "Week2Hangout";
			this.scheduleBlock.action = "Stand";
			this.scheduleBlock = this.Students[21].ScheduleBlocks[4];
			this.scheduleBlock.destination = "Week2Hangout";
			this.scheduleBlock.action = "Stand";
			this.scheduleBlock = this.Students[21].ScheduleBlocks[6];
			this.scheduleBlock.destination = "Week2Hangout";
			this.scheduleBlock.action = "Stand";
			this.scheduleBlock = this.Students[21].ScheduleBlocks[7];
			this.scheduleBlock.destination = "Week2Hangout";
			this.scheduleBlock.action = "Stand";
			this.scheduleBlock = this.Students[21].ScheduleBlocks[8];
			this.scheduleBlock.destination = "Week2Hangout";
			this.scheduleBlock.action = "Stand";
			this.Students[21].GetDestinations();
		}
		this.UpdateWeek2Hangout(4);
		this.UpdateWeek2Hangout(5);
		this.UpdateWeek2Hangout(6);
		this.UpdateWeek2Hangout(7);
		this.UpdateWeek2Hangout(8);
		this.UpdateWeek2Hangout(9);
		this.UpdateWeek2Hangout(22);
		this.UpdateWeek2Hangout(23);
		this.UpdateWeek2Hangout(24);
		this.UpdateWeek2Hangout(25);
		this.UpdateWeek2Hangout(27);
		this.UpdateWeek2Hangout(28);
		this.UpdateWeek2Hangout(29);
		this.UpdateWeek2Hangout(30);
		this.UpdateWeek2Hangout(32);
		this.UpdateWeek2Hangout(33);
		this.UpdateWeek2Hangout(34);
		this.UpdateWeek2Hangout(35);
		this.UpdateWeek2Hangout(37);
		this.UpdateWeek2Hangout(38);
		this.UpdateWeek2Hangout(39);
		this.UpdateWeek2Hangout(40);
		this.UpdateWeek2Hangout(42);
		this.UpdateWeek2Hangout(43);
		this.UpdateWeek2Hangout(44);
		this.UpdateWeek2Hangout(45);
		this.UpdateWeek2Hangout(56);
		this.UpdateWeek2Hangout(57);
		this.UpdateWeek2Hangout(58);
		this.UpdateWeek2Hangout(59);
		this.UpdateWeek2Hangout(60);
		this.UpdateWeek2Hangout(81);
		this.UpdateWeek2Hangout(82);
		this.UpdateWeek2Hangout(83);
		this.UpdateWeek2Hangout(84);
		this.UpdateWeek2Hangout(85);
	}

	// Token: 0x06001D9F RID: 7583 RVA: 0x00169E58 File Offset: 0x00168058
	public void UpdateWeek2Hangout(int StudentID)
	{
		if (this.Students[StudentID] != null)
		{
			this.scheduleBlock = this.Students[StudentID].ScheduleBlocks[2];
			this.scheduleBlock.destination = "Week2Hangout";
			this.scheduleBlock.action = "Socialize";
			this.scheduleBlock = this.Students[StudentID].ScheduleBlocks[4];
			this.scheduleBlock.destination = "Week2Hangout";
			this.scheduleBlock.action = "Socialize";
			this.scheduleBlock = this.Students[StudentID].ScheduleBlocks[6];
			this.scheduleBlock.destination = "Week2Hangout";
			this.scheduleBlock.action = "Socialize";
			this.scheduleBlock = this.Students[StudentID].ScheduleBlocks[7];
			this.scheduleBlock.destination = "Week2Hangout";
			this.scheduleBlock.action = "Socialize";
			this.Students[StudentID].GetDestinations();
		}
	}

	// Token: 0x06001DA0 RID: 7584 RVA: 0x00169F5C File Offset: 0x0016815C
	public void EightiesWeek3RoutineAdjustments()
	{
		for (int i = 2; i < 6; i++)
		{
			if (this.Students[i] != null)
			{
				this.scheduleBlock = this.Students[i].ScheduleBlocks[2];
				this.scheduleBlock.destination = "EightiesSpot";
				this.scheduleBlock.action = "Read";
				this.scheduleBlock = this.Students[i].ScheduleBlocks[7];
				this.scheduleBlock.destination = "EightiesSpot";
				this.scheduleBlock.action = "Read";
				this.Students[i].GetDestinations();
			}
		}
	}

	// Token: 0x06001DA1 RID: 7585 RVA: 0x0016A004 File Offset: 0x00168204
	public void EightiesWeek4RoutineAdjustments()
	{
		for (int i = 6; i < 11; i++)
		{
			if (this.Students[i] != null)
			{
				this.scheduleBlock = this.Students[i].ScheduleBlocks[4];
				this.scheduleBlock.destination = "EightiesSpot";
				this.scheduleBlock.action = "PrepareFood";
				this.Students[i].GetDestinations();
			}
		}
	}

	// Token: 0x06001DA2 RID: 7586 RVA: 0x0016A070 File Offset: 0x00168270
	public void EightiesWeek5RoutineAdjustments()
	{
		this.SunbatheAllDay(25);
		this.SunbatheAllDay(30);
		this.SunbatheAllDay(35);
		this.SunbatheAllDay(40);
		this.SunbatheAllDay(45);
		this.SunbatheAllDay(50);
		this.SunbatheAllDay(55);
	}

	// Token: 0x06001DA3 RID: 7587 RVA: 0x0016A0AC File Offset: 0x001682AC
	public void EightiesWeek6RoutineAdjustments()
	{
		int i = 26;
		if (this.Students[i] != null)
		{
			this.scheduleBlock = this.Students[i].ScheduleBlocks[2];
			this.scheduleBlock.destination = "Patrol";
			this.scheduleBlock.action = "Patrol";
			this.scheduleBlock = this.Students[i].ScheduleBlocks[7];
			this.scheduleBlock.destination = "Patrol";
			this.scheduleBlock.action = "Patrol";
			this.Students[i].GetDestinations();
		}
		i = 29;
		if (this.Students[i] != null)
		{
			this.scheduleBlock = this.Students[i].ScheduleBlocks[2];
			this.scheduleBlock.destination = "Patrol";
			this.scheduleBlock.action = "Patrol";
			this.scheduleBlock = this.Students[i].ScheduleBlocks[7];
			this.scheduleBlock.destination = "Patrol";
			this.scheduleBlock.action = "Patrol";
			this.Students[i].GetDestinations();
		}
		for (i = 52; i < 56; i++)
		{
			if (this.Students[i] != null)
			{
				this.scheduleBlock = this.Students[i].ScheduleBlocks[2];
				this.scheduleBlock.destination = "Perform";
				this.scheduleBlock.action = "Perform";
				this.scheduleBlock = this.Students[i].ScheduleBlocks[7];
				this.scheduleBlock.destination = "Perform";
				this.scheduleBlock.action = "Perform";
				this.Students[i].GetDestinations();
			}
		}
	}

	// Token: 0x06001DA4 RID: 7588 RVA: 0x0016A268 File Offset: 0x00168468
	public void EightiesWeek8RoutineAdjustments()
	{
		for (int i = 2; i < 11; i++)
		{
			this.Hangouts.List[i].position = this.PopularGirlSpots[i].position;
			this.Hangouts.List[i].LookAt(this.EightiesHangouts.List[18]);
		}
	}

	// Token: 0x06001DA5 RID: 7589 RVA: 0x0016A2C4 File Offset: 0x001684C4
	public void EightiesWeek9RoutineAdjustments()
	{
		if (this.Students[19] != null)
		{
			for (int i = 57; i < 61; i++)
			{
				this.scheduleBlock = this.Students[i].ScheduleBlocks[2];
				this.scheduleBlock.destination = "PhotoShoot";
				this.scheduleBlock.action = "PhotoShoot";
				this.scheduleBlock = this.Students[i].ScheduleBlocks[7];
				this.scheduleBlock.destination = "PhotoShoot";
				this.scheduleBlock.action = "PhotoShoot";
				this.Students[i].GetDestinations();
			}
			this.Students[1].Infatuated = true;
			if (DateGlobals.Weekday != DayOfWeek.Monday)
			{
				this.FollowGravureIdol(1);
			}
			this.FollowGravureIdol(6);
			this.FollowGravureIdol(7);
			this.FollowGravureIdol(8);
			this.FollowGravureIdol(9);
			this.FollowGravureIdol(10);
			this.FollowGravureIdol(23);
			this.FollowGravureIdol(28);
			this.FollowGravureIdol(33);
			this.FollowGravureIdol(38);
			this.FollowGravureIdol(43);
			this.FollowGravureIdol(48);
			this.FollowGravureIdol(63);
			this.FollowGravureIdol(68);
			this.FollowGravureIdol(73);
		}
	}

	// Token: 0x06001DA6 RID: 7590 RVA: 0x0016A3F4 File Offset: 0x001685F4
	public void EightiesWeek10RoutineAdjustments()
	{
		for (int i = 2; i < 11; i++)
		{
			this.BecomeSleuth(i);
		}
		this.BecomeSleuth(20);
		this.RivalGuardSpots[0].parent = this.Students[20].transform;
		this.RivalGuardSpots[0].localPosition = new Vector3(0f, 0f, 0f);
		this.RivalGuardSpots[0].localEulerAngles = new Vector3(0f, 0f, 0f);
		for (int i = 37; i < 41; i++)
		{
			this.BecomeSleuth(i);
		}
		for (int i = 57; i < 61; i++)
		{
			this.BecomeGuard(i);
		}
	}

	// Token: 0x06001DA7 RID: 7591 RVA: 0x0016A4A4 File Offset: 0x001686A4
	public void BecomeSleuth(int ID)
	{
		if (this.Students[ID] != null)
		{
			this.Students[ID].Persona = PersonaType.Sleuth;
			this.Students[ID].BecomeSleuth();
			this.Students[ID].GetDestinations();
		}
	}

	// Token: 0x06001DA8 RID: 7592 RVA: 0x0016A4E0 File Offset: 0x001686E0
	public void BecomeGuard(int ID)
	{
		if (this.Students[ID] != null)
		{
			this.Students[ID].Persona = PersonaType.Sleuth;
			this.Students[ID].BecomeSleuth();
			ScheduleBlock scheduleBlock = this.Students[ID].ScheduleBlocks[2];
			scheduleBlock.destination = "Guard";
			scheduleBlock.action = "Guard";
			ScheduleBlock scheduleBlock2 = this.Students[ID].ScheduleBlocks[4];
			scheduleBlock2.destination = "Guard";
			scheduleBlock2.action = "Guard";
			ScheduleBlock scheduleBlock3 = this.Students[ID].ScheduleBlocks[7];
			scheduleBlock3.destination = "Guard";
			scheduleBlock3.action = "Guard";
			ScheduleBlock scheduleBlock4 = this.Students[ID].ScheduleBlocks[8];
			scheduleBlock3.destination = "Guard";
			scheduleBlock3.action = "Guard";
			this.Students[ID].GetDestinations();
		}
	}

	// Token: 0x06001DA9 RID: 7593 RVA: 0x0016A5BC File Offset: 0x001687BC
	public void FollowGravureIdol(int ID)
	{
		if (this.Students[ID] != null)
		{
			this.Hangouts.List[ID] = this.Students[19].transform;
			this.scheduleBlock = this.Students[ID].ScheduleBlocks[2];
			this.scheduleBlock.destination = "Hangout";
			this.scheduleBlock.action = "Socialize";
			if (ID > 1)
			{
				this.scheduleBlock = this.Students[ID].ScheduleBlocks[4];
				this.scheduleBlock.destination = "Hangout";
				this.scheduleBlock.action = "Socialize";
			}
			this.scheduleBlock = this.Students[ID].ScheduleBlocks[6];
			this.scheduleBlock.destination = "Hangout";
			this.scheduleBlock.action = "Socialize";
			this.scheduleBlock = this.Students[ID].ScheduleBlocks[7];
			this.scheduleBlock.destination = "Hangout";
			this.scheduleBlock.action = "Socialize";
			this.Students[ID].GetDestinations();
			this.Students[ID].Infatuated = true;
		}
	}

	// Token: 0x06001DAA RID: 7594 RVA: 0x0016A6EC File Offset: 0x001688EC
	public void SunbatheAllDay(int ID)
	{
		if (this.Students[ID] != null)
		{
			this.Students[ID].DressCode = false;
			this.scheduleBlock = this.Students[ID].ScheduleBlocks[2];
			this.scheduleBlock.destination = "Sunbathe";
			this.scheduleBlock.action = "Sunbathe";
			this.scheduleBlock = this.Students[ID].ScheduleBlocks[6];
			this.scheduleBlock.destination = "Sunbathe";
			this.scheduleBlock.action = "Sunbathe";
			this.scheduleBlock = this.Students[ID].ScheduleBlocks[7];
			this.scheduleBlock.destination = "Sunbathe";
			this.scheduleBlock.action = "Sunbathe";
			this.Students[ID].GetDestinations();
		}
		ID++;
	}

	// Token: 0x06001DAB RID: 7595 RVA: 0x0016A7CC File Offset: 0x001689CC
	public void ForgetAboutSunbathing(int ID)
	{
		if (this.Students[ID] != null)
		{
			this.Students[ID].DressCode = false;
			this.scheduleBlock = this.Students[ID].ScheduleBlocks[2];
			this.scheduleBlock.destination = "Hangout";
			this.scheduleBlock.action = "Socialize";
			this.scheduleBlock = this.Students[ID].ScheduleBlocks[6];
			this.scheduleBlock.destination = "Hangout";
			this.scheduleBlock.action = "Socialize";
			this.scheduleBlock = this.Students[ID].ScheduleBlocks[7];
			this.scheduleBlock.destination = "Hangout";
			this.scheduleBlock.action = "Socialize";
			this.Students[ID].GetDestinations();
			this.Students[ID].CurrentDestination = this.Students[ID].Destinations[this.Students[ID].Phase];
			this.Students[ID].Pathfinding.target = this.Students[ID].Destinations[this.Students[ID].Phase];
		}
		ID++;
	}

	// Token: 0x06001DAC RID: 7596 RVA: 0x0016A900 File Offset: 0x00168B00
	public void TakeOutTheTrash()
	{
		int num = 2;
		int num2 = 0;
		while (num2 < this.GarbageBags && num < 90)
		{
			if (this.GarbageBagList[num2] != null)
			{
				if (num > 9 && num < 21)
				{
					num++;
				}
				while (this.Students[num] == null || !this.Students[num].gameObject.activeInHierarchy)
				{
					num++;
				}
				this.GarbageBagList[num2].GetComponent<PickUpScript>().DisableGarbageBag();
				this.Students[num].TakingOutTrash = true;
				this.Students[num].TrashDestination = this.GarbageBagList[num2].transform;
				this.Students[num].Routine = false;
				Debug.Log("Assigned " + this.Students[num].Name + " to clean up trash bag #" + num2.ToString());
			}
			num++;
			num2++;
		}
	}

	// Token: 0x06001DAD RID: 7597 RVA: 0x0016A9EC File Offset: 0x00168BEC
	public void Medibang()
	{
		this.Students[35].IdleAnim = "f02_idleElegant_00";
		this.Students[35].WalkAnim = "f02_jojoWalk_00";
		this.Students[35].OriginalIdleAnim = "f02_idleElegant_00";
		this.Students[35].OriginalWalkAnim = "f02_jojoWalk_00";
		this.Students[35].Cosmetic.MyRenderer.enabled = false;
		this.Students[35].EdgyAttacher.SetActive(true);
		this.Students[35].Cosmetic.Medibang = true;
		this.Students[35].Cosmetic.Start();
	}

	// Token: 0x06001DAE RID: 7598 RVA: 0x0016AA9C File Offset: 0x00168C9C
	public void RemovePoolFromRoutines()
	{
		Debug.Log("Firing RemovePoolFromRoutines()");
		this.OsanaPoolEvent.enabled = false;
		this.PoolClosed = true;
		for (int i = 81; i < 86; i++)
		{
			ScheduleBlock scheduleBlock = this.Students[i].ScheduleBlocks[4];
			scheduleBlock.destination = "LunchSpot";
			scheduleBlock.action = "Eat";
			this.Students[i].Actions[4] = StudentActionType.SitAndEatBento;
			this.Students[i].GetDestinations();
		}
		if (this.Eighties)
		{
			Debug.Log("A bunch of girls are now being instructed to forget about sunbathing.");
			this.ForgetAboutSunbathing(25);
			this.ForgetAboutSunbathing(30);
			this.ForgetAboutSunbathing(35);
			this.ForgetAboutSunbathing(40);
			this.ForgetAboutSunbathing(45);
			this.ForgetAboutSunbathing(50);
			this.ForgetAboutSunbathing(55);
		}
	}

	// Token: 0x06001DAF RID: 7599 RVA: 0x0016AB60 File Offset: 0x00168D60
	public void LoadCollectibles()
	{
		if (this.HeadmasterTapesCollected.Length != 0)
		{
			for (int i = 1; i < 12; i++)
			{
				this.HeadmasterTapesCollected[i] = CollectibleGlobals.GetHeadmasterTapeCollected(i);
				this.PantiesCollected[i] = CollectibleGlobals.GetPantyPurchased(i);
				this.MangaCollected[i] = CollectibleGlobals.GetMangaCollected(i);
				this.TapesCollected[i] = CollectibleGlobals.GetTapeCollected(i);
			}
		}
	}

	// Token: 0x06001DB0 RID: 7600 RVA: 0x0016ABBC File Offset: 0x00168DBC
	public void SaveCollectibles()
	{
		for (int i = 1; i < 12; i++)
		{
			CollectibleGlobals.SetHeadmasterTapeCollected(i, this.HeadmasterTapesCollected[i]);
			CollectibleGlobals.SetPantyPurchased(i, this.PantiesCollected[i]);
			CollectibleGlobals.SetTapeCollected(i, this.TapesCollected[i]);
		}
		for (int i = 1; i < 16; i++)
		{
			CollectibleGlobals.SetMangaCollected(i, this.MangaCollected[i]);
		}
	}

	// Token: 0x06001DB1 RID: 7601 RVA: 0x0016AC1C File Offset: 0x00168E1C
	public void UpdateTeachers()
	{
		this.UpdateMe(90);
		this.UpdateMe(91);
		this.UpdateMe(92);
		this.UpdateMe(93);
		this.UpdateMe(94);
		this.UpdateMe(95);
		this.UpdateMe(96);
		this.UpdateMe(97);
	}

	// Token: 0x06001DB2 RID: 7602 RVA: 0x0016AC6C File Offset: 0x00168E6C
	public void UpdateAppearances()
	{
		foreach (StudentScript studentScript in this.Students)
		{
			if (studentScript != null)
			{
				studentScript.Cosmetic.Start();
			}
		}
	}

	// Token: 0x06001DB3 RID: 7603 RVA: 0x0016ACA8 File Offset: 0x00168EA8
	public void RandomizeRoutines()
	{
		this.ID = 1;
		while (this.ID < 101)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.EmptyObject, base.transform.position, Quaternion.identity);
			this.RandomSpots[this.ID] = gameObject.transform;
			gameObject.transform.position = this.PossibleRandomSpots[UnityEngine.Random.Range(1, 11)].position;
			this.ID++;
		}
		this.ID = 1;
		while (this.ID < 97)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.Indoors = true;
				studentScript.Spawned = true;
				studentScript.Calm = true;
				if (studentScript.ShoeRemoval.Locker == null && !studentScript.Teacher)
				{
					studentScript.ShoeRemoval.Start();
					studentScript.ShoeRemoval.PutOnShoes();
				}
				ScheduleBlock scheduleBlock = studentScript.ScheduleBlocks[0];
				scheduleBlock.destination = "Random";
				scheduleBlock.action = "Random";
				ScheduleBlock scheduleBlock2 = studentScript.ScheduleBlocks[1];
				scheduleBlock2.destination = "Random";
				scheduleBlock2.action = "Random";
				ScheduleBlock scheduleBlock3 = studentScript.ScheduleBlocks[2];
				scheduleBlock3.destination = "Random";
				scheduleBlock3.action = "Random";
				ScheduleBlock scheduleBlock4 = studentScript.ScheduleBlocks[3];
				scheduleBlock4.destination = "Random";
				scheduleBlock4.action = "Random";
				ScheduleBlock scheduleBlock5 = studentScript.ScheduleBlocks[4];
				scheduleBlock5.destination = "Random";
				scheduleBlock5.action = "Random";
				ScheduleBlock scheduleBlock6 = studentScript.ScheduleBlocks[5];
				scheduleBlock6.destination = "Random";
				scheduleBlock6.action = "Random";
				studentScript.GetDestinations();
				studentScript.CurrentDestination = studentScript.Destinations[studentScript.Phase];
				studentScript.Pathfinding.target = studentScript.Destinations[studentScript.Phase];
				studentScript.CurrentAction = StudentActionType.Random;
				this.Students[this.ID].transform.position = this.PossibleRandomSpots[UnityEngine.Random.Range(1, 11)].position;
				Physics.SyncTransforms();
			}
			this.ID++;
		}
	}

	// Token: 0x06001DB4 RID: 7604 RVA: 0x0016AEC4 File Offset: 0x001690C4
	public void DepowerStudentCouncil()
	{
		for (int i = 86; i < 90; i++)
		{
			StudentScript studentScript = this.Students[i];
			if (studentScript != null)
			{
				studentScript.OriginalPersona = PersonaType.Heroic;
				studentScript.Persona = PersonaType.Heroic;
				studentScript.Club = ClubType.None;
				studentScript.CameraReacting = false;
				studentScript.SpeechLines.Stop();
				studentScript.EmptyHands();
				studentScript.IdleAnim = studentScript.BulliedIdleAnim;
				studentScript.WalkAnim = studentScript.BulliedWalkAnim;
				studentScript.Armband.SetActive(false);
				ScheduleBlock scheduleBlock = studentScript.ScheduleBlocks[3];
				scheduleBlock.destination = "LunchSpot";
				scheduleBlock.action = "Eat";
				studentScript.GetDestinations();
				studentScript.CurrentDestination = studentScript.Destinations[studentScript.Phase];
				studentScript.Pathfinding.target = studentScript.Destinations[studentScript.Phase];
			}
		}
	}

	// Token: 0x06001DB5 RID: 7605 RVA: 0x0016AF9C File Offset: 0x0016919C
	public void Become1989()
	{
		this.Eighties = true;
		this.WeekLimit = 10;
		if (this.TakingPortraits)
		{
			this.PhotoBG.mainTexture = this.EightiesBG;
			this.PortraitChan = this.StudentChan;
			this.PortraitKun = this.StudentKun;
			this.EightiesPrefix = "1989";
			this.Profile.enabled = true;
			return;
		}
		this.Yandere.HeartCamera.enabled = false;
		this.Tutorial.ReputationHUD.transform.localPosition = new Vector3(-15f, 25f, 0f);
		this.Tutorial.SanityHUD.transform.localPosition = new Vector3(50f, 30f, 0f);
		this.Tutorial.ClockHUD.transform.localPosition = new Vector3(-25f, -10f, 0f);
		this.FPSValue.GetComponent<Text>().color = new Color(1f, 1f, 1f, 1f);
		this.FPSValue.localPosition = new Vector3(75f, -179f, 0f);
		this.FPS.GetComponent<Text>().color = new Color(1f, 1f, 1f, 1f);
		this.FPS.localPosition = new Vector3(120f, -179f, 0f);
		this.LandLinePhone.gameObject.SetActive(true);
		this.OutOfOrderSign.SetActive(false);
		this.YellowifyLabel(this.Police.EndOfDay.Counselor.CounselorSubtitle);
		this.YellowifyLabel(this.Police.EndOfDay.Counselor.LectureSubtitle);
		this.YellowifyLabel(this.LoveManager.ConfessionManager.SubtitleLabel);
		this.YellowifyLabel(this.Headmaster.HeadmasterSubtitle);
		this.YellowifyLabel(this.Yandere.Subtitle.Label);
		this.YellowifyLabel(this.EventSubtitle);
		this.EightiesifyLabel(this.Yandere.SanityLabel);
		this.HauntedBathroomLight.enabled = true;
		this.SpawnPositions[7].localPosition = new Vector3(1f, 0f, -6f);
		this.PracticeSpots[1].localPosition = new Vector3(1.66666f, 4f, 26f);
		this.PracticeSpots[1].localEulerAngles = new Vector3(0f, -90f, 0f);
		for (int i = 1; i < this.ModernDayProps.Length; i++)
		{
			this.ModernDayProps[i].SetActive(false);
		}
		for (int i = 1; i < this.EightiesProps.Length; i++)
		{
			this.EightiesProps[i].SetActive(true);
		}
		this.LunchSpots = this.EightiesLunchSpots;
		this.Hangouts = this.EightiesHangouts;
		this.Patrols = this.EightiesPatrols;
		this.Clubs = this.EightiesClubs;
		this.InfoClubRoom.SetActive(false);
		this.InfoClubProps.SetActive(false);
		this.ModernDayScienceClub.SetActive(false);
		this.ModernDayScienceProps.SetActive(false);
		this.ModernDayPropsLMC.SetActive(false);
		this.ModernDayRoomLMC.SetActive(false);
		this.NewspaperClubProps.SetActive(true);
		this.NewspaperClubRoom.SetActive(true);
		this.EightiesPropsLMC.SetActive(true);
		this.EightiesRoomLMC.SetActive(true);
		this.EightiesScienceClub.SetActive(true);
		this.EightiesScienceProps.SetActive(true);
		if (this.Week < 11)
		{
			this.SuitorID = this.SuitorIDs[this.Week];
		}
		this.LyricsSpot.parent.position = this.EightiesLyricDesk.position;
		this.LyricsSpot.parent.eulerAngles = this.EightiesLyricDesk.eulerAngles;
	}

	// Token: 0x06001DB6 RID: 7606 RVA: 0x0016B38E File Offset: 0x0016958E
	public void YellowifyLabel(UILabel Label)
	{
		Label.trueTypeFont = this.Arial;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 0f, 1f);
		Label.fontStyle = FontStyle.Bold;
	}

	// Token: 0x06001DB7 RID: 7607 RVA: 0x0016B3CC File Offset: 0x001695CC
	public void EightiesifyLabel(UILabel Label)
	{
		Label.trueTypeFont = this.VCR;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 1f, 1f);
		Label.effectStyle = UILabel.Effect.Outline8;
		Label.effectColor = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x06001DB8 RID: 7608 RVA: 0x0016B434 File Offset: 0x00169634
	public void StayInOneSpot(int StudentID)
	{
		this.Hangouts.List[StudentID].transform.position = this.Students[StudentID].transform.position;
		this.Hangouts.List[StudentID].transform.eulerAngles = this.Students[StudentID].transform.eulerAngles;
		for (int i = 0; i < 8; i++)
		{
			ScheduleBlock scheduleBlock = this.Students[StudentID].ScheduleBlocks[i];
			scheduleBlock.destination = "Hangout";
			scheduleBlock.action = "Wait";
		}
		this.Students[StudentID].GetDestinations();
		this.Students[StudentID].CurrentAction = StudentActionType.Wait;
		this.Students[StudentID].Pathfinding.target = this.Tutorial.Destination[this.Tutorial.Phase + 1];
		this.Students[StudentID].CurrentDestination = this.Tutorial.Destination[this.Tutorial.Phase + 1];
	}

	// Token: 0x06001DB9 RID: 7609 RVA: 0x0016B530 File Offset: 0x00169730
	public void ChangeSuitorRoutine(int StudentID)
	{
		StudentScript studentScript = this.Students[StudentID];
		studentScript.RelaxAnim = studentScript.PatrolAnim;
		studentScript.Curious = true;
		studentScript.Crush = this.RivalID;
		this.Hangouts.List[StudentID].transform.position = new Vector3(6f, 0f, -5f);
		this.Hangouts.List[StudentID].transform.eulerAngles = new Vector3(0f, 90f, 0f);
		ScheduleBlock scheduleBlock = studentScript.ScheduleBlocks[2];
		scheduleBlock.destination = "Hangout";
		scheduleBlock.action = "Relax";
		ScheduleBlock scheduleBlock2 = studentScript.ScheduleBlocks[4];
		scheduleBlock2.destination = "Hangout";
		scheduleBlock2.action = "Relax";
		ScheduleBlock scheduleBlock3 = studentScript.ScheduleBlocks[7];
		scheduleBlock3.destination = "Hangout";
		scheduleBlock3.action = "Relax";
		this.Students[StudentID].GetDestinations();
		this.Students[StudentID].Pathfinding.target = this.Students[StudentID].Destinations[this.Students[StudentID].Phase];
		this.Students[StudentID].CurrentDestination = this.Students[StudentID].Destinations[this.Students[StudentID].Phase];
		this.SuitorLocker = this.LockerPositions[StudentID];
	}

	// Token: 0x06001DBA RID: 7610 RVA: 0x0016B680 File Offset: 0x00169880
	public void UpdateRivalEliminationDetails(int StudentID)
	{
		this.RivalKilledSelf[StudentID - 10] = true;
	}

	// Token: 0x040035E5 RID: 13797
	private PortraitChanScript NewPortraitChan;

	// Token: 0x040035E6 RID: 13798
	private GameObject NewStudent;

	// Token: 0x040035E7 RID: 13799
	public StudentScript[] Students;

	// Token: 0x040035E8 RID: 13800
	public OsanaThursdayAfterClassEventScript OsanaThursdayAfterClassEvent;

	// Token: 0x040035E9 RID: 13801
	public SelectiveGrayscale SmartphoneSelectiveGreyscale;

	// Token: 0x040035EA RID: 13802
	public PickpocketMinigameScript PickpocketMinigame;

	// Token: 0x040035EB RID: 13803
	public FindStudentLockerScript FindStudentLocker;

	// Token: 0x040035EC RID: 13804
	public PopulationManagerScript PopulationManager;

	// Token: 0x040035ED RID: 13805
	public SelectiveGrayscale HandSelectiveGreyscale;

	// Token: 0x040035EE RID: 13806
	public ReputationSetterScript ReputationSetter;

	// Token: 0x040035EF RID: 13807
	public SkinnedMeshRenderer FemaleShowerCurtain;

	// Token: 0x040035F0 RID: 13808
	public CleaningManagerScript CleaningManager;

	// Token: 0x040035F1 RID: 13809
	public StolenPhoneSpotScript StolenPhoneSpot;

	// Token: 0x040035F2 RID: 13810
	public SelectiveGrayscale SelectiveGreyscale;

	// Token: 0x040035F3 RID: 13811
	public InterestManagerScript InterestManager;

	// Token: 0x040035F4 RID: 13812
	public CombatMinigameScript CombatMinigame;

	// Token: 0x040035F5 RID: 13813
	public DatingMinigameScript DatingMinigame;

	// Token: 0x040035F6 RID: 13814
	public SnappedYandereScript SnappedYandere;

	// Token: 0x040035F7 RID: 13815
	public TextureManagerScript TextureManager;

	// Token: 0x040035F8 RID: 13816
	public TutorialWindowScript TutorialWindow;

	// Token: 0x040035F9 RID: 13817
	public QualityManagerScript QualityManager;

	// Token: 0x040035FA RID: 13818
	public GenericRivalBagScript RivalBookBag;

	// Token: 0x040035FB RID: 13819
	public ComputerGamesScript ComputerGames;

	// Token: 0x040035FC RID: 13820
	public DialogueWheelScript DialogueWheel;

	// Token: 0x040035FD RID: 13821
	public EmergencyExitScript EmergencyExit;

	// Token: 0x040035FE RID: 13822
	public MemorialSceneScript MemorialScene;

	// Token: 0x040035FF RID: 13823
	public TranqDetectorScript TranqDetector;

	// Token: 0x04003600 RID: 13824
	public WitnessCameraScript WitnessCamera;

	// Token: 0x04003601 RID: 13825
	public ConvoManagerScript ConvoManager;

	// Token: 0x04003602 RID: 13826
	public TallLockerScript CommunalLocker;

	// Token: 0x04003603 RID: 13827
	public BloodParentScript BloodParent;

	// Token: 0x04003604 RID: 13828
	public CabinetDoorScript CabinetDoor;

	// Token: 0x04003605 RID: 13829
	public ClubManagerScript ClubManager;

	// Token: 0x04003606 RID: 13830
	public LightSwitchScript LightSwitch;

	// Token: 0x04003607 RID: 13831
	public LoveManagerScript LoveManager;

	// Token: 0x04003608 RID: 13832
	public MiyukiEnemyScript MiyukiEnemy;

	// Token: 0x04003609 RID: 13833
	public TaskManagerScript TaskManager;

	// Token: 0x0400360A RID: 13834
	public Collider MaleLockerRoomArea;

	// Token: 0x0400360B RID: 13835
	public StudentScript BloodReporter;

	// Token: 0x0400360C RID: 13836
	public HeadmasterScript Headmaster;

	// Token: 0x0400360D RID: 13837
	public NoteWindowScript NoteWindow;

	// Token: 0x0400360E RID: 13838
	public ReputationScript Reputation;

	// Token: 0x0400360F RID: 13839
	public WeaponScript FragileWeapon;

	// Token: 0x04003610 RID: 13840
	public AudioSource PracticeVocals;

	// Token: 0x04003611 RID: 13841
	public AudioSource PracticeMusic;

	// Token: 0x04003612 RID: 13842
	public ContainerScript Container;

	// Token: 0x04003613 RID: 13843
	public RedStringScript RedString;

	// Token: 0x04003614 RID: 13844
	public RingEventScript RingEvent;

	// Token: 0x04003615 RID: 13845
	public RivalPoseScript RivalPose;

	// Token: 0x04003616 RID: 13846
	public GazerEyesScript Shinigami;

	// Token: 0x04003617 RID: 13847
	public HologramScript Holograms;

	// Token: 0x04003618 RID: 13848
	public RobotArmScript RobotArms;

	// Token: 0x04003619 RID: 13849
	public AlphabetScript Alphabet;

	// Token: 0x0400361A RID: 13850
	public FanCoverScript FanCover;

	// Token: 0x0400361B RID: 13851
	public PickUpScript Flashlight;

	// Token: 0x0400361C RID: 13852
	public FountainScript Fountain;

	// Token: 0x0400361D RID: 13853
	public PoseModeScript PoseMode;

	// Token: 0x0400361E RID: 13854
	public TutorialScript Tutorial;

	// Token: 0x0400361F RID: 13855
	public Collider LockerRoomArea;

	// Token: 0x04003620 RID: 13856
	public StudentScript Reporter;

	// Token: 0x04003621 RID: 13857
	public DoorScript GamingDoor;

	// Token: 0x04003622 RID: 13858
	public GhostScript GhostChan;

	// Token: 0x04003623 RID: 13859
	public SchemesScript Schemes;

	// Token: 0x04003624 RID: 13860
	public TributeScript Tribute;

	// Token: 0x04003625 RID: 13861
	public YandereScript Yandere;

	// Token: 0x04003626 RID: 13862
	public ListScript MeetSpots;

	// Token: 0x04003627 RID: 13863
	public MirrorScript Mirror;

	// Token: 0x04003628 RID: 13864
	public PoliceScript Police;

	// Token: 0x04003629 RID: 13865
	public DoorScript ShedDoor;

	// Token: 0x0400362A RID: 13866
	public UILabel ErrorLabel;

	// Token: 0x0400362B RID: 13867
	public RestScript Rest;

	// Token: 0x0400362C RID: 13868
	public TagScript Tag;

	// Token: 0x0400362D RID: 13869
	public UISprite HUD;

	// Token: 0x0400362E RID: 13870
	public Collider EastBathroomArea;

	// Token: 0x0400362F RID: 13871
	public Collider WestBathroomArea;

	// Token: 0x04003630 RID: 13872
	public Collider IncineratorArea;

	// Token: 0x04003631 RID: 13873
	public Collider HeadmasterArea;

	// Token: 0x04003632 RID: 13874
	public Collider GardenArea;

	// Token: 0x04003633 RID: 13875
	public Collider PoolStairs;

	// Token: 0x04003634 RID: 13876
	public Collider TreeArea;

	// Token: 0x04003635 RID: 13877
	public Collider NEStairs;

	// Token: 0x04003636 RID: 13878
	public Collider NWStairs;

	// Token: 0x04003637 RID: 13879
	public Collider SEStairs;

	// Token: 0x04003638 RID: 13880
	public Collider SWStairs;

	// Token: 0x04003639 RID: 13881
	public DoorScript AltFemaleVomitDoor;

	// Token: 0x0400363A RID: 13882
	public DoorScript FemaleVomitDoor;

	// Token: 0x0400363B RID: 13883
	public CounselorDoorScript[] CounselorDoor;

	// Token: 0x0400363C RID: 13884
	public ParticleSystem AltFemaleDrownSplashes;

	// Token: 0x0400363D RID: 13885
	public ParticleSystem FemaleDrownSplashes;

	// Token: 0x0400363E RID: 13886
	public OfferHelpScript EightiesOfferHelp;

	// Token: 0x0400363F RID: 13887
	public OfferHelpScript FragileOfferHelp;

	// Token: 0x04003640 RID: 13888
	public OfferHelpScript OsanaOfferHelp;

	// Token: 0x04003641 RID: 13889
	public OfferHelpScript OfferHelp;

	// Token: 0x04003642 RID: 13890
	public Transform MaleLockerRoomChangingSpot;

	// Token: 0x04003643 RID: 13891
	public Transform AltFemaleVomitSpot;

	// Token: 0x04003644 RID: 13892
	public Transform RaibaruMentorSpot;

	// Token: 0x04003645 RID: 13893
	public Transform SleepSpot;

	// Token: 0x04003646 RID: 13894
	public Transform PyroSpot;

	// Token: 0x04003647 RID: 13895
	public ListScript EightiesSpots;

	// Token: 0x04003648 RID: 13896
	public ListScript SearchPatrols;

	// Token: 0x04003649 RID: 13897
	public ListScript CleaningSpots;

	// Token: 0x0400364A RID: 13898
	public ListScript Patrols;

	// Token: 0x0400364B RID: 13899
	public ClockScript Clock;

	// Token: 0x0400364C RID: 13900
	public JsonScript JSON;

	// Token: 0x0400364D RID: 13901
	public GateScript Gate;

	// Token: 0x0400364E RID: 13902
	public ListScript LunchWitnessPositions;

	// Token: 0x0400364F RID: 13903
	public ListScript EntranceVectors;

	// Token: 0x04003650 RID: 13904
	public ListScript ShowerLockers;

	// Token: 0x04003651 RID: 13905
	public ListScript Week1Hangouts;

	// Token: 0x04003652 RID: 13906
	public ListScript Week2Hangouts;

	// Token: 0x04003653 RID: 13907
	public ListScript GoAwaySpots;

	// Token: 0x04003654 RID: 13908
	public ListScript HidingSpots;

	// Token: 0x04003655 RID: 13909
	public ListScript LunchSpots;

	// Token: 0x04003656 RID: 13910
	public ListScript Stairways;

	// Token: 0x04003657 RID: 13911
	public ListScript Hangouts;

	// Token: 0x04003658 RID: 13912
	public ListScript Lockers;

	// Token: 0x04003659 RID: 13913
	public ListScript Podiums;

	// Token: 0x0400365A RID: 13914
	public ListScript Clubs;

	// Token: 0x0400365B RID: 13915
	public ListScript EightiesLunchSpots;

	// Token: 0x0400365C RID: 13916
	public ListScript EightiesHangouts;

	// Token: 0x0400365D RID: 13917
	public ListScript EightiesPatrols;

	// Token: 0x0400365E RID: 13918
	public ListScript EightiesClubs;

	// Token: 0x0400365F RID: 13919
	public BodyHidingLockerScript[] BodyHidingLockers;

	// Token: 0x04003660 RID: 13920
	public ChangingBoothScript[] ChangingBooths;

	// Token: 0x04003661 RID: 13921
	public SelectiveGrayscale[] SpyGrayscales;

	// Token: 0x04003662 RID: 13922
	public GradingPaperScript[] FacultyDesks;

	// Token: 0x04003663 RID: 13923
	public DynamicBone[] AllDynamicBones;

	// Token: 0x04003664 RID: 13924
	public StudentScript[] WitnessList;

	// Token: 0x04003665 RID: 13925
	public TrashCanScript[] TrashCans;

	// Token: 0x04003666 RID: 13926
	public StudentScript[] Teachers;

	// Token: 0x04003667 RID: 13927
	public GloveScript[] GloveList;

	// Token: 0x04003668 RID: 13928
	public ListScript[] Seats;

	// Token: 0x04003669 RID: 13929
	public BugScript[] Bugs;

	// Token: 0x0400366A RID: 13930
	public Collider[] Blood;

	// Token: 0x0400366B RID: 13931
	public Collider[] Limbs;

	// Token: 0x0400366C RID: 13932
	public Transform[] TeacherGuardLocation;

	// Token: 0x0400366D RID: 13933
	public Transform[] CorpseGuardLocation;

	// Token: 0x0400366E RID: 13934
	public Transform[] PossibleRandomSpots;

	// Token: 0x0400366F RID: 13935
	public Transform[] BloodGuardLocation;

	// Token: 0x04003670 RID: 13936
	public Transform[] SleuthDestinations;

	// Token: 0x04003671 RID: 13937
	public Transform[] StrippingPositions;

	// Token: 0x04003672 RID: 13938
	public Transform[] GardeningPatrols;

	// Token: 0x04003673 RID: 13939
	public Transform[] MartialArtsSpots;

	// Token: 0x04003674 RID: 13940
	public Transform[] PopularGirlSpots;

	// Token: 0x04003675 RID: 13941
	public Transform[] LockerPositions;

	// Token: 0x04003676 RID: 13942
	public Transform[] PhotoShootSpots;

	// Token: 0x04003677 RID: 13943
	public Transform[] RivalGuardSpots;

	// Token: 0x04003678 RID: 13944
	public Transform[] BackstageSpots;

	// Token: 0x04003679 RID: 13945
	public Transform[] SpawnPositions;

	// Token: 0x0400367A RID: 13946
	public Transform[] GraffitiSpots;

	// Token: 0x0400367B RID: 13947
	public Transform[] PracticeSpots;

	// Token: 0x0400367C RID: 13948
	public Transform[] SunbatheSpots;

	// Token: 0x0400367D RID: 13949
	public Transform[] MeetingSpots;

	// Token: 0x0400367E RID: 13950
	public Transform[] PerformSpots;

	// Token: 0x0400367F RID: 13951
	public Transform[] PinDownSpots;

	// Token: 0x04003680 RID: 13952
	public Transform[] ShockedSpots;

	// Token: 0x04003681 RID: 13953
	public Transform[] FridaySpots;

	// Token: 0x04003682 RID: 13954
	public Transform[] MiyukiSpots;

	// Token: 0x04003683 RID: 13955
	public Transform[] RandomSpots;

	// Token: 0x04003684 RID: 13956
	public Transform[] SocialSeats;

	// Token: 0x04003685 RID: 13957
	public Transform[] SocialSpots;

	// Token: 0x04003686 RID: 13958
	public Transform[] SupplySpots;

	// Token: 0x04003687 RID: 13959
	public Transform[] BullySpots;

	// Token: 0x04003688 RID: 13960
	public Transform[] DramaSpots;

	// Token: 0x04003689 RID: 13961
	public Transform[] MournSpots;

	// Token: 0x0400368A RID: 13962
	public Transform[] ClubZones;

	// Token: 0x0400368B RID: 13963
	public Transform[] FleeSpots;

	// Token: 0x0400368C RID: 13964
	public Transform[] FoodTrays;

	// Token: 0x0400368D RID: 13965
	public Transform[] SulkSpots;

	// Token: 0x0400368E RID: 13966
	public Transform[] WaitSpots;

	// Token: 0x0400368F RID: 13967
	public Transform[] Uniforms;

	// Token: 0x04003690 RID: 13968
	public Transform[] Plates;

	// Token: 0x04003691 RID: 13969
	public Transform[] FemaleVomitSpots;

	// Token: 0x04003692 RID: 13970
	public Transform[] MaleVomitSpots;

	// Token: 0x04003693 RID: 13971
	public Transform[] FemaleWashSpots;

	// Token: 0x04003694 RID: 13972
	public Transform[] MaleWashSpots;

	// Token: 0x04003695 RID: 13973
	public GameObject[] ShrineCollectibles;

	// Token: 0x04003696 RID: 13974
	public GameObject[] GarbageBagList;

	// Token: 0x04003697 RID: 13975
	public GameObject[] Graffiti;

	// Token: 0x04003698 RID: 13976
	public GameObject[] Canvas;

	// Token: 0x04003699 RID: 13977
	public DoorScript[] FemaleToiletDoors;

	// Token: 0x0400369A RID: 13978
	public DoorScript[] MaleToiletDoors;

	// Token: 0x0400369B RID: 13979
	public DrinkingFountainScript[] DrinkingFountains;

	// Token: 0x0400369C RID: 13980
	public Renderer[] FridayPaintings;

	// Token: 0x0400369D RID: 13981
	public bool[] PantyShotTaken;

	// Token: 0x0400369E RID: 13982
	public bool[] SeatsTaken11;

	// Token: 0x0400369F RID: 13983
	public bool[] SeatsTaken12;

	// Token: 0x040036A0 RID: 13984
	public bool[] SeatsTaken21;

	// Token: 0x040036A1 RID: 13985
	public bool[] SeatsTaken22;

	// Token: 0x040036A2 RID: 13986
	public bool[] SeatsTaken31;

	// Token: 0x040036A3 RID: 13987
	public bool[] SeatsTaken32;

	// Token: 0x040036A4 RID: 13988
	public bool[] NoBully;

	// Token: 0x040036A5 RID: 13989
	public Quaternion[] OriginalClubRotations;

	// Token: 0x040036A6 RID: 13990
	public Vector3[] OriginalClubPositions;

	// Token: 0x040036A7 RID: 13991
	public Collider RivalDeskCollider;

	// Token: 0x040036A8 RID: 13992
	public Transform FollowerLookAtTarget;

	// Token: 0x040036A9 RID: 13993
	public Transform SuitorConfessionSpot;

	// Token: 0x040036AA RID: 13994
	public Transform RivalConfessionSpot;

	// Token: 0x040036AB RID: 13995
	public Transform OriginalLyricsSpot;

	// Token: 0x040036AC RID: 13996
	public Transform EightiesLyricDesk;

	// Token: 0x040036AD RID: 13997
	public Transform FragileSlaveSpot;

	// Token: 0x040036AE RID: 13998
	public Transform FemaleCoupleSpot;

	// Token: 0x040036AF RID: 13999
	public Transform YandereStripSpot;

	// Token: 0x040036B0 RID: 14000
	public Transform FemaleBatheSpot;

	// Token: 0x040036B1 RID: 14001
	public Transform FemaleStalkSpot;

	// Token: 0x040036B2 RID: 14002
	public Transform FemaleStripSpot;

	// Token: 0x040036B3 RID: 14003
	public Transform FemaleVomitSpot;

	// Token: 0x040036B4 RID: 14004
	public Transform MedicineCabinet;

	// Token: 0x040036B5 RID: 14005
	public Transform PyroWateringCan;

	// Token: 0x040036B6 RID: 14006
	public Transform ConfessionSpot;

	// Token: 0x040036B7 RID: 14007
	public Transform CorpseLocation;

	// Token: 0x040036B8 RID: 14008
	public Transform FemaleWashSpot;

	// Token: 0x040036B9 RID: 14009
	public Transform MaleCoupleSpot;

	// Token: 0x040036BA RID: 14010
	public Transform LastKnownOsana;

	// Token: 0x040036BB RID: 14011
	public Transform AirGuitarSpot;

	// Token: 0x040036BC RID: 14012
	public Transform BloodLocation;

	// Token: 0x040036BD RID: 14013
	public Transform FastBatheSpot;

	// Token: 0x040036BE RID: 14014
	public Transform InfirmarySeat;

	// Token: 0x040036BF RID: 14015
	public Transform MaleBatheSpot;

	// Token: 0x040036C0 RID: 14016
	public Transform MaleStalkSpot;

	// Token: 0x040036C1 RID: 14017
	public Transform MaleStripSpot;

	// Token: 0x040036C2 RID: 14018
	public Transform MaleVomitSpot;

	// Token: 0x040036C3 RID: 14019
	public Transform SacrificeSpot;

	// Token: 0x040036C4 RID: 14020
	public Transform WeaponBoxSpot;

	// Token: 0x040036C5 RID: 14021
	public Transform FountainSpot;

	// Token: 0x040036C6 RID: 14022
	public Transform MaleWashSpot;

	// Token: 0x040036C7 RID: 14023
	public Transform SenpaiLocker;

	// Token: 0x040036C8 RID: 14024
	public Transform SuitorLocker;

	// Token: 0x040036C9 RID: 14025
	public Transform RomanceSpot;

	// Token: 0x040036CA RID: 14026
	public Transform BrokenSpot;

	// Token: 0x040036CB RID: 14027
	public Transform BullyGroup;

	// Token: 0x040036CC RID: 14028
	public Transform EdgeOfGrid;

	// Token: 0x040036CD RID: 14029
	public Transform GoAwaySpot;

	// Token: 0x040036CE RID: 14030
	public Transform LyricsSpot;

	// Token: 0x040036CF RID: 14031
	public Transform MainCamera;

	// Token: 0x040036D0 RID: 14032
	public Transform SuitorSpot;

	// Token: 0x040036D1 RID: 14033
	public Transform ToolTarget;

	// Token: 0x040036D2 RID: 14034
	public Transform MiyukiCat;

	// Token: 0x040036D3 RID: 14035
	public Transform ShameSpot;

	// Token: 0x040036D4 RID: 14036
	public Transform SlaveSpot;

	// Token: 0x040036D5 RID: 14037
	public Transform Papers;

	// Token: 0x040036D6 RID: 14038
	public Transform Exit;

	// Token: 0x040036D7 RID: 14039
	public Transform[] FemaleRestSpots;

	// Token: 0x040036D8 RID: 14040
	public Transform[] MaleRestSpots;

	// Token: 0x040036D9 RID: 14041
	public GameObject ModernRivalBookBag;

	// Token: 0x040036DA RID: 14042
	public GameObject LovestruckCamera;

	// Token: 0x040036DB RID: 14043
	public GameObject WednesdayGiftBox;

	// Token: 0x040036DC RID: 14044
	public GameObject DelinquentRadio;

	// Token: 0x040036DD RID: 14045
	public GameObject FridayTestNotes;

	// Token: 0x040036DE RID: 14046
	public GameObject EndingCutscene;

	// Token: 0x040036DF RID: 14047
	public GameObject GardenBlockade;

	// Token: 0x040036E0 RID: 14048
	public GameObject FPSDisplayBG;

	// Token: 0x040036E1 RID: 14049
	public GameObject PortraitChan;

	// Token: 0x040036E2 RID: 14050
	public GameObject RandomPatrol;

	// Token: 0x040036E3 RID: 14051
	public GameObject ChaseCamera;

	// Token: 0x040036E4 RID: 14052
	public GameObject EmptyObject;

	// Token: 0x040036E5 RID: 14053
	public GameObject MondayBento;

	// Token: 0x040036E6 RID: 14054
	public GameObject PortraitKun;

	// Token: 0x040036E7 RID: 14055
	public GameObject StudentChan;

	// Token: 0x040036E8 RID: 14056
	public GameObject FPSDisplay;

	// Token: 0x040036E9 RID: 14057
	public GameObject PyroFlames;

	// Token: 0x040036EA RID: 14058
	public GameObject StudentKun;

	// Token: 0x040036EB RID: 14059
	public GameObject RivalChan;

	// Token: 0x040036EC RID: 14060
	public GameObject BakeSale;

	// Token: 0x040036ED RID: 14061
	public GameObject Canvases;

	// Token: 0x040036EE RID: 14062
	public GameObject Medicine;

	// Token: 0x040036EF RID: 14063
	public GameObject DrumSet;

	// Token: 0x040036F0 RID: 14064
	public GameObject Flowers;

	// Token: 0x040036F1 RID: 14065
	public GameObject Portal;

	// Token: 0x040036F2 RID: 14066
	public GameObject Gift;

	// Token: 0x040036F3 RID: 14067
	public GameObject Note;

	// Token: 0x040036F4 RID: 14068
	public float[] SpawnTimes;

	// Token: 0x040036F5 RID: 14069
	public int InitialSabotageProgress;

	// Token: 0x040036F6 RID: 14070
	public int LowDetailThreshold;

	// Token: 0x040036F7 RID: 14071
	public int FarAnimThreshold;

	// Token: 0x040036F8 RID: 14072
	public int MartialArtsPhase;

	// Token: 0x040036F9 RID: 14073
	public int OriginalUniforms = 2;

	// Token: 0x040036FA RID: 14074
	public int SabotageProgress;

	// Token: 0x040036FB RID: 14075
	public int StudentsSpawned;

	// Token: 0x040036FC RID: 14076
	public int SedatedStudents;

	// Token: 0x040036FD RID: 14077
	public int StudentsTotal = 13;

	// Token: 0x040036FE RID: 14078
	public int TeachersTotal = 6;

	// Token: 0x040036FF RID: 14079
	public int GirlsSpawned;

	// Token: 0x04003700 RID: 14080
	public int TagStudentID;

	// Token: 0x04003701 RID: 14081
	public int GarbageBags;

	// Token: 0x04003702 RID: 14082
	public int NewUniforms;

	// Token: 0x04003703 RID: 14083
	public int NPCsSpawned;

	// Token: 0x04003704 RID: 14084
	public int SleuthPhase = 1;

	// Token: 0x04003705 RID: 14085
	public int DramaPhase = 1;

	// Token: 0x04003706 RID: 14086
	public int NPCsTotal;

	// Token: 0x04003707 RID: 14087
	public int WeekLimit = 2;

	// Token: 0x04003708 RID: 14088
	public int Witnesses;

	// Token: 0x04003709 RID: 14089
	public int PinPhase;

	// Token: 0x0400370A RID: 14090
	public int Bullies;

	// Token: 0x0400370B RID: 14091
	public int Speaker = 21;

	// Token: 0x0400370C RID: 14092
	public int Frame;

	// Token: 0x0400370D RID: 14093
	public int Bones;

	// Token: 0x0400370E RID: 14094
	public int Week;

	// Token: 0x0400370F RID: 14095
	public int GymTeacherID = 100;

	// Token: 0x04003710 RID: 14096
	public int ObstacleID = 6;

	// Token: 0x04003711 RID: 14097
	public int CurrentID;

	// Token: 0x04003712 RID: 14098
	public int SuitorID = 13;

	// Token: 0x04003713 RID: 14099
	public int VictimID;

	// Token: 0x04003714 RID: 14100
	public int NurseID = 93;

	// Token: 0x04003715 RID: 14101
	public int RivalID = 7;

	// Token: 0x04003716 RID: 14102
	public int SpawnID;

	// Token: 0x04003717 RID: 14103
	public int GloveID;

	// Token: 0x04003718 RID: 14104
	public int ID;

	// Token: 0x04003719 RID: 14105
	public bool ReactedToGameLeader;

	// Token: 0x0400371A RID: 14106
	public bool EmbarassingSecret;

	// Token: 0x0400371B RID: 14107
	public bool MurderTakingPlace;

	// Token: 0x0400371C RID: 14108
	public bool ControllerShrink;

	// Token: 0x0400371D RID: 14109
	public bool EightiesTutorial;

	// Token: 0x0400371E RID: 14110
	public bool GasInWateringCan;

	// Token: 0x0400371F RID: 14111
	public bool ReturnedFromSave;

	// Token: 0x04003720 RID: 14112
	public bool DisableFarAnims;

	// Token: 0x04003721 RID: 14113
	public bool GameOverIminent;

	// Token: 0x04003722 RID: 14114
	public bool RivalEliminated;

	// Token: 0x04003723 RID: 14115
	public bool TakingPortraits;

	// Token: 0x04003724 RID: 14116
	public bool TeachersSpawned;

	// Token: 0x04003725 RID: 14117
	public bool MetalDetectors;

	// Token: 0x04003726 RID: 14118
	public bool RecordingVideo;

	// Token: 0x04003727 RID: 14119
	public bool TutorialActive;

	// Token: 0x04003728 RID: 14120
	public bool YandereVisible;

	// Token: 0x04003729 RID: 14121
	public bool CanSelfReport;

	// Token: 0x0400372A RID: 14122
	public bool NoClubMeeting;

	// Token: 0x0400372B RID: 14123
	public bool UpdatedBlood;

	// Token: 0x0400372C RID: 14124
	public bool YandereDying;

	// Token: 0x0400372D RID: 14125
	public bool FirstUpdate;

	// Token: 0x0400372E RID: 14126
	public bool MissionMode;

	// Token: 0x0400372F RID: 14127
	public bool OpenCurtain;

	// Token: 0x04003730 RID: 14128
	public bool PinningDown;

	// Token: 0x04003731 RID: 14129
	public bool RoofFenceUp;

	// Token: 0x04003732 RID: 14130
	public bool SpawnNobody;

	// Token: 0x04003733 RID: 14131
	public bool YandereLate;

	// Token: 0x04003734 RID: 14132
	public bool EmptyDemon;

	// Token: 0x04003735 RID: 14133
	public bool ForceSpawn;

	// Token: 0x04003736 RID: 14134
	public bool PoolClosed;

	// Token: 0x04003737 RID: 14135
	public bool NoGravity;

	// Token: 0x04003738 RID: 14136
	public bool Randomize;

	// Token: 0x04003739 RID: 14137
	public bool Eighties;

	// Token: 0x0400373A RID: 14138
	public bool LoveSick;

	// Token: 0x0400373B RID: 14139
	public bool NoSpeech;

	// Token: 0x0400373C RID: 14140
	public bool Meeting;

	// Token: 0x0400373D RID: 14141
	public bool Jammed;

	// Token: 0x0400373E RID: 14142
	public bool Spooky;

	// Token: 0x0400373F RID: 14143
	public bool Bully;

	// Token: 0x04003740 RID: 14144
	public bool Ebola;

	// Token: 0x04003741 RID: 14145
	public bool Gaze;

	// Token: 0x04003742 RID: 14146
	public bool Pose;

	// Token: 0x04003743 RID: 14147
	public bool Sans;

	// Token: 0x04003744 RID: 14148
	public bool Stop;

	// Token: 0x04003745 RID: 14149
	public bool Egg;

	// Token: 0x04003746 RID: 14150
	public bool Six;

	// Token: 0x04003747 RID: 14151
	public bool AoT;

	// Token: 0x04003748 RID: 14152
	public bool DK;

	// Token: 0x04003749 RID: 14153
	public float Atmosphere;

	// Token: 0x0400374A RID: 14154
	public float OpenValue = 100f;

	// Token: 0x0400374B RID: 14155
	public float YandereHeight = 999f;

	// Token: 0x0400374C RID: 14156
	public float MeetingTimer;

	// Token: 0x0400374D RID: 14157
	public float PinDownTimer;

	// Token: 0x0400374E RID: 14158
	public float ChangeTimer;

	// Token: 0x0400374F RID: 14159
	public float SleuthTimer;

	// Token: 0x04003750 RID: 14160
	public float DramaTimer;

	// Token: 0x04003751 RID: 14161
	public float GrowTimer;

	// Token: 0x04003752 RID: 14162
	public float LowestRep;

	// Token: 0x04003753 RID: 14163
	public float PinTimer;

	// Token: 0x04003754 RID: 14164
	public float Timer;

	// Token: 0x04003755 RID: 14165
	public float[] StudentReps;

	// Token: 0x04003756 RID: 14166
	public string[] ColorNames;

	// Token: 0x04003757 RID: 14167
	public string[] MaleNames;

	// Token: 0x04003758 RID: 14168
	public string[] FirstNames;

	// Token: 0x04003759 RID: 14169
	public string[] LastNames;

	// Token: 0x0400375A RID: 14170
	public float[] TargetSize;

	// Token: 0x0400375B RID: 14171
	public int[] SuitorIDs;

	// Token: 0x0400375C RID: 14172
	public AudioSource[] FountainAudio;

	// Token: 0x0400375D RID: 14173
	public AudioClip YanderePinDown;

	// Token: 0x0400375E RID: 14174
	public AudioClip PinDownSFX;

	// Token: 0x0400375F RID: 14175
	[SerializeField]
	private int ProblemID = -1;

	// Token: 0x04003760 RID: 14176
	public GameObject Cardigan;

	// Token: 0x04003761 RID: 14177
	public SkinnedMeshRenderer CardiganRenderer;

	// Token: 0x04003762 RID: 14178
	public Mesh OpenChipBag;

	// Token: 0x04003763 RID: 14179
	public Vignetting[] Vignettes;

	// Token: 0x04003764 RID: 14180
	public Renderer[] Trees;

	// Token: 0x04003765 RID: 14181
	public DoorScript[] AllDoors;

	// Token: 0x04003766 RID: 14182
	public OcclusionPortal PlazaOccluder;

	// Token: 0x04003767 RID: 14183
	public AudioClip SlidingDoorOpen;

	// Token: 0x04003768 RID: 14184
	public AudioClip SlidingDoorShut;

	// Token: 0x04003769 RID: 14185
	public AudioClip SwingingDoorOpen;

	// Token: 0x0400376A RID: 14186
	public AudioClip SwingingDoorShut;

	// Token: 0x0400376B RID: 14187
	public bool SeatOccupied;

	// Token: 0x0400376C RID: 14188
	public int Class = 1;

	// Token: 0x0400376D RID: 14189
	public int Thins;

	// Token: 0x0400376E RID: 14190
	public int Seriouses;

	// Token: 0x0400376F RID: 14191
	public int Rounds;

	// Token: 0x04003770 RID: 14192
	public int Sads;

	// Token: 0x04003771 RID: 14193
	public int Means;

	// Token: 0x04003772 RID: 14194
	public int Smugs;

	// Token: 0x04003773 RID: 14195
	public int Gentles;

	// Token: 0x04003774 RID: 14196
	public int Rival1s;

	// Token: 0x04003775 RID: 14197
	public DoorScript[] Doors;

	// Token: 0x04003776 RID: 14198
	public int DoorID;

	// Token: 0x04003777 RID: 14199
	private int OpenedDoors;

	// Token: 0x04003778 RID: 14200
	private int SnappedStudents = 1;

	// Token: 0x04003779 RID: 14201
	public Texture PureWhite;

	// Token: 0x0400377A RID: 14202
	public Transform[] BullySnapPosition;

	// Token: 0x0400377B RID: 14203
	public OcclusionPortal WindowOccluder;

	// Token: 0x0400377C RID: 14204
	public bool TransparentWindows;

	// Token: 0x0400377D RID: 14205
	public bool TransWindows;

	// Token: 0x0400377E RID: 14206
	public Renderer Window;

	// Token: 0x0400377F RID: 14207
	private ScheduleBlock scheduleBlock;

	// Token: 0x04003780 RID: 14208
	public OsanaPoolEventScript OsanaPoolEvent;

	// Token: 0x04003781 RID: 14209
	public bool[] HeadmasterTapesCollected;

	// Token: 0x04003782 RID: 14210
	public bool[] PantiesCollected;

	// Token: 0x04003783 RID: 14211
	public bool[] MangaCollected;

	// Token: 0x04003784 RID: 14212
	public bool[] TapesCollected;

	// Token: 0x04003785 RID: 14213
	public SkinnedMeshRenderer LandLinePhone;

	// Token: 0x04003786 RID: 14214
	public PostProcessingBehaviour Profile;

	// Token: 0x04003787 RID: 14215
	public Light HauntedBathroomLight;

	// Token: 0x04003788 RID: 14216
	public GameObject OutOfOrderSign;

	// Token: 0x04003789 RID: 14217
	public Transform LandLineSpot;

	// Token: 0x0400378A RID: 14218
	public UILabel EventSubtitle;

	// Token: 0x0400378B RID: 14219
	public string EightiesPrefix;

	// Token: 0x0400378C RID: 14220
	public Texture EightiesBG;

	// Token: 0x0400378D RID: 14221
	public UITexture PhotoBG;

	// Token: 0x0400378E RID: 14222
	public Font Arial;

	// Token: 0x0400378F RID: 14223
	public Font VCR;

	// Token: 0x04003790 RID: 14224
	public RectTransform FPS;

	// Token: 0x04003791 RID: 14225
	public RectTransform FPSValue;

	// Token: 0x04003792 RID: 14226
	public GameObject ModernDayPropsLMC;

	// Token: 0x04003793 RID: 14227
	public GameObject ModernDayRoomLMC;

	// Token: 0x04003794 RID: 14228
	public GameObject EightiesPropsLMC;

	// Token: 0x04003795 RID: 14229
	public GameObject EightiesRoomLMC;

	// Token: 0x04003796 RID: 14230
	public GameObject NewspaperClubProps;

	// Token: 0x04003797 RID: 14231
	public GameObject NewspaperClubRoom;

	// Token: 0x04003798 RID: 14232
	public GameObject InfoClubProps;

	// Token: 0x04003799 RID: 14233
	public GameObject InfoClubRoom;

	// Token: 0x0400379A RID: 14234
	public GameObject ModernDayScienceClub;

	// Token: 0x0400379B RID: 14235
	public GameObject ModernDayScienceProps;

	// Token: 0x0400379C RID: 14236
	public GameObject EightiesScienceClub;

	// Token: 0x0400379D RID: 14237
	public GameObject EightiesScienceProps;

	// Token: 0x0400379E RID: 14238
	public GameObject[] ModernDayProps;

	// Token: 0x0400379F RID: 14239
	public GameObject[] EightiesProps;

	// Token: 0x040037A0 RID: 14240
	public GameObject IdolStage;

	// Token: 0x040037A1 RID: 14241
	public GameObject PoolPhotoShootCameras;

	// Token: 0x040037A2 RID: 14242
	public GameObject Journalist;

	// Token: 0x040037A3 RID: 14243
	public UIPanel FreeFloatingPanel;

	// Token: 0x040037A4 RID: 14244
	public bool[] RivalKilledSelf;
}
