// Decompiled with JetBrains decompiler
// Type: UIDragDropContainer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
