// Decompiled with JetBrains decompiler
// Type: EightiesEndCutsceneScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class EightiesEndCutsceneScript : MonoBehaviour
{
  public UISprite SkipCircle;
  public UIPanel SkipPanel;
  public AudioSource Jukebox;
  public AudioSource MyAudio;
  public ClockScript Clock;
  public UISprite Darkness;
  public Camera MainCamera;
  public UILabel Subtitle;
  public GameObject Cops;
  public AudioClip[] Clip;
  public string[] Text;
  public float SkipTimer;
  public float Rotation;
  public float Speed;
  public float Timer;
  public int Phase;
  public int Disappearances;
  public int Deaths;
  public bool Debugging;
  public bool SkipLine6;
  public bool FadeOut;
  public bool WarmUp;
  public AudioClip DeadClip;
  public AudioClip AllDeadClip;
  public AudioClip MissingClip;
  public AudioClip AllMissingClip;
  public AudioClip SomeMissingClip;
  public AudioClip DeadOrMissingClip;
  public AudioClip AllDeadOrMissingClip;
  public AudioClip SomeDeadOrMissingClip;
  public AudioClip PacifistClip;

  private void Start()
  {
    this.MainCamera.transform.localPosition = new Vector3(0.0f, 1.482f, -10f);
    this.MainCamera.clearFlags = CameraClearFlags.Color;
    this.MainCamera.backgroundColor = new Color(1f, 1f, 1f, 1f);
    this.MainCamera.farClipPlane = 150f;
    this.Clock.BloomFadeSpeed = 5f;
    this.Clock.StopTime = true;
    this.Clock.BloomWait = 1f;
    this.SkipPanel.alpha = 0.0f;
    this.Subtitle.text = "";
    for (int elimID = 1; elimID < 11; ++elimID)
    {
      if (GameGlobals.GetRivalEliminations(elimID) == 1 || GameGlobals.GetRivalEliminations(elimID) == 2)
      {
        Debug.Log((object) ("Rival #" + elimID.ToString() + " was killed."));
        ++this.Deaths;
      }
      else
        Debug.Log((object) ("Apparently, Rival #" + elimID.ToString() + " does not appear to have been killed."));
      if (GameGlobals.GetRivalEliminations(elimID) == 11)
        ++this.Disappearances;
    }
    if (this.Deaths == 10)
    {
      this.Text[6] = "...and your connection to at least one other person's death.";
      this.Text[12] = "...and every single one of those girls is dead now!";
      this.Clip[6] = this.DeadClip;
      this.Clip[12] = this.AllDeadClip;
    }
    else if (this.Disappearances == 10)
    {
      this.Text[6] = "...and your connection to at least one other person's disappearance.";
      this.Text[12] = "...and every single one of those girls has gone missing!";
      this.Clip[6] = this.MissingClip;
      this.Clip[12] = this.AllMissingClip;
    }
    else if (this.Deaths + this.Disappearances == 10)
    {
      this.Text[6] = "...and your connection to several other deaths and disappearances over the past 10 weeks.";
      this.Text[12] = "...and every single one of those girls is dead or missing!";
      this.Clip[6] = this.DeadOrMissingClip;
      this.Clip[12] = this.AllDeadOrMissingClip;
    }
    else if (this.Deaths > 0)
    {
      this.Text[6] = "...and your connection to at least one other person's death.";
      this.Text[12] = "Some of those girls are dead now! And the others? They're conveniently...out of the picture.";
      this.Clip[6] = this.DeadClip;
      this.Clip[12] = this.SomeDeadOrMissingClip;
    }
    else if (this.Disappearances > 0)
    {
      this.Text[6] = "...and your connection to at least one other person's disappearance.";
      this.Text[12] = "And some of those girls have gone missing. Tch...how convenient for you.";
      this.Clip[6] = this.MissingClip;
      this.Clip[12] = this.SomeMissingClip;
    }
    else if (this.Deaths + this.Disappearances == 0)
    {
      this.SkipLine6 = true;
      this.Text[12] = "...and from what I've heard, you've been doing everything in your power to keep girls away from him.";
      this.Clip[6] = this.Clip[0];
      this.Clip[12] = this.PacifistClip;
    }
    if ((double) SchoolGlobals.SchoolAtmosphere >= 0.5)
      return;
    this.Darkness.color = new Color(1f, 1f, 1f, 1f);
  }

  private void Update()
  {
    if (this.WarmUp)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer <= 1.0)
        return;
      this.MyAudio.Play();
      this.Jukebox.Play();
      this.WarmUp = false;
      this.Timer = 0.0f;
    }
    else
    {
      this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0.1f, Time.deltaTime);
      if (!this.MyAudio.isPlaying || this.Debugging && Input.GetButtonDown("A") && this.Phase < 16)
      {
        this.Timer = 1.1f;
        if ((double) this.Timer > 1.0)
        {
          this.Timer = 0.0f;
          ++this.Phase;
          if (this.Phase == 6 && this.SkipLine6)
            ++this.Phase;
          if (this.Phase < this.Text.Length)
          {
            this.Subtitle.text = this.Text[this.Phase];
            this.MyAudio.clip = this.Clip[this.Phase];
            this.MyAudio.Play();
            if (this.Phase == 2 || this.Phase == 3)
            {
              if (this.Phase == 3)
                this.MainCamera.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
              this.MainCamera.transform.localPosition = new Vector3(0.0f, 1.482f, 0.0f);
              this.Cops.SetActive(true);
              this.Speed = 0.0f;
            }
            else if (this.Phase == 16)
            {
              this.FadeOut = true;
              this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            }
          }
          else if ((double) this.Darkness.alpha == 1.0)
            SceneManager.LoadScene("CourtroomScene");
        }
      }
      if (this.Phase < 2)
      {
        this.Speed += Time.deltaTime * 0.05f;
        this.MainCamera.transform.localPosition = Vector3.Lerp(this.MainCamera.transform.localPosition, new Vector3(0.0f, 1.482f, 0.0f), Time.deltaTime * this.Speed);
        this.Rotation = Mathf.Lerp(this.Rotation, -15f, Time.deltaTime * this.Speed);
        this.MainCamera.transform.localEulerAngles = new Vector3(this.Rotation, 0.0f, 0.0f);
      }
      else if (this.Phase == 2)
      {
        this.Speed += Time.deltaTime * 3f;
        this.Rotation = Mathf.Lerp(this.Rotation, 0.0f, Time.deltaTime * this.Speed);
        this.MainCamera.transform.localEulerAngles = new Vector3(this.Rotation, 0.0f, 0.0f);
      }
      else if (this.Phase > 2 && this.Phase < this.Text.Length)
      {
        this.Speed += Time.deltaTime;
        this.Rotation = Mathf.Lerp(this.Rotation, -180f, Time.deltaTime * this.Speed);
        this.MainCamera.transform.localEulerAngles = new Vector3(0.0f, this.Rotation, 0.0f);
      }
      int phase = this.Phase;
      if (this.FadeOut)
      {
        this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 1f, Time.deltaTime * 0.33333f);
        this.SkipPanel.alpha = Mathf.MoveTowards(this.SkipPanel.alpha, 0.0f, Time.deltaTime * 0.33333f);
        this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0.0f, Time.deltaTime * 2f);
      }
      else
      {
        this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0.0f, Time.deltaTime * 0.33333f);
        if (!this.WarmUp)
        {
          this.SkipTimer += Time.deltaTime;
          if ((double) this.SkipTimer > 2.0)
            this.SkipPanel.alpha = Mathf.MoveTowards(this.SkipPanel.alpha, 1f, Time.deltaTime * 0.33333f);
        }
        if ((double) this.SkipPanel.alpha != 1.0)
          return;
        if (Input.GetButton("X"))
        {
          this.SkipCircle.fillAmount -= Time.deltaTime;
          if ((double) this.SkipCircle.fillAmount != 0.0)
            return;
          this.MyAudio.Stop();
          this.FadeOut = true;
          this.Phase = this.Text.Length;
          this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }
        else
          this.SkipCircle.fillAmount = 1f;
      }
    }
  }
}
