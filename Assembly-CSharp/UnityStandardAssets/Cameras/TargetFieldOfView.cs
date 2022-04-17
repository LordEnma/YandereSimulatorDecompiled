using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000553 RID: 1363
	public class TargetFieldOfView : AbstractTargetFollower
	{
		// Token: 0x060022D1 RID: 8913 RVA: 0x001F4A3D File Offset: 0x001F2C3D
		protected override void Start()
		{
			base.Start();
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(this.m_Target, this.m_IncludeEffectsInSize);
			this.m_Cam = base.GetComponentInChildren<Camera>();
		}

		// Token: 0x060022D2 RID: 8914 RVA: 0x001F4A68 File Offset: 0x001F2C68
		protected override void FollowTarget(float deltaTime)
		{
			float magnitude = (this.m_Target.position - base.transform.position).magnitude;
			float target = Mathf.Atan2(this.m_BoundSize, magnitude) * 57.29578f * this.m_ZoomAmountMultiplier;
			this.m_Cam.fieldOfView = Mathf.SmoothDamp(this.m_Cam.fieldOfView, target, ref this.m_FovAdjustVelocity, this.m_FovAdjustTime);
		}

		// Token: 0x060022D3 RID: 8915 RVA: 0x001F4ADB File Offset: 0x001F2CDB
		public override void SetTarget(Transform newTransform)
		{
			base.SetTarget(newTransform);
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(newTransform, this.m_IncludeEffectsInSize);
		}

		// Token: 0x060022D4 RID: 8916 RVA: 0x001F4AF8 File Offset: 0x001F2CF8
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

		// Token: 0x04004B59 RID: 19289
		[SerializeField]
		private float m_FovAdjustTime = 1f;

		// Token: 0x04004B5A RID: 19290
		[SerializeField]
		private float m_ZoomAmountMultiplier = 2f;

		// Token: 0x04004B5B RID: 19291
		[SerializeField]
		private bool m_IncludeEffectsInSize;

		// Token: 0x04004B5C RID: 19292
		private float m_BoundSize;

		// Token: 0x04004B5D RID: 19293
		private float m_FovAdjustVelocity;

		// Token: 0x04004B5E RID: 19294
		private Camera m_Cam;

		// Token: 0x04004B5F RID: 19295
		private Transform m_LastTarget;
	}
}
