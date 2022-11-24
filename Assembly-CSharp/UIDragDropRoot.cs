// Decompiled with JetBrains decompiler
// Type: UIDragDropRoot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Drag and Drop Root")]
public class UIDragDropRoot : MonoBehaviour
{
  public static Transform root;

  private void OnEnable() => UIDragDropRoot.root = this.transform;

  private void OnDisable()
  {
    if (!((Object) UIDragDropRoot.root == (Object) this.transform))
      return;
    UIDragDropRoot.root = (Transform) null;
  }
}
