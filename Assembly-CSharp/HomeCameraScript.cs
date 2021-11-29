using System;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x02000312 RID: 786
public class HomeCameraScript : MonoBehaviour
{
	// Token: 0x0600183F RID: 6207 RVA: 0x000E95CC File Offset: 0x000E77CC
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

	// Token: 0x06001840 RID: 6208 RVA: 0x000E9928 File Offset: 0x000E7B28
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

	// Token: 0x06001841 RID: 6209 RVA: 0x000EA17E File Offset: 0x000E837E
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

	// Token: 0x06001842 RID: 6210 RVA: 0x000EA1C0 File Offset: 0x000E83C0
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

	// Token: 0x06001843 RID: 6211 RVA: 0x000EA328 File Offset: 0x000E8528
	public void UpdateDOF(float Focus)
	{
		Focus *= ((float)Screen.width / 1280f + (float)Screen.height / 720f) * 0.5f;
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = Focus;
		this.Profile.depthOfField.settings = settings;
	}

	// Token: 0x06001844 RID: 6212 RVA: 0x000EA384 File Offset: 0x000E8584
	private void ReduceKnee()
	{
		BloomModel.Settings settings = this.Profile.bloom.settings;
		settings.bloom.softKnee = 0.75f;
		this.Profile.bloom.settings = settings;
	}

	// Token: 0x06001845 RID: 6213 RVA: 0x000EA3C4 File Offset: 0x000E85C4
	private void ResetBloom()
	{
		BloomModel.Settings settings = this.Profile.bloom.settings;
		settings.bloom.intensity = 1f;
		settings.bloom.threshold = 1.1f;
		settings.bloom.softKnee = 0.75f;
		settings.bloom.radius = 4f;
		this.Profile.bloom.settings = settings;
	}

	// Token: 0x06001846 RID: 6214 RVA: 0x000EA438 File Offset: 0x000E8638
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

	// Token: 0x06001847 RID: 6215 RVA: 0x000EA638 File Offset: 0x000E8838
	public void EightiesifyLabel(UILabel Label)
	{
		Label.trueTypeFont = this.VCR;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 1f, 1f);
		Label.effectStyle = UILabel.Effect.Outline8;
		Label.effectColor = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x040023D2 RID: 9170
	public HomeTriggerScript[] EightiesTriggers;

	// Token: 0x040023D3 RID: 9171
	public HomeTriggerScript[] Triggers;

	// Token: 0x040023D4 RID: 9172
	public HomeWindowScript[] HomeWindows;

	// Token: 0x040023D5 RID: 9173
	public HomePantyChangerScript HomePantyChanger;

	// Token: 0x040023D6 RID: 9174
	public HomeSenpaiShrineScript HomeSenpaiShrine;

	// Token: 0x040023D7 RID: 9175
	public HomeVideoGamesScript HomeVideoGames;

	// Token: 0x040023D8 RID: 9176
	public HomeCorkboardScript HomeCorkboard;

	// Token: 0x040023D9 RID: 9177
	public HomeDarknessScript HomeDarkness;

	// Token: 0x040023DA RID: 9178
	public HomeInternetScript HomeInternet;

	// Token: 0x040023DB RID: 9179
	public HomePrisonerScript HomePrisoner;

	// Token: 0x040023DC RID: 9180
	public HomeYandereScript HomeYandere;

	// Token: 0x040023DD RID: 9181
	public HomeSleepScript HomeAnime;

	// Token: 0x040023DE RID: 9182
	public HomeMangaScript HomeManga;

	// Token: 0x040023DF RID: 9183
	public HomeSleepScript HomeSleep;

	// Token: 0x040023E0 RID: 9184
	public HomeExitScript HomeExit;

	// Token: 0x040023E1 RID: 9185
	public PostProcessingProfile Profile;

	// Token: 0x040023E2 RID: 9186
	public PromptBarScript PromptBar;

	// Token: 0x040023E3 RID: 9187
	public Vignetting Vignette;

	// Token: 0x040023E4 RID: 9188
	public UILabel PantiesMangaLabel;

	// Token: 0x040023E5 RID: 9189
	public UISprite Button;

