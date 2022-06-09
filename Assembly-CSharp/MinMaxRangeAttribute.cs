// Decompiled with JetBrains decompiler
// Type: MinMaxRangeAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
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
