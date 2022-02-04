using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000546 RID: 1350
	public class TargetFieldOfView : AbstractTargetFollower
	{
		// Token: 0x06002281 RID: 8833 RVA: 0x001EE669 File Offset: 0x001EC869
		protected override void Start()
		{
			base.Start();
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(this.m_Target, this.m_IncludeEffectsInSize);
			this.m_Cam = base.GetComponentInChildren<Camera>();
		}

		// Token: 0x06002282 RID: 8834 RVA: 0x001EE694 File Offset: 0x001EC894
		protected override void FollowTarget(float deltaTime)
		{
			float magnitude = (this.m_Target.position - base.transform.position).magnitude;
			float target = Mathf.Atan2(this.m_BoundSize, magnitude) * 57.29578f * this.m_ZoomAmountMultiplier;
			this.m_Cam.fieldOfView = Mathf.SmoothDamp(this.m_Cam.fieldOfView, target, ref this.m_FovAdjustVelocity, this.m_FovAdjustTime);
		}

		// Token: 0x06002283 RID: 8835 RVA: 0x001EE707 File Offset: 0x001EC907
		public override void SetTarget(Transform newTransform)
		{
			base.SetTarget(newTransform);
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(newTransform, this.m_IncludeEffectsInSize);
		}

		// Token: 0x06002284 RID: 8836 RVA: 0x001EE724 File Offset: 0x001EC924
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

		// Token: 0x04004A79 RID: 19065
		[SerializeField]
		private float m_FovAdjustTime = 1f;

		// Token: 0x04004A7A RID: 19066
		[SerializeField]
		private float m_ZoomAmountMultiplier = 2f;

		// Token: 0x04004A7B RID: 19067
		[SerializeField]
		private bool m_IncludeEffectsInSize;

		// Token: 0x04004A7C RID: 19068
		private float m_BoundSize;

		// Token: 0x04004A7D RID: 19069
		private float m_FovAdjustVelocity;

		// Token: 0x04004A7E RID: 19070
		private Camera m_Cam;

		// Token: 0x04004A7F RID: 19071
		private Transform m_LastTarget;
	}
}
