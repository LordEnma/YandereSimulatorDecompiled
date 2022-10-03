// Decompiled with JetBrains decompiler
// Type: PhoneScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhoneScript : MonoBehaviour
{
  public OsanaTextMessageScript OsanaMessages;
  public GameObject[] RightMessage;
  public GameObject[] LeftMessage;
  public AudioClip[] VoiceClips;
  public AudioClip SubtleWhoosh;
  public AudioClip AppInstall;
  public GameObject NewMessage;
  public AudioSource Jukebox;
  public Transform OldMessages;
  public Transform PauseMenu;
  public Transform InfoIcon;
  public Transform Buttons;
  public Transform Panel;
  public Vignetting Vignette;
  public UITexture OsanaCover;
  public UISprite Darkness;
  public UISprite Sprite;
  public int[] Speaker;
  public string[] Text;
  public int[] Height;
  public AudioClip[] KidnapClip;
  public int[] KidnapSpeaker;
  public string[] KidnapText;
  public int[] KidnapHeight;
  public AudioClip[] BefriendClip;
  public int[] BefriendSpeaker;
  public string[] BefriendText;
  public int[] BefriendHeight;
  public AudioClip[] NonlethalClip;
  public string[] NonlethalText;
  public int[] NonlethalHeight;
  public bool ManuallyAdvance;
  public bool MeetingInfoChan;
  public bool PostElimination;
  public bool ShowPauseMenu;
  public bool FadeOut;
  public bool Auto;
  public float PauseMenuTimer;
  public float AutoLimit;
  public float AutoTimer;
  public float Timer;
  public int PauseMenuPhase;
  public int ID;

  private void Start()
  {
    Time.timeScale = 1f;
    this.Buttons.localPosition = new Vector3(this.Buttons.localPosition.x, -135f, this.Buttons.localPosition.z);
    this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
    if (DateGlobals.Week > 1 && DateGlobals.Weekday == DayOfWeek.Sunday)
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    if (EventGlobals.KidnapConversation)
    {
      this.VoiceClips = this.KidnapClip;
      this.Speaker = this.KidnapSpeaker;
      this.Text = this.KidnapText;
      this.Height = this.KidnapHeight;
      EventGlobals.BefriendConversation = true;
      EventGlobals.KidnapConversation = false;
    }
    else if (EventGlobals.BefriendConversation)
    {
      this.VoiceClips = this.BefriendClip;
      this.Speaker = this.BefriendSpeaker;
      this.Text = this.BefriendText;
      this.Height = this.BefriendHeight;
      EventGlobals.LivingRoom = true;
      EventGlobals.BefriendConversation = false;
    }
    else if (EventGlobals.OsanaConversation)
    {
      Debug.Log((object) "The game believes that, right now, we're supposed to be seeing Osana's text message conversation.");
      this.VoiceClips = this.OsanaMessages.OsanaClips;
      this.Speaker = this.OsanaMessages.OsanaSpeakers;
      this.Text = this.OsanaMessages.OsanaTexts;
      this.Height = this.OsanaMessages.OsanaHeights;
      EventGlobals.OsanaConversation = true;
      EventGlobals.LivingRoom = true;
    }
    else
      this.MeetingInfoChan = true;
    if (GameGlobals.LoveSick)
    {
      Camera.main.backgroundColor = Color.black;
      this.LoveSickColorSwap();
    }
    if (!this.PostElimination || (GameGlobals.RivalEliminationID == 3 || !GameGlobals.NonlethalElimination) && GameGlobals.RivalEliminationID != 9)
      return;
    this.VoiceClips[1] = this.NonlethalClip[1];
    this.VoiceClips[2] = this.NonlethalClip[2];
    this.VoiceClips[3] = this.NonlethalClip[3];
    this.Text[1] = this.NonlethalText[1];
    this.Text[2] = this.NonlethalText[2];
    this.Text[3] = this.NonlethalText[3];
    this.Height[1] = this.NonlethalHeight[1];
    this.Height[2] = this.NonlethalHeight[2];
    this.Height[3] = this.NonlethalHeight[3];
  }

  private void Update()
  {
    if (!this.FadeOut)
    {
      if ((double) this.Timer > 0.0 && this.Buttons.gameObject.activeInHierarchy)
      {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime));
        if ((double) this.Darkness.color.a == 0.0)
        {
          if (!this.Jukebox.isPlaying)
            this.Jukebox.Play();
          if ((UnityEngine.Object) this.NewMessage == (UnityEngine.Object) null)
            this.SpawnMessage();
        }
      }
      if (this.ShowPauseMenu)
      {
        this.PauseMenuTimer += Time.deltaTime;
        if (this.PauseMenuPhase == 0)
        {
          this.PauseMenu.localPosition = Vector3.Lerp(this.PauseMenu.localPosition, new Vector3(0.0f, -15f, 0.0f), Time.deltaTime * 10f);
          if ((double) this.PauseMenuTimer > 1.0)
          {
            this.GetComponent<AudioSource>().clip = this.AppInstall;
            this.GetComponent<AudioSource>().Play();
            ++this.PauseMenuPhase;
          }
        }
        else if (this.PauseMenuPhase == 1)
        {
          this.InfoIcon.localScale = Vector3.Lerp(this.InfoIcon.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
          if ((double) this.PauseMenuTimer > 2.0)
          {
            this.GetComponent<AudioSource>().clip = this.SubtleWhoosh;
            this.GetComponent<AudioSource>().Play();
            ++this.PauseMenuPhase;
          }
        }
        else if (this.PauseMenuPhase == 2)
        {
          this.PauseMenu.localPosition = Vector3.Lerp(this.PauseMenu.localPosition, new Vector3(-485f, -15f, 0.0f), Time.deltaTime * 10f);
          if ((double) this.PauseMenuTimer > 3.0)
          {
            this.GetComponent<AudioSource>().volume = 1f;
            this.ShowPauseMenu = false;
            this.ManuallyAdvance = true;
          }
        }
      }
      else
      {
        if ((UnityEngine.Object) this.NewMessage != (UnityEngine.Object) null)
        {
          this.Buttons.localPosition = new Vector3(this.Buttons.localPosition.x, Mathf.Lerp(this.Buttons.localPosition.y, 0.0f, Time.deltaTime * 10f), this.Buttons.localPosition.z);
          this.AutoTimer += Time.deltaTime;
          if ((UnityEngine.Object) this.OsanaCover != (UnityEngine.Object) null)
          {
            if (this.MeetingInfoChan && this.ID > 5 && this.ID < 11)
              this.OsanaCover.alpha = Mathf.MoveTowards(this.OsanaCover.alpha, 0.0f, Time.deltaTime);
            else
              this.OsanaCover.alpha = Mathf.MoveTowards(this.OsanaCover.alpha, 1f, Time.deltaTime);
          }
          if (this.Auto && (double) this.AutoTimer > (double) this.VoiceClips[this.ID].length + 1.0 || Input.GetButtonDown("A") || this.ManuallyAdvance)
          {
            this.ManuallyAdvance = false;
            if (this.MeetingInfoChan && this.ID == 16 && this.PauseMenuPhase == 0 && !this.PostElimination)
            {
              this.GetComponent<AudioSource>().clip = this.SubtleWhoosh;
              this.GetComponent<AudioSource>().volume = 0.5f;
              this.GetComponent<AudioSource>().Play();
              this.ShowPauseMenu = true;
            }
            else
            {
              this.AutoTimer = 0.0f;
              if (this.ID < this.Text.Length - 1)
              {
                ++this.ID;
                this.SpawnMessage();
              }
              else
              {
                this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                this.FadeOut = true;
                if (!this.Buttons.gameObject.activeInHierarchy)
                  this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
              }
            }
          }
        }
        if (Input.GetButtonDown("X") && (double) this.Buttons.localPosition.y > -1.0)
          this.FadeOut = true;
      }
    }
    else
    {
      this.Buttons.localPosition = new Vector3(this.Buttons.localPosition.x, Mathf.Lerp(this.Buttons.localPosition.y, -135f, Time.deltaTime * 10f), this.Buttons.localPosition.z);
      this.GetComponent<AudioSource>().volume = 1f - this.Darkness.color.a;
      this.Jukebox.volume = (float) (0.25 - (double) this.Darkness.color.a * 0.25);
      if ((double) this.Darkness.color.a >= 1.0)
      {
        if (DateGlobals.Week == 2)
        {
          GameGlobals.TransitionToPostCredits = true;
          SceneManager.LoadScene("CreditsScene");
        }
        else if (DateGlobals.Weekday == DayOfWeek.Sunday)
        {
          if (DateGlobals.PassDays < 1)
            DateGlobals.PassDays = 1;
          SceneManager.LoadScene("CalendarScene");
        }
        else if (!EventGlobals.BefriendConversation && !EventGlobals.LivingRoom)
        {
          if (DateGlobals.PassDays < 1)
            DateGlobals.PassDays = 1;
          SceneManager.LoadScene("CalendarScene");
        }
        else if (EventGlobals.LivingRoom)
          SceneManager.LoadScene("LivingRoomScene");
        else
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
    }
    this.Timer += Time.deltaTime;
  }

  private void SpawnMessage()
  {
    if ((UnityEngine.Object) this.NewMessage != (UnityEngine.Object) null)
    {
      this.NewMessage.transform.parent = this.OldMessages;
      this.OldMessages.localPosition = new Vector3(this.OldMessages.localPosition.x, this.OldMessages.localPosition.y + (float) (72.0 + (double) this.Height[this.ID] * 32.0), this.OldMessages.localPosition.z);
    }
    AudioSource component = this.GetComponent<AudioSource>();
    component.clip = this.VoiceClips[this.ID];
    component.Play();
    if (this.Speaker[this.ID] == 1)
    {
      this.NewMessage = UnityEngine.Object.Instantiate<GameObject>(this.LeftMessage[this.Height[this.ID]]);
      this.NewMessage.transform.parent = this.Panel;
      this.NewMessage.transform.localPosition = new Vector3(-225f, -375f, 0.0f);
      this.NewMessage.transform.localScale = Vector3.zero;
    }
    else
    {
      this.NewMessage = UnityEngine.Object.Instantiate<GameObject>(this.RightMessage[this.Height[this.ID]]);
      this.NewMessage.transform.parent = this.Panel;
      this.NewMessage.transform.localPosition = new Vector3(225f, -375f, 0.0f);
      this.NewMessage.transform.localScale = Vector3.zero;
      if (this.Speaker == this.KidnapSpeaker && this.Height[this.ID] == 8)
        this.NewMessage.GetComponent<TextMessageScript>().Attachment = true;
    }
    if (this.Height[this.ID] == 9 && this.Speaker[this.ID] == 2)
    {
      this.Buttons.gameObject.SetActive(false);
      this.Darkness.enabled = true;
      this.Jukebox.Stop();
      this.Timer = -99999f;
    }
    this.AutoLimit = (float) (this.Height[this.ID] + 1);
    this.NewMessage.GetComponent<TextMessageScript>().Label.text = this.Text[this.ID];
  }

  private void LoveSickColorSwap()
  {
    foreach (GameObject gameObject in UnityEngine.Object.FindObjectsOfType<GameObject>())
    {
      UISprite component1 = gameObject.GetComponent<UISprite>();
      if ((UnityEngine.Object) component1 != (UnityEngine.Object) null && component1.color != Color.black && (bool) (UnityEngine.Object) component1.transform.parent)
        component1.color = new Color(1f, 0.0f, 0.0f, component1.color.a);
      UILabel component2 = gameObject.GetComponent<UILabel>();
      if ((UnityEngine.Object) component2 != (UnityEngine.Object) null && component2.color != Color.black)
        component2.color = new Color(1f, 0.0f, 0.0f, component2.color.a);
      this.Darkness.color = Color.black;
    }
  }
}
