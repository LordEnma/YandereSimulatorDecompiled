// Decompiled with JetBrains decompiler
// Type: RangeInt
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public class RangeInt
{
  [SerializeField]
  private int value;
  [SerializeField]
  private int min;
  [SerializeField]
  private int max;

  public RangeInt(int value, int min, int max)
  {
    this.value = value;
    this.min = min;
    this.max = max;
  }

  public RangeInt(int min, int max)
    : this(min, min, max)
  {
  }

  public int Value
  {
    get => this.value;
    set => this.value = value;
  }

  public int Min => this.min;

  public int Max => this.max;

  public int Next => this.value != this.max ? this.value + 1 : this.min;

  public int Previous => this.value != this.min ? this.value - 1 : this.max;
}
