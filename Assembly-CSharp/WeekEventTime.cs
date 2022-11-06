// Decompiled with JetBrains decompiler
// Type: WeekEventTime
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public class WeekEventTime : IScheduledEventTime
{
  [SerializeField]
  private int week;

  public WeekEventTime(int week) => this.week = week;

  public ScheduledEventTimeType ScheduleType => ScheduledEventTimeType.Week;

  public bool OccurringNow(DateAndTime currentTime) => currentTime.Week == this.week;

  public bool OccursInTheFuture(DateAndTime currentTime) => currentTime.Week < this.week;

  public bool OccurredInThePast(DateAndTime currentTime) => currentTime.Week > this.week;
}
