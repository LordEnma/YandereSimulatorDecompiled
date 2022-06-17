// Decompiled with JetBrains decompiler
// Type: DelinquentManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DelinquentManagerScript : MonoBehaviour
{
  public GameObject Delinquents;
  public GameObject RapBeat;
  public GameObject Panel;
  public float[] NextTime;
  public DelinquentScript Attacker;
  public MirrorScript Mirror;
  public UILabel TimeLabel;
  public ClockScript Clock;
  public UISprite Circle;
  public float SpeechTimer;
  public float TimerMax;
  public float Timer;
  public bool Aggro;
  public int Phase = 1;

  private void Start()
  {
    this.Delinquents.SetActive(false);
    this.TimerMax = 15f;
    this.Timer = 15f;
    ++this.Phase;
  }

  private void Update()
  {
    this.SpeechTimer = Mathf.MoveTowards(this.SpeechTimer, 0.0f, Time.deltaTime);
    if ((Object) this.Attacker != (Object) null && !this.Attacker.Attacking && this.Attacker.ExpressedSurprise && this.Attacker.Run && !this.Aggro)
    {
      AudioSource component = this.GetComponent<AudioSource>();
      component.clip = this.Attacker.AggroClips[Random.Range(0, this.Attacker.AggroClips.Length)];
      component.Play();
      this.Aggro = true;
    }
    if (!this.Panel.activeInHierarchy || (double) this.Clock.HourTime <= (double) this.NextTime[this.Phase])
      return;
    if (this.Phase == 3 && (double) this.Clock.HourTime > 7.25)
    {
      this.TimerMax = 75f;
      this.Timer = 75f;
      ++this.Phase;
    }
    else if (this.Phase == 5 && (double) this.Clock.HourTime > 8.5)
    {
      this.TimerMax = 285f;
      this.Timer = 285f;
      ++this.Phase;
    }
    else if (this.Phase == 7 && (double) this.Clock.HourTime > 13.25)
    {
      this.TimerMax = 15f;
      this.Timer = 15f;
      ++this.Phase;
    }
    else if (this.Phase == 9 && (double) this.Clock.HourTime > 13.5)
    {
      this.TimerMax = 135f;
      this.Timer = 135f;
      ++this.Phase;
    }
    if ((Object) this.Attacker == (Object) null)
      this.Timer -= Time.deltaTime * (this.Clock.TimeSpeed / 60f);
    this.Circle.fillAmount = (float) (1.0 - (double) this.Timer / (double) this.TimerMax);
    if ((double) this.Timer > 0.0)
      return;
    this.Delinquents.SetActive(!this.Delinquents.activeInHierarchy);
    if (this.Phase < 8)
    {
      ++this.Phase;
    }
    else
    {
      this.Delinquents.SetActive(false);
      this.Panel.SetActive(false);
    }
  }

  public void CheckTime()
  {
    if ((double) this.Clock.HourTime < 13.0)
    {
      this.Delinquents.SetActive(false);
      this.TimerMax = 15f;
      this.Timer = 15f;
      this.Phase = 6;
    }
    else
    {
      if ((double) this.Clock.HourTime >= 15.5)
        return;
      this.Delinquents.SetActive(false);
      this.TimerMax = 15f;
      this.Timer = 15f;
      this.Phase = 8;
    }
  }

  public void EasterEgg()
  {
    this.RapBeat.SetActive(true);
    ++this.Mirror.Limit;
  }
}
