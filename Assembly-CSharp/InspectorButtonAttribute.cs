﻿// Decompiled with JetBrains decompiler
// Type: InspectorButtonAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class InspectorButtonAttribute : PropertyAttribute
{
  public static float kDefaultButtonWidth = 150f;
  public readonly string MethodName;
  private float _buttonWidth = InspectorButtonAttribute.kDefaultButtonWidth;

  public float ButtonWidth
  {
    get => this._buttonWidth;
    set => this._buttonWidth = value;
  }

  public InspectorButtonAttribute(string MethodName) => this.MethodName = MethodName;
}