// Decompiled with JetBrains decompiler
// Type: UIDragDropContainer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Drag and Drop Container")]
public class UIDragDropContainer : MonoBehaviour
{
  public Transform reparentTarget;

  protected virtual void Start()
  {
    if (!((Object) this.reparentTarget == (Object) null))
      return;
    this.reparentTarget = this.transform;
  }
}
