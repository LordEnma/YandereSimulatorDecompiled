using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000543 RID: 1347
	public class TargetFieldOfView : AbstractTargetFollower
	{
		// Token: 0x0600226B RID: 8811 RVA: 0x001EBE51 File Offset: 0x001EA051
		protected override void Start()
		{
			base.Start();
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(this.m_Target, this.m_IncludeEffectsInSize);
			this.m_Cam = base.GetComponentInChildren<Camera>();
		}

		// Token: 0x0600226C RID: 8812 RVA: 0x001EBE7C File Offset: 0x001EA07C
		protected override void FollowTarget(float deltaTime)
		{
			float magnitude = (this.m_Target.position - base.transform.position).magnitude;
			float target = Mathf.Atan2(this.m_BoundSize, magnitude) * 57.29578f * this.m_ZoomAmountMultiplier;
			this.m_Cam.fieldOfView = Mathf.SmoothDamp(this.m_Cam.fieldOfView, target, ref this.m_FovAdjustVelocity, this.m_FovAdjustTime);
		}

		// Token: 0x0600226D RID: 8813 RVA: 0x001EBEEF File Offset: 0x001EA0EF
		public override void SetTarget(Transform newTransform)
		{
			base.SetTarget(newTransform);
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(newTransform, this.m_IncludeEffectsInSize);
		}

		// Token: 0x0600226E RID: 8814 RVA: 0x001EBF0C File Offset: 0x001EA10C
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

		// Token: 0x04004A44 RID: 19012
		[SerializeField]
		private float m_FovAdjustTime = 1f;

		// Token: 0x04004A45 RID: 19013
		[SerializeField]
		private float m_ZoomAmountMultiplier = 2f;

		// Token: 0x04004A46 RID: 19014
		[SerializeField]
		private bool m_IncludeEffectsInSize;

		// Token: 0x04004A47 RID: 19015
		private float m_BoundSize;

		// Token: 0x04004A48 RID: 19016
		private float m_FovAdjustVelocity;

		// Token: 0x04004A49 RID: 19017
		private Camera m_Cam;

		// Token: 0x04004A4A RID: 19018
		private Transform m_LastTarget;
	}
}
