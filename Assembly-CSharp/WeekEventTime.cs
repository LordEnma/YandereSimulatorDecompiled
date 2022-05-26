// Decompiled with JetBrains decompiler
// Type: WeekEventTime
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
