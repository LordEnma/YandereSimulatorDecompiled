// Decompiled with JetBrains decompiler
// Type: Phase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public class Phase
{
  [SerializeField]
  private PhaseOfDay type;

  public Phase(PhaseOfDay type) => this.type = type;

  public PhaseOfDay Type => this.type;
}
