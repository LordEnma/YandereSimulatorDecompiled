// Decompiled with JetBrains decompiler
// Type: PlayerGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class PlayerGlobals
{
  private const string Str_Money = "Money";
  private const string Str_Alerts = "Alerts";
  private const string Str_BullyPhoto = "BullyPhoto_";
  private const string Str_Enlightenment = "Enlightenment";
  private const string Str_EnlightenmentBonus = "EnlightenmentBonus";
  private const string Str_Friends = "Friends";
  private const string Str_Headset = "Headset";
  private const string Str_DirectionalMic = "DirectionalMic";
  private const string Str_FakeID = "FakeID";
  private const string Str_RaibaruLoner = "RaibaruLoner";
  private const string Str_Kills = "Kills";
  private const string Str_CorpsesDiscovered = "CorpsesDiscovered";
  private const string Str_Numbness = "Numbness";
  private const string Str_NumbnessBonus = "NumbnessBonus";
  private const string Str_PantiesEquipped = "PantiesEquipped";
  private const string Str_PantyShots = "PantyShots";
  private const string Str_Photo = "Photo_";
  private const string Str_PhotoOnCorkboard = "PhotoOnCorkboard_";
  private const string Str_PhotoPosition = "PhotoPosition_";
  private const string Str_PhotoRotation = "PhotoRotation_";
  private const string Str_Reputation = "Reputation";
  private const string Str_Seduction = "Seduction";
  private const string Str_SeductionBonus = "SeductionBonus";
  private const string Str_SenpaiPhoto = "SenpaiPhoto_";
  private const string Str_SenpaiShots = "SenpaiShots";
  private const string Str_SenpaiShotsTexted = "SenpaiShotsTexted";
  private const string Str_SocialBonus = "SocialBonus";
  private const string Str_SpeedBonus = "SpeedBonus";
  private const string Str_StealthBonus = "StealthBonus";
  private const string Str_StudentFriend = "StudentFriend_";
  private const string Str_StudentPantyShot = "StudentPantyShot_";
  private const string Str_ShrineCollectible = "ShrineCollectible_";
  private const string Str_UsingGamepad = "UsingGamepad";
  private const string Str_PersonaID = "PersonaID";
  private const string Str_ShrineItems = "ShrineItems";
  private const string Str_BringingItem = "BringingItem";
  private const string Str_CannotBringItem = "CannotBringItem";
  private const string Str_BoughtLockpick = "BoughtLockpick";
  private const string Str_BoughtSedative = "BoughtSedative";
  private const string Str_BoughtNarcotics = "BoughtNarcotics";
  private const string Str_BoughtPoison = "BoughtPoison";
  private const string Str_BoughtExplosive = "BoughtExplosive";
  private const string Str_PoliceVisits = "PoliceVisits";
  private const string Str_BloodWitnessed = "BloodWitnessed";
  private const string Str_WeaponWitnessed = "WeaponWitnessed";

  public static float Money
  {
    get => PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_Money");
    set => PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_Money", value);
  }

  public static int Alerts
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Alerts");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Alerts", value);
  }

  public static int Enlightenment
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Enlightenment");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Enlightenment", value);
  }

  public static int EnlightenmentBonus
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_EnlightenmentBonus");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_EnlightenmentBonus", value);
  }

  public static int Friends
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Friends");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Friends", value);
  }

  public static bool Headset
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Headset");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Headset", value);
  }

  public static bool DirectionalMic
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DirectionalMic");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DirectionalMic", value);
  }

  public static bool FakeID
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_FakeID");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_FakeID", value);
  }

  public static bool RaibaruLoner
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_RaibaruLoner");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_RaibaruLoner", value);
  }

  public static int Kills
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Kills");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Kills", value);
  }

  public static int CorpsesDiscovered
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CorpsesDiscovered");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CorpsesDiscovered", value);
  }

  public static int Numbness
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Numbness");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Numbness", value);
  }

  public static int NumbnessBonus
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_NumbnessBonus");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_NumbnessBonus", value);
  }

  public static int PantiesEquipped
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PantiesEquipped");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PantiesEquipped", value);
  }

  public static int PantyShots
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PantyShots");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PantyShots", value);
  }

  public static bool GetPhoto(int photoID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Photo_" + photoID.ToString());

  public static void SetPhoto(int photoID, bool value)
  {
    string id = photoID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_Photo_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Photo_" + id, value);
  }

  public static int[] KeysOfPhoto() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_Photo_");

  public static bool GetPhotoOnCorkboard(int photoID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_" + photoID.ToString());

  public static void SetPhotoOnCorkboard(int photoID, bool value)
  {
    string id = photoID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_" + id, value);
  }

  public static int[] KeysOfPhotoOnCorkboard() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_");

  public static Vector2 GetPhotoPosition(int photoID) => GlobalsHelper.GetVector2("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_" + photoID.ToString());

  public static void SetPhotoPosition(int photoID, Vector2 value)
  {
    string id = photoID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_", id);
    GlobalsHelper.SetVector2("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_" + id, value);
  }

  public static int[] KeysOfPhotoPosition() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_");

  public static float GetPhotoRotation(int photoID) => PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_" + photoID.ToString());

  public static void SetPhotoRotation(int photoID, float value)
  {
    string id = photoID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_", id);
    PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_" + id, value);
  }

  public static int[] KeysOfPhotoRotation() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_");

  public static float Reputation
  {
    get => PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_Reputation");
    set => PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_Reputation", value);
  }

  public static int Seduction
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Seduction");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Seduction", value);
  }

  public static int SeductionBonus
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SeductionBonus");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SeductionBonus", value);
  }

  public static bool GetSenpaiPhoto(int photoID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_" + photoID.ToString());

  public static void SetSenpaiPhoto(int photoID, bool value)
  {
    string id = photoID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_" + id, value);
  }

  public static int GetBullyPhoto(int photoID) => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_" + photoID.ToString());

  public static void SetBullyPhoto(int photoID, int value)
  {
    string id = photoID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_", id);
    PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_" + id, value);
  }

  public static int[] KeysOfBullyPhoto() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_");

  public static int[] KeysOfSenpaiPhoto() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_");

  public static int SenpaiShots
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiShots");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiShots", value);
  }

  public static int SenpaiShotsTexted
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiShotsTexted");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiShotsTexted", value);
  }

  public static int SocialBonus
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SocialBonus");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SocialBonus", value);
  }

  public static int SpeedBonus
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpeedBonus");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpeedBonus", value);
  }

  public static int StealthBonus
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_StealthBonus");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_StealthBonus", value);
  }

  public static bool GetStudentFriend(int studentID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_" + studentID.ToString());

  public static void SetStudentFriend(int studentID, bool value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_" + id, value);
  }

  public static int[] KeysOfStudentFriend() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_");

  public static bool GetStudentPantyShot(int studentID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_" + studentID.ToString());

  public static void SetStudentPantyShot(int studentID, bool value)
  {
    string id = studentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_" + id, value);
  }

  public static int[] KeysOfStudentPantyShot() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_");

  public static string[] KeysOfShrineCollectible() => KeysHelper.GetStringKeys("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_");

  public static bool GetShrineCollectible(int ID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_" + ID.ToString());

  public static void SetShrineCollectible(int ID, bool value)
  {
    string id = ID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_" + id, value);
  }

  public static bool UsingGamepad
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_UsingGamepad");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_UsingGamepad", value);
  }

  public static int PersonaID
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PersonaID");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PersonaID", value);
  }

  public static int ShrineItems
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_ShrineItems");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_ShrineItems", value);
  }

  public static int BringingItem
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BringingItem");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BringingItem", value);
  }

  public static string[] KeysOfCannotBringItem() => KeysHelper.GetStringKeys("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem");

  public static bool GetCannotBringItem(int ID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem" + ID.ToString());

  public static void SetCannotBringItem(int ID, bool value)
  {
    string id = ID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem" + id, value);
  }

  public static bool BoughtLockpick
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtLockpick");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtLockpick", value);
  }

  public static bool BoughtSedative
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtSedative");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtSedative", value);
  }

  public static bool BoughtNarcotics
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtNarcotics");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtNarcotics", value);
  }

  public static bool BoughtPoison
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtPoison");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtPoison", value);
  }

  public static bool BoughtExplosive
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtExplosive");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtExplosive", value);
  }

  public static int PoliceVisits
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PoliceVisits");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PoliceVisits", value);
  }

  public static int BloodWitnessed
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BloodWitnessed");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BloodWitnessed", value);
  }

  public static int WeaponWitnessed
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponWitnessed");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponWitnessed", value);
  }

  public static void DeleteAll()
  {
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Money");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Alerts");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Enlightenment");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_EnlightenmentBonus");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Friends");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Headset");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DirectionalMic");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_FakeID");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_RaibaruLoner");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Kills");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CorpsesDiscovered");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Numbness");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_NumbnessBonus");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PantiesEquipped");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PantyShots");
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_Photo_", PlayerGlobals.KeysOfPhoto());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_", PlayerGlobals.KeysOfPhotoOnCorkboard());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_", PlayerGlobals.KeysOfPhotoPosition());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_", PlayerGlobals.KeysOfPhotoRotation());
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Reputation");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Seduction");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SeductionBonus");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiShots");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiShotsTexted");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SocialBonus");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SpeedBonus");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StealthBonus");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PersonaID");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ShrineItems");
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_", PlayerGlobals.KeysOfBullyPhoto());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_", PlayerGlobals.KeysOfSenpaiPhoto());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_", PlayerGlobals.KeysOfStudentFriend());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_", PlayerGlobals.KeysOfStudentPantyShot());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_", PlayerGlobals.KeysOfShrineCollectible());
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BringingItem");
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem", PlayerGlobals.KeysOfCannotBringItem());
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BoughtLockpick");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BoughtSedative");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BoughtNarcotics");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BoughtPoison");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BoughtExplosive");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PoliceVisits");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BloodWitnessed");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_WeaponWitnessed");
  }
}
