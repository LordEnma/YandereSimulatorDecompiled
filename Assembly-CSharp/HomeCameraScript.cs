using System;
using UnityEngine;
using UnityEngine.PostProcessing;

public class HomeCameraScript : MonoBehaviour
{
	public HomeTriggerScript[] EightiesTriggers;

	public HomeTriggerScript[] Triggers;

	public HomeWindowScript[] HomeWindows;

	public HomePantyChangerScript HomePantyChanger;

	public HomeSenpaiShrineScript HomeSenpaiShrine;

	public HomeVideoGamesScript HomeVideoGames;

	public HomeCorkboardScript HomeCorkboard;

	public HomeDarknessScript HomeDarkness;

	public HomeInternetScript HomeInternet;

	public HomePrisonerScript HomePrisoner;

	public HomeYandereScript HomeYandere;

	public HomeSleepScript HomeAnime;

	public HomeMangaScript HomeManga;

	public HomeSleepScript HomeSleep;

	public HomeExitScript HomeExit;

	public PostProcessingProfile Profile;

	public PromptBarScript PromptBar;

	public Vignetting Vignette;

	public UILabel PantiesMangaLabel;

	public UISprite Button;

	public GameObject CyberstalkWindow;

	public GameObject StairwayBlocker;

	public GameObject ComputerScreen;

	public GameObject CorkboardLabel;

	public GameObject LoveSickCamera;

	public GameObject LoadingScreen;

	public GameObject CeilingLight;

	public GameObject SchemeCamera;

	public GameObject SenpaiLight;

	public GameObject Controller;

	public GameObject NightLight;

	public GameObject RopeGroup;

	public GameObject DayLight;

	public GameObject Tripod;

	public GameObject Victim;

	public GameObject EightiesCarpet;

	public GameObject ModernCarpet;

	public Transform BedroomDoor;

	public Transform Destination;

	public Transform Butsudan;

	public Transform Target;

	public Transform Focus;

	public Transform[] OutOfRoomDestinations;

	public Transform[] EightiesDestinations;

	public Transform[] EightiesTargets;

	public Transform[] Destinations;

	public Transform[] Targets;

	public float CooldownTimer;

	public float CameraTimer;

	public float Rotation;

	public int LastID;

	public int Frame;

	public int ID;

	public AudioSource BasementJukebox;

	public AudioSource RoomJukebox;

	public AudioClip NightBasement;

	public AudioClip NightRoom;

	public AudioClip HomeLoveSick;

	public bool CameFromBasement;

	public bool RecentlyMoved;

	public bool RestoreBloom;

	public bool RestoreDOF;

	public bool OutOfRoom;

	public bool Torturing;

	public bool Eighties;

	public bool OpenDoor;

	public bool TooClose;

	public bool InHouse;

	public CosmeticScript SenpaiCosmetic;

	public Renderer ClockFace;

	public Renderer HairLock;

	public AudioClip OpenDrawer;

	public SkinnedMeshRenderer BedroomRenderer;

	public Vector3 LastChangePoint;

	private int Is;

	private int Ts;

	public Transform PromptBarPanel;

	public Transform PauseScreen;

	public GameObject CassetteTapes;

	public UILabel[] HUDLabels;

	public AudioClip DayRoom80s;

	public AudioClip DayBasement80s;

	public AudioClip NightRoom80s;

	public AudioClip NightBasement80s;

	public GameObject EightiesController;

	public GameObject ModernDayRoom;

	public GameObject EightiesRoom;

	public GameObject EightiesLabelPanel;

	public GameObject LabelPanel;

	public GameObject MonitorLight;

	public Font VCR;

