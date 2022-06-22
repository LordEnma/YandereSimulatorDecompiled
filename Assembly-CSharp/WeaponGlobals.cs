// Decompiled with JetBrains decompiler
// Type: WeaponGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class WeaponGlobals
{
  private const string Str_WeaponStatus = "WeaponStatus_";

  public static int GetWeaponStatus(int weaponID) => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + weaponID.ToString());

  public static void SetWeaponStatus(int weaponID, int value)
  {
    string id = weaponID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", id);
    PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + id, value);
  }

  public static int[] KeysOfWeaponStatus() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_");

  public static void DeleteAll() => Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", WeaponGlobals.KeysOfWeaponStatus());
}
