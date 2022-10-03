// Decompiled with JetBrains decompiler
// Type: RivalData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
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
