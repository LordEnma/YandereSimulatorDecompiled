// Decompiled with JetBrains decompiler
// Type: InspectorButtonAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
