using System;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x02000318 RID: 792
public class HomeCameraScript : MonoBehaviour
{
	// Token: 0x06001878 RID: 6264 RVA: 0x000ECAF0 File Offset: 0x000EACF0
	public void Start()
	{
		this.ResetBloom();
		this.HomeSleep.Start();
		this.Button.color = new Color(this.Button.color.r, this.Button.color.g, this.Button.color.b, 0f);
		this.Focus.position = this.Target.position;
		base.transform.position = this.Destination.position;
		if (HomeGlobals.Night)
		{
			this.CeilingLight.SetActive(true);
			this.SenpaiLight.SetActive(true);
			this.NightLight.SetActive(true);
			this.DayLight.SetActive(false);
			this.Triggers[7].Disable();
			this.BasementJukebox.clip = this.NightBasement;
			this.RoomJukebox.clip = this.NightRoom;
			this.PlayMusic();
			this.PantiesMangaLabel.text = "Read Manga";
		}
		else
		{
			this.BasementJukebox.Play();
			this.RoomJukebox.Play();
			this.ComputerScreen.SetActive(false);
			if (DateGlobals.Weekday == DayOfWeek.Friday && GameGlobals.RivalEliminationID == 0)
			{
				this.EightiesTriggers[2].Disable();
				this.Triggers[2].Disable();
			}
			this.Triggers[3].Disable();
			this.Triggers[5].Disable();
			this.Triggers[9].Disable();
		}
		if (SchoolGlobals.KidnapVictim == 0)
		{
			this.RopeGroup.SetActive(false);
			this.Tripod.SetActive(false);
			this.Victim.SetActive(false);
			this.EightiesTriggers[10].Disable();
			this.Triggers[10].Disable();
		}
		else
		{
			int kidnapVictim = SchoolGlobals.KidnapVictim;
			if (StudentGlobals.GetStudentArrested(kidnapVictim) || StudentGlobals.GetStudentDead(kidnapVictim))
			{
				this.RopeGroup.SetActive(false);
				this.Victim.SetActive(false);
				this.EightiesTriggers[10].Disable();
				this.Triggers[10].Disable();
			}
		}
		if (GameGlobals.LoveSick)
		{
			this.LoveSickColorSwap();
		}
		Time.timeScale = 1f;
		this.HairLock.material.color = this.SenpaiCosmetic.ColorValue;
		if (SchoolGlobals.SchoolAtmosphere > 1f)
		{
			SchoolGlobals.SchoolAtmosphere = 1f;
		}
		if (this.Profile.bloom.enabled)
		{
			this.RestoreBloom = true;
		}
		if (this.Profile.depthOfField.enabled)
		{
			this.RestoreDOF = true;
		}
		this.ReduceKnee();
		this.Profile.colorGrading.enabled = false;
		if (GameGlobals.Eighties)
		{
			this.BecomeEighties();
			return;
		}
		this.Butsudan.localPosition = new Vector3(-0.2041f, 0.095f, 0.241f);
		this.Butsudan.localEulerAngles = new Vector3(0f, 135f, 0f);
		this.ModernDayRoom.SetActive(true);
		this.EightiesRoom.SetActive(false);
		this.EightiesLabelPanel.SetActive(false);
		this.LabelPanel.SetActive(true);
		this.EightiesTriggers[1].transform.parent.gameObject.SetActive(false);
		this.Triggers[1].transform.parent.gameObject.SetActive(true);
	}

