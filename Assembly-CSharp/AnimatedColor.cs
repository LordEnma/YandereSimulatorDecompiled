// Decompiled with JetBrains decompiler
// Type: AnimatedColor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
