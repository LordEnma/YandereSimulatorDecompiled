// Decompiled with JetBrains decompiler
// Type: BucketGas
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
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
