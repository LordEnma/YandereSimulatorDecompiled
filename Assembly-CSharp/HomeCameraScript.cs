// Decompiled with JetBrains decompiler
// Type: HomeCameraScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
  public GameObject ComputerScreen;
  public GameObject CorkboardLabel;
  public GameObject LoveSickCamera;
  public GameObject LoadingScreen;
  public GameObject CeilingLight;
  public GameObject SenpaiLight;
  public GameObject Controller;
  public GameObject NightLight;
  public GameObject RopeGroup;
  public GameObject DayLight;
  public GameObject Tripod;
  public GameObject Victim;
  public Transform Destination;
  public Transform Butsudan;
  public Transform Target;
  public Transform Focus;
  public Transform[] EightiesDestinations;
  public Transform[] EightiesTargets;
  public Transform[] Destinations;
  public Transform[] Targets;
  public int Frame;
  public int ID;
  public AudioSource BasementJukebox;
  public AudioSource RoomJukebox;
  public AudioClip NightBasement;
  public AudioClip NightRoom;
  public AudioClip HomeLoveSick;
  public bool RestoreBloom;
  public bool RestoreDOF;
  public bool Torturing;
  public bool Eighties;
  public CosmeticScript SenpaiCosmetic;
  public Renderer HairLock;
  public AudioClip OpenDrawer;
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
    this.ResetBloom();
    this.HomeSleep.Start();
    this.Button.color = new Color(this.Button.color.r, this.Button.color.g, this.Button.color.b, 0.0f);
    this.Focus.position = this.Target.position;
    this.transform.position = this.Destination.position;
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
    if (StudentGlobals.Prisoners == 0)
    {
      this.RopeGroup.SetActive(false);
      this.Tripod.SetActive(false);
      this.Victim.SetActive(false);
      this.EightiesTriggers[10].Disable();
      this.Triggers[10].Disable();
    }
    if (GameGlobals.LoveSick)
      this.LoveSickColorSwap();
    Time.timeScale = 1f;
    this.HairLock.material.color = this.SenpaiCosmetic.ColorValue;
    if ((double) SchoolGlobals.SchoolAtmosphere > 1.0)
      SchoolGlobals.SchoolAtmosphere = 1f;
    if (this.Profile.bloom.enabled)
      this.RestoreBloom = true;
    if (this.Profile.depthOfField.enabled)
      this.RestoreDOF = true;
    this.ReduceKnee();
    this.Profile.colorGrading.enabled = false;
    if (GameGlobals.Eighties)
    {
      this.BecomeEighties();
    }
    else
    {
      this.Butsudan.localPosition = new Vector3(-0.2041f, 0.095f, 0.241f);
      this.Butsudan.localEulerAngles = new Vector3(0.0f, 135f, 0.0f);
      this.ModernDayRoom.SetActive(true);
      this.EightiesRoom.SetActive(false);
      this.EightiesLabelPanel.SetActive(false);
      this.LabelPanel.SetActive(true);
      this.EightiesTriggers[1].transform.parent.gameObject.SetActive(false);
      this.Triggers[1].transform.parent.gameObject.SetActive(true);
    }
  }

  private void LateUpdate()
  {
    if ((double) this.HomeYandere.transform.position.y > -5.0)
    {
      Transform destination = this.Destinations[0];
      destination.position = new Vector3(-this.HomeYandere.transform.position.x, destination.position.y, destination.position.z);
    }
    this.Focus.position = Vector3.Lerp(this.Focus.position, this.Target.position, Time.deltaTime * 10f);
    this.transform.position = Vector3.Lerp(this.transform.position, this.Destination.position, Time.deltaTime * 10f);
    this.transform.LookAt(this.Focus.position);
    if (this.HomeYandere.CanMove)
    {
      this.UpdateDOF(1.66666f);
      if (this.RestoreBloom)
        this.Profile.bloom.enabled = true;
      if (this.RestoreDOF)
        this.Profile.depthOfField.enabled = true;
    }
    else if (!this.HomeDarkness.FadeOut)
    {
      if (this.ID == 6)
        this.Profile.depthOfField.enabled = false;
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
        this.HomeExit.enabled = true;
      else if (this.ID == 2)
        this.HomeSleep.enabled = true;
      else if (this.ID == 3)
        this.HomeInternet.enabled = true;
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
          this.HomeYandere.transform.position = new Vector3(1f, 0.0f, 0.0f);
          this.HomeYandere.transform.eulerAngles = new Vector3(0.0f, 90f, 0.0f);
          this.Controller.transform.localPosition = new Vector3(0.1245f, 0.032f, 0.0f);
        }
        else
        {
          this.HomeYandere.transform.position = new Vector3(-2f, 0.0f, 0.0f);
          this.HomeYandere.transform.eulerAngles = new Vector3(0.0f, -90f, 0.0f);
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
        AudioSource.PlayClipAtPoint(this.OpenDrawer, this.transform.position);
      }
      else if (this.ID == 9)
        this.HomeManga.enabled = true;
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
        this.HomeAnime.enabled = true;
    }
    if ((UnityEngine.Object) this.Destination == (UnityEngine.Object) this.Destinations[0])
    {
      this.Vignette.intensity = (double) this.HomeYandere.transform.position.y > -1.0 ? Mathf.MoveTowards(this.Vignette.intensity, 1f, Time.deltaTime) : Mathf.MoveTowards(this.Vignette.intensity, 5f, Time.deltaTime * 5f);
      this.Vignette.chromaticAberration = Mathf.MoveTowards(this.Vignette.chromaticAberration, 1f, Time.deltaTime);
      this.Vignette.blur = Mathf.MoveTowards(this.Vignette.blur, 1f, Time.deltaTime);
    }
    else
    {
      this.Vignette.intensity = (double) this.HomeYandere.transform.position.y > -1.0 ? Mathf.MoveTowards(this.Vignette.intensity, 0.0f, Time.deltaTime) : Mathf.MoveTowards(this.Vignette.intensity, 0.0f, Time.deltaTime * 5f);
      this.Vignette.chromaticAberration = Mathf.MoveTowards(this.Vignette.chromaticAberration, 0.0f, Time.deltaTime);
      this.Vignette.blur = Mathf.MoveTowards(this.Vignette.blur, 0.0f, Time.deltaTime);
    }
    this.Button.color = new Color(this.Button.color.r, this.Button.color.g, this.Button.color.b, Mathf.MoveTowards(this.Button.color.a, this.ID <= 0 || !this.HomeYandere.CanMove ? 0.0f : 1f, Time.deltaTime * 10f));
    if (this.HomeDarkness.FadeOut)
    {
      this.BasementJukebox.volume = Mathf.MoveTowards(this.BasementJukebox.volume, 0.0f, Time.deltaTime);
      this.RoomJukebox.volume = Mathf.MoveTowards(this.RoomJukebox.volume, 0.0f, Time.deltaTime);
    }
    else if ((double) this.HomeYandere.transform.position.y > -1.0)
    {
      this.BasementJukebox.volume = Mathf.MoveTowards(this.BasementJukebox.volume, 0.0f, Time.deltaTime);
      this.RoomJukebox.volume = Mathf.MoveTowards(this.RoomJukebox.volume, 0.5f, Time.deltaTime);
    }
    else if (!this.Torturing)
    {
      this.BasementJukebox.volume = Mathf.MoveTowards(this.BasementJukebox.volume, 0.5f, Time.deltaTime);
      this.RoomJukebox.volume = Mathf.MoveTowards(this.RoomJukebox.volume, 0.0f, Time.deltaTime);
    }
    if (!Input.GetKeyDown(KeyCode.M))
      return;
    this.BasementJukebox.gameObject.SetActive(false);
    this.RoomJukebox.gameObject.SetActive(false);
  }

  public void PlayMusic()
  {
    if (YanvaniaGlobals.DraculaDefeated || HomeGlobals.MiyukiDefeated)
      return;
    if (!this.BasementJukebox.isPlaying)
      this.BasementJukebox.Play();
    if (this.RoomJukebox.isPlaying)
      return;
    this.RoomJukebox.Play();
  }

  private void LoveSickColorSwap()
  {
    foreach (GameObject gameObject in UnityEngine.Object.FindObjectsOfType<GameObject>())
    {
      if ((UnityEngine.Object) gameObject.transform.parent != (UnityEngine.Object) this.PauseScreen && (UnityEngine.Object) gameObject.transform.parent != (UnityEngine.Object) this.PromptBarPanel)
      {
        UISprite component1 = gameObject.GetComponent<UISprite>();
        if ((UnityEngine.Object) component1 != (UnityEngine.Object) null && component1.color != Color.black)
          component1.color = new Color(1f, 0.0f, 0.0f, component1.color.a);
        UILabel component2 = gameObject.GetComponent<UILabel>();
        if ((UnityEngine.Object) component2 != (UnityEngine.Object) null && component2.color != Color.black)
          component2.color = new Color(1f, 0.0f, 0.0f, component2.color.a);
      }
    }
    this.DayLight.GetComponent<Light>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
    this.HomeDarkness.Sprite.color = Color.black;
    this.BasementJukebox.clip = this.HomeLoveSick;
    this.RoomJukebox.clip = this.HomeLoveSick;
    this.LoveSickCamera.SetActive(true);
    this.PlayMusic();
  }

  public void UpdateDOF(float Focus)
  {
    Focus *= (float) (((double) Screen.width / 1280.0 + (double) Screen.height / 720.0) * 0.5);
    this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
    {
      focusDistance = Focus
    };
  }

  private void ReduceKnee()
  {
    BloomModel.Settings settings = this.Profile.bloom.settings;
    settings.bloom.softKnee = 0.75f;
    this.Profile.bloom.settings = settings;
  }

  private void ResetBloom()
  {
    BloomModel.Settings settings = this.Profile.bloom.settings;
    settings.bloom.intensity = 1f;
    settings.bloom.threshold = 1.1f;
    settings.bloom.softKnee = 0.75f;
    settings.bloom.radius = 4f;
    this.Profile.bloom.settings = settings;
  }

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
    for (int index = 1; index < this.HUDLabels.Length; ++index)
      this.EightiesifyLabel(this.HUDLabels[index]);
    this.HUDLabels[1].transform.parent.localPosition -= new Vector3(25f, 25f, 0.0f);
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
      this.Triggers[7].Disable();
    else if (DateGlobals.Weekday != DayOfWeek.Sunday)
    {
      this.Triggers[5].Disable();
      this.Triggers[9].Disable();
    }
    this.CeilingLight.transform.localPosition = new Vector3(-0.049f, 0.2666f, 0.007f);
    this.CeilingLight.GetComponent<Light>().intensity = 3f;
  }

  public void EightiesifyLabel(UILabel Label)
  {
    Label.trueTypeFont = this.VCR;
    Label.applyGradient = false;
    Label.color = new Color(1f, 1f, 1f, 1f);
    Label.effectStyle = UILabel.Effect.Outline8;
    Label.effectColor = new Color(0.0f, 0.0f, 0.0f, 1f);
  }
}
