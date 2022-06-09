// Decompiled with JetBrains decompiler
// Type: ClubGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

public static class ClubGlobals
{
  private const string Str_Club = "Club";
  private const string Str_ClubClosed = "ClubClosed_";
  private const string Str_ClubKicked = "ClubKicked_";
  private const string Str_QuitClub = "QuitClub_";

  public static ClubType Club
  {
    get => GlobalsHelper.GetEnum<ClubType>("Profile_" + GameGlobals.Profile.ToString() + "_Club");
    set => GlobalsHelper.SetEnum<ClubType>("Profile_" + GameGlobals.Profile.ToString() + "_Club", value);
  }

  public static bool GetClubClosed(ClubType clubID)
  {
    int num = GameGlobals.Profile;
    string str1 = num.ToString();
    num = (int) clubID;
    string str2 = num.ToString();
    return GlobalsHelper.GetBool("Profile_" + str1 + "_ClubClosed_" + str2);
  }

  public static void SetClubClosed(ClubType clubID, bool value)
  {
    string id = ((int) clubID).ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ClubClosed_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ClubClosed_" + id, value);
  }

  public static ClubType[] KeysOfClubClosed() => KeysHelper.GetEnumKeys<ClubType>("Profile_" + GameGlobals.Profile.ToString() + "_ClubClosed_");

  public static bool GetClubKicked(ClubType clubID)
  {
    int num = GameGlobals.Profile;
    string str1 = num.ToString();
    num = (int) clubID;
    string str2 = num.ToString();
    return GlobalsHelper.GetBool("Profile_" + str1 + "_ClubKicked_" + str2);
  }

  public static void SetClubKicked(ClubType clubID, bool value)
  {
    string id = ((int) clubID).ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ClubKicked_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ClubKicked_" + id, value);
  }

  public static ClubType[] KeysOfClubKicked() => KeysHelper.GetEnumKeys<ClubType>("Profile_" + GameGlobals.Profile.ToString() + "_ClubKicked_");

  public static bool GetQuitClub(ClubType clubID)
  {
    int num = GameGlobals.Profile;
    string str1 = num.ToString();
    num = (int) clubID;
    string str2 = num.ToString();
    return GlobalsHelper.GetBool("Profile_" + str1 + "_QuitClub_" + str2);
  }

  public static void SetQuitClub(ClubType clubID, bool value)
  {
    string id = ((int) clubID).ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_QuitClub_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_QuitClub_" + id, value);
  }

  public static ClubType[] KeysOfQuitClub() => KeysHelper.GetEnumKeys<ClubType>("Profile_" + GameGlobals.Profile.ToString() + "_QuitClub_");

  public static void DeleteAll()
  {
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Club");
    int num;
    foreach (ClubType clubType in ClubGlobals.KeysOfClubClosed())
    {
      num = GameGlobals.Profile;
      string str1 = num.ToString();
      num = (int) clubType;
      string str2 = num.ToString();
      Globals.Delete("Profile_" + str1 + "_ClubClosed_" + str2);
    }
    foreach (ClubType clubType in ClubGlobals.KeysOfClubKicked())
    {
      num = GameGlobals.Profile;
      string str3 = num.ToString();
      num = (int) clubType;
      string str4 = num.ToString();
      Globals.Delete("Profile_" + str3 + "_ClubKicked_" + str4);
    }
    foreach (ClubType clubType in ClubGlobals.KeysOfQuitClub())
    {
      num = GameGlobals.Profile;
      string str5 = num.ToString();
      num = (int) clubType;
      string str6 = num.ToString();
      Globals.Delete("Profile_" + str5 + "_QuitClub_" + str6);
    }
    KeysHelper.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ClubClosed_");
    int profile = GameGlobals.Profile;
    KeysHelper.Delete("Profile_" + profile.ToString() + "_ClubKicked_");
    profile = GameGlobals.Profile;
    KeysHelper.Delete("Profile_" + profile.ToString() + "_QuitClub_");
  }
}
