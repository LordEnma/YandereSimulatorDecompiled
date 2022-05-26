// Decompiled with JetBrains decompiler
// Type: Stance
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public class Stance
{
  [SerializeField]
  private StanceType current;
  [SerializeField]
  private StanceType previous;

  public Stance(StanceType initialStance)
  {
    this.current = initialStance;
    this.previous = initialStance;
  }

  public StanceType Current
  {
    get => this.current;
    set
    {
      this.previous = this.current;
      this.current = value;
    }
  }

  public StanceType Previous => this.previous;
}