	public void Start()
	{
		Tripod.SetActive(value: false);
		ResetBloom();
		ResetChroma();
		HomeSleep.Start();
		Button.color = new Color(Button.color.r, Button.color.g, Button.color.b, 0f);
		Focus.position = Target.position;
		base.transform.position = Destination.position;
		if (HomeGlobals.Night)
		{
			ClockFace.material.SetTextureOffset("_MainTex", new Vector2(0.0322f, 0f));
			CeilingLight.SetActive(value: true);
			SenpaiLight.SetActive(value: true);
			NightLight.SetActive(value: true);
			DayLight.SetActive(value: false);
			Triggers[7].Disable();
			BasementJukebox.clip = NightBasement;
			RoomJukebox.clip = NightRoom;
			PantiesMangaLabel.text = "Read Manga";
			BedroomRenderer.SetBlendShapeWeight(1, 100f);
			PlayMusic();
			if (!GameGlobals.CorkboardScene)
			{
				HomeYandere.transform.position = new Vector3(-2f, 0f, -2.5f);
				HomeYandere.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				HomeYandere.CharacterAnimation.Play("f02_thinkLoop_00");
				base.gameObject.SetActive(value: false);
				HomeYandere.CanMove = false;
				SchemeCamera.SetActive(value: true);
				Triggers[1].Disable();
				RoomJukebox.volume = 0f;
			}
		}
		else
		{
			BasementJukebox.Play();
			RoomJukebox.Play();
			ComputerScreen.SetActive(value: false);
			if (DateGlobals.Weekday == DayOfWeek.Friday && GameGlobals.RivalEliminationID == 0)
			{
				EightiesTriggers[2].Disable();
				Triggers[2].Disable();
			}
			Triggers[3].Disable();
			Triggers[5].Disable();
			Triggers[9].Disable();
		}
		if (StudentGlobals.Prisoners == 0)
		{
			RopeGroup.SetActive(value: false);
			Tripod.SetActive(value: false);
			Victim.SetActive(value: false);
			EightiesTriggers[10].Disable();
			Triggers[10].Disable();
		}
		if (GameGlobals.LoveSick)
		{
			LoveSickColorSwap();
		}
		Time.timeScale = 1f;
		HairLock.material.color = SenpaiCosmetic.ColorValue;
		if (SchoolGlobals.SchoolAtmosphere > 1f)
		{
			SchoolGlobals.SchoolAtmosphere = 1f;
		}
		if (Profile.bloom.enabled)
		{
			RestoreBloom = true;
		}
		if (Profile.depthOfField.enabled)
		{
			RestoreDOF = true;
		}
		ReduceKnee();
		Profile.colorGrading.enabled = false;
		if (GameGlobals.Eighties)
		{
			BecomeEighties();
		}
		else
		{
			EightiesCarpet.SetActive(value: false);
			ModernCarpet.SetActive(value: true);
			Butsudan.localPosition = new Vector3(-0.2041f, 0.095f, 0.241f);
			Butsudan.localEulerAngles = new Vector3(0f, 135f, 0f);
			ModernDayRoom.SetActive(value: true);
			EightiesRoom.SetActive(value: false);
			EightiesLabelPanel.SetActive(value: false);
			LabelPanel.SetActive(value: true);
			EightiesTriggers[1].transform.parent.gameObject.SetActive(value: false);
			Triggers[1].transform.parent.gameObject.SetActive(value: true);
		}
		if (!OptionGlobals.Vsync)
		{
			QualitySettings.vSyncCount = 0;
		}
		else
		{
			QualitySettings.vSyncCount = 1;
		}
	}

