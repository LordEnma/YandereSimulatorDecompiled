// Decompiled with JetBrains decompiler
// Type: YanvaniaGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

public static class YanvaniaGlobals
{
  private const string Str_DraculaDefeated = "DraculaDefeated";
  private const string Str_MidoriEasterEgg = "MidoriEasterEgg";

  public static bool DraculaDefeated
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated", value);
  }

  public static bool MidoriEasterEgg
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg", value);
  }

  public static void DeleteAll()
  {
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg");
  }
}
