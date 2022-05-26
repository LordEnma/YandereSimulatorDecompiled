// Decompiled with JetBrains decompiler
// Type: BloodSprayColliderScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
