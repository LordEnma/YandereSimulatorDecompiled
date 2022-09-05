// Decompiled with JetBrains decompiler
// Type: HideColliderScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HideColliderScript : MonoBehaviour
{
  public RagdollScript Corpse;
  public Collider MyCollider;

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer != 11)
      return;
    GameObject gameObject = other.gameObject.transform.root.gameObject;
    if (gameObject.GetComponent<StudentScript>().Alive)
      return;
    this.Corpse = gameObject.GetComponent<RagdollScript>();
    if (this.Corpse.Hidden || this.Corpse.Concealed)
      return;
    this.Corpse.HideCollider = this.MyCollider;
    ++this.Corpse.Police.HiddenCorpses;
    this.Corpse.Hidden = true;
  }
}
