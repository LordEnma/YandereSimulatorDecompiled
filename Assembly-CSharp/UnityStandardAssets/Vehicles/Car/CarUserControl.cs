// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Vehicles.Car.CarUserControl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
  [RequireComponent(typeof (CarController))]
  public class CarUserControl : MonoBehaviour
  {
    private CarController m_Car;

    private void Awake() => this.m_Car = this.GetComponent<CarController>();

    private void FixedUpdate()
    {
      float axis1 = CrossPlatformInputManager.GetAxis("Horizontal");
      float axis2 = CrossPlatformInputManager.GetAxis("Vertical");
      float axis3 = CrossPlatformInputManager.GetAxis("Jump");
      this.m_Car.Move(axis1, axis2, axis2, axis3);
    }
  }
}
