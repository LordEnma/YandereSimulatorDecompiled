// Decompiled with JetBrains decompiler
// Type: DateSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public class DateSaveData
{
  public int week;
  public DayOfWeek weekday;

  public static DateSaveData ReadFromGlobals() => new DateSaveData()
  {
    week = DateGlobals.Week,
    weekday = DateGlobals.Weekday
  };

  public static void WriteToGlobals(DateSaveData data)
  {
    DateGlobals.Week = data.week;
    DateGlobals.Weekday = data.weekday;
  }
}
