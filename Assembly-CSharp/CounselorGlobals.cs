// Decompiled with JetBrains decompiler
// Type: CounselorGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class CounselorGlobals
{
  private const string Str_DelinquentPunishments = "DelinquentPunishments";
  private const string Str_CounselorPunishments = "CounselorPunishments";
  private const string Str_CounselorVisits = "CounselorVisits";
  private const string Str_CounselorTape = "CounselorTape";
  private const string Str_ApologiesUsed = "ApologiesUsed";
  private const string Str_WeaponsBanned = "WeaponsBanned";
  private const string Str_BloodVisits = "BloodVisits";
  private const string Str_InsanityVisits = "InsanityVisits";
  private const string Str_LewdVisits = "LewdVisits";
  private const string Str_TheftVisits = "TheftVisits";
  private const string Str_TrespassVisits = "TrespassVisits";
  private const string Str_WeaponVisits = "WeaponVisits";
  private const string Str_BloodExcuseUsed = "BloodExcuseUsed";
  private const string Str_InsanityExcuseUsed = "InsanityExcuseUsed";
  private const string Str_LewdExcuseUsed = "LewdExcuseUsed";
  private const string Str_TheftExcuseUsed = "TheftExcuseUsed";
  private const string Str_TrespassExcuseUsed = "TrespassExcuseUsed";
  private const string Str_WeaponExcuseUsed = "WeaponExcuseUsed";
  private const string Str_BloodBlameUsed = "BloodBlameUsed";
  private const string Str_InsanityBlameUsed = "InsanityBlameUsed";
  private const string Str_LewdBlameUsed = "LewdBlameUsed";
  private const string Str_TheftBlameUsed = "TheftBlameUsed";
  private const string Str_TrespassBlameUsed = "TrespassBlameUsed";
  private const string Str_WeaponBlameUsed = "WeaponBlameUsed";
  private const string Str_ReportedAlcohol = "ReportedAlcohol";
  private const string Str_ReportedCigarettes = "ReportedCigarettes";
  private const string Str_ReportedCondoms = "ReportedCondoms";
  private const string Str_ReportedTheft = "ReportedTheft";
  private const string Str_ReportedCheating = "ReportedCheating";

  public static int DelinquentPunishments
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_DelinquentPunishments");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_DelinquentPunishments", value);
  }

  public static int CounselorPunishments
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CounselorPunishments");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CounselorPunishments", value);
  }

  public static int CounselorVisits
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CounselorVisits");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CounselorVisits", value);
  }

  public static int CounselorTape
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CounselorTape");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CounselorTape", value);
  }

  public static int ApologiesUsed
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_ApologiesUsed");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_ApologiesUsed", value);
  }

  public static int WeaponsBanned
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponsBanned");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponsBanned", value);
  }

  public static int BloodVisits
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BloodVisits");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BloodVisits", value);
  }

  public static int InsanityVisits
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_InsanityVisits");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_InsanityVisits", value);
  }

  public static int LewdVisits
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_LewdVisits");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_LewdVisits", value);
  }

  public static int TheftVisits
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TheftVisits");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TheftVisits", value);
  }

  public static int TrespassVisits
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TrespassVisits");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TrespassVisits", value);
  }

  public static int WeaponVisits
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponVisits");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponVisits", value);
  }

  public static int BloodExcuseUsed
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BloodExcuseUsed");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BloodExcuseUsed", value);
  }

  public static int InsanityExcuseUsed
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_InsanityExcuseUsed");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_InsanityExcuseUsed", value);
  }

  public static int LewdExcuseUsed
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_LewdExcuseUsed");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_LewdExcuseUsed", value);
  }

  public static int TheftExcuseUsed
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TheftExcuseUsed");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TheftExcuseUsed", value);
  }

  public static int TrespassExcuseUsed
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TrespassExcuseUsed");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TrespassExcuseUsed", value);
  }

  public static int WeaponExcuseUsed
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponExcuseUsed");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponExcuseUsed", value);
  }

  public static int BloodBlameUsed
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BloodBlameUsed");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BloodBlameUsed", value);
  }

  public static int InsanityBlameUsed
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_InsanityBlameUsed");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_InsanityBlameUsed", value);
  }

  public static int LewdBlameUsed
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_LewdBlameUsed");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_LewdBlameUsed", value);
  }

  public static int TheftBlameUsed
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TheftBlameUsed");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TheftBlameUsed", value);
  }

  public static int TrespassBlameUsed
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TrespassBlameUsed");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TrespassBlameUsed", value);
  }

  public static int WeaponBlameUsed
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponBlameUsed");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponBlameUsed", value);
  }

  public static bool ReportedAlcohol
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReportedAlcohol");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReportedAlcohol", value);
  }

  public static bool ReportedCigarettes
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReportedCigarettes");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReportedCigarettes", value);
  }

  public static bool ReportedCondoms
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReportedCondoms");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReportedCondoms", value);
  }

  public static bool ReportedTheft
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReportedTheft");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReportedTheft", value);
  }

  public static bool ReportedCheating
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReportedCheating");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReportedCheating", value);
  }

  public static void DeleteAll()
  {
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DelinquentPunishments");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CounselorPunishments");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CounselorVisits");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CounselorTape");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ApologiesUsed");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_WeaponsBanned");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BloodVisits");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_InsanityVisits");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LewdVisits");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TheftVisits");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TrespassVisits");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_WeaponVisits");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BloodExcuseUsed");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_InsanityExcuseUsed");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LewdExcuseUsed");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TheftExcuseUsed");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TrespassExcuseUsed");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_WeaponExcuseUsed");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BloodBlameUsed");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_InsanityBlameUsed");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LewdBlameUsed");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TheftBlameUsed");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TrespassBlameUsed");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_WeaponBlameUsed");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ReportedAlcohol");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ReportedCigarettes");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ReportedCondoms");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ReportedTheft");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ReportedCheating");
  }
}
