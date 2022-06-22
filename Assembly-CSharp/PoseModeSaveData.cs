// Decompiled with JetBrains decompiler
// Type: PoseModeSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public class PoseModeSaveData
{
  public Vector3 posePosition;
  public Vector3 poseRotation;
  public Vector3 poseScale;

  public static PoseModeSaveData ReadFromGlobals() => new PoseModeSaveData()
  {
    posePosition = PoseModeGlobals.PosePosition,
    poseRotation = PoseModeGlobals.PoseRotation,
    poseScale = PoseModeGlobals.PoseScale
  };

  public static void WriteToGlobals(PoseModeSaveData data)
  {
    PoseModeGlobals.PosePosition = data.posePosition;
    PoseModeGlobals.PoseRotation = data.poseRotation;
    PoseModeGlobals.PoseScale = data.poseScale;
  }
}
