// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Vehicles.Aeroplane.AeroplaneUserControl2Axis
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
  [RequireComponent(typeof (AeroplaneController))]
  public class AeroplaneUserControl2Axis : MonoBehaviour
  {
    public float maxRollAngle = 80f;
    public float maxPitchAngle = 80f;
    private AeroplaneController m_Aeroplane;

    private void Awake() => this.m_Aeroplane = this.GetComponent<AeroplaneController>();

    private void FixedUpdate()
    {
      float axis1 = CrossPlatformInputManager.GetAxis("Horizontal");
      float axis2 = CrossPlatformInputManager.GetAxis("Vertical");
      bool button = CrossPlatformInputManager.GetButton("Fire1");
      float throttleInput = button ? -1f : 1f;
      this.m_Aeroplane.Move(axis1, axis2, 0.0f, throttleInput, button);
    }

    private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
    {
      float num1 = (float) ((double) roll * (double) this.maxRollAngle * (Math.PI / 180.0));
      float num2 = (float) ((double) pitch * (double) this.maxPitchAngle * (Math.PI / 180.0));
      roll = Mathf.Clamp(num1 - this.m_Aeroplane.RollAngle, -1f, 1f);
      pitch = Mathf.Clamp(num2 - this.m_Aeroplane.PitchAngle, -1f, 1f);
      float num3 = (float) ((double) throttle * 0.5 + 0.5);
      throttle = Mathf.Clamp(num3 - this.m_Aeroplane.Throttle, -1f, 1f);
    }
  }
}
