using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000541 RID: 1345
	public class TargetFieldOfView : AbstractTargetFollower
	{
		// Token: 0x0600225A RID: 8794 RVA: 0x001EA71D File Offset: 0x001E891D
		protected override void Start()
		{
			base.Start();
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(this.m_Target, this.m_IncludeEffectsInSize);
			this.m_Cam = base.GetComponentInChildren<Camera>();
		}

		// Token: 0x0600225B RID: 8795 RVA: 0x001EA748 File Offset: 0x001E8948
		protected override void FollowTarget(float deltaTime)
		{
			float magnitude = (this.m_Target.position - base.transform.position).magnitude;
			float target = Mathf.Atan2(this.m_BoundSize, magnitude) * 57.29578f * this.m_ZoomAmountMultiplier;
			this.m_Cam.fieldOfView = Mathf.SmoothDamp(this.m_Cam.fieldOfView, target, ref this.m_FovAdjustVelocity, this.m_FovAdjustTime);
		}

		// Token: 0x0600225C RID: 8796 RVA: 0x001EA7BB File Offset: 0x001E89BB
		public override void SetTarget(Transform newTransform)
		{
			base.SetTarget(newTransform);
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(newTransform, this.m_IncludeEffectsInSize);
		}

		// Token: 0x0600225D RID: 8797 RVA: 0x001EA7D8 File Offset: 0x001E89D8
		public static float MaxBoundsExtent(Transform obj, bool includeEffects)
		{
			Renderer[] componentsInChildren = obj.GetComponentsInChildren<Renderer>();
			Bounds bounds = default(Bounds);
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
					{
						bounds.Encapsulate(renderer.bounds);
					}
				}
			}
			return Mathf.Max(new float[]
			{
				bounds.extents.x,
				bounds.extents.y,
				bounds.extents.z
			});
		}

		// Token: 0x04004A05 RID: 18949
		[SerializeField]
		private float m_FovAdjustTime = 1f;

		// Token: 0x04004A06 RID: 18950
		[SerializeField]
		private float m_ZoomAmountMultiplier = 2f;

		// Token: 0x04004A07 RID: 18951
		[SerializeField]
		private bool m_IncludeEffectsInSize;

		// Token: 0x04004A08 RID: 18952
		private float m_BoundSize;

		// Token: 0x04004A09 RID: 18953
		private float m_FovAdjustVelocity;

		// Token: 0x04004A0A RID: 18954
		private Camera m_Cam;

		// Token: 0x04004A0B RID: 18955
		private Transform m_LastTarget;
	}
}
