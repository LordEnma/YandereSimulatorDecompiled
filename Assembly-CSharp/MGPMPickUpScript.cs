// Decompiled with JetBrains decompiler
// Type: MGPMPickUpScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MGPMPickUpScript : MonoBehaviour
{
  public float Speed;

  private void Update()
  {
    this.transform.Translate(Vector3.up * Time.deltaTime * this.Speed * -1f);
    if ((double) this.transform.localPosition.y >= -300.0)
      return;
    Object.Destroy((Object) this.gameObject);
  }
}
