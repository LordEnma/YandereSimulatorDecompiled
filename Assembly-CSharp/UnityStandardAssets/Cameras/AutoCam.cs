// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Cameras.AutoCam
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace UnityStandardAssets.Cameras
{
  [ExecuteInEditMode]
  public class AutoCam : PivotBasedCameraRig
  {
    [SerializeField]
    private float m_MoveSpeed = 3f;
    [SerializeField]
    private float m_TurnSpeed = 1f;
    [SerializeField]
    private float m_RollSpeed = 0.2f;
    [SerializeField]
    private bool m_FollowVelocity;
    [SerializeField]
    private bool m_FollowTilt = true;
    [SerializeField]
    private float m_SpinTurnLimit = 90f;
    [SerializeField]
    private float m_TargetVelocityLowerLimit = 4f;
    [SerializeField]
    private float m_SmoothTurnTime = 0.2f;
    private float m_LastFlatAngle;
    private float m_CurrentTurnAmount;
    private float m_TurnSpeedVelocityChange;
    private Vector3 m_RollUp = Vector3.up;

    protected override void FollowTarget(float deltaTime)
    {
      if ((double) deltaTime <= 0.0 || (Object) this.m_Target == (Object) null)
        return;
      Vector3 forward = this.m_Target.forward;
      Vector3 up = this.m_Target.up;
      if (this.m_FollowVelocity && Application.isPlaying)
      {
        if ((double) this.targetRigidbody.velocity.magnitude > (double) this.m_TargetVelocityLowerLimit)
        {
          forward = this.targetRigidbody.velocity.normalized;
          up = Vector3.up;
        }
        else
          up = Vector3.up;
        this.m_CurrentTurnAmount = Mathf.SmoothDamp(this.m_CurrentTurnAmount, 1f, ref this.m_TurnSpeedVelocityChange, this.m_SmoothTurnTime);
      }
      else
      {
        float target1 = Mathf.Atan2(forward.x, forward.z) * 57.29578f;
        if ((double) this.m_SpinTurnLimit > 0.0)
        {
          float target2 = Mathf.InverseLerp(this.m_SpinTurnLimit, this.m_SpinTurnLimit * 0.75f, Mathf.Abs(Mathf.DeltaAngle(this.m_LastFlatAngle, target1)) / deltaTime);
          float smoothTime = (double) this.m_CurrentTurnAmount > (double) target2 ? 0.1f : 1f;
          this.m_CurrentTurnAmount = !Application.isPlaying ? target2 : Mathf.SmoothDamp(this.m_CurrentTurnAmount, target2, ref this.m_TurnSpeedVelocityChange, smoothTime);
        }
        else
          this.m_CurrentTurnAmount = 1f;
        this.m_LastFlatAngle = target1;
      }
      this.transform.position = Vector3.Lerp(this.transform.position, this.m_Target.position, deltaTime * this.m_MoveSpeed);
      if (!this.m_FollowTilt)
      {
        forward.y = 0.0f;
        if ((double) forward.sqrMagnitude < 1.40129846432482E-45)
          forward = this.transform.forward;
      }
      Quaternion b = Quaternion.LookRotation(forward, this.m_RollUp);
      this.m_RollUp = (double) this.m_RollSpeed > 0.0 ? Vector3.Slerp(this.m_RollUp, up, this.m_RollSpeed * deltaTime) : Vector3.up;
      this.transform.rotation = Quaternion.Lerp(this.transform.rotation, b, this.m_TurnSpeed * this.m_CurrentTurnAmount * deltaTime);
    }
  }
}
