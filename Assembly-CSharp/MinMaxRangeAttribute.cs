// Decompiled with JetBrains decompiler
// Type: MinMaxRangeAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
