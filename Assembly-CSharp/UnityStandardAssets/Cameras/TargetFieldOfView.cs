using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000547 RID: 1351
	public class TargetFieldOfView : AbstractTargetFollower
	{
		// Token: 0x0600228B RID: 8843 RVA: 0x001EED21 File Offset: 0x001ECF21
		protected override void Start()
		{
			base.Start();
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(this.m_Target, this.m_IncludeEffectsInSize);
			this.m_Cam = base.GetComponentInChildren<Camera>();
		}

		// Token: 0x0600228C RID: 8844 RVA: 0x001EED4C File Offset: 0x001ECF4C
		protected override void FollowTarget(float deltaTime)
		{
			float magnitude = (this.m_Target.position - base.transform.position).magnitude;
			float target = Mathf.Atan2(this.m_BoundSize, magnitude) * 57.29578f * this.m_ZoomAmountMultiplier;
			this.m_Cam.fieldOfView = Mathf.SmoothDamp(this.m_Cam.fieldOfView, target, ref this.m_FovAdjustVelocity, this.m_FovAdjustTime);
		}

		// Token: 0x0600228D RID: 8845 RVA: 0x001EEDBF File Offset: 0x001ECFBF
		public override void SetTarget(Transform newTransform)
		{
			base.SetTarget(newTransform);
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(newTransform, this.m_IncludeEffectsInSize);
		}

		// Token: 0x0600228E RID: 8846 RVA: 0x001EEDDC File Offset: 0x001ECFDC
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

		// Token: 0x04004A85 RID: 19077
		[SerializeField]
		private float m_FovAdjustTime = 1f;

		// Token: 0x04004A86 RID: 19078
		[SerializeField]
		private float m_ZoomAmountMultiplier = 2f;

		// Token: 0x04004A87 RID: 19079
		[SerializeField]
		private bool m_IncludeEffectsInSize;

		// Token: 0x04004A88 RID: 19080
		private float m_BoundSize;

		// Token: 0x04004A89 RID: 19081
		private float m_FovAdjustVelocity;

		// Token: 0x04004A8A RID: 19082
		private Camera m_Cam;

		// Token: 0x04004A8B RID: 19083
		private Transform m_LastTarget;
	}
}
