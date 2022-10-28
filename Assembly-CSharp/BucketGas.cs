// Decompiled with JetBrains decompiler
// Type: BucketGas
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
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
