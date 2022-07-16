// Decompiled with JetBrains decompiler
// Type: SpecificEventTime
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public class SpecificEventTime : IScheduledEventTime
{
  [SerializeField]
  private int week;
  [SerializeField]
  private DayOfWeek weekday;
  [SerializeField]
  private Clock startClock;
  [SerializeField]
  private Clock endClock;

  public SpecificEventTime(int week, DayOfWeek weekday, Clock startClock, Clock endClock)
  {
    this.week = week;
    this.weekday = weekday;
    this.startClock = startClock;
    this.endClock = endClock;
  }

  public ScheduledEventTimeType ScheduleType => ScheduledEventTimeType.Specific;

  public bool OccurringNow(DateAndTime currentTime)
  {
    int num1 = currentTime.Week == this.week ? 1 : 0;
    bool flag1 = currentTime.Weekday == this.weekday;
    Clock clock = currentTime.Clock;
    bool flag2 = clock.TotalSeconds >= this.startClock.TotalSeconds && clock.TotalSeconds < this.endClock.TotalSeconds;
    int num2 = flag1 ? 1 : 0;
    return (num1 & num2 & (flag2 ? 1 : 0)) != 0;
  }

  public bool OccursInTheFuture(DateAndTime currentTime)
  {
    if (currentTime.Week != this.week)
      return currentTime.Week < this.week;
    return currentTime.Weekday == this.weekday ? currentTime.Clock.TotalSeconds < this.startClock.TotalSeconds : currentTime.Weekday < this.weekday;
  }

  public bool OccurredInThePast(DateAndTime currentTime)
  {
    if (currentTime.Week != this.week)
      return currentTime.Week > this.week;
    return currentTime.Weekday == this.weekday ? currentTime.Clock.TotalSeconds >= this.endClock.TotalSeconds : currentTime.Weekday > this.weekday;
  }
}