	// Token: 0x040023E6 RID: 9190
	public GameObject CyberstalkWindow;

	// Token: 0x040023E7 RID: 9191
	public GameObject ComputerScreen;

	// Token: 0x040023E8 RID: 9192
	public GameObject CorkboardLabel;

	// Token: 0x040023E9 RID: 9193
	public GameObject LoveSickCamera;

	// Token: 0x040023EA RID: 9194
	public GameObject LoadingScreen;

	// Token: 0x040023EB RID: 9195
	public GameObject CeilingLight;

	// Token: 0x040023EC RID: 9196
	public GameObject SenpaiLight;

	// Token: 0x040023ED RID: 9197
	public GameObject Controller;

	// Token: 0x040023EE RID: 9198
	public GameObject NightLight;

	// Token: 0x040023EF RID: 9199
	public GameObject RopeGroup;

	// Token: 0x040023F0 RID: 9200
	public GameObject DayLight;

	// Token: 0x040023F1 RID: 9201
	public GameObject Tripod;

	// Token: 0x040023F2 RID: 9202
	public GameObject Victim;

	// Token: 0x040023F3 RID: 9203
	public Transform Destination;

	// Token: 0x040023F4 RID: 9204
	public Transform Butsudan;

	// Token: 0x040023F5 RID: 9205
	public Transform Target;

	// Token: 0x040023F6 RID: 9206
	public Transform Focus;

	// Token: 0x040023F7 RID: 9207
	public Transform[] EightiesDestinations;

	// Token: 0x040023F8 RID: 9208
	public Transform[] EightiesTargets;

	// Token: 0x040023F9 RID: 9209
	public Transform[] Destinations;

	// Token: 0x040023FA RID: 9210
	public Transform[] Targets;

	// Token: 0x040023FB RID: 9211
	public int Frame;

	// Token: 0x040023FC RID: 9212
	public int ID;

	// Token: 0x040023FD RID: 9213
	public AudioSource BasementJukebox;

	// Token: 0x040023FE RID: 9214
	public AudioSource RoomJukebox;

	// Token: 0x040023FF RID: 9215
	public AudioClip NightBasement;

	// Token: 0x04002400 RID: 9216
	public AudioClip NightRoom;

	// Token: 0x04002401 RID: 9217
	public AudioClip HomeLoveSick;

	// Token: 0x04002402 RID: 9218
	public bool RestoreBloom;

	// Token: 0x04002403 RID: 9219
	public bool RestoreDOF;

	// Token: 0x04002404 RID: 9220
	public bool Torturing;

	// Token: 0x04002405 RID: 9221
	public bool Eighties;

	// Token: 0x04002406 RID: 9222
	public CosmeticScript SenpaiCosmetic;

	// Token: 0x04002407 RID: 9223
	public Renderer HairLock;

	// Token: 0x04002408 RID: 9224
	public AudioClip OpenDrawer;

	// Token: 0x04002409 RID: 9225
	public Transform PromptBarPanel;

	// Token: 0x0400240A RID: 9226
	public Transform PauseScreen;

	// Token: 0x0400240B RID: 9227
	public GameObject CassetteTapes;

	// Token: 0x0400240C RID: 9228
	public UILabel[] HUDLabels;

	// Token: 0x0400240D RID: 9229
	public AudioClip DayRoom80s;

	// Token: 0x0400240E RID: 9230
	public AudioClip DayBasement80s;

	// Token: 0x0400240F RID: 9231
	public AudioClip NightRoom80s;

	// Token: 0x04002410 RID: 9232
	public AudioClip NightBasement80s;

	// Token: 0x04002411 RID: 9233
	public GameObject EightiesController;

	// Token: 0x04002412 RID: 9234
	public GameObject ModernDayRoom;

	// Token: 0x04002413 RID: 9235
	public GameObject EightiesRoom;

	// Token: 0x04002414 RID: 9236
	public GameObject EightiesLabelPanel;

	// Token: 0x04002415 RID: 9237
	public GameObject LabelPanel;

	// Token: 0x04002416 RID: 9238
	public GameObject MonitorLight;

	// Token: 0x04002417 RID: 9239
	public Font VCR;
}
