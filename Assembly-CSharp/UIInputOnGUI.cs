// Decompiled with JetBrains decompiler
// Type: UIInputOnGUI
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[RequireComponent(typeof (UIInput))]
public class UIInputOnGUI : MonoBehaviour
{
  [NonSerialized]
  private UIInput mInput;

  private void Awake() => this.mInput = this.GetComponent<UIInput>();

  private void OnGUI()
  {
    if (Event.current.rawType != UnityEngine.EventType.KeyDown)
      return;
    this.mInput.ProcessEvent(Event.current);
  }
}
