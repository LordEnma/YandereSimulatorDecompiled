using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000549 RID: 1353
	public class TargetFieldOfView : AbstractTargetFollower
	{
		// Token: 0x0600229A RID: 8858 RVA: 0x001F02D9 File Offset: 0x001EE4D9
		protected override void Start()
		{
			base.Start();
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(this.m_Target, this.m_IncludeEffectsInSize);
			this.m_Cam = base.GetComponentInChildren<Camera>();
		}

		// Token: 0x0600229B RID: 8859 RVA: 0x001F0304 File Offset: 0x001EE504
		protected override void FollowTarget(float deltaTime)
		{
			float magnitude = (this.m_Target.position - base.transform.position).magnitude;
			float target = Mathf.Atan2(this.m_BoundSize, magnitude) * 57.29578f * this.m_ZoomAmountMultiplier;
			this.m_Cam.fieldOfView = Mathf.SmoothDamp(this.m_Cam.fieldOfView, target, ref this.m_FovAdjustVelocity, this.m_FovAdjustTime);
		}

		// Token: 0x0600229C RID: 8860 RVA: 0x001F0377 File Offset: 0x001EE577
		public override void SetTarget(Transform newTransform)
		{
			base.SetTarget(newTransform);
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(newTransform, this.m_IncludeEffectsInSize);
		}

		// Token: 0x0600229D RID: 8861 RVA: 0x001F0394 File Offset: 0x001EE594
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

		// Token: 0x04004AB2 RID: 19122
		[SerializeField]
		private float m_FovAdjustTime = 1f;

		// Token: 0x04004AB3 RID: 19123
		[SerializeField]
		private float m_ZoomAmountMultiplier = 2f;

		// Token: 0x04004AB4 RID: 19124
		[SerializeField]
		private bool m_IncludeEffectsInSize;

		// Token: 0x04004AB5 RID: 19125
		private float m_BoundSize;

		// Token: 0x04004AB6 RID: 19126
		private float m_FovAdjustVelocity;

		// Token: 0x04004AB7 RID: 19127
		private Camera m_Cam;

		// Token: 0x04004AB8 RID: 19128
		private Transform m_LastTarget;
	}
}
