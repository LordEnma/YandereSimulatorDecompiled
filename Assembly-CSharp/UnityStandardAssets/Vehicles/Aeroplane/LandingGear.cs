// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Vehicles.Aeroplane.LandingGear
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
  public class LandingGear : MonoBehaviour
  {
    public float raiseAtAltitude = 40f;
    public float lowerAtAltitude = 40f;
    private LandingGear.GearState m_State = LandingGear.GearState.Lowered;
    private Animator m_Animator;
    private Rigidbody m_Rigidbody;
    private AeroplaneController m_Plane;

    private void Start()
    {
      this.m_Plane = this.GetComponent<AeroplaneController>();
      this.m_Animator = this.GetComponent<Animator>();
      this.m_Rigidbody = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
      if (this.m_State == LandingGear.GearState.Lowered && (double) this.m_Plane.Altitude > (double) this.raiseAtAltitude && (double) this.m_Rigidbody.velocity.y > 0.0)
        this.m_State = LandingGear.GearState.Raised;
      if (this.m_State == LandingGear.GearState.Raised && (double) this.m_Plane.Altitude < (double) this.lowerAtAltitude && (double) this.m_Rigidbody.velocity.y < 0.0)
        this.m_State = LandingGear.GearState.Lowered;
      this.m_Animator.SetInteger("GearState", (int) this.m_State);
    }

    private enum GearState
    {
      Raised = -1, // 0xFFFFFFFF
      Lowered = 1,
    }
  }
}
