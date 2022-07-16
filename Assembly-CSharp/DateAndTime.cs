// Decompiled with JetBrains decompiler
// Type: DateAndTime
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public class DateAndTime
{
  [SerializeField]
  private int week;
  [SerializeField]
  private DayOfWeek weekday;
  [SerializeField]
  private Clock clock;

  public DateAndTime(int week, DayOfWeek weekday, Clock clock)
  {
    this.week = week;
    this.weekday = weekday;
    this.clock = clock;
  }

  public int Week => this.week;

  public DayOfWeek Weekday => this.weekday;

  public Clock Clock => this.clock;

  public int TotalSeconds
  {
    get
    {
      int num1 = this.week * 604800;
      int num2 = (int) this.weekday * 86400;
      int totalSeconds = this.clock.TotalSeconds;
      int num3 = num2;
      return num1 + num3 + totalSeconds;
    }
  }

  public void IncrementWeek() => ++this.week;

  public void IncrementWeekday()
  {
    int num = (int) (this.weekday + 1);
    if (num == 7)
    {
      this.IncrementWeek();
      num = 0;
    }
    this.weekday = (DayOfWeek) num;
  }

  public void Tick(float dt)
  {
    int hours24 = this.clock.Hours24;
    this.clock.Tick(dt);
    if (this.clock.Hours24 >= hours24)
      return;
    this.IncrementWeekday();
  }
}
