// Decompiled with JetBrains decompiler
// Type: BucketWeights
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public class BucketWeights : BucketContents
{
  [SerializeField]
  private int count;

  public int Count
  {
    get => this.count;
    set => this.count = value < 0 ? 0 : value;
  }

  public override BucketContentsType Type => BucketContentsType.Weights;

  public override bool IsCleaningAgent => false;

  public override bool IsFlammable => false;

  public override bool CanBeLifted(int strength) => strength > 0;
}
