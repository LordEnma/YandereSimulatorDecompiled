// Decompiled with JetBrains decompiler
// Type: SundayRivalCutsceneScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class SundayRivalCutsceneScript : MonoBehaviour
{
  public HomeSenpaiShrineScript HomeSenpaiShrine;
  public HomeDarknessScript HomeDarkness;
  public HomeYandereScript HomeYandere;
  public PhoneScript Phone;
  public GameObject InfoTextConvo;
  public GameObject InfoTextPanel;
  public AudioClip YoureSafeNow;
  public AudioSource Vibration;
  public GameObject GrabbyHand;
  public GameObject HomeClock;
  public UISprite SkipCircle;
  public UIPanel SkipPanel;
  public float Alpha = 1f;
  public float Speed;
  public float Timer;
  public float X;
  public float Y;
  public float Z;
  public int Phase;
  public bool RestoreDOF;

  private void Start()
  {
    if (!GameGlobals.Eighties && DateGlobals.Weekday == DayOfWeek.Sunday)
    {
      this.HomeSenpaiShrine.Start();
      this.HomeYandere.HomeDarkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
      this.HomeDarkness.enabled = false;
      this.Alpha = 1f;
      this.InfoTextConvo.gameObject.SetActive(true);
      this.Vibration.gameObject.SetActive(true);
      this.HomeYandere.Start();
      this.HomeYandere.HomeCamera.Start();
      this.HomeClock.SetActive(false);
      this.HomeYandere.enabled = false;
      this.HomeYandere.HomeCamera.enabled = false;
      this.HomeYandere.HomeCamera.RoomJukebox.enabled = false;
      this.HomeYandere.HomeCamera.HomeSenpaiShrine.enabled = false;
      UnityEngine.Object.Destroy((UnityEngine.Object) this.HomeYandere.HomeCamera.PauseScreen.gameObject);
      this.HomeYandere.HomeCamera.HomeSenpaiShrine.RightDoor.localEulerAngles = new Vector3(this.HomeYandere.HomeCamera.HomeSenpaiShrine.RightDoor.localEulerAngles.x, 135f, this.HomeYandere.HomeCamera.HomeSenpaiShrine.RightDoor.localEulerAngles.z);
      this.HomeYandere.HomeCamera.HomeSenpaiShrine.LeftDoor.localEulerAngles = new Vector3(this.HomeYandere.HomeCamera.HomeSenpaiShrine.LeftDoor.localEulerAngles.x, -135f, this.HomeYandere.HomeCamera.HomeSenpaiShrine.LeftDoor.localEulerAngles.z);
      this.HomeYandere.transform.position = new Vector3(-1.655f, 0.0f, 1.93f);
      this.HomeYandere.transform.eulerAngles = new Vector3(0.0f, -45f, 0.0f);
      this.HomeYandere.HomeCamera.transform.position = new Vector3(-1.905f, 1.48f, 2.15f);
      this.HomeYandere.HomeCamera.transform.eulerAngles = new Vector3(0.0f, -22.5f, 0.0f);
      if (this.HomeYandere.HomeCamera.Profile.depthOfField.enabled)
        this.RestoreDOF = true;
      this.HomeYandere.HomeCamera.Profile.depthOfField.enabled = false;
    }
    else
      this.gameObject.SetActive(false);
  }

  private void Update()
  {
    if (Input.GetKeyDown("="))
      ++Time.timeScale;
    if (this.SkipCircle.transform.parent.gameObject.activeInHierarchy)
    {
      if (Input.GetButton("X"))
      {
        this.SkipCircle.fillAmount -= Time.deltaTime;
        if ((double) this.SkipCircle.fillAmount == 0.0)
        {
          this.HomeYandere.HomeDarkness.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
          this.SkipCircle.transform.parent.gameObject.SetActive(false);
          this.Phase = 5;
          this.Timer = 0.0f;
        }
      }
      else
        this.SkipCircle.fillAmount = 1f;
    }
    if (this.Phase < 4)
      this.HomeYandere.HomeCamera.transform.Translate(Vector3.forward * Time.deltaTime * -0.01f, Space.Self);
    if (this.Phase == 0)
    {
      this.Alpha = Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime * 0.25f);
      this.HomeYandere.HomeDarkness.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
      if ((double) this.Alpha != 0.0)
        return;
      ++this.Phase;
    }
    else if (this.Phase == 1)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer <= 1.0)
        return;
      this.HomeYandere.Character.GetComponent<Animation>().Play("f02_caressPhoto_00");
      this.Timer = 0.0f;
      ++this.Phase;
    }
    else if (this.Phase == 2)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer <= 2.5)
        return;
      this.Vibration.PlayOneShot(this.YoureSafeNow);
      this.Timer = 0.0f;
      ++this.Phase;
    }
    else if (this.Phase == 3)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 3.0 && !this.Vibration.isPlaying)
        this.Vibration.Play();
      if ((double) this.Timer <= 4.0)
        return;
      this.X = 0.0f;
      this.Y = -22.5f;
      this.Z = 0.0f;
      this.Timer = 0.0f;
      ++this.Phase;
    }
    else if (this.Phase == 4)
    {
      this.Timer += Time.deltaTime;
      this.Speed += Time.deltaTime;
      this.HomeYandere.HomeCamera.transform.position = Vector3.Lerp(this.HomeYandere.HomeCamera.transform.position, new Vector3(-2.055f, 1.075f, 1.99f), Time.deltaTime * this.Speed);
      this.X = Mathf.Lerp(this.X, 67.5f, Time.deltaTime * this.Speed);
      this.Y = Mathf.Lerp(this.Y, -22.5f, Time.deltaTime * this.Speed);
      this.Z = Mathf.Lerp(this.Z, 0.0f, Time.deltaTime * this.Speed);
      this.HomeYandere.HomeCamera.transform.eulerAngles = new Vector3(this.X, this.Y, this.Z);
      if ((double) this.Timer > 2.0)
        this.HomeYandere.gameObject.SetActive(false);
      if ((double) this.Timer > 2.5)
        this.GrabbyHand.SetActive(true);
      if ((double) this.Timer <= 4.5)
        return;
      this.HomeYandere.HomeCamera.transform.position = new Vector3(-1.638197f, 1.4925f, 2f);
      this.HomeYandere.HomeCamera.transform.eulerAngles = new Vector3(0.0f, -45f, 0.0f);
      this.HomeYandere.gameObject.SetActive(false);
      this.GrabbyHand.SetActive(false);
      this.InfoTextConvo.SetActive(true);
      this.Timer = 0.0f;
      ++this.Phase;
    }
    else
    {
      if (this.Phase != 5)
        return;
      this.Timer += Time.deltaTime;
      this.InfoTextPanel.transform.localPosition = Vector3.Lerp(this.InfoTextPanel.transform.localPosition, new Vector3(0.0f, 0.0f, 1f), Time.deltaTime * 10f);
      if ((double) this.Timer <= 1.0)
        return;
      this.SkipPanel.alpha = 0.0f;
      if (this.RestoreDOF)
        this.HomeYandere.HomeCamera.Profile.depthOfField.enabled = true;
      this.Phone.enabled = true;
      Time.timeScale = 1f;
      ++this.Phase;
    }
  }
}
