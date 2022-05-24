using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000555 RID: 1365
	public class TargetFieldOfView : AbstractTargetFollower
	{
		// Token: 0x060022E6 RID: 8934 RVA: 0x001F7B7D File Offset: 0x001F5D7D
		protected override void Start()
		{
			base.Start();
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(this.m_Target, this.m_IncludeEffectsInSize);
			this.m_Cam = base.GetComponentInChildren<Camera>();
		}

		// Token: 0x060022E7 RID: 8935 RVA: 0x001F7BA8 File Offset: 0x001F5DA8
		protected override void FollowTarget(float deltaTime)
		{
			float magnitude = (this.m_Target.position - base.transform.position).magnitude;
			float target = Mathf.Atan2(this.m_BoundSize, magnitude) * 57.29578f * this.m_ZoomAmountMultiplier;
			this.m_Cam.fieldOfView = Mathf.SmoothDamp(this.m_Cam.fieldOfView, target, ref this.m_FovAdjustVelocity, this.m_FovAdjustTime);
		}

		// Token: 0x060022E8 RID: 8936 RVA: 0x001F7C1B File Offset: 0x001F5E1B
		public override void SetTarget(Transform newTransform)
		{
			base.SetTarget(newTransform);
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(newTransform, this.m_IncludeEffectsInSize);
		}

		// Token: 0x060022E9 RID: 8937 RVA: 0x001F7C38 File Offset: 0x001F5E38
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

		// Token: 0x04004B9F RID: 19359
		[SerializeField]
		private float m_FovAdjustTime = 1f;

		// Token: 0x04004BA0 RID: 19360
		[SerializeField]
		private float m_ZoomAmountMultiplier = 2f;

		// Token: 0x04004BA1 RID: 19361
		[SerializeField]
		private bool m_IncludeEffectsInSize;

		// Token: 0x04004BA2 RID: 19362
		private float m_BoundSize;

		// Token: 0x04004BA3 RID: 19363
		private float m_FovAdjustVelocity;

		// Token: 0x04004BA4 RID: 19364
		private Camera m_Cam;

		// Token: 0x04004BA5 RID: 19365
		private Transform m_LastTarget;
	}
}
