// Decompiled with JetBrains decompiler
// Type: ClassGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class ClassGlobals
{
  private const string Str_Biology = "Biology";
  private const string Str_BiologyBonus = "BiologyBonus";
  private const string Str_BiologyGrade = "BiologyGrade";
  private const string Str_Chemistry = "Chemistry";
  private const string Str_ChemistryBonus = "ChemistryBonus";
  private const string Str_ChemistryGrade = "ChemistryGrade";
  private const string Str_Language = "Language";
  private const string Str_LanguageBonus = "LanguageBonus";
  private const string Str_LanguageGrade = "LanguageGrade";
  private const string Str_Physical = "Physical";
  private const string Str_PhysicalBonus = "PhysicalBonus";
  private const string Str_PhysicalGrade = "PhysicalGrade";
  private const string Str_Psychology = "Psychology";
  private const string Str_PsychologyBonus = "PsychologyBonus";
  private const string Str_PsychologyGrade = "PsychologyGrade";
  private const string Str_BonusStudyPoints = "BonusStudyPoints";

  public static int Biology
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Biology");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Biology", value);
  }

  public static int BiologyBonus
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BiologyBonus");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BiologyBonus", value);
  }

  public static int BiologyGrade
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BiologyGrade");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BiologyGrade", value);
  }

  public static int Chemistry
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Chemistry");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Chemistry", value);
  }

  public static int ChemistryBonus
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_ChemistryBonus");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_ChemistryBonus", value);
  }

  public static int ChemistryGrade
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_ChemistryGrade");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_ChemistryGrade", value);
  }

  public static int Language
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Language");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Language", value);
  }

  public static int LanguageBonus
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_LanguageBonus");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_LanguageBonus", value);
  }

  public static int LanguageGrade
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_LanguageGrade");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_LanguageGrade", value);
  }

  public static int Physical
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Physical");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Physical", value);
  }

  public static int PhysicalBonus
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PhysicalBonus");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PhysicalBonus", value);
  }

  public static int PhysicalGrade
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PhysicalGrade");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PhysicalGrade", value);
  }

  public static int Psychology
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Psychology");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Psychology", value);
  }

  public static int PsychologyBonus
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PsychologyBonus");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PsychologyBonus", value);
  }

  public static int PsychologyGrade
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PsychologyGrade");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PsychologyGrade", value);
  }

  public static int BonusStudyPoints
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BonusStudyPoints");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BonusStudyPoints", value);
  }

  public static void DeleteAll()
  {
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Biology");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BiologyBonus");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BiologyGrade");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Chemistry");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ChemistryBonus");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ChemistryGrade");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Language");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LanguageBonus");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LanguageGrade");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Physical");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PhysicalBonus");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PhysicalGrade");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Psychology");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PsychologyBonus");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PsychologyGrade");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BonusStudyPoints");
  }
}
