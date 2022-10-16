// Decompiled with JetBrains decompiler
// Type: DayEventTime
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public class DayEventTime : IScheduledEventTime
{
  [SerializeField]
  private int week;
  [SerializeField]
  private DayOfWeek weekday;

  public DayEventTime(int week, DayOfWeek weekday)
  {
    this.week = week;
    this.weekday = weekday;
  }

  public ScheduledEventTimeType ScheduleType => ScheduledEventTimeType.Day;

  public bool OccurringNow(DateAndTime currentTime) => currentTime.Week == this.week && currentTime.Weekday == this.weekday;

  public bool OccursInTheFuture(DateAndTime currentTime) => currentTime.Week == this.week ? currentTime.Weekday < this.weekday : currentTime.Week < this.week;

  public bool OccurredInThePast(DateAndTime currentTime) => currentTime.Week == this.week ? currentTime.Weekday > this.weekday : currentTime.Week > this.week;
}
