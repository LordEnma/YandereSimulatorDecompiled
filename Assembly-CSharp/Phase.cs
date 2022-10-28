// Decompiled with JetBrains decompiler
// Type: Phase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
