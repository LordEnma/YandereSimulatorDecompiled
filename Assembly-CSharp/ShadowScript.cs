// Decompiled with JetBrains decompiler
// Type: ShadowScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
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
