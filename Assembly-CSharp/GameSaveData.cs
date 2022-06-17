// Decompiled with JetBrains decompiler
// Type: GameSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public class GameSaveData
{
  public bool loveSick;
  public bool masksBanned;
  public bool paranormal;

  public static GameSaveData ReadFromGlobals() => new GameSaveData()
  {
    loveSick = GameGlobals.LoveSick,
    masksBanned = GameGlobals.MasksBanned,
    paranormal = GameGlobals.Paranormal
  };

  public static void WriteToGlobals(GameSaveData data)
  {
    GameGlobals.LoveSick = data.loveSick;
    GameGlobals.MasksBanned = data.masksBanned;
    GameGlobals.Paranormal = data.paranormal;
  }
}
