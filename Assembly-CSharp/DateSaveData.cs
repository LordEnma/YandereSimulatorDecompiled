// Decompiled with JetBrains decompiler
// Type: DateSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
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
