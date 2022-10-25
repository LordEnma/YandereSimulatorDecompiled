// Decompiled with JetBrains decompiler
// Type: RivalData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public class RivalData
{
  [SerializeField]
  private int week;

  public RivalData(int week) => this.week = week;

  public int Week => this.week;
}
