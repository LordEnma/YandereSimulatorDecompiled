// Decompiled with JetBrains decompiler
// Type: UISoundVolume
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[RequireComponent(typeof (UISlider))]
[AddComponentMenu("NGUI/Interaction/Sound Volume")]
public class UISoundVolume : MonoBehaviour
{
  private void Awake()
  {
    UISlider component = this.GetComponent<UISlider>();
    component.value = NGUITools.soundVolume;
    EventDelegate.Add(component.onChange, new EventDelegate.Callback(this.OnChange));
  }

  private void OnChange() => NGUITools.soundVolume = UIProgressBar.current.value;
}
