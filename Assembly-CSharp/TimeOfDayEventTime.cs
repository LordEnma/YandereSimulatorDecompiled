// Decompiled with JetBrains decompiler
// Type: TimeOfDayEventTime
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public class TimeOfDayEventTime : IScheduledEventTime
{
  [SerializeField]
  private int week;
  [SerializeField]
  private DayOfWeek weekday;
  [SerializeField]
  private TimeOfDay timeOfDay;

  public TimeOfDayEventTime(int week, DayOfWeek weekday, TimeOfDay timeOfDay)
  {
    this.week = week;
    this.weekday = weekday;
    this.timeOfDay = timeOfDay;
  }

  public ScheduledEventTimeType ScheduleType => ScheduledEventTimeType.TimeOfDay;

  public bool OccurringNow(DateAndTime currentTime)
  {
    int num1 = currentTime.Week == this.week ? 1 : 0;
    bool flag1 = currentTime.Weekday == this.weekday;
    bool flag2 = currentTime.Clock.TimeOfDay == this.timeOfDay;
    int num2 = flag1 ? 1 : 0;
    return (num1 & num2 & (flag2 ? 1 : 0)) != 0;
  }

  public bool OccursInTheFuture(DateAndTime currentTime)
  {
    if (currentTime.Week != this.week)
      return currentTime.Week < this.week;
    return currentTime.Weekday == this.weekday ? currentTime.Clock.TimeOfDay < this.timeOfDay : currentTime.Weekday < this.weekday;
  }

  public bool OccurredInThePast(DateAndTime currentTime)
  {
    if (currentTime.Week != this.week)
      return currentTime.Week > this.week;
    return currentTime.Weekday == this.weekday ? currentTime.Clock.TimeOfDay > this.timeOfDay : currentTime.Weekday > this.weekday;
  }
}
