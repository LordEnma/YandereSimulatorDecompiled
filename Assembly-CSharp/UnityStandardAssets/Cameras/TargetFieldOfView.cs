// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Cameras.TargetFieldOfView
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace UnityStandardAssets.Cameras
{
  public class TargetFieldOfView : AbstractTargetFollower
  {
    [SerializeField]
    private float m_FovAdjustTime = 1f;
    [SerializeField]
    private float m_ZoomAmountMultiplier = 2f;
    [SerializeField]
    private bool m_IncludeEffectsInSize;
    private float m_BoundSize;
    private float m_FovAdjustVelocity;
    private Camera m_Cam;
    private Transform m_LastTarget;

    protected override void Start()
    {
      base.Start();
      this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(this.m_Target, this.m_IncludeEffectsInSize);
      this.m_Cam = this.GetComponentInChildren<Camera>();
    }

    protected override void FollowTarget(float deltaTime) => this.m_Cam.fieldOfView = Mathf.SmoothDamp(this.m_Cam.fieldOfView, Mathf.Atan2(this.m_BoundSize, (this.m_Target.position - this.transform.position).magnitude) * 57.29578f * this.m_ZoomAmountMultiplier, ref this.m_FovAdjustVelocity, this.m_FovAdjustTime);

    public override void SetTarget(Transform newTransform)
    {
      base.SetTarget(newTransform);
      this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(newTransform, this.m_IncludeEffectsInSize);
    }

    public static float MaxBoundsExtent(Transform obj, bool includeEffects)
    {
      Renderer[] componentsInChildren = obj.GetComponentsInChildren<Renderer>();
      Bounds bounds = new Bounds();
      bool flag = false;
      foreach (Renderer renderer in componentsInChildren)
      {
        if (!(renderer is TrailRenderer) && !(renderer is ParticleSystemRenderer))
        {
          if (!flag)
          {
            flag = true;
            bounds = renderer.bounds;
          }
          else
            bounds.Encapsulate(renderer.bounds);
        }
      }
      return Mathf.Max(bounds.extents.x, bounds.extents.y, bounds.extents.z);
    }
  }
}
