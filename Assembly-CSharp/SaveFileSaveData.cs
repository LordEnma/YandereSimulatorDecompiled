// Decompiled with JetBrains decompiler
// Type: SaveFileSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
