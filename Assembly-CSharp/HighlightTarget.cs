// Decompiled with JetBrains decompiler
// Type: HighlightTarget
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public struct HighlightTarget
{
  public Color TargetColor;
  [ColorUsage(true, true, 0.0f, 3f, 0.0f, 3f)]
  public Color ReplacementColor;
  [Range(0.0f, 1f)]
  public float Threshold;
  [Range(0.0f, 1f)]
  public float SmoothColorInterpolation;
}
