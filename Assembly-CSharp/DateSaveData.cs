// Decompiled with JetBrains decompiler
// Type: DateSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
