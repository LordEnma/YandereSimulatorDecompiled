// Decompiled with JetBrains decompiler
// Type: UIInputOnGUI
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
