// Decompiled with JetBrains decompiler
// Type: SmoothLookAtScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SmoothLookAtScript : MonoBehaviour
{
  public Transform Target;
  public float Speed;

  private void LateUpdate() => this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(this.Target.transform.position - this.transform.position), Time.deltaTime * this.Speed);
}
