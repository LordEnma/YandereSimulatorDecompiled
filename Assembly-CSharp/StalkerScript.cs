// Decompiled with JetBrains decompiler
// Type: StalkerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class StalkerScript : MonoBehaviour
{
  public StruggleBarScript StruggleBar;
  public StalkerYandereScript Yandere;
  public StalkerPromptScript CatPrompt;
  public GameObject KnockoutStars;
  public GameObject Heartbroken;
  public GameObject[] BonkEffect;
  public Transform StalkerDoor;
  public AudioClip CrunchSound;
  public Animation MyAnimation;
  public AudioSource Jukebox;
  public AudioSource MyAudio;
  public AudioClip StalkerKnockout;
  public AudioClip StalkerWon;
  public AudioClip Crunch;
  public UILabel Subtitle;
  public AudioClip[] AlarmedClip;
  public string[] AlarmedText;
  public float[] AlarmedTime;
  public AudioClip[] SpeechClip;
  public string[] SpeechText;
  public float[] SpeechTime;
  public Collider[] Boundary;
  public float MinimumDistance;
  public float Distance;
  public float Scale;
  public float Timer;
  public bool PlayedAudio;
  public bool Struggling;
  public bool Alarmed;
  public bool Started;
  public bool Chase;
  public int SpeechPhase;
  public int Limit;

  private void Update()
  {
    if (!this.Chase)
    {
      this.Distance = Vector3.Distance(this.Yandere.transform.position, this.transform.position);
      if (!this.Alarmed)
      {
        for (int index = 0; index < this.Boundary.Length; ++index)
        {
          if (this.Boundary[index].bounds.Contains(this.Yandere.transform.position))
          {
            AudioSource.PlayClipAtPoint(this.CrunchSound, Camera.main.transform.position);
            this.TriggerAlarm();
          }
        }
        if ((double) this.Distance < 0.5)
          this.TriggerAlarm();
      }
      else
      {
        this.transform.LookAt(this.Yandere.transform.position);
        if (this.Limit == 10 && (double) Vector3.Distance(this.Yandere.transform.position, this.StalkerDoor.position) < 1.0)
          this.ChaseNow();
      }
      if ((double) this.Distance < (double) this.MinimumDistance)
      {
        if (!this.Started)
        {
          this.Timer += Time.deltaTime;
          if ((double) this.Timer > 1.0)
          {
            this.Subtitle.transform.localScale = new Vector3(1f, 1f, 1f);
            this.Subtitle.text = this.SpeechText[0];
            this.MyAudio.clip = this.SpeechClip[0];
            this.MyAudio.Play();
            this.Started = true;
            ++this.SpeechPhase;
          }
        }
        else
        {
          this.MyAudio.pitch = Time.timeScale;
          if (!this.Alarmed)
          {
            if (this.SpeechPhase < this.SpeechTime.Length && !this.MyAudio.isPlaying)
            {
              this.MyAudio.clip = this.SpeechClip[this.SpeechPhase];
              this.MyAudio.Play();
              this.Subtitle.text = this.SpeechText[this.SpeechPhase];
              ++this.SpeechPhase;
            }
          }
          else if (this.SpeechPhase < this.Limit && !this.MyAudio.isPlaying)
          {
            this.MyAudio.clip = this.SpeechClip[this.SpeechPhase];
            this.MyAudio.Play();
            this.Subtitle.text = this.SpeechText[this.SpeechPhase];
            ++this.SpeechPhase;
            if (this.Limit == 10 && this.SpeechPhase == this.Limit)
              this.ChaseNow();
          }
          this.Jukebox.volume = !this.MyAudio.isPlaying ? 1f : 0.1f;
        }
      }
      else
        this.Subtitle.text = "";
    }
    else if (!this.Struggling)
    {
      this.transform.LookAt(this.Yandere.transform.position);
      this.transform.Translate(this.transform.forward * Time.deltaTime * 5f, Space.World);
      this.MyAnimation.CrossFade("newSprint_00");
      if ((double) Vector3.Distance(this.transform.position, this.Yandere.transform.position) < 1.0)
      {
        this.MyAnimation.CrossFade("struggleB_00");
        this.Yandere.BeginStruggle();
        this.Struggling = true;
        this.StruggleBar.gameObject.SetActive(true);
        this.StruggleBar.Struggling = true;
        this.Subtitle.text = "";
      }
    }
    else
    {
      this.transform.position = Vector3.MoveTowards(this.transform.position, this.Yandere.transform.position + this.Yandere.transform.forward * 0.5f, Time.deltaTime * 10f);
      this.transform.rotation = this.Yandere.transform.rotation;
      if (!this.StruggleBar.Struggling)
      {
        if (this.StruggleBar.Yandere.Won)
        {
          if (!this.PlayedAudio)
          {
            AudioSource.PlayClipAtPoint(this.StalkerKnockout, this.Yandere.MainCamera.transform.position);
            this.PlayedAudio = true;
          }
          this.Yandere.MyAnimation.CrossFade("f02_struggleWinA_00");
          this.MyAnimation.CrossFade("struggleWinB_00");
          if ((double) this.MyAnimation["struggleWinB_00"].time >= 0.66666001081466675)
            this.BonkEffect[1].SetActive(true);
          if ((double) this.MyAnimation["struggleWinB_00"].time >= 1.3333300352096558)
          {
            this.KnockoutStars.SetActive(true);
            this.BonkEffect[2].SetActive(true);
          }
          if ((double) this.MyAnimation["struggleWinB_00"].time >= (double) this.MyAnimation["struggleWinB_00"].length)
          {
            this.CatPrompt.BeginCarryingCat();
            this.Yandere.CanMove = true;
            this.enabled = false;
          }
        }
        else
        {
          if (!this.PlayedAudio)
          {
            AudioSource.PlayClipAtPoint(this.StalkerWon, this.Yandere.MainCamera.transform.position);
            this.PlayedAudio = true;
            this.Jukebox.Stop();
          }
          this.Yandere.MyAnimation.CrossFade("f02_struggleLoseA_00");
          this.MyAnimation.CrossFade("struggleLoseB_00");
          if ((double) this.MyAnimation["struggleLoseB_00"].time >= (double) this.MyAnimation["struggleLoseB_00"].length)
          {
            this.Heartbroken.SetActive(true);
            this.enabled = false;
          }
        }
      }
    }
    if ((double) this.Yandere.transform.position.x < 1.0)
      this.MyAudio.volume = 1f;
    else
      this.MyAudio.volume = 0.0f;
  }

  private void ChaseNow()
  {
    this.SpeechClip = this.AlarmedClip;
    this.SpeechText = this.AlarmedText;
    this.SpeechTime = this.AlarmedTime;
    this.SpeechPhase = 9;
    this.MyAudio.clip = this.SpeechClip[this.SpeechPhase];
    this.MyAudio.Play();
    this.Subtitle.text = this.SpeechText[this.SpeechPhase];
    ++this.SpeechPhase;
    this.Yandere.MyAnimation.CrossFade(this.Yandere.IdleAnim);
    this.Yandere.CanMove = false;
    this.Yandere.Chased = true;
    this.Chase = true;
  }

  private void TriggerAlarm()
  {
    this.MyAnimation.CrossFade("readyToFight_00");
    this.SpeechClip = this.AlarmedClip;
    this.SpeechText = this.AlarmedText;
    this.SpeechTime = this.AlarmedTime;
    this.Subtitle.text = "";
    this.Started = false;
    this.Alarmed = true;
    this.SpeechPhase = 0;
    this.Timer = 0.0f;
    this.MyAudio.Stop();
  }
}
