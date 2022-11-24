// Decompiled with JetBrains decompiler
// Type: ArcTrailScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ArcTrailScript : MonoBehaviour
{
  private static readonly Color TRAIL_TINT_COLOR = new Color(1f, 0.0f, 0.0f, 1f);
  public TrailRenderer Trail;

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer != 9)
      return;
    this.Trail.material.SetColor("_TintColor", ArcTrailScript.TRAIL_TINT_COLOR);
  }
}