	// Token: 0x06001879 RID: 6265 RVA: 0x000ECE4C File Offset: 0x000EB04C
	private void LateUpdate()
	{
		if (this.HomeYandere.transform.position.y > -5f)
		{
			Transform transform = this.Destinations[0];
			transform.position = new Vector3(-this.HomeYandere.transform.position.x, transform.position.y, transform.position.z);
		}
		this.Focus.position = Vector3.Lerp(this.Focus.position, this.Target.position, Time.deltaTime * 10f);
		base.transform.position = Vector3.Lerp(base.transform.position, this.Destination.position, Time.deltaTime * 10f);
		base.transform.LookAt(this.Focus.position);
		if (this.HomeYandere.CanMove)
		{
			this.UpdateDOF(1.66666f);
			if (this.RestoreBloom)
			{
				this.Profile.bloom.enabled = true;
			}
			if (this.RestoreDOF)
			{
				this.Profile.depthOfField.enabled = true;
			}
		}
		else if (!this.HomeDarkness.FadeOut)
		{
			if (this.ID == 6)
			{
				this.Profile.depthOfField.enabled = false;
			}
			else if (this.ID == 3)
			{
				this.Profile.bloom.enabled = false;
				this.Profile.depthOfField.enabled = false;
			}
		}
		if (this.ID != 11 && Input.GetButtonDown("A") && this.HomeYandere.CanMove && this.ID != 0)
		{
			this.Destination = this.Destinations[this.ID];
			this.Target = this.Targets[this.ID];
			this.HomeWindows[this.ID].Show = true;
			this.HomeYandere.CanMove = false;
			if (this.ID == 1 || this.ID == 8)
			{
				this.HomeExit.enabled = true;
			}
			else if (this.ID == 2)
			{
				this.HomeSleep.enabled = true;
			}
			else if (this.ID == 3)
			{
				this.HomeInternet.enabled = true;
			}
			else if (this.ID == 4)
			{
				this.CorkboardLabel.SetActive(false);
				this.HomeCorkboard.enabled = true;
				this.LoadingScreen.SetActive(true);
				this.HomeYandere.gameObject.SetActive(false);
			}
			else if (this.ID == 5)
			{
				this.HomeYandere.enabled = false;
				if (!this.Eighties)
				{
					this.HomeYandere.transform.position = new Vector3(1f, 0f, 0f);
					this.HomeYandere.transform.eulerAngles = new Vector3(0f, 90f, 0f);
					this.Controller.transform.localPosition = new Vector3(0.1245f, 0.032f, 0f);
				}
				else
				{
					this.HomeYandere.transform.position = new Vector3(-2f, 0f, 0f);
					this.HomeYandere.transform.eulerAngles = new Vector3(0f, -90f, 0f);
					this.EightiesController.transform.localPosition = new Vector3(-0.394f, -0.01075f, -0.03f);
				}
				this.HomeYandere.Character.GetComponent<Animation>().Play("f02_gaming_00");
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "Play";
				this.PromptBar.Label[1].text = "Back";
				this.PromptBar.Label[4].text = "Select";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
			}
			else if (this.ID == 6)
			{
				this.HomeSenpaiShrine.enabled = true;
				this.HomeYandere.gameObject.SetActive(false);
			}
			else if (this.ID == 7)
			{
				this.HomePantyChanger.enabled = true;
				AudioSource.PlayClipAtPoint(this.OpenDrawer, base.transform.position);
			}
			else if (this.ID == 9)
			{
				this.HomeManga.enabled = true;
			}
			else if (this.ID == 10)
			{
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "Accept";
				this.PromptBar.Label[1].text = "Back";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
				this.HomePrisoner.UpdateDesc();
				this.HomeYandere.gameObject.SetActive(false);
			}
			else if (this.ID == 12)
			{
				this.HomeAnime.enabled = true;
			}
		}
		if (this.Destination == this.Destinations[0])
		{
			this.Vignette.intensity = ((this.HomeYandere.transform.position.y > -1f) ? Mathf.MoveTowards(this.Vignette.intensity, 1f, Time.deltaTime) : Mathf.MoveTowards(this.Vignette.intensity, 5f, Time.deltaTime * 5f));
			this.Vignette.chromaticAberration = Mathf.MoveTowards(this.Vignette.chromaticAberration, 1f, Time.deltaTime);
			this.Vignette.blur = Mathf.MoveTowards(this.Vignette.blur, 1f, Time.deltaTime);
		}
		else
		{
			this.Vignette.intensity = ((this.HomeYandere.transform.position.y > -1f) ? Mathf.MoveTowards(this.Vignette.intensity, 0f, Time.deltaTime) : Mathf.MoveTowards(this.Vignette.intensity, 0f, Time.deltaTime * 5f));
			this.Vignette.chromaticAberration = Mathf.MoveTowards(this.Vignette.chromaticAberration, 0f, Time.deltaTime);
			this.Vignette.blur = Mathf.MoveTowards(this.Vignette.blur, 0f, Time.deltaTime);
		}
		this.Button.color = new Color(this.Button.color.r, this.Button.color.g, this.Button.color.b, Mathf.MoveTowards(this.Button.color.a, (this.ID > 0 && this.HomeYandere.CanMove) ? 1f : 0f, Time.deltaTime * 10f));
		if (this.HomeDarkness.FadeOut)
		{
			this.BasementJukebox.volume = Mathf.MoveTowards(this.BasementJukebox.volume, 0f, Time.deltaTime);
			this.RoomJukebox.volume = Mathf.MoveTowards(this.RoomJukebox.volume, 0f, Time.deltaTime);
		}
		else if (this.HomeYandere.transform.position.y > -1f)
		{
			this.BasementJukebox.volume = Mathf.MoveTowards(this.BasementJukebox.volume, 0f, Time.deltaTime);
			this.RoomJukebox.volume = Mathf.MoveTowards(this.RoomJukebox.volume, 0.5f, Time.deltaTime);
		}
		else if (!this.Torturing)
		{
			this.BasementJukebox.volume = Mathf.MoveTowards(this.BasementJukebox.volume, 0.5f, Time.deltaTime);
			this.RoomJukebox.volume = Mathf.MoveTowards(this.RoomJukebox.volume, 0f, Time.deltaTime);
		}
		if (Input.GetKeyDown(KeyCode.M))
		{
			this.BasementJukebox.gameObject.SetActive(false);
			this.RoomJukebox.gameObject.SetActive(false);
		}
	}

