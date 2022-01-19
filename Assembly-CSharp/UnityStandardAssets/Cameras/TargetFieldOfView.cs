using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000546 RID: 1350
	public class TargetFieldOfView : AbstractTargetFollower
	{
		// Token: 0x0600227B RID: 8827 RVA: 0x001EDAB1 File Offset: 0x001EBCB1
		protected override void Start()
		{
			base.Start();
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(this.m_Target, this.m_IncludeEffectsInSize);
			this.m_Cam = base.GetComponentInChildren<Camera>();
		}

		// Token: 0x0600227C RID: 8828 RVA: 0x001EDADC File Offset: 0x001EBCDC
		protected override void FollowTarget(float deltaTime)
		{
			float magnitude = (this.m_Target.position - base.transform.position).magnitude;
			float target = Mathf.Atan2(this.m_BoundSize, magnitude) * 57.29578f * this.m_ZoomAmountMultiplier;
			this.m_Cam.fieldOfView = Mathf.SmoothDamp(this.m_Cam.fieldOfView, target, ref this.m_FovAdjustVelocity, this.m_FovAdjustTime);
		}

		// Token: 0x0600227D RID: 8829 RVA: 0x001EDB4F File Offset: 0x001EBD4F
		public override void SetTarget(Transform newTransform)
		{
			base.SetTarget(newTransform);
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(newTransform, this.m_IncludeEffectsInSize);
		}

		// Token: 0x0600227E RID: 8830 RVA: 0x001EDB6C File Offset: 0x001EBD6C
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

		// Token: 0x04004A68 RID: 19048
		[SerializeField]
		private float m_FovAdjustTime = 1f;

		// Token: 0x04004A69 RID: 19049
		[SerializeField]
		private float m_ZoomAmountMultiplier = 2f;

		// Token: 0x04004A6A RID: 19050
		[SerializeField]
		private bool m_IncludeEffectsInSize;

		// Token: 0x04004A6B RID: 19051
		private float m_BoundSize;

		// Token: 0x04004A6C RID: 19052
		private float m_FovAdjustVelocity;

		// Token: 0x04004A6D RID: 19053
		private Camera m_Cam;

		// Token: 0x04004A6E RID: 19054
		private Transform m_LastTarget;
	}
}
