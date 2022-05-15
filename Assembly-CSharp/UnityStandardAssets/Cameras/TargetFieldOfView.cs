using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000555 RID: 1365
	public class TargetFieldOfView : AbstractTargetFollower
	{
		// Token: 0x060022E5 RID: 8933 RVA: 0x001F7615 File Offset: 0x001F5815
		protected override void Start()
		{
			base.Start();
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(this.m_Target, this.m_IncludeEffectsInSize);
			this.m_Cam = base.GetComponentInChildren<Camera>();
		}

		// Token: 0x060022E6 RID: 8934 RVA: 0x001F7640 File Offset: 0x001F5840
		protected override void FollowTarget(float deltaTime)
		{
			float magnitude = (this.m_Target.position - base.transform.position).magnitude;
			float target = Mathf.Atan2(this.m_BoundSize, magnitude) * 57.29578f * this.m_ZoomAmountMultiplier;
			this.m_Cam.fieldOfView = Mathf.SmoothDamp(this.m_Cam.fieldOfView, target, ref this.m_FovAdjustVelocity, this.m_FovAdjustTime);
		}

		// Token: 0x060022E7 RID: 8935 RVA: 0x001F76B3 File Offset: 0x001F58B3
		public override void SetTarget(Transform newTransform)
		{
			base.SetTarget(newTransform);
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(newTransform, this.m_IncludeEffectsInSize);
		}

		// Token: 0x060022E8 RID: 8936 RVA: 0x001F76D0 File Offset: 0x001F58D0
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

		// Token: 0x04004B96 RID: 19350
		[SerializeField]
		private float m_FovAdjustTime = 1f;

		// Token: 0x04004B97 RID: 19351
		[SerializeField]
		private float m_ZoomAmountMultiplier = 2f;

		// Token: 0x04004B98 RID: 19352
		[SerializeField]
		private bool m_IncludeEffectsInSize;

		// Token: 0x04004B99 RID: 19353
		private float m_BoundSize;

		// Token: 0x04004B9A RID: 19354
		private float m_FovAdjustVelocity;

		// Token: 0x04004B9B RID: 19355
		private Camera m_Cam;

		// Token: 0x04004B9C RID: 19356
		private Transform m_LastTarget;
	}
}
