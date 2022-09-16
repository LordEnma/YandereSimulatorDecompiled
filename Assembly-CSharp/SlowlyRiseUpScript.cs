// Decompiled with JetBrains decompiler
// Type: SlowlyRiseUpScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SlowlyRiseUpScript : MonoBehaviour
{
  public Transform Target;
  public float Speed;
  public bool Begin;

  private void Update()
  {
    if (Input.GetKeyDown("space"))
      this.Begin = true;
    if (!this.Begin)
      return;
    this.Speed += Time.deltaTime;
    this.transform.position = Vector3.Lerp(this.transform.position, this.Target.position, Time.deltaTime * this.Speed);
  }
}
