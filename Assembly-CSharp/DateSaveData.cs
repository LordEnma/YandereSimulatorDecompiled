// Decompiled with JetBrains decompiler
// Type: DateSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
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
