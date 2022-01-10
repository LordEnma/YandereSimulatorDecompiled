using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000545 RID: 1349
	public class TargetFieldOfView : AbstractTargetFollower
	{
		// Token: 0x06002279 RID: 8825 RVA: 0x001ECDE1 File Offset: 0x001EAFE1
		protected override void Start()
		{
			base.Start();
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(this.m_Target, this.m_IncludeEffectsInSize);
			this.m_Cam = base.GetComponentInChildren<Camera>();
		}

		// Token: 0x0600227A RID: 8826 RVA: 0x001ECE0C File Offset: 0x001EB00C
		protected override void FollowTarget(float deltaTime)
		{
			float magnitude = (this.m_Target.position - base.transform.position).magnitude;
			float target = Mathf.Atan2(this.m_BoundSize, magnitude) * 57.29578f * this.m_ZoomAmountMultiplier;
			this.m_Cam.fieldOfView = Mathf.SmoothDamp(this.m_Cam.fieldOfView, target, ref this.m_FovAdjustVelocity, this.m_FovAdjustTime);
		}

		// Token: 0x0600227B RID: 8827 RVA: 0x001ECE7F File Offset: 0x001EB07F
		public override void SetTarget(Transform newTransform)
		{
			base.SetTarget(newTransform);
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(newTransform, this.m_IncludeEffectsInSize);
		}

		// Token: 0x0600227C RID: 8828 RVA: 0x001ECE9C File Offset: 0x001EB09C
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

		// Token: 0x04004A61 RID: 19041
		[SerializeField]
		private float m_FovAdjustTime = 1f;

		// Token: 0x04004A62 RID: 19042
		[SerializeField]
		private float m_ZoomAmountMultiplier = 2f;

		// Token: 0x04004A63 RID: 19043
		[SerializeField]
		private bool m_IncludeEffectsInSize;

		// Token: 0x04004A64 RID: 19044
		private float m_BoundSize;

		// Token: 0x04004A65 RID: 19045
		private float m_FovAdjustVelocity;

		// Token: 0x04004A66 RID: 19046
		private Camera m_Cam;

		// Token: 0x04004A67 RID: 19047
		private Transform m_LastTarget;
	}
}
