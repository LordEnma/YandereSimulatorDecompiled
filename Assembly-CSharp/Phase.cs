// Decompiled with JetBrains decompiler
// Type: Phase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
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
