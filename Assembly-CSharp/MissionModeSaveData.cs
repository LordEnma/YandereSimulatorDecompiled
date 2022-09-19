// Decompiled with JetBrains decompiler
// Type: MissionModeSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

[Serializable]
public class MissionModeSaveData
{
  public IntAndIntDictionary missionCondition = new IntAndIntDictionary();
  public int missionDifficulty;
  public bool missionMode;
  public int missionRequiredClothing;
  public int missionRequiredDisposal;
  public int missionRequiredWeapon;
  public int missionTarget;
  public string missionTargetName = string.Empty;
  public int nemesisDifficulty;

  public static MissionModeSaveData ReadFromGlobals()
  {
    MissionModeSaveData missionModeSaveData = new MissionModeSaveData();
    foreach (int num in MissionModeGlobals.KeysOfMissionCondition())
      missionModeSaveData.missionCondition.Add(num, MissionModeGlobals.GetMissionCondition(num));
    missionModeSaveData.missionDifficulty = MissionModeGlobals.MissionDifficulty;
    missionModeSaveData.missionMode = MissionModeGlobals.MissionMode;
    missionModeSaveData.missionRequiredClothing = MissionModeGlobals.MissionRequiredClothing;
    missionModeSaveData.missionRequiredDisposal = MissionModeGlobals.MissionRequiredDisposal;
    missionModeSaveData.missionRequiredWeapon = MissionModeGlobals.MissionRequiredWeapon;
    missionModeSaveData.missionTarget = MissionModeGlobals.MissionTarget;
    missionModeSaveData.missionTargetName = MissionModeGlobals.MissionTargetName;
    missionModeSaveData.nemesisDifficulty = MissionModeGlobals.NemesisDifficulty;
    return missionModeSaveData;
  }

  public static void WriteToGlobals(MissionModeSaveData data)
  {
    foreach (KeyValuePair<int, int> keyValuePair in (Dictionary<int, int>) data.missionCondition)
      MissionModeGlobals.SetMissionCondition(keyValuePair.Key, keyValuePair.Value);
    MissionModeGlobals.MissionDifficulty = data.missionDifficulty;
    MissionModeGlobals.MissionMode = data.missionMode;
    MissionModeGlobals.MissionRequiredClothing = data.missionRequiredClothing;
    MissionModeGlobals.MissionRequiredDisposal = data.missionRequiredDisposal;
    MissionModeGlobals.MissionRequiredWeapon = data.missionRequiredWeapon;
    MissionModeGlobals.MissionTarget = data.missionTarget;
    MissionModeGlobals.MissionTargetName = data.missionTargetName;
    MissionModeGlobals.NemesisDifficulty = data.nemesisDifficulty;
  }
}
