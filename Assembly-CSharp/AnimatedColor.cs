// Decompiled with JetBrains decompiler
// Type: AnimatedColor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof (UIWidget))]
public class AnimatedColor : MonoBehaviour
{
  public Color color = Color.white;
  private UIWidget mWidget;

  private void OnEnable()
  {
    this.mWidget = this.GetComponent<UIWidget>();
    this.LateUpdate();
  }

  private void LateUpdate() => this.mWidget.color = this.color;
}
