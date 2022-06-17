// Decompiled with JetBrains decompiler
// Type: MinMaxRangeAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
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