	// Token: 0x0600187A RID: 6266 RVA: 0x000ED6A2 File Offset: 0x000EB8A2
	public void PlayMusic()
	{
		if (!YanvaniaGlobals.DraculaDefeated && !HomeGlobals.MiyukiDefeated)
		{
			if (!this.BasementJukebox.isPlaying)
			{
				this.BasementJukebox.Play();
			}
			if (!this.RoomJukebox.isPlaying)
			{
				this.RoomJukebox.Play();
			}
		}
	}

	// Token: 0x0600187B RID: 6267 RVA: 0x000ED6E4 File Offset: 0x000EB8E4
	private void LoveSickColorSwap()
	{
		foreach (GameObject gameObject in UnityEngine.Object.FindObjectsOfType<GameObject>())
		{
			if (gameObject.transform.parent != this.PauseScreen && gameObject.transform.parent != this.PromptBarPanel)
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
		this.DayLight.GetComponent<Light>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
		this.HomeDarkness.Sprite.color = Color.black;
		this.BasementJukebox.clip = this.HomeLoveSick;
		this.RoomJukebox.clip = this.HomeLoveSick;
		this.LoveSickCamera.SetActive(true);
		this.PlayMusic();
	}

	// Token: 0x0600187C RID: 6268 RVA: 0x000ED84C File Offset: 0x000EBA4C
	public void UpdateDOF(float Focus)
	{
		Focus *= ((float)Screen.width / 1280f + (float)Screen.height / 720f) * 0.5f;
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = Focus;
		this.Profile.depthOfField.settings = settings;
	}

	// Token: 0x0600187D RID: 6269 RVA: 0x000ED8A8 File Offset: 0x000EBAA8
	private void ReduceKnee()
	{
		BloomModel.Settings settings = this.Profile.bloom.settings;
		settings.bloom.softKnee = 0.75f;
		this.Profile.bloom.settings = settings;
	}

	// Token: 0x0600187E RID: 6270 RVA: 0x000ED8E8 File Offset: 0x000EBAE8
	private void ResetBloom()
	{
		BloomModel.Settings settings = this.Profile.bloom.settings;
		settings.bloom.intensity = 1f;
		settings.bloom.threshold = 1.1f;
		settings.bloom.softKnee = 0.75f;
		settings.bloom.radius = 4f;
		this.Profile.bloom.settings = settings;
	}

	// Token: 0x0600187F RID: 6271 RVA: 0x000ED95C File Offset: 0x000EBB5C
	private void BecomeEighties()
	{
		this.Eighties = true;
		this.CassetteTapes.SetActive(false);
		this.ModernDayRoom.SetActive(false);
		this.EightiesRoom.SetActive(true);
		this.EightiesLabelPanel.SetActive(true);
		this.LabelPanel.SetActive(false);
		this.MonitorLight.SetActive(false);
		this.EightiesTriggers[1].transform.parent.gameObject.SetActive(true);
		this.Triggers[1].transform.parent.gameObject.SetActive(false);
		for (int i = 1; i < this.HUDLabels.Length; i++)
		{
			this.EightiesifyLabel(this.HUDLabels[i]);
		}
		this.HUDLabels[1].transform.parent.localPosition -= new Vector3(25f, 25f, 0f);
		if (!HomeGlobals.Night)
		{
			this.BasementJukebox.clip = this.DayBasement80s;
			this.RoomJukebox.clip = this.DayRoom80s;
		}
		else
		{
			this.BasementJukebox.clip = this.NightBasement80s;
			this.RoomJukebox.clip = this.NightRoom80s;
		}
		this.BasementJukebox.Play();
		this.RoomJukebox.Play();
		this.Destinations = this.EightiesDestinations;
		this.Triggers = this.EightiesTriggers;
		this.Targets = this.EightiesTargets;
		this.Destination = this.Destinations[0];
		this.ComputerScreen.SetActive(false);
		if (HomeGlobals.Night)
		{
			this.Triggers[7].Disable();
		}
		else if (DateGlobals.Weekday != DayOfWeek.Sunday)
		{
			this.Triggers[5].Disable();
			this.Triggers[9].Disable();
		}
		this.CeilingLight.transform.localPosition = new Vector3(-0.049f, 0.2666f, 0.007f);
		this.CeilingLight.GetComponent<Light>().intensity = 3f;
	}

	// Token: 0x06001880 RID: 6272 RVA: 0x000EDB5C File Offset: 0x000EBD5C
	public void EightiesifyLabel(UILabel Label)
	{
		Label.trueTypeFont = this.VCR;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 1f, 1f);
		Label.effectStyle = UILabel.Effect.Outline8;
		Label.effectColor = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x04002467 RID: 9319
	public HomeTriggerScript[] EightiesTriggers;

	// Token: 0x04002468 RID: 9320
	public HomeTriggerScript[] Triggers;

	// Token: 0x04002469 RID: 9321
	public HomeWindowScript[] HomeWindows;

	// Token: 0x0400246A RID: 9322
	public HomePantyChangerScript HomePantyChanger;

	// Token: 0x0400246B RID: 9323
	public HomeSenpaiShrineScript HomeSenpaiShrine;

	// Token: 0x0400246C RID: 9324
	public HomeVideoGamesScript HomeVideoGames;

	// Token: 0x0400246D RID: 9325
	public HomeCorkboardScript HomeCorkboard;

	// Token: 0x0400246E RID: 9326
	public HomeDarknessScript HomeDarkness;

	// Token: 0x0400246F RID: 9327
	public HomeInternetScript HomeInternet;

	// Token: 0x04002470 RID: 9328
	public HomePrisonerScript HomePrisoner;

	// Token: 0x04002471 RID: 9329
	public HomeYandereScript HomeYandere;

	// Token: 0x04002472 RID: 9330
	public HomeSleepScript HomeAnime;

	// Token: 0x04002473 RID: 9331
	public HomeMangaScript HomeManga;

	// Token: 0x04002474 RID: 9332
	public HomeSleepScript HomeSleep;

	// Token: 0x04002475 RID: 9333
	public HomeExitScript HomeExit;

	// Token: 0x04002476 RID: 9334
	public PostProcessingProfile Profile;

	// Token: 0x04002477 RID: 9335
	public PromptBarScript PromptBar;

	// Token: 0x04002478 RID: 9336
	public Vignetting Vignette;

	// Token: 0x04002479 RID: 9337
	public UILabel PantiesMangaLabel;

	// Token: 0x0400247A RID: 9338
	public UISprite Button;

	// Token: 0x0400247B RID: 9339
	public GameObject CyberstalkWindow;

	// Token: 0x0400247C RID: 9340
	public GameObject ComputerScreen;

	// Token: 0x0400247D RID: 9341
	public GameObject CorkboardLabel;

	// Token: 0x0400247E RID: 9342
	public GameObject LoveSickCamera;

	// Token: 0x0400247F RID: 9343
	public GameObject LoadingScreen;

	// Token: 0x04002480 RID: 9344
	public GameObject CeilingLight;

	// Token: 0x04002481 RID: 9345
	public GameObject SenpaiLight;

	// Token: 0x04002482 RID: 9346
	public GameObject Controller;

	// Token: 0x04002483 RID: 9347
	public GameObject NightLight;

	// Token: 0x04002484 RID: 9348
	public GameObject RopeGroup;

	// Token: 0x04002485 RID: 9349
	public GameObject DayLight;

	// Token: 0x04002486 RID: 9350
	public GameObject Tripod;

	// Token: 0x04002487 RID: 9351
	public GameObject Victim;

	// Token: 0x04002488 RID: 9352
	public Transform Destination;

	// Token: 0x04002489 RID: 9353
	public Transform Butsudan;

	// Token: 0x0400248A RID: 9354
	public Transform Target;

	// Token: 0x0400248B RID: 9355
	public Transform Focus;

	// Token: 0x0400248C RID: 9356
	public Transform[] EightiesDestinations;

	// Token: 0x0400248D RID: 9357
	public Transform[] EightiesTargets;

	// Token: 0x0400248E RID: 9358
	public Transform[] Destinations;

	// Token: 0x0400248F RID: 9359
	public Transform[] Targets;

	// Token: 0x04002490 RID: 9360
	public int Frame;

	// Token: 0x04002491 RID: 9361
	public int ID;

	// Token: 0x04002492 RID: 9362
	public AudioSource BasementJukebox;

	// Token: 0x04002493 RID: 9363
	public AudioSource RoomJukebox;

	// Token: 0x04002494 RID: 9364
	public AudioClip NightBasement;

	// Token: 0x04002495 RID: 9365
	public AudioClip NightRoom;

	// Token: 0x04002496 RID: 9366
	public AudioClip HomeLoveSick;

	// Token: 0x04002497 RID: 9367
	public bool RestoreBloom;

	// Token: 0x04002498 RID: 9368
	public bool RestoreDOF;

	// Token: 0x04002499 RID: 9369
	public bool Torturing;

	// Token: 0x0400249A RID: 9370
	public bool Eighties;

	// Token: 0x0400249B RID: 9371
	public CosmeticScript SenpaiCosmetic;

	// Token: 0x0400249C RID: 9372
	public Renderer HairLock;

	// Token: 0x0400249D RID: 9373
	public AudioClip OpenDrawer;

	// Token: 0x0400249E RID: 9374
	public Transform PromptBarPanel;

	// Token: 0x0400249F RID: 9375
	public Transform PauseScreen;

	// Token: 0x040024A0 RID: 9376
	public GameObject CassetteTapes;

	// Token: 0x040024A1 RID: 9377
	public UILabel[] HUDLabels;

	// Token: 0x040024A2 RID: 9378
	public AudioClip DayRoom80s;

	// Token: 0x040024A3 RID: 9379
	public AudioClip DayBasement80s;

	// Token: 0x040024A4 RID: 9380
	public AudioClip NightRoom80s;

	// Token: 0x040024A5 RID: 9381
	public AudioClip NightBasement80s;

	// Token: 0x040024A6 RID: 9382
	public GameObject EightiesController;

	// Token: 0x040024A7 RID: 9383
	public GameObject ModernDayRoom;

	// Token: 0x040024A8 RID: 9384
	public GameObject EightiesRoom;

	// Token: 0x040024A9 RID: 9385
	public GameObject EightiesLabelPanel;

	// Token: 0x040024AA RID: 9386
	public GameObject LabelPanel;

	// Token: 0x040024AB RID: 9387
	public GameObject MonitorLight;

	// Token: 0x040024AC RID: 9388
	public Font VCR;
}
