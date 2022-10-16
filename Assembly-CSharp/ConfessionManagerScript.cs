// Decompiled with JetBrains decompiler
// Type: ConfessionManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ConfessionManagerScript : MonoBehaviour
{
  public ShoulderCameraScript ShoulderCamera;
  public StudentManagerScript StudentManager;
  public HeartbrokenScript Heartbroken;
  public JukeboxScript OriginalJukebox;
  public CosmeticScript OsanaCosmetic;
  public AudioClip ConfessionAccepted;
  public AudioClip ConfessionRejected;
  public AudioClip ConfessionGiggle;
  public AudioClip[] ConfessionMusic;
  public GameObject OriginalBlossoms;
  public GameObject HeartBeatCamera;
  public GameObject MainCamera;
  public Transform ConfessionCamera;
  public Transform OriginalPOV;
  public Transform ReactionPOV;
  public Transform SenpaiNeck;
  public Transform SenpaiPOV;
  public string[] ConfessSubs;
  public string[] AcceptSubs;
  public string[] RejectSubs;
  public float[] ConfessTimes;
  public float[] AcceptTimes;
  public float[] RejectTimes;
  public UISprite TimelessDarkness;
  public UISprite ContinueButton;
  public UILabel ContinueLabel;
  public UILabel SubtitleLabel;
  public UISprite Darkness;
  public UIPanel Panel;
  public AudioSource MyAudio;
  public AudioSource Jukebox;
  public Animation Yandere;
  public Animation Senpai;
  public Animation Osana;
  public Renderer Tears;
  public float RotateSpeed;
  public float TearSpeed;
  public float TearTimer;
  public float Timer;
  public bool CheatRejection;
  public bool ReverseTears;
  public bool Eighties;
  public bool Skipping;
  public bool FadeOut;
  public bool Reject;
  public int TearPhase;
  public int Phase;
  public int MusicID;
  public int SubID;

  private void Start()
  {
    this.StudentManager.Yandere.Class.Portal.EndEvents();
    this.StudentManager.Students[this.StudentManager.RivalID].BookBag.SetActive(false);
    this.Senpai["SenpaiConfession"].speed = 0.9f;
    this.TimelessDarkness.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
    this.SubtitleLabel.text = "";
    this.Eighties = this.StudentManager.Eighties;
    this.ContinueButton.alpha = 0.0f;
    if (this.Eighties)
    {
      this.ConfessionMusic[1] = this.ConfessionMusic[5];
      this.ConfessionMusic[2] = this.ConfessionMusic[5];
      this.ConfessionMusic[3] = this.ConfessionMusic[5];
      this.ConfessionMusic[4] = this.ConfessionMusic[5];
      this.Jukebox.clip = this.ConfessionMusic[5];
      this.ContinueLabel.text = "CONTINUE";
      this.StudentManager.EightiesifyLabel(this.ContinueLabel);
      this.ContinueButton.transform.localPosition = new Vector3(680f, 370f, 0.0f);
      this.ContinueButton.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
      this.ContinueLabel.transform.localPosition = new Vector3(-30f, 2.5f, 0.0f);
    }
    Time.timeScale = 1f;
  }

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if (this.Phase == -1)
    {
      this.TimelessDarkness.color = new Color(this.TimelessDarkness.color.r, this.TimelessDarkness.color.g, this.TimelessDarkness.color.b, Mathf.MoveTowards(this.TimelessDarkness.color.a, 1f, Time.deltaTime));
      this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 0.0f, Time.deltaTime);
      this.OriginalJukebox.Volume = Mathf.MoveTowards(this.OriginalJukebox.Volume, 0.0f, Time.deltaTime);
      if ((double) this.TimelessDarkness.color.a == 1.0 && (double) this.Timer > 2.0)
      {
        this.TimelessDarkness.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.ConfessionCamera.gameObject.SetActive(true);
        this.MainCamera.SetActive(false);
        this.OsanaCosmetic = this.StudentManager.Students[this.StudentManager.RivalID].Cosmetic;
        this.Osana = this.StudentManager.Students[this.StudentManager.RivalID].CharacterAnimation;
        this.Tears = this.StudentManager.Students[this.StudentManager.RivalID].Tears;
        this.Senpai = this.StudentManager.Students[1].CharacterAnimation;
        this.SenpaiNeck = this.StudentManager.Students[1].Neck;
        this.Osana[this.OsanaCosmetic.Student.ShyAnim].weight = 0.0f;
        this.Senpai["SenpaiConfession"].speed = 0.9f;
        this.OriginalBlossoms.SetActive(false);
        this.Tears.gameObject.SetActive(true);
        this.Osana.transform.position = new Vector3(0.0f, 6.6f, 119.5f);
        this.Senpai.transform.position = new Vector3(0.0f, 6.6f, 119.5f);
        this.Osana.transform.eulerAngles = new Vector3(0.0f, 180f, 0.0f);
        this.Senpai.transform.eulerAngles = new Vector3(0.0f, 180f, 0.0f);
        this.OsanaCosmetic.MyRenderer.materials[this.OsanaCosmetic.FaceID].SetFloat("_BlendAmount", 1f);
        this.OsanaCosmetic.MyRenderer.materials[this.OsanaCosmetic.SkinID].SetFloat("_BlendAmount", 0.0f);
        this.OsanaCosmetic.MyRenderer.materials[this.OsanaCosmetic.UniformID].SetFloat("_BlendAmount", 0.0f);
        Debug.Log((object) "The characters were told to perform their confession animations.");
        this.Senpai.Play("SenpaiConfession");
        this.Osana.Play("OsanaConfession");
        this.OriginalBlossoms.SetActive(false);
        this.HeartBeatCamera.SetActive(false);
        if (!this.Eighties)
          this.MyAudio.Play();
        this.Jukebox.Play();
        this.Timer = 0.0f;
        ++this.Phase;
        this.Yandere.transform.parent.position = new Vector3(5f, 5.73f, 119f);
        this.Yandere.transform.parent.eulerAngles = new Vector3(0.0f, -90f, 0.0f);
      }
    }
    else if (this.Phase == 0)
    {
      if ((double) this.Darkness.color.a == 0.0)
      {
        this.ContinueButton.alpha = Mathf.MoveTowards(this.ContinueButton.alpha, 1f, Time.deltaTime);
        if ((double) this.ContinueButton.alpha == 1.0 && Input.GetButtonDown("A"))
          this.Timer = 11f;
      }
      if ((double) this.Timer > 11.0)
      {
        if (!this.CheatRejection)
        {
          this.ContinueButton.alpha = 0.0f;
          this.FadeOut = true;
          this.Timer = 0.0f;
          ++this.Phase;
        }
        else if ((double) this.Osana["OsanaConfessionRejected"].time < 45.0)
        {
          this.Senpai.CrossFade("SenpaiConfessionRejected", 1f);
          this.Osana["OsanaConfessionRejected"].time = 45f;
          this.Osana.CrossFade("OsanaConfessionRejected", 1f);
        }
      }
      else
      {
        this.StudentManager.Students[this.StudentManager.RivalID].MyRenderer.enabled = true;
        this.StudentManager.Students[1].MyRenderer.enabled = true;
      }
    }
    else if (this.Phase == 1)
    {
      if ((double) this.Timer > 2.0)
      {
        this.ConfessionCamera.eulerAngles = this.SenpaiPOV.eulerAngles;
        this.ConfessionCamera.position = this.SenpaiPOV.position;
        this.Senpai.gameObject.SetActive(false);
        this.Osana["OsanaConfession"].time = 11f;
        this.MyAudio.volume = 1f;
        this.MyAudio.time = 8f;
        this.FadeOut = false;
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 2)
    {
      if (this.SubID < this.ConfessTimes.Length && (double) this.Osana["OsanaConfession"].time > (double) this.ConfessTimes[this.SubID] + 3.0)
      {
        if (!this.Eighties)
        {
          this.SubtitleLabel.text = this.ConfessSubs[this.SubID] ?? "";
        }
        else
        {
          this.SubtitleLabel.text = "(Your rival confesses her feelings to Senpai...)";
          if (this.SubID > 0)
            this.ContinueButton.alpha = 1f;
        }
        ++this.SubID;
      }
      this.RotateSpeed += Time.deltaTime * 0.2f;
      this.ConfessionCamera.eulerAngles = Vector3.Lerp(this.ConfessionCamera.eulerAngles, new Vector3(0.0f, 0.0f, 0.0f), Time.deltaTime * this.RotateSpeed);
      this.ConfessionCamera.position = Vector3.Lerp(this.ConfessionCamera.position, new Vector3(0.0f, 7.85f, 118f), Time.deltaTime * this.RotateSpeed);
      if ((double) this.Darkness.color.a == 0.0)
      {
        this.ContinueButton.alpha = Mathf.MoveTowards(this.ContinueButton.alpha, 1f, Time.deltaTime);
        if ((double) this.ContinueButton.alpha == 1.0 && Input.GetButtonDown("A"))
        {
          this.ConfessionCamera.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
          this.ConfessionCamera.position = new Vector3(0.0f, 7.85f, 118f);
          this.Osana["OsanaConfession"].time = this.Osana["OsanaConfession"].length;
          this.ContinueButton.alpha = 0.0f;
        }
      }
      if ((double) this.Osana["OsanaConfession"].time >= (double) this.Osana["OsanaConfession"].length)
      {
        this.ContinueButton.alpha = 0.0f;
        if (this.StudentManager.SabotageProgress > 4)
          this.Reject = true;
        if (!this.Reject)
        {
          this.Osana.CrossFade("OsanaConfessionAccepted");
          this.MyAudio.clip = this.ConfessionAccepted;
        }
        else
        {
          this.Osana.CrossFade("OsanaConfessionRejected");
          this.MyAudio.clip = this.ConfessionRejected;
        }
        this.MyAudio.time = 0.0f;
        this.MyAudio.Play();
        this.Jukebox.Stop();
        if (this.Eighties)
          this.MyAudio.volume = 0.0f;
        this.SubtitleLabel.text = "";
        this.RotateSpeed = 0.0f;
        this.SubID = 0;
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 3)
    {
      if (!this.Reject)
      {
        if (this.SubID < this.AcceptTimes.Length && (double) this.Osana["OsanaConfessionAccepted"].time > (double) this.AcceptTimes[this.SubID])
        {
          this.SubtitleLabel.text = this.Eighties ? "Senpai accepts your rival's confession..." : this.AcceptSubs[this.SubID] ?? "";
          ++this.SubID;
        }
        if (this.TearPhase == 0)
        {
          if ((double) this.Timer > 26.0)
          {
            this.ReverseTears = true;
            this.TearSpeed = 5f;
            ++this.TearPhase;
          }
        }
        else if (this.TearPhase == 1)
        {
          if ((double) this.Timer > 33.33333)
          {
            this.ReverseTears = true;
            this.TearSpeed = 5f;
            ++this.TearPhase;
          }
        }
        else if (this.TearPhase == 2)
        {
          if ((double) this.Timer > 39.0)
          {
            this.ReverseTears = true;
            this.TearSpeed = 5f;
            ++this.TearPhase;
          }
        }
        else if (this.TearPhase == 3 && (double) this.Timer > 40.0)
          ++this.TearPhase;
        if ((double) this.Timer > 10.0)
        {
          if (!this.Jukebox.isPlaying)
          {
            this.Jukebox.clip = this.ConfessionMusic[4];
            this.Jukebox.loop = true;
            this.Jukebox.volume = 0.0f;
            this.Jukebox.Play();
          }
          this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0.05f, Time.deltaTime * 0.01f);
          if (!this.ReverseTears)
          {
            this.TearTimer = Mathf.MoveTowards(this.TearTimer, 1f, Time.deltaTime * this.TearSpeed);
          }
          else
          {
            this.TearTimer = Mathf.MoveTowards(this.TearTimer, 0.0f, Time.deltaTime * this.TearSpeed);
            if ((double) this.TearTimer == 0.0)
            {
              this.ReverseTears = false;
              this.TearSpeed = 0.2f;
            }
          }
          if (this.TearPhase < 4)
            this.Tears.materials[0].SetFloat("_TearReveal", this.TearTimer);
          this.Tears.materials[1].SetFloat("_TearReveal", this.TearTimer);
        }
        if ((double) this.Darkness.color.a == 0.0)
        {
          if (this.SubID > 0)
            this.ContinueButton.alpha = Mathf.MoveTowards(this.ContinueButton.alpha, 1f, Time.deltaTime);
          if ((double) this.ContinueButton.alpha == 1.0 && Input.GetButtonDown("A"))
          {
            Debug.Log((object) "Skippin'.");
            this.MyAudio.enabled = false;
            this.MyAudio.volume = 0.0f;
            this.MyAudio.Stop();
            this.Skipping = true;
            this.Timer = 43f;
          }
        }
        if ((double) this.Timer >= 43.0)
        {
          this.ContinueButton.alpha = 0.0f;
          this.TearSpeed = 0.1f;
          this.FadeOut = true;
          this.Timer = 0.0f;
          ++this.Phase;
        }
      }
      else
      {
        if (this.SubID < this.RejectTimes.Length && (double) this.Osana["OsanaConfessionRejected"].time > (double) this.RejectTimes[this.SubID])
        {
          this.SubtitleLabel.text = this.Eighties ? "(Senpai rejects your rival's confession!)" : this.RejectSubs[this.SubID] ?? "";
          ++this.SubID;
        }
        if (this.Eighties && (double) this.Timer < 41.0)
        {
          this.Osana["OsanaConfessionRejected"].time = 41f;
          this.Timer = 41f;
        }
        if ((double) this.Timer > 41.0)
        {
          this.TearTimer = Mathf.MoveTowards(this.TearTimer, 1f, Time.deltaTime * this.TearSpeed);
          this.Tears.materials[0].SetFloat("_TearReveal", this.TearTimer);
          this.Tears.materials[1].SetFloat("_TearReveal", this.TearTimer);
        }
        if ((double) this.Timer > 47.0)
        {
          this.RotateSpeed += Time.deltaTime * 0.01f;
          this.ConfessionCamera.eulerAngles = new Vector3(this.ConfessionCamera.eulerAngles.x, this.ConfessionCamera.eulerAngles.y - this.RotateSpeed * 2f, this.ConfessionCamera.eulerAngles.z);
          this.ConfessionCamera.position = new Vector3(this.ConfessionCamera.position.x, this.ConfessionCamera.position.y, this.ConfessionCamera.position.z - this.RotateSpeed * 0.05f);
        }
        if ((double) this.Darkness.color.a == 0.0)
        {
          if (this.SubID > 0)
            this.ContinueButton.alpha = Mathf.MoveTowards(this.ContinueButton.alpha, 1f, Time.deltaTime);
          if ((double) this.ContinueButton.alpha == 1.0 && Input.GetButtonDown("A"))
          {
            Debug.Log((object) "Skippin'.");
            this.MyAudio.enabled = false;
            this.MyAudio.volume = 0.0f;
            this.MyAudio.Stop();
            this.Skipping = true;
            this.Timer = 51f;
          }
        }
        if ((double) this.Timer > 51.0)
        {
          this.ContinueButton.alpha = 0.0f;
          this.FadeOut = true;
          this.Timer = 0.0f;
          ++this.Phase;
        }
      }
    }
    else if (this.Phase == 4)
    {
      if (this.Reject)
      {
        this.RotateSpeed += Time.deltaTime * 0.01f;
        this.ConfessionCamera.eulerAngles = new Vector3(this.ConfessionCamera.eulerAngles.x, this.ConfessionCamera.eulerAngles.y - this.RotateSpeed * 2f, this.ConfessionCamera.eulerAngles.z);
        this.ConfessionCamera.position = new Vector3(this.ConfessionCamera.position.x, this.ConfessionCamera.position.y, this.ConfessionCamera.position.z - this.RotateSpeed * 0.05f);
      }
      if ((double) this.Timer > 2.0)
      {
        this.ConfessionCamera.eulerAngles = this.OriginalPOV.eulerAngles;
        this.ConfessionCamera.position = this.OriginalPOV.position;
        this.Senpai.gameObject.SetActive(true);
        if (!this.Reject)
        {
          this.Senpai.Play("SenpaiConfessionAccepted");
          this.Senpai["SenpaiConfessionAccepted"].time = this.Osana["OsanaConfessionAccepted"].time;
          this.Senpai.Play("SenpaiConfessionAccepted");
          this.Yandere.Play("YandereConfessionAccepted");
          this.StudentManager.Yandere.LoseGentleEyes();
        }
        else
        {
          this.Senpai.Play("SenpaiConfessionRejected");
          this.Senpai["SenpaiConfessionRejected"].time += 2f;
        }
        if (this.Skipping)
        {
          if (this.Reject)
          {
            this.Osana.Play("OsanaConfessionRejected");
            this.Osana["OsanaConfessionRejected"].time = 47f;
            this.Senpai.Play("SenpaiConfessionRejected");
            this.Senpai["SenpaiConfessionRejected"].time = 47f;
          }
          else
          {
            this.Osana.Play("OsanaConfessionAccepted");
            this.Osana["OsanaConfessionAccepted"].time = 47f;
            this.Senpai.Play("SenpaiConfessionAccepted");
            this.Senpai["SenpaiConfessionAccepted"].time = 47f;
          }
        }
        this.SubtitleLabel.text = "";
        this.FadeOut = false;
        this.RotateSpeed = 0.0f;
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 5)
    {
      if ((double) this.Timer > 5.0)
      {
        if (this.Reject)
          this.Yandere.Play("YandereConfessionRejected");
        this.Jukebox.pitch = Mathf.MoveTowards(this.Jukebox.pitch, 0.0f, Time.deltaTime * 0.1f);
        this.RotateSpeed += Time.deltaTime * 0.5f;
        this.ConfessionCamera.position = Vector3.Lerp(this.ConfessionCamera.position, new Vector3(7f, 7f, 118.5f), Time.deltaTime * this.RotateSpeed);
        if ((double) this.Timer > 10.0)
        {
          if (this.Reject)
            AudioSource.PlayClipAtPoint(this.ConfessionGiggle, this.Yandere.transform.position);
          this.ConfessionCamera.eulerAngles = this.ReactionPOV.eulerAngles;
          this.ConfessionCamera.position = this.ReactionPOV.position;
          this.RotateSpeed = 0.0f;
          this.Timer = 0.0f;
          ++this.Phase;
        }
      }
    }
    else if (this.Phase == 6)
    {
      this.Jukebox.pitch = Mathf.MoveTowards(this.Jukebox.pitch, 0.0f, Time.deltaTime * 0.1f);
      if (!this.Reject)
      {
        if (!this.Heartbroken.Confessed)
        {
          this.MainCamera.transform.eulerAngles = this.ConfessionCamera.eulerAngles;
          this.MainCamera.transform.position = this.ConfessionCamera.position;
          this.Heartbroken.Confessed = true;
          this.MainCamera.SetActive(true);
          Camera.main.enabled = true;
          this.ShoulderCamera.enabled = true;
          this.ShoulderCamera.Noticed = true;
          this.ShoulderCamera.Skip = true;
        }
        this.ConfessionCamera.position = this.MainCamera.transform.position;
      }
      else
      {
        this.RotateSpeed += Time.deltaTime * 0.5f;
        this.ConfessionCamera.position = Vector3.Lerp(this.ConfessionCamera.position, new Vector3(4f, 7f, 119f), Time.deltaTime * this.RotateSpeed);
        Debug.Log((object) ("Timer is: " + this.Timer.ToString()));
        if ((double) this.Timer > 5.0)
        {
          this.FadeOut = true;
          if ((double) this.Darkness.color.a == 1.0)
          {
            Debug.Log((object) "Confession cutscene ended. Deciding where to go next.");
            this.StudentManager.RivalEliminated = true;
            this.StudentManager.Yandere.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Rejected;
            this.MainCamera.SetActive(true);
            this.gameObject.SetActive(false);
            this.StudentManager.Clock.PresentTime = 1080f;
            this.StudentManager.Clock.StopTime = false;
            this.StudentManager.Yandere.HUD.alpha = 1f;
            this.StudentManager.Police.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
            this.StudentManager.Police.gameObject.SetActive(true);
            this.StudentManager.Police.BeginConfession = false;
            this.StudentManager.Police.enabled = true;
            if (this.StudentManager.Police.EndOfDay.Phase == 25)
            {
              this.StudentManager.Police.EndOfDay.Phase = 13;
              this.StudentManager.Police.EndOfDay.Darken = true;
              this.StudentManager.Police.EndOfDay.EndOfDayDarkness.alpha = 1f;
              this.StudentManager.Police.EndOfDay.gameObject.SetActive(true);
            }
          }
        }
      }
    }
    if (this.FadeOut)
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime * 0.5f));
    else
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime * 0.5f));
  }

  private void LateUpdate()
  {
    if (this.Phase <= 4 || !this.Reject)
      return;
    this.SenpaiNeck.eulerAngles = new Vector3(this.SenpaiNeck.eulerAngles.x + 15f, this.SenpaiNeck.eulerAngles.y, this.SenpaiNeck.eulerAngles.z);
  }
}
