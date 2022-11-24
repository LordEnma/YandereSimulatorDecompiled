// Decompiled with JetBrains decompiler
// Type: HomeClockScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Globalization;
using UnityEngine;

public class HomeClockScript : MonoBehaviour
{
  public UILabel MoneyLabel;
  public UILabel HourLabel;
  public UILabel DayLabel;
  public AudioSource MyAudio;
  public bool ShakeMoney;
  public Vector3 Origin;
  public float Shake;
  public float OriginalG;
  public float OriginalB;
  public float G;
  public float B;

  private void Start()
  {
    this.DayLabel.text = this.GetWeekdayText(DateGlobals.Weekday) + ", WEEK " + DateGlobals.Week.ToString();
    this.HourLabel.text = !HomeGlobals.Night ? (HomeGlobals.LateForSchool ? "7:30 AM" : "6:30 AM") : "8:00 PM";
    this.OriginalG = this.MoneyLabel.color.g;
    this.OriginalB = this.MoneyLabel.color.b;
    this.UpdateMoneyLabel();
  }

  private void Update()
  {
    if (!this.ShakeMoney)
      return;
    this.Shake = Mathf.MoveTowards(this.Shake, 0.0f, Time.deltaTime * 10f);
    this.MoneyLabel.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(this.Shake * -1f, this.Shake * 1f), this.Origin.y + UnityEngine.Random.Range(this.Shake * -1f, this.Shake * 1f), 0.0f);
    this.G = Mathf.MoveTowards(this.G, this.OriginalG, Time.deltaTime);
    this.B = Mathf.MoveTowards(this.B, this.OriginalB, Time.deltaTime);
    this.MoneyLabel.color = new Color(1f, this.G, this.B, 1f);
    if ((double) this.Shake != 0.0)
      return;
    this.ShakeMoney = false;
  }

  private string GetWeekdayText(DayOfWeek weekday)
  {
    switch (weekday)
    {
      case DayOfWeek.Sunday:
        return "SUNDAY";
      case DayOfWeek.Monday:
        return "MONDAY";
      case DayOfWeek.Tuesday:
        return "TUESDAY";
      case DayOfWeek.Wednesday:
        return "WEDNESDAY";
      case DayOfWeek.Thursday:
        return "THURSDAY";
      case DayOfWeek.Friday:
        return "FRIDAY";
      default:
        return "SATURDAY";
    }
  }

  public void UpdateMoneyLabel() => this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", (IFormatProvider) NumberFormatInfo.InvariantInfo);

  public void MoneyFail()
  {
    if (this.Origin != Vector3.zero)
      this.MoneyLabel.transform.localPosition = this.Origin;
    this.Origin = this.MoneyLabel.transform.localPosition;
    this.ShakeMoney = true;
    this.Shake = 10f;
    this.G = 0.0f;
    this.B = 0.0f;
    this.MyAudio.Play();
  }
}
