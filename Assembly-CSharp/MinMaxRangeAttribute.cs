// Decompiled with JetBrains decompiler
// Type: MinMaxRangeAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MinMaxRangeAttribute : PropertyAttribute
{
  public float minLimit;
  public float maxLimit;

  public MinMaxRangeAttribute(float minLimit, float maxLimit)
  {
    this.minLimit = minLimit;
    this.maxLimit = maxLimit;
  }
}
