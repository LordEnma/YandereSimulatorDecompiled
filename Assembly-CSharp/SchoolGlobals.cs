// Decompiled with JetBrains decompiler
// Type: SchoolGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class SchoolGlobals
{
  private const string Str_DemonActive = "DemonActive_";
  private const string Str_GardenGraveOccupied = "GardenGraveOccupied_";
  private const string Str_KidnapVictim = "KidnapVictim";
  private const string Str_Population = "Population";
  private const string Str_RoofFence = "RoofFence";
  private const string Str_SchoolAtmosphere = "SchoolAtmosphere";
  private const string Str_SchoolAtmosphereSet = "SchoolAtmosphereSet";
  private const string Str_PreviousSchoolAtmosphere = "PreviousSchoolAtmosphere";
  private const string Str_ReactedToGameLeader = "ReactedToGameLeader";
  private const string Str_SCP = "SCP";
  private const string Str_HighSecurity = "HighSecurity";

  public static bool GetDemonActive(int demonID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + demonID.ToString());

  public static void SetDemonActive(int demonID, bool value)
  {
    string id = demonID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + id, value);
  }

  public static int[] KeysOfDemonActive() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_");

  public static bool GetGardenGraveOccupied(int graveID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + graveID.ToString());

  public static void SetGardenGraveOccupied(int graveID, bool value)
  {
    string id = graveID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + id, value);
  }

  public static int[] KeysOfGardenGraveOccupied() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_");

  public static int KidnapVictim
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_KidnapVictim");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_KidnapVictim", value);
  }

  public static int Population
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Population");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Population", value);
  }

  public static bool RoofFence
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_RoofFence");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_RoofFence", value);
  }

  public static float PreviousSchoolAtmosphere
  {
    get => PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_PreviousSchoolAtmosphere");
    set => PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_PreviousSchoolAtmosphere", value);
  }

  public static float SchoolAtmosphere
  {
    get => PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphere");
    set => PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphere", value);
  }

  public static bool SchoolAtmosphereSet
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphereSet");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphereSet", value);
  }

  public static bool ReactedToGameLeader
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReactedToGameLeader");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReactedToGameLeader", value);
  }

  public static bool HighSecurity
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HighSecurity");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HighSecurity", value);
  }

  public static bool SCP
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SCP");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SCP", value);
  }

  public static void DeleteAll()
  {
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_", SchoolGlobals.KeysOfDemonActive());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_", SchoolGlobals.KeysOfGardenGraveOccupied());
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_KidnapVictim");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Population");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_RoofFence");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphere");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphereSet");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PreviousSchoolAtmosphere");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ReactedToGameLeader");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_HighSecurity");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SCP");
  }
}
