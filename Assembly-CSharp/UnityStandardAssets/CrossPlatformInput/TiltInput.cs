// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.CrossPlatformInput.TiltInput
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
  public class TiltInput : MonoBehaviour
  {
    public TiltInput.AxisMapping mapping;
    public TiltInput.AxisOptions tiltAroundAxis;
    public float fullTiltAngle = 25f;
    public float centreAngleOffset;
    private CrossPlatformInputManager.VirtualAxis m_SteerAxis;

    private void OnEnable()
    {
      if (this.mapping.type != TiltInput.AxisMapping.MappingType.NamedAxis)
        return;
      this.m_SteerAxis = new CrossPlatformInputManager.VirtualAxis(this.mapping.axisName);
      CrossPlatformInputManager.RegisterVirtualAxis(this.m_SteerAxis);
    }

    private void Update()
    {
      float num1 = 0.0f;
      if (Input.acceleration != Vector3.zero)
      {
        switch (this.tiltAroundAxis)
        {
          case TiltInput.AxisOptions.ForwardAxis:
            num1 = Mathf.Atan2(Input.acceleration.x, -Input.acceleration.y) * 57.29578f + this.centreAngleOffset;
            break;
          case TiltInput.AxisOptions.SidewaysAxis:
            num1 = Mathf.Atan2(Input.acceleration.z, -Input.acceleration.y) * 57.29578f + this.centreAngleOffset;
            break;
        }
      }
      float num2 = (float) ((double) Mathf.InverseLerp(-this.fullTiltAngle, this.fullTiltAngle, num1) * 2.0 - 1.0);
      switch (this.mapping.type)
      {
        case TiltInput.AxisMapping.MappingType.NamedAxis:
          this.m_SteerAxis.Update(num2);
          break;
        case TiltInput.AxisMapping.MappingType.MousePositionX:
          CrossPlatformInputManager.SetVirtualMousePositionX(num2 * (float) Screen.width);
          break;
        case TiltInput.AxisMapping.MappingType.MousePositionY:
          CrossPlatformInputManager.SetVirtualMousePositionY(num2 * (float) Screen.width);
          break;
        case TiltInput.AxisMapping.MappingType.MousePositionZ:
          CrossPlatformInputManager.SetVirtualMousePositionZ(num2 * (float) Screen.width);
          break;
      }
    }

    private void OnDisable() => this.m_SteerAxis.Remove();

    public enum AxisOptions
    {
      ForwardAxis,
      SidewaysAxis,
    }

    [Serializable]
    public class AxisMapping
    {
      public TiltInput.AxisMapping.MappingType type;
      public string axisName;

      public enum MappingType
      {
        NamedAxis,
        MousePositionX,
        MousePositionY,
        MousePositionZ,
      }
    }
  }
}
