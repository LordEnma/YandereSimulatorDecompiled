using System;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x02000314 RID: 788
public class HomeCameraScript : MonoBehaviour
{
	// Token: 0x0600184F RID: 6223 RVA: 0x000EAA54 File Offset: 0x000E8C54
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

	// Token: 0x06001850 RID: 6224 RVA: 0x000EADB0 File Offset: 0x000E8FB0
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

	// Token: 0x06001851 RID: 6225 RVA: 0x000EB606 File Offset: 0x000E9806
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

	// Token: 0x06001852 RID: 6226 RVA: 0x000EB648 File Offset: 0x000E9848
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

	// Token: 0x06001853 RID: 6227 RVA: 0x000EB7B0 File Offset: 0x000E99B0
	public void UpdateDOF(float Focus)
	{
		Focus *= ((float)Screen.width / 1280f + (float)Screen.height / 720f) * 0.5f;
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = Focus;
		this.Profile.depthOfField.settings = settings;
	}

	// Token: 0x06001854 RID: 6228 RVA: 0x000EB80C File Offset: 0x000E9A0C
	private void ReduceKnee()
	{
		BloomModel.Settings settings = this.Profile.bloom.settings;
		settings.bloom.softKnee = 0.75f;
		this.Profile.bloom.settings = settings;
	}

	// Token: 0x06001855 RID: 6229 RVA: 0x000EB84C File Offset: 0x000E9A4C
	private void ResetBloom()
	{
		BloomModel.Settings settings = this.Profile.bloom.settings;
		settings.bloom.intensity = 1f;
		settings.bloom.threshold = 1.1f;
		settings.bloom.softKnee = 0.75f;
		settings.bloom.radius = 4f;
		this.Profile.bloom.settings = settings;
	}

	// Token: 0x06001856 RID: 6230 RVA: 0x000EB8C0 File Offset: 0x000E9AC0
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

	// Token: 0x06001857 RID: 6231 RVA: 0x000EBAC0 File Offset: 0x000E9CC0
	public void EightiesifyLabel(UILabel Label)
	{
		Label.trueTypeFont = this.VCR;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 1f, 1f);
		Label.effectStyle = UILabel.Effect.Outline8;
		Label.effectColor = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x04002406 RID: 9222
	public HomeTriggerScript[] EightiesTriggers;

	// Token: 0x04002407 RID: 9223
	public HomeTriggerScript[] Triggers;

	// Token: 0x04002408 RID: 9224
	public HomeWindowScript[] HomeWindows;

	// Token: 0x04002409 RID: 9225
	public HomePantyChangerScript HomePantyChanger;

	// Token: 0x0400240A RID: 9226
	public HomeSenpaiShrineScript HomeSenpaiShrine;

	// Token: 0x0400240B RID: 9227
	public HomeVideoGamesScript HomeVideoGames;

	// Token: 0x0400240C RID: 9228
	public HomeCorkboardScript HomeCorkboard;

	// Token: 0x0400240D RID: 9229
	public HomeDarknessScript HomeDarkness;

	// Token: 0x0400240E RID: 9230
	public HomeInternetScript HomeInternet;

	// Token: 0x0400240F RID: 9231
	public HomePrisonerScript HomePrisoner;

	// Token: 0x04002410 RID: 9232
	public HomeYandereScript HomeYandere;

	// Token: 0x04002411 RID: 9233
	public HomeSleepScript HomeAnime;

	// Token: 0x04002412 RID: 9234
	public HomeMangaScript HomeManga;

	// Token: 0x04002413 RID: 9235
	public HomeSleepScript HomeSleep;

	// Token: 0x04002414 RID: 9236
	public HomeExitScript HomeExit;

	// Token: 0x04002415 RID: 9237
	public PostProcessingProfile Profile;

	// Token: 0x04002416 RID: 9238
	public PromptBarScript PromptBar;

	// Token: 0x04002417 RID: 9239
	public Vignetting Vignette;

	// Token: 0x04002418 RID: 9240
	public UILabel PantiesMangaLabel;

	// Token: 0x04002419 RID: 9241
	public UISprite Button;

