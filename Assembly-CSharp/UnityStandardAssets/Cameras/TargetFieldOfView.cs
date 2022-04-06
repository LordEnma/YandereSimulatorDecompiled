using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000553 RID: 1363
	public class TargetFieldOfView : AbstractTargetFollower
	{
		// Token: 0x060022CA RID: 8906 RVA: 0x001F3FE1 File Offset: 0x001F21E1
		protected override void Start()
		{
			base.Start();
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(this.m_Target, this.m_IncludeEffectsInSize);
			this.m_Cam = base.GetComponentInChildren<Camera>();
		}

		// Token: 0x060022CB RID: 8907 RVA: 0x001F400C File Offset: 0x001F220C
		protected override void FollowTarget(float deltaTime)
		{
			float magnitude = (this.m_Target.position - base.transform.position).magnitude;
			float target = Mathf.Atan2(this.m_BoundSize, magnitude) * 57.29578f * this.m_ZoomAmountMultiplier;
			this.m_Cam.fieldOfView = Mathf.SmoothDamp(this.m_Cam.fieldOfView, target, ref this.m_FovAdjustVelocity, this.m_FovAdjustTime);
		}

		// Token: 0x060022CC RID: 8908 RVA: 0x001F407F File Offset: 0x001F227F
		public override void SetTarget(Transform newTransform)
		{
			base.SetTarget(newTransform);
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(newTransform, this.m_IncludeEffectsInSize);
		}

		// Token: 0x060022CD RID: 8909 RVA: 0x001F409C File Offset: 0x001F229C
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

		// Token: 0x04004B47 RID: 19271
		[SerializeField]
		private float m_FovAdjustTime = 1f;

		// Token: 0x04004B48 RID: 19272
		[SerializeField]
		private float m_ZoomAmountMultiplier = 2f;

		// Token: 0x04004B49 RID: 19273
		[SerializeField]
		private bool m_IncludeEffectsInSize;

		// Token: 0x04004B4A RID: 19274
		private float m_BoundSize;

		// Token: 0x04004B4B RID: 19275
		private float m_FovAdjustVelocity;

		// Token: 0x04004B4C RID: 19276
		private Camera m_Cam;

		// Token: 0x04004B4D RID: 19277
		private Transform m_LastTarget;
	}
}
