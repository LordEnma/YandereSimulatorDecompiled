﻿// Decompiled with JetBrains decompiler
// Type: SetColorPickerColor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[RequireComponent(typeof (UIWidget))]
public class SetColorPickerColor : MonoBehaviour
{
  [NonSerialized]
  private UIWidget mWidget;

  public void SetToCurrent()
  {
    if ((UnityEngine.Object) this.mWidget == (UnityEngine.Object) null)
      this.mWidget = this.GetComponent<UIWidget>();
    if (!((UnityEngine.Object) UIColorPicker.current != (UnityEngine.Object) null))
      return;
    this.mWidget.color = UIColorPicker.current.value;
  }
}