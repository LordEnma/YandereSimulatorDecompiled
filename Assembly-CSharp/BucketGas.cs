// Decompiled with JetBrains decompiler
// Type: BucketGas
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public class BucketGas : BucketContents
{
  public override BucketContentsType Type => BucketContentsType.Gas;

  public override bool IsCleaningAgent => false;

  public override bool IsFlammable => true;

  public override bool CanBeLifted(int strength) => true;
}
