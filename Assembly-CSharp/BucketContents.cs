// Decompiled with JetBrains decompiler
// Type: BucketContents
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

public abstract class BucketContents
{
  public abstract BucketContentsType Type { get; }

  public abstract bool IsCleaningAgent { get; }

  public abstract bool IsFlammable { get; }

  public abstract bool CanBeLifted(int strength);
}
