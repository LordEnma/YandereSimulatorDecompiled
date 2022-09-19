// Decompiled with JetBrains decompiler
// Type: DateReverseScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DateReverseScript : MonoBehaviour
{
  public AudioSource MyAudio;
  public string[] MonthName;
  public string Prefix;
  public UILabel Label;
  public AudioClip Finish;
  public float TimeLimit;
  public float LifeTime;
  public float Timer;
  public int RollDirection;
  public int Month;
  public int Year;
  public int Day;
  public int SlowMonth;
  public int SlowYear;
  public int SlowDay;
  public int EndMonth;
  public int EndYear;
  public int EndDay;
  public bool Rollback;

  private void Start()
  {
    Time.timeScale = 1f;
    this.UpdateDate();
  }

  private void Update()
  {
    if (Input.GetKeyDown("space"))
      this.Rollback = true;
    if (!this.Rollback)
      return;
    this.LifeTime += Time.deltaTime;
    this.Timer += Time.deltaTime;
    if ((double) this.Timer <= (double) this.TimeLimit)
      return;
    if (this.Year == this.SlowYear && this.Month == this.SlowMonth && this.Day < this.SlowDay || this.Year == this.SlowYear && this.Month < this.SlowMonth)
    {
      this.TimeLimit *= 1.09f;
      if (this.Month == this.EndMonth && this.Day == this.EndDay + 1)
      {
        this.MyAudio.clip = this.Finish;
        this.Label.color = new Color(1f, 0.0f, 0.0f, 1f);
        this.enabled = false;
      }
    }
    else if ((double) this.TimeLimit > 0.0099999997764825821)
      this.TimeLimit *= 0.9f;
    else
      this.Day += this.RollDirection * 19;
    this.Timer = 0.0f;
    this.Day += this.RollDirection;
    this.UpdateDate();
    this.MyAudio.Play();
    if ((Object) this.MyAudio.clip != (Object) this.Finish)
      return;
    this.MyAudio.pitch = 1f;
  }

  private void UpdateDate()
  {
    if (this.Day < 1)
    {
      this.Day = 31;
      --this.Month;
      if (this.Month < 1)
      {
        this.Month = 12;
        --this.Year;
      }
    }
    else if (this.Day > 31)
    {
      this.Day = 1;
      ++this.Month;
      if (this.Month > 11)
      {
        this.Month = 1;
        ++this.Year;
      }
    }
    this.Prefix = this.Day == 1 || this.Day == 21 || this.Day == 31 ? "st" : (this.Day == 2 || this.Day == 22 ? "nd" : (this.Day == 3 || this.Day == 23 ? "rd" : "th"));
    this.Label.text = this.MonthName[this.Month] + " " + this.Day.ToString() + this.Prefix + ", " + this.Year.ToString();
  }
}
