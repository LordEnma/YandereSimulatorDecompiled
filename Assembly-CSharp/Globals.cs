// Decompiled with JetBrains decompiler
// Type: Globals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class Globals
{
  public static bool KeyExists(string key) => PlayerPrefs.HasKey(key);

  public static void DeleteAll()
  {
    int profile = GameGlobals.Profile;
    ClassGlobals.DeleteAll();
    ClubGlobals.DeleteAll();
    CollectibleGlobals.DeleteAll();
    ConversationGlobals.DeleteAll();
    DateGlobals.DeleteAll();
    DatingGlobals.DeleteAll();
    EventGlobals.DeleteAll();
    GameGlobals.DeleteAll();
    HomeGlobals.DeleteAll();
    MissionModeGlobals.DeleteAll();
    PlayerGlobals.DeleteAll();
    PoseModeGlobals.DeleteAll();
    SchemeGlobals.DeleteAll();
    SchoolGlobals.DeleteAll();
    SenpaiGlobals.DeleteAll();
    StudentGlobals.DeleteAll();
    TaskGlobals.DeleteAll();
    YanvaniaGlobals.DeleteAll();
    WeaponGlobals.DeleteAll();
    TutorialGlobals.DeleteAll();
    CounselorGlobals.DeleteAll();
    YancordGlobals.DeleteAll();
    CorkboardGlobals.DeleteAll();
    GameGlobals.Profile = profile;
    DateGlobals.Week = 1;
  }

  public static void Delete(string key) => PlayerPrefs.DeleteKey(key);

  public static void DeleteCollection(string key, int[] usedKeys)
  {
    foreach (int usedKey in usedKeys)
      PlayerPrefs.DeleteKey(key + usedKey.ToString());
    KeysHelper.Delete(key);
  }

  public static void DeleteCollection(string key, string[] usedKeys)
  {
    foreach (string usedKey in usedKeys)
      PlayerPrefs.DeleteKey(key + usedKey);
    KeysHelper.Delete(key);
  }

  public static void Save() => PlayerPrefs.Save();
}
