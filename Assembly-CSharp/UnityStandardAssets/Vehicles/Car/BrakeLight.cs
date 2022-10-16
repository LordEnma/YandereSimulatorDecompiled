// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Vehicles.Car.BrakeLight
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
  public class BrakeLight : MonoBehaviour
  {
    public CarController car;
    private Renderer m_Renderer;

    private void Start() => this.m_Renderer = this.GetComponent<Renderer>();

    private void Update() => this.m_Renderer.enabled = (double) this.car.BrakeInput > 0.0;
  }
}
