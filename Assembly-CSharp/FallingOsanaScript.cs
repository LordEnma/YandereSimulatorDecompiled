// Decompiled with JetBrains decompiler
// Type: FallingOsanaScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FallingOsanaScript : MonoBehaviour
{
  public StudentScript Osana;
  public GameObject GroundImpact;

  private void Update()
  {
    if ((double) this.transform.position.y > 0.0)
      this.transform.position += new Vector3(0.0f, -1.0001f, 0.0f);
    if ((double) this.transform.position.y >= 0.0)
      return;
    this.transform.position = new Vector3(this.transform.position.x, 0.0f, this.transform.position.z);
    Object.Instantiate<GameObject>(this.GroundImpact, this.transform.position, Quaternion.identity);
  }
}
