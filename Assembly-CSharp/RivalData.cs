// Decompiled with JetBrains decompiler
// Type: RivalData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
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
