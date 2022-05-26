// Decompiled with JetBrains decompiler
// Type: PoliceWalk
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PoliceWalk : MonoBehaviour
{
  private void Update()
  {
    Vector3 position = this.transform.position;
    position.z += Time.deltaTime;
    this.transform.position = position;
  }
}
