// Decompiled with JetBrains decompiler
// Type: SenpaiGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class SenpaiGlobals
{
  private const string Str_CustomSenpai = "CustomSenpai";
  private const string Str_SenpaiEyeColor = "SenpaiEyeColor";
  private const string Str_SenpaiEyeWear = "SenpaiEyeWear";
  private const string Str_SenpaiFacialHair = "SenpaiFacialHair";
  private const string Str_SenpaiHairColor = "SenpaiHairColor";
  private const string Str_SenpaiHairStyle = "SenpaiHairStyle";
  private const string Str_SenpaiSkinColor = "SenpaiSkinColor";

  public static bool CustomSenpai
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSenpai");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSenpai", value);
  }

  public static string SenpaiEyeColor
  {
    get => PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiEyeColor");
    set => PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiEyeColor", value);
  }

  public static int SenpaiEyeWear
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiEyeWear");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiEyeWear", value);
  }

  public static int SenpaiFacialHair
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiFacialHair");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiFacialHair", value);
  }

  public static string SenpaiHairColor
  {
    get => PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiHairColor");
    set => PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiHairColor", value);
  }

  public static int SenpaiHairStyle
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiHairStyle");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiHairStyle", value);
  }

  public static int SenpaiSkinColor
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiSkinColor");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiSkinColor", value);
  }

  public static void DeleteAll()
  {
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSenpai");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiEyeColor");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiEyeWear");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiFacialHair");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiHairColor");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiHairStyle");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiSkinColor");
  }
}
