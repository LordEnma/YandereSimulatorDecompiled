// Decompiled with JetBrains decompiler
// Type: SaveFileSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public class SaveFileSaveData
{
  public int currentSaveFile;

  public static SaveFileSaveData ReadFromGlobals() => new SaveFileSaveData()
  {
    currentSaveFile = SaveFileGlobals.CurrentSaveFile
  };

  public static void WriteToGlobals(SaveFileSaveData data) => SaveFileGlobals.CurrentSaveFile = data.currentSaveFile;
}
