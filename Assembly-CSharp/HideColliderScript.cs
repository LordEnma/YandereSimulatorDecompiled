// Decompiled with JetBrains decompiler
// Type: HideColliderScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
