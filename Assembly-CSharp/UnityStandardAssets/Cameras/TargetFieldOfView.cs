using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000554 RID: 1364
	public class TargetFieldOfView : AbstractTargetFollower
	{
		// Token: 0x060022DB RID: 8923 RVA: 0x001F5FC5 File Offset: 0x001F41C5
		protected override void Start()
		{
			base.Start();
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(this.m_Target, this.m_IncludeEffectsInSize);
			this.m_Cam = base.GetComponentInChildren<Camera>();
		}

		// Token: 0x060022DC RID: 8924 RVA: 0x001F5FF0 File Offset: 0x001F41F0
		protected override void FollowTarget(float deltaTime)
		{
			float magnitude = (this.m_Target.position - base.transform.position).magnitude;
			float target = Mathf.Atan2(this.m_BoundSize, magnitude) * 57.29578f * this.m_ZoomAmountMultiplier;
			this.m_Cam.fieldOfView = Mathf.SmoothDamp(this.m_Cam.fieldOfView, target, ref this.m_FovAdjustVelocity, this.m_FovAdjustTime);
		}

		// Token: 0x060022DD RID: 8925 RVA: 0x001F6063 File Offset: 0x001F4263
		public override void SetTarget(Transform newTransform)
		{
			base.SetTarget(newTransform);
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(newTransform, this.m_IncludeEffectsInSize);
		}

		// Token: 0x060022DE RID: 8926 RVA: 0x001F6080 File Offset: 0x001F4280
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

		// Token: 0x04004B6F RID: 19311
		[SerializeField]
		private float m_FovAdjustTime = 1f;

		// Token: 0x04004B70 RID: 19312
		[SerializeField]
		private float m_ZoomAmountMultiplier = 2f;

		// Token: 0x04004B71 RID: 19313
		[SerializeField]
		private bool m_IncludeEffectsInSize;

		// Token: 0x04004B72 RID: 19314
		private float m_BoundSize;

		// Token: 0x04004B73 RID: 19315
		private float m_FovAdjustVelocity;

		// Token: 0x04004B74 RID: 19316
		private Camera m_Cam;

		// Token: 0x04004B75 RID: 19317
		private Transform m_LastTarget;
	}
}
