// Decompiled with JetBrains decompiler
// Type: OptionGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class OptionGlobals
{
  private const string Str_DisableBloom = "DisableBloom";
  private const string Str_DisableFarAnimations = "DisableFarAnimations";
  private const string Str_DisableOutlines = "DisableOutlines";
  private const string Str_DisablePostAliasing = "DisablePostAliasing";
  private const string Str_EnableShadows = "EnableShadows";
  private const string Str_DisableObscurance = "DisableObscurance";
  private const string Str_DrawDistance = "DrawDistance";
  private const string Str_DrawDistanceLimit = "DrawDistanceLimit";
  private const string Str_Vsync = "Vsync";
  private const string Str_Fog = "Fog";
  private const string Str_FPSIndex = "FPSIndex";
  private const string Str_HighPopulation = "HighPopulation";
  private const string Str_LowDetailStudents = "LowDetailStudents";
  private const string Str_ParticleCount = "ParticleCount";
  private const string Str_RimLight = "RimLight";
  private const string Str_DepthOfField = "DepthOfField";
  private const string Str_Sensitivity = "Sensitivity";
  private const string Str_InvertAxisX = "InvertAxisX";
  private const string Str_InvertAxisY = "InvertAxisY";
  private const string Str_TutorialsOff = "TutorialsOff";
  private const string Str_HintsOff = "HintsOff";
  private const string Str_CameraPosition = "CameraPosition";
  private const string Str_ToggleRun = "ToggleRun";
  private const string Str_OpaqueWindows = "OpaqueWindows";
  private const string Str_ColorGrading = "ColorGrading";
  private const string Str_ToggleGrass = "ToggleGrass";
  private const string Str_HairPhysics = "HairPhysics";
  private const string Str_MotionBlur = "MotionBlur";
  private const string Str_DisplayFPS = "DisplayFPS";
  private const string Str_SubtitleSize = "SubtitleSize";
  private const string Str_RivalDeathSlowMo = "RivalDeathSlowMo";
  private const string Str_DisableStatic = "DisableStatic";
  private const string Str_DisableDisplacement = "DisableDisplacement";
  private const string Str_DisableAbberation = "DisableAbberation";
  private const string Str_DisableVignette = "DisableVignette";
  private const string Str_DisableDistortion = "DisableDistortion";
  private const string Str_DisableScanlines = "DisableScanlines";
  private const string Str_DisableNoise = "DisableNoise";
  private const string Str_DisableTint = "DisableTint";

  public static bool DisableBloom
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisableBloom");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisableBloom", value);
  }

  public static int DisableFarAnimations
  {
    get => PlayerPrefs.GetInt("Profile_" + 0.ToString() + "_DisableFarAnimations");
    set => PlayerPrefs.SetInt("Profile_" + 0.ToString() + "_DisableFarAnimations", value);
  }

  public static bool DisableOutlines
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisableOutlines");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisableOutlines", value);
  }

  public static bool DisablePostAliasing
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisablePostAliasing");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisablePostAliasing", value);
  }

  public static bool EnableShadows
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_EnableShadows");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_EnableShadows", value);
  }

  public static bool DisableObscurance
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisableObscurance");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisableObscurance", value);
  }

  public static int DrawDistance
  {
    get => PlayerPrefs.GetInt("Profile_" + 0.ToString() + "_DrawDistance");
    set => PlayerPrefs.SetInt("Profile_" + 0.ToString() + "_DrawDistance", value);
  }

  public static int DrawDistanceLimit
  {
    get => PlayerPrefs.GetInt("Profile_" + 0.ToString() + "_DrawDistanceLimit");
    set => PlayerPrefs.SetInt("Profile_" + 0.ToString() + "_DrawDistanceLimit", value);
  }

  public static bool Vsync
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_Vsync");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_Vsync", value);
  }

  public static bool Fog
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_Fog");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_Fog", value);
  }

  public static int FPSIndex
  {
    get => PlayerPrefs.GetInt("Profile_" + 0.ToString() + "_FPSIndex");
    set => PlayerPrefs.SetInt("Profile_" + 0.ToString() + "_FPSIndex", value);
  }

  public static bool HighPopulation
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_HighPopulation");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_HighPopulation", value);
  }

  public static int LowDetailStudents
  {
    get => PlayerPrefs.GetInt("Profile_" + 0.ToString() + "_LowDetailStudents");
    set => PlayerPrefs.SetInt("Profile_" + 0.ToString() + "_LowDetailStudents", value);
  }

  public static int ParticleCount
  {
    get => PlayerPrefs.GetInt("Profile_" + 0.ToString() + "_ParticleCount");
    set => PlayerPrefs.SetInt("Profile_" + 0.ToString() + "_ParticleCount", value);
  }

  public static bool RimLight
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_RimLight");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_RimLight", value);
  }

  public static bool DepthOfField
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DepthOfField");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DepthOfField", value);
  }

  public static bool MotionBlur
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_MotionBlur");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_MotionBlur", value);
  }

  public static int Sensitivity
  {
    get => PlayerPrefs.GetInt("Profile_" + 0.ToString() + "_Sensitivity");
    set => PlayerPrefs.SetInt("Profile_" + 0.ToString() + "_Sensitivity", value);
  }

  public static bool InvertAxisX
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_InvertAxisX");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_InvertAxisX", value);
  }

  public static bool InvertAxisY
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_InvertAxisY");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_InvertAxisY", value);
  }

  public static int SubtitleSize
  {
    get => PlayerPrefs.GetInt("Profile_" + 0.ToString() + "_SubtitleSize");
    set => PlayerPrefs.SetInt("Profile_" + 0.ToString() + "_SubtitleSize", value);
  }

  public static bool RivalDeathSlowMo
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_RivalDeathSlowMo");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_RivalDeathSlowMo", value);
  }

  public static bool TutorialsOff
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_TutorialsOff");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_TutorialsOff", value);
  }

  public static bool HintsOff
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_HintsOff");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_HintsOff", value);
  }

  public static int CameraPosition
  {
    get => PlayerPrefs.GetInt("Profile_" + 0.ToString() + "_CameraPosition");
    set => PlayerPrefs.SetInt("Profile_" + 0.ToString() + "_CameraPosition", value);
  }

  public static bool ToggleRun
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_ToggleRun");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_ToggleRun", value);
  }

  public static bool OpaqueWindows
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_OpaqueWindows");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_OpaqueWindows", value);
  }

  public static bool ColorGrading
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_ColorGrading");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_ColorGrading", value);
  }

  public static bool ToggleGrass
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_ToggleGrass");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_ToggleGrass", value);
  }

  public static bool HairPhysics
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_HairPhysics");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_HairPhysics", value);
  }

  public static bool DisplayFPS
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisplayFPS");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisplayFPS", value);
  }

  public static bool DisableStatic
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisableStatic");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisableStatic", value);
  }

  public static bool DisableDisplacement
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisableDisplacement");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisableDisplacement", value);
  }

  public static bool DisableAbberation
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisableAbberation");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisableAbberation", value);
  }

  public static bool DisableVignette
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisableVignette");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisableVignette", value);
  }

  public static bool DisableDistortion
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisableDistortion");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisableDistortion", value);
  }

  public static bool DisableScanlines
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisableScanlines");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisableScanlines", value);
  }

  public static bool DisableNoise
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisableNoise");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisableNoise", value);
  }

  public static bool DisableTint
  {
    get => GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisableTint");
    set => GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisableTint", value);
  }

  public static void DeleteAll()
  {
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableBloom");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableFarAnimations");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableOutlines");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisablePostAliasing");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_EnableShadows");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableObscurance");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DrawDistance");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DrawDistanceLimit");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Vsync");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Fog");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_FPSIndex");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_HighPopulation");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LowDetailStudents");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ParticleCount");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_RimLight");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DepthOfField");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Sensitivity");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_InvertAxisX");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_InvertAxisY");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TutorialsOff");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_HintsOff");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CameraPosition");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ToggleRun");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_OpaqueWindows");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ColorGrading");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ToggleGrass");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_HairPhysics");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MotionBlur");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisplayFPS");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SubtitleSize");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_RivalDeathSlowMo");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableStatic");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableDisplacement");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableAbberation");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableVignette");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableDistortion");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableScanlines");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableNoise");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableTint");
  }
}
