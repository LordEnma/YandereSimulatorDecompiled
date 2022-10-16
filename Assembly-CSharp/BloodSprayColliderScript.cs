// Decompiled with JetBrains decompiler
// Type: BloodSprayColliderScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
