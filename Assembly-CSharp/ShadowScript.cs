// Decompiled with JetBrains decompiler
// Type: ShadowScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ShadowScript : MonoBehaviour
{
  public Transform Foot;

  private void Update()
  {
    Vector3 position1 = this.transform.position;
    Vector3 position2 = this.Foot.position;
    position1.x = position2.x;
    position1.z = position2.z;
    this.transform.position = position1;
  }
}
