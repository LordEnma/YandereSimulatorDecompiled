// Decompiled with JetBrains decompiler
// Type: RivalData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
