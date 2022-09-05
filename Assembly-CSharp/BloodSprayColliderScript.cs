// Decompiled with JetBrains decompiler
// Type: BloodSprayColliderScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BloodSprayColliderScript : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer != 13)
      return;
    YandereScript component = other.gameObject.GetComponent<YandereScript>();
    if (!((Object) component != (Object) null))
      return;
    component.Bloodiness = 100f;
    Object.Destroy((Object) this.gameObject);
  }
}
