// Decompiled with JetBrains decompiler
// Type: UIDragDropContainer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
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
