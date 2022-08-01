// Decompiled with JetBrains decompiler
// Type: RivalData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
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