	// Token: 0x0400241A RID: 9242
	public GameObject CyberstalkWindow;

	// Token: 0x0400241B RID: 9243
	public GameObject ComputerScreen;

	// Token: 0x0400241C RID: 9244
	public GameObject CorkboardLabel;

	// Token: 0x0400241D RID: 9245
	public GameObject LoveSickCamera;

	// Token: 0x0400241E RID: 9246
	public GameObject LoadingScreen;

	// Token: 0x0400241F RID: 9247
	public GameObject CeilingLight;

	// Token: 0x04002420 RID: 9248
	public GameObject SenpaiLight;

	// Token: 0x04002421 RID: 9249
	public GameObject Controller;

	// Token: 0x04002422 RID: 9250
	public GameObject NightLight;

	// Token: 0x04002423 RID: 9251
	public GameObject RopeGroup;

	// Token: 0x04002424 RID: 9252
	public GameObject DayLight;

	// Token: 0x04002425 RID: 9253
	public GameObject Tripod;

	// Token: 0x04002426 RID: 9254
	public GameObject Victim;

	// Token: 0x04002427 RID: 9255
	public Transform Destination;

	// Token: 0x04002428 RID: 9256
	public Transform Butsudan;

	// Token: 0x04002429 RID: 9257
	public Transform Target;

	// Token: 0x0400242A RID: 9258
	public Transform Focus;

	// Token: 0x0400242B RID: 9259
	public Transform[] EightiesDestinations;

	// Token: 0x0400242C RID: 9260
	public Transform[] EightiesTargets;

	// Token: 0x0400242D RID: 9261
	public Transform[] Destinations;

	// Token: 0x0400242E RID: 9262
	public Transform[] Targets;

	// Token: 0x0400242F RID: 9263
	public int Frame;

	// Token: 0x04002430 RID: 9264
	public int ID;

	// Token: 0x04002431 RID: 9265
	public AudioSource BasementJukebox;

	// Token: 0x04002432 RID: 9266
	public AudioSource RoomJukebox;

	// Token: 0x04002433 RID: 9267
	public AudioClip NightBasement;

	// Token: 0x04002434 RID: 9268
	public AudioClip NightRoom;

	// Token: 0x04002435 RID: 9269
	public AudioClip HomeLoveSick;

	// Token: 0x04002436 RID: 9270
	public bool RestoreBloom;

	// Token: 0x04002437 RID: 9271
	public bool RestoreDOF;

	// Token: 0x04002438 RID: 9272
	public bool Torturing;

	// Token: 0x04002439 RID: 9273
	public bool Eighties;

	// Token: 0x0400243A RID: 9274
	public CosmeticScript SenpaiCosmetic;

	// Token: 0x0400243B RID: 9275
	public Renderer HairLock;

	// Token: 0x0400243C RID: 9276
	public AudioClip OpenDrawer;

	// Token: 0x0400243D RID: 9277
	public Transform PromptBarPanel;

	// Token: 0x0400243E RID: 9278
	public Transform PauseScreen;

	// Token: 0x0400243F RID: 9279
	public GameObject CassetteTapes;

	// Token: 0x04002440 RID: 9280
	public UILabel[] HUDLabels;

	// Token: 0x04002441 RID: 9281
	public AudioClip DayRoom80s;

	// Token: 0x04002442 RID: 9282
	public AudioClip DayBasement80s;

	// Token: 0x04002443 RID: 9283
	public AudioClip NightRoom80s;

	// Token: 0x04002444 RID: 9284
	public AudioClip NightBasement80s;

	// Token: 0x04002445 RID: 9285
	public GameObject EightiesController;

	// Token: 0x04002446 RID: 9286
	public GameObject ModernDayRoom;

	// Token: 0x04002447 RID: 9287
	public GameObject EightiesRoom;

	// Token: 0x04002448 RID: 9288
	public GameObject EightiesLabelPanel;

	// Token: 0x04002449 RID: 9289
	public GameObject LabelPanel;

	// Token: 0x0400244A RID: 9290
	public GameObject MonitorLight;

	// Token: 0x0400244B RID: 9291
	public Font VCR;
}
