// Decompiled with JetBrains decompiler
// Type: DateGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public static class DateGlobals
{
  private const string Str_Week = "Week";
  private const string Str_Weekday = "Weekday";
  private const string Str_PassDays = "PassDays";
  private const string Str_DayPassed = "DayPassed";
  private const string Str_GameplayDay = "GameplayDay";
  private const string Str_ForceSkip = "ForceSkip";

  public static int Week
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Week");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Week", value);
  }

  public static DayOfWeek Weekday
  {
    get => GlobalsHelper.GetEnum<DayOfWeek>("Profile_" + GameGlobals.Profile.ToString() + "_Weekday");
    set => GlobalsHelper.SetEnum<DayOfWeek>("Profile_" + GameGlobals.Profile.ToString() + "_Weekday", value);
  }

  public static int PassDays
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PassDays");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PassDays", value);
  }

  public static bool DayPassed
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed", value);
  }

  public static int GameplayDay
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay", value);
  }

  public static bool ForceSkip
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ForceSkip");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ForceSkip", value);
  }

  public static void DeleteAll()
  {
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Week");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Weekday");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PassDays");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ForceSkip");
  }
}
