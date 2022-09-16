// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Cameras.LookatTarget
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace UnityStandardAssets.Cameras
{
  public class LookatTarget : AbstractTargetFollower
  {
    [SerializeField]
    private Vector2 m_RotationRange;
    [SerializeField]
    private float m_FollowSpeed = 1f;
    private Vector3 m_FollowAngles;
    private Quaternion m_OriginalRotation;
    protected Vector3 m_FollowVelocity;

    protected override void Start()
    {
      base.Start();
      this.m_OriginalRotation = this.transform.localRotation;
    }

    protected override void FollowTarget(float deltaTime)
    {
      this.transform.localRotation = this.m_OriginalRotation;
      Vector3 vector3_1 = this.transform.InverseTransformPoint(this.m_Target.position);
      float num = Mathf.Clamp(Mathf.Atan2(vector3_1.x, vector3_1.z) * 57.29578f, (float) (-(double) this.m_RotationRange.y * 0.5), this.m_RotationRange.y * 0.5f);
      this.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0.0f, num, 0.0f);
      Vector3 vector3_2 = this.transform.InverseTransformPoint(this.m_Target.position);
      this.m_FollowAngles = Vector3.SmoothDamp(this.m_FollowAngles, new Vector3(this.m_FollowAngles.x + Mathf.DeltaAngle(this.m_FollowAngles.x, Mathf.Clamp(Mathf.Atan2(vector3_2.y, vector3_2.z) * 57.29578f, (float) (-(double) this.m_RotationRange.x * 0.5), this.m_RotationRange.x * 0.5f)), this.m_FollowAngles.y + Mathf.DeltaAngle(this.m_FollowAngles.y, num)), ref this.m_FollowVelocity, this.m_FollowSpeed);
      this.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(-this.m_FollowAngles.x, this.m_FollowAngles.y, 0.0f);
    }
  }
}
