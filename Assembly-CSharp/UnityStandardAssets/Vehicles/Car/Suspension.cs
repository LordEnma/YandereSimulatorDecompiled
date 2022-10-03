// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Vehicles.Car.Suspension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
  public class Suspension : MonoBehaviour
  {
    public GameObject wheel;
    private Vector3 m_TargetOriginalPosition;
    private Vector3 m_Origin;

    private void Start()
    {
      this.m_TargetOriginalPosition = this.wheel.transform.localPosition;
      this.m_Origin = this.transform.localPosition;
    }

    private void Update() => this.transform.localPosition = this.m_Origin + (this.wheel.transform.localPosition - this.m_TargetOriginalPosition);
  }
}
