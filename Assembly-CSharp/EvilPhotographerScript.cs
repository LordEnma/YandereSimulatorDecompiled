// Decompiled with JetBrains decompiler
// Type: EvilPhotographerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class EvilPhotographerScript : MonoBehaviour
{
  public StalkerYandereScript Yandere;
  public DetectionMarkerScript Marker;
  public AudioClip ShockedGameOverLine;
  public AudioClip GameOverSound;
  public AudioClip GameOverLine;
  public AudioClip SpottedSound;
  public GameObject Heartbroken;
  public GameObject Fire;
  public Animation MyAnimation;
  public Transform YandereHead;
  public Transform Head;
  public AudioSource Jukebox;
  public AudioSource MyAudio;
  public Renderer Darkness;
  public UILabel Subtitle;
  public Transform[] PanicNode;
  public Transform[] Node;
  public AudioClip[] SpeechClip;
  public string[] SpeechText;
  public float[] SpeechTime;
  public AudioClip[] ShockClip;
  public string[] ShockText;
  public float[] ShockTime;
  public string ShockedGameOverText;
  public string GameOverText;
  public string WaitAnim;
  public string WalkAnim;
  public string RunAnim;
  public float MinimumDistance;
  public float SpeechTimer;
  public float NoticeSpeed;
  public float ShockTimer;
  public float Awareness;
  public float WaitTimer;
  public float Distance;
  public float Alpha;
  public float Scale;
  public float Timer;
  public float TargetRotation;
  public float Rotation;
  public int GameOverPhase;
  public int CurrentNode;
  public int SpeechPhase;
  public bool Searching;
  public bool GameOver;
  public bool Started;
  public bool Shocked;
  public Vector3 DistractionPoint;
  public float DistractionTimer;
  public bool Distracted;

  private void Start() => this.Subtitle.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);

  private void Update()
  {
    if (!this.GameOver)
    {
      if ((double) this.Yandere.transform.position.y > (double) this.transform.position.y - 1.0 && (double) this.Yandere.transform.position.y < (double) this.transform.position.y + 1.0)
      {
        if (this.Distracted)
        {
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(new Vector3(this.DistractionPoint.x, this.transform.position.y, this.DistractionPoint.z) - this.transform.position), Time.deltaTime * 10f);
          this.DistractionTimer -= Time.deltaTime;
          if ((double) this.DistractionTimer < 0.0)
            this.Distracted = false;
        }
        else
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
              if (this.SpeechPhase < this.SpeechTime.Length)
              {
                this.SpeechTimer += Time.deltaTime;
                if ((double) this.SpeechTimer > (double) this.SpeechTime[this.SpeechPhase])
                {
                  this.Subtitle.text = this.SpeechText[this.SpeechPhase];
                  this.MyAudio.clip = this.SpeechClip[this.SpeechPhase];
                  this.MyAudio.Play();
                  ++this.SpeechPhase;
                  if (this.Shocked && this.SpeechPhase > 3)
                  {
                    this.WaitAnim = "guardCorpse_00";
                    this.Node = this.PanicNode;
                    this.Searching = true;
                    this.Shocked = false;
                  }
                }
              }
              this.Scale = Mathf.Abs((float) (1.0 - ((double) this.Distance - 5.0) / (double) this.MinimumDistance));
              if ((double) this.Scale < 0.0)
                this.Scale = 0.0f;
              if ((double) this.Scale > 1.0)
                this.Scale = 1f;
              this.Jukebox.volume = (float) (1.0 - 0.89999997615814209 * (double) this.Scale);
              this.Subtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
              this.MyAudio.volume = this.Scale;
            }
            if ((double) this.Distance < 0.5)
            {
              Debug.Log((object) ("Got a ''proximity'' game over from " + this.gameObject.name));
              AudioSource.PlayClipAtPoint(this.SpottedSound, Camera.main.transform.position);
              this.TransitionToGameOver();
            }
          }
          else if ((double) this.Distance < (double) this.MinimumDistance + 1.0)
          {
            this.Jukebox.volume = 1f;
            this.MyAudio.volume = 0.0f;
            this.Subtitle.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
            this.Subtitle.text = "";
          }
        }
        this.LookForYandere();
      }
      else if ((double) this.Alpha > 0.0)
      {
        this.Alpha -= Time.deltaTime;
        this.Marker.Tex.transform.localScale = new Vector3(1f, this.Alpha, 1f);
        this.Marker.Tex.color = new Color(1f, 0.0f, 0.0f, this.Alpha);
      }
      if (!this.Distracted)
      {
        if ((double) Vector3.Distance(this.transform.position, this.Node[this.CurrentNode].position) < 0.10000000149011612)
        {
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.Node[this.CurrentNode].rotation, Time.deltaTime * 10f);
          this.MyAnimation.CrossFade(this.WaitAnim);
          this.WaitTimer += Time.deltaTime;
          if ((double) this.WaitTimer <= 10.0 || this.Shocked)
            return;
          this.WaitTimer = 0.0f;
          ++this.CurrentNode;
          if (this.CurrentNode >= this.Node.Length)
            this.CurrentNode = 1;
          if (this.Searching || !((Object) this.Fire != (Object) null) || !this.Fire.activeInHierarchy)
            return;
          this.SpeechClip = this.ShockClip;
          this.SpeechText = this.ShockText;
          this.SpeechTime = this.ShockTime;
          this.SpeechPhase = 0;
          this.SpeechTimer = 0.0f;
          this.Subtitle.text = this.SpeechText[0];
          this.MyAudio.clip = this.SpeechClip[0];
          this.MyAudio.Play();
          this.WaitAnim = "scaredIdle_01";
          this.CurrentNode = 1;
          this.ShockTimer = 1f;
          this.Shocked = true;
        }
        else
        {
          if ((double) this.ShockTimer == 0.0)
          {
            if ((Object) this.Fire != (Object) null && this.Fire.activeInHierarchy)
            {
              this.transform.position = Vector3.MoveTowards(this.transform.position, this.Node[this.CurrentNode].position, Time.deltaTime * 4f);
              this.MyAnimation.CrossFade(this.RunAnim);
            }
            else
            {
              this.transform.position = Vector3.MoveTowards(this.transform.position, this.Node[this.CurrentNode].position, Time.deltaTime);
              this.MyAnimation.CrossFade(this.WalkAnim);
            }
          }
          else
          {
            this.MyAnimation.CrossFade(this.WaitAnim);
            this.ShockTimer = Mathf.MoveTowards(this.ShockTimer, 0.0f, Time.deltaTime);
          }
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(this.Node[this.CurrentNode].position - this.transform.position), Time.deltaTime * 10f);
        }
      }
      else
        this.MyAnimation.CrossFade(this.WaitAnim);
    }
    else if (this.GameOverPhase == 0)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer <= 1.0 || this.MyAudio.isPlaying)
        return;
      Debug.Log((object) "Should be updating the subtitle with the Game Over text.");
      this.Subtitle.transform.localScale = new Vector3(1f, 1f, 1f);
      if (this.Shocked)
      {
        this.Subtitle.text = this.ShockedGameOverText;
        this.MyAudio.clip = this.ShockedGameOverLine;
      }
      else
      {
        this.Subtitle.text = this.GameOverText;
        this.MyAudio.clip = this.GameOverLine;
      }
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
    Debug.DrawLine(this.Head.position, new Vector3(this.Yandere.transform.position.x, (float) ((double) this.Yandere.transform.position.y + (double) this.Yandere.MyController.height - 0.20000000298023224), this.Yandere.transform.position.z), Color.red);
    RaycastHit hitInfo;
    return Physics.Linecast(this.Head.position, new Vector3(this.Yandere.transform.position.x, (float) ((double) this.Yandere.transform.position.y + (double) this.Yandere.MyController.height - 0.20000000298023224), this.Yandere.transform.position.z), out hitInfo) && hitInfo.collider.gameObject.layer == 13;
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
    if (!this.Yandere.Invisible)
    {
      this.NoticeSpeed = (this.MinimumDistance - this.Distance) * this.Awareness;
      this.Alpha = !this.YandereIsInFOV() ? Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime) : (!this.YandereIsInLOS() ? Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime) : Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * this.NoticeSpeed));
      if ((double) this.Alpha == 1.0)
      {
        Debug.Log((object) ("Got a ''witnessed'' game over from " + this.gameObject.name));
        AudioSource.PlayClipAtPoint(this.GameOverSound, Camera.main.transform.position);
        this.TransitionToGameOver();
      }
    }
    else
      this.Alpha = Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime);
    this.Marker.Tex.transform.localScale = new Vector3(1f, this.Alpha, 1f);
    this.Marker.Tex.color = new Color(1f, 0.0f, 0.0f, this.Alpha);
  }
}
