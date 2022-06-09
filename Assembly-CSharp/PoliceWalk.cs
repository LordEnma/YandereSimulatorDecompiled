// Decompiled with JetBrains decompiler
// Type: PoliceWalk
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
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
