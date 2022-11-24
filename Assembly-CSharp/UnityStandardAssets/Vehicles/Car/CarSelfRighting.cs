// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Vehicles.Car.CarSelfRighting
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
  public class CarSelfRighting : MonoBehaviour
  {
    [SerializeField]
    private float m_WaitTime = 3f;
    [SerializeField]
    private float m_VelocityThreshold = 1f;
    private float m_LastOkTime;
    private Rigidbody m_Rigidbody;

    private void Start() => this.m_Rigidbody = this.GetComponent<Rigidbody>();

    private void Update()
    {
      if ((double) this.transform.up.y > 0.0 || (double) this.m_Rigidbody.velocity.magnitude > (double) this.m_VelocityThreshold)
        this.m_LastOkTime = Time.time;
      if ((double) Time.time <= (double) this.m_LastOkTime + (double) this.m_WaitTime)
        return;
      this.RightCar();
    }

    private void RightCar()
    {
      this.transform.position += Vector3.up;
      this.transform.rotation = Quaternion.LookRotation(this.transform.forward);
    }
  }
}
