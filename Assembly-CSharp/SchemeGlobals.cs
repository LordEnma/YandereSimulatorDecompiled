// Decompiled with JetBrains decompiler
// Type: SchemeGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class SchemeGlobals
{
  private const string Str_CurrentScheme = "CurrentScheme";
  private const string Str_EmbarassingSecret = "EmbarassingSecret";
  private const string Str_HelpingKokona = "HelpingKokona";
  private const string Str_SchemePreviousStage = "SchemePreviousStage_";
  private const string Str_SchemeStage = "SchemeStage_";
  private const string Str_SchemeStatus = "SchemeStatus_";
  private const string Str_SchemeUnlocked = "SchemeUnlocked_";
  private const string Str_ServicePurchased = "ServicePurchased_";

  public static int CurrentScheme
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CurrentScheme");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CurrentScheme", value);
  }

  public static bool EmbarassingSecret
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_EmbarassingSecret");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_EmbarassingSecret", value);
  }

  public static bool HelpingKokona
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HelpingKokona");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HelpingKokona", value);
  }

  public static int GetSchemePreviousStage(int schemeID) => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + schemeID.ToString());

  public static void SetSchemePreviousStage(int schemeID, int value)
  {
    string id = schemeID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_", id);
    PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + id, value);
  }

  public static int[] KeysOfSchemePreviousStage() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_");

  public static int GetSchemeStage(int schemeID) => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + schemeID.ToString());

  public static void SetSchemeStage(int schemeID, int value)
  {
    string id = schemeID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_", id);
    PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + id, value);
  }

  public static int[] KeysOfSchemeStage() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_");

  public static bool GetSchemeStatus(int schemeID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + schemeID.ToString());

  public static void SetSchemeStatus(int schemeID, bool value)
  {
    string id = schemeID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + id, value);
  }

  public static int[] KeysOfSchemeStatus() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_");

  public static bool GetSchemeUnlocked(int schemeID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + schemeID.ToString());

  public static void SetSchemeUnlocked(int schemeID, bool value)
  {
    string id = schemeID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + id, value);
  }

  public static int[] KeysOfSchemeUnlocked() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_");

  public static bool GetServicePurchased(int serviceID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + serviceID.ToString());

  public static void SetServicePurchased(int serviceID, bool value)
  {
    string id = serviceID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + id, value);
  }

  public static int[] KeysOfServicePurchased() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_");

  public static void DeleteAll()
  {
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentScheme");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_EmbarassingSecret");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_HelpingKokona");
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_", SchemeGlobals.KeysOfSchemePreviousStage());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_", SchemeGlobals.KeysOfSchemeStage());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_", SchemeGlobals.KeysOfSchemeStatus());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_", SchemeGlobals.KeysOfSchemeUnlocked());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_", SchemeGlobals.KeysOfServicePurchased());
  }
}
