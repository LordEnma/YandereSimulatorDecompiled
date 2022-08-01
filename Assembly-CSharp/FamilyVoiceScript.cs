// Decompiled with JetBrains decompiler
// Type: FamilyVoiceScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FamilyVoiceScript : MonoBehaviour
{
  public StalkerPromptScript BreakerDoor;
  public StalkerYandereScript Yandere;
  public DetectionMarkerScript Marker;
  public AudioClip GameOverSound;
  public AudioClip GameOverLine;
  public AudioClip CrunchSound;
  public GameObject Heartbroken;
  public GameObject Lights;
  public Animation MyAnimation;
  public Transform YandereHead;
  public Transform Door;
  public Transform Head;
  public AudioSource Jukebox;
  public AudioSource MyAudio;
  public Renderer Darkness;
  public UILabel Subtitle;
  public AudioClip[] SpeechClip;
  public AudioClip DoorOpen;
  public AudioClip PowerOn;
  public Transform[] Boundary;
  public Transform[] Node;
  public string[] SpeechText;
  public float[] SpeechTime;
  public string GameOverText;
  public float MinimumDistance;
  public float NoticeSpeed;
  public float Distance;
  public float FixTimer;
  public float Alpha;
  public float Scale;
  public float Timer;
  public float TargetRotation;
  public float Rotation;
  public int GameOverPhase;
  public int CurrentNode;
  public int SpeechPhase;
  public int AnimPhase;
  public bool Investigating;
  public bool OpenFrontDoor;
  public bool MultiClip;
  public bool GameOver;
  public bool Started;
  public bool Return;

  private void Start() => this.Subtitle.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);

  private void Update()
  {
    if (!this.GameOver)
    {
      if (!this.Investigating)
      {
        if ((double) this.Yandere.transform.position.y > (double) this.transform.position.y - 1.0 && (double) this.Yandere.transform.position.y < (double) this.transform.position.y + 1.0)
        {
          this.Distance = Vector3.Distance(this.Yandere.transform.position, this.transform.position);
          if ((double) this.Distance < (double) this.MinimumDistance)
          {
            if (!this.Started)
            {
              this.Subtitle.text = this.SpeechText[0];
              this.MyAudio.Play();
              this.Started = true;
            }
            else
            {
              this.MyAudio.pitch = Time.timeScale;
              if (this.MultiClip)
              {
                if ((double) this.MyAnimation["fatherFixing_00"].time > (double) this.MyAnimation["fatherFixing_00"].length)
                  this.MyAnimation["fatherFixing_00"].time -= this.MyAnimation["fatherFixing_00"].length;
                if (this.AnimPhase == 0)
                {
                  if ((double) this.MyAnimation["fatherFixing_00"].time > 18.0 && (double) this.MyAnimation["fatherFixing_00"].time < 18.1000003814697)
                  {
                    this.Subtitle.text = this.SpeechText[this.SpeechPhase];
                    this.MyAudio.clip = this.SpeechClip[this.SpeechPhase];
                    this.MyAudio.Play();
                    ++this.SpeechPhase;
                    this.AnimPhase = 1;
                  }
                }
                else if ((double) this.MyAnimation["fatherFixing_00"].time < 1.0)
                {
                  this.Subtitle.text = this.SpeechText[this.SpeechPhase];
                  this.MyAudio.clip = this.SpeechClip[this.SpeechPhase];
                  this.MyAudio.Play();
                  ++this.SpeechPhase;
                  this.AnimPhase = 0;
                }
              }
              else if (this.SpeechPhase < this.SpeechTime.Length && (double) this.MyAudio.time > (double) this.SpeechTime[this.SpeechPhase])
              {
                this.Subtitle.text = this.SpeechText[this.SpeechPhase];
                ++this.SpeechPhase;
              }
              this.Scale = Mathf.Abs((float) (1.0 - ((double) this.Distance - 1.0) / ((double) this.MinimumDistance - 1.0)));
              if ((double) this.Scale < 0.0)
                this.Scale = 0.0f;
              if ((double) this.Scale > 1.0)
                this.Scale = 1f;
              this.Jukebox.volume = (float) (1.0 - 0.899999976158142 * (double) this.Scale);
              this.Subtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
              this.MyAudio.volume = this.Scale;
            }
            for (int index = 0; index < this.Boundary.Length; ++index)
            {
              Transform transform = this.Boundary[index];
              if ((Object) transform != (Object) null && (double) Vector3.Distance(this.Yandere.transform.position, transform.position) < 0.333330005407333)
              {
                Debug.Log((object) ("Got a ''proximity'' game over from " + this.gameObject.name));
                AudioSource.PlayClipAtPoint(this.CrunchSound, Camera.main.transform.position);
                this.TransitionToGameOver();
              }
            }
            this.LookForYandere();
          }
          else if ((double) this.Distance < (double) this.MinimumDistance + 1.0)
          {
            this.Jukebox.volume = 1f;
            this.MyAudio.volume = 0.0f;
            this.Subtitle.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
          }
        }
        if (this.Node.Length == 0)
          return;
        this.transform.parent.rotation = Quaternion.Slerp(this.transform.parent.rotation, Quaternion.LookRotation(new Vector3(5.4f, 0.0f, -100f) - this.transform.parent.position), Time.deltaTime * 10f);
      }
      else
      {
        this.LookForYandere();
        this.transform.parent.position = Vector3.MoveTowards(this.transform.parent.position, this.Node[this.CurrentNode].position, Time.deltaTime);
        if ((double) this.FixTimer == 0.0 || (double) this.FixTimer == 5.0)
          this.transform.parent.rotation = Quaternion.Slerp(this.transform.parent.rotation, Quaternion.LookRotation(this.Node[this.CurrentNode].position - this.transform.parent.position), Time.deltaTime * 10f);
        if ((double) Vector3.Distance(this.transform.parent.position, this.Node[this.CurrentNode].position) < 0.100000001490116)
        {
          if (this.CurrentNode == this.Node.Length - 1)
            this.Return = true;
          if (!this.Return)
          {
            ++this.CurrentNode;
            if (this.CurrentNode == 3)
            {
              AudioSource.PlayClipAtPoint(this.DoorOpen, this.Door.transform.position);
              this.OpenFrontDoor = true;
            }
          }
          else if ((double) this.FixTimer == 5.0)
          {
            this.BreakerDoor.Label.text = "Open";
            this.BreakerDoor.Open = false;
            this.MyAnimation.CrossFade("walkConfident_00");
            --this.CurrentNode;
            if (this.CurrentNode == 1)
            {
              AudioSource.PlayClipAtPoint(this.DoorOpen, this.Door.transform.position);
              this.OpenFrontDoor = false;
            }
            if (this.CurrentNode < 0)
            {
              this.MyAnimation.CrossFade("fatherFixing_00");
              this.BreakerDoor.ServedPurpose = false;
              this.Investigating = false;
              this.Return = false;
              this.CurrentNode = 1;
              this.FixTimer = 0.0f;
            }
          }
          else
          {
            this.FixTimer = Mathf.MoveTowards(this.FixTimer, 5f, Time.deltaTime);
            if ((double) this.FixTimer >= 4.0 && !this.Lights.activeInHierarchy)
            {
              AudioSource.PlayClipAtPoint(this.PowerOn, Camera.main.transform.position);
              this.Lights.SetActive(true);
            }
            this.MyAnimation.CrossFade("rummage_00");
          }
        }
        this.Rotation = !this.OpenFrontDoor ? Mathf.Lerp(this.Rotation, 0.0f, Time.deltaTime * 3.6f) : Mathf.Lerp(this.Rotation, this.TargetRotation, Time.deltaTime * 3.6f);
        this.Door.transform.localEulerAngles = new Vector3(this.Door.transform.localEulerAngles.x, this.Rotation, this.Door.transform.localEulerAngles.z);
      }
    }
    else if (this.GameOverPhase == 0)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer <= 1.0 || this.MyAudio.isPlaying)
        return;
      Debug.Log((object) "Should be updating the subtitle with the Game Over text.");
      this.Subtitle.transform.localScale = new Vector3(1f, 1f, 1f);
      this.Subtitle.text = this.GameOverText ?? "";
      this.MyAudio.clip = this.GameOverLine;
      this.MyAudio.Play();
      ++this.GameOverPhase;
    }
    else
    {
      if (this.MyAudio.isPlaying && !Input.GetButton("A"))
        return;
      this.Heartbroken.SetActive(true);
      this.Subtitle.text = "";
      this.enabled = false;
      this.MyAudio.Stop();
    }
  }

  private bool YandereIsInFOV()
  {
    Vector3 to = this.Yandere.transform.position - this.Head.position;
    float num = 90f;
    return (double) Vector3.Angle(this.Head.forward, to) <= (double) num;
  }

  private bool YandereIsInLOS()
  {
    Debug.DrawLine(this.Head.position, new Vector3(this.Yandere.transform.position.x, this.YandereHead.position.y, this.Yandere.transform.position.z), Color.red);
    RaycastHit hitInfo;
    return Physics.Linecast(this.Head.position, new Vector3(this.Yandere.transform.position.x, this.YandereHead.position.y, this.Yandere.transform.position.z), out hitInfo) && hitInfo.collider.gameObject.layer == 13;
  }

  private void TransitionToGameOver()
  {
    this.Marker.Tex.transform.localScale = new Vector3(1f, 0.0f, 1f);
    this.Marker.Tex.color = new Color(1f, 0.0f, 0.0f, 0.0f);
    this.Darkness.material.color = new Color(0.0f, 0.0f, 0.0f, 1f);
    this.Yandere.RPGCamera.enabled = false;
    this.Yandere.CanMove = false;
    this.Subtitle.text = "";
    this.GameOver = true;
    this.Jukebox.Stop();
    this.MyAudio.Stop();
    this.Alpha = 0.0f;
  }

  private void LookForYandere()
  {
    if (this.Yandere.Hidden && this.Yandere.Stance.Current == StanceType.Crouching)
    {
      this.Alpha = Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime * this.NoticeSpeed);
    }
    else
    {
      this.Alpha = !this.YandereIsInFOV() ? Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime * this.NoticeSpeed) : (!this.YandereIsInLOS() ? Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime * this.NoticeSpeed) : Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * this.NoticeSpeed));
      if (this.Investigating && (double) Vector3.Distance(this.Yandere.transform.position, this.transform.parent.position) < 1.0)
        this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, (float) ((double) Time.deltaTime * (double) this.NoticeSpeed * 2.0));
    }
    if ((double) this.Alpha == 1.0)
    {
      Debug.Log((object) ("Got a ''witnessed'' game over from " + this.gameObject.name));
      AudioSource.PlayClipAtPoint(this.GameOverSound, Camera.main.transform.position);
      this.TransitionToGameOver();
    }
    this.Marker.Tex.transform.localScale = new Vector3(1f, this.Alpha, 1f);
    this.Marker.Tex.color = new Color(1f, 0.0f, 0.0f, this.Alpha);
  }
}
