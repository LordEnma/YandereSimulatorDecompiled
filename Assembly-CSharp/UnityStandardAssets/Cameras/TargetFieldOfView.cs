using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200054D RID: 1357
	public class TargetFieldOfView : AbstractTargetFollower
	{
		// Token: 0x060022B2 RID: 8882 RVA: 0x001F2241 File Offset: 0x001F0441
		protected override void Start()
		{
			base.Start();
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(this.m_Target, this.m_IncludeEffectsInSize);
			this.m_Cam = base.GetComponentInChildren<Camera>();
		}

		// Token: 0x060022B3 RID: 8883 RVA: 0x001F226C File Offset: 0x001F046C
		protected override void FollowTarget(float deltaTime)
		{
			float magnitude = (this.m_Target.position - base.transform.position).magnitude;
			float target = Mathf.Atan2(this.m_BoundSize, magnitude) * 57.29578f * this.m_ZoomAmountMultiplier;
			this.m_Cam.fieldOfView = Mathf.SmoothDamp(this.m_Cam.fieldOfView, target, ref this.m_FovAdjustVelocity, this.m_FovAdjustTime);
		}

		// Token: 0x060022B4 RID: 8884 RVA: 0x001F22DF File Offset: 0x001F04DF
		public override void SetTarget(Transform newTransform)
		{
			base.SetTarget(newTransform);
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(newTransform, this.m_IncludeEffectsInSize);
		}

		// Token: 0x060022B5 RID: 8885 RVA: 0x001F22FC File Offset: 0x001F04FC
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

		// Token: 0x04004B11 RID: 19217
		[SerializeField]
		private float m_FovAdjustTime = 1f;

		// Token: 0x04004B12 RID: 19218
		[SerializeField]
		private float m_ZoomAmountMultiplier = 2f;

		// Token: 0x04004B13 RID: 19219
		[SerializeField]
		private bool m_IncludeEffectsInSize;

		// Token: 0x04004B14 RID: 19220
		private float m_BoundSize;

		// Token: 0x04004B15 RID: 19221
		private float m_FovAdjustVelocity;

		// Token: 0x04004B16 RID: 19222
		private Camera m_Cam;

		// Token: 0x04004B17 RID: 19223
		private Transform m_LastTarget;
	}
}
