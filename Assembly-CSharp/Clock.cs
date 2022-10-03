// Decompiled with JetBrains decompiler
// Type: Clock
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Clock
{
  [SerializeField]
  private int hours;
  [SerializeField]
  private int minutes;
  [SerializeField]
  private int seconds;
  [SerializeField]
  private float currentSecond;
  private static readonly Dictionary<TimeOfDay, string> TimeOfDayStrings = new Dictionary<TimeOfDay, string>()
  {
    {
      TimeOfDay.Midnight,
      "Midnight"
    },
    {
      TimeOfDay.EarlyMorning,
      "Early Morning"
    },
    {
      TimeOfDay.Morning,
      "Morning"
    },
    {
      TimeOfDay.LateMorning,
      "Late Morning"
    },
    {
      TimeOfDay.Noon,
      "Noon"
    },
    {
      TimeOfDay.Afternoon,
      "Afternoon"
    },
    {
      TimeOfDay.Evening,
      "Evening"
    },
    {
      TimeOfDay.Night,
      "Night"
    }
  };

  public Clock(int hours, int minutes, int seconds, float currentSecond)
  {
    this.hours = hours;
    this.minutes = minutes;
    this.seconds = seconds;
    this.currentSecond = currentSecond;
  }

  public Clock(int hours, int minutes, int seconds)
    : this(hours, minutes, seconds, 0.0f)
  {
  }

  public Clock()
    : this(0, 0, 0, 0.0f)
  {
  }

  public int Hours24 => this.hours;

  public int Hours12
  {
    get
    {
      int num = this.hours % 12;
      return num != 0 ? num : 12;
    }
  }

  public int Minutes => this.minutes;

  public int Seconds => this.seconds;

  public float CurrentSecond => this.currentSecond;

  public int TotalSeconds => this.hours * 3600 + this.minutes * 60 + this.seconds;

  public float PreciseTotalSeconds => (float) this.TotalSeconds + this.currentSecond;

  public bool IsAM => this.hours < 12;

  public TimeOfDay TimeOfDay
  {
    get
    {
      if (this.hours < 3)
        return TimeOfDay.Midnight;
      if (this.hours < 6)
        return TimeOfDay.EarlyMorning;
      if (this.hours < 9)
        return TimeOfDay.Morning;
      if (this.hours < 12)
        return TimeOfDay.LateMorning;
      if (this.hours < 15)
        return TimeOfDay.Noon;
      if (this.hours < 18)
        return TimeOfDay.Afternoon;
      return this.hours < 21 ? TimeOfDay.Evening : TimeOfDay.Night;
    }
  }

  public string TimeOfDayString => Clock.TimeOfDayStrings[this.TimeOfDay];

  public bool IsBefore(Clock clock) => this.TotalSeconds < clock.TotalSeconds;

  public bool IsAfter(Clock clock) => this.TotalSeconds > clock.TotalSeconds;

  public void IncrementHour()
  {
    ++this.hours;
    if (this.hours != 24)
      return;
    this.hours = 0;
  }

  public void IncrementMinute()
  {
    ++this.minutes;
    if (this.minutes != 60)
      return;
    this.IncrementHour();
    this.minutes = 0;
  }

  public void IncrementSecond()
  {
    ++this.seconds;
    if (this.seconds != 60)
      return;
    this.IncrementMinute();
    this.seconds = 0;
  }

  public void Tick(float dt)
  {
    for (this.currentSecond += dt; (double) this.currentSecond >= 1.0; --this.currentSecond)
      this.IncrementSecond();
  }
}
