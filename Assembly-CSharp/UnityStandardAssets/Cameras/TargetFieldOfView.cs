using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000548 RID: 1352
	public class TargetFieldOfView : AbstractTargetFollower
	{
		// Token: 0x06002294 RID: 8852 RVA: 0x001EF901 File Offset: 0x001EDB01
		protected override void Start()
		{
			base.Start();
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(this.m_Target, this.m_IncludeEffectsInSize);
			this.m_Cam = base.GetComponentInChildren<Camera>();
		}

		// Token: 0x06002295 RID: 8853 RVA: 0x001EF92C File Offset: 0x001EDB2C
		protected override void FollowTarget(float deltaTime)
		{
			float magnitude = (this.m_Target.position - base.transform.position).magnitude;
			float target = Mathf.Atan2(this.m_BoundSize, magnitude) * 57.29578f * this.m_ZoomAmountMultiplier;
			this.m_Cam.fieldOfView = Mathf.SmoothDamp(this.m_Cam.fieldOfView, target, ref this.m_FovAdjustVelocity, this.m_FovAdjustTime);
		}

		// Token: 0x06002296 RID: 8854 RVA: 0x001EF99F File Offset: 0x001EDB9F
		public override void SetTarget(Transform newTransform)
		{
			base.SetTarget(newTransform);
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(newTransform, this.m_IncludeEffectsInSize);
		}

		// Token: 0x06002297 RID: 8855 RVA: 0x001EF9BC File Offset: 0x001EDBBC
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

		// Token: 0x04004A95 RID: 19093
		[SerializeField]
		private float m_FovAdjustTime = 1f;

		// Token: 0x04004A96 RID: 19094
		[SerializeField]
		private float m_ZoomAmountMultiplier = 2f;

		// Token: 0x04004A97 RID: 19095
		[SerializeField]
		private bool m_IncludeEffectsInSize;

		// Token: 0x04004A98 RID: 19096
		private float m_BoundSize;

		// Token: 0x04004A99 RID: 19097
		private float m_FovAdjustVelocity;

		// Token: 0x04004A9A RID: 19098
		private Camera m_Cam;

		// Token: 0x04004A9B RID: 19099
		private Transform m_LastTarget;
	}
}
