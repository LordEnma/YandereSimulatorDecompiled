// Decompiled with JetBrains decompiler
// Type: RiggedAttacher
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RiggedAttacher : MonoBehaviour
{
  public Transform BasePelvisRoot;
  public Transform AttachmentPelvisRoot;

  private void Start() => this.Attaching(this.BasePelvisRoot, this.AttachmentPelvisRoot);

  private void Attaching(Transform Base, Transform Attachment)
  {
    Attachment.transform.SetParent(Base);
    Base.localEulerAngles = Vector3.zero;
    Base.localPosition = Vector3.zero;
    Transform[] componentsInChildren = Base.GetComponentsInChildren<Transform>();
    foreach (Transform componentsInChild in Attachment.GetComponentsInChildren<Transform>())
    {
      foreach (Transform p in componentsInChildren)
      {
        if (componentsInChild.name == p.name)
        {
          componentsInChild.SetParent(p);
          componentsInChild.localEulerAngles = Vector3.zero;
          componentsInChild.localPosition = Vector3.zero;
        }
      }
    }
  }
}
