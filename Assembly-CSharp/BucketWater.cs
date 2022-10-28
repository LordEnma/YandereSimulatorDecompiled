// Decompiled with JetBrains decompiler
// Type: BucketWater
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public class BucketWater : BucketContents
{
  [SerializeField]
  private float bloodiness;
  [SerializeField]
  private bool hasBleach;

  public float Bloodiness
  {
    get => this.bloodiness;
    set => this.bloodiness = Mathf.Clamp01(value);
  }

  public bool HasBleach
  {
    get => this.hasBleach;
    set => this.hasBleach = value;
  }

  public override BucketContentsType Type => BucketContentsType.Water;

  public override bool IsCleaningAgent => this.hasBleach;

  public override bool IsFlammable => false;

  public override bool CanBeLifted(int strength) => true;
}
