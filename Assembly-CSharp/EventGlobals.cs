// Decompiled with JetBrains decompiler
// Type: EventGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

public static class EventGlobals
{
  private const string Str_BefriendConversation = "BefriendConversation";
  private const string Str_StalkerConversation = "StalkerConversation";
  private const string Str_KidnapConversation = "KidnapConversation";
  private const string Str_OsanaConversation = "OsanaConversation";
  private const string Str_Event1 = "Event1";
  private const string Str_Event2 = "Event2";
  private const string Str_OsanaEvent1 = "OsanaEvent1";
  private const string Str_OsanaEvent2 = "OsanaEvent2";
  private const string Str_LivingRoom = "LivingRoom";
  private const string Str_LearnedAboutPhotographer = "LearnedAboutPhotographer";

  public static bool BefriendConversation
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BefriendConversation");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BefriendConversation", value);
  }

  public static bool StalkerConversation
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StalkerConversation");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StalkerConversation", value);
  }

  public static bool KidnapConversation
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_KidnapConversation");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_KidnapConversation", value);
  }

  public static bool OsanaConversation
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_OsanaConversation");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_OsanaConversation", value);
  }

  public static bool OsanaEvent1
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_OsanaEvent1");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_OsanaEvent1", value);
  }

  public static bool OsanaEvent2
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_OsanaEvent2");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_OsanaEvent2", value);
  }

  public static bool Event1
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Event1");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Event1", value);
  }

  public static bool Event2
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Event2");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Event2", value);
  }

  public static bool LivingRoom
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_LivingRoom");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_LivingRoom", value);
  }

  public static bool LearnedAboutPhotographer
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_LearnedAboutPhotographer");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_LearnedAboutPhotographer", value);
  }

  public static void DeleteAll()
  {
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BefriendConversation");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StalkerConversation");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_KidnapConversation");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_OsanaConversation");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_OsanaEvent1");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_OsanaEvent2");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Event1");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Event2");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LivingRoom");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LearnedAboutPhotographer");
  }
}
