// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Vehicles.Aeroplane.AeroplaneControlSurfaceAnimator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
  public class AeroplaneControlSurfaceAnimator : MonoBehaviour
  {
    [SerializeField]
    private float m_Smoothing = 5f;
    [SerializeField]
    private AeroplaneControlSurfaceAnimator.ControlSurface[] m_ControlSurfaces;
    private AeroplaneController m_Plane;

    private void Start()
    {
      this.m_Plane = this.GetComponent<AeroplaneController>();
      foreach (AeroplaneControlSurfaceAnimator.ControlSurface controlSurface in this.m_ControlSurfaces)
        controlSurface.originalLocalRotation = controlSurface.transform.localRotation;
    }

    private void Update()
    {
      foreach (AeroplaneControlSurfaceAnimator.ControlSurface controlSurface in this.m_ControlSurfaces)
      {
        switch (controlSurface.type)
        {
          case AeroplaneControlSurfaceAnimator.ControlSurface.Type.Aileron:
            Quaternion rotation1 = Quaternion.Euler(controlSurface.amount * this.m_Plane.RollInput, 0.0f, 0.0f);
            this.RotateSurface(controlSurface, rotation1);
            break;
          case AeroplaneControlSurfaceAnimator.ControlSurface.Type.Elevator:
            Quaternion rotation2 = Quaternion.Euler(controlSurface.amount * -this.m_Plane.PitchInput, 0.0f, 0.0f);
            this.RotateSurface(controlSurface, rotation2);
            break;
          case AeroplaneControlSurfaceAnimator.ControlSurface.Type.Rudder:
            Quaternion rotation3 = Quaternion.Euler(0.0f, controlSurface.amount * this.m_Plane.YawInput, 0.0f);
            this.RotateSurface(controlSurface, rotation3);
            break;
          case AeroplaneControlSurfaceAnimator.ControlSurface.Type.RuddervatorNegative:
            float num1 = this.m_Plane.YawInput - this.m_Plane.PitchInput;
            Quaternion rotation4 = Quaternion.Euler(0.0f, 0.0f, controlSurface.amount * num1);
            this.RotateSurface(controlSurface, rotation4);
            break;
          case AeroplaneControlSurfaceAnimator.ControlSurface.Type.RuddervatorPositive:
            float num2 = this.m_Plane.YawInput + this.m_Plane.PitchInput;
            Quaternion rotation5 = Quaternion.Euler(0.0f, 0.0f, controlSurface.amount * num2);
            this.RotateSurface(controlSurface, rotation5);
            break;
        }
      }
    }

    private void RotateSurface(
      AeroplaneControlSurfaceAnimator.ControlSurface surface,
      Quaternion rotation)
    {
      Quaternion b = surface.originalLocalRotation * rotation;
      surface.transform.localRotation = Quaternion.Slerp(surface.transform.localRotation, b, this.m_Smoothing * Time.deltaTime);
    }

    [Serializable]
    public class ControlSurface
    {
      public Transform transform;
      public float amount;
      public AeroplaneControlSurfaceAnimator.ControlSurface.Type type;
      [HideInInspector]
      public Quaternion originalLocalRotation;

      public enum Type
      {
        Aileron,
        Elevator,
        Rudder,
        RuddervatorNegative,
        RuddervatorPositive,
      }
    }
  }
}
