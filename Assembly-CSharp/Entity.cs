// Decompiled with JetBrains decompiler
// Type: Entity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public abstract class Entity
{
  [SerializeField]
  private GenderType gender;
  [SerializeField]
  private DeathType deathType;

  public Entity(GenderType gender)
  {
    this.gender = gender;
    this.deathType = DeathType.None;
  }

  public GenderType Gender => this.gender;

  public DeathType DeathType
  {
    get => this.deathType;
    set => this.deathType = value;
  }

  public abstract EntityType EntityType { get; }
}
