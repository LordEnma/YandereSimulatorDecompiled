// Decompiled with JetBrains decompiler
// Type: StreetManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StreetManagerScript : MonoBehaviour
{
  public StreetShopInterfaceScript StreetShopInterface;
  public AudioSource CurrentlyActiveJukebox;
  public AudioSource JukeboxNight;
  public AudioSource JukeboxDay;
  public AudioSource Yakuza;
  public Transform BinocularCamera;
  public Transform Yandere;
  public Transform Hips;
  public Transform Sun;
  public Animation MaidAnimation;
  public Animation Gossip1;
  public Animation Gossip2;
  public GameObject MaidPrompt;
  public GameObject MaidLabel;
  public HomeClockScript Clock;
  public Animation[] Civilian;
  public GameObject Couple;
  public UISprite Darkness;
  public Renderer Stars;
  public Light Sunlight;
  public bool Threatened;
  public bool GoToCafe;
  public bool FadeOut;
  public bool Mute;
  public bool Day;
  public float Rotation;
  public float Timer;
  public float DesiredValue;
  public float StarAlpha;
  public float Alpha;
  public UILabel[] HUDLabels;
  public AudioClip DayStreet80s;
  public AudioClip NightStreet80s;
  public GameObject EightiesCivilians;
  public GameObject ModernCivilians;
  public GameObject KenchoShip;
  public Renderer Konbini;
  public Texture EightiesKonbini;
  public Font VCR;

  private void Start()
  {
    this.MaidAnimation["f02_faceCouncilGrace_00"].layer = 1;
    this.MaidAnimation.Play("f02_faceCouncilGrace_00");
    this.MaidAnimation["f02_faceCouncilGrace_00"].weight = 1f;
    this.Gossip1["f02_socialSit_00"].layer = 1;
    this.Gossip1.Play("f02_socialSit_00");
    this.Gossip1["f02_socialSit_00"].weight = 1f;
    this.Gossip2["f02_socialSit_00"].layer = 1;
    this.Gossip2.Play("f02_socialSit_00");
    this.Gossip2["f02_socialSit_00"].weight = 1f;
    for (int index = 1; index < 6; ++index)
    {
      this.Civilian[index]["f02_smile_00"].layer = 1;
      this.Civilian[index].Play("f02_smile_00");
      this.Civilian[index]["f02_smile_00"].weight = 1f;
    }
    this.Darkness.color = new Color(1f, 1f, 1f, 1f);
    this.CurrentlyActiveJukebox = this.JukeboxNight;
    this.Alpha = 1f;
    this.Sunlight.shadows = LightShadows.None;
    if (!HomeGlobals.Night)
    {
      this.Day = true;
      this.MaidLabel.SetActive(false);
      this.MaidPrompt.SetActive(false);
      this.Clock.HourLabel.text = "6:00 AM";
      this.Sunlight.shadows = LightShadows.Soft;
      this.Yakuza.transform.parent.gameObject.SetActive(false);
      if (DateGlobals.Weekday == DayOfWeek.Sunday)
      {
        this.MaidLabel.SetActive(true);
        this.MaidPrompt.SetActive(true);
      }
    }
    if (GameGlobals.Eighties)
    {
      this.BecomeEighties();
    }
    else
    {
      this.Yakuza.transform.parent.gameObject.SetActive(false);
      this.EightiesCivilians.SetActive(false);
      this.ModernCivilians.SetActive(true);
    }
    if (GameGlobals.YakuzaPhase <= 0)
      return;
    this.Threatened = true;
  }

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if ((double) this.Timer > 0.5)
    {
      if ((double) this.Alpha == 1.0)
      {
        this.JukeboxNight.volume = 0.5f;
        this.JukeboxNight.Play();
        this.JukeboxDay.volume = 0.0f;
        this.JukeboxDay.Play();
      }
      if (!this.FadeOut)
      {
        this.Alpha = Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime);
        this.Darkness.color = new Color(1f, 1f, 1f, this.Alpha);
      }
      else
      {
        this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime);
        if (!this.StreetShopInterface.Show && !this.Mute)
          this.CurrentlyActiveJukebox.volume = (float) ((1.0 - (double) this.Alpha) * 0.5);
        if (this.GoToCafe)
        {
          this.Darkness.color = new Color(1f, 1f, 1f, this.Alpha);
          if ((double) this.Alpha == 1.0)
            SceneManager.LoadScene("MaidMenuScene");
        }
        else
        {
          this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
          if ((double) this.Alpha == 1.0)
          {
            Debug.Log((object) "Going home, supposedly.");
            SceneManager.LoadScene("HomeScene");
          }
        }
      }
    }
    if (!this.FadeOut && !this.BinocularCamera.gameObject.activeInHierarchy)
    {
      this.DesiredValue = (double) this.Yandere.position.z <= (double) this.Yakuza.transform.position.z ? 0.0f : ((double) Vector3.Distance(this.Yandere.position, this.Yakuza.transform.position) <= 5.0 ? Vector3.Distance(this.Yandere.position, this.Yakuza.transform.position) * 0.1f : 0.5f);
      if (!this.StreetShopInterface.Show && !this.Mute)
      {
        if (this.Day)
        {
          this.JukeboxDay.volume = Mathf.Lerp(this.JukeboxDay.volume, this.DesiredValue, Time.deltaTime * 10f);
          this.JukeboxNight.volume = Mathf.Lerp(this.JukeboxNight.volume, 0.0f, Time.deltaTime * 10f);
        }
        else
        {
          this.JukeboxDay.volume = Mathf.Lerp(this.JukeboxDay.volume, 0.0f, Time.deltaTime * 10f);
          this.JukeboxNight.volume = Mathf.Lerp(this.JukeboxNight.volume, this.DesiredValue, Time.deltaTime * 10f);
        }
      }
      if ((double) Vector3.Distance(this.Yandere.position, this.Yakuza.transform.position) < 0.10000000149011612 && !this.Threatened)
      {
        this.Threatened = true;
        this.Yakuza.Play();
      }
    }
    if (Input.GetKeyDown("m"))
    {
      this.Mute = !this.Mute;
      Debug.Log((object) ("Mute is: " + this.Mute.ToString()));
      if (this.Mute)
      {
        this.JukeboxNight.volume = 0.0f;
        this.JukeboxDay.volume = 0.0f;
        if ((UnityEngine.Object) this.StreetShopInterface != (UnityEngine.Object) null)
          this.StreetShopInterface.Jukebox.volume = 0.0f;
      }
      else
        this.CurrentlyActiveJukebox.Play();
    }
    if (!this.Mute)
    {
      if (this.StreetShopInterface.Show)
      {
        this.JukeboxNight.volume = Mathf.Lerp(this.JukeboxNight.volume, 0.0f, Time.deltaTime * 10f);
        this.JukeboxDay.volume = Mathf.Lerp(this.JukeboxDay.volume, 0.0f, Time.deltaTime * 10f);
      }
      else if (this.Day)
      {
        this.CurrentlyActiveJukebox = this.JukeboxDay;
        this.Rotation = Mathf.Lerp(this.Rotation, 45f, Time.deltaTime * 10f);
        this.StarAlpha = Mathf.Lerp(this.StarAlpha, 0.0f, Time.deltaTime * 10f);
      }
      else
      {
        this.CurrentlyActiveJukebox = this.JukeboxNight;
        this.Rotation = Mathf.Lerp(this.Rotation, -45f, Time.deltaTime * 10f);
        this.StarAlpha = Mathf.Lerp(this.StarAlpha, 1f, Time.deltaTime * 10f);
      }
    }
    this.Sun.transform.eulerAngles = new Vector3(this.Rotation, this.Rotation, 0.0f);
    this.Stars.material.SetColor("_TintColor", new Color(1f, 1f, 1f, this.StarAlpha));
  }

  private void LateUpdate() => this.Hips.LookAt(this.BinocularCamera.position);

  private void BecomeEighties()
  {
    for (int index = 1; index < this.HUDLabels.Length; ++index)
      this.EightiesifyLabel(this.HUDLabels[index]);
    this.HUDLabels[1].transform.parent.localPosition -= new Vector3(25f, 25f, 0.0f);
    this.JukeboxDay.clip = this.DayStreet80s;
    this.JukeboxNight.clip = this.NightStreet80s;
    this.KenchoShip.SetActive(false);
    this.EightiesCivilians.SetActive(true);
    this.ModernCivilians.SetActive(false);
    this.Konbini.material.mainTexture = this.EightiesKonbini;
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