	private void LateUpdate()
	{
		OutOfRoomDestinations[4].transform.position = new Vector3(OutOfRoomDestinations[4].transform.position.x, OutOfRoomDestinations[4].transform.position.y, 1f - (0.8347812f - HomeYandere.Yandere.transform.position.z) * 0.5f);
		if (CooldownTimer == 0f)
		{
			if (HomeYandere.CanMove)
			{
				if (HomeYandere.transform.position.y > -0.1f && HomeYandere.Yandere.transform.position.x > -2.56f && HomeYandere.Yandere.transform.position.z < 2.914333f)
				{
					if (!TooClose && CameraTimer == 0f && Destination != Destinations[0])
					{
						Destination = Destinations[0];
						LastChangePoint = HomeYandere.transform.position;
						base.transform.position = Destination.position;
						CameraTimer = 1f;
						TooClose = true;
						RecentlyMoved = true;
					}
					Destinations[0].position = new Vector3(0f - HomeYandere.transform.position.x, Destinations[0].position.y, Destinations[0].position.z);
					if (HomeYandere.transform.position.y > -5f && Destinations[0].transform.position.y < 0f)
					{
						Destinations[0].transform.position = new Vector3(Destinations[0].transform.position.x, 1.5f, 2.4185f);
						base.transform.position = new Vector3(base.transform.position.x, 1.5f, 2.4185f);
					}
					base.transform.position = Vector3.Lerp(base.transform.position, Destination.position, Time.deltaTime * 10f);
					InHouse = false;
				}
				else if (HomeYandere.transform.position.y < -5f)
				{
					Destinations[0].position = new Vector3(2.425f, -8.5f, 0f);
					Destination = Destinations[0];
					base.transform.position = Vector3.Lerp(base.transform.position, Destination.position, Time.deltaTime * 10f);
					InHouse = false;
				}
				else if (HomeYandere.transform.position.x < -15f && HomeYandere.transform.position.z > 10.445f)
				{
					if (!TooClose && CameraTimer == 0f && Destination != OutOfRoomDestinations[5])
					{
						if (HomeYandere.CanMove)
						{
							Destination = OutOfRoomDestinations[5];
						}
						else
						{
							Destination = OutOfRoomDestinations[6];
						}
						LastChangePoint = HomeYandere.transform.position;
						CameraTimer = 1f;
						TooClose = true;
						RecentlyMoved = true;
					}
					base.transform.position = Destination.position;
				}
				else if (HomeYandere.transform.position.x < -8.4f)
				{
					if (!TooClose && CameraTimer == 0f && Destination != OutOfRoomDestinations[4])
					{
						Destination = OutOfRoomDestinations[4];
						LastChangePoint = HomeYandere.transform.position;
						CameraTimer = 1f;
						TooClose = true;
						RecentlyMoved = true;
					}
					base.transform.position = Destination.position;
				}
				else if (HomeYandere.transform.position.y < -2.8f)
				{
					if (HomeYandere.transform.position.z < 7.269f)
					{
						base.transform.position = Destination.position;
						if (!TooClose && CameraTimer == 0f)
						{
							if (Destination != OutOfRoomDestinations[2])
							{
								Destination = OutOfRoomDestinations[2];
								LastChangePoint = HomeYandere.transform.position;
								CameraTimer = 1f;
								TooClose = true;
								RecentlyMoved = true;
							}
							float num = 0f;
							if (HomeYandere.transform.position.z < Destination.position.z)
							{
								num = (Destination.position.z - HomeYandere.transform.position.z) * 0.4f;
							}
							float num2 = 0f;
							base.transform.position = new Vector3(base.transform.position.x + num, base.transform.position.y, base.transform.position.z + num2);
						}
					}
					else
					{
						if (!TooClose && CameraTimer == 0f && Destination != OutOfRoomDestinations[3])
						{
							Destination = OutOfRoomDestinations[3];
							LastChangePoint = HomeYandere.transform.position;
							CameraTimer = 1f;
							TooClose = true;
							RecentlyMoved = true;
						}
						base.transform.position = Destination.position;
					}
					InHouse = true;
				}
				else if (HomeYandere.transform.position.y > 0f)
				{
					if (!TooClose && CameraTimer == 0f && Destination != OutOfRoomDestinations[0])
					{
						Destination = OutOfRoomDestinations[0];
						LastChangePoint = HomeYandere.transform.position;
						CameraTimer = 1f;
						TooClose = true;
						RecentlyMoved = true;
					}
					base.transform.position = Destination.position;
				}
				else if (HomeYandere.transform.position.y > -2.8f)
				{
					if (!TooClose && CameraTimer == 0f && Destination != OutOfRoomDestinations[1])
					{
						Destination = OutOfRoomDestinations[1];
						LastChangePoint = HomeYandere.transform.position;
						CameraTimer = 1f;
						TooClose = true;
						RecentlyMoved = true;
					}
					base.transform.position = Destination.position;
				}
			}
			else
			{
				if (Destination == OutOfRoomDestinations[5])
				{
					Destination = OutOfRoomDestinations[6];
				}
				base.transform.position = Vector3.Lerp(base.transform.position, Destination.position, Time.deltaTime * 10f);
			}
		}
		Focus.position = Vector3.Lerp(Focus.position, Target.position, Time.deltaTime * 10f);
		base.transform.LookAt(Focus.position);
		if (HomeYandere.CanMove)
		{
			ResetChroma();
			UpdateDOF(1.66666f);
			if (RestoreBloom)
			{
				Profile.bloom.enabled = true;
			}
			if (RestoreDOF)
			{
				Profile.depthOfField.enabled = true;
			}
		}
		else if (!HomeDarkness.FadeOut)
		{
			if (ID == 6)
			{
				Profile.depthOfField.enabled = false;
			}
			else if (ID == 3)
			{
				Profile.bloom.enabled = false;
				Profile.depthOfField.enabled = false;
			}
		}
		if (ID != 11 && Input.GetButtonDown(InputNames.Xbox_A) && HomeYandere.CanMove && ID != 0 && CooldownTimer == 0f)
		{
			Destination = Destinations[ID];
			Target = Targets[ID];
			HomeWindows[ID].Show = true;
			HomeYandere.CanMove = false;
			if (ID == 1 || ID == 8)
			{
				HomeExit.Start();
				HomeExit.enabled = true;
			}
			else if (ID == 2)
			{
				HomeSleep.enabled = true;
			}
			else if (ID == 3)
			{
				HomeInternet.enabled = true;
			}
			else if (ID == 4)
			{
				CorkboardLabel.SetActive(value: false);
				HomeCorkboard.enabled = true;
				LoadingScreen.SetActive(value: true);
				HomeYandere.gameObject.SetActive(value: false);
			}
			else if (ID == 5)
			{
				HomeYandere.enabled = false;
				if (!Eighties)
				{
					HomeYandere.transform.position = new Vector3(1f, 0f, 0f);
					HomeYandere.transform.eulerAngles = new Vector3(0f, 90f, 0f);
					Controller.transform.localPosition = new Vector3(0.1245f, 0.032f, 0f);
				}
				else
				{
					HomeYandere.transform.position = new Vector3(-2f, 0f, 0f);
					HomeYandere.transform.eulerAngles = new Vector3(0f, -90f, 0f);
					EightiesController.transform.localPosition = new Vector3(-0.394f, -0.01075f, -0.03f);
				}
				HomeYandere.Character.GetComponent<Animation>().Play("f02_gaming_00");
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Play";
				PromptBar.Label[1].text = "Back";
				PromptBar.Label[4].text = "Select";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
			}
			else if (ID == 6)
			{
				HomeSenpaiShrine.enabled = true;
				AudioSource.PlayClipAtPoint(HomeSenpaiShrine.ShrineOpen, base.transform.position);
				HomeYandere.gameObject.SetActive(value: false);
			}
			else if (ID == 7)
			{
				HomePantyChanger.enabled = true;
				AudioSource.PlayClipAtPoint(OpenDrawer, base.transform.position);
			}
			else if (ID == 9)
			{
				HomeManga.enabled = true;
			}
			else if (ID == 10)
			{
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Accept";
				PromptBar.Label[1].text = "Back";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
				HomePrisoner.UpdateDesc();
				HomeYandere.gameObject.SetActive(value: false);
			}
			else if (ID == 12)
			{
				HomeAnime.enabled = true;
			}
		}
		if (Destination == Destinations[0])
		{
			Vignette.intensity = ((HomeYandere.transform.position.y > -1f) ? Mathf.MoveTowards(Vignette.intensity, 1f, Time.deltaTime) : Mathf.MoveTowards(Vignette.intensity, 5f, Time.deltaTime * 5f));
			Vignette.chromaticAberration = Mathf.MoveTowards(Vignette.chromaticAberration, 1f, Time.deltaTime);
			Vignette.blur = Mathf.MoveTowards(Vignette.blur, 1f, Time.deltaTime);
		}
		else
		{
			Vignette.intensity = ((HomeYandere.transform.position.y > -1f) ? Mathf.MoveTowards(Vignette.intensity, 0f, Time.deltaTime) : Mathf.MoveTowards(Vignette.intensity, 0f, Time.deltaTime * 5f));
			Vignette.chromaticAberration = Mathf.MoveTowards(Vignette.chromaticAberration, 0f, Time.deltaTime);
			Vignette.blur = Mathf.MoveTowards(Vignette.blur, 0f, Time.deltaTime);
		}
		Button.color = new Color(Button.color.r, Button.color.g, Button.color.b, Mathf.MoveTowards(Button.color.a, (ID > 0 && HomeYandere.CanMove) ? 1f : 0f, Time.deltaTime * 10f));
		if (HomeDarkness.FadeOut)
		{
			BasementJukebox.volume = Mathf.MoveTowards(BasementJukebox.volume, 0f, Time.deltaTime);
			RoomJukebox.volume = Mathf.MoveTowards(RoomJukebox.volume, 0f, Time.deltaTime);
		}
		else if (!Torturing)
		{
			if (HomeYandere.transform.position.y < -7.5f)
			{
				BasementJukebox.volume = Mathf.MoveTowards(BasementJukebox.volume, 0.5f, Time.deltaTime);
				RoomJukebox.volume = Mathf.MoveTowards(RoomJukebox.volume, 0f, Time.deltaTime);
			}
			else
			{
				BasementJukebox.volume = Mathf.MoveTowards(BasementJukebox.volume, 0f, Time.deltaTime);
				RoomJukebox.volume = Mathf.MoveTowards(RoomJukebox.volume, 0.5f, Time.deltaTime);
			}
		}
		if (Input.GetKeyDown(KeyCode.M))
		{
			BasementJukebox.gameObject.SetActive(value: false);
			RoomJukebox.gameObject.SetActive(value: false);
		}
		if (OpenDoor)
		{
			Rotation = Mathf.Lerp(Rotation, -127.5f, Time.deltaTime);
			BedroomDoor.localEulerAngles = new Vector3(-90f, Rotation, 0f);
		}
		if (ID > 0)
		{
			LastID = ID;
		}
		if (CooldownTimer > 0f)
		{
			CooldownTimer = Mathf.MoveTowards(CooldownTimer, 0f, Time.deltaTime);
		}
		if (CameraTimer > 0f)
		{
			CameraTimer = Mathf.MoveTowards(CameraTimer, 0f, Time.deltaTime);
		}
		if (TooClose && Vector3.Distance(HomeYandere.transform.position, LastChangePoint) > 1f)
		{
			TooClose = false;
		}
	}

