// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Cameras.HandHeldCam
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace UnityStandardAssets.Cameras
{
  public class HandHeldCam : LookatTarget
  {
    [SerializeField]
    private float m_SwaySpeed = 0.5f;
    [SerializeField]
    private float m_BaseSwayAmount = 0.5f;
    [SerializeField]
    private float m_TrackingSwayAmount = 0.5f;
    [Range(-1f, 1f)]
    [SerializeField]
    private float m_TrackingBias;

    protected override void FollowTarget(float deltaTime)
    {
      base.FollowTarget(deltaTime);
      float num1 = Mathf.PerlinNoise(0.0f, Time.time * this.m_SwaySpeed) - 0.5f;
      float num2 = Mathf.PerlinNoise(0.0f, (float) ((double) Time.time * (double) this.m_SwaySpeed + 100.0)) - 0.5f;
      float num3 = num1 * this.m_BaseSwayAmount;
      float num4 = num2 * this.m_BaseSwayAmount;
      float num5 = Mathf.PerlinNoise(0.0f, Time.time * this.m_SwaySpeed) - 0.5f + this.m_TrackingBias;
      float num6 = Mathf.PerlinNoise(0.0f, (float) ((double) Time.time * (double) this.m_SwaySpeed + 100.0)) - 0.5f + this.m_TrackingBias;
      float num7 = num5 * (-this.m_TrackingSwayAmount * this.m_FollowVelocity.x);
      float num8 = num6 * (this.m_TrackingSwayAmount * this.m_FollowVelocity.y);
      this.transform.Rotate(num3 + num7, num4 + num8, 0.0f);
    }
  }
}
