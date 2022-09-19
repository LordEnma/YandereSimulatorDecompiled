// Decompiled with JetBrains decompiler
// Type: Phase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
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
