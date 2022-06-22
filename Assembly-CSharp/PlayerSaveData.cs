// Decompiled with JetBrains decompiler
// Type: PlayerSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerSaveData
{
  public int alerts;
  public int enlightenment;
  public int enlightenmentBonus;
  public bool headset;
  public int kills;
  public int numbness;
  public int numbnessBonus;
  public int pantiesEquipped;
  public int pantyShots;
  public IntHashSet photo = new IntHashSet();
  public IntHashSet photoOnCorkboard = new IntHashSet();
  public IntAndVector2Dictionary photoPosition = new IntAndVector2Dictionary();
  public IntAndFloatDictionary photoRotation = new IntAndFloatDictionary();
  public float reputation;
  public int seduction;
  public int seductionBonus;
  public IntHashSet senpaiPhoto = new IntHashSet();
  public int senpaiShots;
  public int socialBonus;
  public int speedBonus;
  public int stealthBonus;
  public IntHashSet studentFriend = new IntHashSet();
  public IntHashSet studentPantyShot = new IntHashSet();

  public static PlayerSaveData ReadFromGlobals()
  {
    PlayerSaveData playerSaveData = new PlayerSaveData();
    playerSaveData.alerts = PlayerGlobals.Alerts;
    playerSaveData.enlightenment = PlayerGlobals.Enlightenment;
    playerSaveData.enlightenmentBonus = PlayerGlobals.EnlightenmentBonus;
    playerSaveData.headset = PlayerGlobals.Headset;
    playerSaveData.kills = PlayerGlobals.Kills;
    playerSaveData.numbness = PlayerGlobals.Numbness;
    playerSaveData.numbnessBonus = PlayerGlobals.NumbnessBonus;
    playerSaveData.pantiesEquipped = PlayerGlobals.PantiesEquipped;
    playerSaveData.pantyShots = PlayerGlobals.PantyShots;
    foreach (int photoID in PlayerGlobals.KeysOfPhoto())
    {
      if (PlayerGlobals.GetPhoto(photoID))
        playerSaveData.photo.Add(photoID);
    }
    foreach (int photoID in PlayerGlobals.KeysOfPhotoOnCorkboard())
    {
      if (PlayerGlobals.GetPhotoOnCorkboard(photoID))
        playerSaveData.photoOnCorkboard.Add(photoID);
    }
    foreach (int num in PlayerGlobals.KeysOfPhotoPosition())
      playerSaveData.photoPosition.Add(num, PlayerGlobals.GetPhotoPosition(num));
    foreach (int num in PlayerGlobals.KeysOfPhotoRotation())
      playerSaveData.photoRotation.Add(num, PlayerGlobals.GetPhotoRotation(num));
    playerSaveData.reputation = PlayerGlobals.Reputation;
    playerSaveData.seduction = PlayerGlobals.Seduction;
    playerSaveData.seductionBonus = PlayerGlobals.SeductionBonus;
    foreach (int photoID in PlayerGlobals.KeysOfSenpaiPhoto())
    {
      if (PlayerGlobals.GetSenpaiPhoto(photoID))
        playerSaveData.senpaiPhoto.Add(photoID);
    }
    playerSaveData.senpaiShots = PlayerGlobals.SenpaiShots;
    playerSaveData.socialBonus = PlayerGlobals.SocialBonus;
    playerSaveData.speedBonus = PlayerGlobals.SpeedBonus;
    playerSaveData.stealthBonus = PlayerGlobals.StealthBonus;
    foreach (int studentID in PlayerGlobals.KeysOfStudentFriend())
    {
      if (PlayerGlobals.GetStudentFriend(studentID))
        playerSaveData.studentFriend.Add(studentID);
    }
    foreach (int studentID in PlayerGlobals.KeysOfStudentPantyShot())
    {
      if (PlayerGlobals.GetStudentPantyShot(studentID))
        playerSaveData.studentPantyShot.Add(studentID);
    }
    return playerSaveData;
  }

  public static void WriteToGlobals(PlayerSaveData data)
  {
    PlayerGlobals.Alerts = data.alerts;
    PlayerGlobals.Enlightenment = data.enlightenment;
    PlayerGlobals.EnlightenmentBonus = data.enlightenmentBonus;
    PlayerGlobals.Headset = data.headset;
    PlayerGlobals.Kills = data.kills;
    PlayerGlobals.Numbness = data.numbness;
    PlayerGlobals.NumbnessBonus = data.numbnessBonus;
    PlayerGlobals.PantiesEquipped = data.pantiesEquipped;
    PlayerGlobals.PantyShots = data.pantyShots;
    Debug.Log((object) "Is this being called anywhere?");
    foreach (int photoID in (HashSet<int>) data.photo)
      PlayerGlobals.SetPhoto(photoID, true);
    foreach (int photoID in (HashSet<int>) data.photoOnCorkboard)
      PlayerGlobals.SetPhotoOnCorkboard(photoID, true);
    foreach (KeyValuePair<int, Vector2> keyValuePair in (Dictionary<int, Vector2>) data.photoPosition)
      PlayerGlobals.SetPhotoPosition(keyValuePair.Key, keyValuePair.Value);
    foreach (KeyValuePair<int, float> keyValuePair in (Dictionary<int, float>) data.photoRotation)
      PlayerGlobals.SetPhotoRotation(keyValuePair.Key, keyValuePair.Value);
    PlayerGlobals.Reputation = data.reputation;
    PlayerGlobals.Seduction = data.seduction;
    PlayerGlobals.SeductionBonus = data.seductionBonus;
    foreach (int photoID in (HashSet<int>) data.senpaiPhoto)
      PlayerGlobals.SetSenpaiPhoto(photoID, true);
    PlayerGlobals.SenpaiShots = data.senpaiShots;
    PlayerGlobals.SocialBonus = data.socialBonus;
    PlayerGlobals.SpeedBonus = data.speedBonus;
    PlayerGlobals.StealthBonus = data.stealthBonus;
    foreach (int studentID in (HashSet<int>) data.studentFriend)
      PlayerGlobals.SetStudentFriend(studentID, true);
    foreach (int studentID in (HashSet<int>) data.studentPantyShot)
      PlayerGlobals.SetStudentPantyShot(studentID, true);
  }
}
