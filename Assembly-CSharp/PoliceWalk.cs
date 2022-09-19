// Decompiled with JetBrains decompiler
// Type: PoliceWalk
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
