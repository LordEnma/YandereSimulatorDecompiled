// Decompiled with JetBrains decompiler
// Type: BucketGas
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public class BucketGas : BucketContents
{
  public override BucketContentsType Type => BucketContentsType.Gas;

  public override bool IsCleaningAgent => false;

  public override bool IsFlammable => true;

  public override bool CanBeLifted(int strength) => true;
}
