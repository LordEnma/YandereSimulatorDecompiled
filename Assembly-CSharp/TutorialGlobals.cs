// Decompiled with JetBrains decompiler
// Type: TutorialGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

public static class TutorialGlobals
{
  private const string Str_IgnoreDistraction = "IgnoreDistraction";
  private const string Str_IgnoreClothing = "IgnoreClothing";
  private const string Str_IgnoreCouncil = "IgnoreCouncil";
  private const string Str_IgnoreTeacher = "IgnoreTeacher";
  private const string Str_IgnorePersona = "IgnorePersona";
  private const string Str_IgnoreLocker = "IgnoreLocker";
  private const string Str_IgnorePolice = "IgnorePolice";
  private const string Str_IgnoreSanity = "IgnoreSanity";
  private const string Str_IgnoreSenpai = "IgnoreSenpai";
  private const string Str_IgnoreVision = "IgnoreVision";
  private const string Str_IgnoreWeapon = "IgnoreWeapon";
  private const string Str_IgnoreBlood = "IgnoreBlood";
  private const string Str_IgnoreClass = "IgnoreClass";
  private const string Str_IgnoreMoney = "IgnoreMoney";
  private const string Str_IgnorePhoto = "IgnorePhoto";
  private const string Str_IgnoreClub = "IgnoreClub";
  private const string Str_IgnoreInfo = "IgnoreInfo";
  private const string Str_IgnorePool = "IgnorePool";
  private const string Str_IgnoreRep = "IgnoreClass";

  public static bool IgnoreDistraction
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreDistraction");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreDistraction", value);
  }

  public static bool IgnoreClothing
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClothing");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClothing", value);
  }

  public static bool IgnoreCouncil
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreCouncil");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreCouncil", value);
  }

  public static bool IgnoreTeacher
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreTeacher");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreTeacher", value);
  }

  public static bool IgnorePersona
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePersona");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePersona", value);
  }

  public static bool IgnoreLocker
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreLocker");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreLocker", value);
  }

  public static bool IgnorePolice
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePolice");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePolice", value);
  }

  public static bool IgnoreSanity
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreSanity");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreSanity", value);
  }

  public static bool IgnoreSenpai
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreSenpai");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreSenpai", value);
  }

  public static bool IgnoreVision
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreVision");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreVision", value);
  }

  public static bool IgnoreWeapon
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreWeapon");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreWeapon", value);
  }

  public static bool IgnoreBlood
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreBlood");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreBlood", value);
  }

  public static bool IgnoreClass
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClass");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClass", value);
  }

  public static bool IgnoreMoney
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreMoney");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreMoney", value);
  }

  public static bool IgnorePhoto
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePhoto");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePhoto", value);
  }

  public static bool IgnoreClub
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClub");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClub", value);
  }

  public static bool IgnoreInfo
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreInfo");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreInfo", value);
  }

  public static bool IgnorePool
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePool");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePool", value);
  }

  public static bool IgnoreRep
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClass");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClass", value);
  }

  public static void DeleteAll()
  {
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreDistraction");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClothing");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreCouncil");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreTeacher");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePersona");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreLocker");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePolice");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreSanity");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreSenpai");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreVision");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreWeapon");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreBlood");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClass");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreMoney");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePhoto");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClub");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreInfo");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePool");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClass");
  }
}
