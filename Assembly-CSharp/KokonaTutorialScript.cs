using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KokonaTutorialScript : MonoBehaviour
{
	public GameObject SpawnedTarp;

	public int Phase;

	public StudentManagerScript StudentManager;

	public WeaponManagerScript WeaponManager;

	public IncineratorScript Incinerator;

	public WaterCoolerScript WaterCooler;

	public PoisonBottleScript RatPoison;

	public PoisonBottleScript Sedative;

	public TranqCaseScript TranqCase;

	public PickUpScript CarBattery;

	public AIPathSerializer AStar;

	public YandereScript Yandere;

	public PickUpScript JerryCan;

	public VoidGoddessScript VG;

	public GloveScript Raincoat;

	public PickUpScript Bleach;

	public BucketScript Bucket;

	public PickUpScript Candle;

	public PickUpScript Tarp;

	public TutorialScript T;

	public MopScript Mop;

	public Transform[] Patrols;

	public TutorialObjectScript[] TutorialObject;

	public GameObject EightiesTutorialGraphics;

	public GameObject SpawnedClothing;

	public GameObject SpoolOfThread;

	public GameObject MaskingTape;

	public GameObject[] TutorialSets;

	public GameObject[] TutorialWall;

	public GameObject[] PoliceIcons;

	public DoorScript[] HomeEcDoors;

	public DoorScript[] Doors;

	public UILabel[] PoliceLabels;

	public UILabel InstructionLabel;

	public UILabel SubtitleLabel;

	public UISprite[] Checkmarks;

	public UISprite Darkness;

	public Camera MainCamera;

	public Transform[] YandereSpawnPoints;

	public Transform[] StudentSpawnPoints;

	public Transform[] TutorialIntroPoints;

	public Transform CameraStartPoint;

	public Transform CameraEndPoint;

	public Transform Highlight;

	public Transform Window;

	public StringList[] KeyboardInstructions;

	public StringList[] GamepadInstructions;

	public StringList[] KokonaDialogue;

	public TransformList[] SpawnPoints;

	public int TutorialPhase;

	public int TutorialsPerformed;

	public int Selected = 1;

	public float TutorialTimer;

	public float TargetVolume = 0.5f;

	public float VolumeSpeed = 0.1f;

	public float DownTimer;

	public float UpTimer;

	public float Timer;

	public bool Show;

	public AudioSource KokonaAudioSource;

	public AudioSource MenuSanity;

	public AudioSource HighSanity;

	public AudioSource MedSanity;

	public AudioSource LowSanity;

	public bool EnableAttacking;

	public bool EnableMovement;

	public bool EnableTalking;

	public bool EnableEating;

	public bool EnablePatrol;

	public ScheduleBlock scheduleBlock;

	public UISprite ExitGroup;

	public InputDeviceType PreviousInputDevice;

	public InputDeviceScript InputDevice;

	public AudioClip NextClip;

	private void Start()
	{
		Window.transform.localScale = new Vector3(0f, 0f, 0f);
		if (!GameGlobals.KokonaTutorial)
		{
			Window.gameObject.SetActive(value: false);
			base.gameObject.SetActive(value: false);
			return;
		}
		Window.gameObject.SetActive(value: true);
		Yandere.StudentManager.Atmosphere = 1f;
		Yandere.StudentManager.SetAtmosphere();
		EightiesTutorialGraphics.SetActive(value: false);
		GameGlobals.EightiesTutorial = false;
		GameGlobals.Eighties = false;
		Yandere.NotificationManager.transform.localPosition = new Vector3(0f, 100f, 0f);
		Yandere.YandereVisionPanel.transform.localPosition = new Vector3(0f, 0f, 0f);
		Yandere.transform.eulerAngles = YandereSpawnPoints[0].eulerAngles;
		Yandere.transform.position = YandereSpawnPoints[0].position;
		Yandere.NotificationManager.NotificationLimit = 0;
		Yandere.PauseScreen.gameObject.SetActive(value: false);
		Yandere.Jukebox.gameObject.SetActive(value: false);
		Yandere.Shutter.PhotographedKokona = false;
		Yandere.WeaponManager.DisableAllWeapons();
		Yandere.Inventory.MaskingTape = false;
		Yandere.Inventory.SedativePoisons = 0;
		Yandere.Inventory.EmeticPoisons = 0;
		Yandere.HeartCamera.enabled = false;
		Yandere.RPGCamera.enabled = false;
		Yandere.Inventory.String = false;
		Yandere.Class.BiologyGrade = 1;
		Yandere.MyLocker.Open = false;
		Yandere.Trespassing = false;
		Yandere.Attacked = false;
		Yandere.CannotAim = true;
		Yandere.CanMove = false;
		Yandere.enabled = true;
		Yandere.Bloodiness = 0f;
		Yandere.NearBodies = 0;
		Yandere.Followers = 0;
		Yandere.Sanity = 100f;
		Yandere.Alerts = 0;
		Yandere.Kills = 0;
		WaterCooler.gameObject.transform.position = new Vector3(0f, 0f, 0f);
		CarBattery.gameObject.transform.position = new Vector3(0f, 0f, 0f);
		Raincoat.gameObject.transform.position = new Vector3(0f, 0f, 0f);
		JerryCan.gameObject.transform.position = new Vector3(0f, 0f, 0f);
		Candle.gameObject.transform.position = new Vector3(0f, 0f, 0f);
		Tarp.gameObject.transform.position = new Vector3(0f, 0f, 0f);
		Incinerator.gameObject.SetActive(value: false);
		RatPoison.gameObject.SetActive(value: false);
		Sedative.gameObject.SetActive(value: false);
		Incinerator.Contents = 0;
		CarBattery.Smoke.Clear();
		CarBattery.Smoke.Stop();
		WaterCooler.Timer = 1f;
		WaterCooler.Empty = true;
		WaterCooler.UpdateCylinderColor();
		WaterCooler.TripwireTrap.SetActive(value: false);
		WaterCooler.PickUp.enabled = true;
		WaterCooler.TrapSet = false;
		TranqCase.Detector.StopChecking = false;
		TranqCase.Detector.enabled = true;
		TranqCase.Occupied = false;
		if (Yandere.MyLocker.NewestUniform != null)
		{
			UnityEngine.Object.Destroy(Yandere.MyLocker.NewestUniform);
		}
		if (StudentManager.Reputation.Portal.WashingMachine.Washing)
		{
			StudentManager.Reputation.Portal.WashingMachine.Finish();
		}
		if (StudentManager.Reputation.Portal.WashingMachine.NewestUniform != null)
		{
			UnityEngine.Object.Destroy(StudentManager.Reputation.Portal.WashingMachine.NewestUniform);
		}
		if (SpawnedClothing != null)
		{
			UnityEngine.Object.Destroy(SpawnedClothing);
		}
		if (SpawnedTarp != null)
		{
			UnityEngine.Object.Destroy(SpawnedTarp);
		}
		if (Yandere.Schoolwear != 1)
		{
			Yandere.Schoolwear = 1;
			Yandere.ChangeSchoolwear();
		}
		foreach (Transform item in Yandere.Police.BloodParent.transform)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
		foreach (Transform item2 in Yandere.StudentManager.PuddleParent.transform)
		{
			UnityEngine.Object.Destroy(item2.gameObject);
		}
		GameObject[] tutorialWall = TutorialWall;
		foreach (GameObject gameObject in tutorialWall)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(value: false);
			}
		}
		foreach (Transform item3 in Yandere.DetectionPanel.transform)
		{
			UnityEngine.Object.Destroy(item3.gameObject);
		}
		T.Clock.CameraEffects.UpdateBloomKnee(0.75f);
		T.Clock.CameraEffects.UpdateBloomRadius(4f);
		T.Clock.CameraEffects.UpdateBloom(1f);
		T.Clock.StopTime = true;
		Darkness.color = new Color(1f, 1f, 1f, 1f);
		Darkness.enabled = true;
		MainCamera.farClipPlane = 50f;
		InstructionLabel.text = "";
		SubtitleLabel.text = "";
		InstructionLabel.alpha = 0f;
		SubtitleLabel.alpha = 0f;
		ExitGroup.alpha = 0f;
		T.ReputationHUD.alpha = 0f;
		T.SanityHUD.alpha = 0f;
		T.ClockHUD.alpha = 0f;
		T.FPSBG.SetActive(value: false);
		T.FPS.SetActive(value: false);
		TutorialPhase = 1;
		TutorialTimer = 0f;
		Incinerator.Finish();
		Mop.Bleached = false;
		Mop.Bloodiness = 0f;
		Mop.Sparkles.Stop();
		Mop.UpdateBlood();
		if (Bucket.Full)
		{
			Bucket.Empty();
		}
		Bleach.transform.parent = TutorialSets[3].transform;
		Bucket.transform.parent = TutorialSets[3].transform;
		Mop.transform.parent = TutorialSets[3].transform;
		if (Bucket.PickUp.OriginalPosition != Vector3.zero)
		{
			Bucket.transform.eulerAngles = Bucket.PickUp.OriginalRotation;
			Bucket.transform.position = Bucket.PickUp.OriginalPosition;
		}
		if (Mop.PickUp.OriginalPosition != Vector3.zero)
		{
			Mop.transform.eulerAngles = Mop.PickUp.OriginalRotation;
			Mop.transform.position = Mop.PickUp.OriginalPosition;
		}
		if (Bleach.OriginalPosition != Vector3.zero)
		{
			Bleach.transform.eulerAngles = Bleach.OriginalRotation;
			Bleach.transform.position = Bleach.OriginalPosition;
		}
		DoorScript[] doors = StudentManager.Doors;
		foreach (DoorScript doorScript in doors)
		{
			if (doorScript != null)
			{
				doorScript.Prompt.Hide();
				doorScript.Prompt.enabled = false;
				doorScript.enabled = false;
			}
		}
		tutorialWall = TutorialSets;
		foreach (GameObject gameObject2 in tutorialWall)
		{
			if (gameObject2 != null)
			{
				gameObject2.transform.localPosition = new Vector3(0f, 0f, 0f);
				gameObject2.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				gameObject2.SetActive(value: false);
			}
		}
		WeaponManager.Weapons[2].transform.position = new Vector3(0f, 0f, 0f);
		WeaponManager.Weapons[0].transform.position = new Vector3(0f, 0f, 0f);
		WeaponManager.Weapons[0].Undroppable = false;
		PoliceIcons[0].SetActive(value: false);
		PoliceIcons[1].SetActive(value: false);
		PoliceIcons[2].SetActive(value: false);
		MainCamera.transform.position = CameraStartPoint.position;
		MainCamera.transform.eulerAngles = CameraStartPoint.eulerAngles;
		StudentSpawnPoints = TutorialIntroPoints;
		StudentManager.Yandere.Police.StudentFoundCorpse = false;
		StudentManager.DialogueWheel.KokonaTutorialPhase = 0;
		StudentManager.StudentPhotographed[30] = false;
		StudentManager.OriginalUniforms = 99;
		StudentManager.BloodReporter = null;
		StudentManager.NewUniforms = 99;
		StudentManager.DespawnAllStudents();
		EnableAttacking = false;
		EnableMovement = false;
		EnableTalking = false;
		EnableEating = false;
		EnablePatrol = false;
		SpawnStudent(26);
		SpawnStudent(27);
		SpawnStudent(28);
		SpawnStudent(29);
		SpawnStudent(30);
		StudentManager.Students[26].MyController.enabled = false;
		StudentManager.Students[27].MyController.enabled = false;
		StudentManager.Students[28].MyController.enabled = false;
		StudentManager.Students[29].MyController.enabled = false;
		StudentManager.Students[30].MyController.enabled = false;
	}

	private void SpawnStudent(int ID)
	{
		StudentManager.SpawnStudent(ID);
		StudentScript studentScript = StudentManager.Students[ID];
		if (ID < 25 || ID > 31)
		{
			studentScript.Cosmetic.Empty = true;
			studentScript.Name = "A student";
		}
		studentScript.Cosmetic.Start();
		studentScript.Start();
		studentScript.enabled = false;
		studentScript.Pathfinding.enabled = false;
		studentScript.Prompt.enabled = false;
		studentScript.Prompt.Hide();
		studentScript.transform.position = StudentSpawnPoints[ID].position;
		studentScript.transform.eulerAngles = StudentSpawnPoints[ID].eulerAngles;
		studentScript.CharacterAnimation.Play(studentScript.IdleAnim);
		studentScript.InEvent = true;
		if (EnableAttacking)
		{
			studentScript.OriginalPersona = PersonaType.Coward;
			studentScript.Persona = PersonaType.Coward;
			studentScript.Prompt.enabled = true;
			studentScript.CanTalk = false;
			studentScript.Spawned = true;
			studentScript.enabled = true;
			if (Selected == 15)
			{
				studentScript.VisionDistance = 10f;
				studentScript.Paranoia = 1f;
			}
			else
			{
				studentScript.VisionDistance = 2f;
				studentScript.Paranoia = 2f;
			}
			for (int i = 0; i < studentScript.ScheduleBlocks.Length; i++)
			{
				scheduleBlock = studentScript.ScheduleBlocks[i];
				scheduleBlock.destination = "Self";
				scheduleBlock.action = "Wait";
				studentScript.GetDestinations();
				studentScript.CurrentAction = StudentActionType.Wait;
				studentScript.Pathfinding.target = studentScript.transform;
				studentScript.CurrentDestination = studentScript.transform;
			}
			if (EnableMovement)
			{
				studentScript.Destinations[0] = StudentSpawnPoints[ID];
				studentScript.Pathfinding.enabled = true;
			}
			if (EnableTalking)
			{
				studentScript.Destinations[0] = StudentSpawnPoints[ID];
				studentScript.Pathfinding.enabled = true;
				studentScript.Prompt.enabled = true;
				studentScript.CanTalk = true;
				StudentManager.UpdateStudents();
			}
			if (EnableEating)
			{
				StudentManager.LunchSpots.List[30].position = new Vector3(35.25f, 0f, 72f);
				StudentManager.LunchSpots.List[30].eulerAngles = new Vector3(0f, -90f, 0f);
				for (int i = 0; i < studentScript.ScheduleBlocks.Length; i++)
				{
					scheduleBlock = studentScript.ScheduleBlocks[i];
					scheduleBlock.destination = "LunchSpot";
					scheduleBlock.action = "Eat";
					studentScript.GetDestinations();
					studentScript.CurrentAction = StudentActionType.SitAndEatBento;
					studentScript.Pathfinding.target = studentScript.transform;
					studentScript.CurrentDestination = studentScript.transform;
				}
			}
			if (EnablePatrol)
			{
				StudentManager.Patrols.List[ID] = Patrols[ID];
				for (int i = 0; i < studentScript.ScheduleBlocks.Length; i++)
				{
					scheduleBlock = studentScript.ScheduleBlocks[i];
					scheduleBlock.destination = "Patrol";
					scheduleBlock.action = "Patrol";
					studentScript.GetDestinations();
					studentScript.CurrentAction = StudentActionType.Patrol;
					studentScript.Pathfinding.target = studentScript.transform;
					studentScript.CurrentDestination = studentScript.transform;
				}
			}
		}
		for (int j = 0; j < studentScript.Outlines.Length; j++)
		{
			if (studentScript.Outlines[j] != null)
			{
				studentScript.Outlines[j].color = new Color(0f, 1f, 0f, 1f);
				studentScript.Outlines[j].enabled = true;
			}
		}
	}

	private void Update()
	{
		if (Phase == 1)
		{
			Timer += Time.deltaTime;
			if (Timer > 1f)
			{
				DoorScript[] doors = StudentManager.Doors;
				foreach (DoorScript doorScript in doors)
				{
					if (doorScript != null)
					{
						doorScript.Prompt.Hide();
						doorScript.Prompt.enabled = false;
						doorScript.enabled = false;
					}
				}
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			if (Input.GetButtonDown("A"))
			{
				Timer = 4f;
				Darkness.alpha = 0f;
				MainCamera.transform.position = CameraEndPoint.position;
				MainCamera.transform.eulerAngles = CameraEndPoint.eulerAngles;
			}
			Timer += Time.deltaTime;
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime);
			MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, CameraEndPoint.position, Time.deltaTime * Timer);
			MainCamera.transform.eulerAngles = Vector3.Lerp(MainCamera.transform.eulerAngles, CameraEndPoint.eulerAngles, Time.deltaTime * Timer);
			if (Timer > 4f)
			{
				Yandere.PromptBar.ClearButtons();
				Yandere.PromptBar.Label[0].text = "Confirm";
				Yandere.PromptBar.Label[4].text = "Change";
				Yandere.PromptBar.UpdateButtons();
				Yandere.PromptBar.Show = true;
				Show = true;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 3)
		{
			if (Input.GetKey("down"))
			{
				DownTimer += Time.deltaTime;
			}
			if (Input.GetKeyUp("down"))
			{
				DownTimer = 0f;
			}
			if (Yandere.PauseScreen.InputManager.TappedDown || DownTimer > 0.5f)
			{
				if (DownTimer > 0.5f)
				{
					DownTimer = 0.4f;
				}
				Selected++;
				if (Selected == 16)
				{
					Selected = 17;
				}
				if (Selected > 17)
				{
					Selected = 1;
				}
				UpdateHighlight();
			}
			if (Input.GetKey("up"))
			{
				UpTimer += Time.deltaTime;
			}
			if (Input.GetKeyUp("up"))
			{
				UpTimer = 0f;
			}
			if (Yandere.PauseScreen.InputManager.TappedUp || UpTimer > 0.5f)
			{
				if (UpTimer > 0.5f)
				{
					UpTimer = 0.4f;
				}
				Selected--;
				if (Selected == 16)
				{
					Selected = 15;
				}
				if (Selected < 1)
				{
					Selected = 17;
				}
				UpdateHighlight();
			}
			if (Input.GetButtonDown("A"))
			{
				HighSanity.time = MenuSanity.time;
				MedSanity.time = MenuSanity.time;
				LowSanity.time = MenuSanity.time;
				Yandere.PromptBar.ClearButtons();
				Yandere.PromptBar.Show = false;
				Show = false;
				Timer = 0f;
				if (Selected < 17)
				{
					Phase++;
				}
				else
				{
					if (TutorialsPerformed == 0)
					{
						KokonaAudioSource.clip = KokonaDialogue[16].Audio[0];
						SubtitleLabel.text = KokonaDialogue[16].Text[0];
					}
					else
					{
						KokonaAudioSource.clip = KokonaDialogue[16].Audio[1];
						SubtitleLabel.text = KokonaDialogue[16].Text[1];
					}
					KokonaAudioSource.Play();
					SubtitleLabel.alpha = 1f;
					Phase = 9;
				}
			}
		}
		else if (Phase == 4)
		{
			Timer += Time.deltaTime;
			if (Timer > 0.5f)
			{
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 5)
		{
			Timer += Time.deltaTime;
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime);
			if (Timer > 1f)
			{
				Timer = 0f;
				PrepareTutorialScene(Selected);
				Yandere.FixCamera();
				Phase++;
			}
		}
		else if (Phase == 6)
		{
			Timer += Time.deltaTime;
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime);
			if (Timer > 1f)
			{
				Yandere.RPGCamera.enabled = true;
				Yandere.CanMove = true;
				PlayKokonaVoice();
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 7)
		{
			UpdateTutorial();
		}
		else if (Phase == 8)
		{
			Timer += Time.deltaTime;
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime);
			ExitGroup.alpha = Mathf.MoveTowards(ExitGroup.alpha, 0f, Time.deltaTime);
			SubtitleLabel.alpha = Mathf.MoveTowards(SubtitleLabel.alpha, 0f, Time.deltaTime);
			InstructionLabel.alpha = Mathf.MoveTowards(InstructionLabel.alpha, 0f, Time.deltaTime);
			if (Timer > 1f)
			{
				Start();
				MainCamera.transform.position = CameraEndPoint.position;
				MainCamera.transform.eulerAngles = CameraEndPoint.eulerAngles;
				Phase = 2;
				Timer = 3f;
			}
		}
		else if (Phase == 9)
		{
			if (Input.GetButtonDown("A"))
			{
				KokonaAudioSource.Stop();
				Timer = 1f;
			}
			Timer += Time.deltaTime;
			if (Timer > 1f)
			{
				Darkness.color = new Color(0f, 0f, 0f, 0f);
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 10)
		{
			if (Input.GetButtonDown("A"))
			{
				KokonaAudioSource.Stop();
			}
			if (!KokonaAudioSource.isPlaying)
			{
				Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime);
				SubtitleLabel.alpha = Mathf.MoveTowards(SubtitleLabel.alpha, 0f, Time.deltaTime);
				if (Darkness.alpha == 1f)
				{
					Timer += Time.deltaTime;
					if (Timer > 0f)
					{
						DateGlobals.Weekday = DayOfWeek.Sunday;
						GameGlobals.KokonaTutorial = false;
						SceneManager.LoadScene("PhoneScene");
					}
				}
			}
		}
		if (Show)
		{
			Window.transform.localScale = Vector3.Lerp(Window.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
		}
		else
		{
			Window.transform.localScale = Vector3.Lerp(Window.transform.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
		}
		if (Phase < 4 || Phase > 7)
		{
			MenuSanity.volume = Mathf.MoveTowards(MenuSanity.volume, TargetVolume, Time.deltaTime * VolumeSpeed);
			HighSanity.volume = Mathf.MoveTowards(HighSanity.volume, 0f, Time.deltaTime * VolumeSpeed);
			MedSanity.volume = Mathf.MoveTowards(MedSanity.volume, 0f, Time.deltaTime * VolumeSpeed);
			LowSanity.volume = Mathf.MoveTowards(LowSanity.volume, 0f, Time.deltaTime * VolumeSpeed);
			return;
		}
		MenuSanity.volume = Mathf.MoveTowards(MenuSanity.volume, 0f, Time.deltaTime * VolumeSpeed);
		if (Yandere.SanityType == SanityType.High)
		{
			HighSanity.volume = Mathf.MoveTowards(HighSanity.volume, TargetVolume, Time.deltaTime * VolumeSpeed);
			MedSanity.volume = Mathf.MoveTowards(MedSanity.volume, 0f, Time.deltaTime * VolumeSpeed);
			LowSanity.volume = Mathf.MoveTowards(LowSanity.volume, 0f, Time.deltaTime * VolumeSpeed);
		}
		else if (Yandere.SanityType == SanityType.Medium)
		{
			HighSanity.volume = Mathf.MoveTowards(HighSanity.volume, 0f, Time.deltaTime * VolumeSpeed);
			MedSanity.volume = Mathf.MoveTowards(MedSanity.volume, TargetVolume, Time.deltaTime * VolumeSpeed);
			LowSanity.volume = Mathf.MoveTowards(LowSanity.volume, 0f, Time.deltaTime * VolumeSpeed);
		}
		else if (Yandere.SanityType == SanityType.Low)
		{
			HighSanity.volume = Mathf.MoveTowards(HighSanity.volume, 0f, Time.deltaTime * VolumeSpeed);
			MedSanity.volume = Mathf.MoveTowards(MedSanity.volume, 0f, Time.deltaTime * VolumeSpeed);
			LowSanity.volume = Mathf.MoveTowards(LowSanity.volume, TargetVolume, Time.deltaTime * VolumeSpeed);
		}
	}

	private void UpdateTutorial()
	{
		if (Yandere.CanMove && !Yandere.Aiming)
		{
			ExitGroup.alpha = Mathf.MoveTowards(ExitGroup.alpha, 1f, Time.deltaTime);
			if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start"))
			{
				KokonaAudioSource.Stop();
				NextClip = null;
				ExitTutorial();
			}
		}
		else
		{
			ExitGroup.alpha = Mathf.MoveTowards(ExitGroup.alpha, 0.5f, Time.deltaTime);
		}
		UpdateInstructionText();
		if (!Yandere.Talking && !StudentManager.DialogueWheel.TopicInterface.gameObject.activeInHierarchy && NextClip == null)
		{
			SubtitleLabel.text = KokonaDialogue[Selected].Text[TutorialPhase];
		}
		if (Selected == 1)
		{
			if (TutorialPhase == 1)
			{
				if (Yandere.Armed)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 2)
			{
				if (Yandere.Kills == 2)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 3)
			{
				if (Yandere.Kills == 5)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 4)
			{
				T.SanityHUD.alpha = Mathf.MoveTowards(T.SanityHUD.alpha, 1f, Time.deltaTime);
				if (Yandere.Sanity == 100f && Yandere.CanMove)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 5)
			{
				TutorialTimer += Time.deltaTime;
				if (TutorialTimer > 5f)
				{
					Checkmarks[Selected].enabled = true;
					TutorialsPerformed++;
					ExitTutorial();
				}
			}
		}
		else if (Selected == 2)
		{
			if (TutorialPhase == 1)
			{
				if (Yandere.Carrying && Yandere.CanMove)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 2)
			{
				if (Vector3.Distance(Yandere.transform.position, Incinerator.transform.position) < 2f)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 3)
			{
				if (Incinerator.Corpses > 0)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 4)
			{
				if (Incinerator.Corpses == 5)
				{
					Incinerator.CannotIncinerate = false;
				}
				if (Incinerator.Smoke.isPlaying)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 5)
			{
				TutorialTimer += Time.deltaTime;
				if (TutorialTimer > 5f)
				{
					Checkmarks[Selected].enabled = true;
					TutorialsPerformed++;
					ExitTutorial();
				}
			}
		}
		else if (Selected == 3)
		{
			if (TutorialPhase == 1)
			{
				if (Yandere.PickUp != null && (bool)Yandere.PickUp.Bucket)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 2)
			{
				if (Bucket.Full)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 3)
			{
				if (Yandere.Mop != null && Yandere.Mop.Bleached)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 4)
			{
				if (VG.BloodParent.childCount == 0)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 5)
			{
				TutorialTimer += Time.deltaTime;
				if (TutorialTimer > 5f)
				{
					Checkmarks[Selected].enabled = true;
					TutorialsPerformed++;
					ExitTutorial();
				}
			}
		}
		else if (Selected == 4)
		{
			if (TutorialPhase == 1)
			{
				if (Yandere.MyLocker.Open)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 2)
			{
				if (Yandere.Schoolwear == 0)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 3)
			{
				if (Yandere.Bloodiness == 0f)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 4)
			{
				if (Yandere.Schoolwear > 0)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 5)
			{
				TutorialTimer += Time.deltaTime;
				if (TutorialTimer > 5f)
				{
					Checkmarks[Selected].enabled = true;
					TutorialsPerformed++;
					ExitTutorial();
				}
			}
		}
		else if (Selected == 5)
		{
			if (TutorialPhase == 1)
			{
				if (!WeaponManager.Weapons[0].Bloody)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 2)
			{
				if (Yandere.PickUp != null && Yandere.PickUp.Clothing)
				{
					Doors[1].Locked = false;
					Doors[2].Locked = false;
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 3)
			{
				if (StudentManager.Reputation.Portal.WashingMachine.Open)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 4)
			{
				if (StudentManager.Reputation.Portal.WashingMachine.Washing)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 5)
			{
				TutorialTimer += Time.deltaTime;
				if (TutorialTimer > 5f)
				{
					Checkmarks[Selected].enabled = true;
					TutorialsPerformed++;
					ExitTutorial();
				}
			}
		}
		else if (Selected == 6)
		{
			if (TutorialPhase == 1)
			{
				if (Yandere.transform.position.x > 36f)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 2)
			{
				if (Yandere.Laughing)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 3)
			{
				if (StudentManager.Students[30].InvestigationTimer > 5f)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 4)
			{
				if (!TutorialObject[1].Self.activeInHierarchy)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 5)
			{
				TutorialTimer += Time.deltaTime;
				if (TutorialTimer > 5f)
				{
					Checkmarks[Selected].enabled = true;
					TutorialsPerformed++;
					ExitTutorial();
				}
			}
		}
		else if (Selected == 7)
		{
			if (Yandere.Carrying || Yandere.Dragging)
			{
				Yandere.EmptyHands();
			}
			if (TutorialPhase == 1)
			{
				if (Yandere.PickUp != null && Yandere.transform.position.z < 73f)
				{
					Yandere.EmptyHands();
				}
				if (Yandere.Gloved)
				{
					Tarp.enabled = true;
					Tarp.Prompt.enabled = true;
					TutorialWall[7].SetActive(value: true);
					StudentManager.Students[30].Ragdoll.Prompt.enabled = true;
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 2)
			{
				if (StudentManager.Students[30].Ragdoll.MyTarp != null)
				{
					WeaponManager.Weapons[8].enabled = true;
					WeaponManager.Weapons[8].Prompt.enabled = true;
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 3)
			{
				if (StudentManager.Students[30].Ragdoll.Dismembered)
				{
					Yandere.EmptyHands();
					WeaponManager.Weapons[8].enabled = false;
					WeaponManager.Weapons[8].Prompt.enabled = false;
					WeaponManager.Weapons[8].Prompt.Hide();
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 4)
			{
				if (!Yandere.Gloved)
				{
					Raincoat.enabled = false;
					Raincoat.Prompt.enabled = false;
					Raincoat.Prompt.Hide();
					TutorialWall[7].SetActive(value: false);
				}
				if (Incinerator.Contents == 6)
				{
					Incinerator.CannotIncinerate = false;
				}
				if (Incinerator.Smoke.isPlaying)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 5)
			{
				TutorialTimer += Time.deltaTime;
				if (TutorialTimer > 5f)
				{
					Checkmarks[Selected].enabled = true;
					TutorialsPerformed++;
					ExitTutorial();
				}
			}
		}
		else if (Selected == 8)
		{
			T.ReputationHUD.alpha = Mathf.MoveTowards(T.ReputationHUD.alpha, 1f, Time.deltaTime);
			if (TutorialPhase == 1)
			{
				if (StudentManager.Students[30].AlarmTimer > 1f)
				{
					StudentManager.Students[30].Blind = true;
					T.ReputationHUD.alpha = 1f;
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 2)
			{
				if (StudentManager.Students[30].Forgave && Yandere.CanMove)
				{
					StudentManager.DialogueWheel.KokonaTutorialPhase = 2;
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 3)
			{
				if (StudentManager.DialogueWheel.TopicInterface.gameObject.activeInHierarchy)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 4)
			{
				if (StudentManager.DialogueWheel.TopicInterface.gameObject.activeInHierarchy)
				{
					InstructionLabel.transform.localPosition = new Vector3(0f, 270f, 0f);
				}
				else
				{
					InstructionLabel.transform.localPosition = new Vector3(0f, 500f, 0f);
				}
				if (StudentManager.Students[30].Complimented && Yandere.CanMove)
				{
					StudentManager.Students[30].Prompt.enabled = false;
					StudentManager.Students[30].Prompt.Hide();
					StudentManager.Students[30].CanTalk = false;
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 5)
			{
				TutorialTimer += Time.deltaTime;
				if (TutorialTimer > 5f)
				{
					Checkmarks[Selected].enabled = true;
					TutorialsPerformed++;
					ExitTutorial();
				}
			}
		}
		else if (Selected == 9)
		{
			if (TutorialPhase == 1)
			{
				if (Yandere.Aiming)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 2)
			{
				if (Yandere.Shutter.PhotographedKokona)
				{
					StudentManager.StudentPhotographed[30] = true;
					for (int i = 0; i < StudentManager.Students[30].Outlines.Length; i++)
					{
						if (StudentManager.Students[30].Outlines[i] != null)
						{
							StudentManager.Students[30].Outlines[i].enabled = true;
						}
					}
					Yandere.CannotAim = true;
					if (Yandere.Aiming)
					{
						Yandere.StopAiming();
					}
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 3)
			{
				if (Yandere.transform.position.x > 36f)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 4)
			{
				if (Yandere.YandereVision)
				{
					TutorialTimer += Time.deltaTime;
					if (TutorialTimer > 2.5f)
					{
						TutorialTimer = 0f;
						TutorialPhase++;
						PlayKokonaVoice();
					}
				}
			}
			else if (TutorialPhase == 5)
			{
				TutorialTimer += Time.deltaTime;
				if (TutorialTimer > 5f)
				{
					Checkmarks[Selected].enabled = true;
					TutorialsPerformed++;
					ExitTutorial();
				}
			}
		}
		else if (Selected == 10)
		{
			if (TutorialPhase != 0 && !StudentManager.Students[30].Alive)
			{
				TutorialPhase = 0;
				PlayKokonaVoice();
			}
			if (TutorialPhase == 0)
			{
				TutorialTimer += Time.deltaTime;
				if (TutorialTimer > 5f)
				{
					ExitTutorial();
				}
			}
			else if (TutorialPhase == 1)
			{
				if (Yandere.Inventory.SedativePoisons == 1 && !Yandere.Armed && Yandere.Weapon[1] != null)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 2)
			{
				if (StudentManager.Students[30].Following && Vector3.Distance(StudentManager.Students[30].transform.position, TranqCase.transform.position) < 4f)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 3)
			{
				if (StudentManager.Students[30].Ragdoll.Zs.activeInHierarchy)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 4)
			{
				if (TranqCase.Occupied && Yandere.CanMove)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 5)
			{
				TutorialTimer += Time.deltaTime;
				if (TutorialTimer > 5f)
				{
					Checkmarks[Selected].enabled = true;
					TutorialsPerformed++;
					ExitTutorial();
				}
			}
		}
		else if (Selected == 11)
		{
			if (TutorialPhase == 1)
			{
				if (Yandere.Inventory.EmeticPoisons == 1)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 2)
			{
				if (StudentManager.Students[30].InvestigationTimer > 5f)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 3)
			{
				if (StudentManager.Students[30].MyBento.Tampered && Yandere.CanMove)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 4)
			{
				if (StudentManager.Students[30].Drowned && Yandere.CanMove)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 5)
			{
				TutorialTimer += Time.deltaTime;
				if (TutorialTimer > 5f)
				{
					Checkmarks[Selected].enabled = true;
					TutorialsPerformed++;
					ExitTutorial();
				}
			}
		}
		else if (Selected == 12)
		{
			if (!Yandere.enabled || (CarBattery.Smoke.isPlaying && !StudentManager.Students[30].Electrocuted && !StudentManager.Students[30].Electrified))
			{
				Debug.Log("Yandere.enabled is: " + Yandere.enabled);
				Debug.Log("CarBattery.Smoke.isPlaying is: " + CarBattery.Smoke.isPlaying);
				if (TutorialPhase != 0)
				{
					TutorialTimer += Time.deltaTime;
					if (TutorialTimer > 1f)
					{
						TutorialTimer = 0f;
						TutorialPhase = 0;
						PlayKokonaVoice();
					}
				}
			}
			if (TutorialPhase == 0)
			{
				TutorialTimer += Time.deltaTime;
				if (TutorialTimer > 5f)
				{
					ExitTutorial();
				}
			}
			else if (TutorialPhase == 1)
			{
				if (Yandere.PickUp != null && (bool)Yandere.PickUp.Bucket)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 2)
			{
				if (Bucket.Full)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 3)
			{
				if (Bucket.NewestPuddle != null && Vector3.Distance(Bucket.NewestPuddle.transform.position, StudentManager.Students[30].transform.position) < 1f)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 4)
			{
				if (StudentManager.Students[30].Electrocuted && StudentManager.Students[30].Ragdoll.enabled)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 5)
			{
				TutorialTimer += Time.deltaTime;
				if (TutorialTimer > 5f)
				{
					Checkmarks[Selected].enabled = true;
					TutorialsPerformed++;
					ExitTutorial();
				}
			}
		}
		else if (Selected == 13)
		{
			if (TutorialPhase < 5 && Yandere.transform.position.x > 32f)
			{
				Yandere.transform.position = new Vector3(32f, Yandere.transform.position.y, Yandere.transform.position.z);
				Physics.SyncTransforms();
			}
			if (TutorialPhase == 1)
			{
				if (Yandere.Armed)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 2)
			{
				if (Yandere.Kills == 1)
				{
					StudentManager.Students[28].OriginalPersona = PersonaType.Heroic;
					StudentManager.Students[28].Persona = PersonaType.Heroic;
					StudentManager.Students[28].Pathfinding.canSearch = true;
					StudentManager.Students[28].Pathfinding.canMove = true;
					StudentManager.Students[28].Pathfinding.enabled = true;
					StudentManager.Students[28].VisionDistance = 5f;
					Yandere.EquippedWeapon.Undroppable = true;
					TutorialWall[13].SetActive(value: false);
					Yandere.CanMove = false;
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 3)
			{
				if (Yandere.Struggling)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 4)
			{
				if (Yandere.CanMove)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 5)
			{
				TutorialTimer += Time.deltaTime;
				if (TutorialTimer > 5f)
				{
					Checkmarks[Selected].enabled = true;
					TutorialsPerformed++;
					ExitTutorial();
				}
			}
		}
		else if (Selected == 14)
		{
			WaterCooler.Prompt.HideButton[3] = true;
			if (StudentManager.Students[30].DeathType == DeathType.Weapon && TutorialPhase != 0)
			{
				TutorialPhase = 0;
				PlayKokonaVoice();
			}
			if (TutorialPhase == 0)
			{
				TutorialTimer += Time.deltaTime;
				if (TutorialTimer > 5f)
				{
					ExitTutorial();
				}
			}
			else if (TutorialPhase == 1)
			{
				if (Yandere.Inventory.String && Yandere.Inventory.MaskingTape && WeaponManager.Weapons[0].transform.parent != null)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 2)
			{
				if (Bucket.Full)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 3)
			{
				if (WaterCooler.TrapSet)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 4)
			{
				if (StudentManager.Students[30].Burning && StudentManager.Students[30].Ragdoll.enabled)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 5)
			{
				TutorialTimer += Time.deltaTime;
				if (TutorialTimer > 5f)
				{
					Checkmarks[Selected].enabled = true;
					TutorialsPerformed++;
					ExitTutorial();
				}
			}
		}
		else if (Selected == 15)
		{
			StudentManager.Police.UpdateIconsForTutorial();
			if ((Yandere.Alerts > 0 || StudentManager.Yandere.Police.StudentFoundCorpse || StudentManager.BloodReporter != null || (Yandere.Attacking && Yandere.TargetStudent.StudentID != 30)) && TutorialPhase != 0)
			{
				TutorialTimer = 0f;
				TutorialPhase = 0;
				PlayKokonaVoice();
			}
			if (Yandere.Sanity < 100f)
			{
				T.SanityHUD.alpha = Mathf.MoveTowards(T.SanityHUD.alpha, 1f, Time.deltaTime);
			}
			if (Incinerator.Contents > 5)
			{
				Incinerator.CannotIncinerate = false;
			}
			if (TutorialPhase == 0)
			{
				TutorialTimer += Time.deltaTime;
				if (TutorialTimer > 5f)
				{
					ExitTutorial();
				}
			}
			else if (TutorialPhase == 1)
			{
				TutorialTimer += Time.deltaTime;
				if (TutorialTimer > 5f)
				{
					TutorialTimer = 0f;
					TutorialPhase++;
				}
			}
			else if (TutorialPhase == 2)
			{
				if (VG.BloodParent.childCount == 0 && !WeaponManager.Weapons[8].Blood.enabled && !Raincoat.Blood.enabled && Incinerator.Smoke.isPlaying && Yandere.Sanity == 100f)
				{
					TutorialPhase++;
					PlayKokonaVoice();
				}
			}
			else if (TutorialPhase == 3)
			{
				TutorialTimer += Time.deltaTime;
				if (TutorialTimer > 5f)
				{
					Checkmarks[Selected].enabled = true;
					TutorialsPerformed++;
					ExitTutorial();
				}
			}
		}
		if (!KokonaAudioSource.isPlaying && NextClip != null)
		{
			KokonaAudioSource.clip = NextClip;
			KokonaAudioSource.Play();
			NextClip = null;
		}
	}

	public void ExitTutorial()
	{
		if (!Yandere.Attacking && !Yandere.Dipping && !KokonaAudioSource.isPlaying && NextClip == null)
		{
			InstructionLabel.text = "";
			SubtitleLabel.text = "";
			Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
			Yandere.RightFootprintSpawner.Bloodiness = 0;
			Yandere.LeftFootprintSpawner.Bloodiness = 0;
			Yandere.RPGCamera.enabled = false;
			WeaponManager.Weapons[0].Undroppable = false;
			if (Yandere.Armed)
			{
				Yandere.EquippedWeapon.Undroppable = false;
			}
			CarBattery.Smoke.Stop();
			if (Yandere.Laughing)
			{
				Yandere.StopLaughing();
			}
			Yandere.CanMove = true;
			Yandere.DropSpecifically = true;
			Yandere.EmptyHands();
			if (Yandere.Weapon[1] != null)
			{
				Yandere.DropTimer[1] = 1f;
				Yandere.DropWeapon(1);
			}
			if (Yandere.Weapon[2] != null)
			{
				Yandere.DropTimer[2] = 1f;
				Yandere.DropWeapon(2);
			}
			if (Yandere.YandereVision)
			{
				Yandere.ResetYandereEffects();
				Yandere.YandereVision = false;
			}
			Yandere.WeaponMenu.UpdateSprites();
			WeaponManager.CleanWeapons();
			if (Yandere.Gloves != null)
			{
				Yandere.RemoveGloves();
			}
			Yandere.CanMove = false;
			Yandere.DropSpecifically = false;
			Phase++;
			Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
		}
	}

	private void UpdateInstructionText()
	{
		SubtitleLabel.alpha = Mathf.MoveTowards(SubtitleLabel.alpha, 1f, Time.deltaTime);
		InstructionLabel.alpha = Mathf.MoveTowards(InstructionLabel.alpha, 1f, Time.deltaTime);
		if (InputDevice.Type == InputDeviceType.MouseAndKeyboard)
		{
			InstructionLabel.text = KeyboardInstructions[Selected].Text[TutorialPhase];
		}
		else
		{
			InstructionLabel.text = GamepadInstructions[Selected].Text[TutorialPhase];
		}
	}

	private void PlayKokonaVoice()
	{
		if (KokonaAudioSource.isPlaying)
		{
			NextClip = KokonaDialogue[Selected].Audio[TutorialPhase];
			return;
		}
		KokonaAudioSource.clip = KokonaDialogue[Selected].Audio[TutorialPhase];
		KokonaAudioSource.Play();
	}

	private void UpdateHighlight()
	{
		Highlight.localPosition = new Vector3(0f, 400 - 50 * Selected, 0f);
	}

	private void PrepareTutorialScene(int TutorialID)
	{
		Yandere.StudentManager.Atmosphere = 0f;
		Yandere.StudentManager.SetAtmosphere();
		GameObject[] tutorialSets = TutorialSets;
		foreach (GameObject gameObject in tutorialSets)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(value: false);
			}
		}
		StudentManager.DespawnAllStudents();
		Yandere.transform.eulerAngles = YandereSpawnPoints[TutorialID].eulerAngles;
		Yandere.transform.position = YandereSpawnPoints[TutorialID].position;
		StudentSpawnPoints = SpawnPoints[Selected].Trans;
		switch (TutorialID)
		{
		case 1:
			WeaponManager.Weapons[0].transform.position = new Vector3(28.25f, 0.75f, 71f);
			EnableAttacking = true;
			SpawnStudent(26);
			SpawnStudent(27);
			SpawnStudent(28);
			SpawnStudent(29);
			SpawnStudent(30);
			break;
		case 2:
			Incinerator.gameObject.transform.localPosition = new Vector3(0f, 0f, 11f);
			Incinerator.gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			Incinerator.gameObject.SetActive(value: true);
			Incinerator.CannotIncinerate = true;
			Yandere.Bloodiness = 100f;
			EnableAttacking = true;
			SpawnStudent(26);
			SpawnStudent(27);
			SpawnStudent(28);
			SpawnStudent(29);
			SpawnStudent(30);
			StudentManager.Students[26].BecomeRagdoll();
			StudentManager.Students[27].BecomeRagdoll();
			StudentManager.Students[28].BecomeRagdoll();
			StudentManager.Students[29].BecomeRagdoll();
			StudentManager.Students[30].BecomeRagdoll();
			break;
		case 3:
		{
			Yandere.Bloodiness = 100f;
			for (int j = 26; j < 31; j++)
			{
				GameObject obj = UnityEngine.Object.Instantiate(VG.BloodPool, StudentSpawnPoints[j].position, Quaternion.identity);
				obj.transform.parent = VG.BloodParent;
				obj.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
			}
			break;
		}
		case 4:
			Yandere.Bloodiness = 100f;
			SpawnStudent(26);
			SpawnStudent(27);
			SpawnStudent(28);
			SpawnStudent(29);
			SpawnStudent(30);
			break;
		case 5:
			SpawnedClothing = UnityEngine.Object.Instantiate(Yandere.MyLocker.BloodyUniform[1], new Vector3(20f, 1f, -12f), Quaternion.identity);
			WeaponManager.Weapons[0].Equip();
			WeaponManager.Weapons[0].Blood.enabled = true;
			WeaponManager.Weapons[0].StainWithBlood();
			WeaponManager.Weapons[0].Bloody = true;
			Doors[1].enabled = true;
			Doors[2].enabled = true;
			Doors[1].Prompt.enabled = true;
			Doors[2].Prompt.enabled = true;
			Doors[1].Locked = true;
			Doors[2].Locked = true;
			Doors[1].CloseDoor();
			Doors[2].CloseDoor();
			Doors[1].DoorColliders[0].isTrigger = false;
			Doors[1].DoorColliders[1].isTrigger = false;
			Doors[2].DoorColliders[0].isTrigger = false;
			Doors[2].DoorColliders[1].isTrigger = false;
			SpawnStudent(26);
			SpawnStudent(27);
			SpawnStudent(28);
			SpawnStudent(29);
			SpawnStudent(30);
			break;
		case 6:
			Yandere.NotificationManager.transform.localPosition = new Vector3(0f, 0f, -999.9999f);
			TutorialObject[1].Prompt.enabled = true;
			TutorialObject[1].Self.SetActive(value: true);
			EnableAttacking = true;
			EnableMovement = true;
			SpawnStudent(30);
			StudentManager.Students[30].InEvent = false;
			break;
		case 7:
			Incinerator.gameObject.transform.localPosition = new Vector3(7.5f, 0f, 5.75f);
			Incinerator.gameObject.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
			Incinerator.gameObject.SetActive(value: true);
			Incinerator.CannotIncinerate = true;
			Raincoat.gameObject.transform.position = new Vector3(34f, 0.775f, 77.5f);
			Raincoat.gameObject.transform.eulerAngles = new Vector3(0f, -90f, 0f);
			Yandere.CoatBloodiness = 0f;
			Raincoat.PickUp.CannotPickUp = true;
			Raincoat.Prompt.enabled = true;
			Raincoat.Blood.enabled = false;
			Raincoat.enabled = true;
			Raincoat.PickUp.MyRigidbody.useGravity = false;
			Raincoat.PickUp.MyRigidbody.isKinematic = true;
			Raincoat.PickUp.MyCollider.enabled = true;
			Raincoat.gameObject.SetActive(value: true);
			Raincoat.PickUp.Dumped = false;
			Tarp.gameObject.SetActive(value: true);
			Tarp.gameObject.transform.position = new Vector3(34f, 0.79f, 77f);
			Tarp.gameObject.transform.eulerAngles = new Vector3(0f, 90f, 0f);
			Tarp.enabled = false;
			Tarp.Prompt.enabled = false;
			Tarp.Prompt.Hide();
			WeaponManager.Weapons[8].transform.position = new Vector3(34f, 0.766666f, 76.66666f);
			WeaponManager.Weapons[8].transform.eulerAngles = new Vector3(0f, 90f, 0f);
			WeaponManager.Weapons[8].gameObject.SetActive(value: true);
			WeaponManager.Weapons[8].enabled = false;
			WeaponManager.Weapons[8].Prompt.enabled = false;
			WeaponManager.Weapons[8].Prompt.Hide();
			SpawnStudent(26);
			SpawnStudent(27);
			SpawnStudent(28);
			SpawnStudent(29);
			SpawnStudent(30);
			StudentManager.Students[30].BecomeRagdoll();
			StudentManager.Students[30].Ragdoll.NeckSnapped = true;
			StudentManager.Students[30].Ragdoll.Prompt.enabled = false;
			StudentManager.Students[30].Ragdoll.Prompt.Hide();
			break;
		case 8:
			StudentManager.DialogueWheel.KokonaTutorialPhase = 1;
			Yandere.Bloodiness = 100f;
			EnableAttacking = true;
			EnableTalking = true;
			SpawnStudent(30);
			StudentManager.Students[30].InEvent = false;
			break;
		case 9:
			Yandere.CannotAim = false;
			SpawnStudent(30);
			break;
		case 10:
			WeaponManager.Weapons[2].transform.position = new Vector3(22.5f, 0.75166667f, 78.66666f);
			WeaponManager.Weapons[2].transform.eulerAngles = new Vector3(0f, 180f, 0f);
			WeaponManager.Weapons[2].gameObject.SetActive(value: true);
			Sedative.transform.position = new Vector3(22.5f, 0.7433333f, 79f);
			Sedative.gameObject.SetActive(value: true);
			Sedative.Prompt.enabled = true;
			StudentManager.DialogueWheel.KokonaTutorialPhase = 3;
			Doors[3].Prompt.enabled = true;
			Doors[3].enabled = true;
			EnableAttacking = true;
			EnableTalking = true;
			SpawnStudent(30);
			StudentManager.Students[30].InEvent = false;
			StudentManager.Students[30].Friend = true;
			StudentManager.Students[30].Phase = 2;
			break;
		case 11:
			Yandere.NotificationManager.transform.localPosition = new Vector3(0f, 0f, -999.9999f);
			RatPoison.transform.position = new Vector3(28.25f, 0.7438f, 73f);
			RatPoison.transform.eulerAngles = new Vector3(0f, -135f, 0f);
			RatPoison.gameObject.SetActive(value: true);
			RatPoison.Prompt.enabled = true;
			EnableAttacking = true;
			EnableMovement = true;
			EnableEating = true;
			SpawnStudent(30);
			StudentManager.Students[30].Phase = 1;
			StudentManager.Students[30].InEvent = false;
			break;
		case 12:
			CarBattery.transform.position = new Vector3(38.25f, 0.745f, 70f);
			CarBattery.transform.eulerAngles = new Vector3(-90f, -90f, 0f);
			CarBattery.gameObject.tag = "E";
			Bucket.transform.parent = null;
			Bucket.gameObject.SetActive(value: true);
			SpawnStudent(30);
			break;
		case 13:
			WeaponManager.Weapons[0].transform.position = new Vector3(28.25f, 0.75f, 71f);
			EnableAttacking = true;
			SpawnStudent(28);
			SpawnStudent(30);
			break;
		case 14:
			WeaponManager.Weapons[0].transform.position = new Vector3(28.25f, 0.75f, 73.5f);
			WeaponManager.Weapons[0].transform.eulerAngles = new Vector3(0f, 180f, 0f);
			Bucket.transform.parent = null;
			Bucket.gameObject.SetActive(value: true);
			Bucket.transform.position = new Vector3(28.25f, 0.75f, 69.66666f);
			Bucket.transform.eulerAngles = new Vector3(0f, 90f, 0f);
			JerryCan.transform.position = new Vector3(28.25f, 1.15f, 70.4f);
			JerryCan.transform.eulerAngles = new Vector3(0f, 0f, 0f);
			Candle.transform.position = new Vector3(34f, 0.744f, 74.815f);
			Candle.transform.eulerAngles = new Vector3(0f, 0f, 0f);
			WaterCooler.transform.position = new Vector3(34f, 0f, 70f);
			WaterCooler.transform.eulerAngles = new Vector3(0f, 0f, 0f);
			SpoolOfThread.SetActive(value: true);
			MaskingTape.SetActive(value: true);
			EnableAttacking = true;
			EnableMovement = true;
			EnablePatrol = true;
			SpawnStudent(30);
			StudentManager.Students[30].Phase = 1;
			break;
		case 15:
			Yandere.NotificationManager.transform.localPosition = new Vector3(0f, 0f, -999.9999f);
			Incinerator.gameObject.transform.localPosition = new Vector3(10f, 0f, 5.75f);
			Incinerator.gameObject.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
			Incinerator.gameObject.SetActive(value: true);
			Incinerator.CannotIncinerate = true;
			Raincoat.gameObject.transform.position = new Vector3(34f, 0.775f, 77.5f);
			Raincoat.gameObject.transform.eulerAngles = new Vector3(0f, -90f, 0f);
			Yandere.CoatBloodiness = 0f;
			Raincoat.PickUp.CannotPickUp = false;
			Raincoat.Prompt.enabled = true;
			Raincoat.Blood.enabled = false;
			Raincoat.enabled = true;
			Raincoat.PickUp.MyRigidbody.useGravity = false;
			Raincoat.PickUp.MyRigidbody.isKinematic = true;
			Raincoat.PickUp.MyCollider.enabled = true;
			Raincoat.gameObject.SetActive(value: true);
			Raincoat.PickUp.Dumped = false;
			Tarp.gameObject.SetActive(value: true);
			Tarp.gameObject.transform.position = new Vector3(34f, 0.79f, 77f);
			Tarp.gameObject.transform.eulerAngles = new Vector3(0f, 90f, 0f);
			Tarp.enabled = true;
			Tarp.Prompt.enabled = true;
			WeaponManager.Weapons[8].transform.position = new Vector3(34f, 0.766666f, 76.66666f);
			WeaponManager.Weapons[8].transform.eulerAngles = new Vector3(0f, 90f, 0f);
			WeaponManager.Weapons[8].gameObject.SetActive(value: true);
			WeaponManager.Weapons[8].enabled = true;
			WeaponManager.Weapons[8].Prompt.enabled = true;
			WeaponManager.Weapons[8].MyCollider.enabled = true;
			WeaponManager.Weapons[8].InsideIncinerator = false;
			WeaponManager.Weapons[8].Blood.enabled = false;
			WeaponManager.Weapons[8].MurderWeapon = false;
			WeaponManager.Weapons[8].KinematicTimer = 0f;
			WeaponManager.Weapons[8].Bloody = false;
			WeaponManager.Weapons[8].Dumped = false;
			WeaponManager.Weapons[8].DumpTimer = 0f;
			WeaponManager.Weapons[8].RemoveBlood();
			EnableAttacking = true;
			EnableMovement = true;
			SpawnStudent(2);
			SpawnStudent(3);
			SpawnStudent(4);
			SpawnStudent(5);
			StudentManager.Students[2].Perception = 10f;
			StudentManager.Students[3].Perception = 10f;
			StudentManager.Students[4].Perception = 10f;
			StudentManager.Students[5].Perception = 10f;
			SpawnStudent(26);
			SpawnStudent(27);
			SpawnStudent(28);
			SpawnStudent(29);
			SpawnStudent(30);
			StudentManager.Students[2].InEvent = false;
			StudentManager.Students[3].InEvent = false;
			StudentManager.Students[4].InEvent = false;
			StudentManager.Students[5].InEvent = false;
			StudentManager.Students[26].InEvent = false;
			StudentManager.Students[27].InEvent = false;
			StudentManager.Students[28].InEvent = false;
			StudentManager.Students[29].InEvent = false;
			StudentManager.Students[30].InEvent = false;
			TutorialSets[3].transform.localPosition = new Vector3(1.25f, 0f, 5.75f);
			TutorialSets[3].transform.localEulerAngles = new Vector3(0f, -90f, 0f);
			TutorialSets[3].SetActive(value: true);
			Bucket.transform.parent = TutorialSets[3].transform;
			Bucket.transform.localPosition = new Vector3(0f, 0f, 10f);
			Mop.transform.parent = TutorialSets[3].transform;
			Mop.transform.localPosition = new Vector3(2f, 0.7f, 11f);
			Mop.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
			Bleach.transform.parent = TutorialSets[3].transform;
			Bleach.transform.localPosition = new Vector3(-2f, 0f, 11f);
			Bleach.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			PoliceIcons[0].transform.parent.localPosition = new Vector3(0f, 0f, 0f);
			PoliceIcons[0].transform.localPosition = new Vector3(0f, -100f, 0f);
			PoliceIcons[0].SetActive(value: true);
			T.Clock.Period = 5;
			break;
		}
		if (TutorialSets[TutorialID] != null)
		{
			TutorialSets[TutorialID].SetActive(value: true);
		}
		if (StudentManager.Students[30] != null)
		{
			StudentManager.Students[30].AddOutlineToHair();
			for (int k = 0; k < StudentManager.Students[30].Outlines.Length; k++)
			{
				if (StudentManager.Students[30].Outlines[k] != null)
				{
					StudentManager.Students[30].Outlines[k].color = new Color(10f, 0f, 0f, 1f);
					StudentManager.Students[30].Outlines[k].enabled = true;
				}
			}
		}
		PoliceLabels[2].text = "Wash Raincoat";
		PoliceLabels[3].text = "Wash Circular Saw";
		AStar.OnEnable();
		Physics.SyncTransforms();
	}
}