	public void PlayMusic()
	{
		if (!YanvaniaGlobals.DraculaDefeated && !HomeGlobals.MiyukiDefeated)
		{
			if (!BasementJukebox.isPlaying)
			{
				BasementJukebox.Play();
			}
			if (!RoomJukebox.isPlaying)
			{
				RoomJukebox.Play();
			}
		}
	}

	private void LoveSickColorSwap()
	{
		GameObject[] array = UnityEngine.Object.FindObjectsOfType<GameObject>();
		foreach (GameObject gameObject in array)
		{
			if (gameObject.transform.parent != PauseScreen && gameObject.transform.parent != PromptBarPanel)
			{
				UISprite component = gameObject.GetComponent<UISprite>();
				if (component != null && component.color != Color.black)
				{
					component.color = new Color(1f, 0f, 0f, component.color.a);
				}
				UILabel component2 = gameObject.GetComponent<UILabel>();
				if (component2 != null && component2.color != Color.black)
				{
					component2.color = new Color(1f, 0f, 0f, component2.color.a);
				}
			}
		}
		DayLight.GetComponent<Light>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
		HomeDarkness.Sprite.color = Color.black;
		BasementJukebox.clip = HomeLoveSick;
		RoomJukebox.clip = HomeLoveSick;
		LoveSickCamera.SetActive(value: true);
		PlayMusic();
	}

