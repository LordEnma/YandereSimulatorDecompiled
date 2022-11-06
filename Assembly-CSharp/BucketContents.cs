// Decompiled with JetBrains decompiler
// Type: BucketContents
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

public abstract class BucketContents
{
  public abstract BucketContentsType Type { get; }

  public abstract bool IsCleaningAgent { get; }

  public abstract bool IsFlammable { get; }

  public abstract bool CanBeLifted(int strength);
}
