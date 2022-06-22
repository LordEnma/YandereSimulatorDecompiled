// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Vehicles.Aeroplane.AeroplaneUserControl4Axis
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
  [RequireComponent(typeof (AeroplaneController))]
  public class AeroplaneUserControl4Axis : MonoBehaviour
  {
    public float maxRollAngle = 80f;
    public float maxPitchAngle = 80f;
    private AeroplaneController m_Aeroplane;
    private float m_Throttle;
    private bool m_AirBrakes;
    private float m_Yaw;

    private void Awake() => this.m_Aeroplane = this.GetComponent<AeroplaneController>();

    private void FixedUpdate()
    {
      float axis1 = CrossPlatformInputManager.GetAxis("Mouse X");
      float axis2 = CrossPlatformInputManager.GetAxis("Mouse Y");
      this.m_AirBrakes = CrossPlatformInputManager.GetButton("Fire1");
      this.m_Yaw = CrossPlatformInputManager.GetAxis("Horizontal");
      this.m_Throttle = CrossPlatformInputManager.GetAxis("Vertical");
      this.m_Aeroplane.Move(axis1, axis2, this.m_Yaw, this.m_Throttle, this.m_AirBrakes);
    }

    private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
    {
      float num1 = (float) ((double) roll * (double) this.maxRollAngle * (Math.PI / 180.0));
      float num2 = (float) ((double) pitch * (double) this.maxPitchAngle * (Math.PI / 180.0));
      roll = Mathf.Clamp(num1 - this.m_Aeroplane.RollAngle, -1f, 1f);
      pitch = Mathf.Clamp(num2 - this.m_Aeroplane.PitchAngle, -1f, 1f);
    }
  }
}