	public void UpdateDOF(float Focus)
	{
		Focus *= ((float)Screen.width / 1280f + (float)Screen.height / 720f) * 0.5f;
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		settings.focusDistance = Focus;
		Profile.depthOfField.settings = settings;
		UpdateAperture(5.6f);
	}

	public void UpdateAperture(float Aperture)
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		float num = (float)Screen.width / 1280f;
		settings.aperture = Aperture * num;
		settings.focalLength = 50f;
		Profile.depthOfField.settings = settings;
	}

	private void ReduceKnee()
	{
		BloomModel.Settings settings = Profile.bloom.settings;
		settings.bloom.softKnee = 0.75f;
		Profile.bloom.settings = settings;
	}

	private void ResetBloom()
	{
		BloomModel.Settings settings = Profile.bloom.settings;
		settings.bloom.intensity = 1f;
		settings.bloom.threshold = 1.1f;
		settings.bloom.softKnee = 0.75f;
		settings.bloom.radius = 4f;
		Profile.bloom.settings = settings;
	}

	private void ResetChroma()
	{
		ChromaticAberrationModel.Settings settings = Profile.chromaticAberration.settings;
		settings.intensity = 0.1f;
		Profile.chromaticAberration.settings = settings;
	}

	private void BecomeEighties()
	{
		EightiesCarpet.SetActive(value: true);
		ModernCarpet.SetActive(value: false);
		Butsudan.localPosition = new Vector3(0.2095f, 0.0721f, -0.25f);
		Butsudan.localEulerAngles = new Vector3(0f, -50f, 0f);
		Eighties = true;
		CassetteTapes.SetActive(value: false);
		ModernDayRoom.SetActive(value: false);
		EightiesRoom.SetActive(value: true);
		EightiesLabelPanel.SetActive(value: true);
		LabelPanel.SetActive(value: false);
		MonitorLight.SetActive(value: false);
		EightiesTriggers[1].transform.parent.gameObject.SetActive(value: true);
		Triggers[1].transform.parent.gameObject.SetActive(value: false);
		for (int i = 1; i < HUDLabels.Length; i++)
		{
			EightiesifyLabel(HUDLabels[i]);
		}
		HUDLabels[1].transform.parent.localPosition -= new Vector3(25f, 25f, 0f);
		if (!HomeGlobals.Night)
		{
			BasementJukebox.clip = DayBasement80s;
			RoomJukebox.clip = DayRoom80s;
		}
		else
		{
			BasementJukebox.clip = NightBasement80s;
			RoomJukebox.clip = NightRoom80s;
		}
		BasementJukebox.Play();
		RoomJukebox.Play();
		Destinations = EightiesDestinations;
		Triggers = EightiesTriggers;
		Targets = EightiesTargets;
		Destination = Destinations[0];
		ComputerScreen.SetActive(value: false);
		if (HomeGlobals.Night)
		{
			Triggers[7].Disable();
		}
		else if (DateGlobals.Weekday != 0)
		{
			Triggers[5].Disable();
			Triggers[9].Disable();
		}
		CeilingLight.transform.localPosition = new Vector3(-0.049f, 0.2666f, 0.007f);
		CeilingLight.GetComponent<Light>().intensity = 3f;
	}

	public void EightiesifyLabel(UILabel Label)
	{
		Label.trueTypeFont = VCR;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 1f, 1f);
		Label.effectStyle = UILabel.Effect.Outline8;
		Label.effectColor = new Color(0f, 0f, 0f, 1f);
	}
}
