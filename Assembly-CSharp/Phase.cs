// Decompiled with JetBrains decompiler
// Type: Phase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
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
